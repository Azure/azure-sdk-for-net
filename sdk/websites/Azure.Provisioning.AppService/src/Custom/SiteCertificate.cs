// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteCertificate
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

    public static partial class ResourceVersions
    {
        // Preserve historical API versions that shipped from the reflection-based provisioning generator.
        /// <summary> API version "2024-11-01". </summary>
        public static readonly string V2024_11_01 = "2024-11-01";
    }
}
