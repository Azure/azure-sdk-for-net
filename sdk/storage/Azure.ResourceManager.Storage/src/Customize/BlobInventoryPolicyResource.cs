// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds CreateOrUpdate overloads that forward to the collection's CreateOrUpdate (PUT)
// to preserve prior GA behavior. The resource's Update sends PATCH which differs from recordings.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobInventoryPolicyResource
    {
        // Backward-compatible CreateResourceIdentifier was generated for singleton resource previously.
        /// <summary> Generates the resource identifier of a <see cref="BlobInventoryPolicyResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="accountName"> The account name. </param>
        /// <param name="blobInventoryPolicyName"> The blob inventory policy name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, BlobInventoryPolicyName blobInventoryPolicyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
