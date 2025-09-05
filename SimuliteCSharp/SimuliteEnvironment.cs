using SimuliteCSharp.Values;
namespace SimuliteCSharp;

public class SimuliteEnvironment
{
	public SimuliteEnvironment? Parent { get; private set; }
	private Dictionary<string, IRuntimeValue> locals = new();

	public SimuliteEnvironment() {
		
	}
	
	public SimuliteEnvironment(SimuliteEnvironment parent)
	{
		Parent = parent;
	}

	public void AddLocal(string identifier, IRuntimeValue value)
	{
		locals[identifier] = value;
	}
	
	public IRuntimeValue ResolveLocal(string identifier)
	{
		if (locals.TryGetValue(identifier, out IRuntimeValue? variable))
			return variable;
		
		if (Parent != null)
			return Parent.ResolveLocal(identifier);
			
		throw new Exception($"Variable '{identifier}' not found in scope.");
	}
}
