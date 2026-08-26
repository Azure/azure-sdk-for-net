// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountKeyVaultProperties
{
    private BicepValue<string> _keyName;
    private BicepValue<string> _keyVersion;
    private BicepValue<Uri> _keyVaultUri;

    /// <summary> Gets or sets the key name. </summary>
    [CodeGenMember("KeyName")]
    public BicepValue<string> KeyName
    {
        get { Initialize(); return _keyName; }
        set { Initialize(); _keyName.Assign(value); }
    }

    /// <summary> Gets or sets the key version. </summary>
    [CodeGenMember("KeyVersion")]
    public BicepValue<string> KeyVersion
    {
        get { Initialize(); return _keyVersion; }
        set { Initialize(); _keyVersion.Assign(value); }
    }

    /// <summary> Gets or sets the key vault URI. </summary>
    [CodeGenMember("KeyVaultUri")]
    public BicepValue<Uri> KeyVaultUri
    {
        get { Initialize(); return _keyVaultUri; }
        set { Initialize(); _keyVaultUri.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks their parent as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _keyName = DefineProperty<string>(nameof(KeyName), new string[] { "keyname" });
        _keyVersion = DefineProperty<string>(nameof(KeyVersion), new string[] { "keyversion" });
        _keyVaultUri = DefineProperty<Uri>(nameof(KeyVaultUri), new string[] { "keyvaulturi" });
    }
}
