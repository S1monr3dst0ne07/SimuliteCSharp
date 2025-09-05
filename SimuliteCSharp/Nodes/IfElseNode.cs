
using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class IfElseNode(INode condition, INode yes, INode no) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? val = condition.Evaluate(env);
		if (val is null | val.GetType() != typeof(RuntimeBoolean))
		{
			throw new Exception("Invalid condition, got type "+val.GetType()+" expected RuntimeBoolean");
		}
		RuntimeBoolean boolVal = (RuntimeBoolean)val;

		if (boolVal.Value)
			return yes.Evaluate(env);
		else
			return no.Evaluate(env);
	}
}
