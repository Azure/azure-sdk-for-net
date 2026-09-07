// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class IssuerCertificateInfo
{
    private BicepValue<Uri> _certificateUri;

    /// <summary> The URI of the issuer certificate. </summary>
    // The generated property is required. Preserve the released optional property while retaining
    // the generated Uri type and its original wire path.
    [CodeGenMember("CertificateUri")]
    public BicepValue<Uri> CertificateUri
    {
        get
        {
            Initialize();
            return _certificateUri;
        }
        set
        {
            Initialize();
            _certificateUri.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _certificateUri = DefineProperty<Uri>(nameof(CertificateUri), ["certificateUri"]);
    }
}
