// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// This is a temporary work-around until we get json support in the .NET code generator.
    /// I was not able to get the JsonSerializer to deserialize a Dictionary of string, List of PathItem correctly,
    /// the PathItem fields were always set to null.
    /// </summary>
    internal static class PathItemExtensions
    {
        internal static PathItem ToPathItem(this Dictionary<string, string> dictionary)
        {
            dictionary.TryGetValue("name", out string name);
            dictionary.TryGetValue("isDirectory", out string isDirectoryString);
            dictionary.TryGetValue("lastModified", out string lastModifiedString);
            dictionary.TryGetValue("etag", out string etagString);
            dictionary.TryGetValue("contentLength", out string contentLengthString);
            dictionary.TryGetValue("owner", out string owner);
            dictionary.TryGetValue("group", out string group);
            dictionary.TryGetValue("permissions", out string permissions);

            bool isDirectory = false;
            if (isDirectoryString != null)
            {
                isDirectory = bool.Parse(isDirectoryString);
            }

            DateTimeOffset lastModified = new DateTimeOffset();
            if (lastModifiedString != null)
            {
                lastModified = DateTimeOffset.Parse(lastModifiedString, CultureInfo.InvariantCulture);
            }

            ETag eTag = new ETag();
            if (etagString != null)
            {
                eTag = new ETag(etagString);
            }

            long contentLength = 0;
            if (contentLengthString != null)
            {
                contentLength = long.Parse(contentLengthString, CultureInfo.InvariantCulture);
            }

            PathItem pathItem = new PathItem()
            {
                Name = name,
                IsDirectory = isDirectory,
                LastModified = lastModified,
                ETag = eTag,
                ContentLength = contentLength,
                Owner = owner,
                Group = group,
                Permissions = permissions
            };
            return pathItem;
        }
    }
}
