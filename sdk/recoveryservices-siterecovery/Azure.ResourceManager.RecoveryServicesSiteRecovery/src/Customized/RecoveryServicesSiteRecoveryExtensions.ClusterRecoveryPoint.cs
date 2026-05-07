// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public static partial class RecoveryServicesSiteRecoveryExtensions
    {
        /// <summary> Gets an object representing a SiteRecoveryClusterRecoveryPointResource along with the instance operations that can be performed on it but with no data. </summary>
        public static SiteRecoveryClusterRecoveryPointResource GetSiteRecoveryClusterRecoveryPointResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableRecoveryServicesSiteRecoveryArmClient(client).GetSiteRecoveryClusterRecoveryPointResource(id);
        }
    }
}
