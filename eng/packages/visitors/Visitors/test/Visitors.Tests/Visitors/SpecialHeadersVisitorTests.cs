// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using Visitors.Tests.Common;
using Visitors.Tests.TestHelpers;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using Microsoft.TypeSpec.Generator.Snippets;

namespace Visitors.Tests
{
    public class SpecialHeadersVisitorTests
    {
        [Test]
        public void RemovesSpecialHeaderParametersFromServiceMethods()
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

            var clientProvider = (CodeModelGenerator.Instance as ScmCodeModelGenerator)!.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = (CodeModelGenerator.Instance as ScmCodeModelGenerator)!.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection!)
            {
                Assert.IsFalse(method.Signature.Parameters.Any(p => p.Name == "return-client-request-id"));
                Assert.IsFalse(method.Signature.Parameters.Any(p => p.Name == "x-ms-client-request-id"));
            }

            // find the CreateRequest method
            var createRequestMethod = clientProvider!.RestClient.GetCreateRequestMethod(serviceMethod.Operation);
            // validate setting headers in the CreateRequest method
            Assert.IsNotNull(createRequestMethod);
            var methodBody = createRequestMethod.BodyStatements?.ToDisplayString();
            Assert.IsNotNull(methodBody);

            Assert.IsTrue(methodBody!.Contains("request.Headers.Set(\"return-client-request-id\", \"true\""));
            Assert.IsTrue(methodBody.Contains("request.Headers.Set(\"some-other-parameter\", someOtherParameter"));

        }

        [Test]
        public void DoesNotChangeExistingParameters()
        {
            var visitor = new TestSpecialHeadersVisitor();
            var operationParameters = CreateParameters();
            var serviceMethodParameters = CreateParameters();
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

            var clientProvider = (CodeModelGenerator.Instance as ScmCodeModelGenerator)!.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = (CodeModelGenerator.Instance as ScmCodeModelGenerator)!.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreSame(serviceMethodParameters.Last(), serviceMethod.Parameters[0]);

            Assert.AreEqual(1, serviceMethod.Operation.Parameters.Count);
            Assert.AreSame(operationParameters.Last(), serviceMethod.Operation.Parameters[0]);

            Assert.AreNotSame(serviceMethodParameters[0], serviceMethod.Parameters[0]);
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
            public ScmMethodProviderCollection? InvokeVisitServiceMethod(
                InputServiceMethod serviceMethod,
                ClientProvider client,
                ScmMethodProviderCollection? methodCollection)
            {
                return base.Visit(serviceMethod, client, methodCollection);
            }
        }
    }
}