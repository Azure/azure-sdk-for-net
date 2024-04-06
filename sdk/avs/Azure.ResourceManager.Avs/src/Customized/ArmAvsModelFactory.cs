// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Avs;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmAvsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The private cloud SKU. </param>
        /// <param name="identity"> The identity of the private cloud, if configured. Current supported identity types: SystemAssigned, None. </param>
        /// <param name="managementCluster"> The default cluster used for management. </param>
        /// <param name="internet"> Connectivity to internet is enabled or disabled. </param>
        /// <param name="identitySources"> vCenter Single Sign On Identity Sources. </param>
        /// <param name="availability"> Properties describing how the cloud is distributed across availability zones. </param>
        /// <param name="encryption"> Customer managed key encryption, can be enabled or disabled. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="circuit"> An ExpressRoute Circuit. </param>
        /// <param name="endpoints"> The endpoints. </param>
        /// <param name="networkBlock"> The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22. </param>
        /// <param name="managementNetwork"> Network used to access vCenter Server and NSX-T Manager. </param>
        /// <param name="provisioningNetwork"> Used for virtual machine cold migration, cloning, and snapshot migration. </param>
        /// <param name="vMotionNetwork"> Used for live migration of virtual machines. </param>
        /// <param name="vCenterPassword"> Optionally, set the vCenter admin password when the private cloud is created. </param>
        /// <param name="nsxtPassword"> Optionally, set the NSX-T Manager password when the private cloud is created. </param>
        /// <param name="vCenterCertificateThumbprint"> Thumbprint of the vCenter Server SSL certificate. </param>
        /// <param name="nsxtCertificateThumbprint"> Thumbprint of the NSX-T Manager SSL certificate. </param>
        /// <param name="externalCloudLinks"> Array of cloud link IDs from other clouds that connect to this one. </param>
        /// <param name="secondaryCircuit"> A secondary expressRoute circuit from a separate AZ. Only present in a stretched private cloud. </param>
        /// <param name="nsxPublicIPQuotaRaised"> Flag to indicate whether the private cloud has the quota for provisioned NSX Public IP count raised from 64 to 1024. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudData"/> instance for mocking. </returns>
        public static AvsPrivateCloudData AvsPrivateCloudData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string skuName = null, ManagedServiceIdentity identity = null, AvsManagementCluster managementCluster = null, InternetConnectivityState? internet = null, IEnumerable<SingleSignOnIdentitySource> identitySources = null, PrivateCloudAvailabilityProperties availability = null, CustomerManagedEncryption encryption = null, AvsPrivateCloudProvisioningState? provisioningState = null, ExpressRouteCircuit circuit = null, AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, IEnumerable<ResourceIdentifier> externalCloudLinks = null, ExpressRouteCircuit secondaryCircuit = null, NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = null)
        {
            tags ??= new Dictionary<string, string>();
            identitySources ??= new List<SingleSignOnIdentitySource>();
            externalCloudLinks ??= new List<ResourceIdentifier>();

            return new AvsPrivateCloudData(id, name, resourceType, systemData, tags, location, skuName != null ? new AvsSku(skuName) : null, identity, managementCluster, internet, identitySources?.ToList(), availability, encryption, new List<string>(), provisioningState, circuit, endpoints, networkBlock, managementNetwork, provisioningNetwork, vMotionNetwork, vCenterPassword, nsxtPassword, vCenterCertificateThumbprint, nsxtCertificateThumbprint, externalCloudLinks?.ToList(), secondaryCircuit, nsxPublicIPQuotaRaised, null);
        }
    }
}
