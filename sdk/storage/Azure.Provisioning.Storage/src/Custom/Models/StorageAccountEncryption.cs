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

    // The generator omits writable Services because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the encryption services. </summary>
    [CodeGenMember("Services")]
    public StorageAccountEncryptionServices Services
    {
        get { Initialize(); return _services; }
        set { Initialize(); AssignOrReplace(ref _services, value); }
    }

    // The generator omits writable KeySource because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the encryption key source. </summary>
    [CodeGenMember("KeySource")]
    public BicepValue<StorageAccountKeySource> KeySource
    {
        get { Initialize(); return _keySource; }
        set { Initialize(); _keySource.Assign(value); }
    }

    // The generator omits writable RequireInfrastructureEncryption because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets whether infrastructure encryption is required. </summary>
    [CodeGenMember("RequireInfrastructureEncryption")]
    public BicepValue<bool> RequireInfrastructureEncryption
    {
        get { Initialize(); return _requireInfrastructureEncryption; }
        set { Initialize(); _requireInfrastructureEncryption.Assign(value); }
    }

    // The generator omits writable KeyVaultProperties because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the key vault properties. </summary>
    [CodeGenMember("KeyVaultProperties")]
    public StorageAccountKeyVaultProperties KeyVaultProperties
    {
        get { Initialize(); return _keyVaultProperties; }
        set { Initialize(); AssignOrReplace(ref _keyVaultProperties, value); }
    }

    // The generator omits writable EncryptionIdentity because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the encryption identity. </summary>
    [CodeGenMember("EncryptionIdentity")]
    public StorageAccountEncryptionIdentity EncryptionIdentity
    {
        get { Initialize(); return _encryptionIdentity; }
        set { Initialize(); AssignOrReplace(ref _encryptionIdentity, value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _services = DefineModelProperty<StorageAccountEncryptionServices>(nameof(Services), new string[] { "services" });
        _keySource = DefineProperty<StorageAccountKeySource>(nameof(KeySource), new string[] { "keySource" });
        _requireInfrastructureEncryption = DefineProperty<bool>(nameof(RequireInfrastructureEncryption), new string[] { "requireInfrastructureEncryption" });
        _keyVaultProperties = DefineModelProperty<StorageAccountKeyVaultProperties>(nameof(KeyVaultProperties), new string[] { "keyvaultproperties" });
        _encryptionIdentity = DefineModelProperty<StorageAccountEncryptionIdentity>(nameof(EncryptionIdentity), new string[] { "identity" });
    }
}
