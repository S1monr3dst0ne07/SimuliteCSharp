using Antlr4.Runtime;
using SimuliteCSharp.Nodes;
namespace SimuliteCSharp;

public class SimuliteApi
{
	public static INode Parse(string input)
	{
		AntlrInputStream inputStream = new AntlrInputStream(input);
		SimuliteLexer lexer = new SimuliteLexer(inputStream);
		CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
		SimuliteParser parser = new SimuliteParser(commonTokenStream);
		SimuliteParser.ProgramContext? simuliteContext = parser.program();
		SimuliteVisitor visitor = new SimuliteVisitor();
		return visitor.Visit(simuliteContext);
	}
}
