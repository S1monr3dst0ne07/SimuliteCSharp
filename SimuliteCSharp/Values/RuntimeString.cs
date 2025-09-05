namespace SimuliteCSharp.Values;

public class RuntimeString(string val) : IRuntimeValue
{
	public string Value = val;
	
	public string Show()
	{
		return Value;
	}
}
