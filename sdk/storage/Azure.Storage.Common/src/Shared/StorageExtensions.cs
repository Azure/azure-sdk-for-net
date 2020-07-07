// Copyright (c) Microsoft Corporation. All rights reserved.
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
    }
}
