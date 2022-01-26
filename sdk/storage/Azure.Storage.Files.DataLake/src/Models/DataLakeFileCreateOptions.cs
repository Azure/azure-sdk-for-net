// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for creating a Data Lake file.
    /// </summary>
    public class DataLakeFileCreateOptions : DataLakePathCreateOptions
    {
        /// <summary>
        /// Optional encryption context that can be set the file.
        /// Encryption context is intended to store metadata that can be used to decrypt the blob.
        /// </summary>
        public string EncryptionContext { get; set; }
    }
}
