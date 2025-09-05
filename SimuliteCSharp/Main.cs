using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        var source = File.ReadAllText(path);
        var ast = SimuliteApi.Parse(source);
        var env = new SimuliteEnvironment();

        ast.Evaluate(env);

    }
}
