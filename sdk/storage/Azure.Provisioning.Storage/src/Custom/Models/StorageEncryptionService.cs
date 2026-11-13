// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageEncryptionService
{
    private BicepValue<bool> _isEnabled;
    private BicepValue<StorageEncryptionKeyType> _keyType;

    // The generator omits writable IsEnabled because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets whether encryption is enabled. </summary>
    [CodeGenMember("IsEnabled")]
    public BicepValue<bool> IsEnabled
    {
        get { Initialize(); return _isEnabled; }
        set { Initialize(); _isEnabled.Assign(value); }
    }

    // The generator omits writable KeyType because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the encryption key type. </summary>
    [CodeGenMember("KeyType")]
    public BicepValue<StorageEncryptionKeyType> KeyType
    {
        get { Initialize(); return _keyType; }
        set { Initialize(); _keyType.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _isEnabled = DefineProperty<bool>(nameof(IsEnabled), new string[] { "enabled" });
        _keyType = DefineProperty<StorageEncryptionKeyType>(nameof(KeyType), new string[] { "keyType" });
    }
}
