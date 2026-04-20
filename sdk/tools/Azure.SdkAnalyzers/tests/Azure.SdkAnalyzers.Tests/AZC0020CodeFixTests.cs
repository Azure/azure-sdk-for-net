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
    public class AZC0020CodeFixTests
    {
        private const string AzureStubs = @"
namespace Azure
{
    public class RequestContext
    {
        public System.Threading.CancellationToken CancellationToken { get; set; }
        public ErrorOptions ErrorOptions { get; set; }
    }

    public enum ErrorOptions
    {
        Default
    }

    public class Response { }
}

namespace Azure.Sample
{
    public class SampleClient
    {
        public System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string content, Azure.RequestContext context = null)
        {
            return System.Threading.Tasks.Task.FromResult<Azure.Response>(null);
        }
    }
}
";

        private static CSharpCodeFixTest<RequestContextCancellationTokenAnalyzer, RequestContextCodeFixProvider, DefaultVerifier> CreateCodeFixTest(
            string source,
            string fixedSource)
        {
            var test = new CSharpCodeFixTest<RequestContextCancellationTokenAnalyzer, RequestContextCodeFixProvider, DefaultVerifier>
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
            test.TestState.Sources.Add(AzureStubs);
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.FixedState.Sources.Add(AzureStubs);

            return test;
        }

        [Test]
        public async Task FixNewRequestContextWithNoInitializer()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test"",
            {|AZC0020:new RequestContext()|});
    }
}
";

            const string fixedCode = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test"",
            new RequestContext { CancellationToken = cancellationToken });
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixNewRequestContextWithExistingInitializerMissingCT()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test"",
            {|AZC0020:new RequestContext { ErrorOptions = ErrorOptions.Default }|});
    }
}
";

            const string fixedCode = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test"",
            new RequestContext { ErrorOptions = ErrorOptions.Default, CancellationToken = cancellationToken });
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixNewRequestContextWithCancellationTokenNone()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test"",
            {|AZC0020:new RequestContext { CancellationToken = CancellationToken.None }|});
    }
}
";

            const string fixedCode = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test"",
            new RequestContext { CancellationToken = cancellationToken });
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixInLambdaWithCancellationToken()
        {
            const string code = @"
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task ProcessAsync()
    {
        Func<CancellationToken, Task> action = async (ct) =>
        {
            await _client.UpdateAsync(
                ""test"",
                {|AZC0020:new RequestContext()|});
        };
        await action(CancellationToken.None);
    }
}
";

            const string fixedCode = @"
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task ProcessAsync()
    {
        Func<CancellationToken, Task> action = async (ct) =>
        {
            await _client.UpdateAsync(
                ""test"",
                new RequestContext { CancellationToken = ct });
        };
        await action(CancellationToken.None);
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }

        [Test]
        public async Task FixMultipleViolationsInSameMethod()
        {
            const string code = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task ProcessAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test1"",
            {|AZC0020:new RequestContext()|});

        await _client.UpdateAsync(
            ""test2"",
            {|AZC0020:new RequestContext()|});
    }
}
";

            const string fixedCode = @"
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Sample;

public class MyService
{
    private SampleClient _client = new SampleClient();

    public async Task ProcessAsync(CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(
            ""test1"",
            new RequestContext { CancellationToken = cancellationToken });

        await _client.UpdateAsync(
            ""test2"",
            new RequestContext { CancellationToken = cancellationToken });
    }
}
";

            await CreateCodeFixTest(code, fixedCode).RunAsync(CancellationToken.None);
        }
    }
}
