// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    public partial class ShareableSearchServicePrivateLinkResourceProperties
    {
        /// <summary> The resource provider type for the resource that has been onboarded to private link service. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ShareablePrivateLinkResourcePropertiesType => Type;
    }
}
