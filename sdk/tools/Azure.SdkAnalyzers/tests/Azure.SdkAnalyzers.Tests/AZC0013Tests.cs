// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.TaskCompletionSourceAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0013Tests
    {
        [Test]
        public async Task AZC0013ErrorOnTaskCompletionSourceDefaultConstructor()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = {|AZC0013:new TaskCompletionSource<string>()|};
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0013ErrorOnTaskCompletionSourceWithState()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>({|AZC0013:new object()|});
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0013ErrorOnTaskCompletionSourceWithoutRunContinuationsAsynchronously()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(new object(), {|AZC0013:TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness|});
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0013ErrorOnTaskCompletionSourceWithField()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private static TaskCreationOptions _option = TaskCreationOptions.RunContinuationsAsynchronously;
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>({|AZC0013:TaskCreationOptions.LongRunning | _option | TaskCreationOptions.PreferFairness|});
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0013NoErrorOnTaskCompletionSourceWithRunContinuationsAsynchronously()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0013NoErrorOnTaskCompletionSourceWithRunContinuationsAsynchronouslyAndState()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(new object(), TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0013NoErrorOnTaskCompletionSourceContainsRunContinuationsAsynchronously()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(TaskCreationOptions.LongRunning | TaskCreationOptions.RunContinuationsAsynchronously | TaskCreationOptions.PreferFairness);
    }
}
";
            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
