// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewaySslProfile type. </summary>
    [CodeGenSuppress("TrustedClientCertificates")]
    public partial class ApplicationGatewaySslProfile
    {
        /// <summary> Gets or sets the TrustedClientCertificates compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.trustedClientCertificates")]
        public IList<WritableSubResource> TrustedClientCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.TrustedClientCertificates);
    }
}
