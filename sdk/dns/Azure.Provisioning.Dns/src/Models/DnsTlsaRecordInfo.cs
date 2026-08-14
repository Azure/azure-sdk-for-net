// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// A TLSA record. For more information about the TLSA record format, see RFC
/// 6698: https://www.rfc-editor.org/rfc/rfc6698.
/// </summary>
public partial class DnsTlsaRecordInfo : ProvisionableConstruct
{
    /// <summary> The usage specifies the provided association that will be used to match the certificate presented in the TLS handshake. </summary>
    public BicepValue<int> Usage
    {
        get { Initialize(); return _usage!; }
        set { Initialize(); _usage!.Assign(value); }
    }
    private BicepValue<int>? _usage;

    /// <summary> The selector specifies which part of the TLS certificate presented by the server will be matched against the association data. </summary>
    public BicepValue<int> Selector
    {
        get { Initialize(); return _selector!; }
        set { Initialize(); _selector!.Assign(value); }
    }
    private BicepValue<int>? _selector;

    /// <summary> The matching type specifies how the certificate association is presented. </summary>
    public BicepValue<int> MatchingType
    {
        get { Initialize(); return _matchingType!; }
        set { Initialize(); _matchingType!.Assign(value); }
    }
    private BicepValue<int>? _matchingType;

    /// <summary> This specifies the certificate association data to be matched. </summary>
    public BicepValue<string> CertAssociationData
    {
        get { Initialize(); return _certAssociationData!; }
        set { Initialize(); _certAssociationData!.Assign(value); }
    }
    private BicepValue<string>? _certAssociationData;

    /// <summary>
    /// Creates a new DnsTlsaRecordInfo.
    /// </summary>
    public DnsTlsaRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsTlsaRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _usage = DefineProperty<int>("Usage", ["usage"]);
        _selector = DefineProperty<int>("Selector", ["selector"]);
        _matchingType = DefineProperty<int>("MatchingType", ["matchingType"]);
        _certAssociationData = DefineProperty<string>("CertAssociationData", ["certAssociationData"]);
    }
}
