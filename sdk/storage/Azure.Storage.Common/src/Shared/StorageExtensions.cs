﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Shared
{
    internal static class StorageExtensions
    {
        public static string EscapePath(this string path)
        {
            if (path == null)
            {
                return null;
            }

            path = path.Trim('/');
            string[] split = path.Split('/');

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = Uri.EscapeDataString(split[i]);
            }

            return string.Join("/", split);
        }

        public static string UnescapePath(this string path)
        {
            if (path == null)
            {
                return null;
            }

            path = path.Trim('/');
            string[] split = path.Split('/');

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = Uri.UnescapeDataString(split[i]);
            }

            return string.Join("/", split);
        }

        public static string GenerateBlockId(long offset)
        {
            // TODO #8162 - Add in a random GUID so multiple simultaneous
            // uploads won't stomp on each other and the first to commit wins.
            // This will require some changes to our test framework's
            // RecordedClientRequestIdPolicy.
            byte[] id = new byte[48]; // 48 raw bytes => 64 byte string once Base64 encoded
            BitConverter.GetBytes(offset).CopyTo(id, 0);
            return Convert.ToBase64String(id);
        }
    }
}
