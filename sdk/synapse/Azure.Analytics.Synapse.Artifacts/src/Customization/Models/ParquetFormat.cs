// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The data stored in Parquet format. </summary>
    public partial class ParquetFormat : DatasetStorageFormat
    {
        /// <summary> Initializes a new instance of ParquetFormat. </summary>
        public ParquetFormat()
        {
            Type = "ParquetFormat";
        }
    }
}
