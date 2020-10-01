// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Data Lake query error.
    /// </summary>
    public class DataLakeQueryError
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// If the error is a fatal error.
        /// </summary>
        public bool IsFatal { get; internal set; }

        /// <summary>
        /// The position of the error.
        /// </summary>
        public long Position { get; internal set; }

        internal DataLakeQueryError() { }
    }
}
