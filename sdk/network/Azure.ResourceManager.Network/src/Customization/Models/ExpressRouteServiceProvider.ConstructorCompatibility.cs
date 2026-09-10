// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ExpressRouteServiceProvider type. </summary>
    [CodeGenSuppress("ExpressRouteServiceProvider")]
    public partial class ExpressRouteServiceProvider
    {
        /// <summary> Initializes a new instance of the ExpressRouteServiceProvider class. </summary>
        public ExpressRouteServiceProvider()
        {
        }
    }
}
