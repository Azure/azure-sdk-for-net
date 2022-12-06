// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    internal static class PathExtensions
    {
        public static string GetParentPath(this string path, char delimiter = '/')
        {
            if (path == null)
            {
                throw new ArgumentException("Cannot get parent of null path");
            }

            path = path.TrimEnd(delimiter);

            int lastIndex = path.LastIndexOf(delimiter);
            if (lastIndex == -1)
            {
                return string.Empty;
            }
            return path.Substring(0, lastIndex);
        }
    }
}
