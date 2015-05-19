//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.ResourceProviderTests
{
    using System;
    using System.Linq;
    using System.Net;
    using global::ApiManagement.Tests;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class ResourceProviderFunctionalTests
    {
        [Fact]
        public void CreateListUpdateDelete()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "CreateListUpdateDelete");

                TryCreateApiService();

                this.ApiManagementClient.RefreshAccessToken();

                // get different resource group name.
                var resourceGroupName =
                    this.ResourceManagementClient.GetResourceGroups()
                        .Where(group => !group.Name.Equals(ResourceGroupName))
                        .Select(group => group.Name)
                        .FirstOrDefault();

                if (resourceGroupName == null)
                {
                    resourceGroupName = TestUtilities.GenerateName("hydraapimresourcegroup");
                }

                // create one more Api Management service (one is already created)
                var serviceName = TestUtilities.GenerateName("hydraapimservice2");
                var createServiceParameters = new ApiServiceCreateOrUpdateParameters(
                    Location,
                    new ApiServiceProperties
                    {
                        CreatedAtUtc = DateTime.UtcNow,
                        SkuProperties = new ApiServiceSkuProperties
                        {
                            Capacity = 1,
                            SkuType = SkuType.Developer
                        },
                        AddresserEmail = "addresser@live.com",
                        PublisherEmail = "publisher@live.com",
                        PublisherName = "publisher"
                    });
                var createResponse = this.ApiManagementClient.ResourceProvider.CreateOrUpdate(resourceGroupName, serviceName, createServiceParameters);
                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

                var getResponse = this.ApiManagementClient.ResourceProvider.Get(resourceGroupName, serviceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal("Succeeded", getResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createServiceParameters.Properties.SkuProperties.Capacity, getResponse.Value.Properties.SkuProperties.Capacity);
                Assert.Equal(createServiceParameters.Properties.SkuProperties.SkuType, getResponse.Value.Properties.SkuProperties.SkuType);
                Assert.Equal(createServiceParameters.Properties.AddresserEmail, getResponse.Value.Properties.AddresserEmail);
                Assert.Equal(createServiceParameters.Properties.PublisherEmail, getResponse.Value.Properties.PublisherEmail);
                Assert.Equal(createServiceParameters.Properties.PublisherName, getResponse.Value.Properties.PublisherName);
                Assert.Equal(0, getResponse.Value.Tags.Count);

                this.ApiManagementClient.RefreshAccessToken();

                // list all services
                var listResponse = this.ApiManagementClient.ResourceProvider.List(null);
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Value);
                Assert.True(listResponse.Value.Count >= 2);
                Assert.True(listResponse.Value.Any(service => service.Name == serviceName));

                // list services only within new group
                listResponse = this.ApiManagementClient.ResourceProvider.List(resourceGroupName);
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Value);

                Assert.True(listResponse.Value.Count >= 1);
                Assert.True(listResponse.Value.Any(service => service.Name == serviceName));
                Assert.True(listResponse.Value.All(service => service.Id.Contains(resourceGroupName)));

                // update service: current implementation update only tags
                var updateRequest = new ApiServiceCreateOrUpdateParameters
                {
                    Location = Location,
                    Properties = new ApiServiceProperties // this should not change via update
                    {
                        SkuProperties = new ApiServiceSkuProperties
                        {
                            Capacity = 2,
                            SkuType = SkuType.Standard
                        },
                        AddresserEmail = "changed.addresser@live.com",
                        PublisherEmail = "changed.publisher@live.com",
                        PublisherName = "changed.publisher"
                    },
                    Tags = // only tags shoud be updated
                    {
                        {"tag1", "tag1 value"},
                        {"tag2", "tag2 value"}
                    }
                };

                var updateResponse = this.ApiManagementClient.ResourceProvider.CreateOrUpdate(resourceGroupName, serviceName,
                    updateRequest);
                Assert.NotNull(updateResponse);
                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
                Assert.NotNull(updateResponse.Value);
                Assert.Equal("Succeeded", updateResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createServiceParameters.Properties.SkuProperties.Capacity, updateResponse.Value.Properties.SkuProperties.Capacity);
                Assert.Equal(createServiceParameters.Properties.SkuProperties.SkuType, updateResponse.Value.Properties.SkuProperties.SkuType);
                Assert.Equal(createServiceParameters.Properties.AddresserEmail, updateResponse.Value.Properties.AddresserEmail);
                Assert.Equal(createServiceParameters.Properties.PublisherEmail, updateResponse.Value.Properties.PublisherEmail);
                Assert.Equal(createServiceParameters.Properties.PublisherName, updateResponse.Value.Properties.PublisherName);
                Assert.Equal(2, updateResponse.Value.Tags.Count);
                Assert.Equal(1, updateResponse.Value.Tags.Count(keyValue => keyValue.Key == "tag1" && keyValue.Value == "tag1 value"));
                Assert.Equal(1, updateResponse.Value.Tags.Count(keyValue => keyValue.Key == "tag2" && keyValue.Value == "tag2 value"));

                getResponse = this.ApiManagementClient.ResourceProvider.Get(resourceGroupName, serviceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal("Succeeded", getResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createServiceParameters.Properties.SkuProperties.Capacity, getResponse.Value.Properties.SkuProperties.Capacity);
                Assert.Equal(createServiceParameters.Properties.SkuProperties.SkuType, getResponse.Value.Properties.SkuProperties.SkuType);
                Assert.Equal(createServiceParameters.Properties.AddresserEmail, getResponse.Value.Properties.AddresserEmail);
                Assert.Equal(createServiceParameters.Properties.PublisherEmail, getResponse.Value.Properties.PublisherEmail);
                Assert.Equal(createServiceParameters.Properties.PublisherName, getResponse.Value.Properties.PublisherName);
                Assert.Equal(2, getResponse.Value.Tags.Count);
                Assert.Equal(1, getResponse.Value.Tags.Count(keyValue => keyValue.Key == "tag1" && keyValue.Value == "tag1 value"));
                Assert.Equal(1, getResponse.Value.Tags.Count(keyValue => keyValue.Key == "tag2" && keyValue.Value == "tag2 value"));

                // delete service

                ApiManagementHelper.RefreshAccessToken(this.ApiManagementClient);

                var deleteResponse = this.ApiManagementClient.ResourceProvider.Delete(resourceGroupName, serviceName);
                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                try
                {
                    this.ApiManagementClient.ResourceProvider.Get(resourceGroupName, serviceName);
                    Assert.True(false, "The code should not have been executed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}