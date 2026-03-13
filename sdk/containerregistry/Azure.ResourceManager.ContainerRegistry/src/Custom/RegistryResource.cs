// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    [CodeGenSuppress("GetArchives", typeof(string))]
    [CodeGenSuppress("GetArchiveAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArchive", typeof(string), typeof(CancellationToken))]
    public partial class ContainerRegistryResource : ArmResource
    {
        /// <summary> Gets a collection of Archives in the <see cref="ContainerRegistryResource"/>. </summary>
        /// <param name="packageType"> The packageType for the resource. </param>
        /// <returns> An object representing collection of Archives and their operations over a ArchiveResource. </returns>
        public virtual ArchiveCollection GetArchives(string packageType)
        {
            return this.GetCachedClient(client => new ArchiveCollection(client, Id, packageType));
        }
    }
}
