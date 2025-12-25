// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ContainerService. </summary>
    public static partial class ContainerServiceExtensions
    {
        /// <summary> Gets an object representing a OSOptionProfileResource along with the instance operations that can be performed on it in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <returns> Returns a <see cref="OSOptionProfileResource" /> object. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileResource GetOSOptionProfile(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            return GetMockableContainerServiceSubscriptionResource(subscriptionResource).GetOSOptionProfile(location);
        }

        /// <summary>
        /// Gets an object representing an <see cref="OSOptionProfileResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OSOptionProfileResource.CreateResourceIdentifier" /> to create an <see cref="OSOptionProfileResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableContainerServiceArmClient.GetOSOptionProfileResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="OSOptionProfileResource"/> object. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileResource GetOSOptionProfileResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableContainerServiceArmClient(client).GetOSOptionProfileResource(id);
        }
    }
}
