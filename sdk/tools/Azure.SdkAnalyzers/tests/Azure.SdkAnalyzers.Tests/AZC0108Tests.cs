// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.AsyncPatternAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0108Tests
    {
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

        [Test]
        public async Task AZC0108ErrorInAsyncMethodFalseValue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;
    public class MyClass
    {
        public static async Task FooAsync()
        {
            await FooImplAsync({|AZC0108:false|}).ConfigureAwait(false);
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108ErrorInAsyncScopeFalseValue()
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
                await FooImplAsync({|AZC0108:false|}).ConfigureAwait(false);
            }
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108ErrorInSyncMethodTrueValue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;
    public class MyClass
    {
        public static void Foo()
        {
            FooImplAsync({|AZC0108:true|}).EnsureCompleted();
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108ErrorInSyncScopeTrueValue()
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
                FooImplAsync({|AZC0108:true|}).EnsureCompleted();
            }
            else
            {
                await Task.Yield();
            }
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108ErrorInSyncPropertyTrueValue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;

    public class MyClass
    {
        public static int Foo { get { return FooImplAsync({|AZC0108:true|}).EnsureCompleted(); } }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108ErrorInSyncExpressionPropertyTrueValue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;

    public class MyClass
    {
        public static int Foo => FooImplAsync({|AZC0108:true|}).EnsureCompleted();

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108NoErrorInAsyncMethodTrueValue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;

    public class MyClass
    {
        public static async Task FooAsync()
        {
            await FooImplAsync(true).ConfigureAwait(false);
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108NoErrorInAsyncScopeTrueValue()
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
                await FooImplAsync(true).ConfigureAwait(false);
            }
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108NoErrorInSyncMethodFalseValue()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Core.Pipeline;
    public class MyClass
    {
        public static void Foo()
        {
            FooImplAsync(false).EnsureCompleted();
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108NoErrorInSyncScopeFalseValue()
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
                FooImplAsync(false).EnsureCompleted();
            }
            else
            {
                await Task.Yield();
            }
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }

        [Test]
        public async Task AZC0108NoErrorOnAsyncParameterPassing()
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
                await FooImplAsync(async).ConfigureAwait(false);
            }
            else
            {
                FooImplAsync(async).EnsureCompleted();
            }
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await Verifier.CreateAnalyzer(code)
                .WithSources(AzureCorePipelineTaskExtensions)
                .RunAsync();
        }
    }
}
