// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Hci
{
    public static partial class HciExtensions
    {
        /// <summary>
        /// Gets an object representing an <see cref="OfferResource"/> (backward-compat).
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        public static OfferResource GetOfferResource(this ArmClient client, ResourceIdentifier id)
        {
            return (OfferResource)(object)GetHciClusterOfferResource(client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PublisherResource"/> (backward-compat).
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        public static PublisherResource GetPublisherResource(this ArmClient client, ResourceIdentifier id)
        {
            return (PublisherResource)(object)GetHciClusterPublisherResource(client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateResource"/> (backward-compat).
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        public static UpdateResource GetUpdateResource(this ArmClient client, ResourceIdentifier id)
        {
            return (UpdateResource)(object)GetHciClusterUpdateResource(client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateRunResource"/> (backward-compat).
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        public static UpdateRunResource GetUpdateRunResource(this ArmClient client, ResourceIdentifier id)
        {
            return (UpdateRunResource)(object)GetHciClusterUpdateRunResource(client, id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateSummaryResource"/> (backward-compat).
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        public static UpdateSummaryResource GetUpdateSummaryResource(this ArmClient client, ResourceIdentifier id)
        {
            return (UpdateSummaryResource)(object)GetHciClusterUpdateSummaryResource(client, id);
        }
    }
}
