// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing the ResourceGroup data model. </summary>
    public partial class ResourceGroupData : TrackedResource
    {
        /// <summary> Initializes a new instance of ResourceGroupData. </summary>
        /// <param name="location"> The location of the resource group. It cannot be changed after the resource group has been created. It must be one of the supported Azure locations. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public ResourceGroupData(string location) : base(location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
        }

        /// <summary> Initializes a new instance of ResourceGroupData. </summary>
        /// <param name="id"> The ID of the resource group. </param>
        /// <param name="name"> The name of the resource group. </param>
        /// <param name="type"> The type of the resource group. </param>
        /// <param name="properties"> The resource group properties. </param>
        /// <param name="location"> The location of the resource group. It cannot be changed after the resource group has been created. It must be one of the supported Azure locations. </param>
        /// <param name="managedBy"> The ID of the resource that manages this resource group. </param>
        /// <param name="tags"> The tags attached to the resource group. </param>
        internal ResourceGroupData(ResourceIdentifier id, string name, string type, ResourceGroupProperties properties, string location, string managedBy, IDictionary<string, string> tags)
            : base(id, name, type, tags, location)
        {
            Properties = properties;
            ManagedBy = managedBy;
        }

        /// <summary> The resource group properties. </summary>
        public ResourceGroupProperties Properties { get; set; }
        /// <summary> The ID of the resource that manages this resource group. </summary>
        public string ManagedBy { get; set; }
    }
}
