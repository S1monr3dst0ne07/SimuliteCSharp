using SimuliteCSharp.Nodes;
namespace SimuliteCSharp.Values;

public class RuntimeFunction(ProgramNode block, string[] paramList, SimuliteEnvironment parentEnv) : IRuntimeValue
{
	public ProgramNode Block = block;
	public string[] ParamList = paramList;
	public SimuliteEnvironment ParentEnv = parentEnv;
	
	public string Show()
	{
		return $"<RuntimeFunction:{Block}>";
	}
}
