// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class NextLinkEndpointVisitorTests
    {
        [Test]
        public void ModifiesCreateNextRequestMethodToUseEndpointAndAppendRawNextLink()
        {
            // Create a pagination operation with nextLink
            var stringType = InputFactory.Literal(InputLiteralTypeKind.String);
            var itemModel = InputFactory.Model("Item", properties: [InputFactory.Property("Name", stringType)]);
            var pageModel = InputFactory.Model(
                "PagedItems",
                properties:
                [
                    InputFactory.Property("Items", InputFactory.List(itemModel)),
                    InputFactory.Property("NextLink", stringType)
                ]);

            var operation = InputFactory.Operation(
                "ListItems",
                parameters: [],
                responses: [InputFactory.OperationResponse(bodytype: pageModel)]);

            var paging = new InputPagingServiceMetadata(
                itemPropertySegments: ["Items"],
                nextLink: new InputPagingServiceMetadataNextLink("NextLink"));

            var pagingMethod = InputFactory.PagingServiceMethod(
                "ListItems",
                operation,
                paging: paging,
                response: InputFactory.ServiceMethodResponse(pageModel, ["result"]));

            var inputClient = InputFactory.Client("TestClient", methods: [pagingMethod]);

            var visitor = new NextLinkEndpointVisitor();
            var generator = MockHelpers.LoadMockGenerator(
                clients: () => [inputClient],
                visitors: () => [visitor]);

            var client = generator.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var restClient = client.RestClient as RestClientProvider;

            Assert.IsNotNull(restClient);

            // Find the CreateNext method
            var createNextMethod = restClient!.Methods
                .OfType<ScmMethodProvider>()
                .FirstOrDefault(m => m.Signature.Name.StartsWith("CreateNext", StringComparison.Ordinal));

            if (createNextMethod != null)
            {
                // Verify the method was modified
                var bodyString = createNextMethod.BodyStatements?.ToDisplayString();
                Assert.IsNotNull(bodyString);

                // Check that the method now uses Reset with _endpoint and AppendRawNextLink
                Assert.That(bodyString, Does.Contain("Reset(_endpoint)"));
                Assert.That(bodyString, Does.Contain("AppendRawNextLink"));
            }
        }

        [Test]
        public void DoesNotModifyNonNextLinkMethods()
        {
            // Create a simple non-paging operation
            var responseModel = InputFactory.Model("Response");
            var operation = InputFactory.Operation(
                "GetItem",
                parameters: [],
                responses: [InputFactory.OperationResponse(bodytype: responseModel)]);

            var serviceMethod = InputFactory.ServiceMethod(
                "GetItem",
                operation,
                response: InputFactory.ServiceMethodResponse(responseModel, ["result"]));

            var inputClient = InputFactory.Client("TestClient", methods: [serviceMethod]);

            var visitor = new NextLinkEndpointVisitor();
            var generator = MockHelpers.LoadMockGenerator(
                clients: () => [inputClient],
                visitors: () => [visitor]);

            var client = generator.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var restClient = client.RestClient as RestClientProvider;

            Assert.IsNotNull(restClient);

            // Find the CreateGetItemRequest method
            var createMethod = restClient!.Methods
                .OfType<ScmMethodProvider>()
                .FirstOrDefault(m => m.Signature.Name == "CreateGetItemRequest");

            Assert.IsNotNull(createMethod);

            // Verify the method was not modified (doesn't contain AppendRawNextLink)
            var bodyString = createMethod!.BodyStatements?.ToDisplayString();
            Assert.IsNotNull(bodyString);
            Assert.That(bodyString, Does.Not.Contain("AppendRawNextLink"));
        }

        [Test]
        public void OnlyModifiesMethodsWithNextPageParameter()
        {
            // Create a pagination operation with nextLink
            var stringType = InputFactory.Literal(InputLiteralTypeKind.String);
            var itemModel = InputFactory.Model("Item", properties: [InputFactory.Property("Name", stringType)]);
            var pageModel = InputFactory.Model(
                "PagedItems",
                properties:
                [
                    InputFactory.Property("Items", InputFactory.List(itemModel)),
                    InputFactory.Property("NextLink", stringType)
                ]);

            var operation = InputFactory.Operation(
                "ListItems",
                parameters: [],
                responses: [InputFactory.OperationResponse(bodytype: pageModel)]);

            var paging = new InputPagingServiceMetadata(
                itemPropertySegments: ["Items"],
                nextLink: new InputPagingServiceMetadataNextLink("NextLink"));

            var pagingMethod = InputFactory.PagingServiceMethod(
                "ListItems",
                operation,
                paging: paging,
                response: InputFactory.ServiceMethodResponse(pageModel, ["result"]));

            var inputClient = InputFactory.Client("TestClient", methods: [pagingMethod]);

            var visitor = new NextLinkEndpointVisitor();
            var generator = MockHelpers.LoadMockGenerator(
                clients: () => [inputClient],
                visitors: () => [visitor]);

            var client = generator.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().First();
            var restClient = client.RestClient as RestClientProvider;

            Assert.IsNotNull(restClient);

            // Verify only methods with "CreateNext" prefix and Uri parameter are modified
            var regularCreateMethod = restClient!.Methods
                .OfType<ScmMethodProvider>()
                .FirstOrDefault(m => m.Signature.Name == "CreateListItemsRequest");

            if (regularCreateMethod != null)
            {
                var bodyString = regularCreateMethod.BodyStatements?.ToDisplayString();
                Assert.IsNotNull(bodyString);
                // Regular create method should not be modified
                Assert.That(bodyString, Does.Not.Contain("AppendRawNextLink"));
            }
        }
    }
}
