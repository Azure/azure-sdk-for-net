// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking
{
    public partial class MockableRecoveryServicesSiteRecoveryArmClient
    {
        /// <summary> Gets an object representing a SiteRecoveryClusterRecoveryPointResource along with the instance operations that can be performed on it but with no data. </summary>
        public virtual SiteRecoveryClusterRecoveryPointResource GetSiteRecoveryClusterRecoveryPointResource(ResourceIdentifier id)
        {
            SiteRecoveryClusterRecoveryPointResource.ValidateResourceId(id);
            return new SiteRecoveryClusterRecoveryPointResource(Client, id);
        }
    }
}
