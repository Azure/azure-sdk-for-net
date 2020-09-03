// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Enum to specify when a file's ExpiriesOn time should be relative
    /// to.
    /// </summary>
    internal enum DataLakeFileExpirationOrigin
    {
        /// <summary>
        /// Files's ExpiriesOn property should be set relative to
        /// the file CreatedOn time.
        /// </summary>
        CreationTime,

        /// <summary>
        /// Files's ExpiriesOn property should be set relative to
        /// the current time.
        /// </summary>
        Now
    }
}
