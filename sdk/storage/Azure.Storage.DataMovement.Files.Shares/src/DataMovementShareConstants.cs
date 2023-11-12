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

            internal const int VersionIndex = 0;

            internal const int ContentTypeOffsetIndex = VersionIndex + IntSizeInBytes;
            internal const int ContentTypeLengthIndex = ContentTypeOffsetIndex + IntSizeInBytes;
            internal const int ContentEncodingOffsetIndex = ContentTypeLengthIndex + IntSizeInBytes;
            internal const int ContentEncodingLengthIndex = ContentEncodingOffsetIndex + IntSizeInBytes;
            internal const int ContentLanguageOffsetIndex = ContentEncodingLengthIndex + IntSizeInBytes;
            internal const int ContentLanguageLengthIndex = ContentLanguageOffsetIndex + IntSizeInBytes;
            internal const int ContentDispositionOffsetIndex = ContentLanguageLengthIndex + IntSizeInBytes;
            internal const int ContentDispositionLengthIndex = ContentDispositionOffsetIndex + IntSizeInBytes;
            internal const int CacheControlOffsetIndex = ContentDispositionLengthIndex + IntSizeInBytes;
            internal const int CacheControlLengthIndex = CacheControlOffsetIndex + IntSizeInBytes;

            internal const int MetadataOffsetIndex = CacheControlLengthIndex + IntSizeInBytes;
            internal const int MetadataLengthIndex = MetadataOffsetIndex + IntSizeInBytes;

            internal const int VariableLengthStartIndex = MetadataLengthIndex + IntSizeInBytes;
        }
    }
}
