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
	
		if (op == "+")
		{
			switch (leftVal)
			{
			case RuntimeFloat lf when rightVal is RuntimeFloat rf:
				return new RuntimeFloat(lf.Value + rf.Value);
			case RuntimeFloat lf2 when rightVal is RuntimeInteger ri2:
				return new RuntimeFloat(lf2.Value + ri2.Value);
			case RuntimeInteger li2 when rightVal is RuntimeFloat rf2:
				return new RuntimeFloat(li2.Value + rf2.Value);
			case RuntimeInteger li3 when rightVal is RuntimeInteger ri3:
				return new RuntimeInteger(li3.Value + ri3.Value);
			}

			//STRINGS
			if (rightVal is RuntimeString | leftVal is RuntimeString)
				return new RuntimeString(leftVal.Print() + rightVal.Print());
		}

		if (op == "-")
		{
			switch (leftVal)
			{
			case RuntimeFloat lf when rightVal is RuntimeFloat rf:
				return new RuntimeFloat(lf.Value - rf.Value);
			case RuntimeFloat lf2 when rightVal is RuntimeInteger ri2:
				return new RuntimeFloat(lf2.Value - ri2.Value);
			case RuntimeInteger li2 when rightVal is RuntimeFloat rf2:
				return new RuntimeFloat(li2.Value - rf2.Value);
			case RuntimeInteger li3 when rightVal is RuntimeInteger ri3:
				return new RuntimeInteger(li3.Value - ri3.Value);
			}

		}

		if (op == "*")
		{
			switch (leftVal)
			{
			case RuntimeFloat lf when rightVal is RuntimeFloat rf:
				return new RuntimeFloat(lf.Value * rf.Value);
			case RuntimeFloat lf2 when rightVal is RuntimeInteger ri2:
				return new RuntimeFloat(lf2.Value * ri2.Value);
			case RuntimeInteger li2 when rightVal is RuntimeFloat rf2:
				return new RuntimeFloat(li2.Value * rf2.Value);
			case RuntimeInteger li3 when rightVal is RuntimeInteger ri3:
				return new RuntimeInteger(li3.Value * ri3.Value);
			}
		}
		
		if (op == "/")
		{
			switch (leftVal)
			{
			case RuntimeFloat lf when rightVal is RuntimeFloat rf:
				if (rf.Value == 0) throw new DivideByZeroException("Division by zero");
				return new RuntimeFloat(lf.Value / rf.Value);
			case RuntimeFloat lf2 when rightVal is RuntimeInteger ri2:
				if (ri2.Value == 0) throw new DivideByZeroException("Division by zero");
				return new RuntimeFloat(lf2.Value / ri2.Value);
			case RuntimeInteger li2 when rightVal is RuntimeFloat rf2:
				if (rf2.Value == 0) throw new DivideByZeroException("Division by zero");
				return new RuntimeFloat(li2.Value / rf2.Value);
			case RuntimeInteger li3 when rightVal is RuntimeInteger ri3:
				if (ri3.Value == 0) throw new DivideByZeroException("Division by zero");
				return new RuntimeInteger(li3.Value / ri3.Value);
			}
		}
	
		throw new Exception($"Invalid numeric operation: {leftVal.GetType()} {op} {rightVal.GetType()}");
	}
}
