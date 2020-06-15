// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using System.Linq;
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    public sealed class OperationsTests : SearchTestBase<ResourceGroupFixture>
    {
        [Fact]
        public void ListOperationsReturnsExpectedOperations()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                var expectedCoreOperations = new[]
                {
                    new Operation(
                        name: "Microsoft.Search/register/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            operation: "Register the Search Resource Provider",
                            resource: "Search Services",
                            description: "Registers the subscription for the search resource provider and enables the creation of search services.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/write",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Set Search Service",
                            description: "Creates or updates the search service.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/read",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Get Search Service",
                            description: "Reads the search service.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/delete",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Delete Search Service",
                            description: "Deletes the search service.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/listAdminKeys/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Get Admin Key",
                            description: "Reads the admin keys.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/regenerateAdminKey/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Regenerate Admin Key",
                            description: "Regenerates the admin key.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/listQueryKeys/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "API Keys",
                            operation: "Get Query Keys",
                            description: "Returns the list of query API keys for the given Azure Search service.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/createQueryKey/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Create Query Key",
                            description: "Creates the query key.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/deleteQueryKey/delete",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "API Keys",
                            operation: "Delete Query Key",
                            description: "Deletes the query key.")),
                    new Operation(
                        name: "Microsoft.Search/checkNameAvailability/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Service Name Availability",
                            operation: "Check Service Name Availability",
                            description: "Checks availability of the service name.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/privateEndpointConnectionProxies/validate/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Private Endpoint Connection Proxy",
                            operation: "Validate Private Endpoint Connection Proxy",
                            description: "Validates a private endpoint connection create call from NRP side")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/privateEndpointConnectionProxies/write",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Private Endpoint Connection Proxy",
                            operation: "Create Private Endpoint Connection Proxy",
                            description: "Creates a private endpoint connection proxy with the specified parameters or updates the properties or tags for the specified private endpoint connection proxy")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/privateEndpointConnectionProxies/read",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Private Endpoint Connection Proxy",
                            operation: "Get Private Endpoint Connection Proxy",
                            description: "Returns the list of private endpoint connection proxies or gets the properties for the specified private endpoint connection proxy")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/privateEndpointConnectionProxies/delete",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Private Endpoint Connection Proxy",
                            operation: "Delete Private Endpoint Connection Proxy",
                            description: "Deletes an existing private endpoint connection proxy"))
                };

                Operation[] actualOperations = searchMgmt.Operations.List().ToArray();

                // There may be more operations than just the core ones expected by this test, but we don't
                // want to break SDK tests every time we add a new operation.
                foreach (Operation expectedCoreOperation in expectedCoreOperations)
                {
                    Assert.Contains(expectedCoreOperation, actualOperations, new ModelComparer<Operation>());
                }
            });
        }
    }
}
