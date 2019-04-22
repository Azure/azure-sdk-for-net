using System.IO;
using BenchmarkDotNet.Running;

namespace Azure.ApplicationModel.Configuration.Performance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
