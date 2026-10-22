// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    // Keep the released model in Models: only the replacement *Data resource type is generated.
    // The persistence adapters in the serialization partial preserve ResourceType, not the complete legacy payload.
    /// <summary> Compatibility type for available SSL options info. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This model is deprecated and it will be removed in a future version. Please use ApplicationGatewayAvailableSslOptionsInfoData instead.")]
    public partial class ApplicationGatewayAvailableSslOptionsInfo : NetworkTrackedResourceData
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

        // This legacy model has no generated partial; its adapter converts native policy IDs to released resource references.
        /// <summary> Predefined policies. </summary>
        [WirePath("properties.predefinedPolicies")]
        public IList<WritableSubResource> PredefinedPolicies { get; }

        // The generated DefaultPolicy belongs to the replacement *Data model, not this retained legacy contract.
        /// <summary> Default policy. </summary>
        [WirePath("properties.defaultPolicy")]
        public ApplicationGatewaySslPolicyName? DefaultPolicy { get; set; }

        // Keep the legacy factory/adapter's cipher suite storage; only the replacement *Data model is generated.
        /// <summary> Available cipher suites. </summary>
        [WirePath("properties.availableCipherSuites")]
        public IList<ApplicationGatewaySslCipherSuite> AvailableCipherSuites { get; }

        // Keep the legacy factory/adapter's protocol storage; only the replacement *Data model is generated.
        /// <summary> Available protocols. </summary>
        [WirePath("properties.availableProtocols")]
        public IList<ApplicationGatewaySslProtocol> AvailableProtocols { get; }
    }
}
