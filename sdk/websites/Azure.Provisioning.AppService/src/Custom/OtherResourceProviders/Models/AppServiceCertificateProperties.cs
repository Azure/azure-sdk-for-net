// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppService;

/// <summary>
/// Key Vault container for a certificate that is purchased through Azure.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public partial class AppServiceCertificateProperties : ProvisionableConstruct
{
    /// <summary>
    /// Key Vault resource Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> KeyVaultId
    {
        get { Initialize(); return _keyVaultId; }
        set { Initialize(); _keyVaultId.Assign(value); }
    }
    private BicepValue<ResourceIdentifier> _keyVaultId;

    /// <summary>
    /// Key Vault secret name.
    /// </summary>
    public BicepValue<string> KeyVaultSecretName
    {
        get { Initialize(); return _keyVaultSecretName; }
        set { Initialize(); _keyVaultSecretName.Assign(value); }
    }
    private BicepValue<string> _keyVaultSecretName;

    /// <summary>
    /// Status of the Key Vault secret.
    /// </summary>
    public BicepValue<KeyVaultSecretStatus> ProvisioningState
    {
        get { Initialize(); return _provisioningState; }
    }
    private BicepValue<KeyVaultSecretStatus> _provisioningState;

    /// <summary>
    /// Creates a new AppServiceCertificateProperties.
    /// </summary>
    public AppServiceCertificateProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// AppServiceCertificateProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _keyVaultId = DefineProperty<ResourceIdentifier>("KeyVaultId", ["keyVaultId"]);
        _keyVaultSecretName = DefineProperty<string>("KeyVaultSecretName", ["keyVaultSecretName"]);
        _provisioningState = DefineProperty<KeyVaultSecretStatus>("ProvisioningState", ["provisioningState"], isOutput: true);
    }
}
