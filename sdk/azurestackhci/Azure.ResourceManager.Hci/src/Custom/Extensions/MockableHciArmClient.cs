// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Hci.Mocking
{
    public partial class MockableHciArmClient
    {
        /// <summary>
        /// Gets an object representing an <see cref="OfferResource"/> (backward-compat).
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        public virtual OfferResource GetOfferResource(ResourceIdentifier id)
            => throw new NotSupportedException("This method is obsolete. Please use GetHciClusterOfferResource instead.");

        /// <summary>
        /// Gets an object representing a <see cref="PublisherResource"/> (backward-compat).
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        public virtual PublisherResource GetPublisherResource(ResourceIdentifier id)
            => throw new NotSupportedException("This method is obsolete. Please use GetHciClusterPublisherResource instead.");

        /// <summary>
        /// Gets an object representing an <see cref="UpdateResource"/> (backward-compat).
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        public virtual UpdateResource GetUpdateResource(ResourceIdentifier id)
            => throw new NotSupportedException("This method is obsolete. Please use GetHciClusterUpdateResource instead.");

        /// <summary>
        /// Gets an object representing an <see cref="UpdateRunResource"/> (backward-compat).
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        public virtual UpdateRunResource GetUpdateRunResource(ResourceIdentifier id)
            => throw new NotSupportedException("This method is obsolete. Please use GetHciClusterUpdateRunResource instead.");

        /// <summary>
        /// Gets an object representing an <see cref="UpdateSummaryResource"/> (backward-compat).
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        public virtual UpdateSummaryResource GetUpdateSummaryResource(ResourceIdentifier id)
            => throw new NotSupportedException("This method is obsolete. Please use GetHciClusterUpdateSummaryResource instead.");
    }
}
