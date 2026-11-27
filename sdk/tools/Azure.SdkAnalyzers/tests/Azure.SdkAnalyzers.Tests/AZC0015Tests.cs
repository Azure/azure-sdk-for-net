// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.ClientMethodReturnTypeAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0015Tests
    {
        private static string Wrap(string member) => $@"
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure;

namespace RandomNamespace
{{
    public class SomeClient
    {{
        {member}
    }}
}}";

        [TestCase("public int {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public string {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public int[] {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<int> {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<Pageable<int>> {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<AsyncPageable<int>> {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<CollectionResult> {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<AsyncCollectionResult> {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<CollectionResult<int>> {|AZC0015:FooAsync|}() { return default; }")]
        [TestCase("public Task<AsyncCollectionResult<int>> {|AZC0015:FooAsync|}() { return default; }")]
        public async Task AZC0015ProducedForInvalidReturnTypes(string member)
        {
            await Verifier.VerifyAnalyzerAsync(Wrap(member));
        }

        [TestCase("public Response FooAsync() { return default; }")]
        [TestCase("public Response<int> FooAsync() { return default; }")]
        [TestCase("public Task<Response<int>> FooAsync() { return default; }")]
        [TestCase("public NullableResponse<int> FooAsync() { return default; }")]
        [TestCase("public Operation<int> FooAsync() { return default; }")]
        [TestCase("public Task<Operation<int>> FooAsync() { return default; }")]
        [TestCase("public Pageable<int> FooAsync() { return default; }")]
        [TestCase("public AsyncPageable<int> FooAsync() { return default; }")]
        public async Task AZC0015NotProducedForValidAzureReturnTypes(string member)
        {
            await Verifier.VerifyAnalyzerAsync(Wrap(member));
        }

        // System.ClientModel (SCM) clients return ClientResult / CollectionResult family types
        // rather than the Azure.Core Response family. AZC0015 must accept those.
        [TestCase("public ClientResult FooAsync() { return default; }")]
        [TestCase("public ClientResult<int> FooAsync() { return default; }")]
        [TestCase("public Task<ClientResult> FooAsync() { return default; }")]
        [TestCase("public Task<ClientResult<int>> FooAsync() { return default; }")]
        [TestCase("public CollectionResult FooAsync() { return default; }")]
        [TestCase("public AsyncCollectionResult FooAsync() { return default; }")]
        [TestCase("public CollectionResult<int> FooAsync() { return default; }")]
        [TestCase("public AsyncCollectionResult<int> FooAsync() { return default; }")]
        public async Task AZC0015NotProducedForSystemClientModelReturnTypes(string member)
        {
            await Verifier.VerifyAnalyzerAsync(Wrap(member));
        }

        [TestCase("ClientResult", "Task<ClientResult>")]
        [TestCase("ClientResult<int>", "Task<ClientResult<int>>")]
        [TestCase("CollectionResult", "AsyncCollectionResult")]
        [TestCase("CollectionResult<int>", "AsyncCollectionResult<int>")]
        [TestCase("Response<int>", "Task<Response<int>>")]
        [TestCase("Pageable<int>", "AsyncPageable<int>")]
        public async Task AZC0015NotProducedForMatchingSyncAndAsyncMethods(string syncReturnType, string asyncReturnType)
        {
            await Verifier.VerifyAnalyzerAsync(Wrap($@"
        public virtual {syncReturnType} GetItems(System.Threading.CancellationToken cancellationToken = default) => default;
        public virtual {asyncReturnType} GetItemsAsync(System.Threading.CancellationToken cancellationToken = default) => default;"));
        }

        [TestCase("CollectionResult")]
        [TestCase("AsyncCollectionResult")]
        [TestCase("CollectionResult<int>")]
        [TestCase("AsyncCollectionResult<int>")]
        public async Task AZC0015NotProducedForDerivedCollectionResults(string returnType)
        {
            var test = Verifier.CreateAnalyzer(Wrap($@"
        public abstract class IntermediateResult<T> : {returnType} {{ }}
        public abstract class DerivedResult : IntermediateResult<int> {{ }}

        public virtual IntermediateResult<int> GetBaseAsync() => default;
        public virtual DerivedResult GetDerivedAsync() => default;"));

            // Inheritance requires the netstandard reference assembly even when the test runner targets .NET Framework.
            string? nugetConfigFilePath = test.ReferenceAssemblies.NuGetConfigFilePath;
            test.ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20
                .WithPackages(test.ReferenceAssemblies.Packages);
            if (nugetConfigFilePath != null)
            {
                test.ReferenceAssemblies = test.ReferenceAssemblies.WithNuGetConfigFilePath(nugetConfigFilePath);
            }

            await test.RunAsync();
        }

        [TestCase("OtherNamespace", "CollectionResult")]
        [TestCase("OtherNamespace", "AsyncCollectionResult")]
        [TestCase("System.ClientModel.Primitives.Other", "CollectionResult")]
        [TestCase("System.ClientModel.Primitives.Other", "AsyncCollectionResult")]
        public async Task AZC0015ProducedForCollectionResultsInOtherNamespaces(string namespaceName, string typeName)
        {
            string code = Wrap($@"
        public virtual {namespaceName}.{typeName} {{|AZC0015:FooAsync|}}() => default;") + $@"
namespace {namespaceName}
{{
    public class {typeName} {{ }}
}}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [TestCase("CollectionResult")]
        [TestCase("AsyncCollectionResult")]
        public async Task AZC0015ProducedForGenericCollectionLookalikesInPrimitivesNamespace(string typeName)
        {
            string code = Wrap($@"
        public virtual System.ClientModel.Primitives.{typeName}<int> {{|AZC0015:FooAsync|}}() => default;") + $@"
namespace System.ClientModel.Primitives
{{
    public class {typeName}<T> {{ }}
}}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        [TestCase("public System.ClientModel.AsyncStreamingResult<int> FooAsync() { return default; }")]
        [TestCase("public Task<System.ClientModel.AsyncStreamingResult<int>> FooAsync() { return default; }")]
        [TestCase("public System.ClientModel.AsyncStreamingClientResult<int> FooAsync() { return default; }")]
        [TestCase("public Task<System.ClientModel.AsyncStreamingClientResult<int>> FooAsync() { return default; }")]
        public async Task AZC0015NotProducedForAsyncStreamingResult(string member)
        {
            string code = $@"
using System.Threading.Tasks;

namespace System.ClientModel
{{
    public sealed class AsyncStreamingResult<T>
    {{
    }}

    public sealed class AsyncStreamingClientResult<T>
    {{
    }}
}}

namespace RandomNamespace
{{
    public class SomeClient
    {{
        {member}
    }}
}}";

            await Verifier.VerifyAnalyzerAsync(code);
        }

        // A public client nested in a non-public type is not publicly accessible, so the
        // return-type rule should not analyze it.
        [Test]
        public async Task AZC0015NotProducedForClientNestedInNonPublicType()
        {
            const string code = @"
namespace RandomNamespace
{
    internal class Outer
    {
        public class SomeClient
        {
            public int FooAsync() { return default; }
        }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        // A user-defined generic type named 'Task' is not System.Threading.Tasks.Task and must
        // not be unwrapped; e.g. a client method returning a custom Task<Response> is not a valid
        // client return type.
        [TestCase("public RandomNamespace.Task<Response> {|AZC0015:FooAsync|}() { return default; }")]
        public async Task AZC0015ProducedForUserDefinedTaskType(string member)
        {
            string code = $@"
using Azure;

namespace RandomNamespace
{{
    public class Task<T> {{ }}

    public class SomeClient
    {{
        {member}
    }}
}}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        // AZC0015 is a public-API rule, so a non-public synchronous counterpart of an
        // async client method must not be validated (or reported on).
        [Test]
        public async Task AZC0015NotProducedForNonPublicSyncCounterpart()
        {
            const string code = @"
using System.ClientModel;

namespace RandomNamespace
{
    public class SomeClient
    {
        public ClientResult FooAsync() { return default; }
        private int Foo() { return default; }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }

        // The sync-counterpart match must consider parameter modifiers (ref/out/in, params),
        // not just types, so a method with a different modifier is not paired and reported on.
        [Test]
        public async Task AZC0015NotProducedWhenSyncCounterpartHasDifferentParameterModifiers()
        {
            const string code = @"
using System.ClientModel;

namespace RandomNamespace
{
    public class SomeClient
    {
        public ClientResult FooAsync(int x) { return default; }
        public int Foo(ref int x) { return default; }
    }
}";
            await Verifier.VerifyAnalyzerAsync(code);
        }
    }
}
