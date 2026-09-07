// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class CustomDomainConfiguration
{
    private BicepValue<Uri> _customCertificateUri;

    /// <summary> Gets or sets the certificate URI. </summary>
    // The generated property uses string. Preserve the released Uri type on the same certificateUrl
    // wire path so callers retain URI validation and source compatibility.
    [CodeGenMember("CertificateUri")]
    public BicepValue<Uri> CertificateUri
    {
        get
        {
            Initialize();
            return _customCertificateUri;
        }
        set
        {
            Initialize();
            _customCertificateUri.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customCertificateUri = DefineProperty<Uri>(nameof(CertificateUri), ["certificateUrl"]);
    }
}
