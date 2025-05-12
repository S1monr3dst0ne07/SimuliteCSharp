using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class ProgramNode(INode[] lines) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? val = null;
		lines.ToList().ForEach(line => val = line.Evaluate(env));
		return val;
	}
}
