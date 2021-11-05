// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.DeviceUpdate.Models
{
    /// <summary>
    /// Import manifest file.
    /// </summary>
    public class ImportManifestFile
    {
        public ImportManifestFile(string fileName, long sizeInBytes, Dictionary<HashType, string> hashes)
        {
            FileName = fileName;
            SizeInBytes = sizeInBytes;
            Hashes = hashes;
        }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File size in number of bytes.
        /// </summary>
        public long SizeInBytes { get; set; }

        /// <summary>
        /// Mapping of hashing algorithm to base64 encoded hash values.
        /// </summary>
        public Dictionary<HashType, string> Hashes { get; private set; }
    }
}
