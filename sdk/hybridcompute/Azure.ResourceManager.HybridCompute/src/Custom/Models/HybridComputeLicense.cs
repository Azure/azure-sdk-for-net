// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: some custom APIs still expose HybridComputeLicense in the Models namespace.
    /// <summary> Describes a license in a hybrid machine. </summary>
    public partial class HybridComputeLicense : HybridComputeLicenseData
    {
        /// <summary> Initializes a new instance of <see cref="HybridComputeLicense"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public HybridComputeLicense(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="HybridComputeLicense"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="tenantId"> Describes the tenant id. </param>
        /// <param name="licenseType"> The type of the license resource. </param>
        /// <param name="licenseDetails"> Describes the properties of a License. </param>
        public HybridComputeLicense(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, IDictionary<string, string> tags, AzureLocation location, HybridComputeProvisioningState? provisioningState, Guid? tenantId, HybridComputeLicenseType? licenseType, HybridComputeLicenseDetails licenseDetails)
            : base(id, name, resourceType, systemData, tags, location, provisioningState is null && tenantId is null && licenseType is null && licenseDetails is null ? default : new LicenseProperties(provisioningState, tenantId, licenseType, licenseDetails, additionalBinaryDataProperties: null), additionalBinaryDataProperties)
        {
        }

        internal static HybridComputeLicense FromData(HybridComputeLicenseData data)
        {
            if (data is null)
            {
                return null;
            }

            if (data is HybridComputeLicense license)
            {
                return license;
            }

            return new HybridComputeLicense(data.Id, data.Name, data.ResourceType, data.SystemData, additionalBinaryDataProperties: null, data.Tags, data.Location, data.ProvisioningState, data.TenantId, data.LicenseType, data.LicenseDetails);
        }

        internal HybridComputeLicenseData ToData() => this;
    }
}
