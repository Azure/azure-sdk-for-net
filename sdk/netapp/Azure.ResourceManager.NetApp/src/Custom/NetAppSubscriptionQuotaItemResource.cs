// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppSubscriptionQuotaItemResource
    {
        // The v1.15 GA scoped this resource under a NetAppAccount and exposed an account-scoped
        // CreateResourceIdentifier overload. The new spec moved the quota item to a
        // subscription/location scope, so this overload no longer maps to a real resource path
        // and is retained only for source-level back-compat.
        /// <summary>
        /// Generate the resource identifier of a v1.15 account-scoped <see cref="NetAppSubscriptionQuotaItemResource"/> instance.
        /// This signature is no longer supported because the resource scope changed to subscription/location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string quotaLimitName)
        {
            throw new NotSupportedException("The v1.15 account-scoped CreateResourceIdentifier overload is no longer supported. Use CreateResourceIdentifier(string subscriptionId, AzureLocation location, string quotaLimitName) instead.");
        }
    }
}
