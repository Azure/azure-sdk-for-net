// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits.Tests.Helper;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class ReservationOrderAliasTests : BillingBenefitsManagementTestBase
    {
        private ReservationOrderAliasModelResource _modelResource { get; set; }
        private TenantResource _tenantResource { get; set; }

        public ReservationOrderAliasTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();

                AsyncPageable<TenantResource> tenantResourcesResponse = Client.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                _tenantResource = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSharedScopeReservationOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMock");
            _modelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(AppliedScopeType.Shared);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.Shared);

            var getAliasResponse = await _modelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.Shared);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleScopeSavingsPlansOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMockSingle");
            _modelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(AppliedScopeType.Single);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.Single);

            var getAliasResponse = await _modelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.Single);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleResourceGroupScopeSavingsPlansOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMockSingleRG");
            _modelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(AppliedScopeType.Single);
            request.AppliedScopeProperties = new AppliedScopeProperties
            {
                ResourceGroupId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47/resourceGroups/TestRG"
            };
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.Single, true);

            var getAliasResponse = await _modelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.Single, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetManagementGroupScopeSavingsPlansOrderAlias()
        {
            var resource = ReservationOrderAliasModelResource.CreateResourceIdentifier("testReservationOrderAliasMockManagementGroup");
            _modelResource = Client.GetReservationOrderAliasModelResource(resource);
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(AppliedScopeType.ManagementGroup);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, AppliedScopeType.ManagementGroup);

            var getAliasResponse = await _modelResource.GetAsync();

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, AppliedScopeType.ManagementGroup);
        }

        private void ValidateResponseProperties(ReservationOrderAliasModelData Data, AppliedScopeType scope, bool isRG = false)
        {
            if (scope == AppliedScopeType.Single)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                if (isRG)
                {
                    Assert.IsEmpty(Data.AppliedScopeProperties.SubscriptionId);
                    Assert.IsNotEmpty(Data.AppliedScopeProperties.ResourceGroupId);
                }
                else
                {
                    Assert.IsNotEmpty(Data.AppliedScopeProperties.SubscriptionId);
                }
            }
            else if (scope == AppliedScopeType.ManagementGroup)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                Assert.IsNotEmpty(Data.AppliedScopeProperties.ManagementGroupId);
            }
            else
            {
                Assert.Null(Data.AppliedScopeProperties);
            }

            Assert.AreEqual(scope, Data.AppliedScopeType);
            Assert.AreEqual(BillingPlan.P1M, Data.BillingPlan);
            Assert.AreEqual("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47", Data.BillingScopeId);
            Assert.IsNotEmpty(Data.Id);
            Assert.IsNotEmpty(Data.Name);
            Assert.IsNotEmpty(Data.DisplayName);
            Assert.NotNull(Data.ResourceType);
            Assert.AreEqual("Microsoft.BillingBenefits", Data.ResourceType.Namespace);
            Assert.AreEqual("reservationOrderAliases", Data.ResourceType.Type);
            Assert.AreEqual(ProvisioningState.Created, Data.ProvisioningState);
            Assert.IsNotEmpty(Data.ReservationOrderId);
            Assert.NotNull(Data.Sku);
            Assert.AreEqual("Standard_B1s", Data.Sku.Name);
            Assert.AreEqual("Standard_B1s", Data.SkuName);
            Assert.AreEqual(Term.P3Y, Data.Term);
            Assert.AreEqual(1, Data.Quantity);
            Assert.AreEqual(AzureLocation.EastUS, Data.Location);
            Assert.AreEqual(ReservedResourceType.VirtualMachines, Data.ReservedResourceType);
            Assert.AreEqual(InstanceFlexibility.On, Data.ReservedResourceInstanceFlexibility);
            Assert.False(Data.Renew);
        }
    }
}
