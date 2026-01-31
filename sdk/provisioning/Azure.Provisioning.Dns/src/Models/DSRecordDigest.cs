// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// A digest.
/// </summary>
public partial class DSRecordDigest : ProvisionableConstruct
{
    /// <summary> The digest algorithm type represents the standard digest algorithm number used to construct the digest. See: https://www.iana.org/assignments/ds-rr-types/ds-rr-types.xhtml. </summary>
    public BicepValue<int> AlgorithmType
    {
        get { Initialize(); return _algorithmType!; }
        set { Initialize(); _algorithmType!.Assign(value); }
    }
    private BicepValue<int>? _algorithmType;

    /// <summary> The digest value is a cryptographic hash value of the referenced DNSKEY Resource Record. </summary>
    public BicepValue<string> Value
    {
        get { Initialize(); return _value!; }
        set { Initialize(); _value!.Assign(value); }
    }
    private BicepValue<string>? _value;

    /// <summary>
    /// Creates a new DSRecordDigest.
    /// </summary>
    public DSRecordDigest()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DSRecordDigest.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _algorithmType = DefineProperty<int>("AlgorithmType", ["algorithmType"]);
        _value = DefineProperty<string>("Value", ["value"]);
    }
}
