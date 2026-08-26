// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountVirtualNetworkRule
{
    private BicepValue<ResourceIdentifier> _virtualNetworkResourceId;
    private BicepValue<StorageAccountNetworkRuleAction> _action;

    /// <summary> Gets or sets the virtual network resource ID. </summary>
    [CodeGenMember("VirtualNetworkResourceId")]
    public BicepValue<ResourceIdentifier> VirtualNetworkResourceId
    {
        get { Initialize(); return _virtualNetworkResourceId; }
        set { Initialize(); _virtualNetworkResourceId.Assign(value); }
    }

    /// <summary> Gets or sets the network rule action. </summary>
    [CodeGenMember("Action")]
    public BicepValue<StorageAccountNetworkRuleAction> Action
    {
        get { Initialize(); return _action; }
        set { Initialize(); _action.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _virtualNetworkResourceId = DefineProperty<ResourceIdentifier>(nameof(VirtualNetworkResourceId), new string[] { "id" });
        _action = DefineProperty<StorageAccountNetworkRuleAction>(nameof(Action), new string[] { "action" });
    }
}
