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
        public static SiteConfigData SiteConfigData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, int? numberOfWorkers = null, IEnumerable<string> defaultDocuments = null, string netFrameworkVersion = null, string phpVersion = null, string pythonVersion = null, string nodeVersion = null, string powerShellVersion = null, string linuxFxVersion = null, string windowsFxVersion = null, bool? isRequestTracingEnabled = null, DateTimeOffset? requestTracingExpirationOn = null, bool? isRemoteDebuggingEnabled = null, string remoteDebuggingVersion = null, bool? isHttpLoggingEnabled = null, bool? useManagedIdentityCreds = null, string acrUserManagedIdentityId = null, int? logsDirectorySizeLimit = null, bool? isDetailedErrorLoggingEnabled = null, string publishingUsername = null, IEnumerable<AppServiceNameValuePair> appSettings = null, IEnumerable<AppServiceNameValuePair> metadata = null, IEnumerable<ConnStringInfo> connectionStrings = null, SiteMachineKey machineKey = null, IEnumerable<HttpRequestHandlerMapping> handlerMappings = null, string documentRoot = null, ScmType? scmType = null, bool? use32BitWorkerProcess = null, bool? isWebSocketsEnabled = null, bool? isAlwaysOn = null, string javaVersion = null, string javaContainer = null, string javaContainerVersion = null, string appCommandLine = null, ManagedPipelineMode? managedPipelineMode = null, IEnumerable<VirtualApplication> virtualApplications = null, SiteLoadBalancing? loadBalancing = null, IEnumerable<RampUpRule> experimentsRampUpRules = null, SiteLimits limits = null, bool? isAutoHealEnabled = null, AutoHealRules autoHealRules = null, string tracingOptions = null, string vnetName = null, bool? isVnetRouteAllEnabled = null, int? vnetPrivatePortsCount = null, AppServiceCorsSettings cors = null, WebAppPushSettings push = null, Uri apiDefinitionUri = null, string apiManagementConfigId = null, string autoSwapSlotName = null, bool? isLocalMySqlEnabled = null, int? managedServiceIdentityId = null, int? xManagedServiceIdentityId = null, string keyVaultReferenceIdentity = null, IEnumerable<AppServiceIPSecurityRestriction> ipSecurityRestrictions = null, SiteDefaultAction? ipSecurityRestrictionsDefaultAction = null, IEnumerable<AppServiceIPSecurityRestriction> scmIPSecurityRestrictions = null, SiteDefaultAction? scmIPSecurityRestrictionsDefaultAction = null, bool? allowIPSecurityRestrictionsForScmToUseMain = null, bool? isHttp20Enabled = null, int? http20ProxyFlag = null, AppServiceSupportedTlsVersion? minTlsVersion = null, AppServiceTlsCipherSuite? minTlsCipherSuite = null, AppServiceSupportedTlsVersion? scmMinTlsVersion = null, AppServiceFtpsState? ftpsState = null, int? preWarmedInstanceCount = null, int? functionAppScaleLimit = null, int? elasticWebAppScaleLimit = null, string healthCheckPath = null, bool? isFunctionsRuntimeScaleMonitoringEnabled = null, string websiteTimeZone = null, int? minimumElasticInstanceCount = null, IDictionary<string, AppServiceStorageAccessInfo> azureStorageAccounts = null, string publicNetworkAccess = null, string kind = null)
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

            return new SiteConfigData(
                id,
                name,
                resourceType,
                systemData,
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
                kind,
                serializedAdditionalRawData: null);
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
        public static SiteConfigData SiteConfigData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? numberOfWorkers, IEnumerable<string> defaultDocuments, string netFrameworkVersion, string phpVersion, string pythonVersion, string nodeVersion, string powerShellVersion, string linuxFxVersion, string windowsFxVersion, bool? isRequestTracingEnabled, DateTimeOffset? requestTracingExpirationOn, bool? isRemoteDebuggingEnabled, string remoteDebuggingVersion, bool? isHttpLoggingEnabled, bool? useManagedIdentityCreds, string acrUserManagedIdentityId, int? logsDirectorySizeLimit, bool? isDetailedErrorLoggingEnabled, string publishingUsername, IEnumerable<AppServiceNameValuePair> appSettings, IEnumerable<AppServiceNameValuePair> metadata, IEnumerable<ConnStringInfo> connectionStrings, SiteMachineKey machineKey, IEnumerable<HttpRequestHandlerMapping> handlerMappings, string documentRoot, ScmType? scmType, bool? use32BitWorkerProcess, bool? isWebSocketsEnabled, bool? isAlwaysOn, string javaVersion, string javaContainer, string javaContainerVersion, string appCommandLine, ManagedPipelineMode? managedPipelineMode, IEnumerable<VirtualApplication> virtualApplications, SiteLoadBalancing? loadBalancing, IEnumerable<RampUpRule> experimentsRampUpRules, SiteLimits limits, bool? isAutoHealEnabled, AutoHealRules autoHealRules, string tracingOptions, string vnetName, bool? isVnetRouteAllEnabled, int? vnetPrivatePortsCount, AppServiceCorsSettings cors, WebAppPushSettings push, Uri apiDefinitionUri, string apiManagementConfigId, string autoSwapSlotName, bool? isLocalMySqlEnabled, int? managedServiceIdentityId, int? xManagedServiceIdentityId, string keyVaultReferenceIdentity, IEnumerable<AppServiceIPSecurityRestriction> ipSecurityRestrictions, SiteDefaultAction? ipSecurityRestrictionsDefaultAction, IEnumerable<AppServiceIPSecurityRestriction> scmIPSecurityRestrictions, SiteDefaultAction? scmIPSecurityRestrictionsDefaultAction, bool? allowIPSecurityRestrictionsForScmToUseMain, bool? isHttp20Enabled, AppServiceSupportedTlsVersion? minTlsVersion, AppServiceTlsCipherSuite? minTlsCipherSuite, AppServiceSupportedTlsVersion? scmMinTlsVersion, AppServiceFtpsState? ftpsState, int? preWarmedInstanceCount, int? functionAppScaleLimit, int? elasticWebAppScaleLimit, string healthCheckPath, bool? isFunctionsRuntimeScaleMonitoringEnabled, string websiteTimeZone, int? minimumElasticInstanceCount, IDictionary<string, AppServiceStorageAccessInfo> azureStorageAccounts, string publicNetworkAccess, string kind)
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
    }
}
