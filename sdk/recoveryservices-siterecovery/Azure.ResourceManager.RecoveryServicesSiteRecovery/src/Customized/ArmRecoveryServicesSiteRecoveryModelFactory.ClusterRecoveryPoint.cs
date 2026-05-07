// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesSiteRecovery;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public static partial class ArmRecoveryServicesSiteRecoveryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryServicesSiteRecovery.SiteRecoveryClusterRecoveryPointData"/>. </summary>
        public static SiteRecoveryClusterRecoveryPointData SiteRecoveryClusterRecoveryPointData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string clusterRecoveryPointType = default, SiteRecoveryClusterRecoveryPointProperties properties = default)
        {
            return new SiteRecoveryClusterRecoveryPointData(id, name, resourceType, systemData, properties);
        }
    }
}
