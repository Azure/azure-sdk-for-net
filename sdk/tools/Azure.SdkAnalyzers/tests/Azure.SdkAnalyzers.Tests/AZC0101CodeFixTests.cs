// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0101CodeFixTests
    {
        private static CSharpCodeFixTest<AsyncPatternAnalyzer, ConfigureAwaitCodeFixProvider, DefaultVerifier> CreateCodeFixTest(
            string source,
            string fixedSource)
        {
            var test = new CSharpCodeFixTest<AsyncPatternAnalyzer, ConfigureAwaitCodeFixProvider, DefaultVerifier>
            {
                ReferenceAssemblies = AzureTestReferences.DefaultReferenceAssemblies,
                SolutionTransforms = {(solution, projectId) =>
                {
                    var project = solution.GetProject(projectId);
                    var parseOptions = (CSharpParseOptions?)project?.ParseOptions;
                    if (parseOptions != null && project != null)
                    {
                        return solution.WithProjectParseOptions(projectId, parseOptions.WithLanguageVersion(LanguageVersion.Latest));
                    }
                    return solution;
                }},
                TestCode = source,
                FixedCode = fixedSource,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck
            };

            test.TestState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));

            return test;
        }

        [NUnit.Framework.Test]
        public async Task FixReplacesConfigureAwaitTrueWithFalse()
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

            const string fixedCode = @"
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

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [NUnit.Framework.Test]
        public async Task FixReplacesConfigureAwaitTrueInAsyncScope()
        {
            const string source = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;

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

            const string fixedSource = @"
namespace RandomNamespace
{
    using System.Threading;
    using System.Threading.Tasks;

    public class MyClass
    {
        private static async Task FooAsync(bool async)
        {
            if (async)
            {
                await Task.Run(() => {}).ConfigureAwait(false);
            }
        }
    }
}";

            var test = CreateCodeFixTest(source, fixedSource);
            test.TestState.Sources.Add(AzureCorePipelineTaskExtensions);
            test.FixedState.Sources.Add(AzureCorePipelineTaskExtensions);
            await test.RunAsync(CancellationToken.None);
        }

        [NUnit.Framework.Test]
        public async Task FixReplacesNamedArgumentConfigureAwaitTrue()
        {
            const string code = @"
namespace RandomNamespace
{
    public class MyClass
    {
        public static async System.Threading.Tasks.Task Foo()
        {
            await System.Threading.Tasks.Task.Run(() => {}).{|AZC0101:ConfigureAwait(continueOnCapturedContext: true)|};
        }
    }
}";

            const string fixedCode = @"
namespace RandomNamespace
{
    public class MyClass
    {
        public static async System.Threading.Tasks.Task Foo()
        {
            await System.Threading.Tasks.Task.Run(() => {}).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [NUnit.Framework.Test]
        public async Task FixReplacesConfigureAwaitTrueOnGenericTask()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    public class MyClass
    {
        public static async Task Foo()
        {
            await Task.FromResult(42).{|AZC0101:ConfigureAwait(true)|};
        }
    }
}";

            const string fixedCode = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    public class MyClass
    {
        public static async Task Foo()
        {
            await Task.FromResult(42).ConfigureAwait(false);
        }
    }
}";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
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
