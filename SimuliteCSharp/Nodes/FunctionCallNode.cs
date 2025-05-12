using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class FunctionCallNode(string identifier, INode?[] parms) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue value = env.ResolveVariable(identifier);
		switch (value)
		{
		case RuntimeExternalFunction exFunc:
			exFunc.Method.Invoke(parms.Select(line => line.Evaluate(env)).ToArray());
			return null;
		case RuntimeFunction func:
			SimuliteEnvironment funcEnv = new SimuliteEnvironment(func.ParentEnv);
			IRuntimeValue?[] parsedParams = parms.Select(line => line.Evaluate(env)).ToArray();
			string[] functionDefParams = func.ParamList;
			Dictionary<string, IRuntimeValue?> paramMap = functionDefParams
				.Zip(parsedParams, (first, second) => new {first, second})
				.ToDictionary(val => val.first, val => val.second);
			foreach (KeyValuePair<string, IRuntimeValue?> param in paramMap)
			{
				funcEnv.AddVariable(param.Key, param.Value);
			}
			func.Block.Evaluate(funcEnv);
			return null;
		default:
			throw new Exception("Invalid function call, calling a variable is not a valid statement.");
		}
	}
}
