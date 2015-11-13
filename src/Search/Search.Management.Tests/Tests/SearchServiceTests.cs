// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using System.Linq;
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    public sealed class SearchServiceTests : SearchTestBase<ResourceGroupFixture>
    {
        [Fact]
        public void CanListServices()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                string serviceName1 = SearchTestUtilities.GenerateServiceName();
                string serviceName2 = SearchTestUtilities.GenerateServiceName();

                var createServiceParameters =
                    new SearchServiceCreateOrUpdateParameters()
                    {
                        Location = Data.Location,
                        Properties = new SearchServiceProperties()
                        {
                            Sku = new Sku() { Name = SkuType.Free },
                            ReplicaCount = 1,
                            PartitionCount = 1
                        }
                    };

                SearchServiceResource service =
                    searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName1, createServiceParameters);
                Assert.NotNull(service);

                service =
                    searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName2, createServiceParameters);
                Assert.NotNull(service);

                SearchServiceListResult servicesListResult = searchMgmt.Services.List(Data.ResourceGroupName);
                Assert.NotNull(servicesListResult);
                Assert.Equal(2, servicesListResult.Value.Count);
                Assert.Contains(serviceName1, servicesListResult.Value.Select(s => s.Name));
                Assert.Contains(serviceName2, servicesListResult.Value.Select(s => s.Name));
            });
        }
    }
}
