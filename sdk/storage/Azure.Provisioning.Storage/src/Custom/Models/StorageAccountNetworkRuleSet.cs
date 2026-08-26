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

    /// <summary> Gets or sets the network bypass setting. </summary>
    [CodeGenMember("Bypass")]
    public BicepValue<StorageNetworkBypass> Bypass
    {
        get { Initialize(); return _bypass; }
        set { Initialize(); _bypass.Assign(value); }
    }

    /// <summary> Gets or sets the resource access rules. </summary>
    [CodeGenMember("ResourceAccessRules")]
    public BicepList<StorageAccountResourceAccessRule> ResourceAccessRules
    {
        get { Initialize(); return _resourceAccessRules; }
        set { Initialize(); _resourceAccessRules.Assign(value); }
    }

    /// <summary> Gets or sets the virtual network rules. </summary>
    [CodeGenMember("VirtualNetworkRules")]
    public BicepList<StorageAccountVirtualNetworkRule> VirtualNetworkRules
    {
        get { Initialize(); return _virtualNetworkRules; }
        set { Initialize(); _virtualNetworkRules.Assign(value); }
    }

    /// <summary> Gets or sets the IP rules. </summary>
    [CodeGenMember("IPRules")]
    public BicepList<StorageAccountIPRule> IPRules
    {
        get { Initialize(); return _ipRules; }
        set { Initialize(); _ipRules.Assign(value); }
    }

    /// <summary> Gets or sets the default network action. </summary>
    [CodeGenMember("DefaultAction")]
    public BicepValue<StorageNetworkDefaultAction> DefaultAction
    {
        get { Initialize(); return _defaultAction; }
        set { Initialize(); _defaultAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _bypass = DefineProperty<StorageNetworkBypass>(nameof(Bypass), new string[] { "bypass" });
        _resourceAccessRules = DefineListProperty<StorageAccountResourceAccessRule>(nameof(ResourceAccessRules), new string[] { "resourceAccessRules" });
        _virtualNetworkRules = DefineListProperty<StorageAccountVirtualNetworkRule>(nameof(VirtualNetworkRules), new string[] { "virtualNetworkRules" });
        _ipRules = DefineListProperty<StorageAccountIPRule>(nameof(IPRules), new string[] { "ipRules" });
        _defaultAction = DefineProperty<StorageNetworkDefaultAction>(nameof(DefaultAction), new string[] { "defaultAction" });
    }
}
