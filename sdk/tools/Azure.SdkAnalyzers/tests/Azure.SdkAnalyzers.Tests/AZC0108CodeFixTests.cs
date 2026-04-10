// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0108CodeFixTests
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

        private static CSharpCodeFixTest<AsyncPatternAnalyzer, AsyncParameterCodeFixProvider, DefaultVerifier> CreateCodeFixTest(
            string source,
            string fixedSource)
        {
            var test = new CSharpCodeFixTest<AsyncPatternAnalyzer, AsyncParameterCodeFixProvider, DefaultVerifier>
            {
                ReferenceAssemblies = AzureTestReferences.DefaultReferenceAssemblies,
                SolutionTransforms = {(solution, projectId) =>
                {
                    var project = solution.GetProject(projectId);
                    var parseOptions = (CSharpParseOptions?)project?.ParseOptions;
                    if (parseOptions != null && solution != null && project != null)
                    {
                        return solution.WithProjectParseOptions(projectId, parseOptions.WithLanguageVersion(LanguageVersion.Latest));
                    }
                    return solution!;
                }},
                TestCode = source,
                FixedCode = fixedSource,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck
            };

            test.TestState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.TestState.Sources.Add(AzureCorePipelineTaskExtensions);
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.FixedState.Sources.Add(AzureCorePipelineTaskExtensions);

            return test;
        }

        [Test]
        public async Task FixFalseInAsyncScope()
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

            const string fixedCode = @"
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
        }

        private static async Task<int> FooImplAsync(bool async, CancellationToken ct = default(CancellationToken))
            => async ? await Task.FromResult(42).ConfigureAwait(false) : 42;
    }
}";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixTrueInSyncScope()
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

            const string fixedCode = @"
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
                FooImplAsync(async).EnsureCompleted();
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

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task NoFixOfferedWithoutAsyncParameter()
        {
            // In a plain async method without a 'bool async' parameter,
            // there is no async parameter to forward, so no fix should be offered.
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

            // Fixed code is the same as the input — no fix applied
            var test = CreateCodeFixTest(code, code);
            test.NumberOfFixAllIterations = 0;
            await test.RunAsync(CancellationToken.None);
        }
    }
}
