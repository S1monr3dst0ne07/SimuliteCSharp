using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class BooleanLiteralNode(bool val) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		throw new NotImplementedException();
	}
}
