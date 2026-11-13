// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public static partial class ArmAppServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceDomainData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="contactAdmin"> Administrative contact. </param>
        /// <param name="contactBilling"> Billing contact. </param>
        /// <param name="contactRegistrant"> Registrant contact. </param>
        /// <param name="contactTech"> Technical contact. </param>
        /// <param name="registrationStatus"> Domain registration status. </param>
        /// <param name="provisioningState"> Domain provisioning state. </param>
        /// <param name="nameServers"> Name servers. </param>
        /// <param name="isDomainPrivacyEnabled"> &lt;code&gt;true&lt;/code&gt; if domain privacy is enabled for this domain; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="createdOn"> Domain creation timestamp. </param>
        /// <param name="expireOn"> Domain expiration timestamp. </param>
        /// <param name="lastRenewedOn"> Timestamp when the domain was renewed last time. </param>
        /// <param name="isAutoRenew"> &lt;code&gt;true&lt;/code&gt; if the domain should be automatically renewed; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isDnsRecordManagementReady">
        /// &lt;code&gt;true&lt;/code&gt; if Azure can assign this domain to App Service apps; otherwise, &lt;code&gt;false&lt;/code&gt;. This value will be &lt;code&gt;true&lt;/code&gt; if domain registration status is active and
        ///  it is hosted on name servers Azure has programmatic access to.
        /// </param>
        /// <param name="managedHostNames"> All hostnames derived from the domain and assigned to Azure resources. </param>
        /// <param name="consent"> Legal agreement consent. </param>
        /// <param name="domainNotRenewableReasons"> Reasons why domain is not renewable. </param>
        /// <param name="dnsType"> Current DNS type. </param>
        /// <param name="dnsZoneId"> Azure DNS Zone to use. </param>
        /// <param name="targetDnsType"> Target DNS type (would be used for migration). </param>
        /// <param name="authCode"></param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.AppServiceDomainData"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceDomainData AppServiceDomainData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, RegistrationContactInfo contactAdmin = null, RegistrationContactInfo contactBilling = null, RegistrationContactInfo contactRegistrant = null, RegistrationContactInfo contactTech = null, AppServiceDomainStatus? registrationStatus = null, ProvisioningState? provisioningState = null, IEnumerable<string> nameServers = null, bool? isDomainPrivacyEnabled = null, DateTimeOffset? createdOn = null, DateTimeOffset? expireOn = null, DateTimeOffset? lastRenewedOn = null, bool? isAutoRenew = null, bool? isDnsRecordManagementReady = null, IEnumerable<AppServiceHostName> managedHostNames = null, DomainPurchaseConsent consent = null, IEnumerable<DomainNotRenewableReason> domainNotRenewableReasons = null, AppServiceDnsType? dnsType = null, string dnsZoneId = null, AppServiceDnsType? targetDnsType = null, string authCode = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();
            nameServers ??= new List<string>();
            managedHostNames ??= new List<AppServiceHostName>();
            domainNotRenewableReasons ??= new List<DomainNotRenewableReason>();

            return new AppServiceDomainData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                contactAdmin,
                contactBilling,
                contactRegistrant,
                contactTech,
                registrationStatus,
                provisioningState,
                nameServers?.ToList(),
                isDomainPrivacyEnabled,
                createdOn,
                expireOn,
                lastRenewedOn,
                isAutoRenew,
                isDnsRecordManagementReady,
                managedHostNames?.ToList(),
                consent,
                domainNotRenewableReasons?.ToList(),
                dnsType,
                dnsZoneId,
                targetDnsType,
                authCode,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceDomainPatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="contactAdmin"> Administrative contact. </param>
        /// <param name="contactBilling"> Billing contact. </param>
        /// <param name="contactRegistrant"> Registrant contact. </param>
        /// <param name="contactTech"> Technical contact. </param>
        /// <param name="registrationStatus"> Domain registration status. </param>
        /// <param name="provisioningState"> Domain provisioning state. </param>
        /// <param name="nameServers"> Name servers. </param>
        /// <param name="isDomainPrivacyEnabled"> &lt;code&gt;true&lt;/code&gt; if domain privacy is enabled for this domain; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="createdOn"> Domain creation timestamp. </param>
        /// <param name="expireOn"> Domain expiration timestamp. </param>
        /// <param name="lastRenewedOn"> Timestamp when the domain was renewed last time. </param>
        /// <param name="isAutoRenew"> &lt;code&gt;true&lt;/code&gt; if the domain should be automatically renewed; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isReadyForDnsRecordManagement">
        /// &lt;code&gt;true&lt;/code&gt; if Azure can assign this domain to App Service apps; otherwise, &lt;code&gt;false&lt;/code&gt;. This value will be &lt;code&gt;true&lt;/code&gt; if domain registration status is active and
        ///  it is hosted on name servers Azure has programmatic access to.
        /// </param>
        /// <param name="managedHostNames"> All hostnames derived from the domain and assigned to Azure resources. </param>
        /// <param name="consent"> Legal agreement consent. </param>
        /// <param name="domainNotRenewableReasons"> Reasons why domain is not renewable. </param>
        /// <param name="dnsType"> Current DNS type. </param>
        /// <param name="dnsZoneId"> Azure DNS Zone to use. </param>
        /// <param name="targetDnsType"> Target DNS type (would be used for migration). </param>
        /// <param name="authCode"></param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.AppServiceDomainPatch"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceDomainPatch AppServiceDomainPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, RegistrationContactInfo contactAdmin = null, RegistrationContactInfo contactBilling = null, RegistrationContactInfo contactRegistrant = null, RegistrationContactInfo contactTech = null, AppServiceDomainStatus? registrationStatus = null, ProvisioningState? provisioningState = null, IEnumerable<string> nameServers = null, bool? isDomainPrivacyEnabled = null, DateTimeOffset? createdOn = null, DateTimeOffset? expireOn = null, DateTimeOffset? lastRenewedOn = null, bool? isAutoRenew = null, bool? isReadyForDnsRecordManagement = null, IEnumerable<AppServiceHostName> managedHostNames = null, DomainPurchaseConsent consent = null, IEnumerable<DomainNotRenewableReason> domainNotRenewableReasons = null, AppServiceDnsType? dnsType = null, string dnsZoneId = null, AppServiceDnsType? targetDnsType = null, string authCode = null, string kind = null)
        {
            nameServers ??= new List<string>();
            managedHostNames ??= new List<AppServiceHostName>();
            domainNotRenewableReasons ??= new List<DomainNotRenewableReason>();

            return new AppServiceDomainPatch(
                id,
                name,
                resourceType,
                systemData,
                contactAdmin,
                contactBilling,
                contactRegistrant,
                contactTech,
                registrationStatus,
                provisioningState,
                nameServers?.ToList(),
                isDomainPrivacyEnabled,
                createdOn,
                expireOn,
                lastRenewedOn,
                isAutoRenew,
                isReadyForDnsRecordManagement,
                managedHostNames?.ToList(),
                consent,
                domainNotRenewableReasons?.ToList(),
                dnsType,
                dnsZoneId,
                targetDnsType,
                authCode,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DomainAvailabilityCheckResult"/>. </summary>
        /// <param name="name"> Name of the domain. </param>
        /// <param name="isAvailable"> &lt;code&gt;true&lt;/code&gt; if domain can be purchased using CreateDomain API; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="domainType"> Valid values are Regular domain: Azure will charge the full price of domain registration, SoftDeleted: Purchasing this domain will simply restore it and this operation will not cost anything. </param>
        /// <returns> A new <see cref="Models.DomainAvailabilityCheckResult"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DomainAvailabilityCheckResult DomainAvailabilityCheckResult(string name = null, bool? isAvailable = null, AppServiceDomainType? domainType = null)
        {
            return new DomainAvailabilityCheckResult(name, isAvailable, domainType, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceHostName"/>. </summary>
        /// <param name="name"> Name of the hostname. </param>
        /// <param name="siteNames"> List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a Traffic Manager. </param>
        /// <param name="azureResourceName"> Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic Manager name otherwise it will be the app name. </param>
        /// <param name="azureResourceType"> Type of the Azure resource the hostname is assigned to. </param>
        /// <param name="customHostNameDnsRecordType"> Type of the DNS record. </param>
        /// <param name="hostNameType"> Type of the hostname. </param>
        /// <returns> A new <see cref="Models.AppServiceHostName"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceHostName AppServiceHostName(string name = null, IEnumerable<string> siteNames = null, string azureResourceName = null, AppServiceResourceType? azureResourceType = null, CustomHostNameDnsRecordType? customHostNameDnsRecordType = null, AppServiceHostNameType? hostNameType = null)
        {
            siteNames ??= new List<string>();

            return new AppServiceHostName(
                name,
                siteNames?.ToList(),
                azureResourceName,
                azureResourceType,
                customHostNameDnsRecordType,
                hostNameType,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DomainControlCenterSsoRequestInfo"/>. </summary>
        /// <param name="uri"> URL where the single sign-on request is to be made. </param>
        /// <param name="postParameterKey"> Post parameter key. </param>
        /// <param name="postParameterValue"> Post parameter value. Client should use 'application/x-www-form-urlencoded' encoding for this value. </param>
        /// <returns> A new <see cref="Models.DomainControlCenterSsoRequestInfo"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DomainControlCenterSsoRequestInfo DomainControlCenterSsoRequestInfo(Uri uri = null, string postParameterKey = null, string postParameterValue = null)
        {
            return new DomainControlCenterSsoRequestInfo(uri, postParameterKey, postParameterValue, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.DomainOwnershipIdentifierData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="ownershipId"> Ownership Id. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.DomainOwnershipIdentifierData"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DomainOwnershipIdentifierData DomainOwnershipIdentifierData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string ownershipId = null, string kind = null)
        {
            return new DomainOwnershipIdentifierData(
                id,
                name,
                resourceType,
                systemData,
                ownershipId,
                kind,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.TldLegalAgreement"/>. </summary>
        /// <param name="agreementKey"> Unique identifier for the agreement. </param>
        /// <param name="title"> Agreement title. </param>
        /// <param name="content"> Agreement details. </param>
        /// <param name="uri"> URL where a copy of the agreement details is hosted. </param>
        /// <returns> A new <see cref="Models.TldLegalAgreement"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TldLegalAgreement TldLegalAgreement(string agreementKey = null, string title = null, string content = null, Uri uri = null)
        {
            return new TldLegalAgreement(agreementKey, title, content, uri, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.TopLevelDomainData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isDomainPrivacySupported"> If &lt;code&gt;true&lt;/code&gt;, then the top level domain supports domain privacy; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.TopLevelDomainData"/> instance for mocking. </returns>
        [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TopLevelDomainData TopLevelDomainData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, bool? isDomainPrivacySupported = null, string kind = null)
        {
            return new TopLevelDomainData(
                id,
                name,
                resourceType,
                systemData,
                isDomainPrivacySupported,
                kind,
                serializedAdditionalRawData: null);
        }
    }
}
