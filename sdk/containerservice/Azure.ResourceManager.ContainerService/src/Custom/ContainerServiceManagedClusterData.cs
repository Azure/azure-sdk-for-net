// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    /// <summary> A class representing the ContainerServiceManagedCluster data model. </summary>
    public partial class ContainerServiceManagedClusterData
    {
        /// <summary> (DEPRECATED) Whether to enable Kubernetes pod security policy (preview). PodSecurityPolicy was deprecated in Kubernetes v1.21, and removed from Kubernetes in v1.25. Learn more at https://aka.ms/k8s/psp and https://aka.ms/aks/psp. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enablePodSecurityPolicy")]
        public bool? EnablePodSecurityPolicy { get; set; }

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
            // Update get once Azure.ResourceManager provide model factory method for ManagedServiceIdentity
            get => ClusterIdentity is null ? default : new ManagedServiceIdentity(ClusterIdentity.IdentityType is null ? Azure.ResourceManager.Models.ManagedServiceIdentityType.None : ClusterIdentity.IdentityType.Value);
            set
            {
                if (value is null)
                    ClusterIdentity = null;
                else
                {
                    IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>();
                    if (value.ManagedServiceIdentityType == Azure.ResourceManager.Models.ManagedServiceIdentityType.UserAssigned || value.ManagedServiceIdentityType == Azure.ResourceManager.Models.ManagedServiceIdentityType.SystemAssignedUserAssigned)
                        userAssignedIdentities = value.UserAssignedIdentities;
                    ClusterIdentity = new ManagedClusterIdentity(value.PrincipalId, value.TenantId, value.ManagedServiceIdentityType, new ChangeTrackingDictionary<string, ManagedClusterDelegatedIdentity>(), userAssignedIdentities, null);
                }
            }
        }

        /// <summary> Metrics profile for the Azure Monitor managed service for Prometheus addon. Collect out-of-the-box Kubernetes infrastructure metrics to send to an Azure Monitor Workspace and configure additional scraping for custom targets. See aka.ms/AzureManagedPrometheus for an overview. </summary>
        [WirePath("properties.azureMonitorProfile.metrics")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedClusterMonitorProfileMetrics AzureMonitorMetrics
        {
            get => AzureMonitorProfile is null ? default : AzureMonitorProfile.Metrics;
            set
            {
                if (AzureMonitorProfile is null)
                    AzureMonitorProfile = new ManagedClusterAzureMonitorProfile();
                AzureMonitorProfile.Metrics = value;
            }
        }

        /// <summary> App Routing settings for the ingress profile. You can find an overview and onboarding guide for this feature at https://learn.microsoft.com/en-us/azure/aks/app-routing?tabs=default%2Cdeploy-app-default. </summary>
        [WirePath("properties.ingressProfile.webAppRouting")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedClusterIngressProfileWebAppRouting IngressWebAppRouting
        {
            get => IngressProfile is null ? default : IngressProfile.WebAppRouting;
            set
            {
                if (IngressProfile is null)
                    IngressProfile = new ManagedClusterIngressProfile();
                IngressProfile.WebAppRouting = value;
            }
        }

        /// <summary> Whether to enable Kubernetes Role-Based Access Control. </summary>
        [WirePath("properties.enableRBAC")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableRbac { get => IsRbacEnabled; set => IsRbacEnabled = value; }

        /// <summary> If local accounts should be disabled on the Managed Cluster. </summary>
        [WirePath("properties.disableLocalAccounts")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableLocalAccounts { get => IsLocalAccountsDisabled; set => IsLocalAccountsDisabled = value; }
    }
}
