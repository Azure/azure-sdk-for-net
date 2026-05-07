// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.RecoveryServicesSiteRecovery;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking
{
    public partial class MockableRecoveryServicesSiteRecoveryResourceGroupResource
    {
        /// <summary> Gets a collection of SiteRecoveryVaultSettingResources scoped to a vault. </summary>
        /// <param name="resourceName"> The name of the recovery services vault. </param>
        public virtual SiteRecoveryVaultSettingCollection GetSiteRecoveryVaultSettings(string resourceName)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            return GetCachedClient(client => new SiteRecoveryVaultSettingCollection(client, Id, resourceName));
        }
    }
}
