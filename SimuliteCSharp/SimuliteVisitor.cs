using SimuliteCSharp.Nodes;
namespace SimuliteCSharp;

public class SimuliteVisitor: SimuliteBaseVisitor<INode>
{
	public override INode VisitAssignment(SimuliteParser.AssignmentContext context)
	{
		return new AssignNode(
			context.IDENTIFIER().GetText(),
			Visit(context.expression())
		);
	}

	public override INode VisitConstant(SimuliteParser.ConstantContext context)
	{
		if (context.INTEGER() is { } i)
			return new IntegerLiteralNode(int.Parse(i.GetText()));
		
		if (context.STRING() is { } s)
			return new StringLiteralNode(s.GetText()[1..^1]);
		
		if (context.FLOAT() is { } f)
			return new FloatLiteralNode(float.Parse(f.GetText()));
		
		if (context.BOOL() is { } b)
			return new BooleanLiteralNode(b.GetText() == "true");
		
		if (context.NULL() is { })
			return new NullLiteralNode();
		
		throw new NotImplementedException();
	}

	public override INode VisitIdentifierExpression(SimuliteParser.IdentifierExpressionContext context)
	{
		return new IdentifierNode(context.IDENTIFIER().GetText());
	}

	public override INode VisitAdditionExpression(SimuliteParser.AdditionExpressionContext context)
	{
		return new NumericOperationNode(
			Visit(context.expression(0)),
			context.addOp().GetText(),
			Visit(context.expression(1))
		);
	}
	public override INode VisitMultiplicationExpression(SimuliteParser.MultiplicationExpressionContext context)
	{
		return new NumericOperationNode(
			Visit(context.expression(0)), 
			context.multOp().GetText(), 
			Visit(context.expression(1))
		);
	}

	public override INode VisitWhileBlock(SimuliteParser.WhileBlockContext context)
	{
		return new WhileNode(Visit(context.expression()), Visit(context.block()));
	}

	public override INode VisitComparisonExpression(SimuliteParser.ComparisonExpressionContext context)
	{
		return new ComparisonNode(
			Visit(context.expression(0)), 
			context.compareOp().GetText(), 
			Visit(context.expression(1))
		);
	}

    public override INode VisitIfBlock(SimuliteParser.IfBlockContext context)
    {
		return new IfElseNode(
			Visit(context.expression()),
			Visit(context.block(0)),
			Visit(context.block(1))
		);
    }

	public override INode VisitFunctionCall(SimuliteParser.FunctionCallContext context)
	{
		return new FunctionCallNode(
			context.IDENTIFIER().GetText(), 
			context.expression().Select(Visit).ToArray()
		);
	}

	public override INode VisitProgram(SimuliteParser.ProgramContext context)
	{
		return new ProgramNode(context.line().Select(Visit).ToArray());
	}

	public override INode VisitLine(SimuliteParser.LineContext context)
	{
		return Visit(context.children[0]);
	}

	public override INode VisitStatement(SimuliteParser.StatementContext context)
	{
		return Visit(context.children[0]);
	}

	public override INode VisitBlock(SimuliteParser.BlockContext context)
	{
		return new ProgramNode(context.line().Select(Visit).ToArray());
	}

	public override INode VisitFunctionDeclaration(SimuliteParser.FunctionDeclarationContext context)
	{
		return new FunctionDeclarationNode(
			context.IDENTIFIER()[0].GetText(), 
			context.IDENTIFIER()[1..].Select(id => id.GetText()).ToArray(), 
			Visit(context.block())
		);
	}

    public override INode VisitReturn(SimuliteParser.ReturnContext context)
    {
		return new ReturnNode(Visit(context.expression()));
    }
}
