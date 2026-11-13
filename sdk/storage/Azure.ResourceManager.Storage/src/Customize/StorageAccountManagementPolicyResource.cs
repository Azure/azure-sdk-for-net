// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compatible CreateResourceIdentifier was generated for singleton resource previously.
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountManagementPolicyResource
    {
        // Backward-compatible overload: 4-param CreateResourceIdentifier (old GA took ManagementPolicyName).
        /// <summary> Generates the resource identifier of a <see cref="StorageAccountManagementPolicyResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="accountName"> The account name. </param>
        /// <param name="managementPolicyName"> The management policy name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, ManagementPolicyName managementPolicyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
