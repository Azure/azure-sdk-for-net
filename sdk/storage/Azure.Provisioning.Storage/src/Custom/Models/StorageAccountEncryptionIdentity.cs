// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountEncryptionIdentity
{
    private BicepValue<string> _encryptionUserAssignedIdentity;
    private BicepValue<string> _encryptionFederatedIdentityClientId;

    // The generator omits writable EncryptionUserAssignedIdentity because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the user-assigned identity used for encryption. </summary>
    [CodeGenMember("EncryptionUserAssignedIdentity")]
    public BicepValue<string> EncryptionUserAssignedIdentity
    {
        get { Initialize(); return _encryptionUserAssignedIdentity; }
        set { Initialize(); _encryptionUserAssignedIdentity.Assign(value); }
    }

    // The generator omits writable EncryptionFederatedIdentityClientId because this model is reached through both the create body and a read-only resource graph.
    /// <summary> Gets or sets the federated identity client ID used for encryption. </summary>
    [CodeGenMember("EncryptionFederatedIdentityClientId")]
    public BicepValue<string> EncryptionFederatedIdentityClientId
    {
        get { Initialize(); return _encryptionFederatedIdentityClientId; }
        set { Initialize(); _encryptionFederatedIdentityClientId.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _encryptionUserAssignedIdentity = DefineProperty<string>(nameof(EncryptionUserAssignedIdentity), new string[] { "userAssignedIdentity" });
        _encryptionFederatedIdentityClientId = DefineProperty<string>(nameof(EncryptionFederatedIdentityClientId), new string[] { "federatedIdentityClientId" });
    }
}
