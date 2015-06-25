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
    public partial class SecurityRule : SubResource
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
        /// Gets or sets a description for this rule. Restricted to 140 chars.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Network protocol this rule applies to. Can be Tcp,
        /// Udp or All(*). Possible values for this property include: 'Tcp',
        /// 'Udp', '*'
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public SecurityRuleProtocol? Protocol { get; set; }

        /// <summary>
        /// Gets or sets Source Port or Range. Integer or range between 0 and
        /// 65535. Asterix â€œ*â€ can also be used to match all ports.
        /// </summary>
        [JsonProperty(PropertyName = "sourcePortRange")]
        public string SourcePortRange { get; set; }

        /// <summary>
        /// Gets or sets Destination Port or Range. Integer or range between 0
        /// and 65535. Asterix â€œ*â€ can also be used to match all ports.
        /// </summary>
        [JsonProperty(PropertyName = "destinationPortRange")]
        public string DestinationPortRange { get; set; }

        /// <summary>
        /// Gets or sets source address prefix. CIDR or source IP range.
        /// Asterix â€œ*â€ can also be used to match all source IPs. Default
        /// tags such as â€˜VirtualNetworkâ€™, â€˜AzureLoadBalancerâ€™ and
        /// â€˜Internetâ€™ can also be used. If this is an ingress rule,
        /// specifies where network traffic originates from.
        /// </summary>
        [JsonProperty(PropertyName = "sourceAddressPrefix")]
        public string SourceAddressPrefix { get; set; }

        /// <summary>
        /// Gets or sets destination address prefix. CIDR or source IP range.
        /// Asterix â€œ*â€ can also be used to match all source IPs. Default
        /// tags such as â€˜VirtualNetworkâ€™, â€˜AzureLoadBalancerâ€™ and
        /// â€˜Internetâ€™ can also be used.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAddressPrefix")]
        public string DestinationAddressPrefix { get; set; }

        /// <summary>
        /// Gets or sets network traffic is allowed or denied. Possible values
        /// are â€œAllowâ€ and â€œDenyâ€. Possible values for this property
        /// include: 'Allow', 'Deny'
        /// </summary>
        [JsonProperty(PropertyName = "access")]
        public SecurityRuleAccess? Access { get; set; }

        /// <summary>
        /// Gets or sets the priority of the rule. The value can be between
        /// 100 and 4096. The priority number must be unique for each rule in
        /// the collection. The lower the priority number, the higher the
        /// priority of the rule.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets the direction of the rule.InBound or Outbound. The
        /// direction specifies if rule will be evaluated on incoming or
        /// outcoming traffic. Possible values for this property include:
        /// 'Inbound', 'Outbound'
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public SecurityRuleDirection? Direction { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the PublicIP resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
