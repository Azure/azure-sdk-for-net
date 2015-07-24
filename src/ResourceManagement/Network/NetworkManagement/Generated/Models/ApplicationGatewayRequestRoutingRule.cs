namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Request routing rule of application gateway
    /// </summary>
    public partial class ApplicationGatewayRequestRoutingRule : SubResource
    {
        /// <summary>
        /// Gets name of the resource that is unique within a resource group.
        /// This name can be used to access the resource
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is
        /// updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the rule type. Possible values for this property
        /// include: 'Basic'
        /// </summary>
        [JsonProperty(PropertyName = "properties.ruleType")]
        public ApplicationGatewayRequestRoutingRuleType? RuleType { get; set; }

        /// <summary>
        /// Gets or sets backend address pool resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }

        /// <summary>
        /// Gets or sets frontend port resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendHttpSettings")]
        public SubResource BackendHttpSettings { get; set; }

        /// <summary>
        /// Gets or sets http listener resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "properties.httpListener")]
        public SubResource HttpListener { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the request routing rule
        /// resource Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

    }
}
