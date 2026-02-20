// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Mocking
{
    public partial class MockableComputeArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="CommunityGalleryResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CommunityGalleryResource.CreateResourceIdentifier" /> to create a <see cref="CommunityGalleryResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CommunityGalleryResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CommunityGalleryResource GetCommunityGalleryResource(ResourceIdentifier id)
        {
            CommunityGalleryResource.ValidateResourceId(id);
            return new CommunityGalleryResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CommunityGalleryImageResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CommunityGalleryImageResource.CreateResourceIdentifier" /> to create a <see cref="CommunityGalleryImageResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CommunityGalleryImageResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CommunityGalleryImageResource GetCommunityGalleryImageResource(ResourceIdentifier id)
        {
            CommunityGalleryImageResource.ValidateResourceId(id);
            return new CommunityGalleryImageResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CommunityGalleryImageVersionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CommunityGalleryImageVersionResource.CreateResourceIdentifier" /> to create a <see cref="CommunityGalleryImageVersionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CommunityGalleryImageVersionResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CommunityGalleryImageVersionResource GetCommunityGalleryImageVersionResource(ResourceIdentifier id)
        {
            CommunityGalleryImageVersionResource.ValidateResourceId(id);
            return new CommunityGalleryImageVersionResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SharedGalleryResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SharedGalleryResource GetSharedGalleryResource(ResourceIdentifier id)
        {
            SharedGalleryResource.ValidateResourceId(id);
            return new SharedGalleryResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryImageResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryImageResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryImageResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SharedGalleryImageResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SharedGalleryImageResource GetSharedGalleryImageResource(ResourceIdentifier id)
        {
            SharedGalleryImageResource.ValidateResourceId(id);
            return new SharedGalleryImageResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryImageVersionResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryImageVersionResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryImageVersionResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SharedGalleryImageVersionResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SharedGalleryImageVersionResource GetSharedGalleryImageVersionResource(ResourceIdentifier id)
        {
            SharedGalleryImageVersionResource.ValidateResourceId(id);
            return new SharedGalleryImageVersionResource(Client, id);
        }
    }
}
