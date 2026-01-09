// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers.CollectionResultDefinitions
{
    public class ListPageableTests
    {
        [Test]
        public void NoNextLinkOrContinuationToken()
        {
            CreatePagingOperation();

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.That(collectionResultDefinition, Is.Not.Null);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void NoNextLinkOrContinuationTokenAsync()
        {
            CreatePagingOperation();

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResult");
            Assert.That(collectionResultDefinition, Is.Not.Null);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void NoNextLinkOrContinuationTokenOfT()
        {
            CreatePagingOperation();

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResultOfT");
            Assert.That(collectionResultDefinition, Is.Not.Null);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        [Test]
        public void NoNextLinkOrContinuationTokenOfTAsync()
        {
            CreatePagingOperation();

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResultOfT");
            Assert.That(collectionResultDefinition, Is.Not.Null);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.That(file.Content, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }

        private static void CreatePagingOperation()
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var parameter = InputFactory.QueryParameter("animalKind", InputPrimitiveType.String, isRequired: true);
            var pagingMetadata = InputFactory.PagingMetadata(["cats"], null, null);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties: [InputFactory.Property("cats", InputFactory.Array(inputModel))]));
            var operation = InputFactory.Operation("getCats", parameters: [parameter], responses: [response]);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata);
            var client = InputFactory.Client("catClient", methods: [inputServiceMethod]);

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);
        }
    }
}
