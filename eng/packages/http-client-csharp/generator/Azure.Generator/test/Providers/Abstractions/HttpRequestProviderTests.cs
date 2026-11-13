// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Generator.Tests.Providers.Abstractions
{
    internal class HttpRequestProviderTests
    {
        [Test]
        public void AddCollectionHeaders_GeneratesCorrectStatement()
        {
            MockHelpers.LoadMockGenerator();
            var httpRequestProvider = new HttpRequestProvider(ValueExpression.Empty);
            var prefixExpression = Snippet.Literal("x-ms-meta-");
            var headersExpression = new VariableExpression(new CSharpType(typeof(IDictionary<string, string>)), "customHeaders");

            var statement = httpRequestProvider.AddCollectionHeaders(prefixExpression, headersExpression);

            Assert.IsNotNull(statement);
            var displayString = statement.ToDisplayString();
            Assert.IsTrue(displayString.Contains("Headers.Add"), $"Expected 'Headers.Add' in generated statement, but got: {displayString}");
            Assert.IsTrue(displayString.Contains("\"x-ms-meta-\""), $"Expected prefix in generated statement, but got: {displayString}");
            Assert.IsTrue(displayString.Contains("customHeaders"), $"Expected headers variable in generated statement, but got: {displayString}");
        }

        [Test]
        public void DictionaryHeaderWithCollectionPrefix_GeneratesAddCallInCreateRequest()
        {
            var dictType = new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String);
            var headerParam = InputFactory.HeaderParameter(
                "customHeaders",
                type: dictType,
                isRequired: false,
                serializedName: "x-ms-meta-",
                collectionHeaderPrefix: "x-ms-meta-");
            var methodParameter = InputFactory.MethodParameter(
                "customHeaders",
                type: dictType,
                isRequired: false,
                location: InputRequestLocation.Header,
                serializedName: "x-ms-meta-");

            var operation = InputFactory.Operation("foo", parameters: [headerParam]);
            var serviceMethod = InputFactory.BasicServiceMethod("foo", operation, parameters: [methodParameter]);
            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);

            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);

            var writer = new TypeProviderWriter(clientProvider!.RestClient);
            var file = writer.Write();

            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }
    }
}
