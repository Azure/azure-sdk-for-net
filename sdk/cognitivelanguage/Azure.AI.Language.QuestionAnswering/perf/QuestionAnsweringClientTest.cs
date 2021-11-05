// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.AI.Language.QuestionAnswering.Perf
{
    public class QuestionAnsweringClientTest : PerfTest<QuestionAnsweringClientTest.QuestionAnsweringClientOptions>
    {
        public QuestionAnsweringClientTest(QuestionAnsweringClientOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();
        }

        public class QuestionAnsweringClientOptions : PerfOptions
        {
            // TODO: Replace with actual options.
            [Option("delay", Default = 100, HelpText = "Delay between gets (milliseconds)")]
            public int Delay { get; set; }
        }
    }
}
