// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Diagnostics;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ModelFactoryAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0035Tests
    {
        [TestCase("Response<TestModel>")]
        [TestCase("Task<Response<TestModel>>")]
        [TestCase("NullableResponse<TestModel>")]
        [TestCase("Operation<TestModel>")]
        [TestCase("Task<Operation<TestModel>>")]
        [TestCase("Pageable<TestModel>")]
        [TestCase("AsyncPageable<TestModel>")]
        public async Task AZC0035_ProducedWhenOutputModelMissingFromModelFactory(string returnType)
        {
            string code = $@"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{{
    public class {{|AZC0035:TestModel|}}
    {{
        private TestModel() {{ }}
        public string Name {{ get; }}
    }}

    public class TestClient
    {{
        public virtual {returnType} GetTestModel()
        {{
            return null;
        }}
    }}
}}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_NotProducedWhenOutputModelHasCorrespondingModelFactory()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class TestModel1
    {
    }

    public class TestModel2
    {
    }

    public class TestClient
    {
        public virtual Response<TestModel1> GetTestModel1()
        {
            return null;
        }

        public virtual Task<Operation<TestModel2>> GetTestModel2Async()
        {
            return null;
        }
    }

    public static class TestModelFactory
    {
        public static TestModel1 TestModel1()
        {
            return null;
        }

        public static TestModel2 TestModel2()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_IgnoresNonClientClassesAndBuiltInTypes()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class TestModel
    {
    }

    public class SomeService
    {
        public virtual Response<TestModel> GetTestModel()
        {
            return null;
        }
    }

    public class TestClient
    {
        public virtual Response GetResponse()
        {
            return null;
        }

        public virtual Response<string> GetString()
        {
            return null;
        }

        public virtual Response<int> GetInt()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_IgnoresEmptyClassesWithPublicConstructors()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class EmptyModel
    {
    }

    public class EmptyModelExplicit
    {
        public EmptyModelExplicit() { }
    }

    public class TestClient
    {
        public virtual Response<EmptyModel> GetEmptyModel()
        {
            return null;
        }

        public virtual Response<EmptyModelExplicit> GetEmptyModelExplicit()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_FlagsEmptyClassesWithNoPublicConstructor()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class {|AZC0035:EmptyModelPrivate|}
    {
        private EmptyModelPrivate() { }
    }

    public class TestClient
    {
        public virtual Response<EmptyModelPrivate> GetEmptyModel()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_FlagsTypesWithPartiallySettableProperties()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class {|AZC0035:ExampleModel|}
    {
        public int Age { get; }
        public string Name { get; }

        public ExampleModel(string name)
        {
            Name = name;
        }
    }

    public class TestClient
    {
        public virtual Response<ExampleModel> GetExampleModel()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_RealWorldExamples()
        {
            const string code = @"
using Azure;
using System;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs
{
    public class BlobContainerClient
    {
        public string Name { get; set; }
        public string AccountName { get; set; }
    }

    public class BlobServiceProperties
    {
        public string Version { get; set; }
        public bool LoggingEnabled { get; set; }
        public int RetentionDays { get; set; }
    }

    public class BlobImmutabilityPolicy
    {
        public BlobImmutabilityPolicy(string policyType, int retentionDays)
        {
            PolicyType = policyType;
            RetentionDays = retentionDays;
        }

        public string PolicyType { get; }
        public int RetentionDays { get; }
    }

    public class ReleasedObjectInfo
    {
        public ReleasedObjectInfo(string objectId)
        {
            ObjectId = objectId;
        }

        public string ObjectId { get; }
        public string Status { get; set; }
        public DateTime? ReleasedAt { get; set; }
    }

    public class {|AZC0035:PrivateConstructorModel|}
    {
        private PrivateConstructorModel() { }
        public string Name { get; set; }
    }

    public class {|AZC0035:ReadOnlyModel|}
    {
        public string Name { get; }
        public int Value { get; }
    }

    public class TestClient
    {
        public virtual Response<BlobContainerClient> GetBlobContainer() => null;
        public virtual Response<BlobServiceProperties> GetServiceProperties() => null;
        public virtual Response<BlobImmutabilityPolicy> GetImmutabilityPolicy() => null;
        public virtual Response<ReleasedObjectInfo> GetReleasedObjectInfo() => null;
        public virtual Response<PrivateConstructorModel> GetPrivateConstructorModel() => null;
        public virtual Response<ReadOnlyModel> GetReadOnlyModel() => null;
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_IgnoresSystemTypes()
        {
            const string code = @"
using Azure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public class BinaryData
    {
        public string Content { get; }
    }
}

namespace System.Threading
{
    public class Thread
    {
        public string Name { get; set; }
        public bool IsAlive { get; }
    }
}

namespace Azure.Test
{
    public class TestClient
    {
        public virtual Response<BinaryData> GetBinaryData()
        {
            return null;
        }

        public virtual Task<Response<Thread>> GetThreadAsync()
        {
            return null;
        }

        public virtual Task<Operation<BinaryData>> GetOperationOfBinaryDataAsync()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_AllowsSystemClientModelTypes()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace System.ClientModel
{
    public class {|AZC0035:CustomClientModel|}
    {
        private CustomClientModel() { }
        public string Name { get; }
    }

    public class AllowedClientModel
    {
        public AllowedClientModel(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

namespace System.ClientModel.Primitives
{
    public class {|AZC0035:PrimitiveModel|}
    {
        private PrimitiveModel() { }
        public string Value { get; }
    }
}

namespace Azure.Test
{
    public class TestClient
    {
        public virtual Response<System.ClientModel.CustomClientModel> GetCustomClientModel()
        {
            return null;
        }

        public virtual Response<System.ClientModel.AllowedClientModel> GetAllowedClientModel()
        {
            return null;
        }

        public virtual Response<System.ClientModel.Primitives.PrimitiveModel> GetPrimitiveModel()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_GenericUnwrappingWithSystemTypes()
        {
            const string code = @"
using Azure;
using System;
using System.Threading.Tasks;

namespace System
{
    public class BinaryData
    {
        public string Content { get; }
    }
}

namespace Azure.Test
{
    public class {|AZC0035:CustomModel|}
    {
        private CustomModel() { }
        public string Name { get; }
    }

    public class TestClient
    {
        public virtual Task<Response<BinaryData>> GetBinaryDataInTaskResponseAsync()
        {
            return null;
        }

        public virtual Task<Operation<BinaryData>> GetBinaryDataInTaskOperationAsync()
        {
            return null;
        }

        public virtual Task<Pageable<BinaryData>> GetBinaryDataInTaskPageableAsync()
        {
            return null;
        }

        public virtual Task<Response<CustomModel>> GetCustomModelAsync()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_SystemClientModelGenericTypes()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace System.ClientModel
{
    public class {|AZC0035:ClientResult|}
    {
        private ClientResult() { }
        public string Value { get; }
    }

    public class EasyClientModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}

namespace Azure.Test
{
    public class TestClient
    {
        public virtual Response<System.ClientModel.ClientResult> GetClientResult()
        {
            return null;
        }

        public virtual Response<System.ClientModel.EasyClientModel> GetEasyClientModel()
        {
            return null;
        }

        public virtual Task<Response<System.ClientModel.ClientResult>> GetClientResultAsync()
        {
            return null;
        }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task AZC0035_OnlyAnalyzesSourceDefinedClientTypes()
        {
            const string code = @"
using Azure;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class {|AZC0035:MyCustomModel|}
    {
        private MyCustomModel() { }
        public string Value { get; }
    }

    public class MyClient
    {
        public virtual Response<MyCustomModel> GetModel()
        {
            return null;
        }
    }

    public static class MyModelFactory
    {
        public static SomeOtherModel SomeOtherModel()
        {
            return null;
        }
    }

    public class SomeOtherModel
    {
        public string Name { get; set; }
    }
}";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        // Regression test: a client method in this assembly returns a model declared
        // in a referenced (external) assembly. The model factory contract only
        // applies to types this assembly owns, so AZC0035 must NOT fire here.
        // Repros the bug seen in Azure.AI.Extensions.OpenAI on ResponseResult and
        // StreamingResponseUpdate (both declared in the external OpenAI package).
        //
        // Note: bypasses Microsoft.CodeAnalysis.Testing, which silently filters
        // diagnostics whose location is outside the test source — that filter
        // would mask this bug. We drive the analyzer directly and inspect
        // every diagnostic it emits.
        [Test]
        public async Task AZC0035_NotProducedForOutputModelsDefinedInExternalAssemblies()
        {
            // Compile a tiny "external" assembly containing a model that the
            // analyzer heuristic would flag (private ctor, read-only prop).
            const string externalSource = @"
namespace External.Models
{
    public class ExternalModel
    {
        private ExternalModel() { }
        public string Name { get; }
    }
}";
            var externalRef = await CompileToMetadataReferenceAsync(externalSource, "External");

            const string source = @"
using Azure;
using External.Models;
using System.Threading.Tasks;

namespace Azure.Test
{
    public class TestClient
    {
        public virtual Response<ExternalModel> GetModel()
        {
            return null;
        }

        public virtual Task<Response<ExternalModel>> GetModelAsync()
        {
            return null;
        }
    }
}";

            var diagnostics = await GetAllAnalyzerDiagnosticsAsync(source, externalRef);

            var azc0035 = diagnostics.Where(d => d.Id == "AZC0035").ToList();
            Assert.That(azc0035, Is.Empty,
                "AZC0035 should not fire for models defined in referenced assemblies. " +
                "Got: " + string.Join("; ", azc0035.Select(d => d.ToString())));
        }

        private static async Task<Microsoft.CodeAnalysis.MetadataReference> CompileToMetadataReferenceAsync(string source, string assemblyName)
        {
            var refAssemblies = await AzureTestReferences.DefaultReferenceAssemblies.ResolveAsync(
                Microsoft.CodeAnalysis.LanguageNames.CSharp, System.Threading.CancellationToken.None);
            var tree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(source);
            var comp = Microsoft.CodeAnalysis.CSharp.CSharpCompilation.Create(
                assemblyName,
                new[] { tree },
                refAssemblies,
                new Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary));
            using var ms = new System.IO.MemoryStream();
            var emit = comp.Emit(ms);
            if (!emit.Success)
            {
                throw new System.Exception("External compile failed: " + string.Join("; ", emit.Diagnostics));
            }
            ms.Position = 0;
            return Microsoft.CodeAnalysis.MetadataReference.CreateFromStream(ms);
        }

        private static async Task<System.Collections.Generic.IReadOnlyList<Microsoft.CodeAnalysis.Diagnostic>> GetAllAnalyzerDiagnosticsAsync(string source, params Microsoft.CodeAnalysis.MetadataReference[] extraReferences)
        {
            var refAssemblies = await AzureTestReferences.DefaultReferenceAssemblies.ResolveAsync(
                Microsoft.CodeAnalysis.LanguageNames.CSharp, System.Threading.CancellationToken.None);

            var allRefs = refAssemblies.AddRange(extraReferences);

            var syntaxTree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(source);
            var compilation = Microsoft.CodeAnalysis.CSharp.CSharpCompilation.Create(
                "TestAssembly",
                new[] { syntaxTree },
                allRefs,
                new Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary));

            var withAnalyzers = ((Microsoft.CodeAnalysis.Compilation)compilation).WithAnalyzers(
                System.Collections.Immutable.ImmutableArray.Create<DiagnosticAnalyzer>(new ModelFactoryAnalyzer()));

            var diagnostics = await withAnalyzers.GetAnalyzerDiagnosticsAsync(System.Threading.CancellationToken.None);
            return diagnostics;
        }
    }
}
