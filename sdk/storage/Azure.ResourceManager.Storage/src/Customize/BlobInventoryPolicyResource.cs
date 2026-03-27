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
        // Backward-compatible overload: 4-param CreateResourceIdentifier (old GA took BlobInventoryPolicyName).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, BlobInventoryPolicyName blobInventoryPolicyName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
    }
}
