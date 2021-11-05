// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary> The ListFilesIncludeType. </summary>
    internal enum ListFilesIncludeType
    {
        /// <summary> Timestamps. </summary>
        Timestamps,
        /// <summary> Etag. </summary>
        Etag,
        /// <summary> Attributes. </summary>
        Attributes,
        /// <summary> PermissionKey. </summary>
        PermissionKey
    }
}
