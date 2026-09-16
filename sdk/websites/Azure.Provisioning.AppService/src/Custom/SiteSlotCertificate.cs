// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteSlotCertificate
{
    // Preserve the legacy BinaryData API while retaining ThumbprintString for the current string-typed schema.

    /// <summary> Certificate thumbprint. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
    public BicepValue<BinaryData> Thumbprint
    {
        get
        {
            if (Properties is null)
            {
                Properties = new CertificateProperties();
            }
            return Properties.Thumbprint;
        }
    }
}
