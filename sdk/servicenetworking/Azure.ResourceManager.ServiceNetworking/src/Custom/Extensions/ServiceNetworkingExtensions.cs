// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ServiceNetworking.Mocking;

namespace Azure.ResourceManager.ServiceNetworking
{
#pragma warning disable 0618
    /// <summary> A class to add extension methods to Azure.ResourceManager.ServiceNetworking. </summary>
    public static partial class ServiceNetworkingExtensions
    {
        /// <summary>
        /// Gets an object representing an <see cref="AssociationResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AssociationResource.CreateResourceIdentifier" /> to create an <see cref="AssociationResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableServiceNetworkingArmClient.GetAssociationResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="AssociationResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerAssociationResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AssociationResource GetAssociationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableServiceNetworkingArmClient(client).GetAssociationResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="FrontendResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FrontendResource.CreateResourceIdentifier" /> to create a <see cref="FrontendResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableServiceNetworkingArmClient.GetFrontendResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="FrontendResource"/> object. </returns>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerFrontendResource` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FrontendResource GetFrontendResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableServiceNetworkingArmClient(client).GetFrontendResource(id);
        }
    }
#pragma warning restore 0618
}
