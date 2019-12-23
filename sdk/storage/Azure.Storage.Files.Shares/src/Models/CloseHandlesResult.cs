// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The result of a force close handle or force close all handles operation.
    /// </summary>
    public class CloseHandlesResult
    {
        /// <summary>
        /// The number of file handles that were closed.
        /// </summary>
        public int ClosedHandlesCount { get; internal set; }

        /// <summary>
        /// The number of file handles that fialed to close.
        /// </summary>
        public int FailedHandlesCount { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ClosedHandlesInfo instances.
        /// You can use FileModelFactory.ClosedHandlesInfo instead.
        /// </summary>
        internal CloseHandlesResult() { }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FileModelFactory
    {
        /// <summary>
        /// Creates a new ClosedHandlesInfo instance for mocking.
        /// </summary>
        public static CloseHandlesResult ClosedHandlesInfo(
            int closedHandlesCount)
            => ClosedHandlesInfo(
                closedHandlesCount: closedHandlesCount,
                failedHandlesCount: 0);

        /// <summary>
        /// Creates a new ClosedHandlesInfo instance for mocking.
        /// </summary>
        public static CloseHandlesResult ClosedHandlesInfo(
            int closedHandlesCount,
            int failedHandlesCount)
            => new CloseHandlesResult()
            {
                ClosedHandlesCount = closedHandlesCount,
                FailedHandlesCount = failedHandlesCount
            };
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class ShareExtensions
    {
        internal static CloseHandlesResult ToCloseHandlesResult(this Response<StorageClosedHandlesSegment> storageClosedHandlesSegment)
        {
            if (storageClosedHandlesSegment == null || storageClosedHandlesSegment.Value == null)
            {
                return null;
            }

            return new CloseHandlesResult
            {
                ClosedHandlesCount = storageClosedHandlesSegment.Value.NumberOfHandlesClosed,
                FailedHandlesCount = storageClosedHandlesSegment.Value.NumberOfHandlesFailedToClose
            };
        }
    }
}
