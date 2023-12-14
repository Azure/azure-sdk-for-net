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
            internal const int ContentTypeOffsetIndex = BlobTypeIndex + OneByte;
            internal const int ContentTypeLengthIndex = ContentTypeOffsetIndex + IntSizeInBytes;
            internal const int ContentEncodingOffsetIndex = ContentTypeLengthIndex + IntSizeInBytes;
            internal const int ContentEncodingLengthIndex = ContentEncodingOffsetIndex + IntSizeInBytes;
            internal const int ContentLanguageOffsetIndex = ContentEncodingLengthIndex + IntSizeInBytes;
            internal const int ContentLanguageLengthIndex = ContentLanguageOffsetIndex + IntSizeInBytes;
            internal const int ContentDispositionOffsetIndex = ContentLanguageLengthIndex + IntSizeInBytes;
            internal const int ContentDispositionLengthIndex = ContentDispositionOffsetIndex + IntSizeInBytes;
            internal const int CacheControlOffsetIndex = ContentDispositionLengthIndex + IntSizeInBytes;
            internal const int CacheControlLengthIndex = CacheControlOffsetIndex + IntSizeInBytes;
            internal const int AccessTierIndex = CacheControlLengthIndex + IntSizeInBytes;
            internal const int MetadataOffsetIndex = AccessTierIndex + OneByte;
            internal const int MetadataLengthIndex = MetadataOffsetIndex + IntSizeInBytes;
            internal const int BlobTagsOffsetIndex = MetadataLengthIndex + IntSizeInBytes;
            internal const int BlobTagsLengthIndex = BlobTagsOffsetIndex + IntSizeInBytes;
            internal const int VariableLengthStartIndex = BlobTagsLengthIndex + IntSizeInBytes;
        }
    }
}
