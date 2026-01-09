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
            Assert.That(updatedClient, Is.Not.Null);
            Assert.That(updatedClient!.Properties.Any(p => p.Name == ClientDiagnosticsPropertyName), Is.True);
            var property = updatedClient.Properties.First(p => p.Name == ClientDiagnosticsPropertyName);
            Assert.Multiple(() =>
            {
                Assert.That(property.Type, Is.EqualTo(new CSharpType(typeof(ClientDiagnostics))));
                Assert.That(property.Modifiers, Is.EqualTo(MethodSignatureModifiers.Internal));
            });
        }

        // This test validates the primary constructors of the client are updated to initialize the ClientDiagnostics property.
        [TestCaseSource(nameof(TestUpdatesConstructorsTestCases))]
        public void TestUpdatesConstructors(InputClient inputClient)
        {
            // Arrange
            var visitor = new TestDistributedTracingVisitor();
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.That(clientProvider, Is.Not.Null);

            bool isSubClient = inputClient.Parent != null;
            var constructor = clientProvider!.Constructors
                .FirstOrDefault(c =>
                    c.Signature.Initializer == null &&
                    ((isSubClient && c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                      c.Signature.Parameters.Any(p => p.Name == "endpoint")) ||
                     (!isSubClient && c.Signature.Parameters.Any(p => p.Name == "options"))));
            Assert.That(constructor, Is.Not.Null);

            var updatedConstructor = visitor.InvokeVisitConstructor(constructor!);

            Assert.That(updatedConstructor?.BodyStatements, Is.Not.Null);
            Assert.That(updatedConstructor!.BodyStatements!.Any(), Is.True);

            var bodyText = updatedConstructor.BodyStatements!.ToDisplayString();
            var expectedText = isSubClient
                ? "ClientDiagnostics = clientDiagnostics"
                : "ClientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics(options, true)";

            Assert.That(bodyText,
                Does.Contain(expectedText),
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
            Assert.That(clientProvider, Is.Not.Null);

            // find the subclient factory method
            var factoryMethod = clientProvider!.Methods
                .FirstOrDefault(m =>m.Signature.Name == "GetSubClient");
            Assert.That(factoryMethod, Is.Not.Null);

            var updatedFactoryMethod = visitor.InvokeVisitMethod(factoryMethod!);
            Assert.That(updatedFactoryMethod?.BodyStatements, Is.Not.Null);

            var bodyText = updatedFactoryMethod!.BodyStatements!.ToDisplayString();
            Assert.That(bodyText, Does.Contain("new global::Samples.SubClient(ClientDiagnostics, Pipeline, _endpoint)"));
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
            Assert.That(clientProvider, Is.Not.Null);

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
            Assert.That(updatedMethod?.BodyStatements, Is.Not.Null);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            Assert.That(result, Is.EqualTo(Helpers.GetExpectedFromFile(isProtocolMethod.ToString())));
        }

        [TestCase(true, ScmMethodKind.Protocol)]
        [TestCase(false, ScmMethodKind.Protocol)]
        [TestCase(true, ScmMethodKind.Convenience)]
        [TestCase(false, ScmMethodKind.Convenience)]
        public void TestSkipsInstrumentationForPagingMethods(bool isAsync, ScmMethodKind methodKind)
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
            Assert.That(clientProvider, Is.Not.Null);

            // create a paging method to test the visitor
            var pagingReturnType = isAsync
                ? new CSharpType(typeof(AsyncPageable<>), typeof(BinaryData))
                : new CSharpType(typeof(Pageable<>), typeof(BinaryData));

            var methodSignature = new MethodSignature(
                isAsync ? "ListItemsAsync" : "ListItems",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                pagingReturnType,
                $"The pageable response returned from the service.",
                [new ParameterProvider("context", $"The request context", AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType)]);
            var bodyStatements = Return(New.Instance(pagingReturnType));
            var method = new ScmMethodProvider(methodSignature, bodyStatements, clientProvider!, methodKind);

            var updatedMethod = visitor.InvokeVisitMethod(method!);
            Assert.That(updatedMethod?.BodyStatements, Is.Not.Null);

            var result = updatedMethod!.BodyStatements!.ToDisplayString();
            Assert.Multiple(() =>
            {
                // Verify that the method body does NOT contain DiagnosticScope instrumentation
                Assert.That(result.Contains("DiagnosticScope"),
                    Is.False,
                    $"Paging method should not have DiagnosticScope instrumentation. Method: {(isAsync ? "AsyncPageable" : "Pageable")}, Kind: {methodKind}");
                Assert.That(result.Contains("scope.Start()"),
                    Is.False,
                    $"Paging method should not have scope.Start() call. Method: {(isAsync ? "AsyncPageable" : "Pageable")}, Kind: {methodKind}");
                Assert.That(result.Contains("scope.Failed"),
                    Is.False,
                    $"Paging method should not have scope.Failed() call. Method: {(isAsync ? "AsyncPageable" : "Pageable")}, Kind: {methodKind}");
            });
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

        private class TestDistributedTracingVisitor : DistributedTracingVisitor
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
