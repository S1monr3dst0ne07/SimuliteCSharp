using SimuliteCSharp.Nodes;
using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class WhileNode(INode condition, INode block) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? val = condition.Evaluate(env);
		if (val is null | val.GetType() != typeof(RuntimeBoolean))
		{
			throw new Exception("Invalid condition, got type "+val.GetType()+" expected RuntimeBoolean");
		}
		RuntimeBoolean boolVal = (RuntimeBoolean)val;
		while (boolVal.Value)
		{
			block.Evaluate(env);
			val = condition.Evaluate(env);
			if (val is null | val.GetType() != typeof(RuntimeBoolean))
			{
				throw new Exception("Invalid condition, got type "+val.GetType()+" expected RuntimeBoolean");
			}
			boolVal = (RuntimeBoolean)val;
		}
		return null;
	}
}
