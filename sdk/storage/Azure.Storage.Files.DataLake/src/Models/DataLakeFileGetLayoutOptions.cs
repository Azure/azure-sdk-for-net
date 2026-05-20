// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for
    /// <see cref="DataLakeFileClient.GetLayout(DataLakeFileGetLayoutOptions, System.Threading.CancellationToken)"/> and
    /// <see cref="DataLakeFileClient.GetLayoutAsync(DataLakeFileGetLayoutOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class DataLakeFileGetLayoutOptions
    {
        /// <summary>
        /// If provided, returns layout only for the specified range.
        /// If not provided, returns the layout for the entire file.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on getting the file's properties and layout.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }
    }
}
