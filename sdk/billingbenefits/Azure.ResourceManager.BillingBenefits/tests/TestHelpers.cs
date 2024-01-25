// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits.Models;

namespace Azure.ResourceManager.BillingBenefits.Tests.Helper
{
    public static class TestHelpers
    {
        public static BillingBenefitsSavingsPlanOrderAliasData CreateSavingsPlanOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType scope)
        {
            var request = new BillingBenefitsSavingsPlanOrderAliasData(new BillingBenefitsSku("Compute_Savings_Plan", null))
            {
                BillingScopeId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"),
                Term = new BillingBenefitsTerm("P3Y"),
                AppliedScopeType = scope,
                DisplayName = "TestSPName" + scope.ToString(),
                BillingPlan = new BillingBenefitsBillingPlan("P1M"),
                Commitment = new BillingBenefitsCommitment
                {
                    Grain = "Hourly",
                    CurrencyCode = "USD",
                    Amount = 0.001
                },
            };

            if (scope == BillingBenefitsAppliedScopeType.Single)
            {
                request.AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
                {
                    SubscriptionId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47")
                };
            }
            else if (scope == BillingBenefitsAppliedScopeType.ManagementGroup)
            {
                request.AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
                {
                    ManagementGroupId = new ResourceIdentifier("/providers/Microsoft.Management/managementGroups/ba5ed788-ddc6-429c-a6a2-0277f01dbee7"),
                    TenantId = new Guid("ba5ed788-ddc6-429c-a6a2-0277f01dbee7")
                };
            }

            return request;
        }

        public static BillingBenefitsReservationOrderAliasCreateOrUpdateContent CreateReservationOrderAliasPurchaseRequest(BillingBenefitsAppliedScopeType scope)
        {
            var request = new BillingBenefitsReservationOrderAliasCreateOrUpdateContent(new BillingBenefitsSku("Standard_B1s", null))
            {
                BillingScopeId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"),
                Term = new BillingBenefitsTerm("P3Y"),
                AppliedScopeType = scope,
                DisplayName = "TestROName" + scope.ToString(),
                BillingPlan = new BillingBenefitsBillingPlan("P1M"),
                ReservedResourceType = "VirtualMachines",
                IsRenewed = false,
                Quantity = 1,
                Location = AzureLocation.EastUS,
                ReservedResourceInstanceFlexibility = BillingBenefitsInstanceFlexibility.On
            };

            if (scope == BillingBenefitsAppliedScopeType.Single)
            {
                request.AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
                {
                    SubscriptionId = new ResourceIdentifier("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47")
                };
            }
            else if (scope == BillingBenefitsAppliedScopeType.ManagementGroup)
            {
                request.AppliedScopeProperties = new BillingBenefitsAppliedScopeProperties
                {
                    ManagementGroupId = new ResourceIdentifier("/providers/Microsoft.Management/managementGroups/ba5ed788-ddc6-429c-a6a2-0277f01dbee7"),
                    TenantId = new Guid("ba5ed788-ddc6-429c-a6a2-0277f01dbee7")
                };
            }

            return request;
        }
    }
}
