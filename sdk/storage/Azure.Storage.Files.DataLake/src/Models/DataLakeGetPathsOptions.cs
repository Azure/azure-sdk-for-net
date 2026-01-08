// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for <see cref="DataLakeFileSystemClient.GetPathsAsync(DataLakeGetPathsOptions, System.Threading.CancellationToken)"/>
    /// and <see cref="DataLakeDirectoryClient.GetPathsAsync(DataLakeGetPathsOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class DataLakeGetPathsOptions
    {
        /// <summary>
        /// Filters results to paths within the specified directory.
        /// Not applicable for <see cref="DataLakeDirectoryClient.GetPathsAsync(DataLakeGetPathsOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// If true, all paths are listed; otherwise, only paths at the root of the filesystem are listed.
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

        /// <summary>
        /// Optional. A relative path within the specified directory where the listing will start from.
        /// For example, a recursive listing under directory folder1/folder2 with beginFrom as folder3/readmefile.txt
        /// will start listing from folder1/folder2/folder3/readmefile.txt. Please note that, multiple entity levels
        /// are supported for recursive listing. Non-recursive listing supports only one entity level.
        /// An error will appear if multiple entity levels are specified for non-recursive listing.
        /// </summary>
        public string StartFrom { get; set; }
    }
}
