// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public static partial class RecoveryServicesSiteRecoveryExtensions
    {
        /// <summary> Gets a collection of SiteRecoveryVaultSettingResources scoped to a vault. </summary>
        /// <param name="resourceGroupResource"></param>
        /// <param name="resourceName"> The name of the recovery services vault. </param>
        public static SiteRecoveryVaultSettingCollection GetSiteRecoveryVaultSettings(this ResourceGroupResource resourceGroupResource, string resourceName)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesSiteRecoveryResourceGroupResource(resourceGroupResource).GetSiteRecoveryVaultSettings(resourceName);
        }
    }
}
