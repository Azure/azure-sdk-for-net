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
    public class AZC0013CodeFixTests
    {
        private static CSharpCodeFixTest<TaskCompletionSourceAnalyzer, TaskCompletionSourceCodeFixProvider, DefaultVerifier> CreateCodeFixTest(
            string source,
            string fixedSource)
        {
            var test = new CSharpCodeFixTest<TaskCompletionSourceAnalyzer, TaskCompletionSourceCodeFixProvider, DefaultVerifier>
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
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));

            return test;
        }

        [Test]
        public async Task FixDefaultConstructor()
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

            const string fixedCode = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixWithStateObjectOnly()
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

            const string fixedCode = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(new object(), TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixWithWrongTaskCreationOptions()
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

            const string fixedCode = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(new object(), TaskCreationOptions.RunContinuationsAsynchronously | TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixWithSingleWrongOption()
        {
            const string code = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>({|AZC0013:TaskCreationOptions.None|});
    }
}
";

            const string fixedCode = @"
namespace RandomNamespace
{
    using System.Threading.Tasks;

    internal class RandomClass
    {
        private TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously | TaskCreationOptions.None);
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }
    }
}
