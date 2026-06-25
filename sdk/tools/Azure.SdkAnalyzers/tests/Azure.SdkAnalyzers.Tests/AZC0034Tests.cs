// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.DuplicateTypeNameAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0034Tests
    {
        [TestCase("Azure.Data", "BlobClient", true)]
        [TestCase("Azure.MyService", "BlobClient", true)]
        [TestCase("Azure.MyService", "PageBlobClient", true)]
        [TestCase("MyCompany.Data", "BlobClient", false)]
        public async Task AZC0034ProducedForReservedTypeNames(string namespaceName, string typeName, bool shouldReport)
        {
            var code = shouldReport
                ? $@"
namespace {namespaceName}
{{
    public class {{|AZC0034:{typeName}|}} {{ }}
}}"
                : $@"
namespace {namespaceName}
{{
    public class {typeName} {{ }}
}}";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task AZC0034IncludesPackageNameInMessage()
        {
            var code = @"
namespace Azure.Test
{
    public class BlobClient { }
}";

            var test = Verifier.CreateAnalyzer(code);
            test.ExpectedDiagnostics.Add(new DiagnosticResult(Descriptors.AZC0034)
                .WithSpan(4, 18, 4, 28)
                .WithArguments("BlobClient", "Azure.Storage.Blobs.BlobClient (from Azure.Storage.Blobs)", "Consider renaming to 'TestBlobClient' or 'TestServiceClient' to avoid confusion."));
            await test.RunAsync();
        }

        [Test]
        public async Task AZC0034NotProducedForSameTypeInSameAssembly()
        {
            // A type defined in Azure.Core itself should not be flagged as conflicting with
            // its own entry in the reserved types list.
            var test = Verifier.CreateAnalyzer("");
            test.TestState.Sources.Add(@"[assembly: System.Reflection.AssemblyTitle(""Azure.Core"")]

namespace Azure
{
    public abstract class Operation { }
    public abstract class Response { }
}");

            test.SolutionTransforms.Add((solution, projectId) =>
                solution.WithProjectAssemblyName(projectId, "Azure.Core"));

            await test.RunAsync();
        }

        [Test]
        public async Task AZC0034NotProducedForSameGenericTypeInSameAssembly()
        {
            // A generic type defined in Azure.Core should not be flagged as conflicting with
            // the non-generic version in the reserved types list.
            var test = Verifier.CreateAnalyzer("");
            test.TestState.Sources.Add(@"[assembly: System.Reflection.AssemblyTitle(""Azure.Core"")]

namespace Azure
{
    public abstract class Operation<T> { }
}");

            test.SolutionTransforms.Add((solution, projectId) =>
                solution.WithProjectAssemblyName(projectId, "Azure.Core"));

            await test.RunAsync();
        }

        [Test]
        public async Task AZC0034NotProducedForNestedTypesInSameAssembly()
        {
            var test = Verifier.CreateAnalyzer("");
            test.TestState.Sources.Add(@"[assembly: System.Reflection.AssemblyTitle(""Azure.Core"")]

namespace Azure.Core
{
    public struct ArrayEnumerator { }
    public struct ObjectEnumerator { }
}");

            test.SolutionTransforms.Add((solution, projectId) =>
                solution.WithProjectAssemblyName(projectId, "Azure.Core"));

            await test.RunAsync();
        }

        [Test]
        public async Task AZC0034ProducedForGenericTypeConflictInDifferentAssembly()
        {
            var code = @"
namespace Azure
{
    public abstract class Operation<T> { }
}";
            var test = Verifier.CreateAnalyzer(code);
            test.ExpectedDiagnostics.Add(new DiagnosticResult(Descriptors.AZC0034)
                .WithSpan(4, 27, 4, 36)
                .WithArguments("Operation`1", "Azure.Operation`1 (from Azure.Core)", "Consider renaming to 'CustomOperation' or 'CustomProcess' to avoid confusion."));
            await test.RunAsync();
        }

        [Test]
        public async Task AZC0034NotProducedForNestedTypes()
        {
            // Nested types are not analyzed even when their names would conflict.
            var code = @"
namespace Azure.Test
{
    public class ParentClass
    {
        public class BlobClient { }
        public struct Response { }
        public enum Operation { }

        public class Container
        {
            public class Enumerator { }
        }
    }
}";

            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
