// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits.Models;

namespace Azure.ResourceManager.BillingBenefits.Tests.Helper
{
    public static class TestHelpers
    {
        public static SavingsPlanOrderAliasModelData CreateSavingsPlanOrderAliasPurchaseRequest(AppliedScopeType scope)
        {
            var request = new SavingsPlanOrderAliasModelData(new BillingBenefitsSku("Compute_Savings_Plan"))
            {
                BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47",
                Term = new Term("P3Y"),
                AppliedScopeType = scope,
                DisplayName = "TestSPName" + scope.ToString(),
                BillingPlan = new BillingPlan("P1M"),
                Commitment = new Commitment
                {
                    Grain = "Hourly",
                    CurrencyCode = "USD",
                    Amount = 0.001
                },
            };

            if (scope == AppliedScopeType.Single)
            {
                request.AppliedScopeProperties = new AppliedScopeProperties
                {
                    SubscriptionId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                };
            }
            else if (scope == AppliedScopeType.ManagementGroup)
            {
                request.AppliedScopeProperties = new AppliedScopeProperties
                {
                    ManagementGroupId = "/providers/Microsoft.Management/managementGroups/ba5ed788-ddc6-429c-a6a2-0277f01dbee7",
                    TenantId = new Guid("ba5ed788-ddc6-429c-a6a2-0277f01dbee7")
                };
            }

            return request;
        }

        public static ReservationOrderAliasModelCreateOrUpdateContent CreateReservationOrderAliasPurchaseRequest(AppliedScopeType scope)
        {
            var request = new ReservationOrderAliasModelCreateOrUpdateContent(new BillingBenefitsSku("Standard_B1s"))
            {
                BillingScopeId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47",
                Term = new Term("P3Y"),
                AppliedScopeType = scope,
                DisplayName = "TestROName" + scope.ToString(),
                BillingPlan = new BillingPlan("P1M"),
                ReservedResourceType = "VirtualMachines",
                Renew = false,
                Quantity = 1,
                Location = AzureLocation.EastUS,
                ReservedResourceProperties = new ReservationOrderAliasRequestReservedResourceProperties
                {
                    InstanceFlexibility = InstanceFlexibility.On
                }
            };

            if (scope == AppliedScopeType.Single)
            {
                request.AppliedScopeProperties = new AppliedScopeProperties
                {
                    SubscriptionId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                };
            }
            else if (scope == AppliedScopeType.ManagementGroup)
            {
                request.AppliedScopeProperties = new AppliedScopeProperties
                {
                    ManagementGroupId = "/providers/Microsoft.Management/managementGroups/ba5ed788-ddc6-429c-a6a2-0277f01dbee7",
                    TenantId = new Guid("ba5ed788-ddc6-429c-a6a2-0277f01dbee7")
                };
            }

            return request;
        }
    }
}
