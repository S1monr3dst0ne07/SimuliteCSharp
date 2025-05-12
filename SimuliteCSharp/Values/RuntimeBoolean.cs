namespace SimuliteCSharp.Values;

public class RuntimeBoolean(bool val) : IRuntimeValue
{
	public bool Value = val;
	
	public string Print()
	{
		return Value.ToString();
	}
}
