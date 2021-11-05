// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specifies the option to copy file security descriptor from source file or to set it using the value which is defined by the header value of x-ms-file-permission or x-ms-file-permission-key.
    /// </summary>
    [CodeGenModel("PermissionCopyModeType")]
    public enum PermissionCopyMode
    {
        /// <summary>
        /// source
        /// </summary>
        Source,

        /// <summary>
        /// override
        /// </summary>
        Override
    }
}
