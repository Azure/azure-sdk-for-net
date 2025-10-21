// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Azure.Generator.Tests.Providers.ClientProviders
{
    internal class ClientProviderTests
    {
        private const string SubClientsCategory = "WithSubClients";
        private const string KeyAuthCategory = "WithKeyAuth";
        private const string OAuth2Category = "WithOAuth2";
        private const string TestClientName = "TestClient";
        private static readonly InputClient _testClient = new(TestClientName, "Samples", "", "TestClient description", null, [], [], _testClient, [], []);
        private static readonly InputClient _animalClient = new("animal", "Samples", "", "AnimalClient description", null, [], [], _testClient, [], []);
        private static readonly InputClient _dogClient = new("dog", "Samples", "", "DogClient description", null, [], [], _animalClient, [], []);
        private static readonly InputClient _huskyClient = new("husky", "Samples", "", "HuskyClient description", null, [], [], _dogClient, [], []);

        private bool _containsSubClients;
        private bool _hasKeyAuth;
        private bool _hasOAuth2;
        private bool _hasAuth;

        [SetUp]
        public void Setup()
        {
            var categories = TestContext.CurrentContext.Test?.Properties["Category"];
            _containsSubClients = categories?.Contains(SubClientsCategory) ?? false;
            _hasKeyAuth = categories?.Contains(KeyAuthCategory) ?? false;
            _hasOAuth2 = categories?.Contains(OAuth2Category) ?? false;
            _hasAuth = _hasKeyAuth || _hasOAuth2;

            Func<IReadOnlyList<InputClient>>? clients = _containsSubClients ?
                () => [_animalClient, _dogClient, _huskyClient] :
                null;
            Func<InputApiKeyAuth>? apiKeyAuth = _hasKeyAuth ? () => new InputApiKeyAuth("mock", null) : null;
            Func<InputOAuth2Auth>? oauth2Auth = _hasOAuth2 ? () => new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]) : null;
            MockHelpers.LoadMockGenerator(
                apiKeyAuth: apiKeyAuth,
                oauth2Auth: oauth2Auth,
                clients: clients);
        }

        [TestCaseSource(nameof(BuildAuthFieldsTestCases), Category = KeyAuthCategory)]
        [TestCaseSource(nameof(BuildAuthFieldsTestCases), Category = OAuth2Category)]
        [TestCaseSource(nameof(BuildAuthFieldsTestCases), Category = $"{KeyAuthCategory},{OAuth2Category}")]
        public void TestBuildAuthFields_WithAuth(List<InputParameter> inputParameters)
        {
            var client = InputFactory.Client(TestClientName, parameters: [.. inputParameters]);
            var clientProvider = new ClientProvider(client);

            Assert.IsNotNull(clientProvider);

            if (_hasKeyAuth)
            {
                // key auth should have the following fields: AuthorizationHeader, _keyCredential
                AssertHasFields(clientProvider, new List<ExpectedFieldProvider>
                {
                    new(FieldModifiers.Private | FieldModifiers.Const, new CSharpType(typeof(string)), "AuthorizationHeader"),
                    new(FieldModifiers.Private | FieldModifiers.ReadOnly, new CSharpType(typeof(AzureKeyCredential)), "_keyCredential")
                });
            }
            if (_hasOAuth2)
            {
                // oauth2 auth should have the following fields: AuthorizationScopes, _tokenCredential
                AssertHasFields(clientProvider, new List<ExpectedFieldProvider>
                {
                    new(FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly, new CSharpType(typeof(string[])), "AuthorizationScopes"),
                    new(FieldModifiers.Private | FieldModifiers.ReadOnly, new CSharpType(typeof(TokenCredential)), "_tokenCredential"),
                });
            }
        }

        [TestCaseSource(nameof(BuildAuthFieldsTestCases))]
        public void TestBuildAuthFields_NoAuth(List<InputParameter> inputParameters)
        {
            var client = InputFactory.Client(TestClientName, parameters: [.. inputParameters]);
            var clientProvider = new ClientProvider(client);

            Assert.IsNotNull(clientProvider);

            // fields here should not have anything related with auth
            bool authFieldFound = false;
            foreach (var field in clientProvider.Fields)
            {
                if (field.Name.EndsWith("Credential") || field.Name.Contains("Authorization"))
                {
                    authFieldFound = true;
                }
            }

            Assert.IsFalse(authFieldFound);
        }

        // validates the credential fields are built correctly when a client has sub-clients
        [TestCaseSource(nameof(SubClientAuthFieldsTestCases), Category = SubClientsCategory)]
        public void TestBuildAuthFields_WithSubClients_NoAuth(InputClient client)
        {
            var clientProvider = new ClientProvider(client);

            Assert.IsNotNull(clientProvider);

            // fields here should not have anything related with auth
            bool authFieldFound = false;
            foreach (var field in clientProvider.Fields)
            {
                if (field.Name.EndsWith("Credential") || field.Name.Contains("Authorization"))
                {
                    authFieldFound = true;
                }
            }

            Assert.IsFalse(authFieldFound);
        }

        [TestCaseSource(nameof(BuildConstructorsTestCases))]
        [TestCaseSource(nameof(BuildConstructorsTestCases), Category = KeyAuthCategory)]
        [TestCaseSource(nameof(BuildConstructorsTestCases), Category = OAuth2Category)]
        [TestCaseSource(nameof(BuildConstructorsTestCases), Category = $"{KeyAuthCategory},{OAuth2Category}")]
        public void TestBuildConstructors_PrimaryConstructor(List<InputParameter> inputParameters)
        {
            var client = InputFactory.Client(TestClientName, parameters: [.. inputParameters]);
            var clientProvider = new ClientProvider(client);

            Assert.IsNotNull(clientProvider);

            var constructors = clientProvider.Constructors;

            var primaryPublicConstructors = constructors.Where(
                c => c.Signature?.Initializer == null && c.Signature?.Modifiers == MethodSignatureModifiers.Public).ToArray();

            for (int i = 0; i < primaryPublicConstructors.Length; i++)
            {
                ValidatePrimaryConstructor(primaryPublicConstructors[i], inputParameters, i);
            }
        }

        private void ValidatePrimaryConstructor(
            ConstructorProvider primaryPublicConstructor,
            List<InputParameter> inputParameters,
            int ctorIndex,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            // validate the body of the primary ctor
            var caseName = TestContext.CurrentContext.Test.Properties.Get("caseName");
            var expected = Helpers.GetExpectedFromFile($"{caseName},{_hasKeyAuth},{_hasOAuth2},{ctorIndex}", method, filePath);
            var primaryCtorBody = primaryPublicConstructor?.BodyStatements;
            Assert.IsNotNull(primaryCtorBody);
            Assert.AreEqual(expected, primaryCtorBody?.ToDisplayString());
        }

        public static IEnumerable<TestCaseData> BuildConstructorsTestCases
        {
            get
            {
                yield return new TestCaseData(new List<InputParameter>
                {
                    InputFactory.PathParameter(
                        "optionalParam",
                        InputPrimitiveType.String,
                        scope: InputParameterScope.Client),
                    InputFactory.EndpointParameter(
                        KnownParameters.Endpoint.Name,
                        InputPrimitiveType.String,
                        defaultValue: InputFactory.Constant.String("someValue"),
                        scope: InputParameterScope.Client,
                        isEndpoint: true)
                }).SetProperty("caseName", "WithDefault");
                // scenario where endpoint is required
                yield return new TestCaseData(new List<InputParameter>
                {
                    InputFactory.EndpointParameter(
                        KnownParameters.Endpoint.Name,
                        InputPrimitiveType.String,
                        scope: InputParameterScope.Client,
                        isRequired: true,
                        isEndpoint: true),
                    InputFactory.PathParameter(
                        "optionalParam",
                        InputPrimitiveType.String,
                        scope: InputParameterScope.Client)
                }).SetProperty("caseName", "WithRequired");
            }
        }

        public static IEnumerable<TestCaseData> BuildAuthFieldsTestCases
        {
            get
            {
                yield return new TestCaseData(new List<InputParameter>
                {
                    InputFactory.EndpointParameter(
                        "optionalParam",
                        InputPrimitiveType.String,
                        scope: InputParameterScope.Client),

                    InputFactory.EndpointParameter(
                        KnownParameters.Endpoint.Name,
                        InputPrimitiveType.String,
                        scope: InputParameterScope.Client,
                        isEndpoint: true)
                });
                yield return new TestCaseData(new List<InputParameter>
                {
                    // have to explicitly set isRequired because we now call CreateParameter in buildFields
                    InputFactory.EndpointParameter(
                        "optionalNullableParam",
                        InputPrimitiveType.String,
                        defaultValue: InputFactory.Constant.String("someValue"),
                        scope: InputParameterScope.Client,
                        isRequired: false),
                    InputFactory.EndpointParameter(
                        "requiredParam2",
                        InputPrimitiveType.String,
                        defaultValue: InputFactory.Constant.String("someValue"),
                        scope: InputParameterScope.Client,
                        isRequired: true),
                    InputFactory.EndpointParameter(
                        "requiredParam3",
                        InputPrimitiveType.Int64,
                        defaultValue: InputFactory.Constant.Int64(2),
                        scope: InputParameterScope.Client,
                        isRequired: true),
                    InputFactory.EndpointParameter(
                        KnownParameters.Endpoint.Name,
                        InputPrimitiveType.String,
                        defaultValue: null,
                        scope: InputParameterScope.Client,
                        isEndpoint: true)
                });
            }
        }

        public static IEnumerable<TestCaseData> SubClientAuthFieldsTestCases
        {
            get
            {
                yield return new TestCaseData(InputFactory.Client(TestClientName));
                yield return new TestCaseData(_animalClient);
                yield return new TestCaseData(_dogClient);
                yield return new TestCaseData(_huskyClient);
            }
        }

        public record ExpectedCSharpType
        {
            public string Name { get; }

            public string Namespace { get; }

            public bool IsFrameworkType { get; }

            public Type FrameworkType => _frameworkType ?? throw new InvalidOperationException();

            public bool IsNullable { get; }

            private readonly Type? _frameworkType;

            public ExpectedCSharpType(Type frameworkType, bool isNullable)
            {
                _frameworkType = frameworkType;
                IsFrameworkType = true;
                IsNullable = isNullable;
                Name = frameworkType.Name;
                Namespace = frameworkType.Namespace!;
            }

            public ExpectedCSharpType(string name, string ns, bool isNullable)
            {
                IsFrameworkType = false;
                IsNullable = isNullable;
                Name = name;
                Namespace = ns;
            }

            public static implicit operator ExpectedCSharpType(CSharpType type)
            {
                if (type.IsFrameworkType)
                {
                    return new(type.FrameworkType, type.IsNullable);
                }
                else
                {
                    return new(type.Name, type.Namespace, type.IsNullable);
                }
            }
        }

        public record ExpectedFieldProvider(FieldModifiers Modifiers, ExpectedCSharpType Type, string Name);

        private static void AssertCSharpTypeAreEqual(ExpectedCSharpType expected, CSharpType type)
        {
            if (expected.IsFrameworkType)
            {
                Assert.IsTrue(type.IsFrameworkType);
                Assert.AreEqual(expected.FrameworkType, type.FrameworkType);
            }
            else
            {
                Assert.IsFalse(type.IsFrameworkType);
                Assert.AreEqual(expected.Name, type.Name);
                Assert.AreEqual(expected.Namespace, type.Namespace);
            }
            Assert.AreEqual(expected.IsNullable, type.IsNullable);
        }

        private static void AssertFieldAreEqual(ExpectedFieldProvider expected, FieldProvider field)
        {
            Assert.AreEqual(expected.Name, field.Name);
            AssertCSharpTypeAreEqual(expected.Type, field.Type);
            Assert.AreEqual(expected.Modifiers, field.Modifiers);
        }

        private static void AssertHasFields(TypeProvider provider, IReadOnlyList<ExpectedFieldProvider> expectedFields)
        {
            var fields = provider.Fields;

            // validate the length of the result
            Assert.GreaterOrEqual(fields.Count, expectedFields.Count);

            // validate each of them
            var fieldDict = fields.ToDictionary(f => f.Name);
            for (int i = 0; i < expectedFields.Count; i++)
            {
                var expected = expectedFields[i];

                Assert.IsTrue(fieldDict.TryGetValue(expected.Name, out var actual), $"Field {expected.Name} not present");
                AssertFieldAreEqual(expected, actual!);
            }
        }
    }
}
