// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Rest.Azure;
    using Xunit;

    public sealed class SearchServiceTests : SearchTestBase<ResourceGroupFixture>
    {
        private const string InvalidServiceName = "----badname";

        [Fact]
        public void CanListServices()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                SearchService service1 = CreateFreeService(searchMgmt);
                SearchService service2 = CreateFreeService(searchMgmt);

                var services = searchMgmt.Services.ListByResourceGroup(Data.ResourceGroupName);
                Assert.NotNull(services);
                Assert.Equal(2, services.Count());
                Assert.Contains(service1.Name, services.Select(s => s.Name));
                Assert.Contains(service2.Name, services.Select(s => s.Name));
            });
        }

        [Fact]
        public void CanListServicesBySubscription()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service1 = CreateFreeService(searchMgmt);
                SearchService service2 = CreateFreeService(searchMgmt);

                var services = searchMgmt.Services.ListBySubscription();
                Assert.NotNull(services);
                Assert.Equal(2, services.Count());
                Assert.Contains(service1.Name, services.Select(s => s.Name));
                Assert.Contains(service2.Name, services.Select(s => s.Name));
            });
        }

        [Fact]
        public void CanCreateAndDeleteService()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateFreeService(searchMgmt);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);

                Assert.Empty(searchMgmt.Services.ListByResourceGroup(Data.ResourceGroupName));
            });
        }

        [Fact]
        public void CanCreateAndGetService()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService originalService = CreateFreeService(searchMgmt);

                SearchService service = searchMgmt.Services.Get(Data.ResourceGroupName, originalService.Name);

                AssertServicesEqual(originalService, service);
            });
        }

        [Fact]
        public void DeleteServiceIsIdempotent()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateFreeService(searchMgmt);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
            });
        }

        [Fact]
        public void CheckNameAvailabilitySucceedsOnNewName()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                CheckNameAvailabilityOutput result = searchMgmt.Services.CheckNameAvailability("newservice");

                Assert.Null(result.Message);
                Assert.Null(result.Reason);
                Assert.True(result.IsNameAvailable);
            });
        }

        [Fact]
        public void CheckNameAvailabilityFailsOnUsedName()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateFreeService(searchMgmt);

                CheckNameAvailabilityOutput result = searchMgmt.Services.CheckNameAvailability(service.Name);

                Assert.Null(result.Message);
                Assert.Equal(UnavailableNameReason.AlreadyExists, result.Reason);
                Assert.False(result.IsNameAvailable);
            });
        }

        [Fact]
        public void CheckNameAvailabilityFailsOnInvalidName()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                CheckNameAvailabilityOutput result =
                    searchMgmt.Services.CheckNameAvailability(InvalidServiceName);

                Assert.False(string.IsNullOrEmpty(result.Message));
                Assert.Equal(UnavailableNameReason.Invalid, result.Reason);
                Assert.False(result.IsNameAvailable);
            });
        }

        [Fact]
        public void CanCreateBasicService()
        {
            Run(() => TestCreateServiceForSku(SkuName.Basic));
        }

        [Fact]
        public void CanCreateStandardService()
        {
            Run(() => TestCreateServiceForSku(SkuName.Standard));
        }

        [Fact]
        public void CanCreateStandard2Service()
        {
            Run(() => TestCreateServiceForSku(SkuName.Standard2));
        }

        [Fact]
        public void CanCreateStandard3Service()
        {
            Run(() =>
            {
                SearchService service = DefineServiceWithSku(SkuName.Standard3);
                service.HostingMode = HostingMode.Default;

                TestCreateService(service);
            });
        }

        [Fact]
        public void CanCreateStandard3HighDensityService()
        {
            Run(() =>
            {
                SearchService service = DefineServiceWithSku(SkuName.Standard3);
                service.HostingMode = HostingMode.HighDensity;

                TestCreateService(service);
            });
        }

        [Fact]
        public void CanCreateStorageOptimizedL1Service()
        {
            Run(() => TestCreateServiceForSku(SkuName.StorageOptimizedL1));
        }

        [Fact]
        public void CanCreateStorageOptimizedL2Service()
        {
            Run(() => TestCreateServiceForSku(SkuName.StorageOptimizedL2));
        }

        [Fact]
        public void CanScaleServiceUpAndDown()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateServiceForSku(searchMgmt, SkuName.Standard);

                WaitForProvisioningToComplete(searchMgmt, service);

                // Scale up to 2 replicas x 2 partitions.
                service =
                    searchMgmt.Services.Update(
                        Data.ResourceGroupName, 
                        service.Name, 
                        new SearchService() { ReplicaCount = 2, PartitionCount = 2 });

                service = WaitForProvisioningToComplete(searchMgmt, service);
                Assert.Equal(2, service.ReplicaCount);
                Assert.Equal(2, service.PartitionCount);

                // Scale back down to 1 replica x 1 partition.
                service =
                    searchMgmt.Services.Update(
                        Data.ResourceGroupName, 
                        service.Name, 
                        new SearchService() { ReplicaCount = 1, PartitionCount = 1 });

                service = WaitForProvisioningToComplete(searchMgmt, service);
                Assert.Equal(1, service.ReplicaCount);
                Assert.Equal(1, service.PartitionCount);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
            });
        }

        [Fact]
        public void CreateStandardServicePollsAutomatically()
        {
            Run(() =>
            {
                // Create an S1 with multiple replicas so that the operation will take some time.
                SearchService service = DefineServiceWithSku(SkuName.Standard);
                service.ReplicaCount = 2;

                SearchManagementClient searchMgmt = GetSearchManagementClient();
                string serviceName = SearchTestUtilities.GenerateServiceName();

                service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service);

                // Unlike BeginCreateOrUpdate, CreateOrUpdate should have already polled until
                // provisioning is complete.
                Assert.Equal(Models.ProvisioningState.Succeeded, service.ProvisioningState);
                Assert.Equal(SearchServiceStatus.Running, service.Status);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
            });
        }

        [Fact]
        public void CanUpdateTags()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateFreeService(searchMgmt);

                var testTags =
                    new Dictionary<string, string>()
                    {
                        ["testTag"] = "testValue",
                        ["anotherTag"] = "anotherValue"
                    };

                // Add some tags.
                service =
                    searchMgmt.Services.Update(
                        Data.ResourceGroupName,
                        service.Name,
                        new SearchService() { Tags = testTags });

                Assert.Equal(testTags, service.Tags);

                // Modify a tag.
                testTags["anotherTag"] = "differentValue";

                service =
                    searchMgmt.Services.Update(
                        Data.ResourceGroupName,
                        service.Name,
                        new SearchService() { Tags = testTags });

                Assert.Equal(testTags, service.Tags);

                // Remove the second tag.
                testTags.Remove("anotherTag");

                service =
                    searchMgmt.Services.Update(
                        Data.ResourceGroupName,
                        service.Name,
                        new SearchService() { Tags = testTags });

                Assert.Equal(testTags, service.Tags);
            });
        }

        [Fact]
        public void UpdatingImmutablePropertiesThrowsCloudException()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateFreeService(searchMgmt);

                CloudException e =
                    Assert.Throws<CloudException>(() =>
                        searchMgmt.Services.Update(
                            Data.ResourceGroupName,
                            service.Name,
                            new SearchService() { HostingMode = HostingMode.HighDensity }));

                Assert.Equal("Updating HostingMode of an existing search service is not allowed.", e.Message);

                // There is currently a validation bug in the Azure Search management API, so we can't
                // test for an exception yet. Instead, just make sure the location doesn't actually change.
                SearchService updatedService =
                    searchMgmt.Services.Update(
                        Data.ResourceGroupName,
                        service.Name,
                        new SearchService() { Location = "East US" });  // We run live tests in West US.

                Assert.Equal(service.Location, updatedService.Location);

                /*e =
                    Assert.Throws<CloudException>(() =>
                        searchMgmt.Services.Update(
                            Data.ResourceGroupName,
                            service.Name,
                            new SearchService() { Location = "East US" }));  // We run live tests in West US.

                    Assert.Equal("Updating Location of an existing search service is not allowed.", e.Message);*/

                e =
                    Assert.Throws<CloudException>(() =>
                        searchMgmt.Services.Update(
                            Data.ResourceGroupName,
                            service.Name,
                            new SearchService() { Sku = new Sku(SkuName.Basic) }));

                Assert.Equal("Updating Sku of an existing search service is not allowed.", e.Message);
            });
        }

        [Fact]
        public void CreateServiceWithInvalidNameGivesUsefulMessage()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = DefineServiceWithSku(SkuName.Free);

                CloudException e =
                    Assert.Throws<CloudException>(() =>
                        searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, InvalidServiceName, service));

                string expectedMessage = 
                    $"Service name '{InvalidServiceName}' is invalid: Service name must only contain " +
                    "lowercase letters, digits or dashes, cannot start or end with or contain consecutive " +
                    "dashes and is limited to 60 characters.";

                Assert.Equal(expectedMessage, e.Message);
            });
        }

        [Fact]
        public void UpdateServiceWithInvalidNameGivesNotFound()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                CloudException e =
                    Assert.Throws<CloudException>(() =>
                        searchMgmt.Services.Update(Data.ResourceGroupName, "missing", new SearchService()));

                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
            });
        }

        [Fact]
        public void CanCreateServiceWithIdentity()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                string serviceName = SearchTestUtilities.GenerateServiceName();
                SearchService service = DefineServiceWithSku(SkuName.Basic);
                service.Identity = new Identity(IdentityType.SystemAssigned);
                service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service);
                Assert.NotNull(service);
                Assert.NotNull(service.Identity);
                Assert.Equal(IdentityType.SystemAssigned, service.Identity.Type);

                string principalId = string.IsNullOrWhiteSpace(service.Identity.PrincipalId) ? null : service.Identity.PrincipalId;
                Assert.NotNull(principalId);

                string tenantId = string.IsNullOrWhiteSpace(service.Identity.TenantId) ? null : service.Identity.TenantId;
                Assert.NotNull(tenantId);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
            });
        }

        [Fact]
        public void CanAddAndRemoveServiceIdentity()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                string serviceName = SearchTestUtilities.GenerateServiceName();
                SearchService service = DefineServiceWithSku(SkuName.Basic);
                service.Identity = null;
                service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service);
                Assert.NotNull(service);
                Assert.Equal(IdentityType.None, service.Identity?.Type ?? IdentityType.None);

                // assign an identity of type 'SystemAssigned'
                service.Identity = new Identity(IdentityType.SystemAssigned);
                service = searchMgmt.Services.Update(Data.ResourceGroupName, service.Name, service);
                Assert.NotNull(service);
                Assert.NotNull(service.Identity);
                Assert.Equal(IdentityType.SystemAssigned, service.Identity.Type);

                string principalId = string.IsNullOrWhiteSpace(service.Identity.PrincipalId) ? null : service.Identity.PrincipalId;
                Assert.NotNull(principalId);

                string tenantId = string.IsNullOrWhiteSpace(service.Identity.TenantId) ? null : service.Identity.TenantId;
                Assert.NotNull(tenantId);

                // remove the identity by setting it's type to 'None'
                service.Identity.Type = IdentityType.None;
                service = searchMgmt.Services.Update(Data.ResourceGroupName, service.Name, service);
                Assert.NotNull(service);
                Assert.Equal(IdentityType.None, service.Identity?.Type ?? IdentityType.None);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
            });
        }

        [Fact]
        public void CannotCreateOrUpdateFreeServiceWithIdentity()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                string serviceName = SearchTestUtilities.GenerateServiceName();
                SearchService service = DefineServiceWithSku(SkuName.Free);
                service.Identity = new Identity(IdentityType.SystemAssigned);

                CloudException e = Assert.Throws<CloudException>(() => 
                    searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service));

                Assert.Equal("Resource identity is not supported for the selected SKU", e.Message);

                // retry create without identity
                service.Identity = null;
                service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service);
                Assert.NotNull(service);
                Assert.Null(service.Identity);

                // try update the created service by defining an identity
                service.Identity = new Identity();
                e = Assert.Throws<CloudException>(() =>
                    searchMgmt.Services.Update(Data.ResourceGroupName, service.Name, service));

                Assert.Equal("Resource identity is not supported for the selected SKU", e.Message);
                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
            });
        }

        [Fact]
        public void CanCreateServiceInPrivateMode()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                CreateServiceForSkuWithDefinitionTemplate(searchMgmt, SkuName.Basic, DefineServiceWithSkuInPrivateMode);
            });
        }

        private static void AssertServicesEqual(SearchService a, SearchService b) =>
            Assert.Equal(a, b, new ModelComparer<SearchService>());

        private SearchService DefineServiceWithSku(SkuName sku)
        {
            return new SearchService()
            {
                Location = "EastUS",
                Sku = new Sku() { Name = sku },
                ReplicaCount = 1,
                PartitionCount = 1
            };
        }

        private SearchService DefineServiceWithSkuInPrivateMode(SkuName sku)
        {
            return new SearchService()
            {
                Location = "EastUS",
                Sku = new Sku() { Name = sku },
                ReplicaCount = 1,
                PartitionCount = 1,
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
        }

        private SearchService CreateServiceForSku(SearchManagementClient searchMgmt, SkuName sku)
        {
            string serviceName = SearchTestUtilities.GenerateServiceName();

            SearchService service = DefineServiceWithSku(sku);

            service = searchMgmt.Services.BeginCreateOrUpdate(Data.ResourceGroupName, serviceName, service);
            Assert.NotNull(service);

            return service;
        }

        private delegate SearchService SearchServiceDefinition(SkuName sku);

        private SearchService CreateServiceForSkuWithDefinitionTemplate(SearchManagementClient searchMgmt, SkuName sku, SearchServiceDefinition searchServiceDefinition)
        {
            string serviceName = SearchTestUtilities.GenerateServiceName();

            SearchService service = searchServiceDefinition(sku);

            service = searchMgmt.Services.BeginCreateOrUpdate(Data.ResourceGroupName, serviceName, service);
            Assert.NotNull(service);

            return service;
        }

        private SearchService CreateFreeService(SearchManagementClient searchMgmt) =>
            CreateServiceForSku(searchMgmt, SkuName.Free);

        private void TestCreateService(SearchService service)
        {
            SearchManagementClient searchMgmt = GetSearchManagementClient();
            string serviceName = SearchTestUtilities.GenerateServiceName();

            service = searchMgmt.Services.BeginCreateOrUpdate(Data.ResourceGroupName, serviceName, service);
            service = WaitForProvisioningToComplete(searchMgmt, service);

            searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
        }

        private SearchService WaitForProvisioningToComplete(
            SearchManagementClient searchMgmt, 
            SearchService service)
        {
            while (service.ProvisioningState == Models.ProvisioningState.Provisioning)
            {
                Assert.Equal(SearchServiceStatus.Provisioning, service.Status);

                SearchTestUtilities.WaitForServiceProvisioning();
                service = searchMgmt.Services.Get(Data.ResourceGroupName, service.Name);
            }

            Assert.Equal(Models.ProvisioningState.Succeeded, service.ProvisioningState);
            Assert.Equal(SearchServiceStatus.Running, service.Status);
            return service;
        }

        private void TestCreateServiceForSku(SkuName sku) => TestCreateService(DefineServiceWithSku(sku));
    }
}
