using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class NumericOperationNode(INode left, string op, INode right) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		IRuntimeValue? leftVal = left.Evaluate(env);
		IRuntimeValue? rightVal = right.Evaluate(env);
	
		if (leftVal is null || rightVal is null)
		{
			throw new Exception($"Cannot operate on null values");
		}


		if (leftVal is RuntimeString && rightVal is RuntimeString)
            return new RuntimeString(leftVal.Show() + rightVal.Show());

		//interaction between float and int will type coerce the int to a float
		if (leftVal is RuntimeInteger && rightVal is RuntimeFloat)
			leftVal = new RuntimeFloat((float)((RuntimeInteger)leftVal).Value);

		if (leftVal is RuntimeFloat && rightVal is RuntimeInteger)
			rightVal = new RuntimeFloat((float)((RuntimeInteger)rightVal).Value);

		//float operations
		if (leftVal is RuntimeFloat || rightVal is RuntimeFloat)
		{
			float l = ((RuntimeFloat)leftVal).Value;
			float r = ((RuntimeFloat)rightVal).Value;
			return new RuntimeFloat(op switch
			{
				"+" => l + r,
				"-" => l - r,
				"*" => l * r,
				"/" => l / r,
			});
		}
		
		//int operations
		if (leftVal is RuntimeInteger || rightVal is RuntimeInteger)
		{
			int l = ((RuntimeInteger)leftVal).Value;
			int r = ((RuntimeInteger)rightVal).Value;
			return new RuntimeInteger(op switch
			{
				"+" => l + r,
				"-" => l - r,
				"*" => l * r,
				"/" => l / r,
			});
		}
	
		throw new Exception($"Invalid numeric operation: {leftVal.GetType()} {op} {rightVal.GetType()}");
	}
}
