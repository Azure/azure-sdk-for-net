// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ContainerService. </summary>
    [CodeGenSuppress("GetOSOptionProfile", typeof(SubscriptionResource))]
    public static partial class ContainerServiceExtensions
    {
        /// <summary> Gets an object representing a OSOptionProfileResource along with the instance operations that can be performed on it in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <returns> Returns a <see cref="OSOptionProfileResource" /> object. </returns>
        public static OSOptionProfileResource GetOSOptionProfile(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            return GetMockableContainerServiceSubscriptionResource(subscriptionResource).GetOSOptionProfile(location);
        }
    }
}
