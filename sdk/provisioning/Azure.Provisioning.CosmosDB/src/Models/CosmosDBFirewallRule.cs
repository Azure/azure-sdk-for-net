// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// CosmosDBFirewallRule.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class CosmosDBFirewallRule : ProvisionableResource
{
    /// <summary>
    /// The name of the mongo cluster firewall rule.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// The end IP address of the mongo cluster firewall rule. Must be IPv4
    /// format.
    /// </summary>
    public BicepValue<string> EndIPAddress
    {
        get { Initialize(); return _endIPAddress!; }
        set { Initialize(); _endIPAddress!.Assign(value); }
    }
    private BicepValue<string>? _endIPAddress;

    /// <summary>
    /// The start IP address of the mongo cluster firewall rule. Must be IPv4
    /// format.
    /// </summary>
    public BicepValue<string> StartIPAddress
    {
        get { Initialize(); return _startIPAddress!; }
        set { Initialize(); _startIPAddress!.Assign(value); }
    }
    private BicepValue<string>? _startIPAddress;

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// The provisioning state of the firewall rule.
    /// </summary>
    public BicepValue<CosmosDBProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<CosmosDBProvisioningState>? _provisioningState;

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// Gets or sets a reference to the parent MongoCluster.
    /// </summary>
    public MongoCluster? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }
    private ResourceReference<MongoCluster>? _parent;

    /// <summary>
    /// Creates a new CosmosDBFirewallRule.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CosmosDBFirewallRule resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CosmosDBFirewallRule.</param>
    public CosmosDBFirewallRule(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/mongoClusters/firewallRules", resourceVersion ?? "2024-07-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CosmosDBFirewallRule.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _endIPAddress = DefineProperty<string>("EndIPAddress", ["properties", "endIpAddress"], isRequired: true);
        _startIPAddress = DefineProperty<string>("StartIPAddress", ["properties", "startIpAddress"], isRequired: true);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _provisioningState = DefineProperty<CosmosDBProvisioningState>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _parent = DefineResource<MongoCluster>("Parent", ["parent"], isRequired: true);
    }

    /// <summary>
    /// Supported CosmosDBFirewallRule resource versions.
    /// </summary>
    public static class ResourceVersions
    {
        /// <summary>
        /// 2024-07-01.
        /// </summary>
        public static readonly string V2024_07_01 = "2024-07-01";
    }

    /// <summary>
    /// Creates a reference to an existing CosmosDBFirewallRule.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CosmosDBFirewallRule resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CosmosDBFirewallRule.</param>
    /// <returns>The existing CosmosDBFirewallRule resource.</returns>
    public static CosmosDBFirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
