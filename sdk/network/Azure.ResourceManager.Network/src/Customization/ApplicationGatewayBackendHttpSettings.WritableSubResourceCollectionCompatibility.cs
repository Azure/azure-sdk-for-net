// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("AuthenticationCertificates")]
    [CodeGenSuppress("TrustedRootCertificates")]
    public partial class ApplicationGatewayBackendHttpSettings
    {
        [Azure.ResourceManager.Network.WirePath("properties.authenticationCertificates")] public IList<WritableSubResource> AuthenticationCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.AuthenticationCertificates);
        [Azure.ResourceManager.Network.WirePath("properties.trustedRootCertificates")] public IList<WritableSubResource> TrustedRootCertificates => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.TrustedRootCertificates);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
