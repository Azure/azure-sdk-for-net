// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridCompute.Models
{
    /// <summary> Describes a license in a hybrid machine. </summary>
    public partial class HybridComputeLicense : TrackedResourceData, IJsonModel<HybridComputeLicense>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="HybridComputeLicense"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public HybridComputeLicense(AzureLocation location) : base(location)
        {
        }

        internal HybridComputeLicense(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, IDictionary<string, string> tags, AzureLocation location, LicenseProperties properties)
            : base(id, name, resourceType, systemData, tags, location)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
        }

        [WirePath("properties")]
        internal LicenseProperties Properties { get; set; }

        /// <summary> The provisioning state, which only appears in the response. </summary>
        [WirePath("properties.provisioningState")]
        public HybridComputeProvisioningState? ProvisioningState => Properties is null ? default : Properties.ProvisioningState;

        /// <summary> Describes the tenant id. </summary>
        [WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => Properties is null ? default : Properties.TenantId;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProperties();
                }
                Properties.TenantId = value;
            }
        }

        /// <summary> The type of the license resource. </summary>
        [WirePath("properties.licenseType")]
        public HybridComputeLicenseType? LicenseType
        {
            get => Properties is null ? default : Properties.LicenseType;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProperties();
                }
                Properties.LicenseType = value;
            }
        }

        /// <summary> Describes the properties of a License. </summary>
        [WirePath("properties.licenseDetails")]
        public HybridComputeLicenseDetails LicenseDetails
        {
            get => Properties is null ? default : Properties.LicenseDetails;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProperties();
                }
                Properties.LicenseDetails = value;
            }
        }

        internal static HybridComputeLicense FromData(Azure.ResourceManager.HybridCompute.HybridComputeLicenseData data)
        {
            if (data is null)
            {
                return null;
            }

            LicenseProperties properties = data.ProvisioningState is null && data.TenantId is null && data.LicenseType is null && data.LicenseDetails is null
                ? default
                : new LicenseProperties(data.ProvisioningState, data.TenantId, data.LicenseType, data.LicenseDetails, additionalBinaryDataProperties: null);

            return new HybridComputeLicense(data.Id, data.Name, data.ResourceType, data.SystemData, additionalBinaryDataProperties: null, data.Tags, data.Location, properties);
        }

        internal static HybridComputeLicense DeserializeHybridComputeLicense(JsonElement element, ModelReaderWriterOptions options)
            => FromData(Azure.ResourceManager.HybridCompute.HybridComputeLicenseData.DeserializeHybridComputeLicenseData(element, options));

        internal Azure.ResourceManager.HybridCompute.HybridComputeLicenseData ToData()
            => new Azure.ResourceManager.HybridCompute.HybridComputeLicenseData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Tags, Location, Properties);

        void IJsonModel<HybridComputeLicense>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeLicenseData>)ToData()).Write(writer, options);

        HybridComputeLicense IJsonModel<HybridComputeLicense>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            Azure.ResourceManager.HybridCompute.HybridComputeLicenseData data = Azure.ResourceManager.HybridCompute.HybridComputeLicenseData.DeserializeHybridComputeLicenseData(JsonDocument.ParseValue(ref reader).RootElement, options);
            return FromData(data);
        }

        BinaryData IPersistableModel<HybridComputeLicense>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(ToData(), options, AzureResourceManagerHybridComputeContext.Default);

        HybridComputeLicense IPersistableModel<HybridComputeLicense>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromData(ModelReaderWriter.Read<Azure.ResourceManager.HybridCompute.HybridComputeLicenseData>(data, options, AzureResourceManagerHybridComputeContext.Default));

        string IPersistableModel<HybridComputeLicense>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
