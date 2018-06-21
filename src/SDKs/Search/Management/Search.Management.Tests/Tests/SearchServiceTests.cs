// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using System.Linq;
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

                CheckNameAvailabilityOutput result = searchMgmt.Services.CheckNameAvailability(InvalidServiceName);

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
        public void CanScaleServiceUpAndDown()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                SearchService service = CreateServiceForSku(searchMgmt, SkuName.Basic);

                service = WaitForProvisioningToComplete(searchMgmt, service);

                // Scale up to 2 replicas.
                service.ReplicaCount = 2;
                service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, service.Name, service);
                service = WaitForProvisioningToComplete(searchMgmt, service);
                Assert.Equal(2, service.ReplicaCount);

                // Scale back down to 1 replica.
                service.ReplicaCount = 1;
                service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, service.Name, service);
                service = WaitForProvisioningToComplete(searchMgmt, service);
                Assert.Equal(1, service.ReplicaCount);

                searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
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
                    Assert.Throws<CloudException>(() => searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, InvalidServiceName, service));

                string expectedMessage = 
                    $"Service name '{InvalidServiceName}' is invalid: Service name must only contain lowercase letters, digits or dashes, cannot " +
                    "start or end with or contain consecutive dashes and is limited to 60 characters.";

                Assert.Equal(expectedMessage, e.Message);
            });
        }

        private static void AssertServicesEqual(SearchService a, SearchService b) => Assert.Equal(a, b, new ModelComparer<SearchService>());

        private SearchService DefineServiceWithSku(SkuName sku)
        {
            return new SearchService()
            {
                Location = Data.Location,
                Sku = new Sku() { Name = sku },
                ReplicaCount = 1,
                PartitionCount = 1
            };
        }

        private SearchService CreateServiceForSku(SearchManagementClient searchMgmt, SkuName sku)
        {
            string serviceName = SearchTestUtilities.GenerateServiceName();

            SearchService service = DefineServiceWithSku(sku);

            service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service);
            Assert.NotNull(service);

            return service;
        }

        private SearchService CreateFreeService(SearchManagementClient searchMgmt) => CreateServiceForSku(searchMgmt, SkuName.Free);

        private void TestCreateService(SearchService service)
        {
            SearchManagementClient searchMgmt = GetSearchManagementClient();
            string serviceName = SearchTestUtilities.GenerateServiceName();

            service = searchMgmt.Services.CreateOrUpdate(Data.ResourceGroupName, serviceName, service);
            service = WaitForProvisioningToComplete(searchMgmt, service);

            searchMgmt.Services.Delete(Data.ResourceGroupName, service.Name);
        }

        private SearchService WaitForProvisioningToComplete(SearchManagementClient searchMgmt, SearchService service)
        {
            while (service.ProvisioningState == ProvisioningState.Provisioning)
            {
                Assert.Equal(SearchServiceStatus.Provisioning, service.Status);

                SearchTestUtilities.WaitForServiceProvisioning();
                service = searchMgmt.Services.Get(Data.ResourceGroupName, service.Name);
            }

            Assert.Equal(ProvisioningState.Succeeded, service.ProvisioningState);
            Assert.Equal(SearchServiceStatus.Running, service.Status);
            return service;
        }

        private void TestCreateServiceForSku(SkuName sku) => TestCreateService(DefineServiceWithSku(sku));
    }
}
