// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Resources.Mocking
{
    // Suppress all these extension methods to avoid conflicts with the original Azure.ResourceMananger.Resources package.
    // These extension methods holder will still be available in the original Azure.ResourceMananger.Resources package which
    // and will delegate to the implementations in this separated package.
    [CodeGenSuppress("GetArmDeploymentResource", typeof(ResourceIdentifier))]
    public partial class MockableResourcesArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing an <see cref="ArmDeploymentResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ArmDeploymentResource.CreateResourceIdentifier" /> to create an <see cref="ArmDeploymentResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ArmDeploymentResource"/> object. </returns>
        public virtual ArmDeploymentResource GetDeploymentResource(ResourceIdentifier id)
        {
            ArmDeploymentResource.ValidateResourceId(id);
            return new ArmDeploymentResource(Client, id);
        }
    }
}
