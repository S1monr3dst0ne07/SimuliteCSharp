using SimuliteCSharp.Values;
namespace SimuliteCSharp.Nodes;

public class FunctionDeclarationNode(string ident, string[] parmList, INode block) : INode
{
	public IRuntimeValue? Evaluate(SimuliteEnvironment env)
	{
		if (block is not ProgramNode programBlock)
			throw new Exception("Invalid function declaration, block is malformed.");
		env.AddLocal(ident, new RuntimeFunction(programBlock, parmList, env));
		return null;
	}
}
