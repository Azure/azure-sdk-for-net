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

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("TenantId")]
    public partial class ScopeConnectionData
    {
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

#pragma warning restore CS0612, CS0618, CS1591
