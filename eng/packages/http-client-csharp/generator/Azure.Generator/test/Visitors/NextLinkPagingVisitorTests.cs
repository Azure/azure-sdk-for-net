// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class NextLinkPagingVisitorTests
    {
        [Test]
        public void HidesOnlyMarkedTokenOnNextLinkMethods(
            [Values] bool nextLink,
            [Values] bool marked,
            [Values(InputRequestLocation.Query, InputRequestLocation.Header)] InputRequestLocation location)
        {
            var client = CreateClient(nextLink, marked, location);
            Assert.AreEqual(4, client.Methods.Count);
            foreach (var method in client.Methods)
            {
                Assert.AreEqual(!(nextLink && marked), method.Signature.Parameters.Any(p => p.Name == "resumeFrom"));
                Assert.IsTrue(method.Signature.Parameters.Any(p => p.Name == "filter"));
                if (nextLink && marked)
                {
                    StringAssert.Contains("string resumeFrom = default;", method.BodyStatements!.ToDisplayString());
                }
            }

            var request = client.RestClient.Methods.Single(m => m.Signature.Name == "CreateGetCatsRequest");
            Assert.IsTrue(request.Signature.Parameters.Any(p => p.Name == "resumeFrom"));
            StringAssert.Contains("wire-token", request.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void PreservesLastContractTokenOverloads([Values] bool newOptionalParameter)
        {
            var client = CreateClient(true, true, InputRequestLocation.Query,
            [
                """
                namespace Samples
                {
                    public class CatClient
                    {
                        public virtual Azure.Pageable<Cat> GetCats(string resumeFrom = default, System.Threading.CancellationToken cancellationToken = default) => default;
                        public virtual Azure.AsyncPageable<Cat> GetCatsAsync(string resumeFrom = default, System.Threading.CancellationToken cancellationToken = default) => default;
                        public virtual Azure.Pageable<System.BinaryData> GetCats(string resumeFrom, Azure.RequestContext context) => default;
                        public virtual Azure.AsyncPageable<System.BinaryData> GetCatsAsync(string resumeFrom, Azure.RequestContext context) => default;
                    }
                }
                """
            ], includeFilter: newOptionalParameter);
            ProcessBackCompatibility(client);

            var publicMethods = client.Methods.Where(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)).ToArray();
            Assert.AreEqual(8, publicMethods.Length);
            foreach (var method in publicMethods)
            {
                bool hasToken = method.Signature.Parameters.Any(p => p.Name == "resumeFrom");
                Assert.AreEqual(hasToken, method.Signature.Attributes.Any(
                    a => a.Type.Equals(typeof(System.ComponentModel.EditorBrowsableAttribute))));
                if (hasToken)
                {
                    Assert.IsNull(method.Signature.Parameters[0].DefaultValue);
                    Assert.IsFalse(method.Signature.Parameters.Any(p => p.Name == "filter"));
                    StringAssert.DoesNotContain("string resumeFrom = default;", method.BodyStatements!.ToDisplayString());
                    if (newOptionalParameter)
                    {
                        StringAssert.Contains("filter: default", method.BodyStatements!.ToDisplayString());
                    }
                }
            }
            AssertMethodsCompile(client);
        }

        [Test]
        public void PreservesMultipleLastContractTokenOverloads(
            [Values] bool fullSignatureFirst,
            [Values] bool fullSignatureHasDefaults)
        {
            string fullDefaults = fullSignatureHasDefaults ? " = default" : "";
            string shortDefaults = fullSignatureHasDefaults ? "" : " = default";
            var signatures = new[]
            {
                $"public virtual Azure.Pageable<Cat> GetCats(string resumeFrom, int? filter{fullDefaults}, System.Threading.CancellationToken cancellationToken{fullDefaults}) => default;",
                $"public virtual Azure.Pageable<Cat> GetCats(string resumeFrom, System.Threading.CancellationToken cancellationToken{shortDefaults}) => default;"
            };
            if (!fullSignatureFirst)
            {
                Array.Reverse(signatures);
            }
            var client = CreateClient(true, true, InputRequestLocation.Query,
            [
                $"namespace Samples {{ public class CatClient {{ {string.Join(Environment.NewLine, signatures)} }} }}"
            ]);
            ProcessBackCompatibility(client);

            var legacyMethods = client.Methods.Where(m => m.Signature.Name == "GetCats"
                && m.Signature.Parameters.Any(p => p.Name == "resumeFrom")
                && m.Signature.ReturnType!.Arguments[0].Name == "Cat").ToArray();
            Assert.AreEqual(2, legacyMethods.Length);
            foreach (var method in legacyMethods)
            {
                Assert.AreEqual(1, method.Signature.Attributes.Count(
                    a => a.Type.Equals(typeof(System.ComponentModel.EditorBrowsableAttribute))));
            }
            AssertMethodsCompile(client, """GetCats(); GetCats("saved-token"); GetCats("saved-token", System.Threading.CancellationToken.None);""");
        }

        [Test]
        public void PreservesExistingOptionalParameterCompatibility()
        {
            var client = CreateClient(true, true, InputRequestLocation.Query,
            [
                """
                    namespace Samples
                    {
                        public class CatClient
                        {
                            public virtual Azure.Pageable<Cat> GetCats(System.Threading.CancellationToken cancellationToken = default) => default;
                        }
                    }
                    """
            ]);
            ProcessBackCompatibility(client);
            Assert.AreEqual(5, client.Methods.Count);
            Assert.IsFalse(client.Methods.Any(m => m.Signature.Parameters.Any(p => p.Name == "resumeFrom")));
            var legacy = client.Methods.Single(m => m.Signature.Name == "GetCats" && m.Signature.Parameters.Count == 1
                && m.Signature.Parameters[0].Name == "cancellationToken");
            Assert.IsTrue(legacy.Signature.Attributes.Any(a => a.Type.Equals(typeof(System.ComponentModel.EditorBrowsableAttribute))));
            StringAssert.Contains("filter: default", legacy.BodyStatements!.ToDisplayString());
            AssertMethodsCompile(client);
        }

        [Test]
        public void PreservesConditionalHeaderCustomization()
        {
            var client = CreateClient(true, true, InputRequestLocation.Query,
            [
                """
                    namespace Samples
                    {
                        public class CatClient
                        {
                            public virtual Azure.Pageable<Cat> GetCats(string resumeFrom, Azure.MatchConditions matchConditions, System.Threading.CancellationToken cancellationToken = default) => default;
                        }
                    }
                    """
            ], includeFilter: false, includeConditions: true);
            var legacy = client.Methods.Single(m => m.Signature.Name == "GetCats"
                && m.Signature.Parameters.Any(p => p.Name == "resumeFrom")
                && m.Signature.ReturnType!.Arguments[0].Name == "Cat");
            Assert.IsTrue(legacy.Signature.Parameters.Any(p => p.Name == "matchConditions"));
            StringAssert.Contains("matchConditions", legacy.BodyStatements!.ToDisplayString());
            StringAssert.DoesNotContain("ifMatch", legacy.BodyStatements!.ToDisplayString());
            AssertMethodsCompile(client);
        }

        private static void ProcessBackCompatibility(ClientProvider client)
            => typeof(TypeProvider).GetMethod("ProcessTypeForBackCompatibility", BindingFlags.Instance | BindingFlags.NonPublic)!
                .Invoke(client, null);

        private static void AssertMethodsCompile(ClientProvider client, string callerStatements = "")
        {
            var source = CSharpSyntaxTree.ParseText(new TypeProviderWriter(client).Write().Content).GetCompilationUnitRoot();
            var methods = source.DescendantNodes().OfType<MethodDeclarationSyntax>().Select(m =>
                m.Body?.DescendantNodes().OfType<ObjectCreationExpressionSyntax>().Any() == true
                    ? m.WithBody(SyntaxFactory.ParseStatement("{ throw new System.NotImplementedException(); }") as BlockSyntax)
                    : m);
            var testClass = SyntaxFactory.ClassDeclaration("CatClient")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddMembers([.. methods])
                .AddMembers(SyntaxFactory.ParseMemberDeclaration($"public void Calls() {{ {callerStatements} }}")!);
            source = source.WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("Samples"))
                    .AddMembers(SyntaxFactory.ClassDeclaration("Cat").AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)), testClass)));
            var references = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator)
                .Append(typeof(Pageable<>).Assembly.Location)
                .Append(typeof(BinaryData).Assembly.Location)
                .Distinct().Select(path => MetadataReference.CreateFromFile(path));
            var compilation = CSharpCompilation.Create("PagingOverloads", [source.SyntaxTree], references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            Assert.IsEmpty(compilation.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error), source.ToFullString());
        }

        private static ClientProvider CreateClient(
            bool nextLink,
            bool marked,
            InputRequestLocation location,
            IEnumerable<string>? lastContractSources = null,
            bool includeFilter = true,
            bool includeConditions = false)
        {
            var token = InputFactory.MethodParameter("resumeFrom", InputPrimitiveType.String, serializedName: "wire-token", location: location);
            InputParameter httpToken = location == InputRequestLocation.Query
                ? InputFactory.QueryParameter("resumeFrom", InputPrimitiveType.String, serializedName: "wire-token")
                : InputFactory.HeaderParameter("resumeFrom", InputPrimitiveType.String, serializedName: "wire-token");
            if (marked)
            {
                typeof(InputParameter).GetProperty(nameof(InputParameter.Decorators))!.SetValue(
                    httpToken, new[] { new InputDecoratorInfo("TypeSpec.@continuationToken", null) });
            }
            var cat = InputFactory.Model("Cat", clientNamespace: "Samples");
            var page = InputFactory.Model("CatPage", properties:
            [
                InputFactory.Property("cats", InputFactory.Array(cat)),
                InputFactory.Property("next", InputPrimitiveType.Url)
            ]);
            List<InputParameter> parameters = [httpToken];
            List<InputMethodParameter> methodParameters = [token];
            if (includeFilter)
            {
                parameters.Add(InputFactory.QueryParameter("filter", InputPrimitiveType.Int32));
                methodParameters.Add(InputFactory.MethodParameter("filter", InputPrimitiveType.Int32, location: InputRequestLocation.Query));
            }
            if (includeConditions)
            {
                foreach (var header in new[] { "If-Match", "If-None-Match" })
                {
                    parameters.Add(InputFactory.HeaderParameter(header, InputPrimitiveType.String, serializedName: header));
                    methodParameters.Add(InputFactory.MethodParameter(header, InputPrimitiveType.String, serializedName: header, location: InputRequestLocation.Header));
                }
            }
            var operation = InputFactory.Operation("GetCats", parameters: parameters, responses: [InputFactory.OperationResponse(bodytype: page)]);
            var method = InputFactory.PagingServiceMethod("GetCats", operation, parameters: methodParameters,
                pagingMetadata: nextLink
                    ? InputFactory.NextLinkPagingMetadata("cats", "next", InputResponseLocation.Body)
                    : InputFactory.PagingMetadata(["cats"], null, null));
            var inputClient = InputFactory.Client("CatClient", methods: [method]);
            MockHelpers.LoadMockGenerator(inputModels: () => [cat, page], clients: () => [inputClient],
                lastContractSources: lastContractSources?.Append(
                    """
                    namespace Azure
                    {
                        public abstract class Pageable<T> { }
                        public abstract class AsyncPageable<T> { }
                        public class RequestContext { }
                        public class MatchConditions { }
                    }
                    namespace Samples { public class Cat { } }
                    namespace System { public class BinaryData { } }
                    """));
            return AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
        }
    }
}
