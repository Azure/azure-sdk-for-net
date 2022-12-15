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
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Shared);

            var getAliasResponse = await _modelResource.GetAsync("mockSavingsPlanAliasTest");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
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
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single);

            var getAliasResponse = await _modelResource.GetAsync("mockSingleSavingsPlanAliasTestNew");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
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
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.Single, true);

            var getAliasResponse = await _modelResource.GetAsync("mockSingleRGSavingsPlanAliasTest");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
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
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.NotNull(createResponse.Value);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.NotNull(createResponse.Value.Data);

            ValidateResponseProperties(createResponse.Value.Data, BillingBenefitsAppliedScopeType.ManagementGroup);

            var getAliasResponse = await _modelResource.GetAsync("mockManagementGroupSavingsPlanAliasTest");

            Assert.AreEqual(200, getAliasResponse.GetRawResponse().Status);
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
            Assert.AreEqual(1, response.Count);
            Assert.IsTrue(response[0].IsValid);
            Assert.Null(response[0].Reason);
            Assert.Null(response[0].ReasonCode);
        }

        private void ValidateResponseProperties(BillingBenefitsSavingsPlanOrderAliasData Data, BillingBenefitsAppliedScopeType scope, bool isRG = false)
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
            Assert.NotNull(Data.Commitment);
            Assert.AreEqual(0.001, Data.Commitment.Amount);
            Assert.AreEqual("USD", Data.Commitment.CurrencyCode);
            Assert.AreEqual(BillingBenefitsCommitmentGrain.Hourly, Data.Commitment.Grain);
            Assert.NotNull(Data.Id);
            Assert.IsNotEmpty(Data.Name);
            Assert.IsNotEmpty(Data.DisplayName);
            Assert.NotNull(Data.ResourceType);
            Assert.AreEqual("Microsoft.BillingBenefits", Data.ResourceType.Namespace);
            Assert.AreEqual("savingsPlanOrderAliases", Data.ResourceType.Type);
            Assert.AreEqual(BillingBenefitsProvisioningState.Created, Data.ProvisioningState);
            Assert.IsNotEmpty(Data.SavingsPlanOrderId);
            Assert.NotNull(Data.Sku);
            Assert.AreEqual("Compute_Savings_Plan", Data.Sku.Name);
            Assert.AreEqual("Compute_Savings_Plan", Data.SkuName);
            Assert.AreEqual(BillingBenefitsTerm.P3Y, Data.Term);
        }
    }
}
