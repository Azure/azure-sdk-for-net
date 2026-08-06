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
    /// <summary> Compatibility declaration for the ApplicationGatewayBackendHttpSettings type. </summary>
    [CodeGenSuppress("AuthenticationCertificates")]
    [CodeGenSuppress("TrustedRootCertificates")]
    public partial class ApplicationGatewayBackendHttpSettings
    {
        /// <summary> Gets or sets the AuthenticationCertificates compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.authenticationCertificates")]
        public IList<WritableSubResource> AuthenticationCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.AuthenticationCertificates);
        /// <summary> Gets or sets the TrustedRootCertificates compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.trustedRootCertificates")]
        public IList<WritableSubResource> TrustedRootCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.TrustedRootCertificates);
    }
}
