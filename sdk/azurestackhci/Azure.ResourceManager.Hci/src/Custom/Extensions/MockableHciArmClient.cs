// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System;
using Azure.Core;

namespace Azure.ResourceManager.Hci.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableHciArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing an <see cref="OfferResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OfferResource.CreateResourceIdentifier" /> to create an <see cref="OfferResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="OfferResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual OfferResource GetOfferResource(ResourceIdentifier id)
        {
            OfferResource.ValidateResourceId(id);
            return new OfferResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PublisherResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PublisherResource.CreateResourceIdentifier" /> to create a <see cref="PublisherResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PublisherResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual PublisherResource GetPublisherResource(ResourceIdentifier id)
        {
            PublisherResource.ValidateResourceId(id);
            return new PublisherResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateRunResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UpdateRunResource.CreateResourceIdentifier" /> to create an <see cref="UpdateRunResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="UpdateRunResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateRunResource GetUpdateRunResource(ResourceIdentifier id)
        {
            UpdateRunResource.ValidateResourceId(id);
            return new UpdateRunResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateSummaryResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UpdateSummaryResource.CreateResourceIdentifier" /> to create an <see cref="UpdateSummaryResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="UpdateSummaryResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateSummaryResource GetUpdateSummaryResource(ResourceIdentifier id)
        {
            UpdateSummaryResource.ValidateResourceId(id);
            return new UpdateSummaryResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UpdateResource.CreateResourceIdentifier" /> to create an <see cref="UpdateResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="UpdateResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateResource GetUpdateResource(ResourceIdentifier id)
        {
            UpdateResource.ValidateResourceId(id);
            return new UpdateResource(Client, id);
        }
    }
}
