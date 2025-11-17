// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// A TXT record.
/// </summary>
public partial class DnsTxtRecordInfo : ProvisionableConstruct
{
    /// <summary> The text value of this TXT record. </summary>
    public BicepList<string> Values
    {
        get { Initialize(); return _values!; }
        set { Initialize(); _values!.Assign(value); }
    }
    private BicepList<string>? _values;

    /// <summary>
    /// Creates a new DnsTxtRecordInfo.
    /// </summary>
    public DnsTxtRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsTxtRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _values = DefineListProperty<string>("Values", ["value"]);
    }
}
