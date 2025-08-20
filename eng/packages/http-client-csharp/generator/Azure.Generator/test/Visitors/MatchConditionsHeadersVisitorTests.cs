// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class MatchConditionsHeadersVisitorTests
    {
        private static readonly CSharpType ETagType = new CSharpType(typeof(ETag)).WithNullable(true);
        private static readonly CSharpType MatchConditionsType = new CSharpType(typeof(MatchConditions)).WithNullable(true);
        private static readonly CSharpType RequestConditionsType = new CSharpType(typeof(RequestConditions)).WithNullable(true);

        [Test]
        public void TestUpdatesParametersInMethods_AllMatchConditionHeaderParameters()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var methodParameters = CreateAllMatchConditionMethodParameters();
            var parameters = CreateAllMatchConditionHttpParameters();
            var responseModel = InputFactory.Model("foo");
            var operation = InputFactory.Operation(
                "foo",
                parameters: parameters,
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);
            var serviceMethod = InputFactory.BasicServiceMethod(
                "foo",
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
                // Verify that the RequestConditions parameter is added to all the client methods
                Assert.AreEqual(2, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters[0].Name == "requestConditions");
            }
        }

        [Test]
        public void TestValidateCreateRequestMethod_AllMatchConditionHeaderParameters()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var methodParameters = CreateAllMatchConditionMethodParameters();
            var parameters = CreateAllMatchConditionHttpParameters();
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

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.IsTrue(methods.Count > 0, "RestClient should have methods defined.");

            // visit the method
            _ = visitor.VisitScmMethod(methods[0]);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [TestCase("ifMatch")]
        [TestCase("If-Match")]
        [TestCase("ifNoneMatch")]
        [TestCase("If-None-Match")]
        public void TestSingleIfMatchParameterTransformedCorrectly(string conditionName)
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter(conditionName.ToVariableName(), conditionName, InputRequestLocation.Header)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter(conditionName.ToVariableName(), conditionName, InputRequestLocation.Header)
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

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
                // Verify that the RequestConditions parameter is added to all the client methods
                Assert.AreEqual(2, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters[0].Name == conditionName.ToVariableName());
                Assert.IsTrue(method.Signature.Parameters[0].Type.Equals(ETagType));
            }
        }

        [TestCase("ifMatch")]
        [TestCase("If-Match")]
        [TestCase("ifNoneMatch")]
        [TestCase("If-None-Match")]
        public void TestValidateCreateRequestMethod_SingleIfMatchParameter(string conditionName)
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter(conditionName.ToVariableName(), conditionName, InputRequestLocation.Header)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter(conditionName.ToVariableName(), conditionName, InputRequestLocation.Header)
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

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.IsTrue(methods.Count > 0, "RestClient should have methods defined.");

            // visit the method
            _ = visitor.VisitScmMethod(methods[0]);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.AreEqual(Helpers.GetExpectedFromFile(conditionName), file.Content);
        }

        [Test]
        public void TestValidateCreateRequestMethod_RequestConditionParameter()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestParameter("contentType", "Content-Type", InputRequestLocation.Header),
                CreateTestParameter("foo", "foo", InputRequestLocation.Body)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestMethodParameter("contentType", "Content-Type", InputRequestLocation.Header),
                CreateTestMethodParameter("foo", "foo", InputRequestLocation.Body)
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

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.IsTrue(methods.Count > 0, "RestClient should have methods defined.");

            // visit the method
            _ = visitor.VisitScmMethod(methods[0]);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void TestProtocolMethodValidation()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
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

            MethodProvider? protocolMethod = null;
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
                if (method.IsProtocolMethod && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    protocolMethod = method;
                }
            }

            Assert.IsNotNull(protocolMethod, "Protocol method should be found.");
            Assert.IsNotNull(protocolMethod?.BodyStatements);

            var bodyText = protocolMethod!.BodyStatements!.ToDisplayString();

            Assert.IsTrue(bodyText.Contains("throw new global::System.ArgumentException(\"Service does not support the If-Match header for this operation"));
            Assert.IsTrue(bodyText.Contains("throw new global::System.ArgumentException(\"Service does not support the If-Unmodified-Since header for this operation"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestProtocolMethodParameterOptionality(bool isRequired)
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header, isRequired),
                CreateTestParameter("foo", "foo", InputRequestLocation.Body, isRequired),
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header, isRequired),
                CreateTestMethodParameter("foo", "foo", InputRequestLocation.Body, isRequired)
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

            MethodProvider? protocolMethod = null;
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
                if (method.IsProtocolMethod && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    protocolMethod = method;
                }
            }

            Assert.IsNotNull(protocolMethod, "Protocol method should be found.");
            Assert.AreEqual(3, protocolMethod!.Signature.Parameters.Count, "Protocol method should have two parameters.");

            var etagParameter = protocolMethod.Signature.Parameters.FirstOrDefault(p => p.Name == "ifNoneMatch");
            Assert.IsNotNull(etagParameter, "If-None-Match parameter should be present.");
            var contextParameter = protocolMethod.Signature.Parameters.FirstOrDefault(p => p.Name == "context");
            Assert.IsNotNull(contextParameter, "Context parameter should be present.");

            Assert.AreEqual(isRequired, etagParameter!.DefaultValue == null);
        }

        [Test]
        public void TestDoesNotChangeNonMatchConditionParameters()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = CreateMixedHttpParameters();
            var methodParameters = CreateMixedMethodParameters();
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

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
                // Verify that the RequestConditions parameter is added to all the client methods
                Assert.AreEqual(3, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters[0].Type.Equals(ETagType));
                Assert.IsFalse(method.Signature.Parameters[1].Type.Equals(ETagType));
            }
        }

        [Test]
        public void TestIgnoresMethodsWithoutMatchConditionHeaders()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("authorization", "Authorization", InputRequestLocation.Header),
                CreateTestParameter("contentType", "Content-Type", InputRequestLocation.Header)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("authorization", "Authorization", InputRequestLocation.Header),
                CreateTestMethodParameter("contentType", "Content-Type", InputRequestLocation.Header)
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

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);
                // Verify that the parameters are unchanged
                Assert.AreEqual(3, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters.Any(p => p.Name == "authorization"));
                Assert.IsTrue(method.Signature.Parameters.Any(p => p.Name == "contentType"));
                Assert.IsFalse(method.Signature.Parameters.Any(p => p.Name == "requestConditions"));
                Assert.IsFalse(method.Signature.Parameters.Any(p => p.Name == "matchConditions"));
                Assert.IsFalse(method.Signature.Parameters.Any(p => p.Type.Equals(ETagType)));
            }
        }

        [Test]
        public void TestHandlesMultipleMatchConditionHeaders()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header)
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

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);

                // Verify that the MatchConditions parameter is added
                Assert.AreEqual(2, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters[0].Name == "matchConditions");
                Assert.IsTrue(method.Signature.Parameters[0].Type.Equals(MatchConditionsType));
            }
        }

        [Test]
        public void TestHandlesDateBasedConditionHeaders()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestParameter("ifUnmodifiedSince", "If-Unmodified-Since", InputRequestLocation.Header)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestMethodParameter("ifUnmodifiedSince", "If-Unmodified-Since", InputRequestLocation.Header)
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

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);

                // Verify that the RequestConditions parameter is added
                Assert.AreEqual(2, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters[0].Name == "requestConditions");
                Assert.IsTrue(method.Signature.Parameters[0].Type.Equals(RequestConditionsType));
            }
        }

        [Test]
        public void TestHandleMultipleMixedConditionalHeaders()
        {
            var visitor = new TestMatchConditionsHeaderVisitor();
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestParameter("someOtherParam", "some-other-param", InputRequestLocation.Query)
            };
            var methodParameters = new List<InputMethodParameter>
            {
                CreateTestMethodParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestMethodParameter("someOtherParam", "some-other-param", InputRequestLocation.Query)
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

            foreach (var method in methodCollection)
            {
                visitor.VisitScmMethod(method);

                // Verify that the RequestConditions parameter is added
                Assert.AreEqual(3, method.Signature.Parameters.Count);
                Assert.IsTrue(method.Signature.Parameters[0].Name == "requestConditions");
                Assert.IsTrue(method.Signature.Parameters[0].Type.Equals(RequestConditionsType));
                Assert.IsTrue(method.Signature.Parameters[1].Name == "someOtherParam");
                Assert.IsTrue(method.Signature.Parameters[2].Name == "context" || method.Signature.Parameters[2].Name == "cancellationToken");
            }
        }

        // This test validates that the CollectionResultDefinition is generated correctly when the payload contains match conditions headers.
        [Test]
        public void TestCollectionResultDefinitionNextLinkInBody()
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var pagingMetadata = InputFactory.NextLinkPagingMetadata("cats", "nextCat", InputResponseLocation.Body);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties: [
                        InputFactory.Property("cats", InputFactory.Array(inputModel)),
                        InputFactory.Property("nextCat", InputPrimitiveType.Url)
                    ]));
            var operation = InputFactory.Operation("getCats", parameters: [.. CreateAllMatchConditionHttpParameters()], responses: [response]);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata);
            var client = InputFactory.Client("catClient", methods: [inputServiceMethod]);

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(client);
            Assert.IsNotNull(clientProvider);

            // visit
            var visitor = new TestMatchConditionsHeaderVisitor();

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.IsTrue(methods.Count > 0, "RestClient should have methods defined.");
            foreach (var method in methods)
            {
                visitor.VisitScmMethod(method);
            }

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.IsNotNull(collectionResultDefinition);
            visitor.TestVisitType(collectionResultDefinition!);

            // validate the fields are updated with the request condition type
            var matchConditionsField = collectionResultDefinition!.Fields.FirstOrDefault(f => f.Name == "_requestConditions");
            Assert.IsNotNull(matchConditionsField, "MatchConditions field should be present in the collection result definition.");
            var ifMatchField = collectionResultDefinition.Fields.FirstOrDefault(f => f.Name == "_ifMatch");
            Assert.IsNull(ifMatchField, "If-Match field should not be present in the collection result definition.");
        }

        private static List<InputMethodParameter> CreateAllMatchConditionMethodParameters()
        {
            List<InputMethodParameter> parameters =
            [
                CreateTestMethodParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestMethodParameter("ifUnmodifiedSince", "If-Unmodified-Since", InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static List<InputParameter> CreateAllMatchConditionHttpParameters()
        {
            List<InputParameter> parameters =
            [
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header),
                CreateTestParameter("ifUnmodifiedSince", "If-Unmodified-Since", InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static List<InputParameter> CreateMixedHttpParameters()
        {
            List<InputParameter> parameters =
            [
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("some-other-parameter", "some-other-parameter", InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static List<InputMethodParameter> CreateMixedMethodParameters()
        {
            List<InputMethodParameter> parameters =
            [
                CreateTestMethodParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestMethodParameter("some-other-parameter", "some-other-parameter", InputRequestLocation.Header)
            ];
            return parameters;
        }

        private static InputParameter CreateTestParameter(
            string name,
            string nameInRequest,
            InputRequestLocation location,
            bool isRequired = false)
        {
            if (location == InputRequestLocation.Header)
            {
                return InputFactory.HeaderParameter(
                    name,
                    type: InputPrimitiveType.String,
                    serializedName: nameInRequest,
                    isRequired: isRequired);
            }
            if (location == InputRequestLocation.Query)
            {
                return InputFactory.QueryParameter(
                    name,
                    type: InputPrimitiveType.String,
                    serializedName: nameInRequest,
                    isRequired: isRequired);
            }

            return InputFactory.BodyParameter(
                name,
                type: InputPrimitiveType.String,
                serializedName: nameInRequest,
                isRequired: isRequired);
        }

        private static InputMethodParameter CreateTestMethodParameter(
            string name,
            string nameInRequest,
            InputRequestLocation location,
            bool isRequired = false)
        {
            return InputFactory.MethodParameter(
                name,
                type: InputPrimitiveType.String,
                serializedName: nameInRequest,
                location: location,
                isRequired: isRequired);
        }

        private class TestMatchConditionsHeaderVisitor : MatchConditionsHeadersVisitor
        {
            public ScmMethodProvider? VisitScmMethod(ScmMethodProvider method)
            {
                return base.VisitMethod(method);
            }

            public TypeProvider? TestVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }

            internal MethodProvider? VisitScmMethod(MethodProvider method)
            {
                return base.VisitMethod(method);
            }
        }
    }
}