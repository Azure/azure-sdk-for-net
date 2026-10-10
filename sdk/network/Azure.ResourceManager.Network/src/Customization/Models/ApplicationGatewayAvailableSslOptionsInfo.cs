// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    // Keep the released model in Models: only the replacement *Data resource type is generated.
    // The persistence adapters below preserve ResourceType, not the complete legacy payload.
    /// <summary> Compatibility type for available SSL options info. </summary>
    public partial class ApplicationGatewayAvailableSslOptionsInfo : NetworkTrackedResourceData, IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>, IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>
    {
        /// <summary> Initializes a new instance of <see cref="ApplicationGatewayAvailableSslOptionsInfo"/>. </summary>
        public ApplicationGatewayAvailableSslOptionsInfo()
        {
            PredefinedPolicies = new List<WritableSubResource>();
            AvailableCipherSuites = new List<ApplicationGatewaySslCipherSuite>();
            AvailableProtocols = new List<ApplicationGatewaySslProtocol>();
        }

        // Adapt the generated resource result to the released model using the base's native metadata storage.
        internal ApplicationGatewayAvailableSslOptionsInfo(ResourceIdentifier id, string name, ResourceType? resourceType, AzureLocation? location, IDictionary<string, string> tags, IEnumerable<WritableSubResource> predefinedPolicies, ApplicationGatewaySslPolicyName? defaultPolicy, IEnumerable<ApplicationGatewaySslCipherSuite> availableCipherSuites, IEnumerable<ApplicationGatewaySslProtocol> availableProtocols)
            : base(id, name, resourceType, location, tags, default)
        {
            PredefinedPolicies = new List<WritableSubResource>(predefinedPolicies ?? Array.Empty<WritableSubResource>());
            AvailableCipherSuites = new List<ApplicationGatewaySslCipherSuite>(availableCipherSuites ?? Array.Empty<ApplicationGatewaySslCipherSuite>());
            AvailableProtocols = new List<ApplicationGatewaySslProtocol>(availableProtocols ?? Array.Empty<ApplicationGatewaySslProtocol>());
            DefaultPolicy = defaultPolicy;
        }

        // Retain the legacy response shape and policy identifiers while preferring the service's typed metadata.
        internal static ApplicationGatewayAvailableSslOptionsInfo FromData(ApplicationGatewayAvailableSslOptionsInfoData data, string subscriptionId = null)
        {
            if (data is null)
            {
                return null;
            }

            var predefinedPolicies = new List<WritableSubResource>();
            foreach (var policy in data.PredefinedPolicies ?? Array.Empty<NetworkSubResource>())
            {
                string policyName = GetNameFromId(policy.Id);
                predefinedPolicies.Add(new WritableSubResource { Id = NetworkExtensions.CreateApplicationGatewaySslPredefinedPolicyIdentifier(subscriptionId, policyName) });
            }

            string name = data.Name ?? "default";
            ResourceType resourceType = data.ResourceType ?? new ResourceType("Microsoft.Network/applicationGatewayAvailableSslOptions");
            return new ApplicationGatewayAvailableSslOptionsInfo(data.Id, name, resourceType, data.Location, data.Tags, predefinedPolicies, data.DefaultPolicy, data.AvailableCipherSuites, data.AvailableProtocols);
        }

        // ApiCompat CP0002: 1.17.0 requires the non-nullable ResourceType.get, not the inherited nullable getter.
        // Read the base's native storage rather than duplicating metadata.
        /// <summary> The resource type. </summary>
        public new ResourceType ResourceType => base.ResourceType ?? default;

        private static string GetNameFromId(ResourceIdentifier id)
        {
            string value = id?.ToString();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            int slashIndex = value.LastIndexOf('/');
            return slashIndex >= 0 ? value.Substring(slashIndex + 1) : value;
        }

        /// <summary> Predefined policies. </summary>
        [WirePath("properties.predefinedPolicies")]
        public IList<WritableSubResource> PredefinedPolicies { get; }

        /// <summary> Default policy. </summary>
        [WirePath("properties.defaultPolicy")]
        public ApplicationGatewaySslPolicyName? DefaultPolicy { get; set; }

        /// <summary> Available cipher suites. </summary>
        [WirePath("properties.availableCipherSuites")]
        public IList<ApplicationGatewaySslCipherSuite> AvailableCipherSuites { get; }

        /// <summary> Available protocols. </summary>
        [WirePath("properties.availableProtocols")]
        public IList<ApplicationGatewaySslProtocol> AvailableProtocols { get; }

        // The legacy type has no generated reader; reuse the base reader to retain ResourceType.
        ApplicationGatewayAvailableSslOptionsInfo IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromMetadata(((IJsonModel<NetworkTrackedResourceData>)new NetworkTrackedResourceData()).Create(ref reader, options));

        // Call the base core directly: covariant interface delegation would re-enter this writer recursively.
        void IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            base.JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }
        // Reuse the generated base persistence reader; the legacy adapter currently restores only ResourceType.
        ApplicationGatewayAvailableSslOptionsInfo IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromMetadata(ModelReaderWriter.Read<NetworkTrackedResourceData>(data, options, AzureResourceManagerNetworkContext.Default));

        string IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        // Preserve native metadata persistence and the base writer's read-only wire visibility rules.
        BinaryData IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write<NetworkTrackedResourceData>(this, options, AzureResourceManagerNetworkContext.Default);

        // Transfer only the repaired ResourceType path; this is not full legacy-payload deserialization.
        private static ApplicationGatewayAvailableSslOptionsInfo FromMetadata(NetworkTrackedResourceData metadata)
        {
            if (metadata is null)
            {
                return null;
            }
            var result = new ApplicationGatewayAvailableSslOptionsInfo();
            ((NetworkTrackedResourceData)result).ResourceType = metadata.ResourceType;
            return result;
        }

        // Let the generated base serialize metadata and decide which fields belong in persisted versus wire JSON.
        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => base.JsonModelWriteCore(writer, options);
    }
}
