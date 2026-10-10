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
    /// <summary> Compatibility declaration for the VpnClientRootCertificate type. </summary>
    [CodeGenSuppress("PublicCertData")]
    public partial class VpnClientRootCertificate
    {
        /// <summary> Initializes a new instance of the VpnClientRootCertificate class. </summary>
        public VpnClientRootCertificate(BinaryData publicCertData)
        {
            PublicCertData = publicCertData;
        }
        /// <summary> Gets or sets the PublicCertData compatibility property. </summary>

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
