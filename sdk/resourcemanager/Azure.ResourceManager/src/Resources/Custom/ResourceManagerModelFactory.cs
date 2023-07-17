// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class ResourceManagerModelFactory
    {
        /// <summary> Initializes a new instance of SubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.SubResource"/> instance for mocking. </returns>
        public static SubResource SubResource(ResourceIdentifier id = null)
        {
            return new SubResource(id);
        }

        /// <summary> Initializes a new instance of WritableSubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.WritableSubResource"/> instance for mocking. </returns>
        public static WritableSubResource WritableSubResource(ResourceIdentifier id = null)
        {
            return new WritableSubResource(id);
        }

        /// <summary> Initializes a new instance of LocationExpanded. </summary>
        /// <param name="id"> The fully qualified ID of the location. For example, /subscriptions/00000000-0000-0000-0000-000000000000/locations/westus. </param>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="name"> The location name. </param>
        /// <param name="locationType"> The location type. </param>
        /// <param name="displayName"> The display name of the location. </param>
        /// <param name="regionalDisplayName"> The display name of the location and its region. </param>
        /// <param name="metadata"> Metadata of the location, such as lat/long, paired region, and others. </param>
        /// <returns> A new <see cref="Resources.Models.LocationExpanded"/> instance for mocking. </returns>
        public static LocationExpanded LocationExpanded(string id, string subscriptionId, string name, LocationType? locationType, string displayName, string regionalDisplayName, LocationMetadata metadata)
        {
            return new LocationExpanded(id, subscriptionId, name, locationType, displayName, regionalDisplayName, metadata, null);
        }
    }
}
