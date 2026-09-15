// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.TrafficManager.Mocking
{
    public partial class MockableTrafficManagerArmClient
    {
        /// <summary> Gets an object representing a <see cref="TrafficManagerEndpointResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TrafficManagerEndpointResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetAzureEndpointTrafficManagerEndpointResource, GetExternalEndpointTrafficManagerEndpointResource, or GetNestedEndpointTrafficManagerEndpointResource instead.", false)]
        public virtual TrafficManagerEndpointResource GetTrafficManagerEndpointResource(ResourceIdentifier id)
        {
            return new TrafficManagerEndpointResource(Client, id);
        }
    }
}
