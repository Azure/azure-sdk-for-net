// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Mocking;

namespace Azure.ResourceManager.Hci
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Hci. </summary>
    public static partial class HciExtensions
    {
        /// <summary>
        /// Gets an object representing an <see cref="OfferResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OfferResource.CreateResourceIdentifier" /> to create an <see cref="OfferResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableHciArmClient.GetOfferResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="OfferResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOfferResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OfferResource GetOfferResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableHciArmClient(client).GetOfferResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PublisherResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PublisherResource.CreateResourceIdentifier" /> to create a <see cref="PublisherResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableHciArmClient.GetPublisherResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PublisherResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisherResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PublisherResource GetPublisherResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableHciArmClient(client).GetPublisherResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateRunResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UpdateRunResource.CreateResourceIdentifier" /> to create an <see cref="UpdateRunResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableHciArmClient.GetUpdateRunResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="UpdateRunResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateRunResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateRunResource GetUpdateRunResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableHciArmClient(client).GetUpdateRunResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateSummaryResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UpdateSummaryResource.CreateResourceIdentifier" /> to create an <see cref="UpdateSummaryResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableHciArmClient.GetUpdateSummaryResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="UpdateSummaryResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummaryResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateSummaryResource GetUpdateSummaryResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableHciArmClient(client).GetUpdateSummaryResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UpdateResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UpdateResource.CreateResourceIdentifier" /> to create an <see cref="UpdateResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableHciArmClient.GetUpdateResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="UpdateResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateResource GetUpdateResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableHciArmClient(client).GetUpdateResource(id);
        }
    }
}
