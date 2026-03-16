// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    public partial class SearchServiceNameAvailabilityContent
    {
        /// <summary> The resource type of the search service. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServiceResourceType ResourceType
        {
            get => new SearchServiceResourceType(Type);
        }
    }
}
