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
    public class ContinuationTokenTests
    {
        [Test]
        public void ContinuationTokenInBody()
        {
            CreatePagingOperation(InputResponseLocation.Body);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInBodyAsync()
        {
            CreatePagingOperation(InputResponseLocation.Body);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResult");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInHeader()
        {
            CreatePagingOperation(InputResponseLocation.Header);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInHeaderAsync()
        {
            CreatePagingOperation(InputResponseLocation.Header);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResult");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInBodyOfT()
        {
            CreatePagingOperation(InputResponseLocation.Body);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResultOfT");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInBodyOfTAsync()
        {
            CreatePagingOperation(InputResponseLocation.Body);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResultOfT");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInHeaderOfT()
        {
            CreatePagingOperation(InputResponseLocation.Header);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResultOfT");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void ContinuationTokenInHeaderOfTAsync()
        {
            CreatePagingOperation(InputResponseLocation.Header);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResultOfT");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        private static void CreatePagingOperation(InputResponseLocation responseLocation)
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var parameter = InputFactory.QueryParameter("myToken", InputPrimitiveType.String, isRequired: true);
            var paging = InputFactory.ContinuationTokenPagingMetadata(parameter, "cats", "nextPage", responseLocation);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties: [InputFactory.Property("cats", InputFactory.Array(inputModel)), InputFactory.Property("nextPage", InputPrimitiveType.Url)]));
            var operation = InputFactory.Operation("getCats", parameters: [parameter], responses: [response]);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: paging);
            var client = InputFactory.Client("catClient", methods: [inputServiceMethod]);

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);
        }
    }
}
