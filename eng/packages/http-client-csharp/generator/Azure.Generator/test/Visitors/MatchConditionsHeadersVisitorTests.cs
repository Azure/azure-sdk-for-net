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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the RequestConditions parameter is added to all the client methods
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(2));
                Assert.That(method.Signature.Parameters[0].Name, Is.EqualTo("requestConditions"));
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
            Assert.That(clientProvider, Is.Not.Null);

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.That(methods.Count, Is.GreaterThan(0), "RestClient should have methods defined.");

            // visit the method
            _ = visitor.VisitCreateRequest(serviceMethod, restClient, methods[0]);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the RequestConditions parameter is added to all the client methods
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(2));
                Assert.Multiple(() =>
                {
                    Assert.That(method.Signature.Parameters[0].Name, Is.EqualTo(conditionName.ToVariableName()));
                    Assert.That(method.Signature.Parameters[0].Type, Is.EqualTo(ETagType));
                });
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
            Assert.That(clientProvider, Is.Not.Null);

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.That(methods.Count, Is.GreaterThan(0), "RestClient should have methods defined.");

            // visit the method
            _ = visitor.VisitCreateRequest(serviceMethod, restClient, methods[0]);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile(conditionName)));
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
            Assert.That(clientProvider, Is.Not.Null);

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.That(methods.Count, Is.GreaterThan(0), "RestClient should have methods defined.");

            // visit the method
            _ = visitor.VisitCreateRequest(serviceMethod, restClient, methods[0]);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
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
            Assert.That(clientProvider, Is.Not.Null);

            MethodProvider? protocolMethod = null;
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                if (method.Kind == ScmMethodKind.Protocol && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    protocolMethod = method;
                }
            }

            Assert.That(protocolMethod, Is.Not.Null, "Protocol method should be found.");
            Assert.That(protocolMethod?.BodyStatements, Is.Not.Null);

            var result = protocolMethod!.BodyStatements!.ToDisplayString();
            Assert.That(result, Is.EqualTo(Helpers.GetExpectedFromFile()));
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
            Assert.That(clientProvider, Is.Not.Null);

            MethodProvider? protocolMethod = null;
            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                if (method.Kind == ScmMethodKind.Protocol && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Async))
                {
                    protocolMethod = method;
                }
            }

            Assert.That(protocolMethod, Is.Not.Null, "Protocol method should be found.");
            Assert.That(protocolMethod!.Signature.Parameters, Has.Count.EqualTo(3), "Protocol method should have two parameters.");

            var etagParameter = protocolMethod.Signature.Parameters.FirstOrDefault(p => p.Name == "ifNoneMatch");
            Assert.That(etagParameter, Is.Not.Null, "If-None-Match parameter should be present.");
            var contextParameter = protocolMethod.Signature.Parameters.FirstOrDefault(p => p.Name == "context");
            Assert.Multiple(() =>
            {
                Assert.That(contextParameter, Is.Not.Null, "Context parameter should be present.");

                Assert.That(etagParameter!.DefaultValue == null, Is.EqualTo(isRequired));
            });
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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the RequestConditions parameter is added to all the client methods
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(3));
                Assert.Multiple(() =>
                {
                    Assert.That(method.Signature.Parameters[0].Type, Is.EqualTo(ETagType));
                    Assert.That(method.Signature.Parameters[1].Type.Equals(ETagType), Is.False);
                });
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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the parameters are unchanged
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(3));
                Assert.Multiple(() =>
                {
                    Assert.That(method.Signature.Parameters.Any(p => p.Name == "authorization"), Is.True);
                    Assert.That(method.Signature.Parameters.Any(p => p.Name == "contentType"), Is.True);
                    Assert.That(method.Signature.Parameters.Any(p => p.Name == "requestConditions"), Is.False);
                    Assert.That(method.Signature.Parameters.Any(p => p.Name == "matchConditions"), Is.False);
                    Assert.That(method.Signature.Parameters.Any(p => p.Type.Equals(ETagType)), Is.False);
                });
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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the MatchConditions parameter is added
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(2));
                Assert.Multiple(() =>
                {
                    Assert.That(method.Signature.Parameters[0].Name, Is.EqualTo("matchConditions"));
                    Assert.That(method.Signature.Parameters[0].Type, Is.EqualTo(MatchConditionsType));
                });
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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the RequestConditions parameter is added
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(2));
                Assert.Multiple(() =>
                {
                    Assert.That(method.Signature.Parameters[0].Name, Is.EqualTo("requestConditions"));
                    Assert.That(method.Signature.Parameters[0].Type, Is.EqualTo(RequestConditionsType));
                });
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
            Assert.That(clientProvider, Is.Not.Null);

            var methodCollection = new ScmMethodProviderCollection(serviceMethod, clientProvider!);

            visitor.VisitScmMethodCollection(serviceMethod, clientProvider!, methodCollection);

            foreach (var method in methodCollection)
            {
                // Verify that the RequestConditions parameter is added
                Assert.That(method.Signature.Parameters, Has.Count.EqualTo(3));
                Assert.Multiple(() =>
                {
                    Assert.That(method.Signature.Parameters[0].Name, Is.EqualTo("requestConditions"));
                    Assert.That(method.Signature.Parameters[0].Type, Is.EqualTo(RequestConditionsType));
                    Assert.That(method.Signature.Parameters[1].Name, Is.EqualTo("someOtherParam"));
                    Assert.That(method.Signature.Parameters[2].Name == "context" || method.Signature.Parameters[2].Name == "cancellationToken", Is.True);
                });
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
            Assert.That(clientProvider, Is.Not.Null);

            // visit
            var visitor = new TestMatchConditionsHeaderVisitor();

            var restClient = clientProvider!.RestClient;
            var methods = restClient.Methods;
            Assert.That(methods.Count, Is.GreaterThan(0), "RestClient should have methods defined.");
            foreach (var method in methods)
            {
                visitor.VisitCreateRequest(inputServiceMethod, restClient, method as ScmMethodProvider);
            }

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.That(collectionResultDefinition, Is.Not.Null);
            visitor.TestVisitType(collectionResultDefinition!);

            // validate the fields are updated with the request condition type
            var matchConditionsField = collectionResultDefinition!.Fields.FirstOrDefault(f => f.Name == "_requestConditions");
            Assert.That(matchConditionsField, Is.Not.Null, "MatchConditions field should be present in the collection result definition.");
            var ifMatchField = collectionResultDefinition.Fields.FirstOrDefault(f => f.Name == "_ifMatch");
            Assert.That(ifMatchField, Is.Null, "If-Match field should not be present in the collection result definition.");
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
            public ScmMethodProviderCollection? VisitScmMethodCollection(
                InputServiceMethod serviceMethod,
                ClientProvider enclosingType,
                ScmMethodProviderCollection? methodProviderCollection)
            {
                return base.Visit(serviceMethod, enclosingType, methodProviderCollection);
            }

            public ScmMethodProvider? VisitCreateRequest(
                InputServiceMethod serviceMethod,
                RestClientProvider enclosingType,
                MethodProvider? methodProvider)
            {
                return base.VisitCreateRequestMethod(serviceMethod, enclosingType, methodProvider as ScmMethodProvider);
            }

            public TypeProvider? TestVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }
        }
    }
}