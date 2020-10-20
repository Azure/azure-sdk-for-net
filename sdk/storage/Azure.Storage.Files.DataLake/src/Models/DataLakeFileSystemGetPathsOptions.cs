// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for <see cref="DataLakeFileSystemClient.GetPaths(DataLakeFileSystemGetPathsOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class DataLakeFileSystemGetPathsOptions
    {
        /// <summary>
        /// Optional.  Filters results to paths within the specified directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Optional.  If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// </summary>
        public bool Recursive { get; set; }

        /// <summary>
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </summary>
        public bool UserPrincipalName { get; set; }
    }
}
