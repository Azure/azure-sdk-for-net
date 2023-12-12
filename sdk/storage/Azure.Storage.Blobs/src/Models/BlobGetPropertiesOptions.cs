// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for getting properties for a blob.
    /// </summary>
    public class BlobGetPropertiesOptions
    {
        /// <summary>
        /// Optional.Valid only when Hierarchical Namespace is enabled for the account.If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs.The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? UserPrincipalName { get; set; }
    }
}