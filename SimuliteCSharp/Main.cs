using NDesk.Options;
using SimuliteCSharp;

class Program
{
    static void Main(string[] args)
    {
        var path = "Program.txt";
        var p = new OptionSet()
        {
            { "i|input=", v => path = v }
        };
        p.Parse(args);

        var root = new SimuliteEnvironment();
        root.AddLocal("print",
            new SimuliteCSharp.Values.RuntimeExternalFunction(
                vs => Console.WriteLine(vs[0].Show())
            )
        );

        var source = File.ReadAllText(path);
        var ast = SimuliteApi.Parse(source);

        ast.Evaluate(root);

    }
}
