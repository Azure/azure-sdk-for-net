// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct StorageAccountVirtualNetworkRuleAction
    {
        /// <summary> Implicit conversion to backward-compatible <see cref="StorageAccountNetworkRuleAction"/>. </summary>
        public static implicit operator StorageAccountNetworkRuleAction(StorageAccountVirtualNetworkRuleAction value) => new StorageAccountNetworkRuleAction(value.ToString());
    }
}
