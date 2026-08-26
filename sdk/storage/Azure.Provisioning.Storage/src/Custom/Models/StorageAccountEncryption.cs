// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountEncryption
{
    private StorageAccountEncryptionServices _services;
    private BicepValue<StorageAccountKeySource> _keySource;
    private BicepValue<bool> _requireInfrastructureEncryption;
    private StorageAccountKeyVaultProperties _keyVaultProperties;
    private StorageAccountEncryptionIdentity _encryptionIdentity;

    /// <summary> Gets or sets the encryption services. </summary>
    [CodeGenMember("Services")]
    public StorageAccountEncryptionServices Services
    {
        get { Initialize(); return _services; }
        set { Initialize(); AssignOrReplace(ref _services, value); }
    }

    /// <summary> Gets or sets the encryption key source. </summary>
    [CodeGenMember("KeySource")]
    public BicepValue<StorageAccountKeySource> KeySource
    {
        get { Initialize(); return _keySource; }
        set { Initialize(); _keySource.Assign(value); }
    }

    /// <summary> Gets or sets whether infrastructure encryption is required. </summary>
    [CodeGenMember("RequireInfrastructureEncryption")]
    public BicepValue<bool> RequireInfrastructureEncryption
    {
        get { Initialize(); return _requireInfrastructureEncryption; }
        set { Initialize(); _requireInfrastructureEncryption.Assign(value); }
    }

    /// <summary> Gets or sets the key vault properties. </summary>
    [CodeGenMember("KeyVaultProperties")]
    public StorageAccountKeyVaultProperties KeyVaultProperties
    {
        get { Initialize(); return _keyVaultProperties; }
        set { Initialize(); AssignOrReplace(ref _keyVaultProperties, value); }
    }

    /// <summary> Gets or sets the encryption identity. </summary>
    [CodeGenMember("EncryptionIdentity")]
    public StorageAccountEncryptionIdentity EncryptionIdentity
    {
        get { Initialize(); return _encryptionIdentity; }
        set { Initialize(); AssignOrReplace(ref _encryptionIdentity, value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _services = DefineModelProperty<StorageAccountEncryptionServices>(nameof(Services), new string[] { "services" });
        _keySource = DefineProperty<StorageAccountKeySource>(nameof(KeySource), new string[] { "keySource" });
        _requireInfrastructureEncryption = DefineProperty<bool>(nameof(RequireInfrastructureEncryption), new string[] { "requireInfrastructureEncryption" });
        _keyVaultProperties = DefineModelProperty<StorageAccountKeyVaultProperties>(nameof(KeyVaultProperties), new string[] { "keyvaultproperties" });
        _encryptionIdentity = DefineModelProperty<StorageAccountEncryptionIdentity>(nameof(EncryptionIdentity), new string[] { "identity" });
    }
}
