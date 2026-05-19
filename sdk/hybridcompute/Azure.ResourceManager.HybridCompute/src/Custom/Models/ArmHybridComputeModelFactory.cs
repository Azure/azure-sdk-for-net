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
    [CodeGenSuppress("LicenseProfileMachineInstanceViewEsuProperties", typeof(Guid?), typeof(IEnumerable<EsuKey>), typeof(EsuServerType?), typeof(EsuEligibility?), typeof(EsuKeyState?), typeof(HybridComputeLicenseData), typeof(LicenseAssignmentState?))]
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
        public static HybridComputePrivateEndpointConnectionProperties HybridComputePrivateEndpointConnectionProperties(ResourceIdentifier privateEndpointId, HybridComputePrivateLinkServiceConnectionStateProperty connectionState = default, string provisioningState = default, IEnumerable<string> groupIds = default)
            => new HybridComputePrivateEndpointConnectionProperties(new PrivateEndpointProperty(privateEndpointId, additionalBinaryDataProperties: null), connectionState, provisioningState, groupIds is null ? new List<string>() : new List<string>(groupIds), additionalBinaryDataProperties: null);

        /// <summary> Creates an EsuKey for mocking. </summary>
        public static EsuKey EsuKey(string sku = default, string licenseStatus = default)
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

        /// <summary> Creates a LicenseProfileMachineInstanceViewEsuProperties for mocking. </summary>
        public static LicenseProfileMachineInstanceViewEsuProperties LicenseProfileMachineInstanceViewEsuProperties(Guid? assignedLicenseImmutableId = default, IEnumerable<EsuKey> esuKeys = default, EsuServerType? serverType = default, EsuEligibility? esuEligibility = default, EsuKeyState? esuKeyState = default, HybridComputeLicense assignedLicense = default, LicenseAssignmentState? licenseAssignmentState = default)
        {
            esuKeys ??= new ChangeTrackingList<EsuKey>();

            return new LicenseProfileMachineInstanceViewEsuProperties(
                assignedLicenseImmutableId,
                new List<EsuKey>(esuKeys),
                additionalBinaryDataProperties: null,
                serverType,
                esuEligibility,
                esuKeyState,
                assignedLicense,
                licenseAssignmentState);
        }
    }
}
