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
        // Per PR review: this overload throws unconditionally — mark [Obsolete] (with
        // error: true) so callers see a build-time error instead of discovering it at
        // runtime. The signature is retained so existing user code compiles after a
        // package upgrade, but using it must be flagged.
        /// <summary>
        /// Generate the resource identifier of a v1.15 account-scoped <see cref="NetAppSubscriptionQuotaItemResource"/> instance.
        /// This signature is no longer supported because the resource scope changed to subscription/location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("The v1.15 account-scoped CreateResourceIdentifier overload is no longer supported. Use CreateResourceIdentifier(string subscriptionId, AzureLocation location, string quotaLimitName) instead.", false)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string quotaLimitName)
        {
            throw new NotSupportedException("The v1.15 account-scoped CreateResourceIdentifier overload is no longer supported. Use CreateResourceIdentifier(string subscriptionId, AzureLocation location, string quotaLimitName) instead.");
        }
    }
}
