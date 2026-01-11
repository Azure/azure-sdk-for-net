// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    [CodeGenSuppress("GetOSOptionProfile")]
    public partial class MockableContainerServiceSubscriptionResource : ArmResource
    {
        /// <summary> Gets an object representing a OSOptionProfileResource along with the instance operations that can be performed on it in the SubscriptionResource. </summary>
        /// <param name="location"> The name of Azure region. </param>
        /// <returns> Returns a <see cref="OSOptionProfileResource" /> object. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual OSOptionProfileResource GetOSOptionProfile(AzureLocation location)
        {
            return new OSOptionProfileResource(Client, Id.AppendChildResource("locations", location).AppendChildResource("osOptions", "default"));
        }
    }
}
