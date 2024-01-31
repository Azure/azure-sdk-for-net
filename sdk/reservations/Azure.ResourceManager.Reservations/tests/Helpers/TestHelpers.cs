// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Reservations.Models;

namespace Azure.ResourceManager.Reservations.Tests.Helper
{
    public static class TestHelpers
    {
        public static ReservationPurchaseContent CreatePurchaseRequestContent(string scope, string billingPlan)
        {
            var request = new ReservationPurchaseContent
            {
                Sku = new ReservationsSkuName("Standard_B1ls", null),
                Location = new Core.AzureLocation("westeurope"),
                ReservedResourceType = new ReservedResourceType("VirtualMachines"),
                BillingScopeId = new Core.ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"),
                Term = new ReservationTerm("P1Y"),
                BillingPlan = new ReservationBillingPlan(billingPlan),
                Quantity = 3,
                DisplayName = "testVM",
                AppliedScopeType = new AppliedScopeType(scope),
                IsRenewEnabled = false,
                ReservedResourceProperties = new PurchaseRequestPropertiesReservedResourceProperties(new InstanceFlexibility("On"), null),
            };

            if (scope.Equals("Single"))
            {
                request.AppliedScopes.Add("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
            }

            return request;
        }
    }
}
