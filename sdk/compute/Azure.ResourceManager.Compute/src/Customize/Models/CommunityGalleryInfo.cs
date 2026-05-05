// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class CommunityGalleryInfo
    {
        /// <summary> The link to the publisher website. Visible to all users. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PublisherUriString
        {
            get => PublisherUri?.AbsoluteUri;
            set => PublisherUri = value == null ? null : new Uri(value);
        }
    }
}
