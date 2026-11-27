// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountIPRule
{
    private BicepValue<string> _ipAddressOrRange;
    private BicepValue<StorageAccountNetworkRuleAction> _action;

    // The generator omits writable IPAddressOrRange because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the IP address or range. </summary>
    [CodeGenMember("IPAddressOrRange")]
    public BicepValue<string> IPAddressOrRange
    {
        get { Initialize(); return _ipAddressOrRange; }
        set { Initialize(); _ipAddressOrRange.Assign(value); }
    }

    // The generator omits writable Action because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the network rule action. </summary>
    [CodeGenMember("Action")]
    public BicepValue<StorageAccountNetworkRuleAction> Action
    {
        get { Initialize(); return _action; }
        set { Initialize(); _action.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _ipAddressOrRange = DefineProperty<string>(nameof(IPAddressOrRange), new string[] { "value" });
        _action = DefineProperty<StorageAccountNetworkRuleAction>(nameof(Action), new string[] { "action" });
    }
}
