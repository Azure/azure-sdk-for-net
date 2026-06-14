// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Tags = System.Collections.Generic.IDictionary<string, string>;

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

        internal enum AccountInfoHeaderType
        {
            Service,
            Blob,
            Container
        }

        internal static AccountInfo ToAccountInfo(this Response response, AccountInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case AccountInfoHeaderType.Service:
                case AccountInfoHeaderType.Blob:
                case AccountInfoHeaderType.Container:
                    return new AccountInfo
                    {
                        SkuName = response.Headers.TryGetValue("x-ms-sku-name", out string skuName) ? skuName.ToSkuName() : default,
                        AccountKind = response.Headers.TryGetValue("x-ms-account-kind", out string accountKind) ? accountKind.ToAccountKind() : default,
                        IsHierarchicalNamespaceEnabled = response.Headers.TryGetValue("x-ms-is-hns-enabled", out bool? isHns) && isHns.GetValueOrDefault()
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(AccountInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToBlobContainerAccessPolicy
        internal static BlobContainerAccessPolicy ToBlobContainerAccessPolicy(
            this Response<BlobSignedIdentifiers> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContainerAccessPolicy
            {
                BlobPublicAccess = response.GetRawResponse().Headers.TryGetValue("x-ms-blob-public-access", out string publicAccess) ? publicAccess.ToPublicAccessType() : default,
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                SignedIdentifiers = response.Value.Items.ToList()
            };
        }
        #endregion

        #region ToBlobContainerInfo

        internal enum BlobContainerInfoHeaderType
        {
            Create,
            SetAccessPolicy,
            SetMetadata
        }

        internal static BlobContainerInfo ToBlobContainerInfo(this Response response, BlobContainerInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlobContainerInfoHeaderType.Create:
                case BlobContainerInfoHeaderType.SetAccessPolicy:
                case BlobContainerInfoHeaderType.SetMetadata:
                    return new BlobContainerInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlobContainerInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToBlobContentInfo

        internal enum BlobContentInfoHeaderType
        {
            AppendBlobCreate,
            PageBlobCreate,
            BlockBlobCommitBlockList,
            BlockBlobPutBlobFromUrl,
            BlockBlobUpload
        }

        internal static BlobContentInfo ToBlobContentInfo(this Response response, BlobContentInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlobContentInfoHeaderType.AppendBlobCreate:
                case BlobContentInfoHeaderType.PageBlobCreate:
                case BlobContentInfoHeaderType.BlockBlobCommitBlockList:
                case BlobContentInfoHeaderType.BlockBlobPutBlobFromUrl:
                case BlobContentInfoHeaderType.BlockBlobUpload:
                    return new BlobContentInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        ContentHash = response.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null,
                        VersionId = response.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string versionId) ? versionId : null,
                        EncryptionKeySha256 = response.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                        EncryptionScope = response.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null,
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlobContentInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToBlobAppendInfo

        internal enum BlobAppendInfoHeaderType
        {
            AppendBlock,
            AppendBlockFromUrl
        }

        internal static BlobAppendInfo ToBlobAppendInfo(this Response response, BlobAppendInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlobAppendInfoHeaderType.AppendBlock:
                case BlobAppendInfoHeaderType.AppendBlockFromUrl:
                    return new BlobAppendInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        ContentHash = response.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null,
                        ContentCrc64 = response.Headers.TryGetValue("x-ms-content-crc64", out byte[] crc64) ? crc64 : null,
                        BlobAppendOffset = response.Headers.TryGetValue("x-ms-blob-append-offset", out string appendOffset) ? appendOffset : null,
                        BlobCommittedBlockCount = response.Headers.TryGetValue("x-ms-blob-committed-block-count", out int? blockCount) ? blockCount.GetValueOrDefault() : default,
                        IsServerEncrypted = response.Headers.TryGetValue("x-ms-request-server-encrypted", out bool? serverEncrypted) && serverEncrypted.GetValueOrDefault(),
                        EncryptionKeySha256 = response.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                        EncryptionScope = response.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlobAppendInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToBlobInfo

        internal enum BlobInfoHeaderType
        {
            AppendBlobSeal,
            SetMetadata,
            SetHttpHeaders
        }

        internal static BlobInfo ToBlobInfo(this Response response, BlobInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlobInfoHeaderType.AppendBlobSeal:
                case BlobInfoHeaderType.SetHttpHeaders:
                    // AppendBlobSeal and SetHttpHeaders do not return BlobSequenceNumber or VersionId.
                    return new BlobInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                    };
                case BlobInfoHeaderType.SetMetadata:
                    // SetMetadata returns VersionId but not BlobSequenceNumber.
                    return new BlobInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string smdValue) ? new ETag(smdValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? smdLastModified) ? smdLastModified.GetValueOrDefault() : default,
                        VersionId = response.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string versionId) ? versionId : null
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlobInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToPageInfo

        internal enum PageInfoHeaderType
        {
            UploadPages,
            ClearPages,
            UploadPagesFromUrl
        }

        internal static PageInfo ToPageInfo(this Response response, PageInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case PageInfoHeaderType.UploadPages:
                case PageInfoHeaderType.UploadPagesFromUrl:
                    return new PageInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        ContentHash = response.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null,
                        ContentCrc64 = response.Headers.TryGetValue("x-ms-content-crc64", out byte[] crc64) ? crc64 : null,
                        BlobSequenceNumber = response.Headers.TryGetValue("x-ms-blob-sequence-number", out long? seqNum) ? seqNum.GetValueOrDefault() : default,
                        EncryptionKeySha256 = response.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                        EncryptionScope = response.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null
                    };
                case PageInfoHeaderType.ClearPages:
                    // Clear Page Blob does not return EncryptionKeySha256 or EncryptionScope.
                    return new PageInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string clearValue) ? new ETag(clearValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? clearLastModified) ? clearLastModified.GetValueOrDefault() : default,
                        ContentHash = response.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] clearContentMD5) ? clearContentMD5 : null,
                        ContentCrc64 = response.Headers.TryGetValue("x-ms-content-crc64", out byte[] clearCrc64) ? clearCrc64 : null,
                        BlobSequenceNumber = response.Headers.TryGetValue("x-ms-blob-sequence-number", out long? clearSeqNum) ? clearSeqNum.GetValueOrDefault() : default,
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(PageInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToPageRangesInfo

        internal enum PageRangesInfoHeaderType
        {
            GetPageRanges,
            GetPageRangesDiff
        }

        internal static PageRangesInfo ToPageRangesInfo(this Response<PageList> response, PageRangesInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case PageRangesInfoHeaderType.GetPageRanges:
                case PageRangesInfoHeaderType.GetPageRangesDiff:
                    return new PageRangesInfo
                    {
                        LastModified = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        BlobContentLength = response.GetRawResponse().Headers.TryGetValue("x-ms-blob-content-length", out long? blobContentLength) ? blobContentLength.GetValueOrDefault() : default,
                        PageRanges = response.Value.PageRange.Select(r => r.ToHttpRange()).ToList(),
                        ClearRanges = response.Value.ClearRange.Select(r => r.ToHttpRange()).ToList(),
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(PageRangesInfoHeaderType)}: {headerType}", nameof(headerType));
            }
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

        internal enum PageBlobInfoHeaderType
        {
            Resize,
            UpdateSequenceNumber
        }

        internal static PageBlobInfo ToPageBlobInfo(this Response response, PageBlobInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case PageBlobInfoHeaderType.Resize:
                case PageBlobInfoHeaderType.UpdateSequenceNumber:
                    return new PageBlobInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        BlobSequenceNumber = response.Headers.TryGetValue("x-ms-blob-sequence-number", out long? seqNum) ? seqNum.GetValueOrDefault() : default
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(PageBlobInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToBlockInfo

        internal enum BlockInfoHeaderType
        {
            StageBlock,
            StageBlockFromUrl
        }

        internal static BlockInfo ToBlockInfo(this Response response, BlockInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlockInfoHeaderType.StageBlock:
                case BlockInfoHeaderType.StageBlockFromUrl:
                    return new BlockInfo
                    {
                        ContentHash = response.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null,
                        ContentCrc64 = response.Headers.TryGetValue("x-ms-content-crc64", out byte[] crc64) ? crc64 : null,
                        EncryptionKeySha256 = response.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                        EncryptionScope = response.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlockInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        // ToBlobContentInfo overloads for BlockBlob are consolidated into the main ToBlobContentInfo method above.
        #region ToBlockList
        internal static BlockList ToBlockList(this Response<BlockList> response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlockList
            {
                LastModified = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                ContentType = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ContentType, out string contentType) ? contentType : null,
                BlobContentLength = response.GetRawResponse().Headers.TryGetValue("x-ms-blob-content-length", out long? blobContentLength) ? blobContentLength.GetValueOrDefault() : default,
                CommittedBlocks = response.Value.CommittedBlocks,
                UncommittedBlocks = response.Value.UncommittedBlocks
            };
        }
        #endregion

        #region ToBlobSnapshotInfo
        internal static BlobSnapshotInfo ToBlobSnapshotInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobSnapshotInfo
            {
                Snapshot = response.Headers.TryGetValue("x-ms-snapshot", out string snapshot) ? snapshot : null,
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                VersionId = response.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string versionId) ? versionId : null,
                IsServerEncrypted = response.Headers.TryGetValue("x-ms-request-server-encrypted", out bool? serverEncrypted) && serverEncrypted.GetValueOrDefault()
            };
        }
        #endregion

        // ToBlobInfo overloads for SetMetadata and SetHttpHeaders are consolidated into the main ToBlobInfo method above.
        #region ToBlobProperties
        internal static BlobProperties ToBlobProperties(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            var objectReplicationRules = response.Headers.TryGetValue(Constants.Blob.ObjectReplicationRulesHeaderPrefix, out IDictionary<string, string> objectReplicationRulesValue)
                ? objectReplicationRulesValue
                : null;
            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy();
            immutabilityPolicy.ExpiresOn = response.Headers.TryGetValue("x-ms-immutability-policy-until-date", out DateTimeOffset? immutabilityExpiry) ? immutabilityExpiry : null;
            immutabilityPolicy.PolicyMode = response.Headers.TryGetValue("x-ms-immutability-policy-mode", out string immutabilityMode) ? immutabilityMode.ToBlobImmutabilityPolicyMode() : null;

            return new BlobProperties(
                lastModified: response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                createdOn: response.Headers.TryGetValue("x-ms-creation-time", out DateTimeOffset? creationTime) ? creationTime.GetValueOrDefault() : default,
                metadata: response.Headers.TryGetValue(Constants.Blob.MetadataHeaderPrefix, out IDictionary<string, string> metadataValue) ? metadataValue : null,
                objectReplicationDestinationPolicyId: response.Headers.TryGetValue("x-ms-or-policy-id", out string orPolicyId) ? orPolicyId : null,
                objectReplicationSourceProperties:
                    objectReplicationRules?.Count > 0
                    ? BlobExtensions.ParseObjectReplicationIds(objectReplicationRules)
                    : null,
                blobType: response.Headers.TryGetValue("x-ms-blob-type", out string blobType) ? blobType.ToBlobType() : default,
                copyCompletedOn: response.Headers.TryGetValue("x-ms-copy-completion-time", out DateTimeOffset? copyCompletionTime) ? copyCompletionTime.GetValueOrDefault() : default,
                copyStatusDescription: response.Headers.TryGetValue("x-ms-copy-status-description", out string copyStatusDescription) ? copyStatusDescription : null,
                copyId: response.Headers.TryGetValue("x-ms-copy-id", out string copyId) ? copyId : null,
                copyProgress: response.Headers.TryGetValue("x-ms-copy-progress", out string copyProgress) ? copyProgress : null,
                copySource: response.Headers.TryGetValue("x-ms-copy-source", out string copySource) ? (copySource == null ? null : new Uri(copySource)) : null,
                blobCopyStatus: response.Headers.TryGetValue("x-ms-copy-status", out string copyStatus) ? copyStatus.ToCopyStatus() : null,
                isIncrementalCopy: response.Headers.TryGetValue("x-ms-incremental-copy", out bool? isIncrementalCopy) && isIncrementalCopy.GetValueOrDefault(),
                destinationSnapshot: response.Headers.TryGetValue("x-ms-copy-destination-snapshot", out string destinationSnapshot) ? destinationSnapshot : null,
                leaseDuration: response.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToLeaseDurationType() : default,
                leaseState: response.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToLeaseState() : default,
                leaseStatus: response.Headers.TryGetValue("x-ms-lease-status", out string leaseStatus) ? leaseStatus.ToLeaseStatus() : default,
                contentLength: response.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out long? contentLength) ? contentLength.GetValueOrDefault() : default,
                contentType: response.Headers.TryGetValue(Constants.HeaderNames.ContentType, out string contentType) ? contentType : null,
                eTag: response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string etagValue) ? new ETag(etagValue) : default,
                contentHash: response.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null,
                contentEncoding: response.Headers.TryGetValue(Constants.HeaderNames.ContentEncoding, out string contentEncoding) ? contentEncoding : null,
                contentDisposition: response.Headers.TryGetValue("Content-Disposition", out string contentDisposition) ? contentDisposition : null,
                contentLanguage: response.Headers.TryGetValue(Constants.HeaderNames.ContentLanguage, out string contentLanguage) ? contentLanguage : null,
                cacheControl: response.Headers.TryGetValue("Cache-Control", out string cacheControl) ? cacheControl : null,
                blobSequenceNumber: response.Headers.TryGetValue("x-ms-blob-sequence-number", out long? blobSequenceNumber) ? blobSequenceNumber.GetValueOrDefault() : default,
                acceptRanges: response.Headers.TryGetValue("Accept-Ranges", out string acceptRanges) ? acceptRanges : null,
                blobCommittedBlockCount: response.Headers.TryGetValue("x-ms-blob-committed-block-count", out int? blobCommittedBlockCount) ? blobCommittedBlockCount.GetValueOrDefault() : default,
                isServerEncrypted: response.Headers.TryGetValue("x-ms-server-encrypted", out bool? isServerEncrypted) && isServerEncrypted.GetValueOrDefault(),
                encryptionKeySha256: response.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                encryptionScope: response.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null,
                accessTier: response.Headers.TryGetValue("x-ms-access-tier", out string accessTier) ? accessTier : null,
                accessTierInferred: response.Headers.TryGetValue("x-ms-access-tier-inferred", out bool? accessTierInferred) && accessTierInferred.GetValueOrDefault(),
                archiveStatus: response.Headers.TryGetValue("x-ms-archive-status", out string archiveStatus) ? archiveStatus : null,
                accessTierChangedOn: response.Headers.TryGetValue("x-ms-access-tier-change-time", out DateTimeOffset? accessTierChangeTime) ? accessTierChangeTime.GetValueOrDefault() : default,
                versionId: response.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string versionId) ? versionId : null,
                isLatestVersion: response.Headers.TryGetValue("x-ms-is-current-version", out bool? isCurrentVersion) && isCurrentVersion.GetValueOrDefault(),
                tagCount: response.Headers.TryGetValue("x-ms-tag-count", out long? tagCount) ? tagCount.GetValueOrDefault() : default,
                expiresOn: response.Headers.TryGetValue("x-ms-expiry-time", out DateTimeOffset? expiresOn) ? expiresOn.GetValueOrDefault() : default,
                isSealed: response.Headers.TryGetValue("x-ms-blob-sealed", out bool? isSealed) && isSealed.GetValueOrDefault(),
                rehydratePriority: response.Headers.TryGetValue("x-ms-rehydrate-priority", out string rehydratePriority) ? rehydratePriority : null,
                lastAccessed: response.Headers.TryGetValue("x-ms-last-access-time", out DateTimeOffset? lastAccessed) ? lastAccessed.GetValueOrDefault() : default,
                immutabilityPolicy: immutabilityPolicy,
                hasLegalHold: response.Headers.TryGetValue("x-ms-legal-hold", out bool? legalHold) && legalHold.GetValueOrDefault(),
                smartAccessTier: response.Headers.TryGetValue("x-ms-smart-access-tier", out string smartAccessTier) ? smartAccessTier : null);
        }
        #endregion

        #region ToBlobCopyInfo

        internal enum BlobCopyInfoHeaderType
        {
            CopyFromUrl,
            StartCopyFromUrl,
            PageBlobCopyIncremental
        }

        internal static BlobCopyInfo ToBlobCopyInfo(this Response response, BlobCopyInfoHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlobCopyInfoHeaderType.CopyFromUrl:
                    return new BlobCopyInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string copyFromUrlEtag) ? new ETag(copyFromUrlEtag) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? copyFromUrlLastModified) ? copyFromUrlLastModified.GetValueOrDefault() : default,
                        VersionId = response.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string copyFromUrlVersionId) ? copyFromUrlVersionId : null,
                        CopyId = response.Headers.TryGetValue("x-ms-copy-id", out string copyFromUrlCopyId) ? copyFromUrlCopyId : null,
                        CopyStatus = response.Headers.TryGetValue("x-ms-copy-status", out string copyFromUrlCopyStatus) ? CopyStatusExtensions.ToCopyStatus(copyFromUrlCopyStatus) : default,
                        EncryptionScope = response.Headers.TryGetValue("x-ms-encryption-scope", out string copyFromUrlEncryptionScope) ? copyFromUrlEncryptionScope : null
                    };
                case BlobCopyInfoHeaderType.StartCopyFromUrl:
                    return new BlobCopyInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string startCopyEtag) ? new ETag(startCopyEtag) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? startCopyLastModified) ? startCopyLastModified.GetValueOrDefault() : default,
                        VersionId = response.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string startCopyVersionId) ? startCopyVersionId : null,
                        CopyId = response.Headers.TryGetValue("x-ms-copy-id", out string startCopyCopyId) ? startCopyCopyId : null,
                        CopyStatus = response.Headers.TryGetValue("x-ms-copy-status", out string startCopyCopyStatus) ? startCopyCopyStatus.ToCopyStatus() : default
                    };
                case BlobCopyInfoHeaderType.PageBlobCopyIncremental:
                    // Page Blob Copy Incremental does not return VersionId.
                    return new BlobCopyInfo
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string incrEtag) ? new ETag(incrEtag) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? incrLastModified) ? incrLastModified.GetValueOrDefault() : default,
                        CopyId = response.Headers.TryGetValue("x-ms-copy-id", out string incrCopyId) ? incrCopyId : null,
                        CopyStatus = response.Headers.TryGetValue("x-ms-copy-status", out string incrCopyStatus) ? incrCopyStatus.ToCopyStatus() : default
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlobCopyInfoHeaderType)}: {headerType}", nameof(headerType));
            }
        }
        #endregion

        #region ToBlobDownloadStreamingResult
        internal static BlobDownloadStreamingResult ToBlobDownloadStreamingResult(this Response<Stream> response)
        {
            if (response == null)
            {
                return null;
            }

            var rawResponse = response.GetRawResponse();
            rawResponse.Headers.ExtractMultiHeaderDownloadProperties(out var metadata, out var objectReplicationRules);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy();
            immutabilityPolicy.ExpiresOn = rawResponse.Headers.TryGetValue("x-ms-immutability-policy-until-date", out DateTimeOffset? immutabilityExpiry) ? immutabilityExpiry : null;
            immutabilityPolicy.PolicyMode = rawResponse.Headers.TryGetValue("x-ms-immutability-policy-mode", out string immutabilityMode) ? immutabilityMode.ToBlobImmutabilityPolicyMode() : null;

            return new BlobDownloadStreamingResult
            {
                Content = response.Value,
                Details = new BlobDownloadDetails
                {
                    BlobType = rawResponse.Headers.TryGetValue("x-ms-blob-type", out string blobType) ? blobType.ToBlobType() : default,
                    ContentLength = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out long? contentLength) ? contentLength.GetValueOrDefault() : default,
                    ContentType = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentType, out string contentType) ? contentType : null,
                    ContentHash = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null,
                    LastModified = rawResponse.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                    Metadata = metadata,
                    ContentRange = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentRange, out string contentRange) ? contentRange : null,
                    ETag = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                    ContentEncoding = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentEncoding, out string contentEncoding) ? contentEncoding : null,
                    CacheControl = rawResponse.Headers.TryGetValue("Cache-Control", out string cacheControl) ? cacheControl : null,
                    ContentDisposition = rawResponse.Headers.TryGetValue("Content-Disposition", out string contentDisposition) ? contentDisposition : null,
                    ContentLanguage = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentLanguage, out string contentLanguage) ? contentLanguage : null,
                    BlobSequenceNumber = rawResponse.Headers.TryGetValue("x-ms-blob-sequence-number", out long? seqNum) ? seqNum.GetValueOrDefault() : default,
                    CopyCompletedOn = rawResponse.Headers.TryGetValue("x-ms-copy-completion-time", out DateTimeOffset? copyCompletionTime) ? copyCompletionTime.GetValueOrDefault() : default,
                    CopyStatusDescription = rawResponse.Headers.TryGetValue("x-ms-copy-status-description", out string copyStatusDescription) ? copyStatusDescription : null,
                    CopyId = rawResponse.Headers.TryGetValue("x-ms-copy-id", out string copyId) ? copyId : null,
                    CopyProgress = rawResponse.Headers.TryGetValue("x-ms-copy-progress", out string copyProgress) ? copyProgress : null,
                    CopySource = rawResponse.Headers.TryGetValue("x-ms-copy-source", out string copySource) ? (copySource == null ? null : new Uri(copySource)) : null,
                    CopyStatus = rawResponse.Headers.TryGetValue("x-ms-copy-status", out string copyStatus) ? copyStatus.ToCopyStatus() : default,
                    LeaseDuration = rawResponse.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToLeaseDurationType() : LeaseDurationType.Infinite,
                    LeaseStatus = rawResponse.Headers.TryGetValue("x-ms-lease-status", out string leaseStatus) ? leaseStatus.ToLeaseStatus() : LeaseStatus.Unlocked,
                    LeaseState = rawResponse.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToLeaseState() : default,
                    AcceptRanges = rawResponse.Headers.TryGetValue("Accept-Ranges", out string acceptRanges) ? acceptRanges : null,
                    BlobCommittedBlockCount = rawResponse.Headers.TryGetValue("x-ms-blob-committed-block-count", out int? blockCount) ? blockCount.GetValueOrDefault() : default,
                    IsServerEncrypted = rawResponse.Headers.TryGetValue("x-ms-server-encrypted", out bool? serverEncrypted) && serverEncrypted.GetValueOrDefault(),
                    EncryptionKeySha256 = rawResponse.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                    EncryptionScope = rawResponse.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null,
                    BlobContentHash = rawResponse.Headers.TryGetValue("x-ms-blob-content-md5", out byte[] blobContentMD5) ? blobContentMD5 : null,
                    TagCount = rawResponse.Headers.TryGetValue("x-ms-tag-count", out long? tagCount) ? tagCount.GetValueOrDefault() : default,
                    VersionId = rawResponse.Headers.TryGetValue(Constants.HeaderNames.VersionId, out string versionId) ? versionId : null,
                    IsSealed = rawResponse.Headers.TryGetValue("x-ms-blob-sealed", out bool? isSealed) && isSealed.GetValueOrDefault(),
                    ObjectReplicationSourceProperties
                        = objectReplicationRules?.Count > 0
                        ? ParseObjectReplicationIds(objectReplicationRules)
                        : null,
                    ObjectReplicationDestinationPolicyId = rawResponse.Headers.TryGetValue("x-ms-or-policy-id", out string orPolicyId) ? orPolicyId : null,
                    LastAccessed = rawResponse.Headers.TryGetValue("x-ms-last-access-time", out DateTimeOffset? lastAccessed) ? lastAccessed.GetValueOrDefault() : default,
                    ImmutabilityPolicy = immutabilityPolicy,
                    HasLegalHold = rawResponse.Headers.TryGetValue("x-ms-legal-hold", out bool? legalHold) && legalHold.GetValueOrDefault(),
                    CreatedOn = rawResponse.Headers.TryGetValue("x-ms-creation-time", out DateTimeOffset? creationTime) ? creationTime.GetValueOrDefault() : default
                }
            };
        }
        #endregion

        #region ToBlobDownloadInfo
        internal static BlobDownloadInfo ToBlobDownloadInfo(Response<Stream> response, Stream stream)
        {
            if (response == null)
            {
                return null;
            }

            var rawResponse = response.GetRawResponse();
            var blobType = rawResponse.Headers.TryGetValue("x-ms-blob-type", out string blobTypeStr) ? blobTypeStr.ToBlobType() : default;
            var contentLength = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentLength, out long? contentLengthVal) ? contentLengthVal.GetValueOrDefault() : default;
            var contentType = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentType, out string contentTypeStr) ? contentTypeStr : null;
            var contentHash = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out byte[] contentMD5) ? contentMD5 : null;
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
                    LastModified = rawResponse.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                    Metadata = rawResponse.Headers.TryGetValue(Constants.HeaderNames.MetadataPrefix, out IDictionary<string, string> metadataValue) ? metadataValue.ToMetadata() : null,
                    ContentRange = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentRange, out string contentRange) ? contentRange : null,
                    ETag = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                    ContentEncoding = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentEncoding, out string contentEncoding) ? contentEncoding : null,
                    CacheControl = rawResponse.Headers.TryGetValue("Cache-Control", out string cacheControl) ? cacheControl : null,
                    ContentDisposition = rawResponse.Headers.TryGetValue("Content-Disposition", out string contentDisposition) ? contentDisposition : null,
                    ContentLanguage = rawResponse.Headers.TryGetValue(Constants.HeaderNames.ContentLanguage, out string contentLanguage) ? contentLanguage : null,
                    BlobSequenceNumber = rawResponse.Headers.TryGetValue("x-ms-blob-sequence-number", out long? seqNum) ? seqNum.GetValueOrDefault() : default,
                    CopyCompletedOn = rawResponse.Headers.TryGetValue("x-ms-copy-completion-time", out DateTimeOffset? copyCompletionTime) ? copyCompletionTime.GetValueOrDefault() : default,
                    CopyStatusDescription = rawResponse.Headers.TryGetValue("x-ms-copy-status-description", out string copyStatusDescription) ? copyStatusDescription : null,
                    CopyId = rawResponse.Headers.TryGetValue("x-ms-copy-id", out string copyId) ? copyId : null,
                    CopyProgress = rawResponse.Headers.TryGetValue("x-ms-copy-progress", out string copyProgress) ? copyProgress : null,
                    CopySource = rawResponse.Headers.TryGetValue("x-ms-copy-source", out string copySource) ? (copySource == null ? null : new Uri(copySource)) : null,
                    CopyStatus = rawResponse.Headers.TryGetValue("x-ms-copy-status", out string copyStatus) ? copyStatus.ToCopyStatus() : default,
                    LeaseDuration = rawResponse.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToLeaseDurationType() : LeaseDurationType.Infinite,
                    LeaseState = rawResponse.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToLeaseState() : default,
                    AcceptRanges = rawResponse.Headers.TryGetValue("Accept-Ranges", out string acceptRanges) ? acceptRanges : null,
                    BlobCommittedBlockCount = rawResponse.Headers.TryGetValue("x-ms-blob-committed-block-count", out int? blockCount) ? blockCount.GetValueOrDefault() : default,
                    IsServerEncrypted = rawResponse.Headers.TryGetValue("x-ms-server-encrypted", out bool? serverEncrypted) && serverEncrypted.GetValueOrDefault(),
                    EncryptionKeySha256 = rawResponse.Headers.TryGetValue("x-ms-encryption-key-sha256", out string encryptionKeySha256) ? encryptionKeySha256 : null,
                    EncryptionScope = rawResponse.Headers.TryGetValue("x-ms-encryption-scope", out string encryptionScope) ? encryptionScope : null,
                    BlobContentHash = rawResponse.Headers.TryGetValue("x-ms-blob-content-md5", out byte[] blobContentMD5) ? blobContentMD5 : null
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

        internal enum BlobLeaseHeaderType
        {
            BlobAcquire,
            ContainerAcquire,
            BlobRenew,
            ContainerRenew,
            BlobChange,
            ContainerChange,
            BlobBreak,
            ContainerBreak
        }

        internal static BlobLease ToBlobLease(this Response response, BlobLeaseHeaderType headerType)
        {
            if (response == null)
            {
                return null;
            }

            switch (headerType)
            {
                case BlobLeaseHeaderType.BlobAcquire:
                case BlobLeaseHeaderType.ContainerAcquire:
                case BlobLeaseHeaderType.BlobRenew:
                case BlobLeaseHeaderType.ContainerRenew:
                case BlobLeaseHeaderType.BlobChange:
                case BlobLeaseHeaderType.ContainerChange:
                    return new BlobLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                        LeaseId = response.Headers.TryGetValue(Constants.HeaderNames.LeaseId, out string leaseId) ? leaseId : null,
                        LeaseTime = response.Headers.ExtractLeaseTime()
                    };
                case BlobLeaseHeaderType.BlobBreak:
                case BlobLeaseHeaderType.ContainerBreak:
                    // LeaseId is not returned on a broken lease.
                    return new BlobLease
                    {
                        ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string breakValue) ? new ETag(breakValue) : default,
                        LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? breakLastModified) ? breakLastModified.GetValueOrDefault() : default,
                        LeaseTime = response.Headers.ExtractLeaseTime()
                    };
                default:
                    throw new ArgumentException($"Unknown {nameof(BlobLeaseHeaderType)}: {headerType}", nameof(headerType));
            }
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
        internal static ReleasedObjectInfo ToReleasedObjectInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new ReleasedObjectInfo(
                eTag: response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                lastModified: response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default);
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
                    ? ParseObjectReplicationMetadata((IReadOnlyDictionary<string, string>)blobItemInternal.OrMetadata)
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
                ContentHash = blobPropertiesInternal.ContentMd5?.ToArray(),
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
                ETag = new ETag(blobPropertiesInternal.ETag),
                CreatedOn = blobPropertiesInternal.CreationTime,
                CopyCompletedOn = blobPropertiesInternal.CopyCompletionTime,
                DeletedOn = blobPropertiesInternal.DeletedTime,
                AccessTierChangedOn = blobPropertiesInternal.AccessTierChangeTime,
                ImmutabilityPolicy = immutabilityPolicy,
                HasLegalHold = blobPropertiesInternal.LegalHold.GetValueOrDefault(),
                SmartAccessTier = blobPropertiesInternal.SmartAccessTier
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
                Properties = BlobExtensions.ToBlobContainerProperties(containerItemInternal.Properties, (IReadOnlyDictionary<string, string>)containerItemInternal.Metadata)
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
                ETag = new ETag(containerPropertiesInternal.ETag),
                Metadata = metadata.ToMetadata(),
                HasImmutableStorageWithVersioning = containerPropertiesInternal.IsImmutableStorageWithVersioningEnabled.GetValueOrDefault(),
            };
        }

        internal static BlobContainerProperties ToBlobContainerProperties(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobContainerProperties
            {
                LastModified = response.Headers.TryGetValue(Constants.HeaderNames.LastModified, out DateTimeOffset? lastModified) ? lastModified.GetValueOrDefault() : default,
                LeaseStatus = response.Headers.TryGetValue("x-ms-lease-status", out string leaseStatus) ? leaseStatus.ToLeaseStatus() : null,
                LeaseState = response.Headers.TryGetValue("x-ms-lease-state", out string leaseState) ? leaseState.ToLeaseState() : null,
                LeaseDuration = response.Headers.TryGetValue("x-ms-lease-duration", out string leaseDuration) ? leaseDuration.ToLeaseDurationType() : LeaseDurationType.Infinite,
                PublicAccess = response.Headers.TryGetValue("x-ms-blob-public-access", out string publicAccess) ? publicAccess.ToPublicAccessType() : PublicAccessType.None,
                HasImmutabilityPolicy = response.Headers.TryGetValue("x-ms-has-immutability-policy", out bool? hasImmutabilityPolicy) ? hasImmutabilityPolicy : null,
                HasLegalHold = response.Headers.TryGetValue("x-ms-has-legal-hold", out bool? hasLegalHold) ? hasLegalHold : null,
                DefaultEncryptionScope = response.Headers.TryGetValue("x-ms-default-encryption-scope", out string defaultEncryptionScope) ? defaultEncryptionScope : null,
                PreventEncryptionScopeOverride = response.Headers.TryGetValue("x-ms-deny-encryption-scope-override", out bool? denyEncryptionScopeOverride) ? denyEncryptionScopeOverride : null,
                // Container Get Properties does not return DeletedOn.
                // Container Get Properties does not return RemainingRetentionDays.
                ETag = response.Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                Metadata = response.Headers.TryGetValue(Constants.HeaderNames.MetadataPrefix, out IDictionary<string, string> metadataValue)
                    ? metadataValue.ToMetadata()
                    : null,
                HasImmutableStorageWithVersioning = response.Headers.TryGetValue("x-ms-immutable-storage-with-versioning-enabled", out bool? immutableStorage) && immutableStorage.GetValueOrDefault()
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
        internal static BlobImmutabilityPolicy ToBlobImmutabilityPolicy(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobImmutabilityPolicy
            {
                ExpiresOn = response.Headers.TryGetValue("x-ms-immutability-policy-until-date", out DateTimeOffset? immutabilityExpiry) ? immutabilityExpiry : null,
                PolicyMode = response.Headers.TryGetValue("x-ms-immutability-policy-mode", out string immutabilityMode) ? immutabilityMode.ToBlobImmutabilityPolicyMode() : null
            };
        }
        #endregion

        #region ToBlobLegalHoldInfo
        internal static BlobLegalHoldResult ToBlobLegalHoldInfo(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new BlobLegalHoldResult
            {
                HasLegalHold = response.Headers.TryGetValue("x-ms-legal-hold", out bool? legalHold) && legalHold.GetValueOrDefault()
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
        internal static PageRangeItem[] ToPageBlobRanges(this Response<PageList> response)
        {
            if (response == null)
            {
                return null;
            }

            return ToPageBlobRanges(
                (IReadOnlyList<PageRange>)response.Value.PageRange,
                (IReadOnlyList<ClearRange>)response.Value.ClearRange);
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
