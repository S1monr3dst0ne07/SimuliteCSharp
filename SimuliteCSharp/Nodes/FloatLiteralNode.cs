using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class FloatLiteralNode(float val) : INode
{

	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		throw new NotImplementedException();
	}
}
