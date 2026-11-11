// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for getting the access control of a file or directory.
    /// </summary>
    public class DataLakePathGetAccessControlOptions
    {
        /// <summary>
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true",
        /// the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response
        /// headers will be transformed from Azure Active Directory Object IDs to User Principal Names.
        /// If "false", the values will be returned as Azure Active Directory Object IDs. The default
        /// value is false. Note that group and application Object IDs are not translated because they
        /// do not have unique friendly names.
        /// </summary>
        public bool? UserPrincipalName { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the path's access control.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
