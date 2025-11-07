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
        [TestCase(true, true, true, true)] // All special headers
        [TestCase(true, true, true, false)] // client-request-id, return-client-request-id, x-ms-client-request-id
        [TestCase(true, true, false, true)] // client-request-id, return-client-request-id
        [TestCase(true, false, true, true)] // client-request-id, x-ms-client-request-id
        [TestCase(false, true, true, true)] // return-client-request-id, x-ms-client-request-id
        [TestCase(true, false, false, true)] // client-request-id only
        [TestCase(false, true, false, true)] // return-client-request-id only
        [TestCase(false, false, true, true)] // x-ms-client-request-id only
        [TestCase(false, false, false, true)] // No special headers (regular parameter only)
        public void RemovesSpecialHeaderParametersFromServiceMethod(
            bool includeClientRequestId,
            bool includeReturnClientRequestId,
            bool includeXMsClientRequestId,
            bool addBackXMsClientRequestId)
        {
            var visitor = new TestClientRequestIdHeaderVisitor(addBackXMsClientRequestId);
            var parameters = CreateHttpParameters(includeClientRequestId, includeReturnClientRequestId, includeXMsClientRequestId);
            var methodParameters = CreateMethodParameters(includeClientRequestId, includeReturnClientRequestId, includeXMsClientRequestId);
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
            int expectedInitialCount = 1; // always has some-other-parameter
            if (includeClientRequestId) expectedInitialCount++;
            if (includeReturnClientRequestId) expectedInitialCount++;
            if (includeXMsClientRequestId) expectedInitialCount++;

            foreach (var serviceMethod in serviceMethods)
            {
                Assert.AreEqual(expectedInitialCount, serviceMethod.Parameters.Count);
                Assert.AreEqual(includeReturnClientRequestId, serviceMethod.Parameters.Any(p => p.SerializedName == "return-client-request-id"));
                Assert.AreEqual(includeXMsClientRequestId, serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));
            }

            var generator = MockHelpers.LoadMockGenerator(
                clients: () => [inputClient],
                visitors: () => [visitor]);
            var client = generator.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();

            // Verify special headers are removed from both methods
            foreach (var serviceMethod in serviceMethods)
            {
                var methodCollection = client.GetMethodCollectionByOperation(serviceMethod.Operation);
                visitor.InvokePreVisit(serviceMethod, client, methodCollection);
            }

            foreach (var serviceMethod in serviceMethods)
            {
                var restClientMethod = client.RestClient.Methods.First(m => m.Signature.Name == $"Create{serviceMethod.Name}Request");

                visitor.InvokeVisit((restClientMethod as ScmMethodProvider)!);
                Assert.AreEqual(1, serviceMethod.Parameters.Count);
                Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "return-client-request-id"));
                Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));
                Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "some-other-parameter"));

                // Verify x-ms-client-request-id is added back in method body if specified and was present
                bool shouldAddBack = addBackXMsClientRequestId && includeXMsClientRequestId;
                Assert.AreEqual(shouldAddBack, restClientMethod.BodyStatements!.ToDisplayString().Contains("request.Headers.SetValue(\"x-ms-client-request-id\", request.ClientRequestId);"));
            }
        }

        [Test]
        public void DoesNotChangeParametersWhenNoSpecialHeaders()
        {
            var visitor = new TestClientRequestIdHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                InputFactory.HeaderParameter(
                    "some-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-parameter")
            };
            var methodParameters = new List<InputMethodParameter>
            {
                InputFactory.MethodParameter(
                    "some-parameter",
                    type: InputPrimitiveType.String,
                    serializedName: "some-parameter",
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
            var generator = MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var client = generator.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var methodCollection = client.GetMethodCollectionByOperation(operation);

            // Verify initial state
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            var originalParameter = serviceMethod.Parameters[0];

            // Act
            visitor.InvokePreVisit(serviceMethod, client, methodCollection);

            // Verify no changes
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreSame(originalParameter, serviceMethod.Parameters[0]);
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
            visitor.InvokePreVisit(serviceMethod, clientProvider!, methodCollection);

            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreSame(serviceMethodParameters.Last(), serviceMethod.Parameters[0]);

            Assert.AreEqual(1, serviceMethod.Operation.Parameters.Count);
            Assert.AreSame(operationParameters.Last(), serviceMethod.Operation.Parameters[0]);

            Assert.AreNotSame(serviceMethodParameters[0], serviceMethod.Parameters[0]);
        }

        private static List<InputMethodParameter> CreateMethodParameters(
            bool includeClientRequestId = true,
            bool includeReturnClientRequestId = true,
            bool includeXMsClientRequestId = true)
        {
            List<InputMethodParameter> parameters = [];

            if (includeClientRequestId)
            {
                parameters.Add(InputFactory.MethodParameter(
                    "client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "client-request-id",
                    location: InputRequestLocation.Header));
            }

            if (includeReturnClientRequestId)
            {
                parameters.Add(InputFactory.MethodParameter(
                    "return-client-request-id",
                    type: InputPrimitiveType.Boolean,
                    serializedName: "return-client-request-id"));
            }

            if (includeXMsClientRequestId)
            {
                parameters.Add(InputFactory.MethodParameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "x-ms-client-request-id"));
            }

            parameters.Add(InputFactory.MethodParameter(
                "some-other-parameter",
                type: InputPrimitiveType.String,
                serializedName: "some-other-parameter",
                location: InputRequestLocation.Header));

            return parameters;
        }

        private static List<InputParameter> CreateHttpParameters(
            bool includeClientRequestId = true,
            bool includeReturnClientRequestId = true,
            bool includeXMsClientRequestId = true)
        {
            List<InputParameter> parameters = [];

            if (includeClientRequestId)
            {
                parameters.Add(InputFactory.HeaderParameter(
                    "client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "client-request-id"));
            }

            if (includeReturnClientRequestId)
            {
                parameters.Add(InputFactory.HeaderParameter(
                    "return-client-request-id",
                    type: InputPrimitiveType.Boolean,
                    serializedName: "return-client-request-id"));
            }

            if (includeXMsClientRequestId)
            {
                parameters.Add(InputFactory.HeaderParameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    serializedName: "x-ms-client-request-id"));
            }

            parameters.Add(InputFactory.HeaderParameter(
                "some-other-parameter",
                type: InputPrimitiveType.String,
                serializedName: "some-other-parameter"));

            return parameters;
        }

        private class TestClientRequestIdHeaderVisitor : ClientRequestIdHeaderVisitor
        {
            public TestClientRequestIdHeaderVisitor(bool addBackXMsClientRequestId = false)
                : base(addBackXMsClientRequestId)
            {
            }
            public void InvokePreVisit(InputServiceMethod serviceMethod, ClientProvider client, ScmMethodProviderCollection methods)
            {
                base.Visit(serviceMethod, client, methods);
            }

            public void InvokeVisit(ScmMethodProvider method)
            {
                base.VisitMethod(method);
            }
        }
    }
}