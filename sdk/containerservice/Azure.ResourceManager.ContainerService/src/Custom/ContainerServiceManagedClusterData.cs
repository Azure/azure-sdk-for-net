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
    }
}
