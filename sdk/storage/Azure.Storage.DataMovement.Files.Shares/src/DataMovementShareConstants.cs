// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using static Azure.Storage.DataMovement.DataMovementConstants;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class DataMovementShareConstants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;

        internal const int MaxRange = 4 * MB;

        internal class SourceCheckpointDetails
        {
            // Prior to Source Files Schema Version 1, the SourceCheckpointDetails was empty and Version was not present.
            internal const int SchemaVersion_1 = 1;
            internal const int SchemaVersion = SchemaVersion_1;

            internal const int VersionEncodedSize = IntSizeInBytes;
            internal const int ShareProtocolEncodedSize = OneByte;

            internal const int VersionIndex = 0;
            internal const int ShareProtocolIndex = VersionIndex + VersionEncodedSize;
            internal const int DataSize = ShareProtocolIndex + ShareProtocolEncodedSize;
        }

        internal class DestinationCheckpointDetails
        {
            // Destination Files Schema Versions 1 and 2 were the beta version of the schema and do not need to be serialized and deserialized backwards compatible.
            // Only Destination Files Schema Versions 3 and beyond need to be backwards compatible.
            internal const int SchemaVersion_3 = 3;
            internal const int SchemaVersion_4 = 4;
            internal const int SchemaVersion = SchemaVersion_4;
            internal const int MinValidSchemaVersion = SchemaVersion_3;
            internal const int MaxValidSchemaVersion = SchemaVersion_4;

            internal const int VersionEncodedSize = IntSizeInBytes;
            internal const int PreserveEncodedSize = OneByte;
            internal const int OffsetLengthEncodedSize = IntSizeInBytes;
            internal const int ShareProtocolEncodedSize = OneByte;

            internal const int VersionIndex = 0;

            internal const int PreserveFileAttributesIndex = VersionIndex + VersionEncodedSize;
            internal const int FileAttributesOffsetIndex = PreserveFileAttributesIndex + PreserveEncodedSize;
            internal const int FileAttributesLengthIndex = FileAttributesOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveFilePermissionIndex = FileAttributesLengthIndex + PreserveEncodedSize;

            internal const int PreserveFileCreatedOnIndex = PreserveFilePermissionIndex + OffsetLengthEncodedSize;
            internal const int FileCreatedOnIndex = PreserveFileCreatedOnIndex + PreserveEncodedSize;
            internal const int FileCreatedOnLengthIndex = FileCreatedOnIndex + OffsetLengthEncodedSize;

            internal const int PreserveFileLastWrittenOnIndex = FileCreatedOnLengthIndex + OffsetLengthEncodedSize;
            internal const int FileLastWrittenOnIndex = PreserveFileLastWrittenOnIndex + PreserveEncodedSize;
            internal const int FileLastWrittenOnLengthIndex = FileLastWrittenOnIndex + OffsetLengthEncodedSize;

            internal const int PreserveFileChangedOn = FileLastWrittenOnLengthIndex + OffsetLengthEncodedSize;
            internal const int FileChangedOnIndex = PreserveFileChangedOn + PreserveEncodedSize;
            internal const int FileChangedOnLengthIndex = FileChangedOnIndex + OffsetLengthEncodedSize;

            internal const int PreserveContentTypeIndex = FileChangedOnLengthIndex + OffsetLengthEncodedSize;
            internal const int ContentTypeOffsetIndex = PreserveContentTypeIndex + PreserveEncodedSize;
            internal const int ContentTypeLengthIndex = ContentTypeOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveContentEncodingIndex = ContentTypeLengthIndex + OffsetLengthEncodedSize;
            internal const int ContentEncodingOffsetIndex = PreserveContentEncodingIndex + PreserveEncodedSize;
            internal const int ContentEncodingLengthIndex = ContentEncodingOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveContentLanguageIndex = ContentEncodingLengthIndex + OffsetLengthEncodedSize;
            internal const int ContentLanguageOffsetIndex = PreserveContentLanguageIndex + PreserveEncodedSize;
            internal const int ContentLanguageLengthIndex = ContentLanguageOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveContentDispositionIndex = ContentLanguageLengthIndex + OffsetLengthEncodedSize;
            internal const int ContentDispositionOffsetIndex = PreserveContentDispositionIndex + PreserveEncodedSize;
            internal const int ContentDispositionLengthIndex = ContentDispositionOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveCacheControlIndex = ContentDispositionLengthIndex + OffsetLengthEncodedSize;
            internal const int CacheControlOffsetIndex = PreserveCacheControlIndex + PreserveEncodedSize;
            internal const int CacheControlLengthIndex = CacheControlOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveFileMetadataIndex = CacheControlLengthIndex + OffsetLengthEncodedSize;
            internal const int FileMetadataOffsetIndex = PreserveFileMetadataIndex + PreserveEncodedSize;
            internal const int FileMetadataLengthIndex = FileMetadataOffsetIndex + OffsetLengthEncodedSize;

            internal const int PreserveDirectoryMetadataIndex = FileMetadataLengthIndex + OffsetLengthEncodedSize;
            internal const int DirectoryMetadataOffsetIndex = PreserveDirectoryMetadataIndex + PreserveEncodedSize;
            internal const int DirectoryMetadataLengthIndex = DirectoryMetadataOffsetIndex + OffsetLengthEncodedSize;

            internal const int ShareProtocolIndex = DirectoryMetadataLengthIndex + OffsetLengthEncodedSize;

            internal const int VariableLengthStartIndex = ShareProtocolIndex + ShareProtocolEncodedSize;
        }
    }
}
