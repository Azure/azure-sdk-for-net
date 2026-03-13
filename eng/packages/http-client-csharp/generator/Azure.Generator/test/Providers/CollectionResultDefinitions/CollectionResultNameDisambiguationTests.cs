// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers.CollectionResultDefinitions
{
    /// <summary>
    /// Tests that CollectionResult type names are automatically disambiguated when two
    /// different pageable operations would otherwise produce the same generated class name.
    ///
    /// The collision arises because client name and method name are concatenated without a
    /// separator, so e.g. client "FooBar" + method "baz" and client "Foo" + method "barBaz"
    /// both produce the base name "FooBarBaz".
    /// </summary>
    public class CollectionResultNameDisambiguationTests
    {
        [Test]
        public void CollidingCollectionResultNamesAreDisambiguated()
        {
            // Arrange: two clients whose names + method names concatenate to the same string.
            // "FooBar" + "baz"    -> base name "FooBarBaz..."
            // "Foo"    + "barBaz" -> base name "FooBarBaz..."
            CreateCollidingPagingOperations();

            // Act: collect all AzureCollectionResultDefinition names.
            var names = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<AzureCollectionResultDefinition>()
                .Select(t => t.Name)
                .ToList();

            // Assert: no two collection result types share the same name.
            Assert.That(names, Is.Unique,
                "Multiple AzureCollectionResultDefinition types must not share the same name.");
        }

        [Test]
        public void NoCollisionMeansNoSuffixAdded()
        {
            // When there is only one paging operation, no disambiguation suffix should be added.
            CreateSinglePagingOperation();

            var collectionResults = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<AzureCollectionResultDefinition>()
                .ToList();

            Assert.That(collectionResults, Is.Not.Empty);
            foreach (var cr in collectionResults)
            {
                // Suffix-free names end with "CollectionResult" or "CollectionResultOfT"
                // (with optional "Async" before CollectionResult).
                Assert.That(cr.Name, Does.EndWith("CollectionResult").Or.EndWith("CollectionResultOfT"),
                    $"Name '{cr.Name}' should not have a numeric disambiguation suffix when there is no collision.");
            }
        }

        private static void CreateCollidingPagingOperations()
        {
            var catModel = InputFactory.Model("cat",
                properties: [InputFactory.Property("color", InputPrimitiveType.String, isRequired: true)]);

            var pagingMetadata = InputFactory.PagingMetadata(["items"], null, null);

            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model("page",
                    properties: [InputFactory.Property("items", InputFactory.Array(catModel))]));

            // Client "FooBar" with method "baz"
            var operation1 = InputFactory.Operation("baz", responses: [response]);
            var method1 = InputFactory.PagingServiceMethod("baz", operation1, pagingMetadata: pagingMetadata);
            var fooBarClient = InputFactory.Client("FooBar", methods: [method1]);

            // Client "Foo" with method "barBaz"
            var operation2 = InputFactory.Operation("barBaz", responses: [response]);
            var method2 = InputFactory.PagingServiceMethod("barBaz", operation2, pagingMetadata: pagingMetadata);
            var fooClient = InputFactory.Client("Foo", methods: [method2]);

            MockHelpers.LoadMockGenerator(
                inputModels: () => [catModel],
                clients: () => [fooBarClient, fooClient]);
        }

        private static void CreateSinglePagingOperation()
        {
            var catModel = InputFactory.Model("cat",
                properties: [InputFactory.Property("color", InputPrimitiveType.String, isRequired: true)]);

            var pagingMetadata = InputFactory.PagingMetadata(["items"], null, null);

            var response = InputFactory.OperationResponse(
                [200],
                InputFactory.Model("page",
                    properties: [InputFactory.Property("items", InputFactory.Array(catModel))]));

            var operation = InputFactory.Operation("getCats", responses: [response]);
            var method = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: pagingMetadata);
            var client = InputFactory.Client("catClient", methods: [method]);

            MockHelpers.LoadMockGenerator(
                inputModels: () => [catModel],
                clients: () => [client]);
        }
    }
}
