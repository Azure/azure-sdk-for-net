// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// Customizes validation of the resource name since default resource name of the TrafficManagerEndpoint has a template parameter baked in.
    /// </summary>
    public partial class TrafficManagerEndpointResource : ArmResource
    {
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            string expectedResourceType = ResourceType.ToString().Replace("{endpointType}", id.ResourceType.GetLastType());

            if (id.ResourceType != expectedResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, expectedResourceType), nameof(id));
        }
    }
}
