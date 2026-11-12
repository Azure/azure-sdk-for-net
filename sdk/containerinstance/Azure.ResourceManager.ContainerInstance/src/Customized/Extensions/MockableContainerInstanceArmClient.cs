// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceArmClient : ArmResource
    {
        /// <summary> Gets an object representing a <see cref="ContainerGroupSandboxResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerGroupSandboxResource"/> object. </returns>
        public virtual ContainerGroupSandboxResource GetContainerGroupSandboxResource(ResourceIdentifier id)
        {
            ContainerGroupSandboxResource.ValidateResourceId(id);
            return new ContainerGroupSandboxResource(Client, id);
        }
    }
}
