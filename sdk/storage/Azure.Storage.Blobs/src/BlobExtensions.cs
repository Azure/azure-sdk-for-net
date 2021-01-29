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
        internal static IList<ObjectReplicationPolicy> ParseObjectReplicationMetadata(this IDictionary<string, string> OrMetadata)
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
            else
            {
                return RehydratePriority.Standard;
            }
        }

        // TODO
        internal static AccountInfo ToAccountInfo(this ResponseWithHeaders<ServiceGetAccountInfoHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContainerInfo ToBlobContainerInfo(this ResponseWithHeaders<ContainerCreateHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContainerProperties ToBlobContainerProperties(this ResponseWithHeaders<ContainerGetPropertiesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContainerInfo ToBlobContainerInfo(this ResponseWithHeaders<ContainerSetMetadataHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContainerAccessPolicy ToBlobContainerAccessPolicy(
            this ResponseWithHeaders<IReadOnlyList<BlobSignedIdentifier>, ContainerGetAccessPolicyHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContainerInfo ToBlobContainerInfo(this ResponseWithHeaders<ContainerSetAccessPolicyHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<AppendBlobCreateHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobAppendInfo ToBlobAppendInfo(this ResponseWithHeaders<AppendBlobAppendBlockHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobAppendInfo ToBlobAppendInfo(this ResponseWithHeaders<AppendBlobAppendBlockFromUrlHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobInfo ToBlobInfo(this ResponseWithHeaders<AppendBlobSealHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<PageBlobCreateHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageInfo ToPageInfo(this ResponseWithHeaders<PageBlobUploadPagesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageInfo ToPageInfo(this ResponseWithHeaders<PageBlobClearPagesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageRangesInfo ToPageRangesInfo(this ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageRangesInfo ToPageRangesInfo(this ResponseWithHeaders<PageList, PageBlobGetPageRangesDiffHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageBlobInfo ToPageBlobInfo(this ResponseWithHeaders<PageBlobResizeHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageBlobInfo ToPageBlobInfo(this ResponseWithHeaders<PageBlobUpdateSequenceNumberHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobCopyInfo ToBlobCopyInfo(this ResponseWithHeaders<PageBlobCopyIncrementalHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PageInfo ToPageInfo(this ResponseWithHeaders<PageBlobUploadPagesFromURLHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<BlockBlobUploadHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlockInfo ToBlockInfo(this ResponseWithHeaders<BlockBlobStageBlockHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlockInfo ToBlockInfo(this ResponseWithHeaders<BlockBlobStageBlockFromURLHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<BlockBlobCommitBlockListHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlockList ToBlockList(this ResponseWithHeaders<BlockList, BlockBlobGetBlockListHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobContentInfo ToBlobContentInfo(this ResponseWithHeaders<BlockBlobPutBlobFromUrlHeaders> response)
        {
            return null;
        }

        // TODO
#pragma warning disable CA1801 // Review unused parameters
        internal static BlobDownloadInfo ToBlobDownloadInfo(ResponseWithHeaders<Stream, BlobQueryHeaders> response, Stream stream)
#pragma warning restore CA1801 // Review unused parameters
        {
            return null;
        }

        // TODO
        internal static BlobSnapshotInfo ToBlobSnapshotInfo(this ResponseWithHeaders<BlobCreateSnapshotHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobInfo ToBlobInfo(this ResponseWithHeaders<BlobSetMetadataHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobInfo ToBlobInfo(this ResponseWithHeaders<BlobSetHttpHeadersHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobProperties ToBlobProperties(this ResponseWithHeaders<BlobGetPropertiesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobCopyInfo ToBlobCopyInfo(this ResponseWithHeaders<BlobCopyFromURLHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobCopyInfo ToBlobCopyInfo(this ResponseWithHeaders<BlobStartCopyFromURLHeaders> response)
        {
            return null;
        }

        // TODO
#pragma warning disable CA1801 // Review unused parameters
        internal static BlobDownloadInfo ToBlobDownloadInfo(ResponseWithHeaders<Stream, BlobDownloadHeaders> response, Stream stream)
#pragma warning restore CA1801 // Review unused parameters
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobAcquireLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerAcquireLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobRenewLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerRenewLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ReleasedObjectInfo ToReleasedObjectInfo(this ResponseWithHeaders<BlobReleaseLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ReleasedObjectInfo ToReleasedObjectInfo(this ResponseWithHeaders<ContainerReleaseLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobChangeLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerChangeLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<BlobBreakLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static BlobLease ToBlobLease(this ResponseWithHeaders<ContainerBreakLeaseHeaders> response)
        {
            return null;
        }
    }
}
