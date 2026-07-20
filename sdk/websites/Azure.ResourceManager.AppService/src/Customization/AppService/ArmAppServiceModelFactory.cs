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
        public static WebSiteData WebSiteData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, ExtendedLocation extendedLocation, string state, IEnumerable<string> hostNames, string repositorySiteName, AppServiceUsageState? usageState, bool? isEnabled, IEnumerable<string> enabledHostNames, WebSiteAvailabilityState? availabilityState, IEnumerable<HostNameSslState> hostNameSslStates, ResourceIdentifier appServicePlanId, bool? isReserved, bool? isXenon, bool? isHyperV, DateTimeOffset? lastModifiedTimeUtc, SiteDnsConfig dnsConfiguration, bool? isVnetRouteAllEnabled, bool? isVnetImagePullEnabled, bool? isVnetContentShareEnabled, bool? isVnetBackupRestoreEnabled, SiteConfigProperties siteConfig, FunctionAppConfig functionAppConfig, AppDaprConfig daprConfig, string workloadProfileName, FunctionAppResourceConfig resourceConfig, IEnumerable<string> trafficManagerHostNames, bool? isScmSiteAlsoStopped, string targetSwapSlot, HostingEnvironmentProfile hostingEnvironmentProfile, bool? isClientAffinityEnabled, bool? isClientCertEnabled, ClientCertMode? clientCertMode, string clientCertExclusionPaths, AppServiceIPMode? ipMode, bool? isEndToEndEncryptionEnabled, bool? isHostNameDisabled, string customDomainVerificationId, string outboundIPAddresses, string possibleOutboundIPAddresses, int? containerSize, int? dailyMemoryTimeQuota, DateTimeOffset? suspendOn, int? maxNumberOfWorkers, CloningInfo cloningInfo, string resourceGroup, bool? isDefaultContainer, string defaultHostName, SlotSwapStatus slotSwapStatus, bool? isHttpsOnly, RedundancyMode? redundancyMode, Guid? inProgressOperationId, string publicNetworkAccess, bool? isStorageAccountRequired, string keyVaultReferenceIdentity, AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope, ResourceIdentifier virtualNetworkSubnetId, string managedEnvironmentId, string sku, string kind)
            => WebSiteData(id, name, resourceType, systemData, tags, location, identity, extendedLocation, kind, state, hostNames, repositorySiteName, usageState,
                            isEnabled, enabledHostNames, availabilityState, hostNameSslStates, appServicePlanId, isReserved, isXenon, isHyperV, lastModifiedTimeUtc, dnsConfiguration,
                            new OutboundVnetRouting() { IsAllTrafficEnabled = isVnetRouteAllEnabled, IsContentShareTrafficEnabled = isVnetContentShareEnabled, IsImagePullTrafficEnabled = isVnetImagePullEnabled, IsBackupRestoreTrafficEnabled = isVnetBackupRestoreEnabled },
                            siteConfig, functionAppConfig, daprConfig, workloadProfileName, resourceConfig, trafficManagerHostNames, isScmSiteAlsoStopped, targetSwapSlot,
                            hostingEnvironmentProfile, isClientAffinityEnabled, null, null, isClientCertEnabled, clientCertMode, clientCertExclusionPaths,
                            ipMode, isEndToEndEncryptionEnabled, null, isHostNameDisabled, customDomainVerificationId, outboundIPAddresses, possibleOutboundIPAddresses, containerSize, dailyMemoryTimeQuota, suspendOn,
                            maxNumberOfWorkers, cloningInfo, resourceGroup, isDefaultContainer, defaultHostName, slotSwapStatus, isHttpsOnly, redundancyMode, inProgressOperationId, publicNetworkAccess,
                            isStorageAccountRequired, keyVaultReferenceIdentity, autoGeneratedDomainNameLabelScope, virtualNetworkSubnetId, managedEnvironmentId, sku);

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
        public static WebSiteData WebSiteData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, ExtendedLocation extendedLocation, string state, IEnumerable<string> hostNames, string repositorySiteName, AppServiceUsageState? usageState, bool? isEnabled, IEnumerable<string> enabledHostNames, WebSiteAvailabilityState? availabilityState, IEnumerable<HostNameSslState> hostNameSslStates, ResourceIdentifier appServicePlanId, bool? isReserved, bool? isXenon, bool? isHyperV, DateTimeOffset? lastModifiedTimeUtc, SiteDnsConfig dnsConfiguration, bool? isVnetRouteAllEnabled, bool? isVnetImagePullEnabled, bool? isVnetContentShareEnabled, bool? isVnetBackupRestoreEnabled, SiteConfigProperties siteConfig, FunctionAppConfig functionAppConfig, AppDaprConfig daprConfig, string workloadProfileName, FunctionAppResourceConfig resourceConfig, IEnumerable<string> trafficManagerHostNames, bool? isScmSiteAlsoStopped, string targetSwapSlot, HostingEnvironmentProfile hostingEnvironmentProfile, bool? isClientAffinityEnabled, bool? isClientCertEnabled, ClientCertMode? clientCertMode, string clientCertExclusionPaths, bool? isHostNameDisabled, string customDomainVerificationId, string outboundIPAddresses, string possibleOutboundIPAddresses, int? containerSize, int? dailyMemoryTimeQuota, DateTimeOffset? suspendOn, int? maxNumberOfWorkers, CloningInfo cloningInfo, string resourceGroup, bool? isDefaultContainer, string defaultHostName, SlotSwapStatus slotSwapStatus, bool? isHttpsOnly, RedundancyMode? redundancyMode, Guid? inProgressOperationId, string publicNetworkAccess, bool? isStorageAccountRequired, string keyVaultReferenceIdentity, ResourceIdentifier virtualNetworkSubnetId, string managedEnvironmentId, string kind)
        {
            return WebSiteData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, identity: identity, extendedLocation: extendedLocation, state: state, hostNames: hostNames, repositorySiteName: repositorySiteName, usageState: usageState, isEnabled: isEnabled, enabledHostNames: enabledHostNames, availabilityState: availabilityState, hostNameSslStates: hostNameSslStates, appServicePlanId: appServicePlanId, isReserved: isReserved, isXenon: isXenon, isHyperV: isHyperV, lastModifiedTimeUtc: lastModifiedTimeUtc, dnsConfiguration: dnsConfiguration, isVnetRouteAllEnabled: isVnetRouteAllEnabled, isVnetImagePullEnabled: isVnetImagePullEnabled, isVnetContentShareEnabled: isVnetContentShareEnabled, isVnetBackupRestoreEnabled: isVnetBackupRestoreEnabled, siteConfig: siteConfig, functionAppConfig: functionAppConfig, daprConfig: daprConfig, workloadProfileName: workloadProfileName, resourceConfig: resourceConfig, trafficManagerHostNames: trafficManagerHostNames, isScmSiteAlsoStopped: isScmSiteAlsoStopped, targetSwapSlot: targetSwapSlot, hostingEnvironmentProfile: hostingEnvironmentProfile, isClientAffinityEnabled: isClientAffinityEnabled, isClientCertEnabled: isClientCertEnabled, clientCertMode: clientCertMode, clientCertExclusionPaths: clientCertExclusionPaths, ipMode: default, isEndToEndEncryptionEnabled: default, isHostNameDisabled: isHostNameDisabled, customDomainVerificationId: customDomainVerificationId, outboundIPAddresses: outboundIPAddresses, possibleOutboundIPAddresses: possibleOutboundIPAddresses, containerSize: containerSize, dailyMemoryTimeQuota: dailyMemoryTimeQuota, suspendOn: suspendOn, maxNumberOfWorkers: maxNumberOfWorkers, cloningInfo: cloningInfo, resourceGroup: resourceGroup, isDefaultContainer: isDefaultContainer, defaultHostName: defaultHostName, slotSwapStatus: slotSwapStatus, isHttpsOnly: isHttpsOnly, redundancyMode: redundancyMode, inProgressOperationId: inProgressOperationId, publicNetworkAccess: publicNetworkAccess, isStorageAccountRequired: isStorageAccountRequired, keyVaultReferenceIdentity: keyVaultReferenceIdentity, autoGeneratedDomainNameLabelScope: default, virtualNetworkSubnetId: virtualNetworkSubnetId, managedEnvironmentId: managedEnvironmentId, sku: default, kind: kind);
        }

        // This method is added to resolve api compatibility issue caused by rename url property for issue #56828
        /// <summary> Initializes a new instance of <see cref="AppService.SiteConfigData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="numberOfWorkers"> Number of workers. </param>
        /// <param name="defaultDocuments"> Default documents. </param>
        /// <param name="netFrameworkVersion"> .NET Framework version. </param>
        /// <param name="phpVersion"> Version of PHP. </param>
        /// <param name="pythonVersion"> Version of Python. </param>
        /// <param name="nodeVersion"> Version of Node.js. </param>
        /// <param name="powerShellVersion"> Version of PowerShell. </param>
        /// <param name="linuxFxVersion"> Linux App Framework and version. </param>
        /// <param name="windowsFxVersion"> Xenon App Framework and version. </param>
        /// <param name="isRequestTracingEnabled"> &lt;code&gt;true&lt;/code&gt; if request tracing is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="requestTracingExpirationOn"> Request tracing expiration time. </param>
        /// <param name="isRemoteDebuggingEnabled"> &lt;code&gt;true&lt;/code&gt; if remote debugging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="remoteDebuggingVersion"> Remote debugging version. </param>
        /// <param name="isHttpLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if HTTP logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="useManagedIdentityCreds"> Flag to use Managed Identity Creds for ACR pull. </param>
        /// <param name="acrUserManagedIdentityId"> If using user managed identity, the user managed identity ClientId. </param>
        /// <param name="logsDirectorySizeLimit"> HTTP logs directory size limit. </param>
        /// <param name="isDetailedErrorLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if detailed error logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="publishingUsername"> Publishing user name. </param>
        /// <param name="appSettings"> Application settings. This property is not returned in response to normal create and read requests since it may contain sensitive information. </param>
        /// <param name="metadata"> Application metadata. This property cannot be retrieved, since it may contain secrets. </param>
        /// <param name="connectionStrings"> Connection strings. This property is not returned in response to normal create and read requests since it may contain sensitive information. </param>
        /// <param name="machineKey"> Site MachineKey. </param>
        /// <param name="handlerMappings"> Handler mappings. </param>
        /// <param name="documentRoot"> Document root. </param>
        /// <param name="scmType"> SCM type. </param>
        /// <param name="use32BitWorkerProcess"> &lt;code&gt;true&lt;/code&gt; to use 32-bit worker process; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isWebSocketsEnabled"> &lt;code&gt;true&lt;/code&gt; if WebSocket is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isAlwaysOn"> &lt;code&gt;true&lt;/code&gt; if Always On is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="javaVersion"> Java version. </param>
        /// <param name="javaContainer"> Java container. </param>
        /// <param name="javaContainerVersion"> Java container version. </param>
        /// <param name="appCommandLine"> App command line to launch. </param>
        /// <param name="managedPipelineMode"> Managed pipeline mode. </param>
        /// <param name="virtualApplications"> Virtual applications. </param>
        /// <param name="loadBalancing"> Site load balancing. </param>
        /// <param name="experimentsRampUpRules"> This is work around for polymorphic types. </param>
        /// <param name="limits"> Site limits. </param>
        /// <param name="isAutoHealEnabled"> &lt;code&gt;true&lt;/code&gt; if Auto Heal is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="autoHealRules"> Auto Heal rules. </param>
        /// <param name="tracingOptions"> Tracing options. </param>
        /// <param name="vnetName"> Virtual Network name. </param>
        /// <param name="isVnetRouteAllEnabled"> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </param>
        /// <param name="vnetPrivatePortsCount"> The number of private ports assigned to this app. These will be assigned dynamically on runtime. </param>
        /// <param name="cors"> Cross-Origin Resource Sharing (CORS) settings. </param>
        /// <param name="push"> Push endpoint settings. </param>
        /// <param name="apiDefinitionUri"> Information about the formal API definition for the app. </param>
        /// <param name="apiManagementConfigId"> Azure API management settings linked to the app. </param>
        /// <param name="autoSwapSlotName"> Auto-swap slot name. </param>
        /// <param name="isLocalMySqlEnabled"> &lt;code&gt;true&lt;/code&gt; to enable local MySQL; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="managedServiceIdentityId"> Managed Service Identity Id. </param>
        /// <param name="xManagedServiceIdentityId"> Explicit Managed Service Identity Id. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="ipSecurityRestrictions"> IP security restrictions for main. </param>
        /// <param name="ipSecurityRestrictionsDefaultAction"> Default action for main access restriction if no rules are matched. </param>
        /// <param name="scmIPSecurityRestrictions"> IP security restrictions for scm. </param>
        /// <param name="scmIPSecurityRestrictionsDefaultAction"> Default action for scm access restriction if no rules are matched. </param>
        /// <param name="allowIPSecurityRestrictionsForScmToUseMain"> IP security restrictions for scm to use main. </param>
        /// <param name="isHttp20Enabled"> Http20Enabled: configures a web site to allow clients to connect over http2.0. </param>
        /// <param name="http20ProxyFlag"> Http20ProxyFlag: Configures a website to allow http2.0 to pass be proxied all the way to the app. 0 = disabled, 1 = pass through all http2 traffic, 2 = pass through gRPC only. </param>
        /// <param name="minTlsVersion"> MinTlsVersion: configures the minimum version of TLS required for SSL requests. </param>
        /// <param name="minTlsCipherSuite"> The minimum strength TLS cipher suite allowed for an application. </param>
        /// <param name="scmMinTlsVersion"> ScmMinTlsVersion: configures the minimum version of TLS required for SSL requests for SCM site. </param>
        /// <param name="ftpsState"> State of FTP / FTPS service. </param>
        /// <param name="preWarmedInstanceCount">
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </param>
        /// <param name="functionAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to the Consumption and Elastic Premium Plans
        /// </param>
        /// <param name="elasticWebAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to apps in plans where ElasticScaleEnabled is &lt;code&gt;true&lt;/code&gt;
        /// </param>
        /// <param name="healthCheckPath"> Health check path. </param>
        /// <param name="isFunctionsRuntimeScaleMonitoringEnabled">
        /// Gets or sets a value indicating whether functions runtime scale monitoring is enabled. When enabled,
        /// the ScaleController will not monitor event sources directly, but will instead call to the
        /// runtime to get scale status.
        /// </param>
        /// <param name="websiteTimeZone"> Sets the time zone a site uses for generating timestamps. Compatible with Linux and Windows App Service. Setting the WEBSITE_TIME_ZONE app setting takes precedence over this config. For Linux, expects tz database values https://www.iana.org/time-zones (for a quick reference see https://en.wikipedia.org/wiki/List_of_tz_database_time_zones). For Windows, expects one of the time zones listed under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones. </param>
        /// <param name="minimumElasticInstanceCount">
        /// Number of minimum instance count for a site
        /// This setting only applies to the Elastic Plans
        /// </param>
        /// <param name="azureStorageAccounts"> List of Azure Storage Accounts. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SiteConfigData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteConfigData SiteConfigData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? numberOfWorkers = null, IEnumerable<string> defaultDocuments = null, string netFrameworkVersion = null, string phpVersion = null, string pythonVersion = null, string nodeVersion = null, string powerShellVersion = null, string linuxFxVersion = null, string windowsFxVersion = null, bool? isRequestTracingEnabled = null, DateTimeOffset? requestTracingExpirationOn = null, bool? isRemoteDebuggingEnabled = null, string remoteDebuggingVersion = null, bool? isHttpLoggingEnabled = null, bool? useManagedIdentityCreds = null, string acrUserManagedIdentityId = null, int? logsDirectorySizeLimit = null, bool? isDetailedErrorLoggingEnabled = null, string publishingUsername = null, IEnumerable<AppServiceNameValuePair> appSettings = null, IEnumerable<AppServiceNameValuePair> metadata = null, IEnumerable<ConnStringInfo> connectionStrings = null, SiteMachineKey machineKey = null, IEnumerable<HttpRequestHandlerMapping> handlerMappings = null, string documentRoot = null, ScmType? scmType = null, bool? use32BitWorkerProcess = null, bool? isWebSocketsEnabled = null, bool? isAlwaysOn = null, string javaVersion = null, string javaContainer = null, string javaContainerVersion = null, string appCommandLine = null, ManagedPipelineMode? managedPipelineMode = null, IEnumerable<VirtualApplication> virtualApplications = null, SiteLoadBalancing? loadBalancing = null, IEnumerable<RampUpRule> experimentsRampUpRules = null, SiteLimits limits = null, bool? isAutoHealEnabled = null, AutoHealRules autoHealRules = null, string tracingOptions = null, string vnetName = null, bool? isVnetRouteAllEnabled = null, int? vnetPrivatePortsCount = null, AppServiceCorsSettings cors = null, WebAppPushSettings push = null, Uri apiDefinitionUri = null, string apiManagementConfigId = null, string autoSwapSlotName = null, bool? isLocalMySqlEnabled = null, int? managedServiceIdentityId = null, int? xManagedServiceIdentityId = null, string keyVaultReferenceIdentity = null, IEnumerable<AppServiceIPSecurityRestriction> ipSecurityRestrictions = null, SiteDefaultAction? ipSecurityRestrictionsDefaultAction = null, IEnumerable<AppServiceIPSecurityRestriction> scmIPSecurityRestrictions = null, SiteDefaultAction? scmIPSecurityRestrictionsDefaultAction = null, bool? allowIPSecurityRestrictionsForScmToUseMain = null, bool? isHttp20Enabled = null, int? http20ProxyFlag = null, AppServiceSupportedTlsVersion? minTlsVersion = null, AppServiceTlsCipherSuite? minTlsCipherSuite = null, AppServiceSupportedTlsVersion? scmMinTlsVersion = null, AppServiceFtpsState? ftpsState = null, int? preWarmedInstanceCount = null, int? functionAppScaleLimit = null, int? elasticWebAppScaleLimit = null, string healthCheckPath = null, bool? isFunctionsRuntimeScaleMonitoringEnabled = null, string websiteTimeZone = null, int? minimumElasticInstanceCount = null, IDictionary<string, AppServiceStorageAccessInfo> azureStorageAccounts = null, string publicNetworkAccess = null, string kind = null)
        {
            defaultDocuments ??= new List<string>();
            appSettings ??= new List<AppServiceNameValuePair>();
            metadata ??= new List<AppServiceNameValuePair>();
            connectionStrings ??= new List<ConnStringInfo>();
            handlerMappings ??= new List<HttpRequestHandlerMapping>();
            virtualApplications ??= new List<VirtualApplication>();
            experimentsRampUpRules ??= new List<RampUpRule>();
            ipSecurityRestrictions ??= new List<AppServiceIPSecurityRestriction>();
            scmIPSecurityRestrictions ??= new List<AppServiceIPSecurityRestriction>();
            azureStorageAccounts ??= new Dictionary<string, AppServiceStorageAccessInfo>();

            return new SiteConfigData(id, name, resourceType, systemData, kind, numberOfWorkers, defaultDocuments.ToList(), netFrameworkVersion, phpVersion, pythonVersion, nodeVersion, powerShellVersion, linuxFxVersion, windowsFxVersion, isRequestTracingEnabled, requestTracingExpirationOn, isRemoteDebuggingEnabled, remoteDebuggingVersion, isHttpLoggingEnabled, useManagedIdentityCreds, acrUserManagedIdentityId, logsDirectorySizeLimit, isDetailedErrorLoggingEnabled, publishingUsername, appSettings.ToList(), metadata.ToList(), connectionStrings.ToList(), machineKey, handlerMappings.ToList(), documentRoot, scmType, use32BitWorkerProcess, isWebSocketsEnabled, isAlwaysOn, javaVersion, javaContainer, javaContainerVersion, appCommandLine, managedPipelineMode, virtualApplications.ToList(), loadBalancing, new RoutingRuleExperiments(), limits, isAutoHealEnabled, autoHealRules, tracingOptions, vnetName, isVnetRouteAllEnabled, vnetPrivatePortsCount, cors, push, new AppServiceApiDefinitionInfo(), new ApiManagementConfig(), autoSwapSlotName, isLocalMySqlEnabled, managedServiceIdentityId, xManagedServiceIdentityId, keyVaultReferenceIdentity, ipSecurityRestrictions.ToList(), ipSecurityRestrictionsDefaultAction, scmIPSecurityRestrictions.ToList(), scmIPSecurityRestrictionsDefaultAction, allowIPSecurityRestrictionsForScmToUseMain, isHttp20Enabled, http20ProxyFlag, minTlsVersion, minTlsCipherSuite, scmMinTlsVersion, ftpsState, preWarmedInstanceCount, functionAppScaleLimit, elasticWebAppScaleLimit, healthCheckPath, isFunctionsRuntimeScaleMonitoringEnabled, websiteTimeZone, minimumElasticInstanceCount, azureStorageAccounts, publicNetworkAccess, null);
        }

        // This method is added to resolve api compatibility issue caused by rename url property for issue #56828
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.AppService.SiteConfigData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="numberOfWorkers"> Number of workers. </param>
        /// <param name="defaultDocuments"> Default documents. </param>
        /// <param name="netFrameworkVersion"> .NET Framework version. </param>
        /// <param name="phpVersion"> Version of PHP. </param>
        /// <param name="pythonVersion"> Version of Python. </param>
        /// <param name="nodeVersion"> Version of Node.js. </param>
        /// <param name="powerShellVersion"> Version of PowerShell. </param>
        /// <param name="linuxFxVersion"> Linux App Framework and version. </param>
        /// <param name="windowsFxVersion"> Xenon App Framework and version. </param>
        /// <param name="isRequestTracingEnabled"> &lt;code&gt;true&lt;/code&gt; if request tracing is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="requestTracingExpirationOn"> Request tracing expiration time. </param>
        /// <param name="isRemoteDebuggingEnabled"> &lt;code&gt;true&lt;/code&gt; if remote debugging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="remoteDebuggingVersion"> Remote debugging version. </param>
        /// <param name="isHttpLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if HTTP logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="useManagedIdentityCreds"> Flag to use Managed Identity Creds for ACR pull. </param>
        /// <param name="acrUserManagedIdentityId"> If using user managed identity, the user managed identity ClientId. </param>
        /// <param name="logsDirectorySizeLimit"> HTTP logs directory size limit. </param>
        /// <param name="isDetailedErrorLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if detailed error logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="publishingUsername"> Publishing user name. </param>
        /// <param name="appSettings"> Application settings. </param>
        /// <param name="metadata"> Application metadata. This property cannot be retrieved, since it may contain secrets. </param>
        /// <param name="connectionStrings"> Connection strings. </param>
        /// <param name="machineKey"> Site MachineKey. </param>
        /// <param name="handlerMappings"> Handler mappings. </param>
        /// <param name="documentRoot"> Document root. </param>
        /// <param name="scmType"> SCM type. </param>
        /// <param name="use32BitWorkerProcess"> &lt;code&gt;true&lt;/code&gt; to use 32-bit worker process; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isWebSocketsEnabled"> &lt;code&gt;true&lt;/code&gt; if WebSocket is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isAlwaysOn"> &lt;code&gt;true&lt;/code&gt; if Always On is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="javaVersion"> Java version. </param>
        /// <param name="javaContainer"> Java container. </param>
        /// <param name="javaContainerVersion"> Java container version. </param>
        /// <param name="appCommandLine"> App command line to launch. </param>
        /// <param name="managedPipelineMode"> Managed pipeline mode. </param>
        /// <param name="virtualApplications"> Virtual applications. </param>
        /// <param name="loadBalancing"> Site load balancing. </param>
        /// <param name="experimentsRampUpRules"> This is work around for polymorphic types. </param>
        /// <param name="limits"> Site limits. </param>
        /// <param name="isAutoHealEnabled"> &lt;code&gt;true&lt;/code&gt; if Auto Heal is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="autoHealRules"> Auto Heal rules. </param>
        /// <param name="tracingOptions"> Tracing options. </param>
        /// <param name="vnetName"> Virtual Network name. </param>
        /// <param name="isVnetRouteAllEnabled"> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </param>
        /// <param name="vnetPrivatePortsCount"> The number of private ports assigned to this app. These will be assigned dynamically on runtime. </param>
        /// <param name="cors"> Cross-Origin Resource Sharing (CORS) settings. </param>
        /// <param name="push"> Push endpoint settings. </param>
        /// <param name="apiDefinitionUri"> Information about the formal API definition for the app. </param>
        /// <param name="apiManagementConfigId"> Azure API management settings linked to the app. </param>
        /// <param name="autoSwapSlotName"> Auto-swap slot name. </param>
        /// <param name="isLocalMySqlEnabled"> &lt;code&gt;true&lt;/code&gt; to enable local MySQL; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="managedServiceIdentityId"> Managed Service Identity Id. </param>
        /// <param name="xManagedServiceIdentityId"> Explicit Managed Service Identity Id. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="ipSecurityRestrictions"> IP security restrictions for main. </param>
        /// <param name="ipSecurityRestrictionsDefaultAction"> Default action for main access restriction if no rules are matched. </param>
        /// <param name="scmIPSecurityRestrictions"> IP security restrictions for scm. </param>
        /// <param name="scmIPSecurityRestrictionsDefaultAction"> Default action for scm access restriction if no rules are matched. </param>
        /// <param name="allowIPSecurityRestrictionsForScmToUseMain"> IP security restrictions for scm to use main. </param>
        /// <param name="isHttp20Enabled"> Http20Enabled: configures a web site to allow clients to connect over http2.0. </param>
        /// <param name="minTlsVersion"> MinTlsVersion: configures the minimum version of TLS required for SSL requests. </param>
        /// <param name="minTlsCipherSuite"> The minimum strength TLS cipher suite allowed for an application. </param>
        /// <param name="scmMinTlsVersion"> ScmMinTlsVersion: configures the minimum version of TLS required for SSL requests for SCM site. </param>
        /// <param name="ftpsState"> State of FTP / FTPS service. </param>
        /// <param name="preWarmedInstanceCount">
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </param>
        /// <param name="functionAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to the Consumption and Elastic Premium Plans
        /// </param>
        /// <param name="elasticWebAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to apps in plans where ElasticScaleEnabled is &lt;code&gt;true&lt;/code&gt;
        /// </param>
        /// <param name="healthCheckPath"> Health check path. </param>
        /// <param name="isFunctionsRuntimeScaleMonitoringEnabled">
        /// Gets or sets a value indicating whether functions runtime scale monitoring is enabled. When enabled,
        /// the ScaleController will not monitor event sources directly, but will instead call to the
        /// runtime to get scale status.
        /// </param>
        /// <param name="websiteTimeZone"> Sets the time zone a site uses for generating timestamps. Compatible with Linux and Windows App Service. Setting the WEBSITE_TIME_ZONE app setting takes precedence over this config. For Linux, expects tz database values https://www.iana.org/time-zones (for a quick reference see https://en.wikipedia.org/wiki/List_of_tz_database_time_zones). For Windows, expects one of the time zones listed under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones. </param>
        /// <param name="minimumElasticInstanceCount">
        /// Number of minimum instance count for a site
        /// This setting only applies to the Elastic Plans
        /// </param>
        /// <param name="azureStorageAccounts"> List of Azure Storage Accounts. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.AppService.SiteConfigData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteConfigData SiteConfigData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, int? numberOfWorkers, IEnumerable<string> defaultDocuments, string netFrameworkVersion, string phpVersion, string pythonVersion, string nodeVersion, string powerShellVersion, string linuxFxVersion, string windowsFxVersion, bool? isRequestTracingEnabled, DateTimeOffset? requestTracingExpirationOn, bool? isRemoteDebuggingEnabled, string remoteDebuggingVersion, bool? isHttpLoggingEnabled, bool? useManagedIdentityCreds, string acrUserManagedIdentityId, int? logsDirectorySizeLimit, bool? isDetailedErrorLoggingEnabled, string publishingUsername, IEnumerable<AppServiceNameValuePair> appSettings, IEnumerable<AppServiceNameValuePair> metadata, IEnumerable<ConnStringInfo> connectionStrings, SiteMachineKey machineKey, IEnumerable<HttpRequestHandlerMapping> handlerMappings, string documentRoot, ScmType? scmType, bool? use32BitWorkerProcess, bool? isWebSocketsEnabled, bool? isAlwaysOn, string javaVersion, string javaContainer, string javaContainerVersion, string appCommandLine, ManagedPipelineMode? managedPipelineMode, IEnumerable<VirtualApplication> virtualApplications, SiteLoadBalancing? loadBalancing, IEnumerable<RampUpRule> experimentsRampUpRules, SiteLimits limits, bool? isAutoHealEnabled, AutoHealRules autoHealRules, string tracingOptions, string vnetName, bool? isVnetRouteAllEnabled, int? vnetPrivatePortsCount, AppServiceCorsSettings cors, WebAppPushSettings push, Uri apiDefinitionUri, string apiManagementConfigId, string autoSwapSlotName, bool? isLocalMySqlEnabled, int? managedServiceIdentityId, int? xManagedServiceIdentityId, string keyVaultReferenceIdentity, IEnumerable<AppServiceIPSecurityRestriction> ipSecurityRestrictions, SiteDefaultAction? ipSecurityRestrictionsDefaultAction, IEnumerable<AppServiceIPSecurityRestriction> scmIPSecurityRestrictions, SiteDefaultAction? scmIPSecurityRestrictionsDefaultAction, bool? allowIPSecurityRestrictionsForScmToUseMain, bool? isHttp20Enabled, AppServiceSupportedTlsVersion? minTlsVersion, AppServiceTlsCipherSuite? minTlsCipherSuite, AppServiceSupportedTlsVersion? scmMinTlsVersion, AppServiceFtpsState? ftpsState, int? preWarmedInstanceCount, int? functionAppScaleLimit, int? elasticWebAppScaleLimit, string healthCheckPath, bool? isFunctionsRuntimeScaleMonitoringEnabled, string websiteTimeZone, int? minimumElasticInstanceCount, IDictionary<string, AppServiceStorageAccessInfo> azureStorageAccounts, string publicNetworkAccess, string kind)
        {
            return SiteConfigData(id: id, name: name, resourceType: resourceType, systemData: systemData, numberOfWorkers: numberOfWorkers, defaultDocuments: defaultDocuments, netFrameworkVersion: netFrameworkVersion, phpVersion: phpVersion, pythonVersion: pythonVersion, nodeVersion: nodeVersion, powerShellVersion: powerShellVersion, linuxFxVersion: linuxFxVersion, windowsFxVersion: windowsFxVersion, isRequestTracingEnabled: isRequestTracingEnabled, requestTracingExpirationOn: requestTracingExpirationOn, isRemoteDebuggingEnabled: isRemoteDebuggingEnabled, remoteDebuggingVersion: remoteDebuggingVersion, isHttpLoggingEnabled: isHttpLoggingEnabled, useManagedIdentityCreds: useManagedIdentityCreds, acrUserManagedIdentityId: acrUserManagedIdentityId, logsDirectorySizeLimit: logsDirectorySizeLimit, isDetailedErrorLoggingEnabled: isDetailedErrorLoggingEnabled, publishingUsername: publishingUsername, appSettings: appSettings, metadata: metadata, connectionStrings: connectionStrings, machineKey: machineKey, handlerMappings: handlerMappings, documentRoot: documentRoot, scmType: scmType, use32BitWorkerProcess: use32BitWorkerProcess, isWebSocketsEnabled: isWebSocketsEnabled, isAlwaysOn: isAlwaysOn, javaVersion: javaVersion, javaContainer: javaContainer, javaContainerVersion: javaContainerVersion, appCommandLine: appCommandLine, managedPipelineMode: managedPipelineMode, virtualApplications: virtualApplications, loadBalancing: loadBalancing, experimentsRampUpRules: experimentsRampUpRules, limits: limits, isAutoHealEnabled: isAutoHealEnabled, autoHealRules: autoHealRules, tracingOptions: tracingOptions, vnetName: vnetName, isVnetRouteAllEnabled: isVnetRouteAllEnabled, vnetPrivatePortsCount: vnetPrivatePortsCount, cors: cors, push: push, apiDefinitionUri: apiDefinitionUri, apiManagementConfigId: apiManagementConfigId, autoSwapSlotName: autoSwapSlotName, isLocalMySqlEnabled: isLocalMySqlEnabled, managedServiceIdentityId: managedServiceIdentityId, xManagedServiceIdentityId: xManagedServiceIdentityId, keyVaultReferenceIdentity: keyVaultReferenceIdentity, ipSecurityRestrictions: ipSecurityRestrictions, ipSecurityRestrictionsDefaultAction: ipSecurityRestrictionsDefaultAction, scmIPSecurityRestrictions: scmIPSecurityRestrictions, scmIPSecurityRestrictionsDefaultAction: scmIPSecurityRestrictionsDefaultAction, allowIPSecurityRestrictionsForScmToUseMain: allowIPSecurityRestrictionsForScmToUseMain, isHttp20Enabled: isHttp20Enabled, http20ProxyFlag: default, minTlsVersion: minTlsVersion, minTlsCipherSuite: minTlsCipherSuite, scmMinTlsVersion: scmMinTlsVersion, ftpsState: ftpsState, preWarmedInstanceCount: preWarmedInstanceCount, functionAppScaleLimit: functionAppScaleLimit, elasticWebAppScaleLimit: elasticWebAppScaleLimit, healthCheckPath: healthCheckPath, isFunctionsRuntimeScaleMonitoringEnabled: isFunctionsRuntimeScaleMonitoringEnabled, websiteTimeZone: websiteTimeZone, minimumElasticInstanceCount: minimumElasticInstanceCount, azureStorageAccounts: azureStorageAccounts, publicNetworkAccess: publicNetworkAccess, kind: kind);
        }

        // This method is added to resolve api compatibility issue caused by rename url property for issue #56828
        /// <summary> Initializes a new instance of <see cref="Models.SiteConfigProperties"/>. </summary>
        /// <param name="numberOfWorkers"> Number of workers. </param>
        /// <param name="defaultDocuments"> Default documents. </param>
        /// <param name="netFrameworkVersion"> .NET Framework version. </param>
        /// <param name="phpVersion"> Version of PHP. </param>
        /// <param name="pythonVersion"> Version of Python. </param>
        /// <param name="nodeVersion"> Version of Node.js. </param>
        /// <param name="powerShellVersion"> Version of PowerShell. </param>
        /// <param name="linuxFxVersion"> Linux App Framework and version. </param>
        /// <param name="windowsFxVersion"> Xenon App Framework and version. </param>
        /// <param name="isRequestTracingEnabled"> &lt;code&gt;true&lt;/code&gt; if request tracing is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="requestTracingExpirationOn"> Request tracing expiration time. </param>
        /// <param name="isRemoteDebuggingEnabled"> &lt;code&gt;true&lt;/code&gt; if remote debugging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="remoteDebuggingVersion"> Remote debugging version. </param>
        /// <param name="isHttpLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if HTTP logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="useManagedIdentityCreds"> Flag to use Managed Identity Creds for ACR pull. </param>
        /// <param name="acrUserManagedIdentityId"> If using user managed identity, the user managed identity ClientId. </param>
        /// <param name="logsDirectorySizeLimit"> HTTP logs directory size limit. </param>
        /// <param name="isDetailedErrorLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if detailed error logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="publishingUsername"> Publishing user name. </param>
        /// <param name="appSettings"> Application settings. This property is not returned in response to normal create and read requests since it may contain sensitive information. </param>
        /// <param name="metadata"> Application metadata. This property cannot be retrieved, since it may contain secrets. </param>
        /// <param name="connectionStrings"> Connection strings. This property is not returned in response to normal create and read requests since it may contain sensitive information. </param>
        /// <param name="machineKey"> Site MachineKey. </param>
        /// <param name="handlerMappings"> Handler mappings. </param>
        /// <param name="documentRoot"> Document root. </param>
        /// <param name="scmType"> SCM type. </param>
        /// <param name="use32BitWorkerProcess"> &lt;code&gt;true&lt;/code&gt; to use 32-bit worker process; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isWebSocketsEnabled"> &lt;code&gt;true&lt;/code&gt; if WebSocket is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isAlwaysOn"> &lt;code&gt;true&lt;/code&gt; if Always On is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="javaVersion"> Java version. </param>
        /// <param name="javaContainer"> Java container. </param>
        /// <param name="javaContainerVersion"> Java container version. </param>
        /// <param name="appCommandLine"> App command line to launch. </param>
        /// <param name="managedPipelineMode"> Managed pipeline mode. </param>
        /// <param name="virtualApplications"> Virtual applications. </param>
        /// <param name="loadBalancing"> Site load balancing. </param>
        /// <param name="experimentsRampUpRules"> This is work around for polymorphic types. </param>
        /// <param name="limits"> Site limits. </param>
        /// <param name="isAutoHealEnabled"> &lt;code&gt;true&lt;/code&gt; if Auto Heal is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="autoHealRules"> Auto Heal rules. </param>
        /// <param name="tracingOptions"> Tracing options. </param>
        /// <param name="vnetName"> Virtual Network name. </param>
        /// <param name="isVnetRouteAllEnabled"> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </param>
        /// <param name="vnetPrivatePortsCount"> The number of private ports assigned to this app. These will be assigned dynamically on runtime. </param>
        /// <param name="cors"> Cross-Origin Resource Sharing (CORS) settings. </param>
        /// <param name="push"> Push endpoint settings. </param>
        /// <param name="apiDefinitionUri"> Information about the formal API definition for the app. </param>
        /// <param name="apiManagementConfigId"> Azure API management settings linked to the app. </param>
        /// <param name="autoSwapSlotName"> Auto-swap slot name. </param>
        /// <param name="isLocalMySqlEnabled"> &lt;code&gt;true&lt;/code&gt; to enable local MySQL; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="managedServiceIdentityId"> Managed Service Identity Id. </param>
        /// <param name="xManagedServiceIdentityId"> Explicit Managed Service Identity Id. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="ipSecurityRestrictions"> IP security restrictions for main. </param>
        /// <param name="ipSecurityRestrictionsDefaultAction"> Default action for main access restriction if no rules are matched. </param>
        /// <param name="scmIPSecurityRestrictions"> IP security restrictions for scm. </param>
        /// <param name="scmIPSecurityRestrictionsDefaultAction"> Default action for scm access restriction if no rules are matched. </param>
        /// <param name="allowIPSecurityRestrictionsForScmToUseMain"> IP security restrictions for scm to use main. </param>
        /// <param name="isHttp20Enabled"> Http20Enabled: configures a web site to allow clients to connect over http2.0. </param>
        /// <param name="http20ProxyFlag"> Http20ProxyFlag: Configures a website to allow http2.0 to pass be proxied all the way to the app. 0 = disabled, 1 = pass through all http2 traffic, 2 = pass through gRPC only. </param>
        /// <param name="minTlsVersion"> MinTlsVersion: configures the minimum version of TLS required for SSL requests. </param>
        /// <param name="minTlsCipherSuite"> The minimum strength TLS cipher suite allowed for an application. </param>
        /// <param name="scmMinTlsVersion"> ScmMinTlsVersion: configures the minimum version of TLS required for SSL requests for SCM site. </param>
        /// <param name="ftpsState"> State of FTP / FTPS service. </param>
        /// <param name="preWarmedInstanceCount">
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </param>
        /// <param name="functionAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to the Consumption and Elastic Premium Plans
        /// </param>
        /// <param name="elasticWebAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to apps in plans where ElasticScaleEnabled is &lt;code&gt;true&lt;/code&gt;
        /// </param>
        /// <param name="healthCheckPath"> Health check path. </param>
        /// <param name="isFunctionsRuntimeScaleMonitoringEnabled">
        /// Gets or sets a value indicating whether functions runtime scale monitoring is enabled. When enabled,
        /// the ScaleController will not monitor event sources directly, but will instead call to the
        /// runtime to get scale status.
        /// </param>
        /// <param name="websiteTimeZone"> Sets the time zone a site uses for generating timestamps. Compatible with Linux and Windows App Service. Setting the WEBSITE_TIME_ZONE app setting takes precedence over this config. For Linux, expects tz database values https://www.iana.org/time-zones (for a quick reference see https://en.wikipedia.org/wiki/List_of_tz_database_time_zones). For Windows, expects one of the time zones listed under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones. </param>
        /// <param name="minimumElasticInstanceCount">
        /// Number of minimum instance count for a site
        /// This setting only applies to the Elastic Plans
        /// </param>
        /// <param name="azureStorageAccounts"> List of Azure Storage Accounts. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. </param>
        /// <returns> A new <see cref="Models.SiteConfigProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteConfigProperties SiteConfigProperties(int? numberOfWorkers = null, IEnumerable<string> defaultDocuments = null, string netFrameworkVersion = null, string phpVersion = null, string pythonVersion = null, string nodeVersion = null, string powerShellVersion = null, string linuxFxVersion = null, string windowsFxVersion = null, bool? isRequestTracingEnabled = null, DateTimeOffset? requestTracingExpirationOn = null, bool? isRemoteDebuggingEnabled = null, string remoteDebuggingVersion = null, bool? isHttpLoggingEnabled = null, bool? useManagedIdentityCreds = null, string acrUserManagedIdentityId = null, int? logsDirectorySizeLimit = null, bool? isDetailedErrorLoggingEnabled = null, string publishingUsername = null, IEnumerable<AppServiceNameValuePair> appSettings = null, IEnumerable<AppServiceNameValuePair> metadata = null, IEnumerable<ConnStringInfo> connectionStrings = null, SiteMachineKey machineKey = null, IEnumerable<HttpRequestHandlerMapping> handlerMappings = null, string documentRoot = null, ScmType? scmType = null, bool? use32BitWorkerProcess = null, bool? isWebSocketsEnabled = null, bool? isAlwaysOn = null, string javaVersion = null, string javaContainer = null, string javaContainerVersion = null, string appCommandLine = null, ManagedPipelineMode? managedPipelineMode = null, IEnumerable<VirtualApplication> virtualApplications = null, SiteLoadBalancing? loadBalancing = null, IEnumerable<RampUpRule> experimentsRampUpRules = null, SiteLimits limits = null, bool? isAutoHealEnabled = null, AutoHealRules autoHealRules = null, string tracingOptions = null, string vnetName = null, bool? isVnetRouteAllEnabled = null, int? vnetPrivatePortsCount = null, AppServiceCorsSettings cors = null, WebAppPushSettings push = null, Uri apiDefinitionUri = null, string apiManagementConfigId = null, string autoSwapSlotName = null, bool? isLocalMySqlEnabled = null, int? managedServiceIdentityId = null, int? xManagedServiceIdentityId = null, string keyVaultReferenceIdentity = null, IEnumerable<AppServiceIPSecurityRestriction> ipSecurityRestrictions = null, SiteDefaultAction? ipSecurityRestrictionsDefaultAction = null, IEnumerable<AppServiceIPSecurityRestriction> scmIPSecurityRestrictions = null, SiteDefaultAction? scmIPSecurityRestrictionsDefaultAction = null, bool? allowIPSecurityRestrictionsForScmToUseMain = null, bool? isHttp20Enabled = null, int? http20ProxyFlag = null, AppServiceSupportedTlsVersion? minTlsVersion = null, AppServiceTlsCipherSuite? minTlsCipherSuite = null, AppServiceSupportedTlsVersion? scmMinTlsVersion = null, AppServiceFtpsState? ftpsState = null, int? preWarmedInstanceCount = null, int? functionAppScaleLimit = null, int? elasticWebAppScaleLimit = null, string healthCheckPath = null, bool? isFunctionsRuntimeScaleMonitoringEnabled = null, string websiteTimeZone = null, int? minimumElasticInstanceCount = null, IDictionary<string, AppServiceStorageAccessInfo> azureStorageAccounts = null, string publicNetworkAccess = null)
        {
            defaultDocuments ??= new List<string>();
            appSettings ??= new List<AppServiceNameValuePair>();
            metadata ??= new List<AppServiceNameValuePair>();
            connectionStrings ??= new List<ConnStringInfo>();
            handlerMappings ??= new List<HttpRequestHandlerMapping>();
            virtualApplications ??= new List<VirtualApplication>();
            experimentsRampUpRules ??= new List<RampUpRule>();
            ipSecurityRestrictions ??= new List<AppServiceIPSecurityRestriction>();
            scmIPSecurityRestrictions ??= new List<AppServiceIPSecurityRestriction>();
            azureStorageAccounts ??= new Dictionary<string, AppServiceStorageAccessInfo>();

            return new SiteConfigProperties(
                numberOfWorkers,
                defaultDocuments?.ToList(),
                netFrameworkVersion,
                phpVersion,
                pythonVersion,
                nodeVersion,
                powerShellVersion,
                linuxFxVersion,
                windowsFxVersion,
                isRequestTracingEnabled,
                requestTracingExpirationOn,
                isRemoteDebuggingEnabled,
                remoteDebuggingVersion,
                isHttpLoggingEnabled,
                useManagedIdentityCreds,
                acrUserManagedIdentityId,
                logsDirectorySizeLimit,
                isDetailedErrorLoggingEnabled,
                publishingUsername,
                appSettings?.ToList(),
                metadata?.ToList(),
                connectionStrings?.ToList(),
                machineKey,
                handlerMappings?.ToList(),
                documentRoot,
                scmType,
                use32BitWorkerProcess,
                isWebSocketsEnabled,
                isAlwaysOn,
                javaVersion,
                javaContainer,
                javaContainerVersion,
                appCommandLine,
                managedPipelineMode,
                virtualApplications?.ToList(),
                loadBalancing,
                experimentsRampUpRules != null ? new RoutingRuleExperiments(experimentsRampUpRules?.ToList(), serializedAdditionalRawData: null) : null,
                limits,
                isAutoHealEnabled,
                autoHealRules,
                tracingOptions,
                vnetName,
                isVnetRouteAllEnabled,
                vnetPrivatePortsCount,
                cors,
                push,
                apiDefinitionUri != null ? new AppServiceApiDefinitionInfo(apiDefinitionUri.AbsoluteUri, serializedAdditionalRawData: null) : null,
                apiManagementConfigId != null ? new ApiManagementConfig(apiManagementConfigId, serializedAdditionalRawData: null) : null,
                autoSwapSlotName,
                isLocalMySqlEnabled,
                managedServiceIdentityId,
                xManagedServiceIdentityId,
                keyVaultReferenceIdentity,
                ipSecurityRestrictions?.ToList(),
                ipSecurityRestrictionsDefaultAction,
                scmIPSecurityRestrictions?.ToList(),
                scmIPSecurityRestrictionsDefaultAction,
                allowIPSecurityRestrictionsForScmToUseMain,
                isHttp20Enabled,
                http20ProxyFlag,
                minTlsVersion,
                minTlsCipherSuite,
                scmMinTlsVersion,
                ftpsState,
                preWarmedInstanceCount,
                functionAppScaleLimit,
                elasticWebAppScaleLimit,
                healthCheckPath,
                isFunctionsRuntimeScaleMonitoringEnabled,
                websiteTimeZone,
                minimumElasticInstanceCount,
                azureStorageAccounts,
                publicNetworkAccess,
                serializedAdditionalRawData: null);
        }

        // This method is added to resolve api compatibility issue caused by rename url property for issue #56828
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.AppService.Models.SiteConfigProperties" />. </summary>
        /// <param name="numberOfWorkers"> Number of workers. </param>
        /// <param name="defaultDocuments"> Default documents. </param>
        /// <param name="netFrameworkVersion"> .NET Framework version. </param>
        /// <param name="phpVersion"> Version of PHP. </param>
        /// <param name="pythonVersion"> Version of Python. </param>
        /// <param name="nodeVersion"> Version of Node.js. </param>
        /// <param name="powerShellVersion"> Version of PowerShell. </param>
        /// <param name="linuxFxVersion"> Linux App Framework and version. </param>
        /// <param name="windowsFxVersion"> Xenon App Framework and version. </param>
        /// <param name="isRequestTracingEnabled"> &lt;code&gt;true&lt;/code&gt; if request tracing is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="requestTracingExpirationOn"> Request tracing expiration time. </param>
        /// <param name="isRemoteDebuggingEnabled"> &lt;code&gt;true&lt;/code&gt; if remote debugging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="remoteDebuggingVersion"> Remote debugging version. </param>
        /// <param name="isHttpLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if HTTP logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="useManagedIdentityCreds"> Flag to use Managed Identity Creds for ACR pull. </param>
        /// <param name="acrUserManagedIdentityId"> If using user managed identity, the user managed identity ClientId. </param>
        /// <param name="logsDirectorySizeLimit"> HTTP logs directory size limit. </param>
        /// <param name="isDetailedErrorLoggingEnabled"> &lt;code&gt;true&lt;/code&gt; if detailed error logging is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="publishingUsername"> Publishing user name. </param>
        /// <param name="appSettings"> Application settings. </param>
        /// <param name="metadata"> Application metadata. This property cannot be retrieved, since it may contain secrets. </param>
        /// <param name="connectionStrings"> Connection strings. </param>
        /// <param name="machineKey"> Site MachineKey. </param>
        /// <param name="handlerMappings"> Handler mappings. </param>
        /// <param name="documentRoot"> Document root. </param>
        /// <param name="scmType"> SCM type. </param>
        /// <param name="use32BitWorkerProcess"> &lt;code&gt;true&lt;/code&gt; to use 32-bit worker process; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isWebSocketsEnabled"> &lt;code&gt;true&lt;/code&gt; if WebSocket is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isAlwaysOn"> &lt;code&gt;true&lt;/code&gt; if Always On is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="javaVersion"> Java version. </param>
        /// <param name="javaContainer"> Java container. </param>
        /// <param name="javaContainerVersion"> Java container version. </param>
        /// <param name="appCommandLine"> App command line to launch. </param>
        /// <param name="managedPipelineMode"> Managed pipeline mode. </param>
        /// <param name="virtualApplications"> Virtual applications. </param>
        /// <param name="loadBalancing"> Site load balancing. </param>
        /// <param name="experimentsRampUpRules"> This is work around for polymorphic types. </param>
        /// <param name="limits"> Site limits. </param>
        /// <param name="isAutoHealEnabled"> &lt;code&gt;true&lt;/code&gt; if Auto Heal is enabled; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="autoHealRules"> Auto Heal rules. </param>
        /// <param name="tracingOptions"> Tracing options. </param>
        /// <param name="vnetName"> Virtual Network name. </param>
        /// <param name="isVnetRouteAllEnabled"> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </param>
        /// <param name="vnetPrivatePortsCount"> The number of private ports assigned to this app. These will be assigned dynamically on runtime. </param>
        /// <param name="cors"> Cross-Origin Resource Sharing (CORS) settings. </param>
        /// <param name="push"> Push endpoint settings. </param>
        /// <param name="apiDefinitionUri"> Information about the formal API definition for the app. </param>
        /// <param name="apiManagementConfigId"> Azure API management settings linked to the app. </param>
        /// <param name="autoSwapSlotName"> Auto-swap slot name. </param>
        /// <param name="isLocalMySqlEnabled"> &lt;code&gt;true&lt;/code&gt; to enable local MySQL; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="managedServiceIdentityId"> Managed Service Identity Id. </param>
        /// <param name="xManagedServiceIdentityId"> Explicit Managed Service Identity Id. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="ipSecurityRestrictions"> IP security restrictions for main. </param>
        /// <param name="ipSecurityRestrictionsDefaultAction"> Default action for main access restriction if no rules are matched. </param>
        /// <param name="scmIPSecurityRestrictions"> IP security restrictions for scm. </param>
        /// <param name="scmIPSecurityRestrictionsDefaultAction"> Default action for scm access restriction if no rules are matched. </param>
        /// <param name="allowIPSecurityRestrictionsForScmToUseMain"> IP security restrictions for scm to use main. </param>
        /// <param name="isHttp20Enabled"> Http20Enabled: configures a web site to allow clients to connect over http2.0. </param>
        /// <param name="minTlsVersion"> MinTlsVersion: configures the minimum version of TLS required for SSL requests. </param>
        /// <param name="minTlsCipherSuite"> The minimum strength TLS cipher suite allowed for an application. </param>
        /// <param name="scmMinTlsVersion"> ScmMinTlsVersion: configures the minimum version of TLS required for SSL requests for SCM site. </param>
        /// <param name="ftpsState"> State of FTP / FTPS service. </param>
        /// <param name="preWarmedInstanceCount">
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </param>
        /// <param name="functionAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to the Consumption and Elastic Premium Plans
        /// </param>
        /// <param name="elasticWebAppScaleLimit">
        /// Maximum number of workers that a site can scale out to.
        /// This setting only applies to apps in plans where ElasticScaleEnabled is &lt;code&gt;true&lt;/code&gt;
        /// </param>
        /// <param name="healthCheckPath"> Health check path. </param>
        /// <param name="isFunctionsRuntimeScaleMonitoringEnabled">
        /// Gets or sets a value indicating whether functions runtime scale monitoring is enabled. When enabled,
        /// the ScaleController will not monitor event sources directly, but will instead call to the
        /// runtime to get scale status.
        /// </param>
        /// <param name="websiteTimeZone"> Sets the time zone a site uses for generating timestamps. Compatible with Linux and Windows App Service. Setting the WEBSITE_TIME_ZONE app setting takes precedence over this config. For Linux, expects tz database values https://www.iana.org/time-zones (for a quick reference see https://en.wikipedia.org/wiki/List_of_tz_database_time_zones). For Windows, expects one of the time zones listed under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones. </param>
        /// <param name="minimumElasticInstanceCount">
        /// Number of minimum instance count for a site
        /// This setting only applies to the Elastic Plans
        /// </param>
        /// <param name="azureStorageAccounts"> List of Azure Storage Accounts. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.AppService.Models.SiteConfigProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteConfigProperties SiteConfigProperties(int? numberOfWorkers, IEnumerable<string> defaultDocuments, string netFrameworkVersion, string phpVersion, string pythonVersion, string nodeVersion, string powerShellVersion, string linuxFxVersion, string windowsFxVersion, bool? isRequestTracingEnabled, DateTimeOffset? requestTracingExpirationOn, bool? isRemoteDebuggingEnabled, string remoteDebuggingVersion, bool? isHttpLoggingEnabled, bool? useManagedIdentityCreds, string acrUserManagedIdentityId, int? logsDirectorySizeLimit, bool? isDetailedErrorLoggingEnabled, string publishingUsername, IEnumerable<AppServiceNameValuePair> appSettings, IEnumerable<AppServiceNameValuePair> metadata, IEnumerable<ConnStringInfo> connectionStrings, SiteMachineKey machineKey, IEnumerable<HttpRequestHandlerMapping> handlerMappings, string documentRoot, ScmType? scmType, bool? use32BitWorkerProcess, bool? isWebSocketsEnabled, bool? isAlwaysOn, string javaVersion, string javaContainer, string javaContainerVersion, string appCommandLine, ManagedPipelineMode? managedPipelineMode, IEnumerable<VirtualApplication> virtualApplications, SiteLoadBalancing? loadBalancing, IEnumerable<RampUpRule> experimentsRampUpRules, SiteLimits limits, bool? isAutoHealEnabled, AutoHealRules autoHealRules, string tracingOptions, string vnetName, bool? isVnetRouteAllEnabled, int? vnetPrivatePortsCount, AppServiceCorsSettings cors, WebAppPushSettings push, Uri apiDefinitionUri, string apiManagementConfigId, string autoSwapSlotName, bool? isLocalMySqlEnabled, int? managedServiceIdentityId, int? xManagedServiceIdentityId, string keyVaultReferenceIdentity, IEnumerable<AppServiceIPSecurityRestriction> ipSecurityRestrictions, SiteDefaultAction? ipSecurityRestrictionsDefaultAction, IEnumerable<AppServiceIPSecurityRestriction> scmIPSecurityRestrictions, SiteDefaultAction? scmIPSecurityRestrictionsDefaultAction, bool? allowIPSecurityRestrictionsForScmToUseMain, bool? isHttp20Enabled, AppServiceSupportedTlsVersion? minTlsVersion, AppServiceTlsCipherSuite? minTlsCipherSuite, AppServiceSupportedTlsVersion? scmMinTlsVersion, AppServiceFtpsState? ftpsState, int? preWarmedInstanceCount, int? functionAppScaleLimit, int? elasticWebAppScaleLimit, string healthCheckPath, bool? isFunctionsRuntimeScaleMonitoringEnabled, string websiteTimeZone, int? minimumElasticInstanceCount, IDictionary<string, AppServiceStorageAccessInfo> azureStorageAccounts, string publicNetworkAccess)
        {
            return SiteConfigProperties(numberOfWorkers: numberOfWorkers, defaultDocuments: defaultDocuments, netFrameworkVersion: netFrameworkVersion, phpVersion: phpVersion, pythonVersion: pythonVersion, nodeVersion: nodeVersion, powerShellVersion: powerShellVersion, linuxFxVersion: linuxFxVersion, windowsFxVersion: windowsFxVersion, isRequestTracingEnabled: isRequestTracingEnabled, requestTracingExpirationOn: requestTracingExpirationOn, isRemoteDebuggingEnabled: isRemoteDebuggingEnabled, remoteDebuggingVersion: remoteDebuggingVersion, isHttpLoggingEnabled: isHttpLoggingEnabled, useManagedIdentityCreds: useManagedIdentityCreds, acrUserManagedIdentityId: acrUserManagedIdentityId, logsDirectorySizeLimit: logsDirectorySizeLimit, isDetailedErrorLoggingEnabled: isDetailedErrorLoggingEnabled, publishingUsername: publishingUsername, appSettings: appSettings, metadata: metadata, connectionStrings: connectionStrings, machineKey: machineKey, handlerMappings: handlerMappings, documentRoot: documentRoot, scmType: scmType, use32BitWorkerProcess: use32BitWorkerProcess, isWebSocketsEnabled: isWebSocketsEnabled, isAlwaysOn: isAlwaysOn, javaVersion: javaVersion, javaContainer: javaContainer, javaContainerVersion: javaContainerVersion, appCommandLine: appCommandLine, managedPipelineMode: managedPipelineMode, virtualApplications: virtualApplications, loadBalancing: loadBalancing, experimentsRampUpRules: experimentsRampUpRules, limits: limits, isAutoHealEnabled: isAutoHealEnabled, autoHealRules: autoHealRules, tracingOptions: tracingOptions, vnetName: vnetName, isVnetRouteAllEnabled: isVnetRouteAllEnabled, vnetPrivatePortsCount: vnetPrivatePortsCount, cors: cors, push: push, apiDefinitionUri: apiDefinitionUri, apiManagementConfigId: apiManagementConfigId, autoSwapSlotName: autoSwapSlotName, isLocalMySqlEnabled: isLocalMySqlEnabled, managedServiceIdentityId: managedServiceIdentityId, xManagedServiceIdentityId: xManagedServiceIdentityId, keyVaultReferenceIdentity: keyVaultReferenceIdentity, ipSecurityRestrictions: ipSecurityRestrictions, ipSecurityRestrictionsDefaultAction: ipSecurityRestrictionsDefaultAction, scmIPSecurityRestrictions: scmIPSecurityRestrictions, scmIPSecurityRestrictionsDefaultAction: scmIPSecurityRestrictionsDefaultAction, allowIPSecurityRestrictionsForScmToUseMain: allowIPSecurityRestrictionsForScmToUseMain, isHttp20Enabled: isHttp20Enabled, http20ProxyFlag: default, minTlsVersion: minTlsVersion, minTlsCipherSuite: minTlsCipherSuite, scmMinTlsVersion: scmMinTlsVersion, ftpsState: ftpsState, preWarmedInstanceCount: preWarmedInstanceCount, functionAppScaleLimit: functionAppScaleLimit, elasticWebAppScaleLimit: elasticWebAppScaleLimit, healthCheckPath: healthCheckPath, isFunctionsRuntimeScaleMonitoringEnabled: isFunctionsRuntimeScaleMonitoringEnabled, websiteTimeZone: websiteTimeZone, minimumElasticInstanceCount: minimumElasticInstanceCount, azureStorageAccounts: azureStorageAccounts, publicNetworkAccess: publicNetworkAccess);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.AppService.SiteContainerData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="image"> Image Name. </param>
        /// <param name="targetPort"> Target Port. </param>
        /// <param name="isMain"> &lt;code&gt;true&lt;/code&gt; if the container is the main site container; &lt;code&gt;false&lt;/code&gt; otherwise. </param>
        /// <param name="startUpCommand"> StartUp Command. </param>
        /// <param name="authType"> Auth Type. </param>
        /// <param name="userName"> User Name. </param>
        /// <param name="passwordSecret"> Password Secret. </param>
        /// <param name="userManagedIdentityClientId"> UserManagedIdentity ClientId. </param>
        /// <param name="createdOn"> Created Time. </param>
        /// <param name="lastModifiedOn"> Last Modified Time. </param>
        /// <param name="volumeMounts"> List of volume mounts. </param>
        /// <param name="environmentVariables"> List of environment variables. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.AppService.SiteContainerData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteContainerData SiteContainerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string image, string targetPort, bool? isMain, string startUpCommand, SiteContainerAuthType? authType, string userName, string passwordSecret, string userManagedIdentityClientId, DateTimeOffset? createdOn, DateTimeOffset? lastModifiedOn, IEnumerable<SiteContainerVolumeMount> volumeMounts, IEnumerable<WebAppEnvironmentVariable> environmentVariables, string kind)
        {
            volumeMounts ??= new List<SiteContainerVolumeMount>();
            environmentVariables ??= new List<WebAppEnvironmentVariable>();

            return new SiteContainerData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                image,
                targetPort,
                isMain,
                startUpCommand,
                authType,
                userName,
                passwordSecret,
                userManagedIdentityClientId,
                createdOn,
                lastModifiedOn,
                volumeMounts?.ToList(),
                null,
                environmentVariables?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.AppService.WebSiteInstanceStatusData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="state"></param>
        /// <param name="statusUri"> Link to the GetStatusApi in Kudu. </param>
        /// <param name="detectorUri"> Link to the Diagnose and Solve Portal. </param>
        /// <param name="consoleUri"> Link to the console to web app instance. </param>
        /// <param name="healthCheckUrlString"> Link to the console to web app instance. </param>
        /// <param name="containers"> Dictionary of &lt;ContainerInfo&gt;. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.AppService.WebSiteInstanceStatusData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebSiteInstanceStatusData WebSiteInstanceStatusData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, SiteRuntimeState? state, Uri statusUri, Uri detectorUri, Uri consoleUri, string healthCheckUrlString, IDictionary<string, ContainerInfo> containers, string kind)
        {
            containers ??= new Dictionary<string, ContainerInfo>();

            return new WebSiteInstanceStatusData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                state,
                statusUri,
                detectorUri,
                consoleUri,
                healthCheckUrlString,
                containers,
                null,
                serializedAdditionalRawData: null);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // TODO: Below are factory methods created for kind property order change in TypeSpec, might be fixed in new MPG, remove them once verified the issue is fixed in MPG and TypeSpec. //
        // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary> Initializes a new instance of <see cref="AppService.AppCertificateData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="password"> Certificate password. </param>
        /// <param name="friendlyName"> Friendly name of the certificate. </param>
        /// <param name="subjectName"> Subject name of the certificate. </param>
        /// <param name="hostNames"> Host names the certificate applies to. </param>
        /// <param name="pfxBlob"> Pfx blob. </param>
        /// <param name="siteName"> App name. </param>
        /// <param name="selfLink"> Self link. </param>
        /// <param name="issuer"> Certificate issuer. </param>
        /// <param name="issueOn"> Certificate issue Date. </param>
        /// <param name="expireOn"> Certificate expiration date. </param>
        /// <param name="thumbprintString"> Certificate thumbprint. </param>
        /// <param name="isValid"> Is the certificate valid?. </param>
        /// <param name="cerBlob"> Raw bytes of .cer file. </param>
        /// <param name="publicKeyHash"> Public key hash. </param>
        /// <param name="hostingEnvironmentProfile"> Specification for the App Service Environment to use for the certificate. </param>
        /// <param name="keyVaultId"> Azure Key Vault Csm resource Id. </param>
        /// <param name="keyVaultSecretName"> Azure Key Vault secret name. </param>
        /// <param name="keyVaultSecretStatus"> Status of the Key Vault secret. </param>
        /// <param name="serverFarmId"> Resource ID of the associated App Service plan. </param>
        /// <param name="canonicalName"> CNAME of the certificate to be issued via free certificate. </param>
        /// <param name="domainValidationMethod"> Method of domain validation for free cert. </param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.AppCertificateData"/> instance for mocking. </returns>
        public static AppCertificateData AppCertificateData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string password, string friendlyName, string subjectName, IEnumerable<string> hostNames = null, byte[] pfxBlob = null, string siteName = null, string selfLink = null, string issuer = null, DateTimeOffset? issueOn = null, DateTimeOffset? expireOn = null, string thumbprintString = null, bool? isValid = null, byte[] cerBlob = null, string publicKeyHash = null, HostingEnvironmentProfile hostingEnvironmentProfile = null, ResourceIdentifier keyVaultId = null, string keyVaultSecretName = null, KeyVaultSecretStatus? keyVaultSecretStatus = null, ResourceIdentifier serverFarmId = null, string canonicalName = null, string domainValidationMethod = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();
            hostNames ??= new List<string>();

            return new AppCertificateData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                kind,
                password,
                friendlyName,
                subjectName,
                hostNames?.ToList(),
                pfxBlob,
                siteName,
                selfLink,
                issuer,
                issueOn,
                expireOn,
                thumbprintString,
                isValid,
                cerBlob,
                publicKeyHash,
                hostingEnvironmentProfile,
                keyVaultId,
                keyVaultSecretName,
                keyVaultSecretStatus,
                serverFarmId,
                canonicalName,
                domainValidationMethod,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceDetectorData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="metadata"> metadata for the detector. </param>
        /// <param name="dataset"> Data Set. </param>
        /// <param name="status"> Indicates status of the most severe insight. </param>
        /// <param name="dataProvidersMetadata"> Additional configuration for different data providers to be used by the UI. </param>
        /// <param name="suggestedUtterances"> Suggested utterances where the detector can be applicable. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceDetectorData"/> instance for mocking. </returns>
        public static AppServiceDetectorData AppServiceDetectorData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, DetectorInfo metadata, IEnumerable<DiagnosticDataset> dataset = null, AppServiceStatusInfo status = null, IEnumerable<DataProviderMetadata> dataProvidersMetadata = null, QueryUtterancesResults suggestedUtterances = null, string kind = null)
        {
            dataset ??= new List<DiagnosticDataset>();
            dataProvidersMetadata ??= new List<DataProviderMetadata>();

            return new AppServiceDetectorData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                metadata,
                dataset?.ToList(),
                status,
                dataProvidersMetadata?.ToList(),
                suggestedUtterances,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceEnvironmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="provisioningState"> Provisioning state of the App Service Environment. </param>
        /// <param name="status"> Current status of the App Service Environment. </param>
        /// <param name="virtualNetwork"> Description of the Virtual Network. </param>
        /// <param name="internalLoadBalancingMode"> Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment. </param>
        /// <param name="multiSize"> Front-end VM size, e.g. "Medium", "Large". </param>
        /// <param name="multiRoleCount"> Number of front-end instances. </param>
        /// <param name="ipSslAddressCount"> Number of IP SSL addresses reserved for the App Service Environment. </param>
        /// <param name="dnsSuffix"> DNS suffix of the App Service Environment. </param>
        /// <param name="maximumNumberOfMachines"> Maximum number of VMs in the App Service Environment. </param>
        /// <param name="frontEndScaleFactor"> Scale factor for front-ends. </param>
        /// <param name="isSuspended">
        /// &lt;code&gt;true&lt;/code&gt; if the App Service Environment is suspended; otherwise, &lt;code&gt;false&lt;/code&gt;. The environment can be suspended, e.g. when the management endpoint is no longer available
        ///  (most likely because NSG blocked the incoming traffic).
        /// </param>
        /// <param name="clusterSettings"> Custom settings for changing the behavior of the App Service Environment. </param>
        /// <param name="userWhitelistedIPRanges"> User added ip ranges to whitelist on ASE db. </param>
        /// <param name="hasLinuxWorkers"> Flag that displays whether an ASE has linux workers or not. </param>
        /// <param name="upgradePreference"> Upgrade Preference. </param>
        /// <param name="dedicatedHostCount"> Dedicated Host Count. </param>
        /// <param name="isZoneRedundant"> Whether or not this App Service Environment is zone-redundant. </param>
        /// <param name="customDnsSuffixConfiguration"> Full view of the custom domain suffix configuration for ASEv3. </param>
        /// <param name="networkingConfiguration"> Full view of networking configuration for an ASE. </param>
        /// <param name="upgradeAvailability"> Whether an upgrade is available for this App Service Environment. </param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.AppServiceEnvironmentData"/> instance for mocking. </returns>
        public static AppServiceEnvironmentData AppServiceEnvironmentData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ProvisioningState? provisioningState, HostingEnvironmentStatus? status = null, AppServiceVirtualNetworkProfile virtualNetwork = null, LoadBalancingMode? internalLoadBalancingMode = null, string multiSize = null, int? multiRoleCount = null, int? ipSslAddressCount = null, string dnsSuffix = null, int? maximumNumberOfMachines = null, int? frontEndScaleFactor = null, bool? isSuspended = null, IEnumerable<AppServiceNameValuePair> clusterSettings = null, IEnumerable<string> userWhitelistedIPRanges = null, bool? hasLinuxWorkers = null, AppServiceEnvironmentUpgradePreference? upgradePreference = null, int? dedicatedHostCount = null, bool? isZoneRedundant = null, CustomDnsSuffixConfigurationData customDnsSuffixConfiguration = null, AseV3NetworkingConfigurationData networkingConfiguration = null, AppServiceEnvironmentUpgradeAvailability? upgradeAvailability = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();
            clusterSettings ??= new List<AppServiceNameValuePair>();
            userWhitelistedIPRanges ??= new List<string>();

            return new AppServiceEnvironmentData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                kind,
                provisioningState,
                status,
                virtualNetwork,
                internalLoadBalancingMode,
                multiSize,
                multiRoleCount,
                ipSslAddressCount,
                dnsSuffix,
                maximumNumberOfMachines,
                frontEndScaleFactor,
                isSuspended,
                clusterSettings?.ToList(),
                userWhitelistedIPRanges?.ToList(),
                hasLinuxWorkers,
                upgradePreference,
                dedicatedHostCount,
                isZoneRedundant,
                customDnsSuffixConfiguration,
                networkingConfiguration,
                upgradeAvailability,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceSourceControlData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="token"> OAuth access token. </param>
        /// <param name="tokenSecret"> OAuth access token secret. </param>
        /// <param name="refreshToken"> OAuth refresh token. </param>
        /// <param name="expireOn"> OAuth token expiration. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceSourceControlData"/> instance for mocking. </returns>
        public static AppServiceSourceControlData AppServiceSourceControlData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string token, string tokenSecret, string refreshToken, DateTimeOffset? expireOn, string kind = null)
        {
            return new AppServiceSourceControlData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                token,
                tokenSecret,
                refreshToken,
                expireOn,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceVirtualNetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="vnetResourceId"> The Virtual Network's resource ID. </param>
        /// <param name="certThumbprintString"> The client certificate thumbprint. </param>
        /// <param name="certBlob">
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </param>
        /// <param name="routes"> The routes that this Virtual Network connection uses. </param>
        /// <param name="isResyncRequired"> &lt;code&gt;true&lt;/code&gt; if a resync is required; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="dnsServers"> DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses. </param>
        /// <param name="isSwift"> Flag that is used to denote if this is VNET injection. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceVirtualNetworkData"/> instance for mocking. </returns>
        public static AppServiceVirtualNetworkData AppServiceVirtualNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, ResourceIdentifier vnetResourceId, string certThumbprintString = null, string certBlob = null, IEnumerable<AppServiceVirtualNetworkRoute> routes = null, bool? isResyncRequired = null, string dnsServers = null, bool? isSwift = null, string kind = null)
        {
            routes ??= new List<AppServiceVirtualNetworkRoute>();

            return new AppServiceVirtualNetworkData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                vnetResourceId,
                certThumbprintString,
                certBlob,
                routes?.ToList(),
                isResyncRequired,
                dnsServers,
                isSwift,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceVirtualNetworkGatewayData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="vnetName"> The Virtual Network name. </param>
        /// <param name="vpnPackageUri"> The URI where the VPN package can be downloaded. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceVirtualNetworkGatewayData"/> instance for mocking. </returns>
        public static AppServiceVirtualNetworkGatewayData AppServiceVirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string vnetName, Uri vpnPackageUri, string kind = null)
        {
            return new AppServiceVirtualNetworkGatewayData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                vnetName,
                vpnPackageUri,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AppServiceWorkerPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> Description of a SKU for a scalable resource. </param>
        /// <param name="workerSizeId"> Worker size ID for referencing this worker pool. </param>
        /// <param name="computeMode"> Shared or dedicated app hosting. </param>
        /// <param name="workerSize"> VM size of the worker pool instances. </param>
        /// <param name="workerCount"> Number of instances in the worker pool. </param>
        /// <param name="instanceNames"> Names of all instances in the worker pool (read only). </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceWorkerPoolData"/> instance for mocking. </returns>
        public static AppServiceWorkerPoolData AppServiceWorkerPoolData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, AppServiceSkuDescription sku, int? workerSizeId, ComputeModeOption? computeMode, string workerSize = null, int? workerCount = null, IEnumerable<string> instanceNames = null, string kind = null)
        {
            instanceNames ??= new List<string>();

            return new AppServiceWorkerPoolData(
                id,
                name,
                resourceType,
                systemData,
                sku,
                kind,
                workerSizeId,
                computeMode,
                workerSize,
                workerCount,
                instanceNames?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.AseV3NetworkingConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="windowsOutboundIPAddresses"></param>
        /// <param name="linuxOutboundIPAddresses"></param>
        /// <param name="externalInboundIPAddresses"></param>
        /// <param name="internalInboundIPAddresses"></param>
        /// <param name="allowNewPrivateEndpointConnections"> Property to enable and disable new private endpoint connection creation on ASE. </param>
        /// <param name="isFtpEnabled"> Property to enable and disable FTP on ASEV3. </param>
        /// <param name="isRemoteDebugEnabled"> Property to enable and disable Remote Debug on ASEV3. </param>
        /// <param name="inboundIPAddressOverride"> Customer provided Inbound IP Address. Only able to be set on Ase create. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AseV3NetworkingConfigurationData"/> instance for mocking. </returns>
        public static AseV3NetworkingConfigurationData AseV3NetworkingConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IEnumerable<IPAddress> windowsOutboundIPAddresses, IEnumerable<IPAddress> linuxOutboundIPAddresses = null, IEnumerable<IPAddress> externalInboundIPAddresses = null, IEnumerable<IPAddress> internalInboundIPAddresses = null, bool? allowNewPrivateEndpointConnections = null, bool? isFtpEnabled = null, bool? isRemoteDebugEnabled = null, string inboundIPAddressOverride = null, string kind = null)
        {
            windowsOutboundIPAddresses ??= new List<IPAddress>();
            linuxOutboundIPAddresses ??= new List<IPAddress>();
            externalInboundIPAddresses ??= new List<IPAddress>();
            internalInboundIPAddresses ??= new List<IPAddress>();

            return new AseV3NetworkingConfigurationData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                windowsOutboundIPAddresses?.ToList(),
                linuxOutboundIPAddresses?.ToList(),
                externalInboundIPAddresses?.ToList(),
                internalInboundIPAddresses?.ToList(),
                allowNewPrivateEndpointConnections,
                isFtpEnabled,
                isRemoteDebugEnabled,
                inboundIPAddressOverride,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.ContinuousWebJobData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="status"> Job status. </param>
        /// <param name="detailedStatus"> Detailed status. </param>
        /// <param name="logUri"> Log URL. </param>
        /// <param name="runCommand"> Run command. </param>
        /// <param name="uri"> Job URL. </param>
        /// <param name="extraInfoUri"> Extra Info URL. </param>
        /// <param name="webJobType"> Job type. </param>
        /// <param name="error"> Error information. </param>
        /// <param name="isUsingSdk"> Using SDK?. </param>
        /// <param name="settings"> Job settings. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.ContinuousWebJobData"/> instance for mocking. </returns>
        public static ContinuousWebJobData ContinuousWebJobData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, ContinuousWebJobStatus? status, string detailedStatus = null, Uri logUri = null, string runCommand = null, Uri uri = null, Uri extraInfoUri = null, WebJobType? webJobType = null, string error = null, bool? isUsingSdk = null, IDictionary<string, BinaryData> settings = null, string kind = null)
        {
            settings ??= new Dictionary<string, BinaryData>();

            return new ContinuousWebJobData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                status,
                detailedStatus,
                logUri,
                runCommand,
                uri,
                extraInfoUri,
                webJobType,
                error,
                isUsingSdk,
                settings,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.CsmPublishingCredentialsPoliciesEntityData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="allow"> &lt;code&gt;true&lt;/code&gt; to allow access to a publishing method; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.CsmPublishingCredentialsPoliciesEntityData"/> instance for mocking. </returns>
        public static CsmPublishingCredentialsPoliciesEntityData CsmPublishingCredentialsPoliciesEntityData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, bool? allow, string kind)
        {
            return new CsmPublishingCredentialsPoliciesEntityData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                allow,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.CustomDnsSuffixConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"></param>
        /// <param name="provisioningDetails"></param>
        /// <param name="dnsSuffix"> The default custom domain suffix to use for all sites deployed on the ASE. </param>
        /// <param name="certificateUri"> The URL referencing the Azure Key Vault certificate secret that should be used as the default SSL/TLS certificate for sites with the custom domain suffix. </param>
        /// <param name="keyVaultReferenceIdentity"> The user-assigned identity to use for resolving the key vault certificate reference. If not specified, the system-assigned ASE identity will be used if available. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.CustomDnsSuffixConfigurationData"/> instance for mocking. </returns>
        public static CustomDnsSuffixConfigurationData CustomDnsSuffixConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, CustomDnsSuffixProvisioningState? provisioningState, string provisioningDetails = null, string dnsSuffix = null, Uri certificateUri = null, string keyVaultReferenceIdentity = null, string kind = null)
        {
            return new CustomDnsSuffixConfigurationData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                provisioningState,
                provisioningDetails,
                dnsSuffix,
                certificateUri,
                keyVaultReferenceIdentity,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceEnvironmentAddressResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="serviceIPAddress"> Main public virtual IP. </param>
        /// <param name="internalIPAddress"> Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode. </param>
        /// <param name="outboundIPAddresses"> IP addresses appearing on outbound connections. </param>
        /// <param name="virtualIPMappings"> Additional virtual IPs. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.AppServiceEnvironmentAddressResult"/> instance for mocking. </returns>
        public static AppServiceEnvironmentAddressResult AppServiceEnvironmentAddressResult(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IPAddress serviceIPAddress = null, IPAddress internalIPAddress = null, IEnumerable<IPAddress> outboundIPAddresses = null, IEnumerable<VirtualIPMapping> virtualIPMappings = null, string kind = null)
        {
            outboundIPAddresses ??= new List<IPAddress>();
            virtualIPMappings ??= new List<VirtualIPMapping>();

            return new AppServiceEnvironmentAddressResult(
                id,
                name,
                resourceType,
                systemData,
                kind,
                serviceIPAddress,
                internalIPAddress,
                outboundIPAddresses?.ToList(),
                virtualIPMappings?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AppServiceVirtualNetworkRoute"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="startAddress"> The starting address for this route. This may also include a CIDR notation, in which case the end address must not be specified. </param>
        /// <param name="endAddress"> The ending address for this route. If the start address is specified in CIDR notation, this must be omitted. </param>
        /// <param name="routeType">
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        ///
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.AppServiceVirtualNetworkRoute"/> instance for mocking. </returns>
        public static AppServiceVirtualNetworkRoute AppServiceVirtualNetworkRoute(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string startAddress = null, string endAddress = null, AppServiceVirtualNetworkRouteType? routeType = null, string kind = null)
        {
            return new AppServiceVirtualNetworkRoute(
                id,
                name,
                resourceType,
                systemData,
                kind,
                startAddress,
                endAddress,
                routeType,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CsmDeploymentStatus"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="deploymentId"> Deployment operation id. </param>
        /// <param name="status"> Deployment build status. </param>
        /// <param name="numberOfInstancesInProgress"> Number of site instances currently being provisioned. </param>
        /// <param name="numberOfInstancesSuccessful"> Number of site instances provisioned successfully. </param>
        /// <param name="numberOfInstancesFailed"> Number of site instances failed to provision. </param>
        /// <param name="failedInstancesLogs"> List of URLs pointing to logs for instances which failed to provision. </param>
        /// <param name="errors"> List of errors. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.CsmDeploymentStatus"/> instance for mocking. </returns>
        public static CsmDeploymentStatus CsmDeploymentStatus(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string deploymentId = null, DeploymentBuildStatus? status = null, int? numberOfInstancesInProgress = null, int? numberOfInstancesSuccessful = null, int? numberOfInstancesFailed = null, IEnumerable<string> failedInstancesLogs = null, IEnumerable<ResponseError> errors = null, string kind = null)
        {
            failedInstancesLogs ??= new List<string>();
            errors ??= new List<ResponseError>();

            return new CsmDeploymentStatus(
                id,
                name,
                resourceType,
                systemData,
                kind,
                deploymentId,
                status,
                numberOfInstancesInProgress,
                numberOfInstancesSuccessful,
                numberOfInstancesFailed,
                failedInstancesLogs?.ToList(),
                errors?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.DeletedSiteData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="deletedSiteId"> Numeric id for the deleted site. </param>
        /// <param name="deletedTimestamp"> Time in UTC when the app was deleted. </param>
        /// <param name="subscription"> Subscription containing the deleted site. </param>
        /// <param name="resourceGroup"> ResourceGroup that contained the deleted site. </param>
        /// <param name="deletedSiteName"> Name of the deleted site. </param>
        /// <param name="slot"> Slot of the deleted site. </param>
        /// <param name="kindPropertiesKind"> Kind of site that was deleted. </param>
        /// <param name="geoRegionName"> Geo Region of the deleted site. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.DeletedSiteData"/> instance for mocking. </returns>
        public static DeletedSiteData DeletedSiteData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? deletedSiteId = null, string deletedTimestamp = null, string subscription = null, string resourceGroup = null, string deletedSiteName = null, string slot = null, string kindPropertiesKind = null, string geoRegionName = null, string kind = null)
        {
            return new DeletedSiteData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                deletedSiteId,
                deletedTimestamp,
                subscription,
                resourceGroup,
                deletedSiteName,
                slot,
                kindPropertiesKind,
                geoRegionName,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.DetectorDefinitionResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> Display name of the detector. </param>
        /// <param name="description"> Description of the detector. </param>
        /// <param name="rank"> Detector Rank. </param>
        /// <param name="isEnabled"> Flag representing whether detector is enabled or not. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.DetectorDefinitionResourceData"/> instance for mocking. </returns>
        public static DetectorDefinitionResourceData DetectorDefinitionResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, double? rank = null, bool? isEnabled = null, string kind = null)
        {
            return new DetectorDefinitionResourceData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                displayName,
                description,
                rank,
                isEnabled,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.ApiKeyVaultReferenceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="reference"></param>
        /// <param name="status"></param>
        /// <param name="vaultName"></param>
        /// <param name="secretName"></param>
        /// <param name="secretVersion"></param>
        /// <param name="identity"> Managed service identity. </param>
        /// <param name="details"></param>
        /// <param name="source"></param>
        /// <param name="activeVersion"></param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.ApiKeyVaultReferenceData"/> instance for mocking. </returns>
        public static ApiKeyVaultReferenceData ApiKeyVaultReferenceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string reference = null, ResolveStatus? status = null, string vaultName = null, string secretName = null, string secretVersion = null, ManagedServiceIdentity identity = null, string details = null, ConfigReferenceSource? source = null, string activeVersion = null, string kind = null)
        {
            return new ApiKeyVaultReferenceData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                reference,
                status,
                vaultName,
                secretName,
                secretVersion,
                identity,
                details,
                source,
                activeVersion,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.FunctionEnvelopeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="functionAppId"> Function App ID. </param>
        /// <param name="scriptRootPathHref"> Script root path URI. </param>
        /// <param name="scriptHref"> Script URI. </param>
        /// <param name="configHref"> Config URI. </param>
        /// <param name="testDataHref"> Test data URI. </param>
        /// <param name="secretsFileHref"> Secrets file URI. </param>
        /// <param name="href"> Function URI. </param>
        /// <param name="config"> Config information. </param>
        /// <param name="files"> File list. </param>
        /// <param name="testData"> Test data used when testing via the Azure Portal. </param>
        /// <param name="invokeUrlTemplate"> The invocation URL. </param>
        /// <param name="language"> The function language. </param>
        /// <param name="isDisabled"> Gets or sets a value indicating whether the function is disabled. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.FunctionEnvelopeData"/> instance for mocking. </returns>
        public static FunctionEnvelopeData FunctionEnvelopeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string functionAppId = null, string scriptRootPathHref = null, string scriptHref = null, string configHref = null, string testDataHref = null, string secretsFileHref = null, string href = null, BinaryData config = null, IDictionary<string, string> files = null, string testData = null, string invokeUrlTemplate = null, string language = null, bool? isDisabled = null, string kind = null)
        {
            files ??= new Dictionary<string, string>();

            return new FunctionEnvelopeData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                functionAppId,
                scriptRootPathHref,
                scriptHref,
                configHref,
                testDataHref,
                secretsFileHref,
                href,
                config,
                files,
                testData,
                invokeUrlTemplate,
                language,
                isDisabled,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.HostNameBindingData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="siteName"> App Service app name. </param>
        /// <param name="domainId"> Fully qualified ARM domain resource URI. </param>
        /// <param name="azureResourceName"> Azure resource name. </param>
        /// <param name="azureResourceType"> Azure resource type. </param>
        /// <param name="customHostNameDnsRecordType"> Custom DNS record type. </param>
        /// <param name="hostNameType"> Hostname type. </param>
        /// <param name="sslState"> SSL type. </param>
        /// <param name="thumbprintString"> SSL certificate thumbprint. </param>
        /// <param name="virtualIP"> Virtual IP address assigned to the hostname if IP based SSL is enabled. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.HostNameBindingData"/> instance for mocking. </returns>
        public static HostNameBindingData HostNameBindingData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string siteName = null, string domainId = null, string azureResourceName = null, AppServiceResourceType? azureResourceType = null, CustomHostNameDnsRecordType? customHostNameDnsRecordType = null, AppServiceHostNameType? hostNameType = null, HostNameBindingSslState? sslState = null, string thumbprintString = null, string virtualIP = null, string kind = null)
        {
            return new HostNameBindingData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                siteName,
                domainId,
                azureResourceName,
                azureResourceType,
                customHostNameDnsRecordType,
                hostNameType,
                sslState,
                thumbprintString,
                virtualIP,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.HybridConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="serviceBusNamespace"> The name of the Service Bus namespace. </param>
        /// <param name="relayName"> The name of the Service Bus relay. </param>
        /// <param name="relayArmId"> The ARM URI to the Service Bus relay. </param>
        /// <param name="hostname"> The hostname of the endpoint. </param>
        /// <param name="port"> The port of the endpoint. </param>
        /// <param name="sendKeyName"> The name of the Service Bus key which has Send permissions. This is used to authenticate to Service Bus. </param>
        /// <param name="sendKeyValue">
        /// The value of the Service Bus key. This is used to authenticate to Service Bus. In ARM this key will not be returned
        /// normally, use the POST /listKeys API instead.
        /// </param>
        /// <param name="serviceBusSuffix"> The suffix for the service bus endpoint. By default this is .servicebus.windows.net. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.HybridConnectionData"/> instance for mocking. </returns>
        public static HybridConnectionData HybridConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string serviceBusNamespace = null, string relayName = null, ResourceIdentifier relayArmId = null, string hostname = null, int? port = null, string sendKeyName = null, string sendKeyValue = null, string serviceBusSuffix = null, string kind = null)
        {
            return new HybridConnectionData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                serviceBusNamespace,
                relayName,
                relayArmId,
                hostname,
                port,
                sendKeyName,
                sendKeyValue,
                serviceBusSuffix,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.HybridConnectionLimitData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="current"> The current number of Hybrid Connections. </param>
        /// <param name="maximum"> The maximum number of Hybrid Connections allowed. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.HybridConnectionLimitData"/> instance for mocking. </returns>
        public static HybridConnectionLimitData HybridConnectionLimitData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? current = null, int? maximum = null, string kind = null)
        {
            return new HybridConnectionLimitData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                current,
                maximum,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.KubeEnvironmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> Extended Location. </param>
        /// <param name="provisioningState"> Provisioning state of the Kubernetes Environment. </param>
        /// <param name="deploymentErrors"> Any errors that occurred during deployment or deployment validation. </param>
        /// <param name="isInternalLoadBalancerEnabled"> Only visible within Vnet/Subnet. </param>
        /// <param name="defaultDomain"> Default Domain Name for the cluster. </param>
        /// <param name="staticIP"> Static IP of the KubeEnvironment. </param>
        /// <param name="environmentType"> Type of Kubernetes Environment. Only supported for Container App Environments with value as Managed. </param>
        /// <param name="arcConfiguration">
        /// Cluster configuration which determines the ARC cluster
        /// components types. Eg: Choosing between BuildService kind,
        /// FrontEnd Service ArtifactsStorageType etc.
        /// </param>
        /// <param name="appLogsConfiguration">
        /// Cluster configuration which enables the log daemon to export
        /// app logs to a destination. Currently only "log-analytics" is
        /// supported
        /// </param>
        /// <param name="containerAppsConfiguration"> Cluster configuration for Container Apps Environments to configure Dapr Instrumentation Key and VNET Configuration. </param>
        /// <param name="aksResourceId"></param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.KubeEnvironmentData"/> instance for mocking. </returns>
        public static KubeEnvironmentData KubeEnvironmentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ExtendedLocation extendedLocation = null, KubeEnvironmentProvisioningState? provisioningState = null, string deploymentErrors = null, bool? isInternalLoadBalancerEnabled = null, string defaultDomain = null, string staticIP = null, string environmentType = null, ArcConfiguration arcConfiguration = null, AppLogsConfiguration appLogsConfiguration = null, ContainerAppsConfiguration containerAppsConfiguration = null, ResourceIdentifier aksResourceId = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();

            return new KubeEnvironmentData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                extendedLocation,
                kind,
                provisioningState,
                deploymentErrors,
                isInternalLoadBalancerEnabled,
                defaultDomain,
                staticIP,
                environmentType,
                arcConfiguration,
                appLogsConfiguration,
                containerAppsConfiguration,
                aksResourceId,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.MigrateMySqlStatusData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="migrationOperationStatus"> Status of the migration task. </param>
        /// <param name="operationId"> Operation ID for the migration task. </param>
        /// <param name="isLocalMySqlEnabled"> True if the web app has in app MySql enabled. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.MigrateMySqlStatusData"/> instance for mocking. </returns>
        public static MigrateMySqlStatusData MigrateMySqlStatusData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AppServiceOperationStatus? migrationOperationStatus = null, string operationId = null, bool? isLocalMySqlEnabled = null, string kind = null)
        {
            return new MigrateMySqlStatusData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                migrationOperationStatus,
                operationId,
                isLocalMySqlEnabled,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SiteAuthSettingsV2"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="platform"> The configuration settings of the platform of App Service Authentication/Authorization. </param>
        /// <param name="globalValidation"> The configuration settings that determines the validation flow of users using App Service Authentication/Authorization. </param>
        /// <param name="identityProviders"> The configuration settings of each of the identity providers used to configure App Service Authentication/Authorization. </param>
        /// <param name="login"> The configuration settings of the login flow of users using App Service Authentication/Authorization. </param>
        /// <param name="httpSettings"> The configuration settings of the HTTP requests for authentication and authorization requests made against App Service Authentication/Authorization. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="Models.SiteAuthSettingsV2"/> instance for mocking. </returns>
        public static SiteAuthSettingsV2 SiteAuthSettingsV2(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AuthPlatform platform = null, GlobalValidation globalValidation = null, AppServiceIdentityProviders identityProviders = null, WebAppLoginInfo login = null, AppServiceHttpSettings httpSettings = null, string kind = null)
        {
            return new SiteAuthSettingsV2(
                id,
                name,
                resourceType,
                systemData,
                kind,
                platform,
                globalValidation,
                identityProviders,
                login,
                httpSettings,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.WorkflowEnvelopeProperties"/>. </summary>
        /// <param name="files"> Gets or sets the files. </param>
        /// <param name="flowState"> Gets or sets the state of the workflow. </param>
        /// <param name="health"> Gets or sets workflow health. </param>
        /// <returns> A new <see cref="Models.WorkflowEnvelopeProperties"/> instance for mocking. </returns>
        public static WorkflowEnvelopeProperties WorkflowEnvelopeProperties(IReadOnlyDictionary<string, BinaryData> files = null, WorkflowState? flowState = null, WorkflowHealth health = null)
        {
            files ??= new Dictionary<string, BinaryData>();

            return new WorkflowEnvelopeProperties(files, flowState, health, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.WorkflowHealth"/>. </summary>
        /// <param name="state"> Gets or sets the workflow health state. </param>
        /// <param name="error"> Gets or sets the workflow error. </param>
        /// <returns> A new <see cref="Models.WorkflowHealth"/> instance for mocking. </returns>
        public static WorkflowHealth WorkflowHealth(WorkflowHealthState state = default, ResponseError error = null)
        {
            return new WorkflowHealth(state, error, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.MSDeployStatusData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="deployer"> Username of deployer. </param>
        /// <param name="provisioningState"> Provisioning state. </param>
        /// <param name="startOn"> Start time of deploy operation. </param>
        /// <param name="endOn"> End time of deploy operation. </param>
        /// <param name="isComplete"> Whether the deployment operation has completed. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.MSDeployStatusData"/> instance for mocking. </returns>
        public static MSDeployStatusData MSDeployStatusData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string deployer = null, MSDeployProvisioningState? provisioningState = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null, bool? isComplete = null, string kind = null)
        {
            return new MSDeployStatusData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                deployer,
                provisioningState,
                startOn,
                endOn,
                isComplete,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.NetworkFeatureData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="virtualNetworkName"> The Virtual Network name. </param>
        /// <param name="virtualNetworkConnection"> The Virtual Network summary view. </param>
        /// <param name="hybridConnections"> The Hybrid Connections summary view. </param>
        /// <param name="hybridConnectionsV2"> The Hybrid Connection V2 (Service Bus) view. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.NetworkFeatureData"/> instance for mocking. </returns>
        public static NetworkFeatureData NetworkFeatureData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string virtualNetworkName = null, AppServiceVirtualNetworkProperties virtualNetworkConnection = null, IEnumerable<RelayServiceConnectionEntityData> hybridConnections = null, IEnumerable<HybridConnectionData> hybridConnectionsV2 = null, string kind = null)
        {
            hybridConnections ??= new List<RelayServiceConnectionEntityData>();
            hybridConnectionsV2 ??= new List<HybridConnectionData>();

            return new NetworkFeatureData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                virtualNetworkName,
                virtualNetworkConnection,
                hybridConnections?.ToList(),
                hybridConnectionsV2?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.PrivateAccessData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isEnabled"> Whether private access is enabled or not. </param>
        /// <param name="virtualNetworks"> The Virtual Networks (and subnets) allowed to access the site privately. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.PrivateAccessData"/> instance for mocking. </returns>
        public static PrivateAccessData PrivateAccessData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, bool? isEnabled = null, IEnumerable<PrivateAccessVirtualNetwork> virtualNetworks = null, string kind = null)
        {
            virtualNetworks ??= new List<PrivateAccessVirtualNetwork>();

            return new PrivateAccessData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                isEnabled,
                virtualNetworks?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.ProcessInfoData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identifier"> ARM Identifier for deployment. </param>
        /// <param name="deploymentName"> Deployment name. </param>
        /// <param name="href"> HRef URI. </param>
        /// <param name="minidump"> Minidump URI. </param>
        /// <param name="isProfileRunning"> Is profile running?. </param>
        /// <param name="isIisProfileRunning"> Is the IIS Profile running?. </param>
        /// <param name="iisProfileTimeoutInSeconds"> IIS Profile timeout (seconds). </param>
        /// <param name="parent"> Parent process. </param>
        /// <param name="children"> Child process list. </param>
        /// <param name="processThreads"> Thread list. </param>
        /// <param name="openFileHandles"> List of open files. </param>
        /// <param name="modules"> List of modules. </param>
        /// <param name="fileName"> File name of this process. </param>
        /// <param name="commandLine"> Command line. </param>
        /// <param name="userName"> User name. </param>
        /// <param name="handleCount"> Handle count. </param>
        /// <param name="moduleCount"> Module count. </param>
        /// <param name="threadCount"> Thread count. </param>
        /// <param name="startOn"> Start time. </param>
        /// <param name="totalCpuTime"> Total CPU time. </param>
        /// <param name="userCpuTime"> User CPU time. </param>
        /// <param name="privilegedCpuTime"> Privileged CPU time. </param>
        /// <param name="workingSet"> Working set. </param>
        /// <param name="peakWorkingSet"> Peak working set. </param>
        /// <param name="privateMemory"> Private memory size. </param>
        /// <param name="virtualMemory"> Virtual memory size. </param>
        /// <param name="peakVirtualMemory"> Peak virtual memory usage. </param>
        /// <param name="pagedSystemMemory"> Paged system memory. </param>
        /// <param name="nonPagedSystemMemory"> Non-paged system memory. </param>
        /// <param name="pagedMemory"> Paged memory. </param>
        /// <param name="peakPagedMemory"> Peak paged memory. </param>
        /// <param name="timeStamp"> Time stamp. </param>
        /// <param name="environmentVariables"> List of environment variables. </param>
        /// <param name="isScmSite"> Is this the SCM site?. </param>
        /// <param name="isWebjob"> Is this a Web Job?. </param>
        /// <param name="description"> Description of process. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.ProcessInfoData"/> instance for mocking. </returns>
        public static ProcessInfoData ProcessInfoData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? identifier = null, string deploymentName = null, string href = null, string minidump = null, bool? isProfileRunning = null, bool? isIisProfileRunning = null, double? iisProfileTimeoutInSeconds = null, string parent = null, IEnumerable<string> children = null, IEnumerable<WebAppProcessThreadProperties> processThreads = null, IEnumerable<string> openFileHandles = null, IEnumerable<ProcessModuleInfoData> modules = null, string fileName = null, string commandLine = null, string userName = null, int? handleCount = null, int? moduleCount = null, int? threadCount = null, DateTimeOffset? startOn = null, string totalCpuTime = null, string userCpuTime = null, string privilegedCpuTime = null, long? workingSet = null, long? peakWorkingSet = null, long? privateMemory = null, long? virtualMemory = null, long? peakVirtualMemory = null, long? pagedSystemMemory = null, long? nonPagedSystemMemory = null, long? pagedMemory = null, long? peakPagedMemory = null, DateTimeOffset? timeStamp = null, IDictionary<string, string> environmentVariables = null, bool? isScmSite = null, bool? isWebjob = null, string description = null, string kind = null)
        {
            children ??= new List<string>();
            processThreads ??= new List<WebAppProcessThreadProperties>();
            openFileHandles ??= new List<string>();
            modules ??= new List<ProcessModuleInfoData>();
            environmentVariables ??= new Dictionary<string, string>();

            return new ProcessInfoData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                identifier,
                deploymentName,
                href,
                minidump,
                isProfileRunning,
                isIisProfileRunning,
                iisProfileTimeoutInSeconds,
                parent,
                children?.ToList(),
                processThreads?.ToList(),
                openFileHandles?.ToList(),
                modules?.ToList(),
                fileName,
                commandLine,
                userName,
                handleCount,
                moduleCount,
                threadCount,
                startOn,
                totalCpuTime,
                userCpuTime,
                privilegedCpuTime,
                workingSet,
                peakWorkingSet,
                privateMemory,
                virtualMemory,
                peakVirtualMemory,
                pagedSystemMemory,
                nonPagedSystemMemory,
                pagedMemory,
                peakPagedMemory,
                timeStamp,
                environmentVariables,
                isScmSite,
                isWebjob,
                description,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.ProcessModuleInfoData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="baseAddress"> Base address. Used as module identifier in ARM resource URI. </param>
        /// <param name="fileName"> File name. </param>
        /// <param name="href"> HRef URI. </param>
        /// <param name="filePath"> File path. </param>
        /// <param name="moduleMemorySize"> Module memory size. </param>
        /// <param name="fileVersion"> File version. </param>
        /// <param name="fileDescription"> File description. </param>
        /// <param name="product"> Product name. </param>
        /// <param name="productVersion"> Product version. </param>
        /// <param name="isDebug"> Is debug?. </param>
        /// <param name="language"> Module language (locale). </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.ProcessModuleInfoData"/> instance for mocking. </returns>
        public static ProcessModuleInfoData ProcessModuleInfoData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string baseAddress = null, string fileName = null, string href = null, string filePath = null, int? moduleMemorySize = null, string fileVersion = null, string fileDescription = null, string product = null, string productVersion = null, bool? isDebug = null, string language = null, string kind = null)
        {
            return new ProcessModuleInfoData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                baseAddress,
                fileName,
                href,
                filePath,
                moduleMemorySize,
                fileVersion,
                fileDescription,
                product,
                productVersion,
                isDebug,
                language,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.PublicCertificateData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="blob"> Public Certificate byte array. </param>
        /// <param name="publicCertificateLocation"> Public Certificate Location. </param>
        /// <param name="thumbprintString"> Certificate Thumbprint. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.PublicCertificateData"/> instance for mocking. </returns>
        public static PublicCertificateData PublicCertificateData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, byte[] blob = null, PublicCertificateLocation? publicCertificateLocation = null, string thumbprintString = null, string kind = null)
        {
            return new PublicCertificateData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                blob,
                publicCertificateLocation,
                thumbprintString,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.PublishingUserData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="publishingUserName"> Username used for publishing. </param>
        /// <param name="publishingPassword"> Password used for publishing. </param>
        /// <param name="publishingPasswordHash"> Password hash used for publishing. </param>
        /// <param name="publishingPasswordHashSalt"> Password hash salt used for publishing. </param>
        /// <param name="scmUri"> Url of SCM site. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.PublishingUserData"/> instance for mocking. </returns>
        public static PublishingUserData PublishingUserData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string publishingUserName = null, string publishingPassword = null, string publishingPasswordHash = null, string publishingPasswordHashSalt = null, Uri scmUri = null, string kind = null)
        {
            return new PublishingUserData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                publishingUserName,
                publishingPassword,
                publishingPasswordHash,
                publishingPasswordHashSalt,
                scmUri,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.RecommendationRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="recommendationName"> Unique name of the rule. </param>
        /// <param name="displayName"> UI friendly name of the rule. </param>
        /// <param name="message"> Localized name of the rule (Good for UI). </param>
        /// <param name="recommendationId">
        /// Recommendation ID of an associated recommendation object tied to the rule, if exists.
        /// If such an object doesn't exist, it is set to null.
        /// </param>
        /// <param name="description"> Localized detailed description of the rule. </param>
        /// <param name="actionName"> Name of action that is recommended by this rule in string. </param>
        /// <param name="level"> Level of impact indicating how critical this rule is. </param>
        /// <param name="channels"> List of available channels that this rule applies. </param>
        /// <param name="categoryTags"> The list of category tags that this recommendation rule belongs to. </param>
        /// <param name="isDynamic"> True if this is associated with a dynamically added rule. </param>
        /// <param name="extensionName"> Extension name of the portal if exists. Applicable to dynamic rule only. </param>
        /// <param name="bladeName"> Deep link to a blade on the portal. Applicable to dynamic rule only. </param>
        /// <param name="forwardLink"> Forward link to an external document associated with the rule. Applicable to dynamic rule only. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.RecommendationRuleData"/> instance for mocking. </returns>
        public static RecommendationRuleData RecommendationRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string recommendationName = null, string displayName = null, string message = null, Guid? recommendationId = null, string description = null, string actionName = null, NotificationLevel? level = null, RecommendationChannel? channels = null, IEnumerable<string> categoryTags = null, bool? isDynamic = null, string extensionName = null, string bladeName = null, string forwardLink = null, string kind = null)
        {
            categoryTags ??= new List<string>();

            return new RecommendationRuleData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                recommendationName,
                displayName,
                message,
                recommendationId,
                description,
                actionName,
                level,
                channels,
                categoryTags?.ToList(),
                isDynamic,
                extensionName,
                bladeName,
                forwardLink,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.RelayServiceConnectionEntityData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="entityName"></param>
        /// <param name="entityConnectionString"></param>
        /// <param name="resourceConnectionString"></param>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="biztalkUri"></param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.RelayServiceConnectionEntityData"/> instance for mocking. </returns>
        public static RelayServiceConnectionEntityData RelayServiceConnectionEntityData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string entityName = null, string entityConnectionString = null, string resourceConnectionString = null, string hostname = null, int? port = null, Uri biztalkUri = null, string kind = null)
        {
            return new RelayServiceConnectionEntityData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                entityName,
                entityConnectionString,
                resourceConnectionString,
                hostname,
                port,
                biztalkUri,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.RemotePrivateEndpointConnectionARMResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"></param>
        /// <param name="privateEndpointId"> PrivateEndpoint of a remote private endpoint connection. </param>
        /// <param name="privateLinkServiceConnectionState"> The state of a private link connection. </param>
        /// <param name="ipAddresses"> Private IPAddresses mapped to the remote private endpoint. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.RemotePrivateEndpointConnectionARMResourceData"/> instance for mocking. </returns>
        public static RemotePrivateEndpointConnectionARMResourceData RemotePrivateEndpointConnectionARMResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, ResourceIdentifier privateEndpointId = null, PrivateLinkConnectionState privateLinkServiceConnectionState = null, IEnumerable<IPAddress> ipAddresses = null, string kind = null)
        {
            ipAddresses ??= new List<IPAddress>();

            return new RemotePrivateEndpointConnectionARMResourceData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                provisioningState,
                privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null,
                privateLinkServiceConnectionState,
                ipAddresses?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.ResourceHealthMetadataData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="category"> The category that the resource matches in the RHC Policy File. </param>
        /// <param name="isSignalAvailable"> Is there a health signal for the resource. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.ResourceHealthMetadataData"/> instance for mocking. </returns>
        public static ResourceHealthMetadataData ResourceHealthMetadataData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string category = null, bool? isSignalAvailable = null, string kind = null)
        {
            return new ResourceHealthMetadataData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                category,
                isSignalAvailable,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.SiteContainerData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="image"> Image Name. </param>
        /// <param name="targetPort"> Target Port. </param>
        /// <param name="isMain"> &lt;code&gt;true&lt;/code&gt; if the container is the main site container; &lt;code&gt;false&lt;/code&gt; otherwise. </param>
        /// <param name="startUpCommand"> StartUp Command. </param>
        /// <param name="authType"> Auth Type. </param>
        /// <param name="userName"> User Name. </param>
        /// <param name="passwordSecret"> Password Secret. </param>
        /// <param name="userManagedIdentityClientId"> UserManagedIdentity ClientId. </param>
        /// <param name="createdOn"> Created Time. </param>
        /// <param name="lastModifiedOn"> Last Modified Time. </param>
        /// <param name="volumeMounts"> List of volume mounts. </param>
        /// <param name="inheritAppSettingsAndConnectionStrings"> &lt;code&gt;true&lt;/code&gt; if all AppSettings and ConnectionStrings have to be passed to the container as environment variables; &lt;code&gt;false&lt;/code&gt; otherwise. </param>
        /// <param name="environmentVariables"> List of environment variables. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SiteContainerData"/> instance for mocking. </returns>
        public static SiteContainerData SiteContainerData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string image, string targetPort, bool? isMain, string startUpCommand = null, SiteContainerAuthType? authType = null, string userName = null, string passwordSecret = null, string userManagedIdentityClientId = null, DateTimeOffset? createdOn = null, DateTimeOffset? lastModifiedOn = null, IEnumerable<SiteContainerVolumeMount> volumeMounts = null, bool? inheritAppSettingsAndConnectionStrings = null, IEnumerable<WebAppEnvironmentVariable> environmentVariables = null, string kind = null)
        {
            volumeMounts ??= new List<SiteContainerVolumeMount>();
            environmentVariables ??= new List<WebAppEnvironmentVariable>();

            return new SiteContainerData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                image,
                targetPort,
                isMain,
                startUpCommand,
                authType,
                userName,
                passwordSecret,
                userManagedIdentityClientId,
                createdOn,
                lastModifiedOn,
                volumeMounts?.ToList(),
                inheritAppSettingsAndConnectionStrings,
                environmentVariables?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.SiteExtensionInfoData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="extensionId"> Site extension ID. </param>
        /// <param name="title"></param>
        /// <param name="extensionType"> Site extension type. </param>
        /// <param name="summary"> Summary description. </param>
        /// <param name="description"> Detailed description. </param>
        /// <param name="version"> Version information. </param>
        /// <param name="extensionUri"> Extension URL. </param>
        /// <param name="projectUri"> Project URL. </param>
        /// <param name="iconUri"> Icon URL. </param>
        /// <param name="licenseUri"> License URL. </param>
        /// <param name="feedUri"> Feed URL. </param>
        /// <param name="authors"> List of authors. </param>
        /// <param name="installerCommandLineParams"> Installer command line parameters. </param>
        /// <param name="publishedOn"> Published timestamp. </param>
        /// <param name="downloadCount"> Count of downloads. </param>
        /// <param name="localIsLatestVersion"> &lt;code&gt;true&lt;/code&gt; if the local version is the latest version; &lt;code&gt;false&lt;/code&gt; otherwise. </param>
        /// <param name="localPath"> Local path. </param>
        /// <param name="installedOn"> Installed timestamp. </param>
        /// <param name="provisioningState"> Provisioning state. </param>
        /// <param name="comment"> Site Extension comment. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SiteExtensionInfoData"/> instance for mocking. </returns>
        public static SiteExtensionInfoData SiteExtensionInfoData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string extensionId = null, string title = null, SiteExtensionType? extensionType = null, string summary = null, string description = null, string version = null, Uri extensionUri = null, Uri projectUri = null, Uri iconUri = null, Uri licenseUri = null, Uri feedUri = null, IEnumerable<string> authors = null, string installerCommandLineParams = null, DateTimeOffset? publishedOn = null, int? downloadCount = null, bool? localIsLatestVersion = null, string localPath = null, DateTimeOffset? installedOn = null, string provisioningState = null, string comment = null, string kind = null)
        {
            authors ??= new List<string>();

            return new SiteExtensionInfoData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                extensionId,
                title,
                extensionType,
                summary,
                description,
                version,
                extensionUri,
                projectUri,
                iconUri,
                licenseUri,
                feedUri,
                authors?.ToList(),
                installerCommandLineParams,
                publishedOn,
                downloadCount,
                localIsLatestVersion,
                localPath,
                installedOn,
                provisioningState,
                comment,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.SiteLogsConfigData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="applicationLogs"> Application logs configuration. </param>
        /// <param name="httpLogs"> HTTP logs configuration. </param>
        /// <param name="isFailedRequestsTracingEnabled"> Failed requests tracing configuration. </param>
        /// <param name="isDetailedErrorMessagesEnabled"> Detailed error messages configuration. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SiteLogsConfigData"/> instance for mocking. </returns>
        public static SiteLogsConfigData SiteLogsConfigData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ApplicationLogsConfig applicationLogs = null, AppServiceHttpLogsConfig httpLogs = null, bool? isFailedRequestsTracingEnabled = null, bool? isDetailedErrorMessagesEnabled = null, string kind = null)
        {
            return new SiteLogsConfigData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                applicationLogs,
                httpLogs,
                isFailedRequestsTracingEnabled != null ? new WebAppEnabledConfig(isFailedRequestsTracingEnabled, serializedAdditionalRawData: null) : null,
                isDetailedErrorMessagesEnabled != null ? new WebAppEnabledConfig(isDetailedErrorMessagesEnabled, serializedAdditionalRawData: null) : null,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.SiteSourceControlData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="repoUri"> Repository or source control URL. </param>
        /// <param name="branch"> Name of branch to use for deployment. </param>
        /// <param name="isManualIntegration"> &lt;code&gt;true&lt;/code&gt; to limit to manual integration; &lt;code&gt;false&lt;/code&gt; to enable continuous integration (which configures webhooks into online repos like GitHub). </param>
        /// <param name="isGitHubAction"> &lt;code&gt;true&lt;/code&gt; if this is deployed via GitHub action. </param>
        /// <param name="isDeploymentRollbackEnabled"> &lt;code&gt;true&lt;/code&gt; to enable deployment rollback; otherwise, &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isMercurial"> &lt;code&gt;true&lt;/code&gt; for a Mercurial repository; &lt;code&gt;false&lt;/code&gt; for a Git repository. </param>
        /// <param name="gitHubActionConfiguration"> If GitHub Action is selected, than the associated configuration. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SiteSourceControlData"/> instance for mocking. </returns>
        public static SiteSourceControlData SiteSourceControlData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, Uri repoUri = null, string branch = null, bool? isManualIntegration = null, bool? isGitHubAction = null, bool? isDeploymentRollbackEnabled = null, bool? isMercurial = null, GitHubActionConfiguration gitHubActionConfiguration = null, string kind = null)
        {
            return new SiteSourceControlData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                repoUri,
                branch,
                isManualIntegration,
                isGitHubAction,
                isDeploymentRollbackEnabled,
                isMercurial,
                gitHubActionConfiguration,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.SlotConfigNamesResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="connectionStringNames"> List of connection string names. </param>
        /// <param name="appSettingNames"> List of application settings names. </param>
        /// <param name="azureStorageConfigNames"> List of external Azure storage account identifiers. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SlotConfigNamesResourceData"/> instance for mocking. </returns>
        public static SlotConfigNamesResourceData SlotConfigNamesResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IEnumerable<string> connectionStringNames = null, IEnumerable<string> appSettingNames = null, IEnumerable<string> azureStorageConfigNames = null, string kind = null)
        {
            connectionStringNames ??= new List<string>();
            appSettingNames ??= new List<string>();
            azureStorageConfigNames ??= new List<string>();

            return new SlotConfigNamesResourceData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                connectionStringNames?.ToList(),
                appSettingNames?.ToList(),
                azureStorageConfigNames?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteBasicAuthPropertyData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="password"> The password for basic auth. </param>
        /// <param name="secretUri"> Url to the secret in Key Vault. </param>
        /// <param name="applicableEnvironmentsMode"> State indicating if basic auth is enabled and for what environments it is active. </param>
        /// <param name="environments"> The list of enabled environments for Basic Auth if ApplicableEnvironmentsMode is set to SpecifiedEnvironments. </param>
        /// <param name="secretState"> State indicating if basic auth has a secret and what type it is. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.StaticSiteBasicAuthPropertyData"/> instance for mocking. </returns>
        public static StaticSiteBasicAuthPropertyData StaticSiteBasicAuthPropertyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string password = null, Uri secretUri = null, string applicableEnvironmentsMode = null, IEnumerable<string> environments = null, string secretState = null, string kind = null)
        {
            environments ??= new List<string>();

            return new StaticSiteBasicAuthPropertyData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                password,
                secretUri,
                applicableEnvironmentsMode,
                environments?.ToList(),
                secretState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteBuildData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="buildId"> An identifier for the static site build. </param>
        /// <param name="sourceBranch"> The source branch. </param>
        /// <param name="pullRequestTitle"> The title of a pull request that a static site build is related to. </param>
        /// <param name="hostname"> The hostname for a static site build. </param>
        /// <param name="createdOn"> When this build was created. </param>
        /// <param name="lastUpdatedOn"> When this build was updated. </param>
        /// <param name="status"> The status of the static site build. </param>
        /// <param name="userProvidedFunctionApps"> User provided function apps registered with the static site build. </param>
        /// <param name="linkedBackends"> Backends linked to the static side build. </param>
        /// <param name="databaseConnections"> Database connections for the static site build. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.StaticSiteBuildData"/> instance for mocking. </returns>
        public static StaticSiteBuildData StaticSiteBuildData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string buildId = null, string sourceBranch = null, string pullRequestTitle = null, string hostname = null, DateTimeOffset? createdOn = null, DateTimeOffset? lastUpdatedOn = null, StaticSiteBuildStatus? status = null, IEnumerable<StaticSiteUserProvidedFunctionAppData> userProvidedFunctionApps = null, IEnumerable<StaticSiteLinkedBackendInfo> linkedBackends = null, IEnumerable<StaticSiteDatabaseConnectionOverview> databaseConnections = null, string kind = null)
        {
            userProvidedFunctionApps ??= new List<StaticSiteUserProvidedFunctionAppData>();
            linkedBackends ??= new List<StaticSiteLinkedBackendInfo>();
            databaseConnections ??= new List<StaticSiteDatabaseConnectionOverview>();

            return new StaticSiteBuildData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                buildId,
                sourceBranch,
                pullRequestTitle,
                hostname,
                createdOn,
                lastUpdatedOn,
                status,
                userProvidedFunctionApps?.ToList(),
                linkedBackends?.ToList(),
                databaseConnections?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteCustomDomainOverviewData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="domainName"> The domain name for the static site custom domain. </param>
        /// <param name="createdOn"> The date and time on which the custom domain was created for the static site. </param>
        /// <param name="status"> The status of the custom domain. </param>
        /// <param name="validationToken"> The TXT record validation token. </param>
        /// <param name="errorMessage"></param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.StaticSiteCustomDomainOverviewData"/> instance for mocking. </returns>
        public static StaticSiteCustomDomainOverviewData StaticSiteCustomDomainOverviewData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string domainName = null, DateTimeOffset? createdOn = null, CustomDomainStatus? status = null, string validationToken = null, string errorMessage = null, string kind = null)
        {
            return new StaticSiteCustomDomainOverviewData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                domainName,
                createdOn,
                status,
                validationToken,
                errorMessage,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Description of a SKU for a scalable resource. </param>
        /// <param name="identity"> Managed service identity. </param>
        /// <param name="defaultHostname"> The default autogenerated hostname for the static site. </param>
        /// <param name="repositoryUri"> URL for the repository of the static site. </param>
        /// <param name="branch"> The target branch in the repository. </param>
        /// <param name="customDomains"> The custom domains associated with this static site. </param>
        /// <param name="repositoryToken"> A user's github repository token. This is used to setup the Github Actions workflow file and API secrets. </param>
        /// <param name="buildProperties"> Build properties to configure on the repository. </param>
        /// <param name="privateEndpointConnections"> Private endpoint connections. </param>
        /// <param name="stagingEnvironmentPolicy"> State indicating whether staging environments are allowed or not allowed for a static web app. </param>
        /// <param name="allowConfigFileUpdates"> &lt;code&gt;false&lt;/code&gt; if config file is locked for this static web app; otherwise, &lt;code&gt;true&lt;/code&gt;. </param>
        /// <param name="templateProperties"> Template options for generating a new repository. </param>
        /// <param name="contentDistributionEndpoint"> The content distribution endpoint for the static site. </param>
        /// <param name="keyVaultReferenceIdentity"> Identity to use for Key Vault Reference authentication. </param>
        /// <param name="userProvidedFunctionApps"> User provided function apps registered with the static site. </param>
        /// <param name="linkedBackends"> Backends linked to the static side. </param>
        /// <param name="provider"> The provider that submitted the last deployment to the primary environment of the static site. </param>
        /// <param name="enterpriseGradeCdnStatus"> State indicating the status of the enterprise grade CDN serving traffic to the static web app. </param>
        /// <param name="publicNetworkAccess"> State indicating whether public traffic are allowed or not for a static web app. Allowed Values: 'Enabled', 'Disabled' or an empty string. </param>
        /// <param name="databaseConnections"> Database connections for the static site. </param>
        /// <param name="kind"> Kind of resource. If the resource is an app, you can refer to https://github.com/Azure/app-service-linux-docs/blob/master/Things_You_Should_Know/kind_property.md#app-service-resource-kind-reference for details supported values for kind. </param>
        /// <returns> A new <see cref="AppService.StaticSiteData"/> instance for mocking. </returns>
        public static StaticSiteData StaticSiteData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, AppServiceSkuDescription sku = null, ManagedServiceIdentity identity = null, string defaultHostname = null, Uri repositoryUri = null, string branch = null, IEnumerable<string> customDomains = null, string repositoryToken = null, StaticSiteBuildProperties buildProperties = null, IEnumerable<ResponseMessageEnvelopeRemotePrivateEndpointConnection> privateEndpointConnections = null, StagingEnvironmentPolicy? stagingEnvironmentPolicy = null, bool? allowConfigFileUpdates = null, StaticSiteTemplate templateProperties = null, string contentDistributionEndpoint = null, string keyVaultReferenceIdentity = null, IEnumerable<StaticSiteUserProvidedFunctionAppData> userProvidedFunctionApps = null, IEnumerable<StaticSiteLinkedBackendInfo> linkedBackends = null, string provider = null, EnterpriseGradeCdnStatus? enterpriseGradeCdnStatus = null, string publicNetworkAccess = null, IEnumerable<StaticSiteDatabaseConnectionOverview> databaseConnections = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();
            customDomains ??= new List<string>();
            privateEndpointConnections ??= new List<ResponseMessageEnvelopeRemotePrivateEndpointConnection>();
            userProvidedFunctionApps ??= new List<StaticSiteUserProvidedFunctionAppData>();
            linkedBackends ??= new List<StaticSiteLinkedBackendInfo>();
            databaseConnections ??= new List<StaticSiteDatabaseConnectionOverview>();

            return new StaticSiteData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                kind,
                sku,
                identity,
                defaultHostname,
                repositoryUri,
                branch,
                customDomains?.ToList(),
                repositoryToken,
                buildProperties,
                privateEndpointConnections?.ToList(),
                stagingEnvironmentPolicy,
                allowConfigFileUpdates,
                templateProperties,
                contentDistributionEndpoint,
                keyVaultReferenceIdentity,
                userProvidedFunctionApps?.ToList(),
                linkedBackends?.ToList(),
                provider,
                enterpriseGradeCdnStatus,
                publicNetworkAccess,
                databaseConnections?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteDatabaseConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="resourceId"> The resource id of the database. </param>
        /// <param name="connectionIdentity"> If present, the identity is used in conjunction with connection string to connect to the database. Use of the system-assigned managed identity is indicated with the string 'SystemAssigned', while use of a user-assigned managed identity is indicated with the resource id of the managed identity resource. </param>
        /// <param name="connectionString"> The connection string to use to connect to the database. </param>
        /// <param name="region"> The region of the database resource. </param>
        /// <param name="configurationFiles"> A list of configuration files associated with this database connection. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.StaticSiteDatabaseConnectionData"/> instance for mocking. </returns>
        public static StaticSiteDatabaseConnectionData StaticSiteDatabaseConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ResourceIdentifier resourceId = null, string connectionIdentity = null, string connectionString = null, string region = null, IEnumerable<StaticSiteDatabaseConnectionConfigurationFileOverview> configurationFiles = null, string kind = null)
        {
            configurationFiles ??= new List<StaticSiteDatabaseConnectionConfigurationFileOverview>();

            return new StaticSiteDatabaseConnectionData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                resourceId,
                connectionIdentity,
                connectionString,
                region,
                configurationFiles?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteLinkedBackendData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="backendResourceId"> The resource id of the backend linked to the static site. </param>
        /// <param name="region"> The region of the backend linked to the static site. </param>
        /// <param name="createdOn"> The date and time on which the backend was linked to the static site. </param>
        /// <param name="provisioningState"> The provisioning state of the linking process. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.StaticSiteLinkedBackendData"/> instance for mocking. </returns>
        public static StaticSiteLinkedBackendData StaticSiteLinkedBackendData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ResourceIdentifier backendResourceId = null, string region = null, DateTimeOffset? createdOn = null, string provisioningState = null, string kind = null)
        {
            return new StaticSiteLinkedBackendData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                backendResourceId,
                region,
                createdOn,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.StaticSiteUserProvidedFunctionAppData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="functionAppResourceId"> The resource id of the function app registered with the static site. </param>
        /// <param name="functionAppRegion"> The region of the function app registered with the static site. </param>
        /// <param name="createdOn"> The date and time on which the function app was registered with the static site. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.StaticSiteUserProvidedFunctionAppData"/> instance for mocking. </returns>
        public static StaticSiteUserProvidedFunctionAppData StaticSiteUserProvidedFunctionAppData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ResourceIdentifier functionAppResourceId = null, string functionAppRegion = null, DateTimeOffset? createdOn = null, string kind = null)
        {
            return new StaticSiteUserProvidedFunctionAppData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                functionAppResourceId,
                functionAppRegion,
                createdOn,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.SwiftVirtualNetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="subnetResourceId"> The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation to Microsoft.Web/serverFarms defined first. </param>
        /// <param name="isSwiftSupported"> A flag that specifies if the scale unit this Web App is on supports Swift integration. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.SwiftVirtualNetworkData"/> instance for mocking. </returns>
        public static SwiftVirtualNetworkData SwiftVirtualNetworkData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ResourceIdentifier subnetResourceId = null, bool? isSwiftSupported = null, string kind = null)
        {
            return new SwiftVirtualNetworkData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                subnetResourceId,
                isSwiftSupported,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.TriggeredJobHistoryData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="runs"> List of triggered web job runs. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.TriggeredJobHistoryData"/> instance for mocking. </returns>
        public static TriggeredJobHistoryData TriggeredJobHistoryData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IEnumerable<TriggeredJobRun> runs = null, string kind = null)
        {
            runs ??= new List<TriggeredJobRun>();

            return new TriggeredJobHistoryData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                runs?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.TriggeredWebJobData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="latestRun"> Latest job run information. </param>
        /// <param name="historyUri"> History URL. </param>
        /// <param name="schedulerLogsUri"> Scheduler Logs URL. </param>
        /// <param name="runCommand"> Run command. </param>
        /// <param name="uri"> Job URL. </param>
        /// <param name="extraInfoUri"> Extra Info URL. </param>
        /// <param name="webJobType"> Job type. </param>
        /// <param name="error"> Error information. </param>
        /// <param name="isUsingSdk"> Using SDK?. </param>
        /// <param name="publicNetworkAccess"> Property to allow or block all public traffic. Allowed Values: 'Enabled', 'Disabled' or an empty string. </param>
        /// <param name="isStorageAccountRequired"> Checks if Customer provided storage account is required. </param>
        /// <param name="settings"> Job settings. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.TriggeredWebJobData"/> instance for mocking. </returns>
        public static TriggeredWebJobData TriggeredWebJobData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, TriggeredJobRun latestRun = null, Uri historyUri = null, Uri schedulerLogsUri = null, string runCommand = null, Uri uri = null, Uri extraInfoUri = null, WebJobType? webJobType = null, string error = null, bool? isUsingSdk = null, string publicNetworkAccess = null, bool? isStorageAccountRequired = null, IDictionary<string, BinaryData> settings = null, string kind = null)
        {
            settings ??= new Dictionary<string, BinaryData>();

            return new TriggeredWebJobData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                latestRun,
                historyUri,
                schedulerLogsUri,
                runCommand,
                uri,
                extraInfoUri,
                webJobType,
                error,
                isUsingSdk,
                publicNetworkAccess,
                isStorageAccountRequired,
                settings,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.WebAppBackupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="backupId"> Id of the backup. </param>
        /// <param name="storageAccountUri"> SAS URL for the storage account container which contains this backup. </param>
        /// <param name="blobName"> Name of the blob which contains data for this backup. </param>
        /// <param name="backupName"> Name of this backup. </param>
        /// <param name="status"> Backup status. </param>
        /// <param name="sizeInBytes"> Size of the backup in bytes. </param>
        /// <param name="createdOn"> Timestamp of the backup creation. </param>
        /// <param name="log"> Details regarding this backup. Might contain an error message. </param>
        /// <param name="databases"> List of databases included in the backup. </param>
        /// <param name="isScheduled"> True if this backup has been created due to a schedule being triggered. </param>
        /// <param name="lastRestoreOn"> Timestamp of a last restore operation which used this backup. </param>
        /// <param name="finishedOn"> Timestamp when this backup finished. </param>
        /// <param name="correlationId"> Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support. </param>
        /// <param name="websiteSizeInBytes"> Size of the original web app which has been backed up. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.WebAppBackupData"/> instance for mocking. </returns>
        public static WebAppBackupData WebAppBackupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? backupId = null, Uri storageAccountUri = null, string blobName = null, string backupName = null, WebAppBackupStatus? status = null, long? sizeInBytes = null, DateTimeOffset? createdOn = null, string log = null, IEnumerable<AppServiceDatabaseBackupSetting> databases = null, bool? isScheduled = null, DateTimeOffset? lastRestoreOn = null, DateTimeOffset? finishedOn = null, string correlationId = null, long? websiteSizeInBytes = null, string kind = null)
        {
            databases ??= new List<AppServiceDatabaseBackupSetting>();

            return new WebAppBackupData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                backupId,
                storageAccountUri,
                blobName,
                backupName,
                status,
                sizeInBytes,
                createdOn,
                log,
                databases?.ToList(),
                isScheduled,
                lastRestoreOn,
                finishedOn,
                correlationId,
                websiteSizeInBytes,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.WebAppDeploymentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="status"> Deployment status. </param>
        /// <param name="message"> Details about deployment status. </param>
        /// <param name="author"> Who authored the deployment. </param>
        /// <param name="deployer"> Who performed the deployment. </param>
        /// <param name="authorEmail"> Author email. </param>
        /// <param name="startOn"> Start time. </param>
        /// <param name="endOn"> End time. </param>
        /// <param name="isActive"> True if deployment is currently active, false if completed and null if not started. </param>
        /// <param name="details"> Details on deployment. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.WebAppDeploymentData"/> instance for mocking. </returns>
        public static WebAppDeploymentData WebAppDeploymentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? status = null, string message = null, string author = null, string deployer = null, string authorEmail = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null, bool? isActive = null, string details = null, string kind = null)
        {
            return new WebAppDeploymentData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                status,
                message,
                author,
                deployer,
                authorEmail,
                startOn,
                endOn,
                isActive,
                details,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.WebJobData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="runCommand"> Run command. </param>
        /// <param name="uri"> Job URL. </param>
        /// <param name="extraInfoUri"> Extra Info URL. </param>
        /// <param name="webJobType"> Job type. </param>
        /// <param name="error"> Error information. </param>
        /// <param name="isUsingSdk"> Using SDK?. </param>
        /// <param name="settings"> Job settings. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.WebJobData"/> instance for mocking. </returns>
        public static WebJobData WebJobData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string runCommand = null, Uri uri = null, Uri extraInfoUri = null, WebJobType? webJobType = null, string error = null, bool? isUsingSdk = null, IDictionary<string, BinaryData> settings = null, string kind = null)
        {
            settings ??= new Dictionary<string, BinaryData>();

            return new WebJobData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                runCommand,
                uri,
                extraInfoUri,
                webJobType,
                error,
                isUsingSdk,
                settings,
                serializedAdditionalRawData: null);
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
        /// <param name="outboundVnetRouting"> Property to configure various outbound traffic routing options over virtual network for a site. </param>
        /// <param name="siteConfig"> Configuration of an App Service app. This property is not returned in response to normal create and read requests since it may contain sensitive information. </param>
        /// <param name="functionAppConfig"> Configuration specific of the Azure Function app. </param>
        /// <param name="daprConfig"> Dapr configuration of the app. </param>
        /// <param name="workloadProfileName"> Workload profile name for function app to execute on. </param>
        /// <param name="resourceConfig"> Function app resource requirements. </param>
        /// <param name="trafficManagerHostNames"> Azure Traffic Manager hostnames associated with the app. Read-only. </param>
        /// <param name="isScmSiteAlsoStopped"> &lt;code&gt;true&lt;/code&gt; to stop SCM (KUDU) site when the app is stopped; otherwise, &lt;code&gt;false&lt;/code&gt;. The default is &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="targetSwapSlot"> Specifies which deployment slot this app will swap into. Read-only. </param>
        /// <param name="hostingEnvironmentProfile"> App Service Environment to use for the app. </param>
        /// <param name="isClientAffinityEnabled"> &lt;code&gt;true&lt;/code&gt; to enable client affinity; &lt;code&gt;false&lt;/code&gt; to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is &lt;code&gt;true&lt;/code&gt;. </param>
        /// <param name="isClientAffinityPartitioningEnabled"> &lt;code&gt;true&lt;/code&gt; to enable client affinity partitioning using CHIPS cookies, this will add the &lt;code&gt;partitioned&lt;/code&gt; property to the affinity cookies; &lt;code&gt;false&lt;/code&gt; to stop sending partitioned affinity cookies. Default is &lt;code&gt;false&lt;/code&gt;. </param>
        /// <param name="isClientAffinityProxyEnabled"> &lt;code&gt;true&lt;/code&gt; to override client affinity cookie domain with X-Forwarded-Host request header. &lt;code&gt;false&lt;/code&gt; to use default domain. Default is &lt;code&gt;false&lt;/code&gt;. </param>
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
        /// <param name="isSshEnabled"> Whether to enable ssh access. </param>
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
        public static WebSiteData WebSiteData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ManagedServiceIdentity identity = null, ExtendedLocation extendedLocation = null, string state = null, IEnumerable<string> hostNames = null, string repositorySiteName = null, AppServiceUsageState? usageState = null, bool? isEnabled = null, IEnumerable<string> enabledHostNames = null, WebSiteAvailabilityState? availabilityState = null, IEnumerable<HostNameSslState> hostNameSslStates = null, ResourceIdentifier appServicePlanId = null, bool? isReserved = null, bool? isXenon = null, bool? isHyperV = null, DateTimeOffset? lastModifiedTimeUtc = null, SiteDnsConfig dnsConfiguration = null, OutboundVnetRouting outboundVnetRouting = null, SiteConfigProperties siteConfig = null, FunctionAppConfig functionAppConfig = null, AppDaprConfig daprConfig = null, string workloadProfileName = null, FunctionAppResourceConfig resourceConfig = null, IEnumerable<string> trafficManagerHostNames = null, bool? isScmSiteAlsoStopped = null, string targetSwapSlot = null, HostingEnvironmentProfile hostingEnvironmentProfile = null, bool? isClientAffinityEnabled = null, bool? isClientAffinityPartitioningEnabled = null, bool? isClientAffinityProxyEnabled = null, bool? isClientCertEnabled = null, ClientCertMode? clientCertMode = null, string clientCertExclusionPaths = null, AppServiceIPMode? ipMode = null, bool? isEndToEndEncryptionEnabled = null, bool? isSshEnabled = null, bool? isHostNameDisabled = null, string customDomainVerificationId = null, string outboundIPAddresses = null, string possibleOutboundIPAddresses = null, int? containerSize = null, int? dailyMemoryTimeQuota = null, DateTimeOffset? suspendOn = null, int? maxNumberOfWorkers = null, CloningInfo cloningInfo = null, string resourceGroup = null, bool? isDefaultContainer = null, string defaultHostName = null, SlotSwapStatus slotSwapStatus = null, bool? isHttpsOnly = null, RedundancyMode? redundancyMode = null, Guid? inProgressOperationId = null, string publicNetworkAccess = null, bool? isStorageAccountRequired = null, string keyVaultReferenceIdentity = null, AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = null, ResourceIdentifier virtualNetworkSubnetId = null, string managedEnvironmentId = null, string sku = null, string kind = null)
        {
            tags ??= new Dictionary<string, string>();
            hostNames ??= new List<string>();
            enabledHostNames ??= new List<string>();
            hostNameSslStates ??= new List<HostNameSslState>();
            trafficManagerHostNames ??= new List<string>();

            return new WebSiteData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                identity,
                extendedLocation,
                kind,
                state,
                hostNames?.ToList(),
                repositorySiteName,
                usageState,
                isEnabled,
                enabledHostNames?.ToList(),
                availabilityState,
                hostNameSslStates?.ToList(),
                appServicePlanId,
                isReserved,
                isXenon,
                isHyperV,
                lastModifiedTimeUtc,
                dnsConfiguration,
                outboundVnetRouting,
                siteConfig,
                functionAppConfig,
                daprConfig,
                workloadProfileName,
                resourceConfig,
                trafficManagerHostNames?.ToList(),
                isScmSiteAlsoStopped,
                targetSwapSlot,
                hostingEnvironmentProfile,
                isClientAffinityEnabled,
                isClientAffinityPartitioningEnabled,
                isClientAffinityProxyEnabled,
                isClientCertEnabled,
                clientCertMode,
                clientCertExclusionPaths,
                ipMode,
                isEndToEndEncryptionEnabled,
                isSshEnabled,
                isHostNameDisabled,
                customDomainVerificationId,
                outboundIPAddresses,
                possibleOutboundIPAddresses,
                containerSize,
                dailyMemoryTimeQuota,
                suspendOn,
                maxNumberOfWorkers,
                cloningInfo,
                resourceGroup,
                isDefaultContainer,
                defaultHostName,
                slotSwapStatus,
                isHttpsOnly,
                redundancyMode,
                inProgressOperationId,
                publicNetworkAccess,
                isStorageAccountRequired,
                keyVaultReferenceIdentity,
                autoGeneratedDomainNameLabelScope,
                virtualNetworkSubnetId,
                managedEnvironmentId,
                sku,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.WebSiteInstanceStatusData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="state"></param>
        /// <param name="statusUri"> Link to the GetStatusApi in Kudu. </param>
        /// <param name="detectorUri"> Link to the Diagnose and Solve Portal. </param>
        /// <param name="consoleUri"> Link to the console to web app instance. </param>
        /// <param name="healthCheckUrlString"> Link to the console to web app instance. </param>
        /// <param name="containers"> Dictionary of &lt;ContainerInfo&gt;. </param>
        /// <param name="physicalZone"> The physical zone that the instance is in. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.WebSiteInstanceStatusData"/> instance for mocking. </returns>
        public static WebSiteInstanceStatusData WebSiteInstanceStatusData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, SiteRuntimeState? state = null, Uri statusUri = null, Uri detectorUri = null, Uri consoleUri = null, string healthCheckUrlString = null, IDictionary<string, ContainerInfo> containers = null, string physicalZone = null, string kind = null)
        {
            containers ??= new Dictionary<string, ContainerInfo>();

            return new WebSiteInstanceStatusData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                state,
                statusUri,
                detectorUri,
                consoleUri,
                healthCheckUrlString,
                containers,
                physicalZone,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="AppService.WorkflowEnvelopeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> The resource kind. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="properties"> Additional workflow properties. </param>
        /// <returns> A new <see cref="AppService.WorkflowEnvelopeData"/> instance for mocking. </returns>
        public static WorkflowEnvelopeData WorkflowEnvelopeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, AzureLocation? location = null, WorkflowEnvelopeProperties properties = null)
        {
            return new WorkflowEnvelopeData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                kind,
                location,
                serializedAdditionalRawData: null);
        }
    }
}
