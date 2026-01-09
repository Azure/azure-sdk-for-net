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

            Assert.That(savingsPlanModelResources, Is.Not.Empty);
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

            Assert.That(savingsPlanModelResources, Is.Not.Empty);
            savingsPlanModelResources.ForEach(model =>
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.HasData, Is.True);
                    Assert.That(model.Data.ProvisioningState, Is.EqualTo(BillingBenefitsProvisioningState.Succeeded));
                });
                ValidateResponseProperties(model);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSavingsPlansInSavingsPlanOrder()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });

            var resources = response.Value.GetBillingBenefitsSavingsPlans().GetAllAsync();
            List<BillingBenefitsSavingsPlanResource> models = await resources.ToEnumerableAsync();

            Assert.That(models, Is.Not.Empty);
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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.Multiple(() =>
            {
                Assert.That(modelResponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(modelResponse.Value, Is.Not.Null);
            });
            var model = modelResponse.Value;
            ValidateResponseProperties(model);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestUpdateSavingsPlan()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.Multiple(() =>
            {
                Assert.That(modelResponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(modelResponse.Value, Is.Not.Null);
            });

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

            Assert.Multiple(() =>
            {
                Assert.That(updateReponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(updateReponse.Value, Is.Not.Null);
            });

            var newModelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");
            Assert.Multiple(() =>
            {
                Assert.That(newModelResponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(newModelResponse.Value, Is.Not.Null);
            });
            Assert.That(newModelResponse.Value.Data.DisplayName, Is.Not.Empty);
            Assert.That(newModelResponse.Value.Data.DisplayName.Equals(originalName, StringComparison.OrdinalIgnoreCase), Is.False);
            ValidateResponseProperties(newModelResponse.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestUpdateSavingsPlanWithRenewSetting()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.Multiple(() =>
            {
                Assert.That(modelResponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(modelResponse.Value, Is.Not.Null);
            });

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

            Assert.Multiple(() =>
            {
                Assert.That(updateReponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(updateReponse.Value, Is.Not.Null);
            });

            // Get renew properties
            var newModelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073", "renewProperties");
            Assert.Multiple(() =>
            {
                Assert.That(newModelResponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(newModelResponse.Value, Is.Not.Null);
            });
            Assert.That(newModelResponse.Value.Data.DisplayName, Is.Not.Empty);
            ValidateResponseProperties(newModelResponse.Value);
            Assert.That(newModelResponse.Value.Data.RenewProperties, Is.Not.Null);
            Assert.That(newModelResponse.Value.Data.RenewProperties.PurchaseProperties, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestValidateSavingsPlanUpdate()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
            });

            var modelResponse = await response.Value.GetBillingBenefitsSavingsPlanAsync("2035abf9-4697-4220-b158-dbff2a0dc073");

            Assert.Multiple(() =>
            {
                Assert.That(modelResponse.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(modelResponse.Value, Is.Not.Null);
            });
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

            Assert.That(validateResponse, Is.Not.Null);
            Assert.That(validateResponse.Count, Is.EqualTo(1));
            Assert.That(validateResponse[0].IsValid, Is.True);
        }

        private void ValidateResponseProperties(BillingBenefitsSavingsPlanResource model)
        {
            Assert.Multiple(() =>
            {
                Assert.That(model.HasData, Is.True);
                Assert.That(model.Data.BillingScopeId.ToString(), Is.EqualTo("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"));
                Assert.That(model.Data.Commitment, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Data.Commitment.CurrencyCode, Is.Not.Empty);
                Assert.That(model.Data.Commitment.Grain, Is.EqualTo(BillingBenefitsCommitmentGrain.Hourly));
                Assert.That(model.Data.Commitment.Amount, Is.GreaterThan(0));
                Assert.That(model.Data.Id, Is.Not.Null);
                Assert.That(model.Data.IsRenewed, Is.Not.Null);
                Assert.That(model.Data.Name, Is.Not.Empty);
                Assert.That(model.Data.DisplayName, Is.Not.Empty);
                Assert.That(model.Data.ResourceType, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Data.ResourceType.Namespace, Is.EqualTo("microsoft.billingbenefits"));
                Assert.That(model.Data.ResourceType.Type, Is.EqualTo("savingsPlanOrders/savingsPlans"));
                Assert.That(model.Data.Sku, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Data.Sku.Name, Is.EqualTo("Compute_Savings_Plan"));
                Assert.That(model.Data.SkuName, Is.EqualTo("Compute_Savings_Plan"));
                Assert.That(model.Data.Term, Is.Not.Null);
                Assert.That(model.Data.Name, Is.Not.Empty);
                Assert.That((string)model.Data.BillingProfileId, Is.Not.Empty);
                Assert.That((string)model.Data.BillingAccountId, Is.Not.Empty);
                Assert.That(model.Data.DisplayProvisioningState, Is.Not.Empty);
                Assert.That(model.Data.ProvisioningState, Is.Not.Null);
                Assert.That(model.Data.PurchaseOn, Is.Not.Null);
                Assert.That(model.Data.BenefitStartOn, Is.Not.Null);
                Assert.That(model.Data.EffectOn, Is.Not.Null);
                Assert.That(model.Data.ExpireOn, Is.Not.Null);
            });
        }
    }
}
