// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for deleteing a Share.
    /// </summary>
    public class ShareDeleteOptions
    {
        /// <summary>
        /// A value indicating whether to delete a share's snapshots in addition
        /// to the share itself.
        /// </summary>
        public bool IncludeSnapshots { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on deleting the share.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ShareDeleteOptions()
        {
            IncludeSnapshots = true;
        }
    }
}
