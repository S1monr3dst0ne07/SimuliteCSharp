namespace SimuliteCSharp.Values;

public class RuntimeFloat(float val) : IRuntimeValue
{
	public float Value = val;
	
	public string Show()
	{
		return Value.ToString();
	}
}
