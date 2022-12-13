// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.ResourceManager.BillingBenefits.Tests.Helper;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class SavingsPlansOrderAliasTests : BillingBenefitsManagementTestBase
    {
        private SavingsPlanOrderAliasModelResource _modelResource { get; set; }
        private TenantResource _tenantResource { get; set; }

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
            var resource = SavingsPlanOrderAliasModelResource.CreateResourceIdentifier("mockSavingsPlanAliasTest");
            _modelResource = Client.GetSavingsPlanOrderAliasModelResource(resource);
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(AppliedScopeType.Shared);
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
            var resource = SavingsPlanOrderAliasModelResource.CreateResourceIdentifier("mockSingleSavingsPlanAliasTestNew");
            _modelResource = Client.GetSavingsPlanOrderAliasModelResource(resource);
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(AppliedScopeType.Single);
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
            var resource = SavingsPlanOrderAliasModelResource.CreateResourceIdentifier("mockSingleRGSavingsPlanAliasTest");
            _modelResource = Client.GetSavingsPlanOrderAliasModelResource(resource);
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(AppliedScopeType.Single);
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
            var resource = SavingsPlanOrderAliasModelResource.CreateResourceIdentifier("mockManagementGroupSavingsPlanAliasTest");
            _modelResource = Client.GetSavingsPlanOrderAliasModelResource(resource);
            var request = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(AppliedScopeType.ManagementGroup);
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

        [TestCase]
        [RecordedTest]
        public async Task TestValidateSavingsPlanOrderAliasPurchase()
        {
            var resource = SavingsPlanOrderAliasModelResource.CreateResourceIdentifier("validateTest");
            _modelResource = Client.GetSavingsPlanOrderAliasModelResource(resource);
            var model = TestHelpers.CreateSavingsPlanOrderAliasPurchaseRequest(AppliedScopeType.Shared);
            var requestContent = new SavingsPlanPurchaseValidateContent();
            requestContent.Benefits.Add(model);

            var response = await _tenantResource.ValidatePurchaseAsync(requestContent);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);
            Assert.NotNull(response.Value.Benefits);
            Assert.AreEqual(1, response.Value.Benefits.Count);
            Assert.IsTrue(response.Value.Benefits[0].Valid);
            Assert.Null(response.Value.Benefits[0].Reason);
            Assert.Null(response.Value.Benefits[0].ReasonCode);
        }

        private void ValidateResponseProperties(SavingsPlanOrderAliasModelData Data, AppliedScopeType scope, bool isRG = false)
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
            Assert.NotNull(Data.Commitment);
            Assert.AreEqual(0.001, Data.Commitment.Amount);
            Assert.AreEqual("USD", Data.Commitment.CurrencyCode);
            Assert.AreEqual(CommitmentGrain.Hourly, Data.Commitment.Grain);
            Assert.NotNull(Data.Id);
            Assert.IsNotEmpty(Data.Name);
            Assert.IsNotEmpty(Data.DisplayName);
            Assert.NotNull(Data.ResourceType);
            Assert.AreEqual("Microsoft.BillingBenefits", Data.ResourceType.Namespace);
            Assert.AreEqual("savingsPlanOrderAliases", Data.ResourceType.Type);
            Assert.AreEqual(ProvisioningState.Created, Data.ProvisioningState);
            Assert.IsNotEmpty(Data.SavingsPlanOrderId);
            Assert.NotNull(Data.Sku);
            Assert.AreEqual("Compute_Savings_Plan", Data.Sku.Name);
            Assert.AreEqual("Compute_Savings_Plan", Data.SkuName);
            Assert.AreEqual(Term.P3Y, Data.Term);
        }
    }
}
