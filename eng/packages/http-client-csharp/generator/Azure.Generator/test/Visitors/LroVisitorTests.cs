// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class LroVisitorTests
    {
        [Test]
        public void UpdatesLroSignatureNoResponseBody()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod("foo", lro, parameters: parameters);
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.That(clientProvider, Is.Not.Null);

            foreach (var method in clientProvider!.Methods)
            {
                var updatedMethod = visitor.InvokeVisitMethod(method);
                Assert.That(updatedMethod, Is.Not.Null);
                var scmMethod = method as ScmMethodProvider;
                Assert.That(scmMethod, Is.Not.Null);
                var waitUntilParameter = scmMethod!.Signature.Parameters[0];
                Assert.That(waitUntilParameter.Type.Equals(typeof(WaitUntil)), Is.True);
                Assert.That(waitUntilParameter.Name, Is.EqualTo("waitUntil"));

                Assert.That(scmMethod.Signature.ReturnType!.Equals(typeof(Operation)) ||
                              scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Task<>), typeof(Operation))), Is.True);

                if (scmMethod.Kind == ScmMethodKind.Protocol)
                {
                    var requestContextParameter = scmMethod.Signature.Parameters[^1];
                    Assert.That(requestContextParameter.Type.Equals(typeof(RequestContext)), Is.True);
                    Assert.That(requestContextParameter.Name, Is.EqualTo("context"));
                }
                else
                {
                    var cancellationTokenParameter = scmMethod.Signature.Parameters[^1];
                    Assert.That(cancellationTokenParameter.Type.Equals(typeof(CancellationToken)), Is.True);
                    Assert.That(cancellationTokenParameter.Name, Is.EqualTo("cancellationToken"));
                }
            }
        }

        [Test]
        public void UpdatesLroSignatureWithResponseBody()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.That(clientProvider, Is.Not.Null);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.That(responseModelProvider, Is.Not.Null);

            foreach (var method in clientProvider!.Methods)
            {
                var updatedMethod = visitor.InvokeVisitMethod(method);
                Assert.That(updatedMethod, Is.Not.Null);
                var scmMethod = method as ScmMethodProvider;
                Assert.That(scmMethod, Is.Not.Null);
                var waitUntilParameter = scmMethod!.Signature.Parameters[0];
                Assert.That(waitUntilParameter.Type.Equals(typeof(WaitUntil)), Is.True);
                Assert.That(waitUntilParameter.Name, Is.EqualTo("waitUntil"));

                if (scmMethod.Kind == ScmMethodKind.Protocol)
                {
                    var requestContextParameter = scmMethod.Signature.Parameters[^1];
                    Assert.That(requestContextParameter.Type.Equals(typeof(RequestContext)), Is.True);
                    Assert.That(requestContextParameter.Name, Is.EqualTo("context"));
                }
                else
                {
                    var cancellationTokenParameter = scmMethod.Signature.Parameters[^1];
                    Assert.That(cancellationTokenParameter.Type.Equals(typeof(CancellationToken)), Is.True);
                    Assert.That(cancellationTokenParameter.Name, Is.EqualTo("cancellationToken"));
                    Assert.That(scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Operation<>), responseModelProvider!.Type)) ||
                                  scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Task<>), new CSharpType(typeof(Operation<>), responseModelProvider.Type))), Is.True);
                }
            }
        }

        [Test]
        public void AddsFromLroResponseMethodAndRemovesExplicitOperatorForLroOnlyModel()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: "someResultPath"));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.That(clientProvider, Is.Not.Null);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.That(responseModelProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];

            // Check that FromLroResponse method was added
            var fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");

            Assert.That(fromLroResponseMethod, Is.Not.Null);
            Assert.That(fromLroResponseMethod!.BodyStatements, Is.Not.Null);
            var result = fromLroResponseMethod!.BodyStatements!.ToDisplayString();
            Assert.That(result, Is.EqualTo(Helpers.GetExpectedFromFile()));

            // Check that explicit operator was removed since model is only used in LRO
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            Assert.That(explicitOperator, Is.Null);

            // does not add the method again on subsequent calls
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);
            serializationProvider = responseModelProvider!.SerializationProviders[0];
            fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");
            result = fromLroResponseMethod!.BodyStatements!.ToDisplayString();
            Assert.That(result, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void RetainsExplicitOperatorWhenModelUsedInNonLroContext()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");

            // Create an LRO method
            var lro = InputFactory.Operation(
                "lroOp",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "lroOp",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: "someResultPath"));

            // Create a non-LRO method that also returns the same model
            var nonLroOp = InputFactory.Operation(
                "nonLroOp",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var nonLroServiceMethod = InputFactory.BasicServiceMethod(
                "nonLroOp",
                nonLroOp,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));

            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod, nonLroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.That(clientProvider, Is.Not.Null);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.That(responseModelProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];

            // Check that FromLroResponse method was added
            var fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");
            Assert.That(fromLroResponseMethod, Is.Not.Null);

            // Check that explicit operator was RETAINED since model is also used in non-LRO context
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            Assert.That(explicitOperator, Is.Not.Null);
        }

        [Test]
        public void DoesNotAddFromLroResponseMethodWhenNoResultPath()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var responseModel = InputFactory.Model("foo");
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            // LRO service method without result path
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]),
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    finalState: 1,
                    finalResponse: InputFactory.OperationResponse(),
                    resultPath: null)); // No result path
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.That(clientProvider, Is.Not.Null);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.That(responseModelProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];

            // Check that FromLroResponse method was NOT added
            var fromLroResponseMethod = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Name == "FromLroResponse");
            Assert.That(fromLroResponseMethod, Is.Null);

            // Explicit operator should still be present
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            Assert.That(explicitOperator, Is.Not.Null);
        }

        [Test]
        public void UpdatesConvenienceMethodBody()
        {
            var visitor = new TestLroVisitor();
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;
            visitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.That(clientProvider, Is.Not.Null);
            var convenienceMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Parameters.All(p => p.Name != "context"));

            Assert.That(convenienceMethod, Is.Not.Null);
            var actual = convenienceMethod!.BodyStatements!.ToDisplayString();
            Assert.That(actual, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void UpdatesProtocolMethodBody()
        {
            var visitor = new TestLroVisitor();
            List<InputParameter> parameters =
            [
                InputFactory.BodyParameter("p1", InputPrimitiveType.String)
            ];
            List<InputMethodParameter> methodParameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var lro = InputFactory.Operation(
                "foo",
                parameters: parameters);
            var responseModel = InputFactory.Model("foo");
            var lroServiceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                lro, parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [lroServiceMethod]);
            var plugin = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var outputLibrary = plugin.Object.OutputLibrary;
            visitor.InvokeVisitLibrary(outputLibrary);

            var clientProvider = outputLibrary.TypeProviders.OfType<ClientProvider>().FirstOrDefault();
            Assert.That(clientProvider, Is.Not.Null);
            var protocolMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Parameters.Any(p => p.Name == "context"));

            Assert.That(protocolMethod, Is.Not.Null);
            var actual = protocolMethod!.BodyStatements!.ToDisplayString();
            Assert.That(actual, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        private class TestLroVisitor : LroVisitor
        {
            public MethodProvider? InvokeVisitMethod(MethodProvider method)
            {
                return base.VisitMethod(method);
            }

            public ScmMethodProviderCollection? InvokeVisitServiceMethod(
                InputServiceMethod serviceMethod,
                ClientProvider client,
                ScmMethodProviderCollection? methodCollection)
            {
                return base.Visit(serviceMethod, client, methodCollection);
            }

            public void InvokeVisitLibrary(OutputLibrary library)
            {
                base.VisitLibrary(library);
            }
        }
    }
}