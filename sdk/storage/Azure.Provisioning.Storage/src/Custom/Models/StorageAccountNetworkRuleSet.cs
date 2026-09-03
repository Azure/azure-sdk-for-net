// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountNetworkRuleSet
{
    private BicepValue<StorageNetworkBypass> _bypass;
    private BicepList<StorageAccountResourceAccessRule> _resourceAccessRules;
    private BicepList<StorageAccountVirtualNetworkRule> _virtualNetworkRules;
    private BicepList<StorageAccountIPRule> _ipRules;
    private BicepValue<StorageNetworkDefaultAction> _defaultAction;

    // The generator omits writable Bypass because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the network bypass setting. </summary>
    [CodeGenMember("Bypass")]
    public BicepValue<StorageNetworkBypass> Bypass
    {
        get { Initialize(); return _bypass; }
        set { Initialize(); _bypass.Assign(value); }
    }

    // The generator omits writable ResourceAccessRules because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the resource access rules. </summary>
    [CodeGenMember("ResourceAccessRules")]
    public BicepList<StorageAccountResourceAccessRule> ResourceAccessRules
    {
        get { Initialize(); return _resourceAccessRules; }
        set { Initialize(); _resourceAccessRules.Assign(value); }
    }

    // The generator omits writable VirtualNetworkRules because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the virtual network rules. </summary>
    [CodeGenMember("VirtualNetworkRules")]
    public BicepList<StorageAccountVirtualNetworkRule> VirtualNetworkRules
    {
        get { Initialize(); return _virtualNetworkRules; }
        set { Initialize(); _virtualNetworkRules.Assign(value); }
    }

    // The generator omits writable IPRules because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the IP rules. </summary>
    [CodeGenMember("IPRules")]
    public BicepList<StorageAccountIPRule> IPRules
    {
        get { Initialize(); return _ipRules; }
        set { Initialize(); _ipRules.Assign(value); }
    }

    // The generator omits writable DefaultAction because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the default network action. </summary>
    [CodeGenMember("DefaultAction")]
    public BicepValue<StorageNetworkDefaultAction> DefaultAction
    {
        get { Initialize(); return _defaultAction; }
        set { Initialize(); _defaultAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _bypass = DefineProperty<StorageNetworkBypass>(nameof(Bypass), new string[] { "bypass" });
        _resourceAccessRules = DefineListProperty<StorageAccountResourceAccessRule>(nameof(ResourceAccessRules), new string[] { "resourceAccessRules" });
        _virtualNetworkRules = DefineListProperty<StorageAccountVirtualNetworkRule>(nameof(VirtualNetworkRules), new string[] { "virtualNetworkRules" });
        _ipRules = DefineListProperty<StorageAccountIPRule>(nameof(IPRules), new string[] { "ipRules" });
        _defaultAction = DefineProperty<StorageNetworkDefaultAction>(nameof(DefaultAction), new string[] { "defaultAction" });
    }
}
