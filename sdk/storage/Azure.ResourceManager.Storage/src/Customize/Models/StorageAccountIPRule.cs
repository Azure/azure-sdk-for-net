// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat (Compile Remove replacement): Replaces generated model to use unified
// StorageAccountNetworkRuleAction type for Action property, matching prior GA surface.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> IP rule with specific IP or IP range in CIDR format. </summary>
    public partial class StorageAccountIPRule
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="StorageAccountIPRule"/>. </summary>
        /// <param name="ipAddressOrRange"> Specifies the IP or IP range in CIDR format. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ipAddressOrRange"/> is null. </exception>
        public StorageAccountIPRule(string ipAddressOrRange)
        {
            Argument.AssertNotNull(ipAddressOrRange, nameof(ipAddressOrRange));

            IPAddressOrRange = ipAddressOrRange;
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountIPRule"/>. </summary>
        /// <param name="ipAddressOrRange"> Specifies the IP or IP range in CIDR format. </param>
        /// <param name="action"> The action of IP ACL rule. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountIPRule(string ipAddressOrRange, StorageAccountIPRuleAction? action, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            IPAddressOrRange = ipAddressOrRange;
            Action = action;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Specifies the IP or IP range in CIDR format. </summary>
        [WirePath("value")]
        public string IPAddressOrRange { get; set; }

        /// <summary> The action of IP ACL rule. </summary>
        [WirePath("action")]
        public StorageAccountNetworkRuleAction? Action { get; set; }
    }
}
