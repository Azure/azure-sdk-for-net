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
    /// <summary> Compatibility declaration for the ApplicationGatewayEntraJwtValidationConfig type. </summary>
    [CodeGenSuppress("TenantId")]
    public partial class ApplicationGatewayEntraJwtValidationConfig
    {
        /// <summary> Gets or sets the TenantId compatibility property. </summary>
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
