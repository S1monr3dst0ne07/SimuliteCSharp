using SimuliteCSharp.Values;
namespace SimuliteCSharp;

public class SimuliteEnvironment
{
	public SimuliteEnvironment? Parent { get; private set; }
	private Dictionary<string, IRuntimeValue> _variables = new();

	public SimuliteEnvironment() {
		
	}
	
	public SimuliteEnvironment(SimuliteEnvironment parent)
	{
		Parent = parent;
	}

	public void AddVariable(string identifier, IRuntimeValue value)
	{
		_variables[identifier] = value;
	}
	
	public IRuntimeValue ResolveVariable(string identifier)
	{
		if (_variables.TryGetValue(identifier, out IRuntimeValue? variable))
			return variable;
		
		if (Parent != null)
			return Parent.ResolveVariable(identifier);
			
		throw new Exception($"Variable '{identifier}' not found in scope.");
	}
}
