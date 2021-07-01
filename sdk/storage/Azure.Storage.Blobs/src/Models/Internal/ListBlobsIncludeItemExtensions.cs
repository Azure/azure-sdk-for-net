﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    internal partial class ListBlobsIncludeItemExtensions
    {
        public static string ToSerialString(this ListBlobsIncludeItem value) => value switch
        {
            ListBlobsIncludeItem.Copy => "copy",
            ListBlobsIncludeItem.Deleted => "deleted",
            ListBlobsIncludeItem.Metadata => "metadata",
            ListBlobsIncludeItem.Snapshots => "snapshots",
            ListBlobsIncludeItem.Uncommittedblobs => "uncommittedblobs",
            ListBlobsIncludeItem.Versions => "versions",
            ListBlobsIncludeItem.Tags => "tags",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ListBlobsIncludeItem value."),
        };

        public static ListBlobsIncludeItem ToListBlobsIncludeItem(this string value)
        {
            if (string.Equals(value, "copy", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Copy;
            if (string.Equals(value, "deleted", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Deleted;
            if (string.Equals(value, "metadata", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Metadata;
            if (string.Equals(value, "snapshots", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Snapshots;
            if (string.Equals(value, "uncommittedblobs", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Uncommittedblobs;
            if (string.Equals(value, "versions", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Versions;
            if (string.Equals(value, "tags", StringComparison.InvariantCultureIgnoreCase))
                return ListBlobsIncludeItem.Tags;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ListBlobsIncludeItem value.");
        }
    }
}
