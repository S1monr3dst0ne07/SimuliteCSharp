using SimuliteCSharp;
using SimuliteCSharp.Nodes;
using SimuliteCSharp.Values;
INode program = SimuliteApi.Parse(File.ReadAllText("./test.sim"));
SimuliteEnvironment env = new();
env.AddVariable("print", new RuntimeExternalFunction((IRuntimeValue[] args) =>
{
	Console.WriteLine(args[0].Print());
}));
program.Evaluate(env);