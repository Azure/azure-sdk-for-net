// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// An SRV record.
/// </summary>
public partial class DnsSrvRecordInfo : ProvisionableConstruct
{
    /// <summary> The priority value for this SRV record. </summary>
    public BicepValue<int> Priority
    {
        get { Initialize(); return _priority!; }
        set { Initialize(); _priority!.Assign(value); }
    }
    private BicepValue<int>? _priority;

    /// <summary> The weight value for this SRV record. </summary>
    public BicepValue<int> Weight
    {
        get { Initialize(); return _weight!; }
        set { Initialize(); _weight!.Assign(value); }
    }
    private BicepValue<int>? _weight;

    /// <summary> The port value for this SRV record. </summary>
    public BicepValue<int> Port
    {
        get { Initialize(); return _port!; }
        set { Initialize(); _port!.Assign(value); }
    }
    private BicepValue<int>? _port;

    /// <summary> The target domain name for this SRV record. </summary>
    public BicepValue<string> Target
    {
        get { Initialize(); return _target!; }
        set { Initialize(); _target!.Assign(value); }
    }
    private BicepValue<string>? _target;

    /// <summary>
    /// Creates a new DnsSrvRecordInfo.
    /// </summary>
    public DnsSrvRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsSrvRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _priority = DefineProperty<int>("Priority", ["priority"]);
        _weight = DefineProperty<int>("Weight", ["weight"]);
        _port = DefineProperty<int>("Port", ["port"]);
        _target = DefineProperty<string>("Target", ["target"]);
    }
}
