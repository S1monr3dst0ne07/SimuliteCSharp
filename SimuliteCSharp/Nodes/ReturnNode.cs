using SimuliteCSharp.Values;
using System.Linq.Expressions;
namespace SimuliteCSharp.Nodes;
class ReturnNode(INode expr) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
        return expr.Evaluate(env);
	}

}
