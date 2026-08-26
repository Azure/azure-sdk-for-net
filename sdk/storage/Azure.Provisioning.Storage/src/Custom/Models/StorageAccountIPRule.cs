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

    /// <summary> Gets or sets the IP address or range. </summary>
    [CodeGenMember("IPAddressOrRange")]
    public BicepValue<string> IPAddressOrRange
    {
        get { Initialize(); return _ipAddressOrRange; }
        set { Initialize(); _ipAddressOrRange.Assign(value); }
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
        _ipAddressOrRange = DefineProperty<string>(nameof(IPAddressOrRange), new string[] { "value" });
        _action = DefineProperty<StorageAccountNetworkRuleAction>(nameof(Action), new string[] { "action" });
    }
}
