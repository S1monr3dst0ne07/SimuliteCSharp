using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class IdentifierNode(string val) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		return env.ResolveLocal(val);
	}
}
