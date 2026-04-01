// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventHubs.Models
{
    /*
     * Network Security Perimeter related configurations of a given namespace.
     * This type is preserved for backward compatibility with the 1.2.x API surface.
     * New code should use <see cref="EventHubsNetworkSecurityPerimeterConfigurationData"/> instead.
     */
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class EventHubsNetworkSecurityPerimeterConfiguration : ResourceData,
        IJsonModel<EventHubsNetworkSecurityPerimeterConfiguration>,
        IPersistableModel<EventHubsNetworkSecurityPerimeterConfiguration>
    {
        private readonly EventHubsNetworkSecurityPerimeterConfigurationData _inner;

        /// <summary> Initializes a new instance of <see cref="EventHubsNetworkSecurityPerimeterConfiguration"/>. </summary>
        public EventHubsNetworkSecurityPerimeterConfiguration()
        {
            _inner = new EventHubsNetworkSecurityPerimeterConfigurationData();
        }

        internal EventHubsNetworkSecurityPerimeterConfiguration(EventHubsNetworkSecurityPerimeterConfigurationData data)
            : base(data?.Id, data?.Name, data?.ResourceType ?? default, data?.SystemData)
        {
            _inner = data ?? new EventHubsNetworkSecurityPerimeterConfigurationData();
        }

        /// <summary> The geo-location where the resource lives. </summary>
        [WirePath("location")]
        public AzureLocation? Location => _inner.Location;

        /// <summary> Provisioning state of NetworkSecurityPerimeter configuration propagation. </summary>
        [WirePath("properties.provisioningState")]
        public EventHubsNetworkSecurityPerimeterConfigurationProvisioningState? ProvisioningState
        {
            get => _inner.ProvisioningState;
            set { }
        }

        /// <summary> List of Provisioning Issues if any. </summary>
        [WirePath("properties.provisioningIssues")]
        public IList<EventHubsProvisioningIssue> ProvisioningIssues => _inner.ProvisioningIssues as IList<EventHubsProvisioningIssue> ?? new List<EventHubsProvisioningIssue>(_inner.ProvisioningIssues ?? Array.Empty<EventHubsProvisioningIssue>());

        /// <summary> NetworkSecurityPerimeter related information. </summary>
        [WirePath("properties.networkSecurityPerimeter")]
        public EventHubsNetworkSecurityPerimeter NetworkSecurityPerimeter => _inner.NetworkSecurityPerimeter;

        /// <summary> Information about resource association. </summary>
        [WirePath("properties.resourceAssociation")]
        public EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation ResourceAssociation => _inner.ResourceAssociation;

        /// <summary> Information about current network profile. </summary>
        [WirePath("properties.profile")]
        public EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile Profile => _inner.Profile;

        /// <summary> True if the EventHub namespace is backed by another Azure resource and not visible to end users. </summary>
        [WirePath("properties.isBackingResource")]
        public bool? IsBackingResource => _inner.IsBackingResource;

        /// <summary> Indicates that the NSP controls related to backing association are only applicable to a specific feature in backing resource's data plane. </summary>
        [WirePath("properties.applicableFeatures")]
        public IReadOnlyList<string> ApplicableFeatures => _inner.ApplicableFeatures;

        /// <summary> Source Resource Association name. </summary>
        [WirePath("properties.parentAssociationName")]
        public string ParentAssociationName => _inner.ParentAssociationName;

        /// <summary> ARM Id of source resource. </summary>
        [WirePath("properties.sourceResourceId")]
        public ResourceIdentifier SourceResourceId => _inner.SourceResourceId;

        internal static EventHubsNetworkSecurityPerimeterConfiguration FromData(EventHubsNetworkSecurityPerimeterConfigurationData data)
            => data == null ? null : new EventHubsNetworkSecurityPerimeterConfiguration(data);

        EventHubsNetworkSecurityPerimeterConfiguration IJsonModel<EventHubsNetworkSecurityPerimeterConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var data = ModelReaderWriter.Read<EventHubsNetworkSecurityPerimeterConfigurationData>(
                BinaryData.FromString(doc.RootElement.GetRawText()), options, AzureResourceManagerEventHubsContext.Default);
            return new EventHubsNetworkSecurityPerimeterConfiguration(data);
        }

        void IJsonModel<EventHubsNetworkSecurityPerimeterConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<EventHubsNetworkSecurityPerimeterConfigurationData>)_inner).Write(writer, options);
        }

        EventHubsNetworkSecurityPerimeterConfiguration IPersistableModel<EventHubsNetworkSecurityPerimeterConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var innerData = ModelReaderWriter.Read<EventHubsNetworkSecurityPerimeterConfigurationData>(
                data, options, AzureResourceManagerEventHubsContext.Default);
            return new EventHubsNetworkSecurityPerimeterConfiguration(innerData);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EventHubsNetworkSecurityPerimeterConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventHubsNetworkSecurityPerimeterConfiguration)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (options.Format != "W" && Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (Optional.IsCollectionDefined(ProvisioningIssues))
            {
                writer.WritePropertyName("provisioningIssues"u8);
                writer.WriteStartArray();
                foreach (var item in ProvisioningIssues)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(NetworkSecurityPerimeter))
            {
                writer.WritePropertyName("networkSecurityPerimeter"u8);
                writer.WriteObjectValue(NetworkSecurityPerimeter, options);
            }
            if (options.Format != "W" && Optional.IsDefined(ResourceAssociation))
            {
                writer.WritePropertyName("resourceAssociation"u8);
                writer.WriteObjectValue(ResourceAssociation, options);
            }
            if (options.Format != "W" && Optional.IsDefined(Profile))
            {
                writer.WritePropertyName("profile"u8);
                writer.WriteObjectValue(Profile, options);
            }
            if (options.Format != "W" && Optional.IsDefined(IsBackingResource))
            {
                writer.WritePropertyName("isBackingResource"u8);
                writer.WriteBooleanValue(IsBackingResource.Value);
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(ApplicableFeatures))
            {
                writer.WritePropertyName("applicableFeatures"u8);
                writer.WriteStartArray();
                foreach (var item in ApplicableFeatures)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(ParentAssociationName))
            {
                writer.WritePropertyName("parentAssociationName"u8);
                writer.WriteStringValue(ParentAssociationName);
            }
            if (options.Format != "W" && Optional.IsDefined(SourceResourceId))
            {
                writer.WritePropertyName("sourceResourceId"u8);
                writer.WriteStringValue(SourceResourceId);
            }
            writer.WriteEndObject();
        }

        string IPersistableModel<EventHubsNetworkSecurityPerimeterConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<EventHubsNetworkSecurityPerimeterConfiguration>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write((object)_inner, options, AzureResourceManagerEventHubsContext.Default);
        }
    }
}
