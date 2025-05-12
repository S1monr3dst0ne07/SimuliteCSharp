using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class NullLiteralNode : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		throw new NotImplementedException();
	}
}
