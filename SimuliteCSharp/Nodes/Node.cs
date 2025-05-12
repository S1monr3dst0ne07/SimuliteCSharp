using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public interface INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env);
}
