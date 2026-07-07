// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ResourceNavigationLink type. </summary>
    [CodeGenSuppress("ResourceNavigationLink")]
    public partial class ResourceNavigationLink
    {
        /// <summary> Initializes a new instance of the ResourceNavigationLink class. </summary>
        public ResourceNavigationLink()
        {
        }
    }
}
