// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class GalleryImageVersionData
    {
        /// <summary> The UEFI settings of a gallery image version. </summary>
        [Obsolete("Use SecurityProfile instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GalleryImageVersionUefiSettings SecurityUefiSettings
        {
            get => SecurityProfile?.UefiSettings;
            set
            {
                SecurityProfile ??= new ImageVersionSecurityProfile();
                SecurityProfile.UefiSettings = value;
            }
        }
    }
}
