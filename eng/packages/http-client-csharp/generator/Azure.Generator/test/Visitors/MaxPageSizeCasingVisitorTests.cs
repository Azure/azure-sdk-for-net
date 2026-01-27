// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class MaxPageSizeCasingVisitorTests
    {
        [Test]
        public void TestUpdatesMaxPageSizeParameterCasing()
        {
            var visitor = new TestMaxPageSizeCasingVisitor();
            var methodParameters = new[]
            {
                InputFactory.MethodParameter("maxpagesize", InputPrimitiveType.Int32, location: InputRequestLocation.Query),
                InputFactory.MethodParameter("otherParam", InputPrimitiveType.String, location: InputRequestLocation.Query)
            };

            var parameters = new[]
            {
                InputFactory.QueryParameter("maxpagesize", InputPrimitiveType.Int32),
                InputFactory.QueryParameter("otherParam", InputPrimitiveType.String)
            };

            var responseModel = InputFactory.Model("TestResponse");
            var operation = InputFactory.Operation(
                "testOperation",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "TestMethod",
                operation,
                parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
            }

            foreach (var method in methodCollection)
            {
                var maxPageSizeParam = method.Signature.Parameters.FirstOrDefault(p => p.Name == "maxPageSize");
                var incorrectParam = method.Signature.Parameters.FirstOrDefault(p => p.Name == "maxpagesize");

                Assert.IsNotNull(maxPageSizeParam, "Method should have a parameter named 'maxPageSize'");
                Assert.IsNull(incorrectParam, "Method should not have a parameter named 'maxpagesize'");

                var otherParam = method.Signature.Parameters.FirstOrDefault(p => p.Name == "otherParam");
                Assert.IsNotNull(otherParam, "Method should still have the 'otherParam' parameter");
            }
        }

        [Test]
        public void TestDoesNotUpdateParametersWithCorrectCasing()
        {
            var visitor = new TestMaxPageSizeCasingVisitor();
            var methodParameters = new[]
            {
                InputFactory.MethodParameter("maxPageSize", InputPrimitiveType.Int32, location: InputRequestLocation.Query),
                InputFactory.MethodParameter("normalParam", InputPrimitiveType.String, location: InputRequestLocation.Query)
            };

            var parameters = new[]
            {
                InputFactory.QueryParameter("maxPageSize", InputPrimitiveType.Int32),
                InputFactory.QueryParameter("normalParam", InputPrimitiveType.String)
            };

            var responseModel = InputFactory.Model("TestResponse");
            var operation = InputFactory.Operation(
                "testOperation",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "TestMethod",
                operation,
                parameters: methodParameters,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
            }

            foreach (var method in methodCollection)
            {
                var maxPageSizeParam = method.Signature.Parameters.FirstOrDefault(p => p.Name == "maxPageSize");
                var normalParam = method.Signature.Parameters.FirstOrDefault(p => p.Name == "normalParam");

                Assert.IsNotNull(maxPageSizeParam, "Method should have a parameter named 'maxPageSize'");
                Assert.IsNotNull(normalParam, "Method should have a parameter named 'normalParam'");

                var incorrectParam = method.Signature.Parameters.FirstOrDefault(p => p.Name == "maxpagesize");
                Assert.IsNull(incorrectParam, "Method should not have a parameter named 'maxpagesize'");
            }
        }

        private class TestMaxPageSizeCasingVisitor : MaxPageSizeCasingVisitor
        {
            public ScmMethodProvider? VisitScmMethod(ScmMethodProvider method)
            {
                return base.VisitMethod(method);
            }
        }
    }
}