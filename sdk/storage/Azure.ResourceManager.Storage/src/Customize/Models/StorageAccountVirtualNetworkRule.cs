// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat (Compile Remove replacement): Replaces generated model to change Action
// property type from StorageAccountVirtualNetworkRuleAction to StorageAccountNetworkRuleAction,
// matching the prior GA unified action type. Could use @@alternateType in spec.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Virtual Network rule. </summary>
    public partial class StorageAccountVirtualNetworkRule
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Backward-compatible constructor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageAccountVirtualNetworkRule(ResourceIdentifier virtualNetworkResourceId) : this(virtualNetworkResourceId, default(StorageAccountVirtualNetworkRuleAction?), default, default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountVirtualNetworkRule"/>. </summary>
        /// <param name="virtualNetworkResourceId"> Resource ID of a subnet. </param>
        /// <param name="action"> The action of virtual network rule. </param>
        /// <param name="state"> Gets the state of virtual network rule. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountVirtualNetworkRule(ResourceIdentifier virtualNetworkResourceId, StorageAccountVirtualNetworkRuleAction? action, StorageAccountNetworkRuleState? state, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            VirtualNetworkResourceId = virtualNetworkResourceId;
            Action = action;
            State = state;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}. </summary>
        [WirePath("id")]
        public ResourceIdentifier VirtualNetworkResourceId { get; set; }

        /// <summary> The action of virtual network rule. </summary>
        [WirePath("action")]
        public StorageAccountNetworkRuleAction? Action { get; set; }

        /// <summary> Gets the state of virtual network rule. </summary>
        [WirePath("state")]
        public StorageAccountNetworkRuleState? State { get; set; }
    }
}
