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

    /// <summary> Gets or sets whether encryption is enabled. </summary>
    [CodeGenMember("IsEnabled")]
    public BicepValue<bool> IsEnabled
    {
        get { Initialize(); return _isEnabled; }
        set { Initialize(); _isEnabled.Assign(value); }
    }

    /// <summary> Gets or sets the encryption key type. </summary>
    [CodeGenMember("KeyType")]
    public BicepValue<StorageEncryptionKeyType> KeyType
    {
        get { Initialize(); return _keyType; }
        set { Initialize(); _keyType.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _isEnabled = DefineProperty<bool>(nameof(IsEnabled), new string[] { "enabled" });
        _keyType = DefineProperty<StorageEncryptionKeyType>(nameof(KeyType), new string[] { "keyType" });
    }
}
