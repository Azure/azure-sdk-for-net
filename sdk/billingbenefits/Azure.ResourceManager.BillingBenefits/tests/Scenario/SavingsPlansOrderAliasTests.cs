// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.ResourceManager.BillingBenefits.Tests.Helper;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class SavingsPlansOrderAliasTests : BillingBenefitsManagementTestBase
    {
        private BillingBenefitsSavingsPlanOrderAliasCollection _modelResource;
        private TenantResource _tenantResource;

        public SavingsPlansOrderAliasTests(bool isAsync) : base(isAsync)
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
        public async Task TestCreateAndGetSharedScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsSavingsPlanOrderAliases();
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Shared);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "mockSavingsPlanAliasTest", request);

            Assert.NotNull(createResponse);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.NotNull(createResponse.Value);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);

            var getAliasResponse = await _modelResource.GetAsync("mockSavingsPlanAliasTest");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsSavingsPlanOrderAliases();
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Single);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "mockSingleSavingsPlanAliasTestNew", request);

            Assert.NotNull(createResponse);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.NotNull(createResponse.Value);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single);

            var getAliasResponse = await _modelResource.GetAsync("mockSingleSavingsPlanAliasTestNew");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Single);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetSingleResourceGroupScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsSavingsPlanOrderAliases();
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Single);
            request.AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
            {
                ResourceGroupId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47/resourceGroups/TestRG")
            };
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "mockSingleRGSavingsPlanAliasTest", request);

            Assert.NotNull(createResponse);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.NotNull(createResponse.Value);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);

            var getAliasResponse = await _modelResource.GetAsync("mockSingleRGSavingsPlanAliasTest");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateAndGetManagementGroupScopeSavingsPlansOrderAlias()
        {
            _modelResource = _tenantResource.GetBillingBenefitsSavingsPlanOrderAliases();
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.ManagementGroup);
            var createResponse = await _modelResource.CreateOrUpdateAsync(WaitUntil.Completed, "mockManagementGroupSavingsPlanAliasTest", request);

            Assert.NotNull(createResponse);
            Assert.That(createResponse.HasCompleted, Is.True);
            Assert.That(createResponse.HasValue, Is.True);
            Assert.NotNull(createResponse.Value);
            Assert.That(createResponse.Value.HasData, Is.True);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);

            var getAliasResponse = await _modelResource.GetAsync("mockManagementGroupSavingsPlanAliasTest");

            Assert.That(getAliasResponse.GetRawResponse().Status, Is.EqualTo(200));
            ValidateResponseProperties(getAliasResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestValidateSavingsPlanOrderAliasPurchase()
        {
            _modelResource = _tenantResource.GetBillingBenefitsSavingsPlanOrderAliases();
            var model = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType.Shared);
            var requestContent = new SavingsPlanPurchaseValidateContent();
            requestContent.Benefits.Add(model);

            var response = await _tenantResource.ValidatePurchaseAsync(requestContent).ToEnumerableAsync();

            Assert.NotNull(response);
            Assert.That(response.Count, Is.EqualTo(1));
            Assert.That(response[0].IsValid, Is.True);
            Assert.That(response[0].Reason, Is.Null);
            Assert.That(response[0].ReasonCode, Is.Null);
        }

        private void ValidateResponseProperties(BillingBenefitsSavingsPlanOrderAliasData Data, BillingBenefitsAppliedScopeType scope, bool isRG = false)
        {
            if (scope == BillingBenefitsAppliedScopeType.Single)
            {
                Assert.NotNull(Data.AppliedScopeProperties);
                if (isRG)
                {
                    Assert.That(Data.AppliedScopeProperties.SubscriptionId, Is.Null);
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
                Assert.That(Data.AppliedScopeProperties, Is.Null);
            }

            Assert.That(Data.AppliedScopeType, Is.EqualTo(scope));
            Assert.That(Data.BillingPlan, Is.EqualTo(BillingBenefitsBillingPlan.P1M));
            Assert.That(Data.BillingScopeId.ToString(), Is.EqualTo("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"));
            Assert.NotNull(Data.Commitment);
            Assert.That(Data.Commitment.Amount, Is.EqualTo(0.001));
            Assert.That(Data.Commitment.CurrencyCode, Is.EqualTo("USD"));
            Assert.That(Data.Commitment.Grain, Is.EqualTo(BillingBenefitsCommitmentGrain.Hourly));
            Assert.NotNull(Data.Id);
            Assert.IsNotEmpty(Data.Name);
            Assert.IsNotEmpty(Data.DisplayName);
            Assert.NotNull(Data.ResourceType);
            Assert.That(Data.ResourceType.Namespace, Is.EqualTo("Microsoft.BillingBenefits"));
            Assert.That(Data.ResourceType.Type, Is.EqualTo("savingsPlanOrderAliases"));
            Assert.That(Data.ProvisioningState, Is.EqualTo(BillingBenefitsProvisioningState.Created));
            Assert.IsNotEmpty(Data.SavingsPlanOrderId);
            Assert.NotNull(Data.Sku);
            Assert.That(Data.Sku.Name, Is.EqualTo("Compute_Savings_Plan"));
            Assert.That(Data.SkuName, Is.EqualTo("Compute_Savings_Plan"));
            Assert.That(Data.Term, Is.EqualTo(BillingBenefitsTerm.P3Y));
        }
    }
}
