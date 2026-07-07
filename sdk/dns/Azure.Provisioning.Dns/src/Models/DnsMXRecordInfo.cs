// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// An MX record.
/// </summary>
public partial class DnsMXRecordInfo : ProvisionableConstruct
{
    /// <summary> The preference value for this MX record. </summary>
    public BicepValue<int> Preference
    {
        get { Initialize(); return _preference!; }
        set { Initialize(); _preference!.Assign(value); }
    }
    private BicepValue<int>? _preference;

    /// <summary> The domain name of the mail host for this MX record. </summary>
    public BicepValue<string> Exchange
    {
        get { Initialize(); return _exchange!; }
        set { Initialize(); _exchange!.Assign(value); }
    }
    private BicepValue<string>? _exchange;

    /// <summary>
    /// Creates a new DnsMXRecordInfo.
    /// </summary>
    public DnsMXRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsMXRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _preference = DefineProperty<int>("Preference", ["preference"]);
        _exchange = DefineProperty<string>("Exchange", ["exchange"]);
    }
}
