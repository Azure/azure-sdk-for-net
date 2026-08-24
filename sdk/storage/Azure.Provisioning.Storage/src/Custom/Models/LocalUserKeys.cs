// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

// TypeSpec does not generate the local-user listKeys action result. Preserve the shipped
// secure output model used by StorageAccountLocalUser.GetKeys.
/// <summary>
/// The Storage Account Local User keys.
/// </summary>
public partial class LocalUserKeys : ProvisionableConstruct
{
    private BicepList<StorageSshPublicKey>? _sshAuthorizedKeys;
    private BicepValue<string>? _sharedKey;

    /// <summary> Optional local user SSH authorized keys for SFTP. </summary>
    public BicepList<StorageSshPublicKey> SshAuthorizedKeys
    {
        get { Initialize(); return _sshAuthorizedKeys!; }
    }

    /// <summary> The server-generated SMB authentication key. </summary>
    public BicepValue<string> SharedKey
    {
        get { Initialize(); return _sharedKey!; }
    }

    /// <summary> Creates a new LocalUserKeys. </summary>
    public LocalUserKeys()
    {
    }

    /// <summary> Defines the provisionable properties. </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _sshAuthorizedKeys = DefineListProperty<StorageSshPublicKey>(nameof(SshAuthorizedKeys), ["sshAuthorizedKeys"], isOutput: true);
        _sharedKey = DefineProperty<string>(nameof(SharedKey), ["sharedKey"], isOutput: true, isSecure: true);
    }
}
