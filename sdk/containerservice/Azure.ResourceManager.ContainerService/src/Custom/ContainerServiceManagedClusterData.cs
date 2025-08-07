// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary> A class representing the ContainerServiceManagedCluster data model. </summary>
    public partial class ContainerServiceManagedClusterData
    {
        /// <summary> Azure Defender settings for the security profile. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedClusterSecurityProfileAzureDefender SecurityAzureDefender
        {
            get
            {
                if (SecurityProfile != null && SecurityProfile.Defender != null)
                {
                    return new ManagedClusterSecurityProfileAzureDefender
                    {
                        IsEnabled = SecurityProfile.Defender.IsSecurityMonitoringEnabled,
                        LogAnalyticsWorkspaceResourceId = SecurityProfile.Defender.LogAnalyticsWorkspaceResourceId
                    };
                }
                return default;
            }
            set
            {
                if (SecurityProfile is null)
                    SecurityProfile = new ManagedClusterSecurityProfile();
                SecurityProfile.Defender = new ManagedClusterSecurityProfileDefender()
                {
                    LogAnalyticsWorkspaceResourceId = value.LogAnalyticsWorkspaceResourceId,
                    IsSecurityMonitoringEnabled = value.IsEnabled
                };
            }
        }

        /// <summary> For more information see [setting the AKS cluster auto-upgrade channel](https://docs.microsoft.com/azure/aks/upgrade-cluster#set-auto-upgrade-channel). </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UpgradeChannel? UpgradeChannel
        {
            get => AutoUpgradeProfile is null ? default : AutoUpgradeProfile.UpgradeChannel;
            set
            {
                if (AutoUpgradeProfile is null)
                    AutoUpgradeProfile = new ManagedClusterAutoUpgradeProfile();
                AutoUpgradeProfile.UpgradeChannel = value;
            }
        }

        /// <summary> The identity of the managed cluster, if configured. Current supported identity types: None, SystemAssigned, UserAssigned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity
        {
            //get; set;
            // Update get once Azure.ResourceManager provide model factory method for ManagedServiceIdentity
            get => ClusterIdentity is null ? default : new ManagedServiceIdentity(ClusterIdentity.ResourceIdentityType);
            set
            {
                if (value is null)
                    ClusterIdentity = null;
                else
                {
                    IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>();
                    if (value.ManagedServiceIdentityType == ManagedServiceIdentityType.UserAssigned || value.ManagedServiceIdentityType == ManagedServiceIdentityType.SystemAssignedUserAssigned)
                        userAssignedIdentities = value.UserAssignedIdentities;
                    ClusterIdentity = new ManagedClusterIdentity(value.PrincipalId, value.TenantId, value.ManagedServiceIdentityType, new ChangeTrackingDictionary<string, ManagedClusterDelegatedIdentity>(), userAssignedIdentities, null);
                }
            }
        }
    }
}
