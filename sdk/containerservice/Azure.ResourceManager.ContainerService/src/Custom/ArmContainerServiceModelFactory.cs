// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmContainerServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContainerService.OSOptionProfileData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="osOptionPropertyList"> The list of OS options. </param>
        /// <returns> A new <see cref="ContainerService.OSOptionProfileData"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileData OSOptionProfileData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<ContainerServiceOSOptionProperty> osOptionPropertyList)
        {
            osOptionPropertyList ??= new List<ContainerServiceOSOptionProperty>();

            return new OSOptionProfileData(
                id,
                name,
                resourceType,
                systemData,
                osOptionPropertyList?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerService.ContainerServiceManagedClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The managed cluster SKU. </param>
        /// <param name="extendedLocation"> The extended location of the Virtual Machine. </param>
        /// <param name="clusterIdentity"> The identity of the managed cluster, if configured. </param>
        /// <param name="provisioningState"> The current provisioning state. </param>
        /// <param name="powerStateCode"> The Power State of the cluster. </param>
        /// <param name="maxAgentPools"> The max number of agent pools for the managed cluster. </param>
        /// <param name="kubernetesVersion"> Both patch version &lt;major.minor.patch&gt; (e.g. 1.20.13) and &lt;major.minor&gt; (e.g. 1.20) are supported. When &lt;major.minor&gt; is specified, the latest supported GA patch version is chosen automatically. Updating the cluster with the same &lt;major.minor&gt; once it has been created (e.g. 1.14.x -&gt; 1.14) will not trigger an upgrade, even if a newer patch version is available. When you upgrade a supported AKS cluster, Kubernetes minor versions cannot be skipped. All upgrades must be performed sequentially by major version number. For example, upgrades between 1.14.x -&gt; 1.15.x or 1.15.x -&gt; 1.16.x are allowed, however 1.14.x -&gt; 1.16.x is not allowed. See [upgrading an AKS cluster](https://docs.microsoft.com/azure/aks/upgrade-cluster) for more details. </param>
        /// <param name="currentKubernetesVersion"> If kubernetesVersion was a fully specified version &lt;major.minor.patch&gt;, this field will be exactly equal to it. If kubernetesVersion was &lt;major.minor&gt;, this field will contain the full &lt;major.minor.patch&gt; version being used. </param>
        /// <param name="dnsPrefix"> This cannot be updated once the Managed Cluster has been created. </param>
        /// <param name="fqdnSubdomain"> This cannot be updated once the Managed Cluster has been created. </param>
        /// <param name="fqdn"> The FQDN of the master pool. </param>
        /// <param name="privateFqdn"> The FQDN of private cluster. </param>
        /// <param name="azurePortalFqdn"> The Azure Portal requires certain Cross-Origin Resource Sharing (CORS) headers to be sent in some responses, which Kubernetes APIServer doesn't handle by default. This special FQDN supports CORS, allowing the Azure Portal to function properly. </param>
        /// <param name="agentPoolProfiles"> The agent pool properties. </param>
        /// <param name="linuxProfile"> The profile for Linux VMs in the Managed Cluster. </param>
        /// <param name="windowsProfile"> The profile for Windows VMs in the Managed Cluster. </param>
        /// <param name="servicePrincipalProfile"> Information about a service principal identity for the cluster to use for manipulating Azure APIs. </param>
        /// <param name="addonProfiles"> The profile of managed cluster add-on. </param>
        /// <param name="podIdentityProfile"> See [use AAD pod identity](https://docs.microsoft.com/azure/aks/use-azure-ad-pod-identity) for more details on AAD pod identity integration. </param>
        /// <param name="oidcIssuerProfile"> The OIDC issuer profile of the Managed Cluster. </param>
        /// <param name="nodeResourceGroup"> The name of the resource group containing agent pool nodes. </param>
        /// <param name="enableRbac"> Whether to enable Kubernetes Role-Based Access Control. </param>
        /// <param name="supportPlan"> The support plan for the Managed Cluster. If unspecified, the default is 'KubernetesOfficial'. </param>
        /// <param name="enablePodSecurityPolicy"> (DEPRECATED) Whether to enable Kubernetes pod security policy (preview). PodSecurityPolicy was deprecated in Kubernetes v1.21, and removed from Kubernetes in v1.25. Learn more at https://aka.ms/k8s/psp and https://aka.ms/aks/psp. </param>
        /// <param name="networkProfile"> The network configuration profile. </param>
        /// <param name="aadProfile"> The Azure Active Directory configuration. </param>
        /// <param name="autoUpgradeProfile"> The auto upgrade configuration. </param>
        /// <param name="upgradeOverrideSettings"> Settings for upgrading a cluster. </param>
        /// <param name="autoScalerProfile"> Parameters to be applied to the cluster-autoscaler when enabled. </param>
        /// <param name="apiServerAccessProfile"> The access profile for managed cluster API server. </param>
        /// <param name="diskEncryptionSetId"> This is of the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskEncryptionSets/{encryptionSetName}'. </param>
        /// <param name="identityProfile"> Identities associated with the cluster. </param>
        /// <param name="privateLinkResources"> Private link resources associated with the cluster. </param>
        /// <param name="disableLocalAccounts"> If set to true, getting static credentials will be disabled for this cluster. This must only be used on Managed Clusters that are AAD enabled. For more details see [disable local accounts](https://docs.microsoft.com/azure/aks/managed-aad#disable-local-accounts-preview). </param>
        /// <param name="httpProxyConfig"> Configurations for provisioning the cluster with HTTP proxy servers. </param>
        /// <param name="securityProfile"> Security profile for the managed cluster. </param>
        /// <param name="storageProfile"> Storage profile for the managed cluster. </param>
        /// <param name="publicNetworkAccess"> Allow or deny public network access for AKS. </param>
        /// <param name="workloadAutoScalerProfile"> Workload Auto-scaler profile for the managed cluster. </param>
        /// <param name="azureMonitorMetrics"> Azure Monitor addon profiles for monitoring the managed cluster. </param>
        /// <param name="serviceMeshProfile"> Service mesh profile for a managed cluster. </param>
        /// <param name="resourceId"> The resourceUID uniquely identifies ManagedClusters that reuse ARM ResourceIds (i.e: create, delete, create sequence). </param>
        /// <returns> A new <see cref="ContainerService.ContainerServiceManagedClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceManagedClusterData ContainerServiceManagedClusterData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedClusterSku sku, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, ManagedClusterIdentity clusterIdentity = null, string provisioningState = null, ContainerServiceStateCode? powerStateCode = null, int? maxAgentPools = null, string kubernetesVersion = null, string currentKubernetesVersion = null, string dnsPrefix = null, string fqdnSubdomain = null, string fqdn = null, string privateFqdn = null, string azurePortalFqdn = null, IEnumerable<ManagedClusterAgentPoolProfile> agentPoolProfiles = null, ContainerServiceLinuxProfile linuxProfile = null, ManagedClusterWindowsProfile windowsProfile = null, ManagedClusterServicePrincipalProfile servicePrincipalProfile = null, IDictionary<string, ManagedClusterAddonProfile> addonProfiles = null, ManagedClusterPodIdentityProfile podIdentityProfile = null, ManagedClusterOidcIssuerProfile oidcIssuerProfile = null, string nodeResourceGroup = null, bool? enableRbac = null, KubernetesSupportPlan? supportPlan = null, bool? enablePodSecurityPolicy = null, ContainerServiceNetworkProfile networkProfile = null, ManagedClusterAadProfile aadProfile = null, ManagedClusterAutoUpgradeProfile autoUpgradeProfile = null, UpgradeOverrideSettings upgradeOverrideSettings = null, ManagedClusterAutoScalerProfile autoScalerProfile = null, ManagedClusterApiServerAccessProfile apiServerAccessProfile = null, ResourceIdentifier diskEncryptionSetId = null, IDictionary<string, ContainerServiceUserAssignedIdentity> identityProfile = null, IEnumerable<ContainerServicePrivateLinkResourceData> privateLinkResources = null, bool? disableLocalAccounts = null, ManagedClusterHttpProxyConfig httpProxyConfig = null, ManagedClusterSecurityProfile securityProfile = null, ManagedClusterStorageProfile storageProfile = null, ContainerServicePublicNetworkAccess? publicNetworkAccess = null, ManagedClusterWorkloadAutoScalerProfile workloadAutoScalerProfile = null, ManagedClusterMonitorProfileMetrics azureMonitorMetrics = null, ServiceMeshProfile serviceMeshProfile = null, ResourceIdentifier resourceId = null)
            => ContainerServiceManagedClusterData(id, name, resourceType, systemData, tags, location, null, sku, extendedLocation, clusterIdentity, null, provisioningState, powerStateCode, maxAgentPools, kubernetesVersion, currentKubernetesVersion, dnsPrefix, fqdnSubdomain, fqdn, privateFqdn, azurePortalFqdn, agentPoolProfiles, linuxProfile, windowsProfile, servicePrincipalProfile, addonProfiles, podIdentityProfile, oidcIssuerProfile, nodeResourceGroup, null, enableRbac, supportPlan, networkProfile, aadProfile, autoUpgradeProfile, upgradeOverrideSettings, autoScalerProfile, apiServerAccessProfile, diskEncryptionSetId, identityProfile, privateLinkResources, disableLocalAccounts, httpProxyConfig, securityProfile, storageProfile, null, publicNetworkAccess, workloadAutoScalerProfile, azureMonitorMetrics, serviceMeshProfile, resourceId, null, null, null, null, null);

        /// <summary> Initializes a new instance of <see cref="Models.ContainerServiceOSOptionProperty"/>. </summary>
        /// <param name="osType"> The OS type. </param>
        /// <param name="enableFipsImage"> Whether the image is FIPS-enabled. </param>
        /// <returns> A new <see cref="Models.ContainerServiceOSOptionProperty"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerServiceOSOptionProperty ContainerServiceOSOptionProperty(string osType = null, bool enableFipsImage = default)
        {
            return new ContainerServiceOSOptionProperty(osType, enableFipsImage, serializedAdditionalRawData: null);
        }
    }
}
