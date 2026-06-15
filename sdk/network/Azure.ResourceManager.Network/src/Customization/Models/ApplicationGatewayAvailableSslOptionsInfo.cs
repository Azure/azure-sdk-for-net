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

        internal ApplicationGatewayAvailableSslOptionsInfo(ResourceIdentifier id, string name, string type, AzureLocation? location, IDictionary<string, string> tags, IEnumerable<WritableSubResource> predefinedPolicies, ApplicationGatewaySslPolicyName? defaultPolicy, IEnumerable<ApplicationGatewaySslCipherSuite> availableCipherSuites, IEnumerable<ApplicationGatewaySslProtocol> availableProtocols)
            : base(id, name, type, location, tags, default)
        {
            PredefinedPolicies = new List<WritableSubResource>(predefinedPolicies ?? Array.Empty<WritableSubResource>());
            AvailableCipherSuites = new List<ApplicationGatewaySslCipherSuite>(availableCipherSuites ?? Array.Empty<ApplicationGatewaySslCipherSuite>());
            AvailableProtocols = new List<ApplicationGatewaySslProtocol>(availableProtocols ?? Array.Empty<ApplicationGatewaySslProtocol>());
            DefaultPolicy = defaultPolicy;
        }

        internal static ApplicationGatewayAvailableSslOptionsInfo FromData(global::Azure.ResourceManager.Network.ApplicationGatewayAvailableSslOptionsInfoData data, string subscriptionId = null)
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
            string type = data.Type ?? "Microsoft.Network/applicationGatewayAvailableSslOptions";
            return new ApplicationGatewayAvailableSslOptionsInfo(data.Id, name, type, data.Location, data.Tags, predefinedPolicies, data.DefaultPolicy, data.AvailableCipherSuites, data.AvailableProtocols);
        }

        /// <summary> The resource type. </summary>
        public ResourceType ResourceType => Type;

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

        ApplicationGatewayAvailableSslOptionsInfo IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ApplicationGatewayAvailableSslOptionsInfo();
        void IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        ApplicationGatewayAvailableSslOptionsInfo IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => new ApplicationGatewayAvailableSslOptionsInfo();
        string IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }
}
