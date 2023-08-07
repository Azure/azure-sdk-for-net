// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Runtime.InteropServices;

namespace Azure.Storage.DataMovement.JobPlan
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct JobChunkPlanBody
    {
        // Once set, the following fields are constants; they should never be modified

        /// <summary>
        /// SrcOffset represents the actual start offset transfer header written in JobPartOrder file
        /// </summary>
        public long SrcOffset;

        /// <summary>
        /// SrcLength represents the actual length of source string for specific transfer
        /// </summary>
        public short SrcLength;

        /// <summary>
        /// DstLength represents the actual length of destination string for specific transfer
        /// </summary>
        public short DstLength;

        /// <summary>
        /// EntityType indicates whether this is a file or a folder
        /// We use a dedicated field for this because the alternative (of doing something fancy the names) was too complex and error-prone
        /// </summary>
        public byte EntityType;

        /// <summary>
        /// ModifiedTime represents the last time at which source was modified before start of transfer stored as nanoseconds.
        /// </summary>
        public long ModifiedTime;

        /// <summary>
        /// SourceSize represents the actual size of the source on disk
        /// </summary>
        public long SourceSize;

        /// <summary>
        /// CompletionTime represents the time at which transfer was completed
        /// </summary>
        public ulong CompletionTime;

        // For S2S copy, per Transfer source's properties
        public short SrcContentTypeLength;
        public short SrcContentEncodingLength;
        public short SrcContentLanguageLength;
        public short SrcContentDispositionLength;
        public short SrcCacheControlLength;
        public short SrcContentMD5Length;
        public short SrcMetadataLength;
        public short SrcBlobTypeLength;
        public short SrcBlobTierLength;
        public short SrcBlobVersionIDLength;
        public short SrcBlobTagsLength;

        // Any fields below this comment are NOT constants; they may change over as the transfer is processed.
        // Care must be taken to read/write to these fields in a thread-safe way!

        // atomicTransferStatus represents the status of current transfer (TransferInProgress, TransferFailed or TransfersCompleted)
        // atomicTransferStatus should not be directly accessed anywhere except by transferStatus and setTransferStatus
        public int atomicTransferStatus;
        // atomicErrorCode represents the storageError error code of the error with which the transfer got failed.
        // atomicErrorCode has a default value (0) which means either there was no error or transfer failed because some non storageError.
        // atomicErrorCode should not be directly accessed anywhere except by transferStatus and setTransferStatus
        public int atomicErrorCode;
    }
}
