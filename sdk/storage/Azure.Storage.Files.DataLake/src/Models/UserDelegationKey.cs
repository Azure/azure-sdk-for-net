// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A user delegation key
    /// </summary>
    public class UserDelegationKey
    {
        /// <summary>
        /// The Azure Active Directory object ID in GUID format.
        /// </summary>
        public string SignedObjectId { get; internal set; }

        /// <summary>
        /// The Azure Active Directory tenant ID in GUID format
        /// </summary>
        public string SignedTenantId { get; internal set; }

        /// <summary>
        /// The date-time the key is active
        /// </summary>
        public DateTimeOffset SignedStartsOn { get; internal set; }

        /// <summary>
        /// The date-time the key expires
        /// </summary>
        public DateTimeOffset SignedExpiresOn { get; internal set; }

        /// <summary>
        /// Abbreviation of the Azure Storage service that accepts the key
        /// </summary>
        public string SignedService { get; internal set; }

        /// <summary>
        /// The service version that created the key
        /// </summary>
        public string SignedVersion { get; internal set; }

        /// <summary>
        /// The delegated user tenant id in Azure AD. Return if DelegatedUserTid is specified.
        /// </summary>
        public string SignedDelegatedUserTenantId { get; internal set; }

        /// <summary>
        /// The key as a base64 string
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of UserDelegationKey instances.
        /// You can use DataLakeModelFactory.UserDelegationKey instead.
        /// </summary>
        internal UserDelegationKey() { }

        internal UserDelegationKey(Blobs.Models.UserDelegationKey blobUserDelegationKey)
        {
            SignedObjectId = blobUserDelegationKey.SignedObjectId;
            SignedTenantId = blobUserDelegationKey.SignedTenantId;
            SignedStartsOn = blobUserDelegationKey.SignedStartsOn;
            SignedExpiresOn = blobUserDelegationKey.SignedExpiresOn;
            SignedService = blobUserDelegationKey.SignedService;
            SignedVersion = blobUserDelegationKey.SignedVersion;
            Value = blobUserDelegationKey.Value;
            SignedDelegatedUserTenantId = blobUserDelegationKey.SignedDelegatedUserTenantId;
        }
    }
}
