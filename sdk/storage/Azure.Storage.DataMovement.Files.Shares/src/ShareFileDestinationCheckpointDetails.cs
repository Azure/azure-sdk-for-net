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
    internal class ShareFileDestinationCheckpointDetails : StorageResourceCheckpointDetailsInternal
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
        public string CacheControl;
        public bool IsCacheControlSet;
        public byte[] CacheControlBytes;

        public string ContentDisposition;
        public bool IsContentDispositionSet;
        public byte[] ContentDispositionBytes;

        public string[] ContentEncoding;
        public bool IsContentEncodingSet;
        public byte[] ContentEncodingBytes;

        public string[] ContentLanguage;
        public bool IsContentLanguageSet;
        public byte[] ContentLanguageBytes;

        public string ContentType;
        public bool IsContentTypeSet;
        public byte[] ContentTypeBytes;

        /// <summary>
        /// The file system attributes for this file.
        /// </summary>
        public NtfsFileAttributes? FileAttributes;
        public bool IsFileAttributesSet;

        public bool FilePermission;

        /// <summary>
        /// The creation time of the file. This is stored as a string with a
        /// roundtrip format because storing as (long)ticks only supports rounding to the minute.
        /// </summary>
        public DateTimeOffset? FileCreatedOn;
        public bool IsFileCreatedOnSet;
        private byte[] _fileCreatedOnBytes;

        /// <summary>
        /// The last write time of the file. This is stored as a string with a
        /// roundtrip format because storing as (long)ticks only supports rounding to the minute.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn;
        public bool IsFileLastWrittenOnSet;
        private byte[] _fileLastWrittenOnBytes;

        /// <summary>
        /// The change time of the file. This is stored as a string with a
        /// roundtrip format because storing as (long)ticks only supports rounding to the minute.
        /// </summary>
        public DateTimeOffset? FileChangedOn;
        public bool IsFileChangedOnSet;
        private byte[] _fileChangedOnBytes;

        /// <summary>
        /// Metadata for destination files.
        /// </summary>
        public Metadata FileMetadata;
        public bool IsFileMetadataSet;
        private byte[] _fileMetadataBytes;

        /// <summary>
        /// Metadata for destination directories.
        /// </summary>
        public Metadata DirectoryMetadata;
        public bool IsDirectoryMetadataSet;
        private byte[] _directoryMetadataBytes;

        /// <summary>
        /// Share Protocol for destination files/directories.
        /// </summary>
        public ShareProtocol ShareProtocol;

        public override int Length => CalculateLength();

        public ShareFileDestinationCheckpointDetails(
            bool isContentTypeSet,
            string contentType,
            bool isContentEncodingSet,
            string[] contentEncoding,
            bool isContentLanguageSet,
            string[] contentLanguage,
            bool isContentDispositionSet,
            string contentDisposition,
            bool isCacheControlSet,
            string cacheControl,
            bool isFileAttributesSet,
            NtfsFileAttributes? fileAttributes,
            bool? filePermissions,
            bool isFileCreatedOnSet,
            DateTimeOffset? fileCreatedOn,
            bool isFileLastWrittenOnSet,
            DateTimeOffset? fileLastWrittenOn,
            bool isFileChangedOnSet,
            DateTimeOffset? fileChangedOn,
            bool isFileMetadataSet,
            Metadata fileMetadata,
            bool isDirectoryMetadataSet,
            Metadata directoryMetadata,
            ShareProtocol shareProtocol)
        {
            Version = DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion;
            CacheControl = cacheControl;
            IsCacheControlSet = isCacheControlSet;
            CacheControlBytes = cacheControl != default ? Encoding.UTF8.GetBytes(cacheControl) : Array.Empty<byte>();

            ContentDisposition = contentDisposition;
            IsContentDispositionSet = isContentDispositionSet;
            ContentDispositionBytes = contentDisposition != default ? Encoding.UTF8.GetBytes(contentDisposition) : Array.Empty<byte>();

            ContentEncoding = contentEncoding;
            IsContentEncodingSet = isContentEncodingSet;
            ContentEncodingBytes = contentEncoding != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), contentEncoding)) : Array.Empty<byte>();

            ContentLanguage = contentLanguage;
            IsContentLanguageSet = isContentLanguageSet;
            ContentLanguageBytes = contentLanguage != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), contentLanguage)) : Array.Empty<byte>();

            ContentType = contentType;
            IsContentTypeSet = isContentTypeSet;
            ContentTypeBytes = contentType != default ? Encoding.UTF8.GetBytes(contentType) : Array.Empty<byte>();

            FileAttributes = fileAttributes;
            IsFileAttributesSet = isFileAttributesSet;

            FilePermission = filePermissions ?? false;

            FileCreatedOn = fileCreatedOn;
            IsFileCreatedOnSet = isFileCreatedOnSet;
            _fileCreatedOnBytes = fileCreatedOn != default ? Encoding.UTF8.GetBytes(fileCreatedOn.Value.ToString(RoundtripDateTimeFormat)) : Array.Empty<byte>();

            FileLastWrittenOn = fileLastWrittenOn;
            IsFileLastWrittenOnSet = isFileLastWrittenOnSet;
            _fileLastWrittenOnBytes = fileLastWrittenOn != default ? Encoding.UTF8.GetBytes(fileLastWrittenOn.Value.ToString(RoundtripDateTimeFormat)) : Array.Empty<byte>();

            FileChangedOn = fileChangedOn;
            IsFileChangedOnSet = isFileChangedOnSet;
            _fileChangedOnBytes = fileChangedOn != default ? Encoding.UTF8.GetBytes(fileChangedOn.Value.ToString(RoundtripDateTimeFormat)) : Array.Empty<byte>();

            FileMetadata = fileMetadata;
            IsFileMetadataSet = isFileMetadataSet;
            _fileMetadataBytes = fileMetadata != default ? Encoding.UTF8.GetBytes(fileMetadata.DictionaryToString()) : Array.Empty<byte>();

            DirectoryMetadata = directoryMetadata;
            IsDirectoryMetadataSet = isDirectoryMetadataSet;
            _directoryMetadataBytes = directoryMetadata != default ? Encoding.UTF8.GetBytes(directoryMetadata.DictionaryToString()) : Array.Empty<byte>();

            ShareProtocol = shareProtocol;
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            BinaryWriter writer = new(stream);

            // Version
            writer.Write(Version);

            // SMB properties
            writer.WritePreservablePropertyOffset(IsFileAttributesSet, DataMovementConstants.IntSizeInBytes, ref currentVariableLengthIndex);
            writer.Write(FilePermission);
            writer.WritePreservablePropertyOffset(IsFileCreatedOnSet, _fileCreatedOnBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsFileLastWrittenOnSet, _fileLastWrittenOnBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsFileChangedOnSet, _fileChangedOnBytes.Length, ref currentVariableLengthIndex);

            // HttpHeaders
            writer.WritePreservablePropertyOffset(IsContentTypeSet, ContentTypeBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsContentEncodingSet, ContentEncodingBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsContentLanguageSet, ContentLanguageBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsContentDispositionSet, ContentDispositionBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsCacheControlSet, CacheControlBytes.Length, ref currentVariableLengthIndex);

            // Metadata
            writer.WritePreservablePropertyOffset(IsFileMetadataSet, _fileMetadataBytes.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(IsDirectoryMetadataSet, _directoryMetadataBytes.Length, ref currentVariableLengthIndex);

            // ShareProtocol
            writer.Write((byte)ShareProtocol);

            // Variable length info
            if (IsFileAttributesSet)
            {
                if (FileAttributes == default)
                {
                    writer.Write((int)0);
                }
                else
                {
                    writer.Write((int)FileAttributes);
                }
            }
            if (IsFileCreatedOnSet)
            {
                writer.Write(_fileCreatedOnBytes);
            }
            if (IsFileLastWrittenOnSet)
            {
                writer.Write(_fileLastWrittenOnBytes);
            }
            if (IsFileChangedOnSet)
            {
                writer.Write(_fileChangedOnBytes);
            }
            if (IsContentTypeSet)
            {
                writer.Write(ContentTypeBytes);
            }
            if (IsContentEncodingSet)
            {
                writer.Write(ContentEncodingBytes);
            }
            if (IsContentLanguageSet)
            {
                writer.Write(ContentLanguageBytes);
            }
            if (IsContentDispositionSet)
            {
                writer.Write(ContentDispositionBytes);
            }
            if (IsCacheControlSet)
            {
                writer.Write(CacheControlBytes);
            }
            if (IsFileMetadataSet)
            {
                writer.Write(_fileMetadataBytes);
            }
            if (IsDirectoryMetadataSet)
            {
                writer.Write(_directoryMetadataBytes);
            }
        }

        internal static ShareFileDestinationCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            if (version < DataMovementShareConstants.DestinationCheckpointDetails.MinValidSchemaVersion
                || version > DataMovementShareConstants.DestinationCheckpointDetails.MaxValidSchemaVersion)
            {
                throw Storage.Errors.UnsupportedJobSchemaVersionHeader(version);
            }

            // SMB properties
            (bool isFileAttributesSet, int fileAttributesOffset, int fileAttributesLength) = reader.ReadVariableLengthFieldInfo();
            bool isFilePermissionSet = reader.ReadBoolean();
            (bool isFileCreatedOnSet, int fileCreatedOnOffset, int fileCreatedOnLength) = reader.ReadVariableLengthFieldInfo();
            (bool isFileLastWrittenOnSet, int fileLastWrittenOnOffset, int fileLastWrittenOnLength) = reader.ReadVariableLengthFieldInfo();
            (bool isFileChangedOnSet, int fileChangedOnOffset, int fileChangedOnLength) = reader.ReadVariableLengthFieldInfo();

            // HttpHeaders
            (bool isContentTypeSet, int contentTypeOffset, int contentTypeLength) = reader.ReadVariableLengthFieldInfo();
            (bool isContentEncodingSet, int contentEncodingOffset, int contentEncodingLength) = reader.ReadVariableLengthFieldInfo();
            (bool isContentLanguageSet, int contentLanguageOffset, int contentLanguageLength) = reader.ReadVariableLengthFieldInfo();
            (bool isContentDispositionSet, int contentDispositionOffset, int contentDispositionLength) = reader.ReadVariableLengthFieldInfo();
            (bool isCacheControlSet, int cacheControlOffset, int cacheControlLength) = reader.ReadVariableLengthFieldInfo();

            // Metadata
            (bool isFileMetadataSet, int fileMetadataOffset, int fileMetadataLength) = reader.ReadVariableLengthFieldInfo();
            (bool isDirectoryMetadataSet, int directoryMetadataOffset, int directoryMetadataLength) = reader.ReadVariableLengthFieldInfo();

            // ShareProtocol
            ShareProtocol shareProtocol = ShareProtocol.Smb;
            bool shareProtocolSupport = version >= DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion_4;
            if (shareProtocolSupport)
            {
                shareProtocol = (ShareProtocol)(reader.ReadByte());
            }

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

            // When deserializing, the version of the new CheckpointDetails is always the latest version.
            return new(
                isContentTypeSet: isContentTypeSet,
                contentType: contentType,
                isContentEncodingSet: isContentEncodingSet,
                contentEncoding: contentEncoding?.Split(HeaderDelimiter),
                isContentLanguageSet: isContentLanguageSet,
                contentLanguage: contentLanguage?.Split(HeaderDelimiter),
                isContentDispositionSet: isContentDispositionSet,
                contentDisposition: contentDisposition,
                isCacheControlSet: isCacheControlSet,
                cacheControl: cacheControl,
                isFileAttributesSet: isFileAttributesSet,
                fileAttributes: ntfsFileAttributes,
                filePermissions: isFilePermissionSet,
                isFileCreatedOnSet: isFileCreatedOnSet,
                fileCreatedOn: fileCreatedOn,
                isFileLastWrittenOnSet: isFileLastWrittenOnSet,
                fileLastWrittenOn: fileLastWrittenOn,
                isFileChangedOnSet: isFileChangedOnSet,
                fileChangedOn: fileChangedOn,
                isFileMetadataSet: isFileMetadataSet,
                fileMetadata: fileMetadataString?.ToDictionary(nameof(fileMetadataString)),
                isDirectoryMetadataSet: isDirectoryMetadataSet,
                directoryMetadata: directoryMetadataString?.ToDictionary(nameof(directoryMetadataString)),
                shareProtocol: shareProtocol);
        }

        private int CalculateLength()
        {
            // Length is fixed size fields plus length of each variable length field
            int length = DataMovementShareConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            if (IsFileAttributesSet)
            {
                length += DataMovementConstants.IntSizeInBytes;
            }
            if (IsFileCreatedOnSet)
            {
                length += _fileCreatedOnBytes.Length;
            }
            if (IsFileLastWrittenOnSet)
            {
                length += _fileLastWrittenOnBytes.Length;
            }
            if (IsFileChangedOnSet)
            {
                length += _fileChangedOnBytes.Length;
            }
            if (IsContentTypeSet)
            {
                length += ContentTypeBytes.Length;
            }
            if (IsContentEncodingSet)
            {
                length += ContentEncodingBytes.Length;
            }
            if (IsContentLanguageSet)
            {
                length += ContentLanguageBytes.Length;
            }
            if (IsContentDispositionSet)
            {
                length += ContentDispositionBytes.Length;
            }
            if (IsCacheControlSet)
            {
                length += CacheControlBytes.Length;
            }
            if (IsFileMetadataSet)
            {
                length += _fileMetadataBytes.Length;
            }
            if (IsDirectoryMetadataSet)
            {
                length += _directoryMetadataBytes.Length;
            }
            return length;
        }
    }
}
