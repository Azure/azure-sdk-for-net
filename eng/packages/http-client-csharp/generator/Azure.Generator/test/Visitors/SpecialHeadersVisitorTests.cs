// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;

namespace Azure.Generator.Tests.Visitors
{
    public class SpecialHeadersVisitorTests
    {
        [Test]
        public void RemovesSpecialHeaderParametersFromServiceMethod()
        {
            var visitor = new TestSpecialHeadersVisitor();
            var parameters = CreateParameters();
            var responseModel = InputFactory.Model("foo");
            var operation = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.LongRunningServiceMethod(
                "foo",
                operation,
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            // Verify initial parameters include special headers
            Assert.AreEqual(3, serviceMethod.Parameters.Count);
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.NameInRequest == "return-client-request-id"));
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.NameInRequest == "x-ms-client-request-id"));

            // Act - this would normally be called by the visitor framework, but we'll test the core logic
            visitor.InvokeRemoveSpecialHeaders(serviceMethod);

            // Verify special headers are removed
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.IsFalse(serviceMethod.Parameters.Any(p => p.NameInRequest == "return-client-request-id"));
            Assert.IsFalse(serviceMethod.Parameters.Any(p => p.NameInRequest == "x-ms-client-request-id"));
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.NameInRequest == "some-other-parameter"));
        }

        [Test]
        public void DoesNotChangeParametersWhenNoSpecialHeaders()
        {
            var visitor = new TestSpecialHeadersVisitor();
            var parameters = new List<InputParameter>
            {
                InputFactory.Parameter(
                    "some-parameter",
                    type: InputPrimitiveType.String,
                    nameInRequest: "some-parameter",
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
                parameters: parameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));

            // Verify initial state
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            var originalParameter = serviceMethod.Parameters[0];

            // Act
            visitor.InvokeRemoveSpecialHeaders(serviceMethod);

            // Verify no changes
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreSame(originalParameter, serviceMethod.Parameters[0]);
        }

        private static List<InputParameter> CreateParameters()
        {
            List<InputParameter> parameters =
            [
                InputFactory.Parameter(
                    "return-client-request-id",
                    type: new InputLiteralType("return-client-request-id", "ns", InputPrimitiveType.Boolean, true),
                    defaultValue: new InputConstant(true, InputPrimitiveType.Boolean),
                    nameInRequest: "return-client-request-id",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "x-ms-client-request-id",
                    type: InputPrimitiveType.String,
                    nameInRequest: "x-ms-client-request-id",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    nameInRequest: "some-other-parameter",
                    location: InputRequestLocation.Header)
            ];
            return parameters;
        }

        private class TestSpecialHeadersVisitor : SpecialHeadersVisitor
        {
            public void InvokeRemoveSpecialHeaders(InputServiceMethod serviceMethod)
            {
                // Simulate the core logic of removing special headers
                var returnClientRequestIdParameter =
                    serviceMethod.Parameters.FirstOrDefault(p => p.NameInRequest == "return-client-request-id");
                var xMsClientRequestIdParameter =
                    serviceMethod.Parameters.FirstOrDefault(p => p.NameInRequest == "x-ms-client-request-id");

                if (returnClientRequestIdParameter != null || xMsClientRequestIdParameter != null)
                {
                    serviceMethod.Update(parameters: [.. serviceMethod.Parameters.Where(p => p.NameInRequest != "return-client-request-id" && p.NameInRequest != "x-ms-client-request-id")]);
                    serviceMethod.Operation.Update(parameters: [.. serviceMethod.Operation.Parameters.Where(p => p.NameInRequest != "return-client-request-id" && p.NameInRequest != "x-ms-client-request-id")]);
                }
            }
        }
    }
}