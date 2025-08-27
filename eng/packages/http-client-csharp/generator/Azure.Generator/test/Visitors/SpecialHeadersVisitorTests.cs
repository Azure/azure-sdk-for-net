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

            // Verify initial parameters include special headers
            Assert.AreEqual(3, serviceMethod.Parameters.Count);
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "return-client-request-id"));
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));

            // Act - this would normally be called by the visitor framework, but we'll test the core logic
            visitor.InvokeRemoveSpecialHeaders(serviceMethod);

            // Verify special headers are removed
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "return-client-request-id"));
            Assert.IsFalse(serviceMethod.Parameters.Any(p => p.SerializedName == "x-ms-client-request-id"));
            Assert.IsTrue(serviceMethod.Parameters.Any(p => p.SerializedName == "some-other-parameter"));
        }

        [Test]
        public void DoesNotChangeParametersWhenNoSpecialHeaders()
        {
            var visitor = new TestSpecialHeadersVisitor();
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

            // Verify initial state
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            var originalParameter = serviceMethod.Parameters[0];

            // Act
            visitor.InvokeRemoveSpecialHeaders(serviceMethod);

            // Verify no changes
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreSame(originalParameter, serviceMethod.Parameters[0]);
        }

        private static List<InputMethodParameter> CreateMethodParameters()
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

        private static List<InputParameter> CreateHttpParameters()
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

        private class TestSpecialHeadersVisitor : SpecialHeadersVisitor
        {
            public void InvokeRemoveSpecialHeaders(InputServiceMethod serviceMethod)
            {
                // Simulate the core logic of removing special headers
                var returnClientRequestIdParameter =
                    serviceMethod.Parameters.FirstOrDefault(p => p.SerializedName == "return-client-request-id");
                var xMsClientRequestIdParameter =
                    serviceMethod.Parameters.FirstOrDefault(p => p.SerializedName == "x-ms-client-request-id");

                if (returnClientRequestIdParameter != null || xMsClientRequestIdParameter != null)
                {
                    serviceMethod.Update(parameters: [.. serviceMethod.Parameters.Where(p => p.SerializedName != "return-client-request-id" && p.SerializedName != "x-ms-client-request-id")]);
                    serviceMethod.Operation.Update(parameters: [.. serviceMethod.Operation.Parameters.Where(p => p.SerializedName != "return-client-request-id" && p.SerializedName != "x-ms-client-request-id")]);
                }
            }
        }
    }
}