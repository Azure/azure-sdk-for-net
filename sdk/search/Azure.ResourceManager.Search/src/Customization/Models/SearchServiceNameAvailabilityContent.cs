// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Search.Models
{
    /// <summary> Input of check name availability API. </summary>
    public partial class SearchServiceNameAvailabilityContent
    {
        /// <summary> The type of the resource whose name is to be validated. This value must always be 'searchServices'. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServiceResourceType ResourceType { get => SearchServiceResourceType.SearchServices; }
    }
}
