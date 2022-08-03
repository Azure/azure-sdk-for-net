// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Used to return back information of the task thats running
    /// </summary>
    internal struct UploadBlobTask
    {
        /// <summary>
        /// Checking to see if the task needs to have a commit block list at the end
        /// </summary>
        public bool IsSinglePutRequest { get; internal set; }

        /// <summary>
        /// Offset of the partition, can be 0
        /// </summary>
        public long Offset { get; internal set; }

        /// <summary>
        /// Length of the partition, can be the length of the entire blob
        /// </summary>
        public long Length { get; internal set; }

        /// <summary>
        /// Delegate representing the unique task to stage the block
        /// </summary>
        public Func<Task> DelegateTask { get; internal set; }

        public UploadBlobTask(
            bool isSinglePutRequest,
            long offset,
            long length,
            Func<Task> delegateTask)
        {
            IsSinglePutRequest = isSinglePutRequest;
            Offset = offset;
            Length = length;
            DelegateTask = delegateTask;
        }
    }
}
