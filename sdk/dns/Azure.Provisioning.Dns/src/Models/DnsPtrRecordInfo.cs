// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// A PTR record.
/// </summary>
public partial class DnsPtrRecordInfo : ProvisionableConstruct
{
    /// <summary> The PTR target domain name for this PTR record. </summary>
    public BicepValue<string> DnsPtrDomainName
    {
        get { Initialize(); return _dnsPtrDomainName!; }
        set { Initialize(); _dnsPtrDomainName!.Assign(value); }
    }
    private BicepValue<string>? _dnsPtrDomainName;

    /// <summary>
    /// Creates a new DnsPtrRecordInfo.
    /// </summary>
    public DnsPtrRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsPtrRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _dnsPtrDomainName = DefineProperty<string>("DnsPtrDomainName", ["ptrdname"]);
    }
}
