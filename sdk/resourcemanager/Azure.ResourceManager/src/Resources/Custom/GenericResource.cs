// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a GenericResource along with the instance operations that can be performed on it. </summary>
    [CodeGenSuppress("CreateResourceIdentifier", typeof(String))]
    public partial class GenericResource : ArmResource
    {
        /// <summary>
        /// Validate the resource identifier against current operations.
        /// </summary>
        /// <param name="identifier"> The resource identifier. </param>
        protected override void ValidateResourceType(ResourceIdentifier identifier)
        {
            if (identifier is null)
                throw new ArgumentException(nameof(identifier));
        }
    }
}
