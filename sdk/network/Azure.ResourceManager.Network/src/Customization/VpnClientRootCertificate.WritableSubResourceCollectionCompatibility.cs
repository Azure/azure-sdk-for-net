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
    [CodeGenSuppress("PublicCertData")]
    public partial class VpnClientRootCertificate
    {
        public VpnClientRootCertificate(BinaryData publicCertData)
        {
            PublicCertData = publicCertData;
        }

        [Azure.ResourceManager.Network.WirePath("properties.publicCertData")]
        public BinaryData PublicCertData
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.PublicCertData);
            set
            {
                if (Properties is null)
                {
                    Properties = new VpnClientRootCertificatePropertiesFormat();
                }
                Properties.PublicCertData = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }
    }
}

#pragma warning restore CS0612, CS0618, CS1591
