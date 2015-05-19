// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Management.Search.Tests
{
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
                            Sku = new Sku(SkuType.Free),
                            ReplicaCount = 1,
                            PartitionCount = 1
                        }
                    };

                SearchServiceCreateOrUpdateResponse createServiceResponse =
                    searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName1, createServiceParameters);
                Assert.Equal(HttpStatusCode.Created, createServiceResponse.StatusCode);

                createServiceResponse =
                    searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName2, createServiceParameters);
                Assert.Equal(HttpStatusCode.Created, createServiceResponse.StatusCode);

                SearchServiceListResponse servicesListResponse = searchMgmt.Services.List(Data.ResourceGroupName);
                Assert.Equal(HttpStatusCode.OK, servicesListResponse.StatusCode);
                Assert.Equal(2, servicesListResponse.Services.Count);
                Assert.Contains(serviceName1, servicesListResponse.Services.Select(s => s.Name));
                Assert.Contains(serviceName2, servicesListResponse.Services.Select(s => s.Name));
            });
        }
    }
}
