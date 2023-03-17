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
        // string to byte array
        public static byte[] ToByteArray(this string query, int? bufferSize = default)
        {
            bufferSize ??= query.Length;

            // Convert query to byte array.
            byte[] arr = new byte[bufferSize.Value];
            byte[] queryArr = Encoding.UTF8.GetBytes(query);
            Array.Copy(queryArr, arr, queryArr.Length);
            return arr;
        }

        // long to byte array
        public static byte[] ToByteArray(this long query, int bufferSize)
        {
            // Convert query to byte array.
            byte[] arr = new byte[bufferSize];
            byte[] queryArr = BitConverter.GetBytes(query);
            Array.Copy(queryArr, arr, queryArr.Length);
            return arr;
        }

        public static string ByteArrayToString(this byte[] bytes, long length)
        {
            return Encoding.UTF8.GetString(bytes, 0, (int)length);
        }

        public static long ByteArrayToLong(this byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0);
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
