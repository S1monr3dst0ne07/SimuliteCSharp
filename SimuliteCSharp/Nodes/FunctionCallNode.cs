using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class FunctionCallNode(string identifier, INode?[] parms) : INode
{
	//get parameter values for call
	private IRuntimeValue?[] GetParamValues(SimuliteEnvironment env)
	{
		return parms.Select(
			param => param?.Evaluate(env)
		).ToArray();
	}


	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		switch (env.ResolveLocal(identifier))
		{
		case RuntimeExternalFunction exFunc:
            exFunc.Method.Invoke(GetParamValues(env));
			return null;
		case RuntimeFunction func:
			SimuliteEnvironment funcEnv = new SimuliteEnvironment(func.ParentEnv);

			foreach (var (key, value) in func.ParamList.Zip(GetParamValues(env)))
				funcEnv.AddLocal(key, value);

			return func.Block.Evaluate(funcEnv);
		default:
			throw new Exception("Invalid function call, calling a variable is not a valid statement.");
		}
	}
}
