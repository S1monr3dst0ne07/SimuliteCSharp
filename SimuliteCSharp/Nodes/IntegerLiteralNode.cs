using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class IntegerLiteralNode(int val) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		return new RuntimeInteger(val);
	}
}
