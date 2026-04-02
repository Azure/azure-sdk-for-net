// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generator bug: MockableContainerInstanceArmClient generated without constructors or methods.
// This partial class provides the missing members.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    /// <summary> A class to add extension methods to <see cref="ArmClient"/>. </summary>
    public partial class MockableContainerInstanceArmClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableContainerInstanceArmClient"/> class for mocking. </summary>
        protected MockableContainerInstanceArmClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableContainerInstanceArmClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableContainerInstanceArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MockableContainerInstanceArmClient(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerGroupResource.CreateResourceIdentifier" /> to create a <see cref="ContainerGroupResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerGroupResource"/> object. </returns>
        public virtual ContainerGroupResource GetContainerGroupResource(ResourceIdentifier id)
        {
            ContainerGroupResource.ValidateResourceId(id);
            return new ContainerGroupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NGroupResource.CreateResourceIdentifier" /> to create a <see cref="NGroupResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NGroupResource"/> object. </returns>
        public virtual NGroupResource GetNGroupResource(ResourceIdentifier id)
        {
            NGroupResource.ValidateResourceId(id);
            return new NGroupResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CGProfileResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CGProfileResource.CreateResourceIdentifier" /> to create a <see cref="CGProfileResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CGProfileResource"/> object. </returns>
        public virtual CGProfileResource GetCGProfileResource(ResourceIdentifier id)
        {
            CGProfileResource.ValidateResourceId(id);
            return new CGProfileResource(Client, id);
        }
    }
}
