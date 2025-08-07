// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class CommunityGalleryInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri PublisherUri
        {
            get
            {
                if (Uri.TryCreate(PublisherUriString,UriKind.Absolute,out Uri result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
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
