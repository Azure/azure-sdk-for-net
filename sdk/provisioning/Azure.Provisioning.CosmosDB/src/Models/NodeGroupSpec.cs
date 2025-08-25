// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// Specification for a node group.
/// </summary>
public partial class NodeGroupSpec : ProvisionableConstruct
{
    /// <summary>
    /// The node type deployed in the node group.
    /// </summary>
    public BicepValue<NodeKind> Kind
    {
        get { Initialize(); return _kind!; }
        set { Initialize(); _kind!.Assign(value); }
    }
    private BicepValue<NodeKind>? _kind;

    /// <summary>
    /// The number of nodes in the node group.
    /// </summary>
    public BicepValue<int> NodeCount
    {
        get { Initialize(); return _nodeCount!; }
        set { Initialize(); _nodeCount!.Assign(value); }
    }
    private BicepValue<int>? _nodeCount;

    /// <summary>
    /// The resource sku for the node group. This defines the size of CPU and
    /// memory that is provisioned for each node. Example values:
    /// &apos;M30&apos;, &apos;M40&apos;.
    /// </summary>
    public BicepValue<string> Sku
    {
        get { Initialize(); return _sku!; }
        set { Initialize(); _sku!.Assign(value); }
    }
    private BicepValue<string>? _sku;

    /// <summary>
    /// The disk storage size for the node group in GB. Example values: 128,
    /// 256, 512, 1024.
    /// </summary>
    public BicepValue<long> DiskSizeInGB
    {
        get { Initialize(); return _diskSizeInGB!; }
        set { Initialize(); _diskSizeInGB!.Assign(value); }
    }
    private BicepValue<long>? _diskSizeInGB;

    /// <summary>
    /// Whether high availability is enabled on the node group.
    /// </summary>
    public BicepValue<bool> EnableHa
    {
        get { Initialize(); return _enableHa!; }
        set { Initialize(); _enableHa!.Assign(value); }
    }
    private BicepValue<bool>? _enableHa;

    /// <summary>
    /// Creates a new NodeGroupSpec.
    /// </summary>
    public NodeGroupSpec()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of NodeGroupSpec.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _kind = DefineProperty<NodeKind>("Kind", ["kind"]);
        _nodeCount = DefineProperty<int>("NodeCount", ["nodeCount"]);
        _sku = DefineProperty<string>("Sku", ["sku"]);
        _diskSizeInGB = DefineProperty<long>("DiskSizeInGB", ["diskSizeGB"]);
        _enableHa = DefineProperty<bool>("EnableHa", ["enableHa"]);
    }
}
