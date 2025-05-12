using SimuliteCSharp.Nodes;
using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class StringLiteralNode(string val) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		return new RuntimeString(val);
	}
}
