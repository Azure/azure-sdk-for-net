// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CloudServiceSwapCollection type. </summary>
    public partial class CloudServiceSwapCollection
    {
        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<CloudServiceSwapResource> GetAllAsync(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<CloudServiceSwapResource> GetAll(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
