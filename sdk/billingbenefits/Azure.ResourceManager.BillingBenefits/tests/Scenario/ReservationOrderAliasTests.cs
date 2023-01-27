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
        private BillingBenefitsReservationOrderAliasCollection _modelResource;
        private TenantResource _tenantResource;

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
            _modelResource = _tenantResource.GetBillingBenefitsReservationOrderAliases();
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Shared);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "testReservationOrderAliasMock", request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMock");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsReservationOrderAliases();
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Single);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "testReservationOrderAliasMockSingle", request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMockSingle");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Single);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleResourceGroupScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsReservationOrderAliases();
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Single);
            request.AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
            {
                ResourceGroupId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47/resourceGroups/TestRG")
            };
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "testReservationOrderAliasMockSingleRG", request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMockSingleRG");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetManagementGroupScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsReservationOrderAliases();
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.ManagementGroup);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "testReservationOrderAliasMockManagementGroup", request);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMockManagementGroup");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);
        }

        private void ValidateResponseProperties(BillingBenefitsReservationOrderAliasData Data, BillingBenefitsAppliedScopeType scope, bool isRG = false)
        {
            if (scope == BillingBenefitsAppliedScopeType.Single)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                if (isRG)
                {
                    Assert.IsNull(Data.AppliedScopeProperties.SubscriptionId);
                    Assert.IsNotEmpty(Data.AppliedScopeProperties.ResourceGroupId);
                }
                else
                {
                    Assert.IsNotEmpty(Data.AppliedScopeProperties.SubscriptionId);
                }
            }
            else if (scope == BillingBenefitsAppliedScopeType.ManagementGroup)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                Assert.IsNotEmpty(Data.AppliedScopeProperties.ManagementGroupId);
            }
            else
            {
                Assert.Null(Data.AppliedScopeProperties);
            }

            Assert.AreEqual(scope, Data.AppliedScopeType);
            Assert.AreEqual(BillingBenefitsBillingPlan.P1M, Data.BillingPlan);
            Assert.AreEqual("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47", Data.BillingScopeId.ToString());
            Assert.IsNotEmpty(Data.Id);
            Assert.IsNotEmpty(Data.Name);
            Assert.IsNotEmpty(Data.DisplayName);
            Assert.NotNull(Data.ResourceType);
            Assert.AreEqual("Microsoft.BillingBenefits", Data.ResourceType.Namespace);
            Assert.AreEqual("reservationOrderAliases", Data.ResourceType.Type);
            Assert.AreEqual(BillingBenefitsProvisioningState.Created, Data.ProvisioningState);
            Assert.IsNotEmpty(Data.ReservationOrderId);
            Assert.NotNull(Data.Sku);
            Assert.AreEqual("Standard_B1s", Data.Sku.Name);
            Assert.AreEqual("Standard_B1s", Data.SkuName);
            Assert.AreEqual(BillingBenefitsTerm.P3Y, Data.Term);
            Assert.AreEqual(1, Data.Quantity);
            Assert.AreEqual(AzureLocation.EastUS, Data.Location);
            Assert.AreEqual(BillingBenefitsReservedResourceType.VirtualMachines, Data.ReservedResourceType);
            Assert.AreEqual(BillingBenefitsInstanceFlexibility.On, Data.ReservedResourceInstanceFlexibility);
            Assert.False(Data.IsRenewed);
        }
    }
}
