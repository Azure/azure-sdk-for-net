// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
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
            get => throw new NotSupportedException("UserAssignedIdentityArmUri is deprecated, please use UserAssignedIdentityId instead.");
            set => throw new NotSupportedException("UserAssignedIdentityArmUri is deprecated, please use UserAssignedIdentityId instead.");
        }
    }
}
