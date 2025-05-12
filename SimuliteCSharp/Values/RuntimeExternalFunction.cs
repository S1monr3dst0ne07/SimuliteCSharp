namespace SimuliteCSharp.Values;

public class RuntimeExternalFunction(Action<IRuntimeValue[]> method) : IRuntimeValue
{
	public Action<IRuntimeValue[]> Method = method;
	public string Print()
	{
		return method.Method.Name;
	}
}
