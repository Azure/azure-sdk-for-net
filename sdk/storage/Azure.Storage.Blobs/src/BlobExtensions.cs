// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using Azure.Storage.Blobs.Models;
using Tags = System.Collections.Generic.IDictionary<string, string>;
using Azure.Core;
using System.IO;
using System.Globalization;
using System.ComponentModel;

namespace Azure.Storage.Blobs
{
    internal static partial class BlobExtensions
    {
        #region Tags
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
            if (tags == null)
            {
                return null;
            }
            IEnumerable<BlobTag> blobTags = tags.Select(tag => new BlobTag(tag.Key, tag.Value));
            return new BlobTags(blobTags);
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

        internal static TaggedBlobItem ToBlobTagItem(this FilterBlobItem filterBlobItem)
        {
            if (filterBlobItem == null)
            {
                return null;
            }

            return new TaggedBlobItem
            {
                BlobName = filterBlobItem.Name,
                BlobContainerName = filterBlobItem.ContainerName,
                Tags = filterBlobItem.Tags.ToTagDictionary()
            };
        }

        internal static List<TaggedBlobItem> ToBlobTagItems(this IEnumerable<FilterBlobItem> filterBlobItems)
        {
            if (filterBlobItems == null)
            {
                return null;
            }

            List<TaggedBlobItem> list = new List<TaggedBlobItem>();

            foreach (FilterBlobItem filterBlobItem in filterBlobItems)
            {
                list.Add(filterBlobItem.ToBlobTagItem());
            }

            return list;
        }
        #endregion

        #region ORS
        /// <summary>
        /// Internal. Parses Object Replication Policy ID from Rule ID and sets the Policy ID for source blobs.
        /// </summary>
        /// <param name="OrIds">
        /// Unparsed Object Replication headers.
        /// For source blobs, the dictionary will contain keys that contain the policy id and rule id separated
        /// by a underscore (e.g. policyId_ruleId). The value of these keys will be the replication status (e.g. Complete, Failed).
        /// For destination blobs, the dictionary will contain one entry where the key will be "policy-id"
        /// and the value will be the destination policy id. No parsing will be required for this.
        /// </param>
        /// <returns>
        /// If the blob has object replication policy(s) applied and is the source blob, this method will return a
        /// List of <see cref="ObjectReplicationPolicy"/>, which contains the Policy ID and the respective
        /// rule(s) and replication status(s) for each policy.
        /// If the blob has object replication policy applied and is the destination blob,
        /// this method will return default as the policy id should be set in ObjectReplicationDestinationPolicyId
        /// (e.g. <see cref="BlobProperties.ObjectReplicationDestinationPolicyId"/>,<see cref="BlobDownloadDetails.ObjectReplicationDestinationPolicyId"/>).
        /// </returns>
        internal static IList<ObjectReplicationPolicy> ParseObjectReplicationIds(this IDictionary<string, string> OrIds)
        {
            try
            {
                // If the dictionary contains a key with policy id, we are not required to do any parsing since
                // the policy id should already be stored in the ObjectReplicationDestinationPolicyId.
                KeyValuePair<string, string> destPolicy = OrIds.Single(id => (id.Key == "policy-id"));
                return default;
            }
            catch (Exception)
            {
                // If an exception is thrown by Single then we have confirmed that there's not a policy id already
                // stored in the ObjectReplicationDestinationPolicyId and that we have the unparsed
                // Object Replication headers from the source blob.
            }
            List<ObjectReplicationPolicy> OrProperties = new List<ObjectReplicationPolicy>();
            foreach (KeyValuePair<string, string> status in OrIds)
            {
                string[] parsedIds = status.Key.Split('_');
                int policyIndex = OrProperties.FindIndex(policy => policy.PolicyId == parsedIds[0]);
                if (policyIndex > -1)
                {
                    OrProperties[policyIndex].Rules.Add(new ObjectReplicationRule()
                    {
                        RuleId = parsedIds[1],
                        ReplicationStatus = (ObjectReplicationStatus)Enum.Parse(typeof(ObjectReplicationStatus), status.Value, true)
                    });
                }
                else
                {
                    IList<ObjectReplicationRule> NewRuleStatus = new List<ObjectReplicationRule>();
                    NewRuleStatus.Add(new ObjectReplicationRule()
                    {
                        RuleId = parsedIds[1],
                        ReplicationStatus = (ObjectReplicationStatus)Enum.Parse(typeof(ObjectReplicationStatus), status.Value, true)
                    });
                    OrProperties.Add(new ObjectReplicationPolicy()
                    {
                        PolicyId = parsedIds[0],
                        Rules = NewRuleStatus
                    });
                }
            }
            return OrProperties;
        }

        /// <summary>
        /// Internal. Parses Object Replication Policy ID from Rule ID and sets the Policy ID for source blobs.
        /// </summary>
        /// <param name="OrMetadata">
        /// Unparsed Object Replication headers.
        /// For source blobs, the dictionary will contain keys that are prefixed with "or-" and followed by the
        /// policy id and rule id separated by a underscore (e.g. or-policyId_ruleId).
        /// The value of this metadata key will be the replication status (e.g. Complete, Failed).
        /// </param>
        /// <returns>
        /// If the blob has object replication policy(s) applied and is the source blob, this method will return a
        /// List of <see cref="ObjectReplicationPolicy"/>, which contains the Policy ID and the respective
        /// rule(s) and replication status(s) for each policy.
        /// </returns>
        internal static IList<ObjectReplicationPolicy> ParseObjectReplicationMetadata(this IReadOnlyDictionary<string, string> OrMetadata)
        {
            List<ObjectReplicationPolicy> OrProperties = new List<ObjectReplicationPolicy>();
            foreach (KeyValuePair<string, string> status in OrMetadata)
            {
                string[] parsedIds = status.Key.Split('_');
                if (parsedIds[0].StartsWith("or-", System.StringComparison.InvariantCulture))
                {
                    parsedIds[0] = parsedIds[0].Substring("or-".Length);
                }
                int policyIndex = OrProperties.FindIndex(policy => policy.PolicyId == parsedIds[0]);
                if (policyIndex > -1)
                {
                    OrProperties[policyIndex].Rules.Add(new ObjectReplicationRule()
                    {
                        RuleId = parsedIds[1],
                        ReplicationStatus = (ObjectReplicationStatus)Enum.Parse(typeof(ObjectReplicationStatus), status.Value, true)
                    });
                }
                else
                {
                    IList<ObjectReplicationRule> NewRuleStatus = new List<ObjectReplicationRule>();
                    NewRuleStatus.Add(new ObjectReplicationRule()
                    {
                        RuleId = parsedIds[1],
                        ReplicationStatus = (ObjectReplicationStatus)Enum.Parse(typeof(ObjectReplicationStatus), status.Value, true)
                    });
                    OrProperties.Add(new ObjectReplicationPolicy()
                    {
                        PolicyId = parsedIds[0],
                        Rules = NewRuleStatus
                    });
                }
            }
            return OrProperties;
        }
        #endregion

        #region ToRehydratePriority
        internal static RehydratePriority? ToRehydratePriority(this string rehydratePriority)
        {
            if (rehydratePriority == null)
            {
                return null;
            }

            if (rehydratePriority == RehydratePriority.High.ToString())
            {
                return RehydratePriority.High;
            }
            else if (rehydratePriority == RehydratePriority.Standard.ToString())
            {
                return RehydratePriority.Standard;
            }
            else
            {
                throw new ArgumentException($"Unknown Rehydrate Priority value: {rehydratePriority}");
            }
        }
        #endregion

        #region ToAccountInfo
        internal static AccountInfo ToAccountInfo(this ResponseWithHeaders<ServiceGetAccountInfoHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new AccountInfo
            {
                SkuName = response.Headers.SkuName.GetValueOrDefault(),
                AccountKind = response.Headers.AccountKind.GetValueOrDefault(),
                IsHierarchicalNamespaceEnabled = response.Headers.IsHierarchicalNamespaceEnabled.GetValueOrDefault()
            };
        }

        internal static AccountInfo ToAccountInfo(this ResponseWithHeaders<BlobGetAccountInfoHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new AccountInfo
            {
                SkuName = response.Headers.SkuName.GetValueOrDefault(),
                AccountKind = response.Headers.AccountKind.GetValueOrDefault(),
                IsHierarchicalNamespaceEnabled = response.Headers.IsHierarchicalNamespaceEnabled.GetValueOrDefault()
            };
        }

        internal static AccountInfo ToAccountInfo(this ResponseWithHeaders<ContainerGetAccountInfoHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new AccountInfo
            {
                SkuName = response.Headers.SkuName.GetValueOrDefault(),
                AccountKind = response.Headers.AccountKind.GetValueOrDefault(),
                IsHierarchicalNamespaceEnabled = response.Headers.IsHierarchicalNamespaceEnabled.GetValueOrDefault()
            };
        }
        #endregion

        #region ToBlobContainerInfo
        internal static BlobContainerInfo ToBlobContainerInfo(this ResponseWithHeaders<ContainerCreateHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContainerInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }
        #endregion

        #region ToBlobContainerAccessPolicy
        internal static BlobContainerAccessPolicy ToBlobContainerAccessPolicy(
            this ResponseWithHeaders<IReadOnlyList<BlobSignedIdentifier>, ContainerGetAccessPolicyHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContainerAccessPolicy
            {
                BlobPublicAccess = response.Headers.BlobPublicAccess.GetValueOrDefault(),
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                SignedIdentifiers = response.Value.ToList()
            };
        }
        #endregion

        #region ToBlobContainerInfo
        internal static BlobContainerInfo ToBlobContainerInfo(this ResponseWithHeaders<ContainerSetAccessPolicyHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new BlobContainerInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
            };
        }

        internal static BlobContainerInfo ToBlobContainerInfo(this ResponseWithHeaders<ContainerSetMetadataHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new BlobContainerInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
            };
        }
        #endregion

        #region ToBlobContentInfo
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<AppendBlobCreateHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContentInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                VersionId = response.Headers.VersionId,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope,
                //BlobSequenceNumber is not returned by Append Blobs.
            };
        }

        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<PageBlobCreateHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContentInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                VersionId = response.Headers.VersionId,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope,
                // Create Page Blob does not return BlobSequenceNumber.
            };
        }
        #endregion

        #region ToBlobAppendInfo
        internal static BlobAppendInfo ToBlobAppendInfo(this ResponseWithHeaders<AppendBlobAppendBlockHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobAppendInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                BlobAppendOffset = response.Headers.BlobAppendOffset,
                BlobCommittedBlockCount = response.Headers.BlobCommittedBlockCount.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope
            };
        }

        internal static BlobAppendInfo ToBlobAppendInfo(this ResponseWithHeaders<AppendBlobAppendBlockFromUrlHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobAppendInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                BlobAppendOffset = response.Headers.BlobAppendOffset,
                BlobCommittedBlockCount = response.Headers.BlobCommittedBlockCount.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope
            };
        }
        #endregion

        #region ToBlobInfo
        internal static BlobInfo ToBlobInfo(this ResponseWithHeaders<AppendBlobSealHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // BlobSequenceNumber does not apply to Append Blobs.
                // Seal Append Blob does not return VersionId
            };
        }
        #endregion

        #region ToPageInfo
        internal static PageInfo ToPageInfo(this ResponseWithHeaders<PageBlobUploadPagesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault(),
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope
            };
        }

        internal static PageInfo ToPageInfo(this ResponseWithHeaders<PageBlobClearPagesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault(),
                // Clear Page Blob does not return EncryptionKeySha256.
                // Clear Page Blob does not return EncryptionScope.
            };
        }

        internal static PageInfo ToPageInfo(this ResponseWithHeaders<PageBlobUploadPagesFromURLHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault(),
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope
            };
        }
        #endregion

        #region ToPageRangesInfo
        internal static PageRangesInfo ToPageRangesInfo(this ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageRangesInfo
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                BlobContentLength = response.Headers.BlobContentLength.GetValueOrDefault(),
                PageRanges = response.Value.PageRange.Select(r => r.ToHttpRange()).ToList(),
                ClearRanges = response.Value.ClearRange.Select(r => r.ToHttpRange()).ToList(),
            };
        }

        internal static PageRangesInfo ToPageRangesInfo(this ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageRangesInfo
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                BlobContentLength = response.Headers.BlobContentLength.GetValueOrDefault(),
                PageRanges = response.Value.PageRange.Select(r => r.ToHttpRange()).ToList(),
                ClearRanges = response.Value.ClearRange.Select(r => r.ToHttpRange()).ToList(),
            };
        }

        internal static HttpRange ToHttpRange(this PageRange pageRange)
            => new HttpRange(
                offset: pageRange.Start,
                length: pageRange.End - pageRange.Start + 1);

        internal static HttpRange ToHttpRange(this ClearRange clearRange)
            => new HttpRange(
                offset: clearRange.Start,
                length: clearRange.End - clearRange.Start + 1);

        #endregion

        #region ToPageBlobInfo
        internal static PageBlobInfo ToPageBlobInfo(this ResponseWithHeaders<PageBlobResizeHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageBlobInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault()
            };
        }

        internal static PageBlobInfo ToPageBlobInfo(this ResponseWithHeaders<PageBlobUpdateSequenceNumberHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PageBlobInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault()
            };
        }
        #endregion

        #region ToBlockInfo
        internal static BlockInfo ToBlockInfo(this ResponseWithHeaders<BlockBlobStageBlockHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlockInfo
            {
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope
            };
        }

        internal static BlockInfo ToBlockInfo(this ResponseWithHeaders<BlockBlobStageBlockFromURLHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlockInfo
            {
                ContentHash = response.Headers.ContentMD5,
                ContentCrc64 = response.Headers.XMsContentCrc64,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope
            };
        }
        #endregion

        #region ToBlobContentInfo
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<BlockBlobCommitBlockListHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContentInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                VersionId = response.Headers.VersionId,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope,
                // BlobSequenceNumber does not apply to Block Blobs.
            };
        }

        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<BlockBlobPutBlobFromUrlHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContentInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                VersionId = response.Headers.VersionId,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope,
                // BlobSequenceNumber is not returned for Block Blobs.
            };
        }

        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<BlockBlobUploadHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContentInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                VersionId = response.Headers.VersionId,
                EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                EncryptionScope = response.Headers.EncryptionScope,
                // BlobSequenceNumber is not returned for Block Blobs.
            };
        }
        #endregion

        #region ToBlockList
        internal static BlockList ToBlockList(this ResponseWithHeaders<BlockList, BlockBlobGetBlockListHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlockList
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                ContentType = response.Headers.ContentType,
                BlobContentLength = response.Headers.BlobContentLength.GetValueOrDefault(),
                CommittedBlocks = response.Value.CommittedBlocks,
                UncommittedBlocks = response.Value.UncommittedBlocks
            };
        }
        #endregion

        #region ToBlobSnapshotInfo
        internal static BlobSnapshotInfo ToBlobSnapshotInfo(this ResponseWithHeaders<BlobCreateSnapshotHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobSnapshotInfo
            {
                Snapshot = response.Headers.Snapshot,
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                VersionId = response.Headers.VersionId,
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault()
            };
        }
        #endregion

        #region ToBlobInfo
        internal static BlobInfo ToBlobInfo(this ResponseWithHeaders<BlobSetMetadataHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // Set Metadata does not return BlobSequenceNumber.
                VersionId = response.Headers.VersionId
            };
        }

        internal static BlobInfo ToBlobInfo(this ResponseWithHeaders<BlobSetHttpHeadersHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // Set HTTP Headers does not return BlobSequenceNumber.
                // Set HTTP Headers does not returnVersionId.
            };
        }
        #endregion

        #region ToBlobProperties
        internal static BlobProperties ToBlobProperties(this ResponseWithHeaders<BlobGetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy();
            immutabilityPolicy.ExpiresOn = response.Headers.ImmutabilityPolicyExpiresOn;
            immutabilityPolicy.PolicyMode = response.Headers.ImmutabilityPolicyMode;

            return new BlobProperties(
                lastModified: response.Headers.LastModified.GetValueOrDefault(),
                createdOn: response.Headers.CreationTime.GetValueOrDefault(),
                metadata: response.Headers.Metadata,
                objectReplicationDestinationPolicyId: response.Headers.ObjectReplicationPolicyId,
                objectReplicationSourceProperties:
                    response.Headers.ObjectReplicationRules?.Count > 0
                    ? BlobExtensions.ParseObjectReplicationIds(response.Headers.ObjectReplicationRules)
                    : null,
                blobType: response.Headers.BlobType.GetValueOrDefault(),
                copyCompletedOn: response.Headers.CopyCompletionTime.GetValueOrDefault(),
                copyStatusDescription: response.Headers.CopyStatusDescription,
                copyId: response.Headers.CopyId,
                copyProgress: response.Headers.CopyProgress,
                copySource: response.Headers.CopySource == null ? null : new Uri(response.Headers.CopySource),
                blobCopyStatus: response.Headers.CopyStatus,
                isIncrementalCopy: response.Headers.IsIncrementalCopy.GetValueOrDefault(),
                destinationSnapshot: response.Headers.DestinationSnapshot,
                leaseDuration: response.Headers.LeaseDuration.GetValueOrDefault(),
                leaseState: response.Headers.LeaseState.GetValueOrDefault(),
                leaseStatus: response.Headers.LeaseStatus.GetValueOrDefault(),
                contentLength: response.Headers.ContentLength.GetValueOrDefault(),
                contentType: response.Headers.ContentType,
                eTag: response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                contentHash: response.Headers.ContentMD5,
                contentEncoding: response.Headers.ContentEncoding,
                contentDisposition: response.Headers.ContentDisposition,
                contentLanguage: response.Headers.ContentLanguage,
                cacheControl: response.Headers.CacheControl,
                blobSequenceNumber: response.Headers.BlobSequenceNumber.GetValueOrDefault(),
                acceptRanges: response.Headers.AcceptRanges,
                blobCommittedBlockCount: response.Headers.BlobCommittedBlockCount.GetValueOrDefault(),
                isServerEncrypted: response.Headers.IsServerEncrypted.GetValueOrDefault(),
                encryptionKeySha256: response.Headers.EncryptionKeySha256,
                encryptionScope: response.Headers.EncryptionScope,
                accessTier: response.Headers.AccessTier,
                accessTierInferred: response.Headers.AccessTierInferred.GetValueOrDefault(),
                archiveStatus: response.Headers.ArchiveStatus,
                accessTierChangedOn: response.Headers.AccessTierChangeTime.GetValueOrDefault(),
                versionId: response.Headers.VersionId,
                isLatestVersion: response.Headers.IsCurrentVersion.GetValueOrDefault(),
                tagCount: response.Headers.TagCount.GetValueOrDefault(),
                expiresOn: response.Headers.ExpiresOn.GetValueOrDefault(),
                isSealed: response.Headers.IsSealed.GetValueOrDefault(),
                rehydratePriority: response.Headers.RehydratePriority,
                lastAccessed: response.Headers.LastAccessed.GetValueOrDefault(),
                immutabilityPolicy: immutabilityPolicy,
                hasLegalHold: response.Headers.LegalHold.GetValueOrDefault());
        }
        #endregion

        #region ToBlobCopyInfo
        internal static BlobCopyInfo ToBlobCopyInfo(this ResponseWithHeaders<BlobCopyFromURLHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobCopyInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                VersionId = response.Headers.VersionId,
                CopyId = response.Headers.CopyId,
                CopyStatus = CopyStatusExtensions.ToCopyStatus(response.Headers.CopyStatus),
                EncryptionScope = response.Headers.EncryptionScope
            };
        }

        internal static BlobCopyInfo ToBlobCopyInfo(this ResponseWithHeaders<BlobStartCopyFromURLHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobCopyInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                VersionId = response.Headers.VersionId,
                CopyId = response.Headers.CopyId,
                CopyStatus = response.Headers.CopyStatus.GetValueOrDefault()
            };
        }

        internal static BlobCopyInfo ToBlobCopyInfo(this ResponseWithHeaders<PageBlobCopyIncrementalHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobCopyInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // Page Blob Copy Incremental does not return VersionId.
                CopyId = response.Headers.CopyId,
                CopyStatus = response.Headers.CopyStatus.GetValueOrDefault()
            };
        }
        #endregion

        #region ToBlobDownloadStreamingResult
        internal static BlobDownloadStreamingResult ToBlobDownloadStreamingResult(this ResponseWithHeaders<Stream, BlobDownloadHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            response.GetRawResponse().Headers.ExtractMultiHeaderDownloadProperties(out var metadata, out var objectReplicationRules);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy();
            immutabilityPolicy.ExpiresOn = response.Headers.ImmutabilityPolicyExpiresOn;
            immutabilityPolicy.PolicyMode = response.Headers.ImmutabilityPolicyMode;

            return new BlobDownloadStreamingResult
            {
                Content = response.Value,
                Details = new BlobDownloadDetails
                {
                    BlobType = response.Headers.BlobType.GetValueOrDefault(),
                    ContentLength = response.Headers.ContentLength.GetValueOrDefault(),
                    ContentType = response.Headers.ContentType,
                    ContentHash = response.Headers.ContentMD5,
                    LastModified = response.Headers.LastModified.GetValueOrDefault(),
                    Metadata = metadata,
                    ContentRange = response.Headers.ContentRange,
                    ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                    ContentEncoding = response.Headers.ContentEncoding,
                    CacheControl = response.Headers.CacheControl,
                    ContentDisposition = response.Headers.ContentDisposition,
                    ContentLanguage = response.Headers.ContentLanguage,
                    BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault(),
                    CopyCompletedOn = response.Headers.CopyCompletionTime.GetValueOrDefault(),
                    CopyStatusDescription = response.Headers.CopyStatusDescription,
                    CopyId = response.Headers.CopyId,
                    CopyProgress = response.Headers.CopyProgress,
                    CopySource = response.Headers.CopySource == null ? null : new Uri(response.Headers.CopySource),
                    CopyStatus = response.Headers.CopyStatus.GetValueOrDefault(),
                    LeaseDuration = response.Headers.LeaseDuration ?? LeaseDurationType.Infinite,
                    LeaseStatus = response.Headers.LeaseStatus ?? LeaseStatus.Unlocked,
                    LeaseState = response.Headers.LeaseState.GetValueOrDefault(),
                    AcceptRanges = response.Headers.AcceptRanges,
                    BlobCommittedBlockCount = response.Headers.BlobCommittedBlockCount.GetValueOrDefault(),
                    IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                    EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                    EncryptionScope = response.Headers.EncryptionScope,
                    BlobContentHash = response.Headers.BlobContentMD5,
                    TagCount = response.Headers.TagCount.GetValueOrDefault(),
                    VersionId = response.Headers.VersionId,
                    IsSealed = response.Headers.IsSealed.GetValueOrDefault(),
                    ObjectReplicationSourceProperties
                        = objectReplicationRules?.Count > 0
                        ? ParseObjectReplicationIds(objectReplicationRules)
                        : null,
                    ObjectReplicationDestinationPolicyId = response.Headers.ObjectReplicationPolicyId,
                    LastAccessed = response.Headers.LastAccessed.GetValueOrDefault(),
                    ImmutabilityPolicy = immutabilityPolicy,
                    HasLegalHold = response.Headers.LegalHold.GetValueOrDefault(),
                    CreatedOn = response.Headers.CreationTime.GetValueOrDefault()
                }
            };
        }
        #endregion

        #region ToBlobDownloadInfo
        internal static BlobDownloadInfo ToBlobDownloadInfo(ResponseWithHeaders<Stream, BlobQueryHeaders> response, Stream stream)
        {
            if (response == null)
            {
                return null;
            }

            var blobType = response.Headers.BlobType.GetValueOrDefault();
            var contentLength = response.Headers.ContentLength.GetValueOrDefault();
            var contentType = response.Headers.ContentType;
            var contentHash = response.Headers.ContentMD5;
            return new BlobDownloadInfo
            {
                BlobType = blobType,
                ContentLength = contentLength,
                Content = stream,
                ContentType = contentType,
                ContentHash = contentHash,
                Details = new BlobDownloadDetails
                {
                    BlobType = blobType,
                    ContentLength = contentLength,
                    ContentType = contentType,
                    ContentHash = contentHash,
                    LastModified = response.Headers.LastModified.GetValueOrDefault(),
                    Metadata = response.Headers.Metadata.ToMetadata(),
                    ContentRange = response.Headers.ContentRange,
                    ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                    ContentEncoding = response.Headers.ContentEncoding,
                    CacheControl = response.Headers.CacheControl,
                    ContentDisposition = response.Headers.ContentDisposition,
                    ContentLanguage = response.Headers.ContentLanguage,
                    BlobSequenceNumber = response.Headers.BlobSequenceNumber.GetValueOrDefault(),
                    CopyCompletedOn = response.Headers.CopyCompletionTime.GetValueOrDefault(),
                    CopyStatusDescription = response.Headers.CopyStatusDescription,
                    CopyId = response.Headers.CopyId,
                    CopyProgress = response.Headers.CopyProgress,
                    CopySource = response.Headers.CopySource == null ? null : new Uri(response.Headers.CopySource),
                    CopyStatus = response.Headers.CopyStatus.GetValueOrDefault(),
                    LeaseDuration = response.Headers.LeaseDuration ?? LeaseDurationType.Infinite,
                    LeaseState = response.Headers.LeaseState.GetValueOrDefault(),
                    AcceptRanges = response.Headers.AcceptRanges,
                    BlobCommittedBlockCount = response.Headers.BlobCommittedBlockCount.GetValueOrDefault(),
                    IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                    EncryptionKeySha256 = response.Headers.EncryptionKeySha256,
                    EncryptionScope = response.Headers.EncryptionScope,
                    BlobContentHash = response.Headers.BlobContentMD5
                }
            };
        }

        private static void ExtractMultiHeaderDownloadProperties(this ResponseHeaders headers, out IDictionary<string, string> metadata, out IDictionary<string, string> objectReplicationRules)
        {
            metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            objectReplicationRules = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (HttpHeader item in headers)
            {
                if (item.Name.StartsWith(Constants.Blob.MetadataHeaderPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    metadata.Add(item.Name.Substring(Constants.Blob.MetadataHeaderPrefix.Length), item.Value);
                }
                else if (item.Name.StartsWith(Constants.Blob.ObjectReplicationRulesHeaderPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    objectReplicationRules.Add(item.Name.Substring(Constants.Blob.ObjectReplicationRulesHeaderPrefix.Length), item.Value);
                }
            }
        }
        #endregion

        #region ToBlobLease
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobAcquireLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerAcquireLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobRenewLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerRenewLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobChangeLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerChangeLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobBreakLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // LeaseId is not returned on a broken lease.
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerBreakLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLease
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // LeaseId is not returned on a broken lease.
                LeaseTime = response.GetRawResponse().Headers.ExtractLeaseTime()
            };
        }

        internal static int? ExtractLeaseTime(this ResponseHeaders responseHeaders)
        {
            int? leaseTime = null;

            if (responseHeaders.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return leaseTime;
        }
        #endregion

        #region ToReleasedObjectInfo
        internal static ReleasedObjectInfo ToReleasedObjectInfo(this ResponseWithHeaders<BlobReleaseLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ReleasedObjectInfo(
                eTag: response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                lastModified: response.Headers.LastModified.GetValueOrDefault());
        }

        internal static ReleasedObjectInfo ToReleasedObjectInfo(this ResponseWithHeaders<ContainerReleaseLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ReleasedObjectInfo(
                eTag: response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                lastModified: response.Headers.LastModified.GetValueOrDefault());
        }
        #endregion

        #region ToBlobItem
        internal static BlobItem[] ToBlobItems(this IReadOnlyList<BlobItemInternal> blobItemInternals)
        {
            if (blobItemInternals == null)
            {
                return null;
            }

            return blobItemInternals.Select(r => r.ToBlobItem()).ToArray();
        }

        internal static BlobItem ToBlobItem(this BlobItemInternal blobItemInternal)
        {
            if (blobItemInternal == null)
            {
                return null;
            }

            return new BlobItem
            {
                Name = blobItemInternal.Name.ToBlobNameString(),
                Deleted = blobItemInternal.Deleted,
                Snapshot = blobItemInternal.Snapshot,
                VersionId = blobItemInternal.VersionId,
                IsLatestVersion = blobItemInternal.IsCurrentVersion,
                Properties = blobItemInternal.Properties.ToBlobItemProperties(),
                Metadata = blobItemInternal.Metadata?.Count > 0
                    ? blobItemInternal.Metadata.ToMetadata()
                    : new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase),
                Tags = blobItemInternal.BlobTags.ToTagDictionary(),
                ObjectReplicationSourceProperties = blobItemInternal.OrMetadata?.Count > 0
                    ? ParseObjectReplicationMetadata(blobItemInternal.OrMetadata)
                    : null,
                HasVersionsOnly = blobItemInternal.HasVersionsOnly
            };
        }

        internal static string ToBlobNameString(this BlobName blobName)
        {
            string blobNameString;
            if (blobName.Encoded.GetValueOrDefault())
            {
                blobNameString = Uri.UnescapeDataString(blobName.Content);
            }
            else
            {
                blobNameString = blobName.Content;
            }
            return blobNameString;
        }

        internal static BlobItemProperties ToBlobItemProperties(this BlobPropertiesInternal blobPropertiesInternal)
        {
            if (blobPropertiesInternal == null)
            {
                return null;
            }

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy();
            immutabilityPolicy.ExpiresOn = blobPropertiesInternal.ImmutabilityPolicyExpiresOn;
            immutabilityPolicy.PolicyMode = blobPropertiesInternal.ImmutabilityPolicyMode;

            return new BlobItemProperties
            {
                LastModified = blobPropertiesInternal.LastModified,
                ContentLength = blobPropertiesInternal.ContentLength,
                ContentType = blobPropertiesInternal.ContentType,
                ContentEncoding = blobPropertiesInternal.ContentEncoding,
                ContentLanguage = blobPropertiesInternal.ContentLanguage,
                ContentHash = blobPropertiesInternal.ContentMD5,
                ContentDisposition = blobPropertiesInternal.ContentDisposition,
                CacheControl = blobPropertiesInternal.CacheControl,
                BlobSequenceNumber = blobPropertiesInternal.BlobSequenceNumber,
                BlobType = blobPropertiesInternal.BlobType,
                LeaseStatus = blobPropertiesInternal.LeaseStatus,
                LeaseState = blobPropertiesInternal.LeaseState,
                LeaseDuration = blobPropertiesInternal.LeaseDuration,
                CopyId = blobPropertiesInternal.CopyId,
                CopyStatus = blobPropertiesInternal.CopyStatus,
                CopySource = blobPropertiesInternal.CopySource == null ? null : new Uri(blobPropertiesInternal.CopySource),
                CopyProgress = blobPropertiesInternal.CopyProgress,
                CopyStatusDescription = blobPropertiesInternal.CopyStatusDescription,
                ServerEncrypted = blobPropertiesInternal.ServerEncrypted,
                DestinationSnapshot = blobPropertiesInternal.DestinationSnapshot,
                RemainingRetentionDays = blobPropertiesInternal.RemainingRetentionDays,
                AccessTier = blobPropertiesInternal.AccessTier,
                AccessTierInferred = blobPropertiesInternal.AccessTierInferred.GetValueOrDefault(),
                ArchiveStatus = blobPropertiesInternal.ArchiveStatus,
                CustomerProvidedKeySha256 = blobPropertiesInternal.CustomerProvidedKeySha256,
                EncryptionScope = blobPropertiesInternal.EncryptionScope,
                TagCount = blobPropertiesInternal.TagCount,
                ExpiresOn = blobPropertiesInternal.ExpiresOn,
                IsSealed = blobPropertiesInternal.IsSealed,
                RehydratePriority = blobPropertiesInternal.RehydratePriority,
                LastAccessedOn = blobPropertiesInternal.LastAccessedOn,
                ETag = new ETag(blobPropertiesInternal.Etag),
                CreatedOn = blobPropertiesInternal.CreationTime,
                CopyCompletedOn = blobPropertiesInternal.CopyCompletionTime,
                DeletedOn = blobPropertiesInternal.DeletedTime,
                AccessTierChangedOn = blobPropertiesInternal.AccessTierChangeTime,
                ImmutabilityPolicy = immutabilityPolicy,
                HasLegalHold = blobPropertiesInternal.LegalHold.GetValueOrDefault()
            };
        }

        #endregion

        #region ToBlobContainerItem
        internal static BlobContainerItem[] ToBlobContainerItems(this IReadOnlyList<ContainerItemInternal> containerItemInternals)
        {
            if (containerItemInternals == null)
            {
                return null;
            }

            return containerItemInternals.Select(r => r.ToBlobContainerItem()).ToArray();
        }

        internal static BlobContainerItem ToBlobContainerItem(this ContainerItemInternal containerItemInternal)
        {
            if (containerItemInternal == null)
            {
                return null;
            }

            return new BlobContainerItem
            {
                Name = containerItemInternal.Name,
                IsDeleted = containerItemInternal.Deleted,
                VersionId = containerItemInternal.Version,
                Properties = BlobExtensions.ToBlobContainerProperties(containerItemInternal.Properties, containerItemInternal.Metadata)
            };
        }
        #endregion

        #region ToBlobContainerProperties
        internal static BlobContainerProperties ToBlobContainerProperties(
            ContainerPropertiesInternal containerPropertiesInternal,
            IReadOnlyDictionary<string, string> metadata)
        {
            if (containerPropertiesInternal == null)
            {
                return null;
            }

            return new BlobContainerProperties
            {
                LastModified = containerPropertiesInternal.LastModified,
                LeaseStatus = containerPropertiesInternal.LeaseStatus,
                LeaseState = containerPropertiesInternal.LeaseState,
                LeaseDuration = containerPropertiesInternal.LeaseDuration,
                PublicAccess = containerPropertiesInternal.PublicAccess,
                HasImmutabilityPolicy = containerPropertiesInternal.HasImmutabilityPolicy,
                HasLegalHold = containerPropertiesInternal.HasLegalHold,
                DefaultEncryptionScope = containerPropertiesInternal.DefaultEncryptionScope,
                PreventEncryptionScopeOverride = containerPropertiesInternal.PreventEncryptionScopeOverride,
                DeletedOn = containerPropertiesInternal.DeletedTime,
                RemainingRetentionDays = containerPropertiesInternal.RemainingRetentionDays,
                ETag = new ETag(containerPropertiesInternal.Etag),
                Metadata = metadata.ToMetadata(),
                HasImmutableStorageWithVersioning = containerPropertiesInternal.IsImmutableStorageWithVersioningEnabled.GetValueOrDefault(),
            };
        }

        internal static BlobContainerProperties ToBlobContainerProperties(this ResponseWithHeaders<ContainerGetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContainerProperties
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseStatus = response.Headers.LeaseStatus,
                LeaseState = response.Headers.LeaseState,
                LeaseDuration = response.Headers.LeaseDuration ?? LeaseDurationType.Infinite,
                PublicAccess = response.Headers.BlobPublicAccess ?? PublicAccessType.None,
                HasImmutabilityPolicy = response.Headers.HasImmutabilityPolicy,
                HasLegalHold = response.Headers.HasLegalHold,
                DefaultEncryptionScope = response.Headers.DefaultEncryptionScope,
                PreventEncryptionScopeOverride = response.Headers.DenyEncryptionScopeOverride,
                // Container Get Properties does not return DeletedOn.
                // Container Get Properties does not return RemainingRetentionDays.
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                Metadata = response.Headers.Metadata.ToMetadata(),
                HasImmutableStorageWithVersioning = response.Headers.IsImmutableStorageWithVersioningEnabled.GetValueOrDefault()
            };
        }

        internal static IDictionary<string, string> ToMetadata(this IDictionary<string, string> originalMetadata)
        {
            if (originalMetadata == null)
            {
                return null;
            }

            IDictionary<string, string> metadata = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);

            foreach (KeyValuePair<string, string> entry in originalMetadata)
            {
                metadata.Add(entry.Key, entry.Value);
            }

            return metadata;
        }

        internal static IDictionary<string, string> ToMetadata(this IReadOnlyDictionary<string, string> originalMetadata)
        {
            if (originalMetadata == null)
            {
                return null;
            }

            IDictionary<string, string> metadata = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);

            foreach (KeyValuePair<string, string> entry in originalMetadata)
            {
                metadata.Add(entry.Key, entry.Value);
            }

            return metadata;
        }
        #endregion

        #region ToBlobImmutabilityPolicy
        internal static BlobImmutabilityPolicy ToBlobImmutabilityPolicy(this ResponseWithHeaders<BlobSetImmutabilityPolicyHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobImmutabilityPolicy
            {
                ExpiresOn = response.Headers.ImmutabilityPolicyExpiry,
                PolicyMode = response.Headers.ImmutabilityPolicyMode
            };
        }
        #endregion

        #region ToBlobLegalHoldInfo
        internal static BlobLegalHoldResult ToBlobLegalHoldInfo(this ResponseWithHeaders<BlobSetLegalHoldHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLegalHoldResult
            {
                HasLegalHold = response.Headers.LegalHold.GetValueOrDefault()
            };
        }
        #endregion

        #region ToEncryptionAlgorithmString
        internal static string ToEncryptionAlgorithmString(this EncryptionAlgorithmType type)
        {
            return type switch
            {
                EncryptionAlgorithmType.Aes256 => EncryptionAlgorithmTypeInternal.AES256.ToSerialString(),
                _ => throw new InvalidEnumArgumentException(),
            };
        }
        #endregion

        #region ToPageBlobRanges
        internal static PageRangeItem[] ToPageBlobRanges(this ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return ToPageBlobRanges(response.Value.PageRange, response.Value.ClearRange);
        }

        internal static PageRangeItem[] ToPageBlobRanges(this ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return ToPageBlobRanges(response.Value.PageRange, response.Value.ClearRange);
        }

        internal static PageRangeItem[] ToPageBlobRanges(
            IReadOnlyList<PageRange> pageRanges,
            IReadOnlyList<ClearRange> clearRanges)
        {
            List<PageRangeItem> pageBlobRangeList = new List<PageRangeItem>();

            int pageRangeIndex = 0;
            int clearRangeIndex = 0;

            while (pageRangeIndex < pageRanges.Count
                || clearRangeIndex < clearRanges.Count)
            {
                // Haven't ran out of page ranges or clear ranges yet.
                if (pageRangeIndex < pageRanges.Count
                    && clearRangeIndex < clearRanges.Count)
                {
                    // Next page range starts before next clear range.
                    if (pageRanges[pageRangeIndex].Start <= clearRanges[clearRangeIndex].Start)
                    {
                        pageBlobRangeList.Add(new PageRangeItem
                        {
                            IsClear = false,
                            Range = pageRanges[pageRangeIndex].ToHttpRange()
                        });
                        pageRangeIndex++;
                    }
                    // Next clear range starts before next page range.
                    else
                    {
                        pageBlobRangeList.Add(new PageRangeItem
                        {
                            IsClear = true,
                            Range = clearRanges[clearRangeIndex].ToHttpRange()
                        });
                        clearRangeIndex++;
                    }
                }
                // We ran out of clear ranges.
                else if (pageRangeIndex < pageRanges.Count)
                {
                    pageBlobRangeList.Add(new PageRangeItem
                    {
                        IsClear = false,
                        Range = pageRanges[pageRangeIndex].ToHttpRange()
                    });
                    pageRangeIndex++;
                }
                // we ran out of filled ranges.
                else
                {
                    pageBlobRangeList.Add(new PageRangeItem
                    {
                        IsClear = true,
                        Range = clearRanges[clearRangeIndex].ToHttpRange()
                    });
                    clearRangeIndex++;
                }
            }

            return pageBlobRangeList.ToArray();
        }
        #endregion ToPageBlobRanges

        #region ValidateConditionsNotPresent
        internal static void ValidateConditionsNotPresent(
            this RequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;
            requestConditions.ValidateConditionsNotPresent(
                invalidConditions,
                ref invalidList);

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this BlobRequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;
            requestConditions.ValidateConditionsNotPresent(
                invalidConditions,
                ref invalidList);

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this BlobLeaseRequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;
            requestConditions.ValidateConditionsNotPresent(
                invalidConditions, ref invalidList);

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this AppendBlobRequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;

            // Validate BlobRequestConditions
            ((BlobRequestConditions)requestConditions).ValidateConditionsNotPresent(
                invalidConditions, ref invalidList);

            // Validate AppendBlobRequestConditions specific conditions.
            if ((invalidConditions & BlobRequestConditionProperty.IfAppendPositionEqual) == BlobRequestConditionProperty.IfAppendPositionEqual
                && requestConditions.IfAppendPositionEqual != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(AppendBlobRequestConditions.IfAppendPositionEqual));
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfMaxSizeLessThanOrEqual) == BlobRequestConditionProperty.IfMaxSizeLessThanOrEqual
                && requestConditions.IfMaxSizeLessThanOrEqual != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(AppendBlobRequestConditions.IfMaxSizeLessThanOrEqual));
            }

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this PageBlobRequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;

            // Validate BlobRequestConditions
            ((BlobRequestConditions)requestConditions).ValidateConditionsNotPresent(
                invalidConditions, ref invalidList);

            // Validate PageBlobRequestConditions specific conditions.
            if ((invalidConditions & BlobRequestConditionProperty.IfSequenceNumberLessThan) == BlobRequestConditionProperty.IfSequenceNumberLessThan
                && requestConditions.IfSequenceNumberLessThan != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(PageBlobRequestConditions.IfSequenceNumberLessThan));
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual) == BlobRequestConditionProperty.IfSequenceNumberLessThanOrEqual
                && requestConditions.IfSequenceNumberLessThanOrEqual != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(PageBlobRequestConditions.IfSequenceNumberLessThanOrEqual));
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfSequenceNumberEqual) == BlobRequestConditionProperty.IfSequenceNumberEqual
                && requestConditions.IfSequenceNumberEqual != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(PageBlobRequestConditions.IfSequenceNumberEqual));
            }

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this RequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            ref List<string> invalidList)
        {
            if (requestConditions == null)
            {
                return;
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfModifiedSince) == BlobRequestConditionProperty.IfModifiedSince
                && requestConditions.IfModifiedSince != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfModifiedSince));
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfUnmodifiedSince) == BlobRequestConditionProperty.IfUnmodifiedSince
                && requestConditions.IfUnmodifiedSince != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfUnmodifiedSince));
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfMatch) == BlobRequestConditionProperty.IfMatch
                && requestConditions.IfMatch != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfMatch));
            }

            if ((invalidConditions & BlobRequestConditionProperty.IfNoneMatch) == BlobRequestConditionProperty.IfNoneMatch
                && requestConditions.IfNoneMatch != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfNoneMatch));
            }
        }

        internal static void ValidateConditionsNotPresent(
            this BlobLeaseRequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            ref List<string> invalidList)
        {
            if (requestConditions == null)
            {
                return;
            }

            if ((invalidConditions & BlobRequestConditionProperty.TagConditions) == BlobRequestConditionProperty.TagConditions
                && requestConditions.TagConditions != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(requestConditions.TagConditions));
            }
        }

        internal static void ValidateConditionsNotPresent(
            this BlobRequestConditions requestConditions,
            BlobRequestConditionProperty invalidConditions,
            ref List<string> invalidList)
        {
            if (requestConditions == null)
            {
                return;
            }

            // Validate BlobRequestConditions
            ((RequestConditions)requestConditions).ValidateConditionsNotPresent(
                invalidConditions, ref invalidList);

            // Validate BlobLeaseRequestConditions conditions.
            ((BlobLeaseRequestConditions)requestConditions).ValidateConditionsNotPresent(
                invalidConditions, ref invalidList);

            // Validate BlobRequestConditions specific conditions.
            if ((invalidConditions & BlobRequestConditionProperty.LeaseId) == BlobRequestConditionProperty.LeaseId
                && requestConditions.LeaseId != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.LeaseId));
            }
            if ((invalidConditions & BlobRequestConditionProperty.AccessTierIfModifiedSince) == BlobRequestConditionProperty.AccessTierIfModifiedSince
                && requestConditions.AccessTierIfModifiedSince != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.AccessTierIfModifiedSince));
            }
            if ((invalidConditions & BlobRequestConditionProperty.AccessTierIfUnmodifiedSince) == BlobRequestConditionProperty.AccessTierIfUnmodifiedSince
                && requestConditions.AccessTierIfUnmodifiedSince != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.AccessTierIfUnmodifiedSince));
            }
        }
        #endregion
    }
}
