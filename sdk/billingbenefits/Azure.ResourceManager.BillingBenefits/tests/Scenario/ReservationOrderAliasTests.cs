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

            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.That(createResponse.Value, Is.Not.Null);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.That(createResponse.Value.Data, Is.Not.Null);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMock");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsReservationOrderAliases();
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Single);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "testReservationOrderAliasMockSingle", request);

            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.That(createResponse.Value, Is.Not.Null);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.That(createResponse.Value.Data, Is.Not.Null);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMockSingle");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
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

            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.That(createResponse.Value, Is.Not.Null);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.That(createResponse.Value.Data, Is.Not.Null);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMockSingleRG");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetManagementGroupScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsReservationOrderAliases();
            var request = TestHelpers.CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.ManagementGroup);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "testReservationOrderAliasMockManagementGroup", request);

            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.That(createResponse.Value, Is.Not.Null);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.That(createResponse.Value.Data, Is.Not.Null);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);

            var getAliasResponse = await _modelResource.GetAsync("testReservationOrderAliasMockManagementGroup");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);
        }

        private void ValidateResponseProperties(BillingBenefitsReservationOrderAliasData Data, BillingBenefitsAppliedScopeType scope, bool isRG = false)
        {
            if (scope == BillingBenefitsAppliedScopeType.Single)
            {
                Assert.That(Data.AppliedScopeProperties, Is.Not.Null);
                if (isRG)
                {
                    Assert.That(Data.AppliedScopeProperties.SubscriptionId, Is.Null);
                    Assert.That((string)Data.AppliedScopeProperties.ResourceGroupId, Is.Not.Empty);
                }
                else
                {
                    Assert.That((string)Data.AppliedScopeProperties.SubscriptionId, Is.Not.Empty);
                }
            }
            else if (scope == BillingBenefitsAppliedScopeType.ManagementGroup)
            {
                Assert.That(Data.AppliedScopeProperties, Is.Not.Null);
                Assert.That((string)Data.AppliedScopeProperties.ManagementGroupId, Is.Not.Empty);
            }
            else
            {
                Assert.That(Data.AppliedScopeProperties, Is.Null);
            }

            Assert.That(Data.AppliedScopeType, Is.EqualTo(scope));
            Assert.That(Data.BillingPlan, Is.EqualTo(BillingBenefitsBillingPlan.P1M));
            Assert.That(Data.BillingScopeId.ToString(), Is.EqualTo("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"));
            Assert.That((string)Data.Id, Is.Not.Empty);
            Assert.That(Data.Name, Is.Not.Empty);
            Assert.That(Data.DisplayName, Is.Not.Empty);
            Assert.That(Data.ResourceType, Is.Not.Null);
            Assert.That(Data.ResourceType.Namespace, Is.EqualTo("Microsoft.BillingBenefits"));
            Assert.That(Data.ResourceType.Type, Is.EqualTo("reservationOrderAliases"));
            Assert.That(Data.ProvisioningState, Is.EqualTo(BillingBenefitsProvisioningState.Created));
            Assert.That((string)Data.ReservationOrderId, Is.Not.Empty);
            Assert.That(Data.Sku, Is.Not.Null);
            Assert.That(Data.Sku.Name, Is.EqualTo("Standard_B1s"));
            Assert.That(Data.SkuName, Is.EqualTo("Standard_B1s"));
            Assert.That(Data.Term, Is.EqualTo(BillingBenefitsTerm.P3Y));
            Assert.That(Data.Quantity, Is.EqualTo(1));
            Assert.That(Data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(Data.ReservedResourceType, Is.EqualTo(BillingBenefitsReservedResourceType.VirtualMachines));
            Assert.That(Data.ReservedResourceInstanceFlexibility, Is.EqualTo(BillingBenefitsInstanceFlexibility.On));
            Assert.That(Data.IsRenewed, Is.False);
        }
    }
}
