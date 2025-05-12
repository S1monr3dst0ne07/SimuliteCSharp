namespace SimuliteCSharp.Values;

public class RuntimeInteger(int val) : IRuntimeValue
{
	public int Value = val;

	public string Print()
	{
		return Value.ToString();
	}
}
