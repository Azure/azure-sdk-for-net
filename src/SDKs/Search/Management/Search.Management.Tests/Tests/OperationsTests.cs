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
                        name: "Microsoft.Search/searchServices/queryKey/read",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "API Keys",
                            operation: "Get Query Key",
                            description: "Reads the query keys.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/createQueryKey/action",
                        display: new OperationDisplay(
                            provider: "Microsoft Search",
                            resource: "Search Services",
                            operation: "Create Query Key",
                            description: "Creates the query key.")),
                    new Operation(
                        name: "Microsoft.Search/searchServices/queryKey/delete",
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
                            description: "Checks availability of the service name."))
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
