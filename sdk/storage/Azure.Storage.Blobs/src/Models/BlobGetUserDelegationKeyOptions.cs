// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Parameters for Get User Delegation Key.
    /// </summary>
    public class BlobGetUserDelegationKeyOptions
    {
        /// <summary>
        /// Constructor for BlobGetUserDelegationKeyOptions.
        /// </summary>
        public BlobGetUserDelegationKeyOptions(DateTimeOffset expiresOn)
        {
            ExpiresOn = expiresOn;
        }

        /// <summary>
        /// Expiration of the key's validity.  The time should be specified
        /// in UTC.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// Optional. Start time for the key's validity, with null indicating an
        /// immediate start.  The time should be specified in UTC.
        ///
        /// Note: If you set the start time to the current time, failures
        /// might occur intermittently for the first few minutes. This is due to different
        /// machines having slightly different current times (known as clock skew).
        /// </summary>
        public DateTimeOffset? StartsOn { get; set; }

        /// <summary>
        /// Optional. The delegated user tenant id in Azure AD.
        /// </summary>
        public string DelegatedUserTenantId { get; set; }
    }
}
