// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
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

        /// <summary>
        /// Creates a new BlobProperties object backed by BlobPropertiesInternal.
        /// </summary>
        /// <param name="properties">
        /// The BlobPropertiesInternal returned with the reques
        /// </param>
        internal static BlobProperties ToBlobProperties(this BlobPropertiesInternal properties) =>
            new BlobProperties()
            {
                LastModified = properties.LastModified,
                CreatedOn = properties.CreatedOn,
                Metadata = properties.Metadata,
                ObjectReplicationDestinationPolicy = properties.ObjectReplicationPolicyId,
                ObjectReplicationSourceProperties = properties.ObjectReplicationRules.ToObjectReplicationIds(),
                BlobType = properties.BlobType,
                CopyCompletedOn = properties.CopyCompletedOn,
                CopyStatusDescription = properties.CopyStatusDescription,
                CopyId = properties.CopyId,
                CopyProgress = properties.CopyProgress,
                CopySource = properties.CopySource,
                CopyStatus = properties.CopyStatus,
                IsIncrementalCopy = properties.IsIncrementalCopy,
                DestinationSnapshot = properties.DestinationSnapshot,
                LeaseDuration = properties.LeaseDuration,
                LeaseState = properties.LeaseState,
                LeaseStatus = properties.LeaseStatus,
                ContentLength = properties.ContentLength,
                ContentType = properties.ContentType,
                ETag = properties.ETag,
                ContentHash = properties.ContentHash,
                ContentEncoding = properties.ContentEncoding,
                ContentDisposition = properties.ContentDisposition,
                ContentLanguage = properties.ContentLanguage,
                CacheControl = properties.CacheControl,
                BlobSequenceNumber = properties.BlobSequenceNumber,
                AcceptRanges = properties.AcceptRanges,
                BlobCommittedBlockCount = properties.BlobCommittedBlockCount,
                IsServerEncrypted = properties.IsServerEncrypted,
                EncryptionKeySha256 = properties.EncryptionKeySha256,
                EncryptionScope = properties.EncryptionScope,
                AccessTier = properties.AccessTier,
                AccessTierInferred = properties.AccessTierInferred,
                ArchiveStatus = properties.ArchiveStatus,
                AccessTierChangedOn = properties.AccessTierChangedOn,
                VersionId = properties.VersionId,
                IsCurrentVersion = properties.IsCurrentVersion,
                TagCount = properties.TagCount,
                ExpiresOn = properties.ExpiresOn,
                IsSealed = properties.IsSealed,
            };

        /// <summary>
        /// Internal. Parses Object Replication Policy ID from Rule ID and sets the Policy ID.
        /// </summary>
        /// <returns></returns>

        internal static IDictionary<string, IDictionary<string, string>> ToObjectReplicationIds(this IDictionary<string,string> OrIds)
        {
            if (OrIds == null)
            {
                return null;
            }
            if (OrIds.Count == 0 ||
                (OrIds.Count > 0 &&
                (OrIds.First().Key == "policy-id")))
            {
                return default;
            }
            IDictionary<string, IDictionary<string, string>> OrProperties = new Dictionary<string, IDictionary<string, string>>();
            foreach (KeyValuePair<string, string> status in OrIds)
            {
                string[] ParsedIds = status.Key.Split('_');
                if (OrProperties.ContainsKey(ParsedIds[0]))
                {
                    OrProperties[ParsedIds[0]].Add(ParsedIds[1], status.Value);
                }
                else
                {
                    IDictionary<string, string> NewRuleStatus = new Dictionary<string, string>();
                    NewRuleStatus.Add(ParsedIds[1], status.Value);
                    OrProperties.Add(ParsedIds[0], NewRuleStatus);
                }
            }
            return OrProperties;
        }
    }
}
