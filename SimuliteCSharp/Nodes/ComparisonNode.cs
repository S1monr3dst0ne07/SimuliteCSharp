using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class ComparisonNode(INode left, string op, INode right) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? leftVal = left.Evaluate(env);
		IRuntimeValue? rightVal = right.Evaluate(env);
		if (leftVal is null || rightVal is null || leftVal is not RuntimeInteger || rightVal is not RuntimeInteger)
		{
			throw new Exception($"Invalid comparison operands, expected integers but got {leftVal?.GetType()} and {rightVal?.GetType()}");
		}
		int leftInt = ((RuntimeInteger)leftVal).Value;
		int rightInt = ((RuntimeInteger)rightVal).Value;
		return new RuntimeBoolean(op switch
		{
			"<" => leftInt < rightInt,
			">" => leftInt > rightInt,
			"<=" => leftInt <= rightInt,
			">=" => leftInt >= rightInt,
			"==" => leftInt == rightInt,
			"!=" => leftInt != rightInt,
			_ => throw new Exception($"Unsupported comparison operator: {op}")
		});
	}
}
