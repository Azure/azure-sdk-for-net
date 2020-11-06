using Azure.Test.PerfStress;
using System.Threading;
using System.Threading.Tasks;

namespace System.PerfStress
{
    // Used to verify framework calls DisposeAsync()
    public class DisposeTest : PerfStressTest<PerfStressOptions>
    {
        public DisposeTest(PerfStressOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public override void Dispose(bool disposing)
        {
            Console.WriteLine($"Dispose({disposing})");
            base.Dispose(disposing);
        }

        public override ValueTask DisposeAsyncCore()
        {
            Console.WriteLine("DisposeAsyncCore()");
            return base.DisposeAsyncCore();
        }
    }
}
