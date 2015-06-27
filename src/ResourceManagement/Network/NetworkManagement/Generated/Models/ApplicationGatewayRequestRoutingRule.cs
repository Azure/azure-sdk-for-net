namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
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
        [JsonProperty(PropertyName = "ruleType")]
        public ApplicationGatewayRequestRoutingRuleType? RuleType { get; set; }

        /// <summary>
        /// Gets or sets backend address pool resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }

        /// <summary>
        /// Gets or sets frontend port resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "backendHttpSettings")]
        public SubResource BackendHttpSettings { get; set; }

        /// <summary>
        /// Gets or sets http listener resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "httpListener")]
        public SubResource HttpListener { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.BackendAddressPool != null)
            {
                this.BackendAddressPool.Validate();
            }
            if (this.BackendHttpSettings != null)
            {
                this.BackendHttpSettings.Validate();
            }
            if (this.HttpListener != null)
            {
                this.HttpListener.Validate();
            }
        }
    }
}
