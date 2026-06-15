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
    [CodeGenSuppress("TenantId")]
    public partial class ApplicationGatewayEntraJwtValidationConfig
    {
        [Azure.ResourceManager.Network.WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.TenantId);
            set
            {
                if (Properties is null)
                {
                    Properties = new ApplicationGatewayEntraJWTValidationConfigPropertiesFormat();
                }
                Properties.TenantId = Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.FormatGuid(value);
            }
        }
    }
}

#pragma warning restore CS0612, CS0618, CS1591
