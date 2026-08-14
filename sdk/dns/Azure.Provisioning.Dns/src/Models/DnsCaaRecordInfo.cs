// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// A CAA record.
/// </summary>
public partial class DnsCaaRecordInfo : ProvisionableConstruct
{
    /// <summary> The flags for this CAA record as an integer between 0 and 255. </summary>
    public BicepValue<int> Flags
    {
        get { Initialize(); return _flags!; }
        set { Initialize(); _flags!.Assign(value); }
    }
    private BicepValue<int>? _flags;

    /// <summary> The tag for this CAA record. </summary>
    public BicepValue<string> Tag
    {
        get { Initialize(); return _tag!; }
        set { Initialize(); _tag!.Assign(value); }
    }
    private BicepValue<string>? _tag;

    /// <summary> The value for this CAA record. </summary>
    public BicepValue<string> Value
    {
        get { Initialize(); return _value!; }
        set { Initialize(); _value!.Assign(value); }
    }
    private BicepValue<string>? _value;

    /// <summary>
    /// Creates a new DnsCaaRecordInfo.
    /// </summary>
    public DnsCaaRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsCaaRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _flags = DefineProperty<int>("flags", ["flags"]);
        _tag = DefineProperty<string>("tag", ["tag"]);
        _value = DefineProperty<string>("value", ["value"]);
    }
}
