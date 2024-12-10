// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionIdentityDetails
    {
        /// <summary>
        /// ARM URL for User Assigned Identity.
        /// </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by UserAssignedIdentityArmUriString", false)]
        public Uri UserAssignedIdentityArmUri
        {
            get => string.IsNullOrEmpty(UserAssignedIdentityArmUriString) ? null : new Uri(UserAssignedIdentityArmUriString);
            set => UserAssignedIdentityArmUriString = value?.AbsoluteUri;
        }
    }
}
