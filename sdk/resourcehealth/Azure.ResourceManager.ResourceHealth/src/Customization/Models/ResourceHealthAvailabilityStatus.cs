// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ResourceHealth.Models
{
    /// <summary> Wrapper type that preserves the GA shape of availability status with Location and Properties. </summary>
    public partial class ResourceHealthAvailabilityStatus : ResourceData
    {
        private ResourceHealthAvailabilityStatus(ResourceIdentifier id, string name, ResourceType resourceType, AzureLocation? location, ResourceHealthAvailabilityStatusProperties properties)
            : base(id, name, resourceType, null)
        {
            Location = location;
            Properties = properties;
        }

        /// <summary> Azure Resource Manager geo location of the resource. </summary>
        public AzureLocation? Location { get; }

        /// <summary> Properties of availability state. </summary>
        public ResourceHealthAvailabilityStatusProperties Properties { get; }

        internal static ResourceHealthAvailabilityStatus FromData(ResourceHealthAvailabilityStatusData data)
        {
            if (data == null)
            {
                return null;
            }

            return new ResourceHealthAvailabilityStatus(data.Id, data.Name, data.Type.GetValueOrDefault(), data.Location, data.Properties);
        }
    }
}
