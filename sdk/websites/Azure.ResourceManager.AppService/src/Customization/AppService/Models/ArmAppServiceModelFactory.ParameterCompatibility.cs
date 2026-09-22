// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenSuppress("AppServiceIdentifierData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    [CodeGenSuppress("PremierAddOnData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("DiagnosticCategoryData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    [CodeGenSuppress("WebSiteAnalysisDefinitionData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string))]
    [CodeGenSuppress("AppServiceVirtualNetworkGatewayData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(Uri), typeof(string))]
    [CodeGenSuppress("ContinuousWebJobData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(ContinuousWebJobStatus?), typeof(string), typeof(Uri), typeof(string), typeof(Uri), typeof(Uri), typeof(WebJobType?), typeof(string), typeof(bool?), typeof(IDictionary<string, BinaryData>), typeof(string))]
    [CodeGenSuppress("CsmPublishingCredentialsPoliciesEntityData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(bool?), typeof(string))]
    [CodeGenSuppress("AppServiceDetectorData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(DetectorInfo), typeof(IEnumerable<DiagnosticDataset>), typeof(AppServiceStatusInfo), typeof(IEnumerable<DataProviderMetadata>), typeof(QueryUtterancesResults), typeof(string))]
    [CodeGenSuppress("AppServiceSourceControlData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(string))]
    [CodeGenSuppress("AseV3NetworkingConfigurationData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IEnumerable<IPAddress>), typeof(IEnumerable<IPAddress>), typeof(IEnumerable<IPAddress>), typeof(IEnumerable<IPAddress>), typeof(bool?), typeof(bool?), typeof(bool?), typeof(string), typeof(string))]
    [CodeGenSuppress("SiteContainerData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(bool?), typeof(string), typeof(SiteContainerAuthType?), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<SiteContainerVolumeMount>), typeof(bool?), typeof(IEnumerable<WebAppEnvironmentVariable>), typeof(string))]
    [CodeGenSuppress("CustomDnsSuffixConfigurationData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(CustomDnsSuffixProvisioningState?), typeof(string), typeof(string), typeof(Uri), typeof(string), typeof(string))]
    [CodeGenSuppress("AppServiceEnvironmentData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ProvisioningState?), typeof(HostingEnvironmentStatus?), typeof(AppServiceVirtualNetworkProfile), typeof(LoadBalancingMode?), typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(int?), typeof(int?), typeof(bool?), typeof(IEnumerable<AppServiceNameValuePair>), typeof(IEnumerable<string>), typeof(bool?), typeof(AppServiceEnvironmentUpgradePreference?), typeof(int?), typeof(bool?), typeof(CustomDnsSuffixConfigurationData), typeof(AseV3NetworkingConfigurationData), typeof(AppServiceEnvironmentUpgradeAvailability?), typeof(string))]
    public static partial class ArmAppServiceModelFactory
    {
        // Keep these wrappers until https://github.com/microsoft/typespec/issues/11667 is fixed because generated
        // compatibility overloads make every parameter required instead of preserving the GA optional trailing parameters.

        /// <summary> Creates an App Service virtual network gateway using the GA parameter optionality. </summary>
        public static AppServiceVirtualNetworkGatewayData AppServiceVirtualNetworkGatewayData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string vnetName, Uri vpnPackageUri, string kind = default)
            => AppServiceVirtualNetworkGatewayData(id, name, resourceType, systemData, kind, vnetName, vpnPackageUri);

        /// <summary> Creates a continuous web job using the GA parameter optionality. </summary>
        public static ContinuousWebJobData ContinuousWebJobData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ContinuousWebJobStatus? status, string detailedStatus = default, Uri logUri = default, string runCommand = default, Uri uri = default, Uri extraInfoUri = default, WebJobType? webJobType = default, string error = default, bool? isUsingSdk = default, IDictionary<string, BinaryData> settings = default, string kind = default)
            => ContinuousWebJobData(id, name, resourceType, systemData, kind, status, detailedStatus, logUri, runCommand, uri, extraInfoUri, webJobType, error, isUsingSdk, settings);

        /// <summary> Creates publishing credential policy data using the GA parameter optionality. </summary>
        public static CsmPublishingCredentialsPoliciesEntityData CsmPublishingCredentialsPoliciesEntityData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? allow, string kind)
            => CsmPublishingCredentialsPoliciesEntityData(id, name, resourceType, systemData, kind, allow);

        /// <summary> Creates App Service detector data using the GA parameter optionality. </summary>
        public static AppServiceDetectorData AppServiceDetectorData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DetectorInfo metadata, IEnumerable<DiagnosticDataset> dataset = default, AppServiceStatusInfo status = default, IEnumerable<DataProviderMetadata> dataProvidersMetadata = default, QueryUtterancesResults suggestedUtterances = default, string kind = default)
            => AppServiceDetectorData(id, name, resourceType, systemData, kind, metadata, dataset, status, dataProvidersMetadata, suggestedUtterances);

        /// <summary> Creates App Service source control data using the GA parameter optionality. </summary>
        public static AppServiceSourceControlData AppServiceSourceControlData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string token, string tokenSecret, string refreshToken, DateTimeOffset? expireOn, string kind = default)
            => AppServiceSourceControlData(id, name, resourceType, systemData, kind, token, tokenSecret, refreshToken, expireOn);

        /// <summary> Creates ASE v3 networking configuration data using the GA parameter optionality. </summary>
        public static AseV3NetworkingConfigurationData AseV3NetworkingConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<IPAddress> windowsOutboundIPAddresses, IEnumerable<IPAddress> linuxOutboundIPAddresses = default, IEnumerable<IPAddress> externalInboundIPAddresses = default, IEnumerable<IPAddress> internalInboundIPAddresses = default, bool? allowNewPrivateEndpointConnections = default, bool? isFtpEnabled = default, bool? isRemoteDebugEnabled = default, string inboundIPAddressOverride = default, string kind = default)
            => AseV3NetworkingConfigurationData(id, name, resourceType, systemData, kind, windowsOutboundIPAddresses, linuxOutboundIPAddresses, externalInboundIPAddresses, internalInboundIPAddresses, allowNewPrivateEndpointConnections, isFtpEnabled, isRemoteDebugEnabled, inboundIPAddressOverride);

        /// <summary> Creates site container data using the GA parameter optionality. </summary>
        public static SiteContainerData SiteContainerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string image, string targetPort, bool? isMain, string startUpCommand = default, SiteContainerAuthType? authType = default, string userName = default, string passwordSecret = default, string userManagedIdentityClientId = default, DateTimeOffset? createdOn = default, DateTimeOffset? lastModifiedOn = default, IEnumerable<SiteContainerVolumeMount> volumeMounts = default, bool? inheritAppSettingsAndConnectionStrings = default, IEnumerable<WebAppEnvironmentVariable> environmentVariables = default, string kind = default)
            => SiteContainerData(id, name, resourceType, systemData, kind, image, targetPort, isMain, startUpCommand, authType, userName, passwordSecret, userManagedIdentityClientId, createdOn, lastModifiedOn, volumeMounts, inheritAppSettingsAndConnectionStrings, environmentVariables);

        /// <summary> Creates custom DNS suffix configuration data using the GA parameter optionality. </summary>
        public static CustomDnsSuffixConfigurationData CustomDnsSuffixConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CustomDnsSuffixProvisioningState? provisioningState, string provisioningDetails = default, string dnsSuffix = default, Uri certificateUri = default, string keyVaultReferenceIdentity = default, string kind = default)
            => CustomDnsSuffixConfigurationData(id, name, resourceType, systemData, kind, provisioningState, provisioningDetails, dnsSuffix, certificateUri, keyVaultReferenceIdentity);

        /// <summary> Creates App Service environment data using the GA parameter optionality. </summary>
        public static AppServiceEnvironmentData AppServiceEnvironmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ProvisioningState? provisioningState, HostingEnvironmentStatus? status = default, AppServiceVirtualNetworkProfile virtualNetwork = default, LoadBalancingMode? internalLoadBalancingMode = default, string multiSize = default, int? multiRoleCount = default, int? ipSslAddressCount = default, string dnsSuffix = default, int? maximumNumberOfMachines = default, int? frontEndScaleFactor = default, bool? isSuspended = default, IEnumerable<AppServiceNameValuePair> clusterSettings = default, IEnumerable<string> userWhitelistedIPRanges = default, bool? hasLinuxWorkers = default, AppServiceEnvironmentUpgradePreference? upgradePreference = default, int? dedicatedHostCount = default, bool? isZoneRedundant = default, CustomDnsSuffixConfigurationData customDnsSuffixConfiguration = default, AseV3NetworkingConfigurationData networkingConfiguration = default, AppServiceEnvironmentUpgradeAvailability? upgradeAvailability = default, string kind = default)
            => AppServiceEnvironmentData(id, name, resourceType, systemData, tags, location, kind, provisioningState, status, virtualNetwork, internalLoadBalancingMode, multiSize, multiRoleCount, ipSslAddressCount, dnsSuffix, maximumNumberOfMachines, frontEndScaleFactor, isSuspended, clusterSettings, userWhitelistedIPRanges, hasLinuxWorkers, upgradePreference, dedicatedHostCount, isZoneRedundant, customDnsSuffixConfiguration, networkingConfiguration, upgradeAvailability);

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="value"> String representation of the identity. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.AppServiceIdentifierData"/> instance for mocking. </returns>
        public static AppServiceIdentifierData AppServiceIdentifierData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string kind = default, string value = default)
        {
            return new AppServiceIdentifierData(
                id,
                name,
                resourceType,
                systemData,
                value is null ? default : new IdentifierProperties(value, default),
                kind,
                default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> Premier add on SKU. </param>
        /// <param name="product"> Premier add on Product. </param>
        /// <param name="vendor"> Premier add on Vendor. </param>
        /// <param name="marketplacePublisher"> Premier add on Marketplace publisher. </param>
        /// <param name="marketplaceOffer"> Premier add on Marketplace offer. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.PremierAddOnData"/> instance for mocking. </returns>
        public static PremierAddOnData PremierAddOnData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, string kind = default, string sku = default, string product = default, string vendor = default, string marketplacePublisher = default, string marketplaceOffer = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new PremierAddOnData(
                id,
                name,
                resourceType,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                sku is null && product is null && vendor is null && marketplacePublisher is null && marketplaceOffer is null ? default : new PremierAddOnProperties(
                    sku,
                    product,
                    vendor,
                    marketplacePublisher,
                    marketplaceOffer,
                    default),
                kind,
                default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="description"> Description of the diagnostic category. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.DiagnosticCategoryData"/> instance for mocking. </returns>
        public static DiagnosticCategoryData DiagnosticCategoryData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string kind = default, string description = default)
        {
            return new DiagnosticCategoryData(
                id,
                name,
                resourceType,
                systemData,
                description is null ? default : new DiagnosticCategoryProperties(description, default),
                kind,
                default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="description"> Description of the Analysis. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <returns> A new <see cref="AppService.WebSiteAnalysisDefinitionData"/> instance for mocking. </returns>
        public static WebSiteAnalysisDefinitionData WebSiteAnalysisDefinitionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string kind = default, string description = default)
        {
            return new WebSiteAnalysisDefinitionData(
                id,
                name,
                resourceType,
                systemData,
                description is null ? default : new AnalysisDefinitionProperties(description, default),
                kind,
                default);
        }
    }
}
