// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary> The delegation signer information. </summary>
public partial class DelegationSignerInfo : ProvisionableConstruct
{
    /// <summary> The digest algorithm type represents the standard digest algorithm number used to construct the digest. See: https://www.iana.org/assignments/ds-rr-types/ds-rr-types.xhtml. </summary>
    public BicepValue<int> DigestAlgorithmType
    {
        get { Initialize(); return _digestAlgorithmType!; }
    }
    private BicepValue<int>? _digestAlgorithmType;

    /// <summary> The digest value is a cryptographic hash value of the referenced DNSKEY Resource Record. </summary>
    public BicepValue<string> DigestValue
    {
        get { Initialize(); return _digestValue!; }
    }
    private BicepValue<string>? _digestValue;

    /// <summary> The record represents a delegation signer (DS) record. </summary>
    public BicepValue<string> Record
    {
        get { Initialize(); return _record!; }
    }
    private BicepValue<string>? _record;

    /// <summary>
    /// Creates a new DelegationSignerInfo.
    /// </summary>
    public DelegationSignerInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DelegationSignerInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _digestAlgorithmType = DefineProperty<int>("DigestAlgorithmType", ["digestAlgorithmType"], isOutput: true);
        _digestValue = DefineProperty<string>("DigestValue", ["digestValue"], isOutput: true);
        _record = DefineProperty<string>("Record", ["record"], isOutput: true);
    }
}
