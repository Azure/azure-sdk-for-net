// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    public static partial class ArmSearchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.SearchServiceNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The search service name to validate. </param>
        /// <param name="resourceType"> The type of the resource whose name is to be validated. </param>
        /// <returns> A new <see cref="Models.SearchServiceNameAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceNameAvailabilityContent SearchServiceNameAvailabilityContent(string name, SearchServiceResourceType resourceType)
        {
            // Preserve even default/custom GA values instead of substituting searchServices.
            return new SearchServiceNameAvailabilityContent(name, resourceType);
        }
    }
}
