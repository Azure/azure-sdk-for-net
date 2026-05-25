// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Compatibility shim for the AutoRest-generated patch model preserved during TypeSpec migration.
    /// <summary> The model for updating a Hybrid Compute license profile. </summary>
    public partial class HybridComputeLicenseProfilePatch : HybridComputeResourceUpdate, IJsonModel<HybridComputeLicenseProfilePatch>
    {
        /// <summary> Initializes a new instance of <see cref="HybridComputeLicenseProfilePatch"/>. </summary>
        public HybridComputeLicenseProfilePatch()
        {
        }

        internal HybridComputeLicenseProfilePatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, LicenseProfileUpdateProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> Describe the Update properties of a license profile. </summary>
        [WirePath("properties")]
        internal LicenseProfileUpdateProperties Properties { get; set; }

        /// <summary> Specifies if this machine is licensed as part of a Software Assurance agreement. </summary>
        [WirePath("properties.softwareAssuranceCustomer")]
        public bool? SoftwareAssuranceCustomer
        {
            get => Properties is null ? default : Properties.SoftwareAssuranceCustomer;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.SoftwareAssuranceCustomer = value;
            }
        }

        /// <summary> The resource id of the license. </summary>
        [WirePath("properties.assignedLicense")]
        public string AssignedLicense
        {
            get => Properties is null ? default : Properties.AssignedLicense;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.AssignedLicense = value;
            }
        }

        /// <summary> Indicates the subscription status of the product. </summary>
        [WirePath("properties.subscriptionStatus")]
        public LicenseProfileSubscriptionStatusUpdate? SubscriptionStatus
        {
            get => Properties is null ? default : Properties.SubscriptionStatus;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.SubscriptionStatus = value;
            }
        }

        /// <summary> Indicates the product type of the license. </summary>
        [WirePath("properties.productType")]
        public LicenseProfileProductType? ProductType
        {
            get => Properties is null ? default : Properties.ProductType;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.ProductType = value;
            }
        }

        /// <summary> The list of product feature updates. </summary>
        [WirePath("properties.productFeatures")]
        public IList<HybridComputeProductFeatureUpdate> ProductFeatures
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                return Properties.ProductFeatures;
            }
        }

        internal HybridComputeLicenseProfileUpdate ToUpdate()
            => new HybridComputeLicenseProfileUpdate(Tags, _additionalBinaryDataProperties, Properties);

        internal static RequestContent ToRequestContent(HybridComputeLicenseProfilePatch patch)
        {
            if (patch == null)
            {
                return null;
            }
            return RequestContent.Create(patch, ModelSerializationExtensions.WireOptions);
        }

        void IJsonModel<HybridComputeLicenseProfilePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HybridComputeLicenseProfilePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HybridComputeLicenseProfilePatch)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
        }

        HybridComputeLicenseProfilePatch IJsonModel<HybridComputeLicenseProfilePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HybridComputeLicenseProfilePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HybridComputeLicenseProfilePatch)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHybridComputeLicenseProfilePatch(document.RootElement, options);
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override HybridComputeResourceUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<HybridComputeLicenseProfilePatch>)this).Create(ref reader, options);

        internal static HybridComputeLicenseProfilePatch DeserializeHybridComputeLicenseProfilePatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            LicenseProfileUpdateProperties properties = default;
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (JsonProperty prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    tags = dictionary;
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = LicenseProfileUpdateProperties.DeserializeLicenseProfileUpdateProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new HybridComputeLicenseProfilePatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override HybridComputeResourceUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HybridComputeLicenseProfilePatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeHybridComputeLicenseProfilePatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(HybridComputeLicenseProfilePatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<HybridComputeLicenseProfilePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(HybridComputeLicenseProfilePatch)} does not support writing '{options.Format}' format.");
            }

            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ((IJsonModel<HybridComputeLicenseProfilePatch>)this).Write(writer, options);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<HybridComputeLicenseProfilePatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        HybridComputeLicenseProfilePatch IPersistableModel<HybridComputeLicenseProfilePatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (HybridComputeLicenseProfilePatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<HybridComputeLicenseProfilePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
