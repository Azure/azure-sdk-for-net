// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Information about the certificate that is used for token validation.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class IssuerCertificateInfo : ProvisionableConstruct
{
    /// <summary>
    /// Keyvault certificate URL in
    /// https://keyvaultname.vault.azure.net/certificates/certificateName/certificateVersion
    /// format.
    /// </summary>
    public BicepValue<Uri> CertificateUri
    {
        get { Initialize(); return _certificateUri!; }
        set { Initialize(); _certificateUri!.Assign(value); }
    }
    private BicepValue<Uri>? _certificateUri;

    /// <summary>
    /// The identity that will be used to access the certificate.
    /// </summary>
    public CustomJwtAuthenticationManagedIdentity Identity
    {
        get { Initialize(); return _identity!; }
        set { Initialize(); AssignOrReplace(ref _identity, value); }
    }
    private CustomJwtAuthenticationManagedIdentity? _identity;

    /// <summary>
    /// Creates a new IssuerCertificateInfo.
    /// </summary>
    public IssuerCertificateInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of IssuerCertificateInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _certificateUri = DefineProperty<Uri>("CertificateUri", ["certificateUrl"]);
        _identity = DefineModelProperty<CustomJwtAuthenticationManagedIdentity>("Identity", ["identity"]);
    }
}
