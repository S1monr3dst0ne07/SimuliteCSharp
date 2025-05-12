using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class AssignNode(string identifier, INode valueExpression) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? val = valueExpression.Evaluate(env);
		if (val == null) return null;
		env.AddVariable(identifier, val);
		return null;
	}
}
