// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds implicit conversion from StorageAccountIPRuleAction to
// StorageAccountNetworkRuleAction to support the unified action type from prior GA.

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct StorageAccountIPRuleAction
    {
        /// <summary> Implicit conversion to backward-compatible <see cref="StorageAccountNetworkRuleAction"/>. </summary>
        public static implicit operator StorageAccountNetworkRuleAction(StorageAccountIPRuleAction value) => new StorageAccountNetworkRuleAction(value.ToString());
    }
}
