// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionIdentityDetails
    {
        /// <summary>
        /// ARM URL for User Assigned Identity.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by UserAssignedIdentityId", false)]
        public Uri UserAssignedIdentityArmUri
        {
            get => string.IsNullOrEmpty(UserAssignedIdentityId) ? null : new Uri(UserAssignedIdentityId);
            set => UserAssignedIdentityId = new(value?.AbsoluteUri);
        }
    }
}
