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
    public class MatchConditionsVisitorTests
    {
        [Test]
        public void RemovesMatchConditionHeaderParametersFromServiceMethods()
        {
            var visitor = new TestMatchConditionsVisitor();
            var parameters = CreateMatchConditionParameters();
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

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            
            // Verify the parameters before visitor transformation
            Assert.AreEqual(4, serviceMethod.Parameters.Count);
            
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            // Verify that individual match condition headers are removed from serviceMethod.Parameters
            Assert.AreEqual(0, serviceMethod.Parameters.Count);
        }

        [Test]
        public void DoesNotChangeNonMatchConditionParameters()
        {
            var visitor = new TestMatchConditionsVisitor();
            var parameters = CreateMixedParameters();
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

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var responseModelProvider = AzureClientGenerator.Instance.TypeFactory.CreateModel(responseModel);
            Assert.IsNotNull(responseModelProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);
            
            // Should have 2 parameters initially
            Assert.AreEqual(2, serviceMethod.Parameters.Count);
            
            methodCollection = visitor.InvokeVisitServiceMethod(serviceMethod, clientProvider!, methodCollection);

            // Should have 1 parameter (the non-match condition one) after transformation
            Assert.AreEqual(1, serviceMethod.Parameters.Count);
            Assert.AreEqual("some-other-parameter", serviceMethod.Parameters[0].NameInRequest);
        }

        private static List<InputParameter> CreateMatchConditionParameters()
        {
            List<InputParameter> parameters =
            [
                InputFactory.Parameter(
                    "ifMatch",
                    type: InputPrimitiveType.String,
                    nameInRequest: "If-Match",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "ifNoneMatch",
                    type: InputPrimitiveType.String,
                    nameInRequest: "If-None-Match",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "ifModifiedSince",
                    type: InputPrimitiveType.DateTimeRFC7231,
                    nameInRequest: "If-Modified-Since",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "ifUnmodifiedSince",
                    type: InputPrimitiveType.DateTimeRFC7231,
                    nameInRequest: "If-Unmodified-Since",
                    location: InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static List<InputParameter> CreateMixedParameters()
        {
            List<InputParameter> parameters =
            [
                InputFactory.Parameter(
                    "ifMatch",
                    type: InputPrimitiveType.String,
                    nameInRequest: "If-Match",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "some-other-parameter",
                    type: InputPrimitiveType.String,
                    nameInRequest: "some-other-parameter",
                    location: InputRequestLocation.Header)
            ];
            return parameters;
        }

        private class TestMatchConditionsVisitor : MatchConditionsVisitor
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