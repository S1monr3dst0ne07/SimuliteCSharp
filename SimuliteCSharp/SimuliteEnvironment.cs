using SimuliteCSharp.Values;
namespace SimuliteCSharp;

public class SimuliteEnvironment
{
	public SimuliteEnvironment? Parent { get; private set; }
	private Dictionary<string, IRuntimeValue> Locals = new();

	public SimuliteEnvironment() {
		
	}
	
	public SimuliteEnvironment(SimuliteEnvironment parent)
	{
		Parent = parent;
	}

	public void AddLocal(string identifier, IRuntimeValue value)
	{
		Locals[identifier] = value;
	}
	
	public IRuntimeValue ResolveLocal(string identifier)
	{
		if (Locals.TryGetValue(identifier, out IRuntimeValue? variable))
			return variable;
		
		if (Parent != null)
			return Parent.ResolveLocal(identifier);
			
		throw new Exception($"Variable '{identifier}' not found in scope.");
	}
}
