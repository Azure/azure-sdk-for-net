// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Predicate used by the snapshot pageables to decide which events fall within the
    /// half-open container-version range derived from the begin/end snapshot metadata.
    /// </summary>
    internal static class SnapshotEventFilter
    {
        /// <summary>
        /// Returns <c>true</c> when <paramref name="evt"/>'s container version number falls
        /// strictly above <paramref name="beginCvId"/> (exclusive lower bound) and at or below
        /// <paramref name="endCvId"/> (inclusive upper bound). The half-open interval matches the
        /// snapshot-range semantics: events captured by the begin snapshot are excluded from the
        /// difference, while events captured by the end snapshot are included.
        /// </summary>
        public static bool IsInRange(ShareChangeFeedEvent evt, long beginCvId, long endCvId)
            => evt.ContainerVersionNumber > beginCvId
            && evt.ContainerVersionNumber <= endCvId;
    }
}
