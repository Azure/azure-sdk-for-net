// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    internal static class DataMovementTestExtensions
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

        public static byte[] ToByteArray(this ushort query, int bufferSize)
        {
            // Convert query to byte array.
            byte[] arr = new byte[bufferSize];
            byte[] queryArr = BitConverter.GetBytes(query);
            Array.Copy(queryArr, arr, queryArr.Length);
            return arr;
        }
    }
}
