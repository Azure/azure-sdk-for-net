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
    private BicepValue<StorageAccountNetworkRuleState> _state;

    // The generator omits writable VirtualNetworkResourceId because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the virtual network resource ID. </summary>
    [CodeGenMember("VirtualNetworkResourceId")]
    public BicepValue<ResourceIdentifier> VirtualNetworkResourceId
    {
        get { Initialize(); return _virtualNetworkResourceId; }
        set { Initialize(); _virtualNetworkResourceId.Assign(value); }
    }

    // The generator omits writable Action because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the network rule action. </summary>
    [CodeGenMember("Action")]
    public BicepValue<StorageAccountNetworkRuleAction> Action
    {
        get { Initialize(); return _action; }
        set { Initialize(); _action.Assign(value); }
    }

    // The Bicep schema now marks State as read-only; retain the shipped writable compatibility view.
    /// <summary> Gets or sets the state of the virtual network rule. </summary>
    [CodeGenMember("State")]
    public BicepValue<StorageAccountNetworkRuleState> State
    {
        get { Initialize(); return _state; }
        set { Initialize(); _state.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _virtualNetworkResourceId = DefineProperty<ResourceIdentifier>(nameof(VirtualNetworkResourceId), new string[] { "id" });
        _action = DefineProperty<StorageAccountNetworkRuleAction>(nameof(Action), new string[] { "action" });

        _state = DefineProperty<StorageAccountNetworkRuleState>(nameof(State), new string[] { "state" });
    }
}
