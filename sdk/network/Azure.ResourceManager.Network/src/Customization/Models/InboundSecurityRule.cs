// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> NVA Inbound Security Rule resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class InboundSecurityRule : NetworkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="InboundSecurityRule"/>. </summary>
        public InboundSecurityRule()
        {
            Rules = new ChangeTrackingList<InboundSecurityRules>();
        }

        /// <summary> Initializes a new instance of <see cref="InboundSecurityRule"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="ruleType"> Rule Type. This should be either AutoExpire or Permanent. Auto Expire Rule only creates NSG rules. Permanent Rule creates NSG rule and SLB LB Rule. </param>
        /// <param name="rules"> List of allowed rules. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        internal InboundSecurityRule(ResourceIdentifier id, string name, ResourceType? resourceType, IDictionary<string, BinaryData> serializedAdditionalRawData, ETag? etag, InboundSecurityRuleType? ruleType, IList<InboundSecurityRules> rules, NetworkProvisioningState? provisioningState) : base(id, name, resourceType, serializedAdditionalRawData)
        {
            ETag = etag;
            RuleType = ruleType;
            Rules = rules;
            ProvisioningState = provisioningState;
        }

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public ETag? ETag { get; }
        /// <summary> Rule Type. This should be either AutoExpire or Permanent. Auto Expire Rule only creates NSG rules. Permanent Rule creates NSG rule and SLB LB Rule. </summary>
        public InboundSecurityRuleType? RuleType { get; set; }
        /// <summary> List of allowed rules. </summary>
        public IList<InboundSecurityRules> Rules { get; }
        /// <summary> The provisioning state of the resource. </summary>
        public NetworkProvisioningState? ProvisioningState { get; }

        /// <summary> Implicitly converts an <see cref="InboundSecurityRule"/> to an <see cref="InboundSecurityRuleData"/>. </summary>
        /// <param name="r"> The <see cref="InboundSecurityRule"/> to convert. </param>
        /// <returns> The converted <see cref="InboundSecurityRuleData"/>. </returns>
        public static implicit operator InboundSecurityRuleData(InboundSecurityRule r) => new InboundSecurityRuleData(r.Id, r.Name, r.ResourceType, new Dictionary<string, BinaryData>(), r.ETag, r.RuleType, r.Rules, r.ProvisioningState);
    }
}
