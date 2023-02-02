// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal static class DataMovementExtensions
    {
        public static byte[] UriToByteArray(this StorageResource storageResource)
        {
            // Create Source Root
            byte[] byteArray;
            if (storageResource.CanProduceUri == ProduceUriType.ProducesUri)
            {
                Uri sourceUri = storageResource.Uri;
                byteArray = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}{1}{2}",
                    sourceUri.Authority,
                    Uri.SchemeDelimiter,
                    sourceUri.AbsolutePath).ToByteArray();
            }
            else
            {
                byteArray = storageResource.Path.ToByteArray();
            }
            return byteArray;
        }

        public static byte[] UriQueryToByteArray(this StorageResource storageResource)
        {
            // Create Source Root
            if (storageResource.CanProduceUri == ProduceUriType.ProducesUri)
            {
                Uri sourceUri = storageResource.Uri;
                return sourceUri.Query.ToByteArray();
            }
            return default;
        }

        public static byte[] ToByteArray(this string query)
        {
            // Convert query to byte array.
            return Encoding.Unicode.GetBytes(query);
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
