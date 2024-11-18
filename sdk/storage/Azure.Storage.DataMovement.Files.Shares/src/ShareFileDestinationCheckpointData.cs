// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using Azure.Storage.Common;
using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileDestinationCheckpointData : StorageResourceCheckpointDataInternal
    {
        private const char HeaderDelimiter = Constants.CommaChar;
        private const string RoundtripDateTimeFormat = "o";

        /// <summary>
        /// Schema version.
        /// </summary>
        public int Version;

        /// <summary>
        /// The content headers for the destination blob.
        /// </summary>
        public DataTransferProperty<string> CacheControl;
        public bool PreserveCacheControl;
        public byte[] CacheControlBytes;

        public DataTransferProperty<string> ContentDisposition;
        public bool PreserveContentDisposition;
        public byte[] ContentDispositionBytes;

        public DataTransferProperty<string[]> ContentEncoding;
        public bool PreserveContentEncoding;
        public byte[] ContentEncodingBytes;

        public DataTransferProperty<string[]> ContentLanguage;
        public bool PreserveContentLanguage;
        public byte[] ContentLanguageBytes;

        public DataTransferProperty<string> ContentType;
        public bool PreserveContentType;
        public byte[] ContentTypeBytes;

        /// <summary>
        /// The file system attributes for this file.
        /// </summary>
        public DataTransferProperty<NtfsFileAttributes?> FileAttributes;
        public bool PreserveFileAttributes;

        public bool PreserveFilePermission;

        /// <summary>
        /// The creation time of the file. This is stored as a string with a
        /// roundtrip format because storing as (long)ticks only supports rounding to the minute.
        /// </summary>
        public DataTransferProperty<DateTimeOffset?> FileCreatedOn;
        public bool PreserveFileCreatedOn;
        private byte[] _fileCreatedOnBytes;

        /// <summary>
        /// The last write time of the file. This is stored as a string with a
        /// roundtrip format because storing as (long)ticks only supports rounding to the minute.
        /// </summary>
        public DataTransferProperty<DateTimeOffset?> FileLastWrittenOn;
        public bool PreserveFileLastWrittenOn;
        private byte[] _fileLastWrittenOnBytes;

        /// <summary>
        /// The change time of the file. This is stored as a string with a
        /// roundtrip format because storing as (long)ticks only supports rounding to the minute.
        /// </summary>
        public DataTransferProperty<DateTimeOffset?> FileChangedOn;
        public bool PreserveFileChangedOn;
        private byte[] _fileChangedOnBytes;

        /// <summary>
        /// Metadata for destination files.
        /// </summary>
        public DataTransferProperty<Metadata> FileMetadata;
        public bool PreserveFileMetadata;
        private byte[] _fileMetadataBytes;

        /// <summary>
        /// Metadata for destination directories.
        /// </summary>
        public DataTransferProperty<Metadata> DirectoryMetadata;
        public bool PreserveDirectoryMetadata;
        private byte[] _directoryMetadataBytes;

        public override int Length => CalculateLength();

        public ShareFileDestinationCheckpointData(
            DataTransferProperty<string> contentType,
            DataTransferProperty<string[]> contentEncoding,
            DataTransferProperty<string[]> contentLanguage,
            DataTransferProperty<string> contentDisposition,
            DataTransferProperty<string> cacheControl,
            DataTransferProperty<NtfsFileAttributes?> fileAttributes,
            bool? preserveFilePermission,
            DataTransferProperty<DateTimeOffset?> fileCreatedOn,
            DataTransferProperty<DateTimeOffset?> fileLastWrittenOn,
            DataTransferProperty<DateTimeOffset?> fileChangedOn,
            DataTransferProperty<Metadata> fileMetadata,
            DataTransferProperty<Metadata> directoryMetadata)
        {
            Version = DataMovementShareConstants.DestinationCheckpointData.SchemaVersion;
            CacheControl = cacheControl;
            PreserveCacheControl = cacheControl?.Preserve ?? true;
            CacheControlBytes = cacheControl?.Value != default ? Encoding.UTF8.GetBytes(cacheControl.Value) : Array.Empty<byte>();

            ContentDisposition = contentDisposition;
            PreserveContentDisposition = contentDisposition?.Preserve ?? true;
            ContentDispositionBytes = contentDisposition?.Value != default ? Encoding.UTF8.GetBytes(contentDisposition.Value) : Array.Empty<byte>();

            ContentEncoding = contentEncoding;
            PreserveContentEncoding = contentEncoding?.Preserve ?? true;
            ContentEncodingBytes = contentEncoding?.Value != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), contentEncoding.Value)) : Array.Empty<byte>();

            ContentLanguage = contentLanguage;
            PreserveContentLanguage = contentLanguage?.Preserve ?? true;
            ContentLanguageBytes = contentLanguage?.Value != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), contentLanguage.Value)) : Array.Empty<byte>();

            ContentType = contentType;
            PreserveContentType = contentType?.Preserve ?? true;
            ContentTypeBytes = contentType?.Value != default ? Encoding.UTF8.GetBytes(contentType.Value) : Array.Empty<byte>();

            FileAttributes = fileAttributes;
            PreserveFileAttributes = fileAttributes?.Preserve ?? true;

            PreserveFilePermission = preserveFilePermission ?? false;

            FileCreatedOn = fileCreatedOn;
            PreserveFileCreatedOn = fileCreatedOn?.Preserve ?? true;
            _fileCreatedOnBytes = fileCreatedOn?.Value != default ? Encoding.UTF8.GetBytes(fileCreatedOn.Value.Value.ToString(RoundtripDateTimeFormat)) : Array.Empty<byte>();

            FileLastWrittenOn = fileLastWrittenOn;
            PreserveFileLastWrittenOn = fileLastWrittenOn?.Preserve ?? true;
            _fileLastWrittenOnBytes = fileLastWrittenOn?.Value != default ? Encoding.UTF8.GetBytes(fileLastWrittenOn.Value.Value.ToString(RoundtripDateTimeFormat)) : Array.Empty<byte>();

            FileChangedOn = fileChangedOn;
            PreserveFileChangedOn = fileChangedOn?.Preserve ?? true;
            _fileChangedOnBytes = fileChangedOn?.Value != default ? Encoding.UTF8.GetBytes(fileChangedOn.Value.Value.ToString(RoundtripDateTimeFormat)) : Array.Empty<byte>();

            FileMetadata = fileMetadata;
            PreserveFileMetadata = fileMetadata?.Preserve ?? true;
            _fileMetadataBytes = fileMetadata?.Value != default ? Encoding.UTF8.GetBytes(fileMetadata.Value.DictionaryToString()) : Array.Empty<byte>();

            DirectoryMetadata = directoryMetadata;
            PreserveDirectoryMetadata = directoryMetadata?.Preserve ?? true;
            _directoryMetadataBytes = directoryMetadata?.Value != default ? Encoding.UTF8.GetBytes(directoryMetadata.Value.DictionaryToString()) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            BinaryWriter writer = new(stream);

            // Version
            writer.Write(Version);

            // SMB properties
            writer.WritePreservablePropertyOffset(PreserveFileAttributes, DataMovementConstants.IntSizeInBytes, ref currentVariableLengthIndex);
            writer.Write(PreserveFilePermission);
            writer.WritePreservablePropertyOffset(PreserveFileCreatedOn, _fileCreatedOnBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveFileLastWrittenOn, _fileLastWrittenOnBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveFileChangedOn, _fileChangedOnBytes.Length, ref currentVariableLengthIndex);

            // HttpHeaders
            writer.WritePreservablePropertyOffset(PreserveContentType, ContentTypeBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveContentEncoding, ContentEncodingBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveContentLanguage, ContentLanguageBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveContentDisposition, ContentDispositionBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveCacheControl, CacheControlBytes.Length, ref currentVariableLengthIndex);

            // Metadata
            writer.WritePreservablePropertyOffset(PreserveFileMetadata, _fileMetadataBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(PreserveDirectoryMetadata, _directoryMetadataBytes.Length, ref currentVariableLengthIndex);

            // Variable length info
            if (!PreserveFileAttributes)
            {
                if (FileAttributes.Value == default)
                {
                    writer.Write((int)0);
                }
                else
                {
                    writer.Write((int)FileAttributes.Value);
                }
            }
            if (!PreserveFileCreatedOn)
            {
                writer.Write(_fileCreatedOnBytes);
            }
            if (!PreserveFileLastWrittenOn)
            {
                writer.Write(_fileLastWrittenOnBytes);
            }
            if (!PreserveFileChangedOn)
            {
                writer.Write(_fileChangedOnBytes);
            }
            if (!PreserveContentType)
            {
                writer.Write(ContentTypeBytes);
            }
            if (!PreserveContentEncoding)
            {
                writer.Write(ContentEncodingBytes);
            }
            if (!PreserveContentLanguage)
            {
                writer.Write(ContentLanguageBytes);
            }
            if (!PreserveContentDisposition)
            {
                writer.Write(ContentDispositionBytes);
            }
            if (!PreserveCacheControl)
            {
                writer.Write(CacheControlBytes);
            }
            if (!PreserveFileMetadata)
            {
                writer.Write(_fileMetadataBytes);
            }
            if (!PreserveDirectoryMetadata)
            {
                writer.Write(_directoryMetadataBytes);
            }
        }

        internal static ShareFileDestinationCheckpointData Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementShareConstants.DestinationCheckpointData.SchemaVersion)
            {
                throw Storage.Errors.UnsupportedJobSchemaVersionHeader(version.ToString());
            }

            // SMB properties
            (bool preserveFileAttributes, int fileAttributesOffset, int fileAttributesLength) = reader.ReadVariableLengthFieldInfo();
            bool preserveFilePermission = reader.ReadBoolean();
            (bool preserveFileCreatedOn, int fileCreatedOnOffset, int fileCreatedOnLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveFileLastWrittenOn, int fileLastWrittenOnOffset, int fileLastWrittenOnLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveFileChangedOn, int fileChangedOnOffset, int fileChangedOnLength) = reader.ReadVariableLengthFieldInfo();

            // HttpHeaders
            (bool preserveContentType, int contentTypeOffset, int contentTypeLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveContentEncoding, int contentEncodingOffset, int contentEncodingLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveContentLanguage, int contentLanguageOffset, int contentLanguageLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveContentDisposition, int contentDispositionOffset, int contentDispositionLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveCacheControl, int cacheControlOffset, int cacheControlLength) = reader.ReadVariableLengthFieldInfo();

            // Metadata
            (bool preserveFileMetadata, int fileMetadataOffset, int fileMetadataLength) = reader.ReadVariableLengthFieldInfo();
            (bool preserveDirectoryMetadata, int directoryMetadataOffset, int directoryMetadataLength) = reader.ReadVariableLengthFieldInfo();

            // NtfsFileAttributes
            NtfsFileAttributes? ntfsFileAttributes = null;
            if (fileAttributesOffset > 0)
            {
                reader.BaseStream.Position = fileAttributesOffset;
                ntfsFileAttributes = (NtfsFileAttributes) reader.ReadInt32();
            }

            // File Created On
            DateTimeOffset? fileCreatedOn = default;
            if (fileCreatedOnOffset > 0)
            {
                reader.BaseStream.Position = fileCreatedOnOffset;
                string dateTimeStr = Encoding.UTF8.GetString(reader.ReadBytes(fileCreatedOnLength));
                fileCreatedOn = DateTimeOffset.Parse(dateTimeStr, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }

            // File Last Written Time
            DateTimeOffset? fileLastWrittenOn = default;
            if (fileLastWrittenOnOffset > 0)
            {
                reader.BaseStream.Position = fileLastWrittenOnOffset;
                string dateTimeStr = Encoding.UTF8.GetString(reader.ReadBytes(fileLastWrittenOnLength));
                fileLastWrittenOn = DateTimeOffset.Parse(dateTimeStr, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }

            // File Changed Time
            DateTimeOffset? fileChangedOn = default;
            if (fileChangedOnOffset > 0)
            {
                reader.BaseStream.Position = fileChangedOnOffset;
                string dateTimeStr = Encoding.UTF8.GetString(reader.ReadBytes(fileChangedOnLength));
                fileChangedOn = DateTimeOffset.Parse(dateTimeStr, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }

            // ContentType
            string contentType = null;
            if (contentTypeOffset > 0)
            {
                reader.BaseStream.Position = contentTypeOffset;
                contentType = Encoding.UTF8.GetString(reader.ReadBytes(contentTypeLength));
            }

            // ContentEncoding
            string contentEncoding = null;
            if (contentEncodingOffset > 0)
            {
                reader.BaseStream.Position = contentEncodingOffset;
                contentEncoding = Encoding.UTF8.GetString(reader.ReadBytes(contentEncodingLength));
            }

            // ContentLanguage
            string contentLanguage = null;
            if (contentLanguageOffset > 0)
            {
                reader.BaseStream.Position = contentLanguageOffset;
                contentLanguage = Encoding.UTF8.GetString(reader.ReadBytes(contentLanguageLength));
            }

            // ContentDisposition
            string contentDisposition = null;
            if (contentDispositionOffset > 0)
            {
                reader.BaseStream.Position = contentDispositionOffset;
                contentDisposition = Encoding.UTF8.GetString(reader.ReadBytes(contentDispositionLength));
            }

            // CacheControl
            string cacheControl = null;
            if (cacheControlOffset > 0)
            {
                reader.BaseStream.Position = cacheControlOffset;
                cacheControl = Encoding.UTF8.GetString(reader.ReadBytes(cacheControlLength));
            }

            // Metadata
            string fileMetadataString = string.Empty;
            if (fileMetadataOffset > 0)
            {
                reader.BaseStream.Position = fileMetadataOffset;
                fileMetadataString = Encoding.UTF8.GetString(reader.ReadBytes(fileMetadataLength));
            }
            string directoryMetadataString = string.Empty;
            if (directoryMetadataOffset > 0)
            {
                reader.BaseStream.Position = directoryMetadataOffset;
                directoryMetadataString = Encoding.UTF8.GetString(reader.ReadBytes(directoryMetadataLength));
            }

            return new(
                contentType: preserveContentType ? new(preserveContentType) : new(contentType),
                contentEncoding: preserveContentEncoding ? new(preserveContentEncoding) : new(contentEncoding?.Split(HeaderDelimiter)),
                contentLanguage: preserveContentLanguage ? new(preserveContentLanguage) : new(contentLanguage?.Split(HeaderDelimiter)),
                contentDisposition: preserveContentDisposition ? new(preserveContentDisposition) : new(contentDisposition),
                cacheControl: preserveCacheControl ? new(preserveCacheControl) : new(cacheControl),
                fileAttributes: preserveFileAttributes ? new(preserveFileAttributes) : new(ntfsFileAttributes),
                preserveFilePermission: preserveFilePermission,
                fileCreatedOn: preserveFileCreatedOn ? new(preserveFileCreatedOn) : new(fileCreatedOn),
                fileLastWrittenOn: preserveFileLastWrittenOn ? new(preserveFileLastWrittenOn) : new(fileLastWrittenOn),
                fileChangedOn: preserveFileChangedOn ? new(preserveFileChangedOn) : new(fileChangedOn),
                fileMetadata: preserveFileMetadata ? new(preserveFileMetadata) : new(fileMetadataString?.ToDictionary(nameof(fileMetadataString))),
                directoryMetadata: preserveDirectoryMetadata ? new(preserveDirectoryMetadata) : new(directoryMetadataString?.ToDictionary(nameof(directoryMetadataString))));
        }

        private int CalculateLength()
        {
            // Length is fixed size fields plus length of each variable length field
            int length = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            if (PreserveFileAttributes)
            {
                length += DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveFileCreatedOn)
            {
                length += _fileCreatedOnBytes.Length;
            }
            if (PreserveFileLastWrittenOn)
            {
                length += _fileLastWrittenOnBytes.Length;
            }
            if (PreserveFileChangedOn)
            {
                length += _fileChangedOnBytes.Length;
            }
            if (!PreserveContentType)
            {
                length += ContentTypeBytes.Length;
            }
            if (!PreserveContentEncoding)
            {
                length += ContentEncodingBytes.Length;
            }
            if (!PreserveContentLanguage)
            {
                length += ContentLanguageBytes.Length;
            }
            if (!PreserveContentDisposition)
            {
                length += ContentDispositionBytes.Length;
            }
            if (!PreserveCacheControl)
            {
                length += CacheControlBytes.Length;
            }
            if (!PreserveFileMetadata)
            {
                length += _fileMetadataBytes.Length;
            }
            if (!PreserveDirectoryMetadata)
            {
                length += _directoryMetadataBytes.Length;
            }
            return length;
        }
    }
}
