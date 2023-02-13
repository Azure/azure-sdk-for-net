// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Consumption
{
    /// <summary> A class to add extension methods to ArmResource. </summary>
    internal partial class ArmResourceExtensionClient : ArmResource
    {
        private static List<ResourceType> _consumptionBudgetCollection = new List<ResourceType> {
            new ResourceType("Microsoft.Resources/subscriptions"),
            new ResourceType("Microsoft.Resources/resourceGroups"),
            new ResourceType("Microsoft.Management/managementGroups"),
            new ResourceType("Microsoft.Billing/billingAccounts"),
            new ResourceType("Microsoft.Billing/billingAccounts/departments"),
            new ResourceType("Microsoft.Billing/billingAccounts/enrollmentAccounts"),
            new ResourceType("Microsoft.Billing/billingAccounts/billingProfiles"),
            new ResourceType("Microsoft.Billing/billingAccounts/invoiceSections")
        };

        /// <summary> Gets a collection of ConsumptionBudgetResources in the ArmResource. </summary>
        /// <returns> An object representing collection of ConsumptionBudgetResources and their operations over a ConsumptionBudgetResource. </returns>
        public virtual ConsumptionBudgetCollection GetConsumptionBudgets()
        {
            if (!_consumptionBudgetCollection.Any(p => p == Id.ResourceType))
                throw new ArgumentException($"Invalid resource identifier {Id} expected one of /subscriptions/{{subscriptionId}}, /subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}, /providers/Microsoft.Billing/billingAccounts/{{billingAccountId}}, /providers/Microsoft.Billing/billingAccounts/{{billingAccountId}}/departments/{{departmentId}}, /providers/Microsoft.Billing/billingAccounts/{{billingAccountId}}/enrollmentAccounts/{{enrollmentAccountId}}, /providers/Microsoft.Management/managementGroups/{{managementGroupId}}, /providers/Microsoft.Billing/billingAccounts/{{billingAccountId}}/billingProfiles/{{billingProfileId}} and providers/Microsoft.Billing/billingAccounts/{{billingAccountId}}/invoiceSections/{{invoiceSectionId}}.");
            return GetCachedClient(Client => new ConsumptionBudgetCollection(Client, Id));
        }
    }
}
