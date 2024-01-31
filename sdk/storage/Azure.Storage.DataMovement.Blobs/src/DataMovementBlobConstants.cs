// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using static Azure.Storage.DataMovement.DataMovementConstants;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class DataMovementBlobConstants
    {
        internal class SourceCheckpointData
        {
            internal const int SchemaVersion = 1;

            internal const int VersionIndex = 0;
            internal const int BlobTypeIndex = VersionIndex + IntSizeInBytes;
            internal const int DataSize = BlobTypeIndex + OneByte;
        }

        internal class DestinationCheckpointData
        {
            internal const int SchemaVersion = 1;

            internal const int VersionIndex = 0;
            internal const int BlobTypeIndex = VersionIndex + IntSizeInBytes;
            internal const int PreserveContentTypeIndex = BlobTypeIndex + OneByte;
            internal const int PreserveContentEncodingIndex = PreserveContentTypeIndex + OneByte;
            internal const int PreserveContentLanguageIndex = PreserveContentEncodingIndex + OneByte;
            internal const int PreserveContentDispositionIndex = PreserveContentLanguageIndex + OneByte;
            internal const int PreserveCacheControlIndex = PreserveContentDispositionIndex + OneByte;
            internal const int PreserveAccessTierIndex = PreserveCacheControlIndex + OneByte;
            internal const int PreserveMetadataIndex = PreserveAccessTierIndex + OneByte;
            internal const int PreserveTagsIndex = PreserveMetadataIndex + OneByte;
            internal const int OptionalIndexValuesStartIndex = PreserveTagsIndex + OneByte;
        }
    }
}
