// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.AsyncPatternAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0111Tests
    {
        private const string AzureCorePipelineTaskExtensions = @"
namespace Azure.Core.Pipeline
{
    using System.Threading.Tasks;

    internal static class TaskExtensions
    {
        public static void EnsureCompleted(this Task task) => task.GetAwaiter().GetResult();
    }
}
";

        [Test]
        public async Task AZC0111ErrorEnsureCompleted()
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
            {|AZC0111:Task.Delay(0)|}.EnsureCompleted();
        }
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0111ErrorEnsureCompletedOnVariable()
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
            var task = Task.Delay(0);
            {|AZC0111:task|}.EnsureCompleted();
        }
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0111ErrorEnsureCompletedWithAsyncParameter()
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
            {|AZC0111:FooImplAsync(async)|}.EnsureCompleted();
        }

        private static async Task FooImplAsync(bool async)
        {
            if (async) { await Task.Delay(0).ConfigureAwait(false); }
        }
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0111NoErrorEnsureCompletedInSyncScope()
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
            if (!async)
            {
                Task.Delay(0).EnsureCompleted();
            }
            else
            {
                await Task.Delay(0).ConfigureAwait(false);
            }
        }
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0111NoErrorEnsureCompletedInSyncMethod()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;

    public class MyClass
    {
        private static void Foo()
        {
            Task.Delay(0).EnsureCompleted();
        }
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }
    }
}
