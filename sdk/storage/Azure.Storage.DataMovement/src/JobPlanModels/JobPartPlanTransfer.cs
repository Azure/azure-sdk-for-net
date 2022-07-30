// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    internal class JobPartPlanTransfer
    {
        // Once set, the following fields are constants; they should never be modified

        /// <summary>
        /// SrcOffset represents the actual start offset transfer header written in JobPartOrder file
        /// </summary>
        public long SrcOffset { get; internal set; }

        /// <summary>
        /// SrcLength represents the actual length of source string for specific transfer
        /// </summary>
        public short SrcLength { get; internal set; }

        /// <summary>
        /// DstLength represents the actual length of destination string for specific transfer
        /// </summary>
        public short DstLength { get; internal set; }

        /// <summary>
        /// EntityType indicates whether this is a file or a folder
        /// We use a dedicated field for this because the alternative (of doing something fancy the names) was too complex and error-prone
        /// </summary>
        public byte EntityType { get; internal set; }

        /// <summary>
        /// ModifiedTime represents the last time at which source was modified before start of transfer stored as nanoseconds.
        /// </summary>
        public long ModifiedTime { get; internal set; }

        /// <summary>
        /// SourceSize represents the actual size of the source on disk
        /// </summary>
        public long SourceSize { get; internal set; }

        /// <summary>
        /// CompletionTime represents the time at which transfer was completed
        /// </summary>
        public ulong CompletionTime { get; internal set; }

        // For S2S copy, per Transfer source's properties
        public short SrcContentTypeLength { get; internal set; }
        public short SrcContentEncodingLength { get; internal set; }
        public short SrcContentLanguageLength { get; internal set; }
        public short SrcContentDispositionLength { get; internal set; }
        public short SrcCacheControlLength { get; internal set; }
        public short SrcContentMD5Length { get; internal set; }
        public short SrcMetadataLength { get; internal set; }
        public short SrcBlobTypeLength { get; internal set; }
        public short SrcBlobTierLength { get; internal set; }
        public short SrcBlobVersionIDLength { get; internal set; }
        public short SrcBlobTagsLength { get; internal set; }

    // Any fields below this comment are NOT constants; they may change over as the transfer is processed.
    // Care must be taken to read/write to these fields in a thread-safe way!

    // atomicTransferStatus represents the status of current transfer (TransferInProgress, TransferFailed or TransfersCompleted)
    // atomicTransferStatus should not be directly accessed anywhere except by transferStatus and setTransferStatus
        public int atomicTransferStatus { get; set; }
    // atomicErrorCode represents the storageError error code of the error with which the transfer got failed.
    // atomicErrorCode has a default value (0) which means either there was no error or transfer failed because some non storageError.
    // atomicErrorCode should not be directly accessed anywhere except by transferStatus and setTransferStatus
        public int atomicErrorCode { get; set; }
    }
}
