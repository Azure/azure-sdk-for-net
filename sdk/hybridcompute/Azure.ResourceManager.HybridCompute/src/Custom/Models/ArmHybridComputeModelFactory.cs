// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.HybridCompute;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    [CodeGenSuppress("EsuKey", typeof(string), typeof(int?))]
    [CodeGenSuppress("HybridComputePrivateLinkScopeProperties", typeof(HybridComputePublicNetworkAccessType?), typeof(string), typeof(string), typeof(IEnumerable<PrivateEndpointConnectionDataModel>), typeof(IEnumerable<ServiceExtension>))]
    [CodeGenSuppress("HybridComputePrivateLinkScopeProperties", typeof(HybridComputePublicNetworkAccessType?), typeof(string), typeof(string), typeof(IEnumerable<PrivateEndpointConnectionDataModel>))]
    [CodeGenSuppress("HybridComputeWindowsConfiguration")]
    [CodeGenSuppress("HybridComputeWindowsConfiguration", typeof(AssessmentModeType?), typeof(PatchModeType?), typeof(bool?), typeof(HybridComputePatchSettingsStatus))]
    [CodeGenSuppress("HybridComputeWindowsConfiguration", typeof(PatchSettings), typeof(IDictionary<string, BinaryData>))]
    public static partial class ArmHybridComputeModelFactory
    {
        /// <summary>
        /// Creates an ArcSettings for mocking.
        /// This method preserves the AutoRest-generated model factory API for backward compatibility.
        /// Use <see cref="ArcSettingsData(ResourceIdentifier, string, ResourceType, Azure.ResourceManager.Models.SystemData, string, ResourceIdentifier)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArcSettings ArcSettings(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, Guid? tenantId = default, ResourceIdentifier gatewayResourceId = default)
            => new ArcSettings(id, name, resourceType, systemData, tenantId, gatewayResourceId, serializedAdditionalRawData: null);

        /// <summary>
        /// Creates a HybridComputePrivateEndpointConnectionProperties for mocking.
        /// This overload accepts <see cref="ResourceIdentifier"/> for <paramref name="privateEndpointId"/> for backward compatibility.
        /// Use the overload that accepts a string privateEndpointId instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HybridComputePrivateEndpointConnectionProperties HybridComputePrivateEndpointConnectionProperties(ResourceIdentifier privateEndpointId = default, HybridComputePrivateLinkServiceConnectionStateProperty connectionState = default, string provisioningState = default, IEnumerable<string> groupIds = default)
            => new HybridComputePrivateEndpointConnectionProperties(new PrivateEndpointProperty(privateEndpointId, additionalBinaryDataProperties: null), connectionState, provisioningState, groupIds is null ? new List<string>() : new List<string>(groupIds), additionalBinaryDataProperties: null);

        /// <summary>
        /// Creates a HybridComputePrivateLinkScopeProperties for mocking.
        /// This overload preserves the AutoRest-generated model factory API for backward compatibility.
        /// </summary>
        public static HybridComputePrivateLinkScopeProperties HybridComputePrivateLinkScopeProperties(HybridComputePublicNetworkAccessType? publicNetworkAccess = default, string provisioningState = default, string privateLinkScopeId = default, IEnumerable<PrivateEndpointConnectionDataModel> privateEndpointConnections = default)
        {
            privateEndpointConnections ??= new ChangeTrackingList<PrivateEndpointConnectionDataModel>();

            return new HybridComputePrivateLinkScopeProperties(
                publicNetworkAccess,
                provisioningState,
                privateLinkScopeId,
                new List<PrivateEndpointConnectionDataModel>(privateEndpointConnections),
                serviceExtensions: new ChangeTrackingList<ServiceExtension>(),
                additionalBinaryDataProperties: null);
        }

        /// <summary> Creates a HybridComputeWindowsConfiguration for mocking. </summary>
        public static HybridComputeWindowsConfiguration HybridComputeWindowsConfiguration(AssessmentModeType? assessmentMode = default, PatchModeType? patchMode = default, bool? isHotpatchingEnabled = default, HybridComputePatchSettingsStatus status = default)
            => new HybridComputeWindowsConfiguration(assessmentMode is null && patchMode is null && isHotpatchingEnabled is null && status is null ? default : new PatchSettings(assessmentMode, patchMode, isHotpatchingEnabled, status, additionalBinaryDataProperties: null), additionalBinaryDataProperties: null);

        /// <summary> Creates an EsuKey for mocking. </summary>
        public static EsuKey EsuKey(string sku = default, int? licenseStatus = default)
            => new EsuKey(sku, licenseStatus, additionalBinaryDataProperties: null);

        /// <summary> Creates a HybridComputeLicense for mocking. </summary>
        public static HybridComputeLicense HybridComputeLicense(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, HybridComputeProvisioningState? provisioningState = default, Guid? tenantId = default, HybridComputeLicenseType? licenseType = default, HybridComputeLicenseDetails licenseDetails = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new HybridComputeLicense(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && tenantId is null && licenseType is null && licenseDetails is null ? default : new LicenseProperties(provisioningState, tenantId, licenseType, licenseDetails, additionalBinaryDataProperties: null));
        }
    }
}
