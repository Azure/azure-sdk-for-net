// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Nginx.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmNginxModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Nginx.NginxDeploymentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Gets or sets the identity. </param>
        /// <param name="properties"></param>
        /// <param name="skuName"></param>
        /// <returns> A new <see cref="Nginx.NginxDeploymentData"/> instance for mocking. </returns>
        public static NginxDeploymentData NginxDeploymentData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags , AzureLocation location , ManagedServiceIdentity identity, NginxDeploymentProperties properties = null, string skuName = null)
        {
            tags ??= new Dictionary<string, string>();

            return new NginxDeploymentData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                properties,
                identity,
                skuName != null ? new NginxResourceSku(skuName, serializedAdditionalRawData: null) : null,
                serializedAdditionalRawData: null);
        }
        /// <summary> Initializes a new instance of <see cref="Models.WebApplicationFirewallStatus"/>. </summary>
        /// <param name="attackSignaturesPackage"> Package containing attack signatures for the NGINX App Protect Web Application Firewall (WAF). </param>
        /// <param name="botSignaturesPackage"> Package containing bot signatures for the NGINX App Protect Web Application Firewall (WAF). </param>
        /// <param name="threatCampaignsPackage"> Package containing threat campaigns for the NGINX App Protect Web Application Firewall (WAF). </param>
        /// <param name="componentVersions"> Versions of the NGINX App Protect Web Application Firewall (WAF) components. </param>
        /// <returns> A new <see cref="Models.WebApplicationFirewallStatus"/> instance for mocking. </returns>
        public static WebApplicationFirewallStatus WebApplicationFirewallStatus(WebApplicationFirewallPackage attackSignaturesPackage, WebApplicationFirewallPackage botSignaturesPackage = null, WebApplicationFirewallPackage threatCampaignsPackage = null, WebApplicationFirewallComponentVersions componentVersions = null)
        {
            return new WebApplicationFirewallStatus(null, attackSignaturesPackage, botSignaturesPackage, threatCampaignsPackage, componentVersions, serializedAdditionalRawData: null);
        }
    }
}
