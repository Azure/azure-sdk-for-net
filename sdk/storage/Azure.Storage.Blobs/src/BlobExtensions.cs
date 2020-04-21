// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Azure.Storage.Blobs.Models;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs
{
    internal static partial class BlobExtensions
    {
        internal static IDictionary<string, string> ToTagDictionary(this BlobTags blobTags)
        {
            if (blobTags?.BlobTagSet == null)
            {
                return null;
            }
            Dictionary<string, string> tags = new Dictionary<string, string>();
            foreach (BlobTag blobTag in blobTags.BlobTagSet)
            {
                tags[blobTag.Key] = blobTag.Value;
            }

            return tags;
        }

        internal static BlobTags ToBlobTags(this Tags tags)
        {
            BlobTags blobTags = new BlobTags();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                blobTags.BlobTagSet.Add(new BlobTag
                {
                    Key = tag.Key,
                    Value = tag.Value
                });
            }
            return blobTags;
        }

        internal static BlobItem ToBlobItem(this BlobItemInternal blobItemInternal)
        {
            if (blobItemInternal == null)
            {
                return null;
            }

            return new BlobItem
            {
                Name = blobItemInternal.Name,
                Deleted = blobItemInternal.Deleted,
                Snapshot = blobItemInternal.Snapshot,
                Properties = blobItemInternal.Properties,
                VersionId = blobItemInternal.VersionId,
                IsCurrentVersion = blobItemInternal.IsCurrentVersion,
                Metadata = blobItemInternal.Metadata?.Count > 0
                    ? blobItemInternal.Metadata
                    : null,
                Tags = blobItemInternal.BlobTags.ToTagDictionary()
            };
        }

        internal static IEnumerable<BlobItem> ToBlobItems(this IEnumerable<BlobItemInternal> blobItemInternals)
        {
            if (blobItemInternals == null)
            {
                return null;
            }

            List<BlobItem> blobItems = new List<BlobItem>();
            foreach (BlobItemInternal blobItemInternal in blobItemInternals)
            {
                blobItems.Add(blobItemInternal.ToBlobItem());
            }
            return blobItems;
        }

        internal static string ToTagsString(this Tags tags)
        {
            if (tags == null)
            {
                return null;
            }

            List<string> encodedTags = new List<string>();
            foreach (KeyValuePair<string, string> tag in tags)
            {
                encodedTags.Add($"{WebUtility.UrlEncode(tag.Key)}={WebUtility.UrlEncode(tag.Value)}");
            }
            return string.Join("&", encodedTags);
        }
    }
}
