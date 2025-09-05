using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class ProgramNode(INode[] lines) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? val = null;
		foreach (INode line in lines)
		{
			val = line.Evaluate(env);
			if (line is ReturnNode) break;
		}

		return val;
	}
}
