// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.ResourceManager.Compute.Models
{
    public static partial class ArmComputeModelFactory
    {
        /// <summary> Initializes a new instance of CommunityGalleryInfo. </summary>
        /// <param name="publisherUri"> The link to the publisher website. Visible to all users. </param>
        /// <param name="publisherContact"> Community gallery publisher support email. The email address of the publisher. Visible to all users. </param>
        /// <param name="eula"> End-user license agreement for community gallery image. </param>
        /// <param name="publicNamePrefix"> The prefix of the gallery name that will be displayed publicly. Visible to all users. </param>
        /// <param name="communityGalleryEnabled"> Contains info about whether community gallery sharing is enabled. </param>
        /// <param name="publicNames"> Community gallery public name list. </param>
        /// <returns> A new <see cref="Models.CommunityGalleryInfo"/> instance for mocking. </returns>
        public static CommunityGalleryInfo CommunityGalleryInfo(Uri publisherUri = null, string publisherContact = null, string eula = null, string publicNamePrefix = null, bool? communityGalleryEnabled = null, IEnumerable<string> publicNames = null)
        {
            publicNames ??= new List<string>();

            return new CommunityGalleryInfo(publisherUri.AbsoluteUri, publisherContact, eula, publicNamePrefix, communityGalleryEnabled, publicNames?.ToList());
        }
    }
}
