// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ActiveBaseSecurityAdminRule type. </summary>
    [CodeGenSuppress("ActiveBaseSecurityAdminRule")]
    public abstract partial class ActiveBaseSecurityAdminRule
    {
        /// <summary> Initializes a new instance of the ActiveBaseSecurityAdminRule class. </summary>
        protected ActiveBaseSecurityAdminRule()
        {
        }
    }
}
