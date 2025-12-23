// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System;
using Azure.Core;

namespace Azure.ResourceManager.ServiceNetworking.Mocking
{
#pragma warning disable 0618
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableServiceNetworkingArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing an <see cref="AssociationResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AssociationResource.CreateResourceIdentifier" /> to create an <see cref="AssociationResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AssociationResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerAssociationResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AssociationResource GetAssociationResource(ResourceIdentifier id)
        {
            AssociationResource.ValidateResourceId(id);
            return new AssociationResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="FrontendResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FrontendResource.CreateResourceIdentifier" /> to create a <see cref="FrontendResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FrontendResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerFrontendResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FrontendResource GetFrontendResource(ResourceIdentifier id)
        {
            FrontendResource.ValidateResourceId(id);
            return new FrontendResource(Client, id);
        }
    }
#pragma warning restore 0618
}
