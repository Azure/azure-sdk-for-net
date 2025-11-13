// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models
{
    public static partial class ArmPaloAltoNetworksNgfwModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Ngfw.PaloAltoNetworksFirewallStatusData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isPanoramaManaged"> Panorama Managed: Default is False. Default will be CloudSec managed. </param>
        /// <param name="healthStatus"> Current status of the Firewall. </param>
        /// <param name="healthReason"> Detail description of current health of the Firewall. </param>
        /// <param name="panoramaStatus"> Panorama Status. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Ngfw.PaloAltoNetworksFirewallStatusData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PaloAltoNetworksFirewallStatusData PaloAltoNetworksFirewallStatusData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, FirewallBooleanType? isPanoramaManaged, FirewallHealthStatus? healthStatus, string healthReason, FirewallPanoramaStatus panoramaStatus, FirewallProvisioningStateType? provisioningState)
            => PaloAltoNetworksFirewallStatusData(id, name, resourceType, systemData, isPanoramaManaged, healthStatus, healthReason, panoramaStatus, provisioningState, default, default);

        /// <summary> Initializes a new instance of <see cref="Ngfw.PaloAltoNetworksFirewallData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="panETag"> panEtag info. </param>
        /// <param name="networkProfile"> Network settings. </param>
        /// <param name="isPanoramaManaged"> Panorama Managed: Default is False. Default will be CloudSec managed. </param>
        /// <param name="panoramaConfig"> Panorama Configuration. </param>
        /// <param name="associatedRulestack"> Associated Rulestack. </param>
        /// <param name="dnsSettings"> DNS settings for Firewall. </param>
        /// <param name="frontEndSettings"> Frontend settings for Firewall. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="planData"> Billing plan information. </param>
        /// <param name="marketplaceDetails"> Marketplace details. </param>
        /// <returns> A new <see cref="Ngfw.PaloAltoNetworksFirewallData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PaloAltoNetworksFirewallData PaloAltoNetworksFirewallData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, ETag? panETag = null, FirewallNetworkProfile networkProfile = null, FirewallBooleanType? isPanoramaManaged = null, FirewallPanoramaConfiguration panoramaConfig = null, RulestackDetails associatedRulestack = null, FirewallDnsSettings dnsSettings = null, IEnumerable<FirewallFrontendSetting> frontEndSettings = null, FirewallProvisioningState? provisioningState = null, FirewallBillingPlanInfo planData = null, PanFirewallMarketplaceDetails marketplaceDetails = null)
            => PaloAltoNetworksFirewallData(id, name, resourceType, systemData, tags, location, panETag, networkProfile, isPanoramaManaged, default, panoramaConfig, associatedRulestack, dnsSettings, frontEndSettings, provisioningState, planData, marketplaceDetails, default, identity);

        /// <summary> Initializes a new instance of <see cref="Ngfw.LocalRulestackData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="panETag"> PanEtag info. </param>
        /// <param name="panLocation"> Rulestack Location, Required for GlobalRulestacks, Not for LocalRulestacks. </param>
        /// <param name="scope"> Rulestack Type. </param>
        /// <param name="associatedSubscriptions"> subscription scope of global rulestack. </param>
        /// <param name="description"> rulestack description. </param>
        /// <param name="defaultMode"> Mode for default rules creation. </param>
        /// <param name="minAppIdVersion"> minimum version. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="securityServices"> Security Profile. </param>
        /// <returns> A new <see cref="Ngfw.LocalRulestackData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LocalRulestackData LocalRulestackData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, ETag? panETag = null, AzureLocation? panLocation = null, RulestackScopeType? scope = null, IEnumerable<string> associatedSubscriptions = null, string description = null, RuleCreationDefaultMode? defaultMode = null, string minAppIdVersion = null, FirewallProvisioningState? provisioningState = null, RulestackSecurityServices securityServices = null)
            => LocalRulestackData(id, name, resourceType, systemData, tags, location, panETag, panLocation, scope, associatedSubscriptions, description, defaultMode, minAppIdVersion, provisioningState, securityServices = default, identity = default);

        /// <summary> Initializes a new instance of <see cref="Ngfw.LocalRulestackCertificateObjectData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="certificateSignerResourceId"> Resource Id of certificate signer, to be populated only when certificateSelfSigned is false. </param>
        /// <param name="certificateSelfSigned"> use certificate self signed. </param>
        /// <param name="auditComment"> comment for this object. </param>
        /// <param name="description"> user description for this object. </param>
        /// <param name="etag"> read only string representing last create or update. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Ngfw.LocalRulestackCertificateObjectData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LocalRulestackCertificateObjectData LocalRulestackCertificateObjectData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string certificateSignerResourceId, FirewallBooleanType certificateSelfSigned, string auditComment = null, string description = null, ETag? etag = null, FirewallProvisioningState? provisioningState = null)
            => LocalRulestackCertificateObjectData(id, name, resourceType, systemData, certificateSignerResourceId, certificateSelfSigned, auditComment, description, etag, provisioningState);

        /// <summary> Initializes a new instance of <see cref="Ngfw.GlobalRulestackData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Global Location. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="panETag"> PanEtag info. </param>
        /// <param name="panLocation"> Rulestack Location, Required for GlobalRulestacks, Not for LocalRulestacks. </param>
        /// <param name="scope"> Rulestack Type. </param>
        /// <param name="associatedSubscriptions"> subscription scope of global rulestack. </param>
        /// <param name="description"> rulestack description. </param>
        /// <param name="defaultMode"> Mode for default rules creation. </param>
        /// <param name="minAppIdVersion"> minimum version. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="securityServices"> Security Profile. </param>
        /// <returns> A new <see cref="Ngfw.GlobalRulestackData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GlobalRulestackData GlobalRulestackData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation location, ManagedServiceIdentity identity = null, ETag? panETag = null, AzureLocation? panLocation = null, RulestackScopeType? scope = null, IEnumerable<string> associatedSubscriptions = null, string description = null, RuleCreationDefaultMode? defaultMode = null, string minAppIdVersion = null, FirewallProvisioningState? provisioningState = null, RulestackSecurityServices securityServices = null)
            => GlobalRulestackData(id, name, resourceType, systemData, panETag, panLocation, scope, associatedSubscriptions, description, defaultMode, minAppIdVersion, provisioningState, securityServices, location, identity);

        /// <summary> Initializes a new instance of <see cref="Ngfw.GlobalRulestackCertificateObjectData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="certificateSignerResourceId"> Resource Id of certificate signer, to be populated only when certificateSelfSigned is false. </param>
        /// <param name="certificateSelfSigned"> use certificate self signed. </param>
        /// <param name="auditComment"> comment for this object. </param>
        /// <param name="description"> user description for this object. </param>
        /// <param name="etag"> read only string representing last create or update. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Ngfw.GlobalRulestackCertificateObjectData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GlobalRulestackCertificateObjectData GlobalRulestackCertificateObjectData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string certificateSignerResourceId, FirewallBooleanType certificateSelfSigned, string auditComment = null, string description = null, ETag? etag = null, FirewallProvisioningState? provisioningState = null)
            => GlobalRulestackCertificateObjectData(id, name, resourceType, systemData, certificateSignerResourceId, certificateSelfSigned, auditComment, description, etag, provisioningState);
    }
}
