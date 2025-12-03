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
            Assert.IsNotNull(clientProvider);

            foreach (var method in clientProvider!.Methods)
            {
                var updatedMethod = visitor.InvokeVisitMethod(method);
                Assert.IsNotNull(updatedMethod);
                var scmMethod = method as ScmMethodProvider;
                Assert.IsNotNull(scmMethod);
                var waitUntilParameter = scmMethod!.Signature.Parameters[0];
                Assert.IsTrue(waitUntilParameter.Type.Equals(typeof(WaitUntil)));
                Assert.AreEqual("waitUntil", waitUntilParameter.Name);

                Assert.IsTrue(scmMethod.Signature.ReturnType!.Equals(typeof(Operation)) ||
                              scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Task<>), typeof(Operation))));

                if (scmMethod.IsProtocolMethod)
                {
                    var requestContextParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(requestContextParameter.Type.Equals(typeof(RequestContext)));
                    Assert.AreEqual("context", requestContextParameter.Name);
                }
                else
                {
                    var cancellationTokenParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(cancellationTokenParameter.Type.Equals(typeof(CancellationToken)));
                    Assert.AreEqual("cancellationToken", cancellationTokenParameter.Name);
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
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            foreach (var method in clientProvider!.Methods)
            {
                var updatedMethod = visitor.InvokeVisitMethod(method);
                Assert.IsNotNull(updatedMethod);
                var scmMethod = method as ScmMethodProvider;
                Assert.IsNotNull(scmMethod);
                var waitUntilParameter = scmMethod!.Signature.Parameters[0];
                Assert.IsTrue(waitUntilParameter.Type.Equals(typeof(WaitUntil)));
                Assert.AreEqual("waitUntil", waitUntilParameter.Name);

                if (scmMethod.IsProtocolMethod)
                {
                    var requestContextParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(requestContextParameter.Type.Equals(typeof(RequestContext)));
                    Assert.AreEqual("context", requestContextParameter.Name);
                }
                else
                {
                    var cancellationTokenParameter = scmMethod.Signature.Parameters[^1];
                    Assert.IsTrue(cancellationTokenParameter.Type.Equals(typeof(CancellationToken)));
                    Assert.AreEqual("cancellationToken", cancellationTokenParameter.Name);
                    Assert.IsTrue(scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Operation<>), responseModelProvider!.Type)) ||
                                  scmMethod.Signature.ReturnType!.Equals(new CSharpType(typeof(Task<>), new CSharpType(typeof(Operation<>), responseModelProvider.Type))));
                }
            }
        }

        [Test]
        public void UpdatesExplicitOperatorToUseResultSegment()
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
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(lroServiceMethod, clientProvider!);
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);

            var serializationProvider = responseModelProvider!.SerializationProviders[0];
            var explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));

            Assert.IsNotNull(explicitOperator);
            Assert.IsNotNull(explicitOperator!.BodyStatements);
            var result = explicitOperator!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), result);

            // does not mutate an already mutated operator
            visitor.InvokeVisitServiceMethod(lroServiceMethod, clientProvider!, methodCollection);
            serializationProvider = responseModelProvider!.SerializationProviders[0];
            explicitOperator = serializationProvider.Methods
                .FirstOrDefault(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit) &&
                                     m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator));
            result = explicitOperator!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), result);
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
            Assert.IsNotNull(clientProvider);
            var convenienceMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Parameters.All(p => p.Name != "context"));

            Assert.IsNotNull(convenienceMethod);
            var actual = convenienceMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
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
            Assert.IsNotNull(clientProvider);
            var protocolMethod = clientProvider!.Methods
                .FirstOrDefault(m => m.Signature.Parameters.Any(p => p.Name == "context"));

            Assert.IsNotNull(protocolMethod);
            var actual = protocolMethod!.BodyStatements!.ToDisplayString();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), actual);
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