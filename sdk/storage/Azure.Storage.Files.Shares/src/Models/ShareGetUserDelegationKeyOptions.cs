// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for Get User Delegation Key.
    /// </summary>
    public class ShareGetUserDelegationKeyOptions
    {
        /// <summary>
        /// Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </summary>
        public DateTimeOffset? StartsOn { get; set; }

        /// <summary>
        /// The delegated user tenant id in Azure AD.
        /// </summary>
        public string DelegatedUserTenantId { get; set; }
    }
}
