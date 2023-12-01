// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Core;
using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileDestinationCheckpointData : StorageResourceCheckpointDataInternal
    {
        private const char HeaderDelimiter = Constants.CommaChar;

        /// <summary>
        /// Schema version.
        /// </summary>
        public int Version;

        /// <summary>
        /// The content headers for the destination blob.
        /// </summary>
        public ShareFileHttpHeaders ContentHeaders;
        private byte[] _contentTypeBytes;
        private byte[] _contentEncodingBytes;
        private byte[] _contentLanguageBytes;
        private byte[] _contentDispositionBytes;
        private byte[] _cacheControlBytes;

        /// <summary>
        /// Metadata for destination files.
        /// </summary>
        public Metadata FileMetadata;
        private byte[] _fileMetadataBytes;

        /// <summary>
        /// Metadata for destination directories.
        /// </summary>
        public Metadata DirectoryMetadata;
        private byte[] _directoryMetadataBytes;

        public FileSmbProperties SmbProperties;
        private byte[] _filePermissionKeyBytes;

        public override int Length => CalculateLength();

        public ShareFileDestinationCheckpointData(
            ShareFileHttpHeaders contentHeaders,
            Metadata fileMetadata,
            Metadata directoryMetadata,
            FileSmbProperties fileSmbProperties)
        {
            Version = DataMovementShareConstants.DestinationCheckpointData.SchemaVersion;
            ContentHeaders = contentHeaders;
            _contentTypeBytes = ContentHeaders?.ContentType != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentType) : Array.Empty<byte>();
            _contentEncodingBytes = ContentHeaders?.ContentEncoding != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), ContentHeaders.ContentEncoding)) : Array.Empty<byte>();
            _contentLanguageBytes = ContentHeaders?.ContentLanguage != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), ContentHeaders.ContentLanguage)) : Array.Empty<byte>();
            _contentDispositionBytes = ContentHeaders?.ContentDisposition != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentDisposition) : Array.Empty<byte>();
            _cacheControlBytes = ContentHeaders?.CacheControl != default ? Encoding.UTF8.GetBytes(ContentHeaders.CacheControl) : Array.Empty<byte>();
            FileMetadata = fileMetadata;
            _fileMetadataBytes = FileMetadata != default ? Encoding.UTF8.GetBytes(FileMetadata.DictionaryToString()) : Array.Empty<byte>();
            DirectoryMetadata = directoryMetadata;
            _directoryMetadataBytes = DirectoryMetadata != default ? Encoding.UTF8.GetBytes(DirectoryMetadata.DictionaryToString()) : Array.Empty<byte>();
            SmbProperties = fileSmbProperties;
            _filePermissionKeyBytes = SmbProperties?.FilePermissionKey != default ? Encoding.UTF8.GetBytes(SmbProperties.FilePermissionKey) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            BinaryWriter writer = new(stream);

            // Version
            writer.Write(Version);

            // SMB properties
            writer.Write((int?)SmbProperties?.FileAttributes);
            writer.WriteVariableLengthFieldInfo(_filePermissionKeyBytes.Length, ref currentVariableLengthIndex);
            writer.Write(SmbProperties?.FileCreatedOn);
            writer.Write(SmbProperties?.FileLastWrittenOn);
            writer.Write(SmbProperties?.FileChangedOn);

            // HttpHeaders
            writer.WriteVariableLengthFieldInfo(_contentTypeBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_contentEncodingBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_contentLanguageBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_contentDispositionBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_cacheControlBytes.Length, ref currentVariableLengthIndex);

            // Metadata
            writer.WriteVariableLengthFieldInfo(_fileMetadataBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_directoryMetadataBytes.Length, ref currentVariableLengthIndex);

            // Variable length info
            writer.Write(_filePermissionKeyBytes);
            writer.Write(_contentTypeBytes);
            writer.Write(_contentEncodingBytes);
            writer.Write(_contentLanguageBytes);
            writer.Write(_contentDispositionBytes);
            writer.Write(_cacheControlBytes);
            writer.Write(_fileMetadataBytes);
            writer.Write(_directoryMetadataBytes);
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
            NtfsFileAttributes? ntfsFileAttributes = (NtfsFileAttributes?)reader.ReadNullableInt32();
            (int filePermissionKeyOffset, int filePermissionKeyLength) = reader.ReadVariableLengthFieldInfo();
            DateTimeOffset? fileCreatedOn = reader.ReadNullableDateTimeOffset();
            DateTimeOffset? fileLastWrittenOn = reader.ReadNullableDateTimeOffset();
            DateTimeOffset? fileChangedOn = reader.ReadNullableDateTimeOffset();

            // HttpHeaders
            (int contentTypeOffset, int contentTypeLength) = reader.ReadVariableLengthFieldInfo();
            (int contentEncodingOffset, int contentEncodingLength) = reader.ReadVariableLengthFieldInfo();
            (int contentLanguageOffset, int contentLanguageLength) = reader.ReadVariableLengthFieldInfo();
            (int contentDispositionOffset, int contentDispositionLength) = reader.ReadVariableLengthFieldInfo();
            (int cacheControlOffset, int cacheControlLength) = reader.ReadVariableLengthFieldInfo();

            // Metadata
            (int fileMetadataOffset, int fileMetadataLength) = reader.ReadVariableLengthFieldInfo();
            (int directoryMetadataOffset, int directoryMetadataLength) = reader.ReadVariableLengthFieldInfo();

            // ContentType
            string contentType = null;
            if (contentTypeOffset > 0)
            {
                reader.BaseStream.Position = contentTypeOffset;
                contentType = Encoding.UTF8.GetString(reader.ReadBytes(contentTypeLength));
            }

            // ContentType
            string filePermissionKey = null;
            if (contentTypeOffset > 0)
            {
                reader.BaseStream.Position = filePermissionKeyOffset;
                filePermissionKey = Encoding.UTF8.GetString(reader.ReadBytes(filePermissionKeyLength));
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

            ShareFileHttpHeaders contentHeaders = new()
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding?.Split(HeaderDelimiter),
                ContentLanguage = contentLanguage?.Split(HeaderDelimiter),
                ContentDisposition = contentDisposition,
                CacheControl = cacheControl,
            };

            FileSmbProperties smbProperties = new()
            {
                FileAttributes = ntfsFileAttributes,
                FilePermissionKey = filePermissionKey,
                FileCreatedOn = fileCreatedOn,
                FileLastWrittenOn = fileLastWrittenOn,
                FileChangedOn = fileChangedOn,
            };

            return new(
                contentHeaders,
                fileMetadataString.ToDictionary(nameof(fileMetadataString)),
                directoryMetadataString.ToDictionary(nameof(directoryMetadataString)),
                smbProperties);
        }

        private int CalculateLength()
        {
            // Length is fixed size fields plus length of each variable length field
            int length = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            length += _contentTypeBytes.Length;
            length += _contentEncodingBytes.Length;
            length += _contentLanguageBytes.Length;
            length += _contentDispositionBytes.Length;
            length += _cacheControlBytes.Length;
            length += _fileMetadataBytes.Length;
            length += _directoryMetadataBytes.Length;
            return length;
        }
    }
}
