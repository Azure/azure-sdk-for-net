// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary> Represents the signing key. </summary>
public partial class DnsSigningKey : ProvisionableConstruct
{
    /// <summary> The delegation signer information. </summary>
    public BicepList<DelegationSignerInfo> DelegationSignerInfo
    {
        get { Initialize(); return _delegationSignerInfo!; }
    }
    private BicepList<DelegationSignerInfo>? _delegationSignerInfo;

    /// <summary> The flags specifies how the key is used. </summary>
    public BicepValue<int> Flags
    {
        get { Initialize(); return _flags!; }
    }
    private BicepValue<int>? _flags;

    /// <summary> The key tag value of the DNSKEY Resource Record. </summary>
    public BicepValue<int> KeyTag
    {
        get { Initialize(); return _keyTag!; }
    }
    private BicepValue<int>? _keyTag;

    /// <summary> The protocol value. The value is always 3. </summary>
    public BicepValue<int> Protocol
    {
        get { Initialize(); return _protocol!; }
    }
    private BicepValue<int>? _protocol;

    /// <summary> The public key, represented as a Base64 encoding. </summary>
    public BicepValue<string> PublicKey
    {
        get { Initialize(); return _publicKey!; }
    }
    private BicepValue<string>? _publicKey;

    /// <summary> The security algorithm type represents the standard security algorithm number of the DNSKEY Resource Record. See: https://www.iana.org/assignments/dns-sec-alg-numbers/dns-sec-alg-numbers.xhtml. </summary>
    public BicepValue<int> SecurityAlgorithmType
    {
        get { Initialize(); return _securityAlgorithmType!; }
    }
    private BicepValue<int>? _securityAlgorithmType;

    /// <summary>
    /// Creates a new DnsSigningKey.
    /// </summary>
    public DnsSigningKey()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsSigningKey.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _delegationSignerInfo = DefineListProperty<DelegationSignerInfo>("DelegationSignerInfo", ["delegationSignerInfo"], isOutput: true);
        _flags = DefineProperty<int>("Flags", ["flags"], isOutput: true);
        _keyTag = DefineProperty<int>("KeyTag", ["keyTag"], isOutput: true);
        _protocol = DefineProperty<int>("Protocol", ["protocol"], isOutput: true);
        _publicKey = DefineProperty<string>("PublicKey", ["publicKey"], isOutput: true);
        _securityAlgorithmType = DefineProperty<int>("SecurityAlgorithmType", ["securityAlgorithmType"], isOutput: true);
    }
}
