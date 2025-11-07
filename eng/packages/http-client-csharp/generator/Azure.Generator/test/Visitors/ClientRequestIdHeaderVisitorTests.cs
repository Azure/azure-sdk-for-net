// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class ClientRequestIdHeaderVisitorTests
    {
        [Test]
        public void RemovesTheRequestClientIdHeaderParameterFromServiceMethods()
        {
            var visitor = new TestClientRequestIdHeaderVisitor();
            var parameters = CreateHttpParameters();
            var methodParameters = CreateMethodParameters();
            var responseModel = InputFactory.Model("foo");
            var operation = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                operation,
                parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection!)
            {
                Assert.IsFalse(method.Signature.Parameters.Any(p => p.Name == "client-request-id"));
            }

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void DoesNotChangeExistingParameters()
        {
            var visitor = new TestClientRequestIdHeaderVisitor();
            var operationParameters = CreateHttpParameters();
            var serviceMethodParameters = CreateMethodParameters();
            var responseModel = InputFactory.Model("foo");
            var operation = InputFactory.Operation(
                "foo",
                parameters: operationParameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                operation,
                parameters: serviceMethodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreSame(serviceMethodParameters.Last(), serviceMethod.Parameters[0]);

            Assert.AreEqual(1, serviceMethod.Operation.Parameters.Count);
            Assert.AreSame(operationParameters.Last(), serviceMethod.Operation.Parameters[0]);

            Assert.AreNotSame(serviceMethodParameters[0], serviceMethod.Parameters[0]);
        }

        private static List<InputMethodParameter> CreateMethodParameters()
        {
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                    "client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "client-request-id",
                    location: InputRequestLocation.Header),
                InputFactory.MethodParameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-other-parameter",
                    location: InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static List<InputParameter> CreateHttpParameters()
        {
            List<InputParameter> parameters =
            [
                InputFactory.HeaderParameter(
                    "client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "client-request-id"),
                InputFactory.HeaderParameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-other-parameter")
            ];
            return parameters;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void RemovesXMsClientRequestIdHeaderParameterFromServiceMethods(bool includeInRequest)
        {
            var visitor = new TestClientRequestIdHeaderVisitor(includeInRequest);
            var parameters = new List<InputParameter>
            {
                InputFactory.HeaderParameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "x-ms-client-request-id"),
                InputFactory.HeaderParameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-other-parameter")
            };
            var methodParameters = new List<InputMethodParameter>
            {
                InputFactory.MethodParameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "x-ms-client-request-id",
                    location: InputRequestLocation.Header),
                InputFactory.MethodParameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-other-parameter",
                    location: InputRequestLocation.Header)
            };
            var responseModel = InputFactory.Model("foo");
            var operation = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                operation,
                parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            // Verify parameter was removed from service method
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "some-other-parameter"));

            // Verify header is added to request body based on includeInRequest flag
            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();
            var hasHeaderSet = file.Content.Contains("request.Headers.SetValue(\"x-ms-client-request-id\", request.ClientRequestId);");
            Assert.AreEqual(includeInRequest, hasHeaderSet);
        }

        [Test]
        public void RemovesReturnClientRequestIdParameterFromServiceMethod()
        {
            var visitor = new TestClientRequestIdHeaderVisitor();
            var parameters = CreateHttpParametersWithReturnClientRequestId();
            var methodParameters = CreateMethodParametersWithReturnClientRequestId();
            var responseModel = InputFactory.Model("foo");
            var serviceMethods = new List<InputServiceMethod>();

            // Create two operations and service methods
            for (int i = 1; i <= 2; i++)
            {
                var operation = InputFactory.Operation(
                    $"operation{i}",
                    parameters: parameters,
                    responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
                var serviceMethod = InputFactory.LongRunningServiceMethod(
                    $"operation{i}",
                    operation,
                    parameters: methodParameters,
                    response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
                serviceMethods.Add(serviceMethod);
            }

            var inputClient = InputFactory.Client("TestClient", methods: serviceMethods);

            // Verify initial parameters include special headers for both methods
            foreach (var serviceMethod in serviceMethods)
            {
                Assert.AreEqual(3, serviceMethod.Parameters.Count);
                Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "return-client-request-id"));
                Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));
            }

            var generator = MockHelpers.LoadMockGenerator(
                clients: () => [inputClient],
                visitors: () => [visitor]);
            var client = generator.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();

            // Verify return-client-request-id header is removed from both methods
            foreach (var serviceMethod in serviceMethods)
            {
                var methodCollection = client.GetMethodCollectionByOperation(serviceMethod.Operation);
                visitor.InvokeVisitServiceMethod(serviceMethod, client, methodCollection);
            }

            foreach (var serviceMethod in serviceMethods)
            {
                var restClientMethod = client.RestClient.Methods.First(m => m.Signature.Name == $"Create{serviceMethod.Name}Request");

                visitor.InvokeVisit((restClientMethod as ScmMethodProvider)!);
                // Should have 1 parameter now: some-other-parameter
                Assert.AreEqual(1, serviceMethod.Parameters.Count);
                Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "return-client-request-id"));
                Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));
                Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "some-other-parameter"));

                // Verify return-client-request-id is set in the method body
                Assert.IsTrue(restClientMethod.BodyStatements!.ToDisplayString().Contains("request.Headers.SetValue(\"return-client-request-id\", \"true\");"));
            }
        }

        private static List<InputMethodParameter> CreateMethodParametersWithReturnClientRequestId()
        {
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter(
                    "return-client-request-id",
                    type: new InputLiteralType("return-client-request-id", "ns", InputPrimitiveType.Boolean, true),
                    defaultValue: new InputConstant(true, InputPrimitiveType.Boolean),
                    serializedName: "return-client-request-id",
                    location: InputRequestLocation.Header),
                InputFactory.MethodParameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "x-ms-client-request-id",
                    location: InputRequestLocation.Header),
                InputFactory.MethodParameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-other-parameter",
                    location: InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static List<InputParameter> CreateHttpParametersWithReturnClientRequestId()
        {
            List<InputParameter> parameters =
            [
                InputFactory.HeaderParameter(
                    "return-client-request-id",
                    type: new InputLiteralType("return-client-request-id", "ns", InputPrimitiveType.Boolean, true),
                    defaultValue: new InputConstant(true, InputPrimitiveType.Boolean),
                    serializedName: "return-client-request-id"),
                InputFactory.HeaderParameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "x-ms-client-request-id"),
                InputFactory.HeaderParameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-other-parameter")
            ];
            return parameters;
        }

        private class TestClientRequestIdHeaderVisitor : ClientRequestIdHeaderVisitor
        {
            public TestClientRequestIdHeaderVisitor(bool includeXmsClientRequestIdInRequest = false)
                : base(includeXmsClientRequestIdInRequest)
            {
            }

            public ScmMethodProviderCollection? InvokeVisitServiceMethod(
                InputServiceMethod serviceMethod,
                ClientProvider client,
                ScmMethodProviderCollection? methodCollection)
            {
                return base.Visit(serviceMethod, client, methodCollection);
            }

            public void InvokeVisit(ScmMethodProvider method)
            {
                base.VisitMethod(method);
            }
        }
    }
}