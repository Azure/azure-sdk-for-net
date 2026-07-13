// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core.Pipeline;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Tests.Visitors
{
    public class DistributedTracingVisitorTests
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";

        [SetUp]
        public void Setup()
        {
            MockHelpers.LoadMockGenerator();
        }

        [Test]
        public void TestAddsClientDiagnosticsProperty()
        {
            // Arrange
            var visitor = new TestDistributedTracingVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "p1",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            // Visit
            var updatedClient = visitor.InvokeVisit(inputClient, clientProvider);

            // Assert
            Assert.IsNotNull(updatedClient);
            Assert.IsTrue(updatedClient!.Properties.Any(p => p.Name == ClientDiagnosticsPropertyName));
            var property = updatedClient.Properties.First(p => p.Name == ClientDiagnosticsPropertyName);
            Assert.AreEqual(new CSharpType(typeof(ClientDiagnostics)), property.Type);
            Assert.AreEqual(MethodSignatureModifiers.Internal, property.Modifiers);
        }

        // This test validates the primary constructors of the client are updated to initialize the ClientDiagnostics property.
        [TestCaseSource(nameof(TestUpdatesConstructorsTestCases))]
        public void TestUpdatesConstructors(InputClient inputClient)
        {
            // Arrange
            var visitor = new TestDistributedTracingVisitor();
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            bool isSubClient = inputClient.Parent != null;
            var constructor = clientProvider!.Constructors
                .FirstOrDefault(c =>
                    c.Signature.Initializer == null &&
                    ((isSubClient && c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                      c.Signature.Parameters.Any(p => p.Name == "endpoint")) ||
                     (!isSubClient && c.Signature.Parameters.Any(p => p.Name == "options"))));
            Assert.IsNotNull(constructor);

            var updatedConstructor = visitor.InvokeVisitConstructor(constructor!);
            Assert.IsNotNull(updatedConstructor?.BodyStatements);
            Assert.IsTrue(updatedConstructor!.BodyStatements!.Any());

            var bodyText = updatedConstructor.BodyStatements!.ToDisplayString();
            var expectedText = isSubClient
                ? "ClientDiagnostics = clientDiagnostics"
                : "ClientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics(options, true)";

            Assert.IsTrue(bodyText.Contains(expectedText),
                $"Constructor should contain appropriate ClientDiagnostics initialization for {(isSubClient ? "subclient" : "client")}");
        }

        [Test]
        public void TestUpdatesSubClientFactoryMethods()
        {
            var visitor = new TestDistributedTracingVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "p1",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            var childInputClient = InputFactory.Client("SubClient", parent: inputClient);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient, childInputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // find the subclient factory method
            var factoryMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Name == "GetSubClient");
            Assert.IsNotNull(factoryMethod);

            var updatedFactoryMethod = visitor.InvokeVisitMethod(factoryMethod!);
            Assert.IsNotNull(updatedFactoryMethod?.BodyStatements);

            var bodyText = updatedFactoryMethod!.BodyStatements!.ToDisplayString();
            Assert.IsTrue(bodyText.Contains("new global::Samples.SubClient(ClientDiagnostics, Pipeline, _endpoint)"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestUpdatesProtocolMethods(bool isProtocolMethod)
        {
            var visitor = new TestDistributedTracingVisitor();

            // load the input
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "p1",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            // create the client provider
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // create a method to test the visitor
            var methodSignature = new MethodSignature(
                "Foo",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async,
                AzureClientGenerator.Instance.TypeFactory.ClientResponseApi.ClientResponseType,
                $"The response returned from the service.",
                [new ParameterProvider("p1", $"p1", AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType)]);
            var bodyStatements = InvokeConsoleWriteLine(Literal("Hello World"));
            var methodKind = isProtocolMethod ? ScmMethodKind.Protocol : ScmMethodKind.Convenience;
            var method = new ScmMethodProvider(methodSignature, bodyStatements, clientProvider!, methodKind);

            var updatedMethod = visitor.InvokeVisitMethod(method!);
            Assert.IsNotNull(updatedMethod?.BodyStatements);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(isProtocolMethod.ToString()), result);
        }

        // Regression test for https://github.com/Azure/azure-sdk-for-net/pull/58979.
        // Libraries such as Azure.AI.Agents.Persistent declare the "ClientDiagnostics" property in
        // hand-written custom code. The custom property's CSharpType is not equal to the framework
        // ClientDiagnostics type injected into the visitor, so matching the property by type threw
        // "Sequence contains no matching element" during regeneration. The property must be matched
        // by name so that a custom-declared ClientDiagnostics property is still found.
        [Test]
        public void TestProtocolMethodWithCustomTypedClientDiagnosticsProperty()
        {
            var visitor = new TestDistributedTracingVisitor();

            // load the input
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "p1",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            // create the client provider
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // Replace the generated ClientDiagnostics property with one whose CSharpType differs from
            // the framework ClientDiagnostics type injected into the visitor, simulating a
            // ClientDiagnostics property declared in custom code.
            var customTypedClientDiagnostics = new PropertyProvider(
                $"The ClientDiagnostics is used to provide tracing support for the client library.",
                MethodSignatureModifiers.Internal,
                new CSharpType(typeof(object)),
                ClientDiagnosticsPropertyName,
                new AutoPropertyBody(false),
                clientProvider!);
            clientProvider!.Update(properties: [customTypedClientDiagnostics]);

            // create a protocol method to test the visitor
            var methodSignature = new MethodSignature(
                "Foo",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async,
                AzureClientGenerator.Instance.TypeFactory.ClientResponseApi.ClientResponseType,
                $"The response returned from the service.",
                [new ParameterProvider("p1", $"p1", AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType)]);
            var bodyStatements = InvokeConsoleWriteLine(Literal("Hello World"));
            var method = new ScmMethodProvider(methodSignature, bodyStatements, clientProvider!, ScmMethodKind.Protocol);

            // The visitor must not throw and must still wrap the body in a diagnostic scope.
            ScmMethodProvider? updatedMethod = null;
            Assert.DoesNotThrow(() => updatedMethod = visitor.InvokeVisitMethod(method));
            Assert.IsNotNull(updatedMethod?.BodyStatements);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            Assert.IsTrue(result.Contains("ClientDiagnostics.CreateScope(\"TestClient.Foo\")"),
                $"Protocol method should be wrapped with a diagnostic scope. Actual: {result}");
        }

        // Regression test for https://github.com/Azure/azure-sdk-for-net/pull/58979.
        // Custom code can rename the ClientDiagnostics property via [CodeGenMember("ClientDiagnostics")],
        // in which case the property's Name differs but its OriginalName is still "ClientDiagnostics".
        // The visitor must locate the property by its OriginalName so the renamed property is still found
        // (and it must be located by name, not by CSharpType, to keep the previous regression fixed).
        [Test]
        public void TestProtocolMethodWithRenamedClientDiagnosticsProperty()
        {
            var visitor = new TestDistributedTracingVisitor();

            // load the input
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "p1",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            // create the client provider
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // Replace the generated ClientDiagnostics property with one that has been renamed via custom
            // code: its Name is different, but its OriginalName is still "ClientDiagnostics". The type is
            // also non-framework, matching how a custom-declared property is modeled.
            var renamedClientDiagnostics = new PropertyProvider(
                $"The ClientDiagnostics is used to provide tracing support for the client library.",
                MethodSignatureModifiers.Internal,
                new CSharpType(typeof(object)),
                "RenamedDiagnostics",
                new AutoPropertyBody(false),
                clientProvider!);
            MockHelpers.SetOriginalName(renamedClientDiagnostics, ClientDiagnosticsPropertyName);
            // NOTE: OriginalName is set via reflection because this test project lacks custom-code test
            // infra to load a real [CodeGenMember] rename. Tracked by https://github.com/Azure/azure-sdk-for-net/issues/60907.
            clientProvider!.Update(properties: [renamedClientDiagnostics]);

            // create a protocol method to test the visitor
            var methodSignature = new MethodSignature(
                "Foo",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async,
                AzureClientGenerator.Instance.TypeFactory.ClientResponseApi.ClientResponseType,
                $"The response returned from the service.",
                [new ParameterProvider("p1", $"p1", AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType)]);
            var bodyStatements = InvokeConsoleWriteLine(Literal("Hello World"));
            var method = new ScmMethodProvider(methodSignature, bodyStatements, clientProvider!, ScmMethodKind.Protocol);

            // The visitor must not throw and must still wrap the body in a diagnostic scope, using the
            // renamed property to create the scope.
            ScmMethodProvider? updatedMethod = null;
            Assert.DoesNotThrow(() => updatedMethod = visitor.InvokeVisitMethod(method));
            Assert.IsNotNull(updatedMethod?.BodyStatements);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            Assert.IsTrue(result.Contains("RenamedDiagnostics.CreateScope(\"TestClient.Foo\")"),
                $"Protocol method should be wrapped with a diagnostic scope using the renamed property. Actual: {result}");
        }

        // This test validates that the "Async" suffix is stripped from the scope name for a protocol
        // method whose name ends in "Async", since GetScopeName() handles the stripping centrally.
        [Test]
        public void TestAsyncProtocolMethodScopeNameStripsAsyncSuffix()
        {
            var visitor = new TestDistributedTracingVisitor();

            // load the input
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "p1",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            // create the client provider
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // create a protocol method whose name ends in "Async" to test the visitor
            var methodSignature = new MethodSignature(
                "FooAsync",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async,
                AzureClientGenerator.Instance.TypeFactory.ClientResponseApi.ClientResponseType,
                $"The response returned from the service.",
                [new ParameterProvider("p1", $"p1", AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType)]);
            var bodyStatements = InvokeConsoleWriteLine(Literal("Hello World"));
            var method = new ScmMethodProvider(methodSignature, bodyStatements, clientProvider!, ScmMethodKind.Protocol);

            var updatedMethod = visitor.InvokeVisitMethod(method!);
            Assert.IsNotNull(updatedMethod?.BodyStatements);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            // The "Async" suffix should be stripped from the scope name.
            Assert.IsTrue(result.Contains("ClientDiagnostics.CreateScope(\"TestClient.Foo\")"),
                $"Scope name should strip the \"Async\" suffix. Actual: {result}");
            Assert.IsFalse(result.Contains("TestClient.FooAsync"),
                $"Scope name should not contain the \"Async\" suffix. Actual: {result}");
        }

        [TestCase(true, ScmMethodKind.Protocol)]
        [TestCase(false, ScmMethodKind.Protocol)]
        [TestCase(true, ScmMethodKind.Convenience)]
        [TestCase(false, ScmMethodKind.Convenience)]
        public void TestPagingMethodsGetScopeInjected(bool isAsync, ScmMethodKind methodKind)
        {
            var visitor = new TestDistributedTracingVisitor();

            // load the input
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                "context",
                InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation(
                "listItems",
                parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("listItems", basicOperation, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [basicServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            // create the client provider
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            // create a paging method to test the visitor
            var pagingReturnType = isAsync
                ? new CSharpType(typeof(AsyncPageable<>), typeof(BinaryData))
                : new CSharpType(typeof(Pageable<>), typeof(BinaryData));

            var methodName = isAsync ? "ListItemsAsync" : "ListItems";
            var methodSignature = new MethodSignature(
                methodName,
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                pagingReturnType,
                $"The pageable response returned from the service.",
                [new ParameterProvider("context", $"The request context", AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType)]);
            var bodyStatements = Return(New.Instance(pagingReturnType));
            var method = new ScmMethodProvider(methodSignature, bodyStatements, clientProvider!, methodKind);

            var updatedMethod = visitor.InvokeVisitMethod(method!);
            Assert.IsNotNull(updatedMethod?.BodyStatements);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            // Verify that the method body does NOT contain DiagnosticScope instrumentation (no wrapping)
            Assert.IsFalse(result.Contains("DiagnosticScope"),
                $"Paging method should not have DiagnosticScope instrumentation. Method: {(isAsync ? "AsyncPageable" : "Pageable")}, Kind: {methodKind}");
            Assert.IsFalse(result.Contains("scope.Start()"),
                $"Paging method should not have scope.Start() call. Method: {(isAsync ? "AsyncPageable" : "Pageable")}, Kind: {methodKind}");
            // Verify the scope name is injected as a constructor argument
            Assert.IsTrue(result.Contains("\"TestClient.ListItems\""),
                $"Paging method should have scope name injected. Method: {(isAsync ? "AsyncPageable" : "Pageable")}, Kind: {methodKind}");
        }

        private static IEnumerable<TestCaseData> TestUpdatesConstructorsTestCases
        {
            get
            {
                // basic client
                yield return new TestCaseData(InputFactory.Client(
                    "TestClient",
                    methods:
                    [
                        InputFactory.BasicServiceMethod(
                            "foo",
                            InputFactory.Operation("foo", parameters: [InputFactory.BodyParameter("p1", InputPrimitiveType.String)]),
                            parameters: [InputFactory.MethodParameter("p1", InputPrimitiveType.String)])
                    ]));
                // sub client
                yield return new TestCaseData(InputFactory.Client(
                    "TestClient",
                    methods:
                    [
                        InputFactory.BasicServiceMethod(
                            "foo",
                            InputFactory.Operation("foo", parameters: [InputFactory.BodyParameter("p1", InputPrimitiveType.String)]),
                            parameters: [InputFactory.MethodParameter("p1", InputPrimitiveType.String)])
                    ],
                    parent: InputFactory.Client("parent")));
            }
        }

        private class TestDistributedTracingVisitor : AzureDistributedTracingVisitor
        {
            public ClientProvider? InvokeVisit(InputClient client, ClientProvider? clientProvider)
            {
                return base.Visit(client, clientProvider);
            }

            public ConstructorProvider? InvokeVisitConstructor(ConstructorProvider constructor)
            {
                return base.VisitConstructor(constructor);
            }

            public MethodProvider? InvokeVisitMethod(MethodProvider method)
            {
                return base.VisitMethod(method);
            }

            public ScmMethodProvider? InvokeVisitMethod(ScmMethodProvider method)
            {
                return base.VisitMethod(method);
            }
        }
    }
}
