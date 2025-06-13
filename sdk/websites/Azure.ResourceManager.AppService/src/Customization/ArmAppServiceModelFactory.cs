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
    /// <summary> Model factory for models. </summary>
    public static partial class ArmAppServiceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ResourceNameAvailabilityContent"/>. </summary>
        /// <param name="name"> Resource name to verify. </param>
        /// <param name="resourceType"> Resource type used for verification. </param>
        /// <param name="isFqdn"> Is fully qualified domain name. </param>
        /// <param name="environmentId"> Azure Resource Manager ID of the customer's selected Container Apps Environment on which to host the Function app. This must be of the form /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.App/managedEnvironments/{managedEnvironmentName}. </param>
        /// <returns> A new <see cref="Models.ResourceNameAvailabilityContent"/> instance for mocking. </returns>
        public static ResourceNameAvailabilityContent ResourceNameAvailabilityContent(string name, CheckNameResourceType resourceType, bool? isFqdn, string environmentId)
        {
            return new ResourceNameAvailabilityContent(name, resourceType, isFqdn, environmentId, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ResourceNameAvailability"/>. </summary>
        /// <param name="isNameAvailable"> &lt;code&gt;true&lt;/code&gt; indicates name is valid and available. &lt;code&gt;false&lt;/code&gt; indicates the name is invalid, unavailable, or both. </param>
        /// <param name="reason"> &lt;code&gt;Invalid&lt;/code&gt; indicates the name provided does not match Azure App Service naming requirements. &lt;code&gt;AlreadyExists&lt;/code&gt; indicates that the name is already in use and is therefore unavailable. </param>
        /// <param name="message"> If reason == invalid, provide the user with the reason why the given name is invalid, and provide the resource naming requirements so that the user can select a valid name. If reason == AlreadyExists, explain that resource name is already in use, and direct them to select a different name. </param>
        /// <returns> A new <see cref="Models.ResourceNameAvailability"/> instance for mocking. </returns>
        public static ResourceNameAvailability ResourceNameAvailability(bool? isNameAvailable, InAvailabilityReasonType? reason, string message)
        {
            return new ResourceNameAvailability(isNameAvailable, reason, message, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.WebSiteData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Managed service identity. </param>
        /// <param name="extendedLocation"> Extended Location. </param>
        /// <param name="state"> Current state of the app. </param>
        /// <param name="hostNames"> Hostnames associated with the app. </param>
        /// <param name="repositorySiteName"> Name of the repository site. </param>
        /// <param name="usageState"> State indicating whether the app has exceeded its quota usage. Read-only. </param>
        /// <param name="isEnabled"> &lt;code&gt;true&lt;/code&gt; if the app is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. Setting this value to false disables the app (takes the app offline). </param>
        /// <param name="enabledHostNames">
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </param>
        /// <param name="availabilityState"> Management information availability state for the app. </param>
        /// <param name="hostNameSslStates"> Hostname SSL states are used to manage the SSL bindings for app's hostnames. </param>
        /// <param name="appServicePlanId"> Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}". </param>
        /// <param name="isReserved"> &lt;code&gt;true&lt;/code&gt; if reserved; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isXenon"> Obsolete: Hyper-V sandbox. </param>
        /// <param name="isHyperV"> Hyper-V sandbox. </param>
        /// <param name="lastModifiedTimeUtc"> Last time the app was modified, in UTC. Read-only. </param>
        /// <param name="dnsConfiguration"> Property to configure various DNS related settings for a site. </param>
        /// <param name="isVnetRouteAllEnabled"> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </param>
        /// <param name="isVnetImagePullEnabled"> To enable pulling image over Virtual Network. </param>
        /// <param name="isVnetContentShareEnabled"> To enable accessing content over virtual network. </param>
        /// <param name="isVnetBackupRestoreEnabled"> To enable Backup and Restore operations over virtual network. </param>
        /// <param name="siteConfig"> Configuration of the app. </param>
        /// <param name="functionAppConfig"> Configuration specific of the Azure Function app. </param>
        /// <param name="daprConfig"> Dapr configuration of the app. </param>
        /// <param name="workloadProfileName"> Workload profile name for function app to execute on. </param>
        /// <param name="resourceConfig"> Function app resource requirements. </param>
        /// <param name="trafficManagerHostNames"> Azure Traffic Manager hostnames associated with the app. Read-only. </param>
        /// <param name="isScmSiteAlsoStopped"> &lt;code&gt;true&lt;/code&gt; to stop SCM (KUDU) site when the app is stopped; otherwise, &lt;code&gt;false&lt;/code&gt;. The default is &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="targetSwapSlot"> Specifies which deployment slot this app will swap into. Read-only. </param>
        /// <param name="hostingEnvironmentProfile"> App Service Environment to use for the app. </param>
        /// <param name="isClientAffinityEnabled"> &lt;code&gt;true&lt;/code&gt; to enable client affinity; &lt;code&gt;false&lt;/code&gt; to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is &lt;code&gt;true&lt;/code&gt;. </param>
        /// <param name="isClientCertEnabled"> &lt;code&gt;true&lt;/code&gt; to enable client certificate authentication (TLS mutual authentication); otherwise, &lt;code&gt;false&lt;/code&gt;. Default is &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="clientCertMode">
        /// This composes with ClientCertEnabled setting.
        /// - ClientCertEnabled: false means ClientCert is ignored.
        /// - ClientCertEnabled: true and ClientCertMode: Required means ClientCert is required.
        /// - ClientCertEnabled: true and ClientCertMode: Optional means ClientCert is optional or accepted.
        /// </param>
        /// <param name="clientCertExclusionPaths"> client certificate authentication comma-separated exclusion paths. </param>
        /// <param name="ipMode"> Specifies the IP mode of the app. </param>
        /// <param name="isEndToEndEncryptionEnabled"> Whether to use end to end encryption between the FrontEnd and the Worker. </param>
        /// <param name="isHostNameDisabled">
        /// &lt;code&gt;true&lt;/code&gt; to disable the public hostnames of the app; otherwise, &lt;code&gt;false&lt;/code&gt;.
        ///  If &lt;code&gt;true&lt;/code&gt;, the app is only accessible via API management process.
        /// </param>
        /// <param name="customDomainVerificationId"> Unique identifier that verifies the custom domains assigned to the app. Customer will add this id to a txt record for verification. </param>
        /// <param name="outboundIPAddresses"> List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that site can be hosted with current settings. Read-only. </param>
        /// <param name="possibleOutboundIPAddresses"> List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants except dataComponent. Read-only. </param>
        /// <param name="containerSize"> Size of the function container. </param>
        /// <param name="dailyMemoryTimeQuota"> Maximum allowed daily memory-time quota (applicable on dynamic apps only). </param>
        /// <param name="suspendOn"> App suspended till in case memory-time quota is exceeded. </param>
        /// <param name="maxNumberOfWorkers">
        /// Maximum number of workers.
        /// This only applies to Functions container.
        /// </param>
        /// <param name="cloningInfo"> If specified during app creation, the app is cloned from a source app. </param>
        /// <param name="resourceGroup"> Name of the resource group the app belongs to. Read-only. </param>
        /// <param name="isDefaultContainer"> &lt;code&gt;true&lt;/code&gt; if the app is a default container; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="defaultHostName"> Default hostname of the app. Read-only. </param>
        /// <param name="slotSwapStatus"> Status of the last deployment slot swap operation. </param>
        /// <param name="isHttpsOnly">
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        /// http requests
        /// </param>
        /// <param name="redundancyMode"> Site redundancy mode. </param>
        /// <param name="inProgressOperationId"> Specifies an operation id if this site has a pending operation. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. Allowed Values: 'Enabled', 'Disabled' or an empty string. </param>
        /// <param name="isStorageAccountRequired"> Checks if Customer provided storage account is required. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="autoGeneratedDomainNameLabelScope"> Specifies the scope of uniqueness for the default hostname during resource creation. </param>
        /// <param name="virtualNetworkSubnetId">
        /// Azure Resource Manager ID of the Virtual network and subnet to be joined by Regional VNET Integration.
        /// This must be of the form /subscriptions/{subscriptionName}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
        /// </param>
        /// <param name="managedEnvironmentId"> Azure Resource Manager ID of the customer's selected Managed Environment on which to host this app. This must be of the form /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.App/managedEnvironments/{managedEnvironmentName}. </param>
        /// <param name="sku"> Current SKU of application based on associated App Service Plan. Some valid SKU values are Free, Shared, Basic, Dynamic, FlexConsumption, Standard, Premium, PremiumV2, PremiumV3, Isolated, IsolatedV2. </param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.WebSiteData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebSiteData WebSiteData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, ExtendedLocation extendedLocation, string state, IEnumerable<string> hostNames, string repositorySiteName, AppServiceUsageState? usageState, bool? isEnabled, IEnumerable<string> enabledHostNames, WebSiteAvailabilityState? availabilityState, IEnumerable<HostNameSslState> hostNameSslStates, ResourceIdentifier appServicePlanId, bool? isReserved, bool? isXenon, bool? isHyperV, DateTimeOffset? lastModifiedTimeUtc, SiteDnsConfig dnsConfiguration, bool? isVnetRouteAllEnabled, bool? isVnetImagePullEnabled, bool? isVnetContentShareEnabled, bool? isVnetBackupRestoreEnabled, SiteConfigProperties siteConfig, FunctionAppConfig functionAppConfig, AppDaprConfig daprConfig, string workloadProfileName, FunctionAppResourceConfig resourceConfig, IEnumerable<string> trafficManagerHostNames, bool? isScmSiteAlsoStopped, string targetSwapSlot, HostingEnvironmentProfile hostingEnvironmentProfile, bool? isClientAffinityEnabled, bool? isClientCertEnabled, ClientCertMode? clientCertMode, string clientCertExclusionPaths, AppServiceIPMode? ipMode, bool? isEndToEndEncryptionEnabled, bool? isHostNameDisabled, string customDomainVerificationId, string outboundIPAddresses, string possibleOutboundIPAddresses, int? containerSize, int? dailyMemoryTimeQuota, DateTimeOffset? suspendOn, int? maxNumberOfWorkers, CloningInfo cloningInfo, string resourceGroup, bool? isDefaultContainer, string defaultHostName, SlotSwapStatus slotSwapStatus, bool? isHttpsOnly, RedundancyMode? redundancyMode, Guid? inProgressOperationId, string publicNetworkAccess, bool? isStorageAccountRequired, string keyVaultReferenceIdentity, AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope, ResourceIdentifier virtualNetworkSubnetId, string managedEnvironmentId, string sku, string kind)
            => WebSiteData(id, name, resourceType, systemData, tags, location, identity, extendedLocation, state, hostNames, repositorySiteName, usageState,
                            isEnabled, enabledHostNames, availabilityState, hostNameSslStates, appServicePlanId, isReserved, isXenon, isHyperV, lastModifiedTimeUtc, dnsConfiguration,
                            new OutboundVnetRouting() { IsAllTrafficEnabled = isVnetRouteAllEnabled, IsContentShareTrafficEnabled = isVnetContentShareEnabled, IsImagePullTrafficEnabled = isVnetImagePullEnabled, IsBackupRestoreTrafficEnabled = isVnetBackupRestoreEnabled },
                            siteConfig, functionAppConfig, daprConfig, workloadProfileName, resourceConfig, trafficManagerHostNames, isScmSiteAlsoStopped, targetSwapSlot,
                            hostingEnvironmentProfile, isClientAffinityEnabled, null, null, isClientCertEnabled, clientCertMode, clientCertExclusionPaths,
                            ipMode, isEndToEndEncryptionEnabled, null, isHostNameDisabled, customDomainVerificationId, outboundIPAddresses, possibleOutboundIPAddresses, containerSize, dailyMemoryTimeQuota, suspendOn,
                            maxNumberOfWorkers, cloningInfo, resourceGroup, isDefaultContainer, defaultHostName, slotSwapStatus, isHttpsOnly, redundancyMode, inProgressOperationId, publicNetworkAccess,
                            isStorageAccountRequired, keyVaultReferenceIdentity, autoGeneratedDomainNameLabelScope, virtualNetworkSubnetId, managedEnvironmentId, sku, kind);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.AppService.WebSiteData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> Managed service identity. </param>
        /// <param name="extendedLocation"> Extended Location. </param>
        /// <param name="state"> Current state of the app. </param>
        /// <param name="hostNames"> Hostnames associated with the app. </param>
        /// <param name="repositorySiteName"> Name of the repository site. </param>
        /// <param name="usageState"> State indicating whether the app has exceeded its quota usage. Read-only. </param>
        /// <param name="isEnabled"> &lt;code&gt;true&lt;/code&gt; if the app is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. Setting this value to false disables the app (takes the app offline). </param>
        /// <param name="enabledHostNames">
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </param>
        /// <param name="availabilityState"> Management information availability state for the app. </param>
        /// <param name="hostNameSslStates"> Hostname SSL states are used to manage the SSL bindings for app's hostnames. </param>
        /// <param name="appServicePlanId"> Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}". </param>
        /// <param name="isReserved"> &lt;code&gt;true&lt;/code&gt; if reserved; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isXenon"> Obsolete: Hyper-V sandbox. </param>
        /// <param name="isHyperV"> Hyper-V sandbox. </param>
        /// <param name="lastModifiedTimeUtc"> Last time the app was modified, in UTC. Read-only. </param>
        /// <param name="dnsConfiguration"> Property to configure various DNS related settings for a site. </param>
        /// <param name="isVnetRouteAllEnabled"> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </param>
        /// <param name="isVnetImagePullEnabled"> To enable pulling image over Virtual Network. </param>
        /// <param name="isVnetContentShareEnabled"> To enable accessing content over virtual network. </param>
        /// <param name="isVnetBackupRestoreEnabled"> To enable Backup and Restore operations over virtual network. </param>
        /// <param name="siteConfig"> Configuration of the app. </param>
        /// <param name="functionAppConfig"> Configuration specific of the Azure Function app. </param>
        /// <param name="daprConfig"> Dapr configuration of the app. </param>
        /// <param name="workloadProfileName"> Workload profile name for function app to execute on. </param>
        /// <param name="resourceConfig"> Function app resource requirements. </param>
        /// <param name="trafficManagerHostNames"> Azure Traffic Manager hostnames associated with the app. Read-only. </param>
        /// <param name="isScmSiteAlsoStopped"> &lt;code&gt;true&lt;/code&gt; to stop SCM (KUDU) site when the app is stopped; otherwise, &lt;code&gt;false&lt;/code&gt;. The default is &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="targetSwapSlot"> Specifies which deployment slot this app will swap into. Read-only. </param>
        /// <param name="hostingEnvironmentProfile"> App Service Environment to use for the app. </param>
        /// <param name="isClientAffinityEnabled"> &lt;code&gt;true&lt;/code&gt; to enable client affinity; &lt;code&gt;false&lt;/code&gt; to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is &lt;code&gt;true&lt;/code&gt;. </param>
        /// <param name="isClientCertEnabled"> &lt;code&gt;true&lt;/code&gt; to enable client certificate authentication (TLS mutual authentication); otherwise, &lt;code&gt;false&lt;/code&gt;. Default is &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="clientCertMode">
        /// This composes with ClientCertEnabled setting.
        /// - ClientCertEnabled: false means ClientCert is ignored.
        /// - ClientCertEnabled: true and ClientCertMode: Required means ClientCert is required.
        /// - ClientCertEnabled: true and ClientCertMode: Optional means ClientCert is optional or accepted.
        /// </param>
        /// <param name="clientCertExclusionPaths"> client certificate authentication comma-separated exclusion paths. </param>
        /// <param name="isHostNameDisabled">
        /// &lt;code&gt;true&lt;/code&gt; to disable the public hostnames of the app; otherwise, &lt;code&gt;false&lt;/code&gt;.
        /// If &lt;code&gt;true&lt;/code&gt;, the app is only accessible via API management process.
        /// </param>
        /// <param name="customDomainVerificationId"> Unique identifier that verifies the custom domains assigned to the app. Customer will add this id to a txt record for verification. </param>
        /// <param name="outboundIPAddresses"> List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that site can be hosted with current settings. Read-only. </param>
        /// <param name="possibleOutboundIPAddresses"> List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants except dataComponent. Read-only. </param>
        /// <param name="containerSize"> Size of the function container. </param>
        /// <param name="dailyMemoryTimeQuota"> Maximum allowed daily memory-time quota (applicable on dynamic apps only). </param>
        /// <param name="suspendOn"> App suspended till in case memory-time quota is exceeded. </param>
        /// <param name="maxNumberOfWorkers">
        /// Maximum number of workers.
        /// This only applies to Functions container.
        /// </param>
        /// <param name="cloningInfo"> If specified during app creation, the app is cloned from a source app. </param>
        /// <param name="resourceGroup"> Name of the resource group the app belongs to. Read-only. </param>
        /// <param name="isDefaultContainer"> &lt;code&gt;true&lt;/code&gt; if the app is a default container; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="defaultHostName"> Default hostname of the app. Read-only. </param>
        /// <param name="slotSwapStatus"> Status of the last deployment slot swap operation. </param>
        /// <param name="isHttpsOnly">
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        /// http requests
        /// </param>
        /// <param name="redundancyMode"> Site redundancy mode. </param>
        /// <param name="inProgressOperationId"> Specifies an operation id if this site has a pending operation. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. Allowed Values: 'Enabled', 'Disabled' or an empty string. </param>
        /// <param name="isStorageAccountRequired"> Checks if Customer provided storage account is required. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="virtualNetworkSubnetId">
        /// Azure Resource Manager ID of the Virtual network and subnet to be joined by Regional VNET Integration.
        /// This must be of the form /subscriptions/{subscriptionName}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
        /// </param>
        /// <param name="managedEnvironmentId"> Azure Resource Manager ID of the customer's selected Managed Environment on which to host this app. This must be of the form /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.App/managedEnvironments/{managedEnvironmentName}. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.AppService.WebSiteData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebSiteData WebSiteData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, ExtendedLocation extendedLocation, string state, IEnumerable<string> hostNames, string repositorySiteName, AppServiceUsageState? usageState, bool? isEnabled, IEnumerable<string> enabledHostNames, WebSiteAvailabilityState? availabilityState, IEnumerable<HostNameSslState> hostNameSslStates, ResourceIdentifier appServicePlanId, bool? isReserved, bool? isXenon, bool? isHyperV, DateTimeOffset? lastModifiedTimeUtc, SiteDnsConfig dnsConfiguration, bool? isVnetRouteAllEnabled, bool? isVnetImagePullEnabled, bool? isVnetContentShareEnabled, bool? isVnetBackupRestoreEnabled, SiteConfigProperties siteConfig, FunctionAppConfig functionAppConfig, AppDaprConfig daprConfig, string workloadProfileName, FunctionAppResourceConfig resourceConfig, IEnumerable<string> trafficManagerHostNames, bool? isScmSiteAlsoStopped, string targetSwapSlot, HostingEnvironmentProfile hostingEnvironmentProfile, bool? isClientAffinityEnabled, bool? isClientCertEnabled, ClientCertMode? clientCertMode, string clientCertExclusionPaths, bool? isHostNameDisabled, string customDomainVerificationId, string outboundIPAddresses, string possibleOutboundIPAddresses, int? containerSize, int? dailyMemoryTimeQuota, DateTimeOffset? suspendOn, int? maxNumberOfWorkers, CloningInfo cloningInfo, string resourceGroup, bool? isDefaultContainer, string defaultHostName, SlotSwapStatus slotSwapStatus, bool? isHttpsOnly, RedundancyMode? redundancyMode, Guid? inProgressOperationId, string publicNetworkAccess, bool? isStorageAccountRequired, string keyVaultReferenceIdentity, ResourceIdentifier virtualNetworkSubnetId, string managedEnvironmentId, string kind)
        {
            return WebSiteData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, identity: identity, extendedLocation: extendedLocation, state: state, hostNames: hostNames, repositorySiteName: repositorySiteName, usageState: usageState, isEnabled: isEnabled, enabledHostNames: enabledHostNames, availabilityState: availabilityState, hostNameSslStates: hostNameSslStates, appServicePlanId: appServicePlanId, isReserved: isReserved, isXenon: isXenon, isHyperV: isHyperV, lastModifiedTimeUtc: lastModifiedTimeUtc, dnsConfiguration: dnsConfiguration, isVnetRouteAllEnabled: isVnetRouteAllEnabled, isVnetImagePullEnabled: isVnetImagePullEnabled, isVnetContentShareEnabled: isVnetContentShareEnabled, isVnetBackupRestoreEnabled: isVnetBackupRestoreEnabled, siteConfig: siteConfig, functionAppConfig: functionAppConfig, daprConfig: daprConfig, workloadProfileName: workloadProfileName, resourceConfig: resourceConfig, trafficManagerHostNames: trafficManagerHostNames, isScmSiteAlsoStopped: isScmSiteAlsoStopped, targetSwapSlot: targetSwapSlot, hostingEnvironmentProfile: hostingEnvironmentProfile, isClientAffinityEnabled: isClientAffinityEnabled, isClientCertEnabled: isClientCertEnabled, clientCertMode: clientCertMode, clientCertExclusionPaths: clientCertExclusionPaths, ipMode: default, isEndToEndEncryptionEnabled: default, isHostNameDisabled: isHostNameDisabled, customDomainVerificationId: customDomainVerificationId, outboundIPAddresses: outboundIPAddresses, possibleOutboundIPAddresses: possibleOutboundIPAddresses, containerSize: containerSize, dailyMemoryTimeQuota: dailyMemoryTimeQuota, suspendOn: suspendOn, maxNumberOfWorkers: maxNumberOfWorkers, cloningInfo: cloningInfo, resourceGroup: resourceGroup, isDefaultContainer: isDefaultContainer, defaultHostName: defaultHostName, slotSwapStatus: slotSwapStatus, isHttpsOnly: isHttpsOnly, redundancyMode: redundancyMode, inProgressOperationId: inProgressOperationId, publicNetworkAccess: publicNetworkAccess, isStorageAccountRequired: isStorageAccountRequired, keyVaultReferenceIdentity: keyVaultReferenceIdentity, autoGeneratedDomainNameLabelScope: default, virtualNetworkSubnetId: virtualNetworkSubnetId, managedEnvironmentId: managedEnvironmentId, sku: default, kind: kind);
        }
    }
}
