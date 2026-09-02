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

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ScopeConnectionData type. </summary>
    [CodeGenSuppress("TenantId")]
    public partial class ScopeConnectionData
    {
        /// <summary> Gets or sets the TenantId compatibility property. </summary>
        [WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.TenantId);
            set
            {
                if (Properties is null)
                {
                    Properties = new ScopeConnectionProperties();
                }
                Properties.TenantId = WritableSubResourceCollectionCompatibility.FormatGuid(value);
            }
        }
    }
}
