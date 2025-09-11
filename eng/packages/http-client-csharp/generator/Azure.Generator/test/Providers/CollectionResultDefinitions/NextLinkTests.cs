// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers.CollectionResultDefinitions
{
    public class NextLinkTests
    {
        [Test]
        public void NextLinkInBody()
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
        public void NextLinkInBodyAsync()
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
        public void NextLinkInHeader()
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
        public void NextLinkInHeaderAsync()
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
        public void NextLinkInBodyOfT()
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
        public void NextLinkInBodyOfTAsync()
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
        public void NextLinkInHeaderOfT()
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
        public void NextLinkInHeaderOfTAsync()
        {
            CreatePagingOperation(InputResponseLocation.Header);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResultOfT");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void NextLinkInBodyMultipleClients()
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
                    properties: [InputFactory.Property("cats", InputFactory.Array(inputModel)), InputFactory.Property("nextCat", InputPrimitiveType.Url)]));
            var operation = InputFactory.Operation("getCats", responses: [response]);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata);
            var catClient = InputFactory.Client("catClient", methods: [inputServiceMethod], clientNamespace: "Cats");
            var felineClient = InputFactory.Client("felineClient", methods: [inputServiceMethod], clientNamespace: "Felines");
            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [catClient, felineClient]);

            var catClientCollectionResult = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.IsNotNull(catClientCollectionResult);

            var felineClientCollectionResult = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "FelineClientGetCatsCollectionResult");
            Assert.IsNotNull(felineClientCollectionResult);
        }

        [Test]
        public void NextLinkInBodyOfTWithStringProperty()
        {
            CreatePagingOperation(InputResponseLocation.Body, useStringProperty: true);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResultOfT");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void NextLinkInBodyWithStringProperty()
        {
            CreatePagingOperation(InputResponseLocation.Body, useStringProperty: true);

            var collectionResultDefinition = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
                t => t is AzureCollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
            Assert.IsNotNull(collectionResultDefinition);

            var writer = new TypeProviderWriter(collectionResultDefinition!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void UsesValidFieldIdentifierNames()
        {
            MockHelpers.LoadMockGenerator();
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var pagingMetadata = InputFactory.NextLinkPagingMetadata("cats", "nextCat", InputResponseLocation.Body);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties:
                    [
                        InputFactory.Property("cats", InputFactory.Array(inputModel)),
                        InputFactory.Property("nextCat", InputPrimitiveType.Url)
                    ]));
            IReadOnlyList<InputHeaderParameter> parameters =
            [
                InputFactory.HeaderParameter("$foo", InputPrimitiveType.String, isRequired: true)
            ];
            IReadOnlyList<InputMethodParameter> methodParameters =
            [
                InputFactory.MethodParameter("$foo", InputPrimitiveType.String, isRequired: true,
                    location: InputRequestLocation.Header)
            ];
            var operation = InputFactory.Operation("getCats", responses: [response], parameters: parameters);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation,
                pagingMetadata: pagingMetadata, parameters: methodParameters);
            var catClient = InputFactory.Client("catClient", methods: [inputServiceMethod], clientNamespace: "Cats");
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(catClient);
            var modelType = AzureClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            var collectionResultDefinition =
                new AzureCollectionResultDefinition(clientProvider!, inputServiceMethod, modelType!.Type, false);
            var fields = collectionResultDefinition.Fields;

            Assert.IsTrue(fields.Any(f => f.Name == "_foo"));
        }

        private static void CreatePagingOperation(InputResponseLocation responseLocation, bool useStringProperty = false)
        {
            var inputModel = InputFactory.Model("cat", properties:
            [
                InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
            ]);
            var pagingMetadata = InputFactory.NextLinkPagingMetadata("cats", "nextCat", responseLocation);
            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model(
                    "page",
                    properties: [
                        InputFactory.Property("cats", InputFactory.Array(inputModel)),
                        InputFactory.Property("nextCat", useStringProperty ? InputPrimitiveType.String : InputPrimitiveType.Url)
                    ]));
            var operation = InputFactory.Operation("getCats", responses: [response]);
            var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata);
            var client = InputFactory.Client("catClient", methods: [inputServiceMethod]);

            MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);
        }
    }
}
