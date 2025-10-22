// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A user delegation key.
    /// </summary>
    public partial class UserDelegationKey
    {
        /// <summary>
        /// The Azure Active Directory object ID in GUID format.
        /// </summary>
        [CodeGenMember("SignedOid")]
        public string SignedObjectId { get; internal set; }

        /// <summary>
        /// The Azure Active Directory tenant ID in GUID format.
        /// </summary>
        [CodeGenMember("SignedTid")]
        public string SignedTenantId { get; internal set; }

        /// <summary>
        /// The date-time the key expires.
        /// </summary>
        [CodeGenMember("SignedExpiry")]
        public DateTimeOffset SignedExpiresOn { get; internal set; }

        /// <summary>
        /// The date-time the key is active.
        /// </summary>
        [CodeGenMember("SignedStart")]
        public DateTimeOffset SignedStartsOn { get; internal set; }

        /// <summary>
        /// Abbreviation of the Azure Storage service that accepts the key.
        /// </summary>
        public string SignedService { get; internal set; }

        /// <summary>
        /// The service version that created the key.
        /// </summary>
        public string SignedVersion { get; internal set; }

        /// <summary>
        /// The delegated user tenant id in Azure AD. Return if DelegatedUserTid is specified.
        /// </summary>
        [CodeGenMember("SignedDelegatedUserTid")]
        public string SignedDelegatedUserTenantId { get; internal set; }

        /// <summary>
        /// The key as a base64 string.
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal UserDelegationKey() { }
    }
}
