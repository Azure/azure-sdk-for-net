// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class LocationExpanded
    {
        /// <summary>
        /// Convert LocationExpanded into a Location object.
        /// </summary>
        /// <param name="location"> The location to convert. </param>
        public static implicit operator AzureLocation(LocationExpanded location)
        {
            return new AzureLocation(location.Name, location.DisplayName);
        }
    }
}
