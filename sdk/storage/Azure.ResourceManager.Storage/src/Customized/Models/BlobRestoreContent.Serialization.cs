// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobRestoreContent
    {
        internal static BlobRestoreContent DeserializeBlobRestoreContent(JsonElement element)
        {
            DateTimeOffset timeToRestore = default;
            IList<BlobRestoreRange> blobRanges = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.Name.Equals("timeToRestore", StringComparison.OrdinalIgnoreCase))
                {
                    timeToRestore = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("blobRanges"))
                {
                    List<BlobRestoreRange> array = new List<BlobRestoreRange>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BlobRestoreRange.DeserializeBlobRestoreRange(item));
                    }
                    blobRanges = array;
                    continue;
                }
            }
            return new BlobRestoreContent(timeToRestore, blobRanges);
        }
    }
}
