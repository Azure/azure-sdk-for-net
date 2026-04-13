// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.AsyncPatternAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0101Tests
    {
        [Test]
        public async Task AZC0101ErrorOnExistingConfigureAwaitTrue()
        {
            const string code = @"
namespace RandomNamespace
{
    public class MyClass
    {
        public static async System.Threading.Tasks.Task Foo()
        {
            await System.Threading.Tasks.Task.Run(() => {}).{|AZC0101:ConfigureAwait(true)|};
        }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0101NoErrorOnConfigureAwaitFalse()
        {
            const string code = @"
namespace RandomNamespace
{
    public class MyClass
    {
        public static async System.Threading.Tasks.Task Foo()
        {
            await System.Threading.Tasks.Task.Run(() => {}).ConfigureAwait(false);
        }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0101ErrorInAsyncScopeConfigureAwaitTrue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;
    public class MyClass
    {
        private static async Task FooAsync(bool async)
        {
            if (async)
            {
                await Task.Run(() => {}).{|AZC0101:ConfigureAwait(true)|};
            }
        }
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        private const string AzureCorePipelineTaskExtensions = @"
namespace Azure.Core.Pipeline
{
    using System.Threading.Tasks;

    internal static class TaskExtensions
    {
        public static T EnsureCompleted<T>(this Task<T> task) => default(T);
    }
}
";
    }
}
