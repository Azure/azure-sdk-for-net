// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Data Lake Query Text Configuration.
    /// </summary>
    public abstract class DataLakeQueryTextConfiguration
    {
        /// <summary>
        /// Record Separator.
        /// </summary>
        public string RecordSeparator { get; set; }
    }
}
