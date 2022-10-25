// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal static class DataMovementExtensions
    {
        public static string ToLocalPathString(this List<string> path)
        {
            return string.Join(@"\", path);
        }

        public static string ToBlobPathString(this List<string> path)
        {
            return string.Join("/", path);
        }

        internal static StorageResourceProperties ToStorageResourceProperties(this FileInfo fileInfo)
        {
            return new StorageResourceProperties(
                lastModified: fileInfo.LastWriteTimeUtc,
                createdOn: fileInfo.CreationTimeUtc,
                contentLength: fileInfo.Length,
                lastAccessed: fileInfo.LastAccessTimeUtc,
                resourceType: StorageResourceType.LocalFile);
        }
    }
}
