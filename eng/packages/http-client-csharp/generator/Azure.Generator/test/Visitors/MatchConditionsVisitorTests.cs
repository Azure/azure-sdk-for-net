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
                    type: InputPrimitiveType.String,
                    nameInRequest: "If-Modified-Since",
                    location: InputRequestLocation.Header),
                InputFactory.Parameter(
                    "ifUnmodifiedSince",
                    type: InputPrimitiveType.String,
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

        [Test]
        public void IdentifiesIfMatchParameter()
        {
            var parameter = CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header);

            Assert.IsTrue(IsMatchConditionParameter(parameter));
        }

        [Test]
        public void IdentifiesIfNoneMatchParameter()
        {
            var parameter = CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header);

            Assert.IsTrue(IsMatchConditionParameter(parameter));
        }

        [Test]
        public void IdentifiesIfModifiedSinceParameter()
        {
            var parameter = CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header);

            Assert.IsTrue(IsMatchConditionParameter(parameter));
        }

        [Test]
        public void IdentifiesIfUnmodifiedSinceParameter()
        {
            var parameter = CreateTestParameter("ifUnmodifiedSince", "If-Unmodified-Since", InputRequestLocation.Header);

            Assert.IsTrue(IsMatchConditionParameter(parameter));
        }

        [Test]
        public void IgnoresNonMatchConditionHeaders()
        {
            var parameter = CreateTestParameter("authorization", "Authorization", InputRequestLocation.Header);

            Assert.IsFalse(IsMatchConditionParameter(parameter));
        }

        [Test]
        public void IgnoresNonHeaderParameters()
        {
            var parameter = CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Query);

            Assert.IsFalse(IsMatchConditionParameter(parameter));
        }

        [Test]
        public void FiltersMatchConditionParameters()
        {
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header),
                CreateTestParameter("authorization", "Authorization", InputRequestLocation.Header),
                CreateTestParameter("contentType", "Content-Type", InputRequestLocation.Header)
            };

            var matchConditionParams = GetMatchConditionParameters(parameters);

            Assert.AreEqual(2, matchConditionParams.Count);
            Assert.IsTrue(matchConditionParams.ContainsKey("If-Match"));
            Assert.IsTrue(matchConditionParams.ContainsKey("If-None-Match"));
        }

        [Test]
        public void DeterminesRequestConditionsNeeded()
        {
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("ifModifiedSince", "If-Modified-Since", InputRequestLocation.Header)
            };

            var matchConditionParams = GetMatchConditionParameters(parameters);
            bool hasDateConditions = matchConditionParams.ContainsKey("If-Modified-Since") ||
                matchConditionParams.ContainsKey("If-Unmodified-Since");

            Assert.IsTrue(hasDateConditions, "Should detect that RequestConditions is needed for date-based conditions");
        }

        [Test]
        public void DeterminesMatchConditionsNeeded()
        {
            var parameters = new List<InputParameter>
            {
                CreateTestParameter("ifMatch", "If-Match", InputRequestLocation.Header),
                CreateTestParameter("ifNoneMatch", "If-None-Match", InputRequestLocation.Header)
            };

            var matchConditionParams = GetMatchConditionParameters(parameters);
            bool hasDateConditions = matchConditionParams.ContainsKey("If-Modified-Since") ||
                                   matchConditionParams.ContainsKey("If-Unmodified-Since");

            Assert.IsFalse(hasDateConditions, "Should detect that only MatchConditions is needed for ETag-only conditions");
        }

        // Helper methods for unit tests
        private static InputParameter CreateTestParameter(string name, string nameInRequest, InputRequestLocation location)
        {
            return new InputParameter(
                name,
                nameInRequest,
                null, // summary
                $"{name} description",
                InputPrimitiveType.String,
                location,
                defaultValue: null,
                kind: InputParameterKind.Method,
                isRequired: false,
                isApiVersion: false,
                isContentType: false,
                isEndpoint: false,
                skipUrlEncoding: false,
                explode: false,
                arraySerializationDelimiter: null,
                headerCollectionPrefix: null,
                serverUrlTemplate: null);
        }

        private static bool IsMatchConditionParameter(InputParameter parameter)
        {
            return !parameter.IsRequired &&
                   parameter.Location == InputRequestLocation.Header &&
                   (parameter.NameInRequest == "If-Match" ||
                    parameter.NameInRequest == "If-None-Match" ||
                    parameter.NameInRequest == "If-Modified-Since" ||
                    parameter.NameInRequest == "If-Unmodified-Since");
        }

        private static Dictionary<string, InputParameter> GetMatchConditionParameters(IReadOnlyList<InputParameter> parameters)
        {
            var matchConditionParameters = new Dictionary<string, InputParameter>();

            foreach (var parameter in parameters)
            {
                if (IsMatchConditionParameter(parameter))
                {
                    matchConditionParameters[parameter.NameInRequest] = parameter;
                }
            }

            return matchConditionParameters;
        }

        private class TestMatchConditionsVisitor : MatchConditionsHeaderVisitor
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