// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using static Azure.Storage.DataMovement.DataMovementConstants;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class DataMovementShareConstants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;

        internal const int MaxRange = 4 * MB;

        internal class SourceCheckpointData
        {
            internal const int DataSize = 0;
        }

        internal class DestinationCheckpointData
        {
            internal const int SchemaVersion = 1;

            private const int VersionEncodedSize = IntSizeInBytes;
            private const int FileAttributesEncodedSize = OneByte + IntSizeInBytes;
            private const int FilePermissionKeyOffsetEncodedSize = IntSizeInBytes;
            private const int FilePermissionKeyLengthEncodedSize = IntSizeInBytes;
            private const int FileCreatedOnEncodedSize = OneByte + LongSizeInBytes;
            private const int FileLastWrittenOnEncodedSize = OneByte + LongSizeInBytes;
            private const int FileChangedOnEncodedSize = OneByte + LongSizeInBytes;
            private const int ContentTypeOffsetEncodedSize = IntSizeInBytes;
            private const int ContentTypeLengthEncodedSize = IntSizeInBytes;
            private const int ContentEncodingOffsetEncodedSize = IntSizeInBytes;
            private const int ContentEncodingLengthEncodedSize = IntSizeInBytes;
            private const int ContentLanguageOffsetEncodedSize = IntSizeInBytes;
            private const int ContentLanguageLengthEncodedSize = IntSizeInBytes;
            private const int ContentDispositionOffsetEncodedSize = IntSizeInBytes;
            private const int ContentDispositionLengthEncodedSize = IntSizeInBytes;
            private const int CacheControlOffsetEncodedSize = IntSizeInBytes;
            private const int CacheControlLengthEncodedSize = IntSizeInBytes;
            private const int FileMetadataOffsetEncodedSize = IntSizeInBytes;
            private const int FileMetadataLengthEncodedSize = IntSizeInBytes;
            private const int DirectoryMetadataOffsetEncodedSize = IntSizeInBytes;
            private const int DirectoryMetadataLengthEncodedSize = IntSizeInBytes;

            internal const int VersionIndex = 0;

            internal const int FileAttributesIndex = VersionIndex + VersionEncodedSize;
            internal const int FilePermissionKeyOffsetIndex = FileAttributesIndex + FileAttributesEncodedSize;
            internal const int FilePermissionKeyLengthIndex = FilePermissionKeyOffsetIndex + FilePermissionKeyOffsetEncodedSize;
            internal const int FileCreatedOnIndex = FilePermissionKeyLengthIndex + FilePermissionKeyLengthEncodedSize;
            internal const int FileLastWrittenOnIndex = FileCreatedOnIndex + FileCreatedOnEncodedSize;
            internal const int FileChangedOnIndex = FileLastWrittenOnIndex + FileLastWrittenOnEncodedSize;

            internal const int ContentTypeOffsetIndex = FileChangedOnIndex + FileChangedOnEncodedSize;
            internal const int ContentTypeLengthIndex = ContentTypeOffsetIndex + ContentTypeOffsetEncodedSize;
            internal const int ContentEncodingOffsetIndex = ContentTypeLengthIndex + ContentTypeLengthEncodedSize;
            internal const int ContentEncodingLengthIndex = ContentEncodingOffsetIndex + ContentEncodingOffsetEncodedSize;
            internal const int ContentLanguageOffsetIndex = ContentEncodingLengthIndex + ContentEncodingLengthEncodedSize;
            internal const int ContentLanguageLengthIndex = ContentLanguageOffsetIndex + ContentLanguageOffsetEncodedSize;
            internal const int ContentDispositionOffsetIndex = ContentLanguageLengthIndex + ContentLanguageLengthEncodedSize;
            internal const int ContentDispositionLengthIndex = ContentDispositionOffsetIndex + ContentDispositionOffsetEncodedSize;
            internal const int CacheControlOffsetIndex = ContentDispositionLengthIndex + ContentDispositionLengthEncodedSize;
            internal const int CacheControlLengthIndex = CacheControlOffsetIndex + CacheControlOffsetEncodedSize;

            internal const int FileMetadataOffsetIndex = CacheControlLengthIndex + CacheControlLengthEncodedSize;
            internal const int FileMetadataLengthIndex = FileMetadataOffsetIndex + FileMetadataOffsetEncodedSize;
            internal const int DirectoryMetadataOffsetIndex = FileMetadataLengthIndex + FileMetadataLengthEncodedSize;
            internal const int DirectoryMetadataLengthIndex = DirectoryMetadataOffsetIndex + DirectoryMetadataOffsetEncodedSize;

            internal const int VariableLengthStartIndex = DirectoryMetadataLengthIndex + DirectoryMetadataLengthEncodedSize;
        }
    }
}
