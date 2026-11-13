// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class CommunityGalleryInfo
    {
        /// <summary>
        /// The link to the publisher website. Visible to all users.
        /// This property is obsolete; use <see cref="PublisherUriString"/> instead, which preserves the original string value as returned by the service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use " + nameof(PublisherUriString) + " instead.", false)]
        public Uri PublisherUri
        {
            get
            {
                if (Uri.TryCreate(PublisherUriString, UriKind.Absolute, out Uri result))
                {
                    return result;
                }
                return null;
            }
            set
            {
                if (value == null || !value.IsAbsoluteUri)
                {
                    PublisherUriString = null;
                }
                else
                {
                    PublisherUriString = value.OriginalString;
                }
            }
        }
    }
}
