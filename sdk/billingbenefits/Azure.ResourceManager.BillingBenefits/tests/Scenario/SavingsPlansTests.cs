// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class SavingsPlansTests : BillingBenefitsManagementTestBase
    {
        private TenantResource _tenant;

        public SavingsPlansTests(bool isAsync) : base(isAsync)
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
                _tenant = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSavingsPlans()
        {
            var response = _tenant.GetBillingBenefitsSavingsPlansAsync(new TenantResourceGetBillingBenefitsSavingsPlansOptions());
            List<BillingBenefitsSavingsPlanResource> savingsPlanModelResources = await response.ToEnumerableAsync();

            Assert.Greater(savingsPlanModelResources.Count, 0);
            savingsPlanModelResources.ForEach(model =>
            {
                ValidateResponseProperties(model);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSavingsPlansWithSelectedState()
        {
            var options = new TenantResourceGetBillingBenefitsSavingsPlansOptions();
            options.SelectedState = "Succeeded";
            var response = _tenant.GetBillingBenefitsSavingsPlansAsync(options);
            List<BillingBenefitsSavingsPlanResource> savingsPlanModelResources = await response.ToEnumerableAsync();

            Assert.Greater(savingsPlanModelResources.Count, 0);
            savingsPlanModelResources.ForEach(model =>
            {
                Assert.IsTrue(model.HasData);
                Assert.AreEqual(BillingBenefitsProvisioningState.Succeeded, model.Data.ProvisioningState);
                ValidateResponseProperties(model);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSavingsPlansInSavingsPlanOrder()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);

            var resources = response.Value.GetBillingBenefitsSavingsPlans().GetAllAsync();
            List<BillingBenefitsSavingsPlanResource> models = await resources.ToEnumerableAsync();

            Assert.Greater(models.Count, 0);
            models.ForEach(model =>
            {
                ValidateResponseProperties(model);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetSavingsPlan()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.AreEqual(200, modelResponse.GetRawResponse().Status);
            Assert.NotNull(modelResponse.Value);
            var model = modelResponse.Value;
            ValidateResponseProperties(model);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestUpdateSavingsPlan()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.AreEqual(200, modelResponse.GetRawResponse().Status);
            Assert.NotNull(modelResponse.Value);

            var modelResource = modelResponse.Value;
            var originalName = modelResource.Data.DisplayName;
            var updateProperties = new BillingBenefitsSavingsPlanPatch
            {
                Properties = new BillingBenefitsSavingsPlanPatchProperties
                {
                    DisplayName = originalName + "New"
                }
            };
            var updateReponse = await modelResource.UpdateAsync(updateProperties);

            Assert.AreEqual(200, updateReponse.GetRawResponse().Status);
            Assert.NotNull(updateReponse.Value);

            var newModelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");
            Assert.AreEqual(200, newModelResponse.GetRawResponse().Status);
            Assert.NotNull(newModelResponse.Value);
            Assert.IsNotEmpty(newModelResponse.Value.Data.DisplayName);
            Assert.False(newModelResponse.Value.Data.DisplayName.Equals(originalName, StringComparison.OrdinalIgnoreCase));
            ValidateResponseProperties(newModelResponse.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestUpdateSavingsPlanWithRenewSetting()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.AreEqual(200, modelResponse.GetRawResponse().Status);
            Assert.NotNull(modelResponse.Value);

            var modelResource = modelResponse.Value;
            var updateProperties = new BillingBenefitsSavingsPlanPatch
            {
                Properties = new BillingBenefitsSavingsPlanPatchProperties
                {
                    IsRenewed = true,
                    RenewProperties = new RenewProperties
                    {
                        PurchaseProperties = new BillingBenefitsPurchaseContent
                        {
                            Sku = new BillingBenefitsSku("Compute_Savings_Plan", null),
                            DisplayName = "TestRenewSP",
                            BillingScopeId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"),
                            Term = new BillingBenefitsTerm("P1Y"),
                            BillingPlan = new BillingBenefitsBillingPlan("P1M"),
                            AppliedScopeType = BillingBenefitsAppliedScopeType.Single,
                            Commitment = new BillingBenefitsCommitment
                            {
                                Grain = "Hourly",
                                CurrencyCode = "USD",
                                Amount = 0.001
                            },
                            IsRenewed = true,
                            AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
                            {
                                ResourceGroupId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47/resourcegroups/TestRG")
                            }
                        }
                    }
                }
            };
            var updateReponse = await modelResource.UpdateAsync(updateProperties);

            Assert.AreEqual(200, updateReponse.GetRawResponse().Status);
            Assert.NotNull(updateReponse.Value);

            // Get renew properties
            var newModelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073", "renewProperties");
            Assert.AreEqual(200, newModelResponse.GetRawResponse().Status);
            Assert.NotNull(newModelResponse.Value);
            Assert.IsNotEmpty(newModelResponse.Value.Data.DisplayName);
            ValidateResponseProperties(newModelResponse.Value);
            Assert.NotNull(newModelResponse.Value.Data.RenewProperties);
            Assert.NotNull(newModelResponse.Value.Data.RenewProperties.PurchaseProperties);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestValidateSavingsPlanUpdate()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.NotNull(response.Value);

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.AreEqual(200, modelResponse.GetRawResponse().Status);
            Assert.NotNull(modelResponse.Value);
            var model = modelResponse.Value;
            var validateContent = new SavingsPlanUpdateValidateContent();
            validateContent.Benefits.Add(new BillingBenefitsSavingsPlanPatchProperties
            {
                AppliedScopeType = BillingBenefitsAppliedScopeType.Single,
                AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
                {
                    SubscriptionId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47")
                }
            });

            var validateResponse = await model.ValidateUpdateAsync(validateContent).ToEnumerableAsync();

            Assert.NotNull(validateResponse);
            Assert.AreEqual(1, validateResponse.Count);
            Assert.IsTrue(validateResponse[0].IsValid);
        }

        private void ValidateResponseProperties(BillingBenefitsSavingsPlanResource model)
        {
            Assert.IsTrue(model.HasData);
            Assert.AreEqual("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47", model.Data.BillingScopeId.ToString());
            Assert.NotNull(model.Data.Commitment);
            Assert.IsNotEmpty(model.Data.Commitment.CurrencyCode);
            Assert.AreEqual(BillingBenefitsCommitmentGrain.Hourly, model.Data.Commitment.Grain);
            Assert.Greater(model.Data.Commitment.Amount, 0);
            Assert.NotNull(model.Data.Id);
            Assert.NotNull(model.Data.IsRenewed);
            Assert.IsNotEmpty(model.Data.Name);
            Assert.IsNotEmpty(model.Data.DisplayName);
            Assert.NotNull(model.Data.ResourceType);
            Assert.AreEqual("microsoft.billingbenefits", model.Data.ResourceType.Namespace);
            Assert.AreEqual("savingsPlanOrders/savingsPlans", model.Data.ResourceType.Type);
            Assert.NotNull(model.Data.Sku);
            Assert.AreEqual("Compute_Savings_Plan", model.Data.Sku.Name);
            Assert.AreEqual("Compute_Savings_Plan", model.Data.SkuName);
            Assert.NotNull(model.Data.Term);
            Assert.IsNotEmpty(model.Data.Name);
            Assert.IsNotEmpty(model.Data.BillingProfileId);
            Assert.IsNotEmpty(model.Data.BillingAccountId);
            Assert.IsNotEmpty(model.Data.DisplayProvisioningState);
            Assert.NotNull(model.Data.ProvisioningState);
            Assert.NotNull(model.Data.PurchaseOn);
            Assert.NotNull(model.Data.BenefitStartOn);
            Assert.NotNull(model.Data.EffectOn);
            Assert.NotNull(model.Data.ExpireOn);
        }
    }
}
