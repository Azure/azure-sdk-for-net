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
    [CodeGenSuppress("Data")]
    [CodeGenSuppress("ValidatedCertData")]
    public partial class ApplicationGatewayTrustedClientCertificate
    {
        [Azure.ResourceManager.Network.WirePath("properties.data")]
        public BinaryData Data
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.Data);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayTrustedClientCertificatePropertiesFormat();
                }
                Properties.Data = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatBinaryData(value);
            }
        }

        [Azure.ResourceManager.Network.WirePath("properties.validatedCertData")] public BinaryData ValidatedCertData => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseBinaryData(Properties?.ValidatedCertData);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
