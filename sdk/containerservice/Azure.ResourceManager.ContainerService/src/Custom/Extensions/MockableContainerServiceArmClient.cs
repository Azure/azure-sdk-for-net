// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableContainerServiceArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing an <see cref="OSOptionProfileResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OSOptionProfileResource.CreateResourceIdentifier" /> to create an <see cref="OSOptionProfileResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="OSOptionProfileResource"/> object. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual OSOptionProfileResource GetOSOptionProfileResource(ResourceIdentifier id)
        {
            OSOptionProfileResource.ValidateResourceId(id);
            return new OSOptionProfileResource(Client, id);
        }
    }
}
