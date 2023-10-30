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
    internal class ShareFileDestinationCheckpointData : StorageResourceCheckpointData
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
        /// The metadata for the destination blob.
        /// </summary>
        public Metadata Metadata;
        private byte[] _metadataBytes;

        public override int Length => CalculateLength();

        public ShareFileDestinationCheckpointData(
            ShareFileHttpHeaders contentHeaders,
            Metadata metadata)
        {
            Version = DataMovementShareConstants.DestinationCheckpointData.SchemaVersion;
            ContentHeaders = contentHeaders;
            _contentTypeBytes = ContentHeaders?.ContentType != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentType) : Array.Empty<byte>();
            _contentEncodingBytes = ContentHeaders?.ContentEncoding != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), ContentHeaders.ContentEncoding)) : Array.Empty<byte>();
            _contentLanguageBytes = ContentHeaders?.ContentLanguage != default ? Encoding.UTF8.GetBytes(string.Join(HeaderDelimiter.ToString(), ContentHeaders.ContentLanguage)) : Array.Empty<byte>();
            _contentDispositionBytes = ContentHeaders?.ContentDisposition != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentDisposition) : Array.Empty<byte>();
            _cacheControlBytes = ContentHeaders?.CacheControl != default ? Encoding.UTF8.GetBytes(ContentHeaders.CacheControl) : Array.Empty<byte>();
            Metadata = metadata;
            _metadataBytes = Metadata != default ? Encoding.UTF8.GetBytes(Metadata.DictionaryToString()) : Array.Empty<byte>();
        }

        internal void SerializeInternal(Stream stream) => Serialize(stream);

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            BinaryWriter writer = new(stream);

            // Version
            writer.Write(Version);

            // Fixed position offset/lengths for variable length info
            writer.WriteVariableLengthFieldInfo(_contentTypeBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_contentEncodingBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_contentLanguageBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_contentDispositionBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_cacheControlBytes.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(_metadataBytes.Length, ref currentVariableLengthIndex);

            // Variable length info
            writer.Write(_contentTypeBytes);
            writer.Write(_contentEncodingBytes);
            writer.Write(_contentLanguageBytes);
            writer.Write(_contentDispositionBytes);
            writer.Write(_cacheControlBytes);
            writer.Write(_metadataBytes);
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

            // ContentType offset/length
            int contentTypeOffset = reader.ReadInt32();
            int contentTypeLength = reader.ReadInt32();

            // ContentEncoding offset/length
            int contentEncodingOffset = reader.ReadInt32();
            int contentEncodingLength = reader.ReadInt32();

            // ContentLanguage offset/length
            int contentLanguageOffset = reader.ReadInt32();
            int contentLanguageLength = reader.ReadInt32();

            // ContentDisposition offset/length
            int contentDispositionOffset = reader.ReadInt32();
            int contentDispositionLength = reader.ReadInt32();

            // CacheControl offset/length
            int cacheControlOffset = reader.ReadInt32();
            int cacheControlLength = reader.ReadInt32();

            // Metadata offset/length
            int metadataOffset = reader.ReadInt32();
            int metadataLength = reader.ReadInt32();

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
            string metadataString = string.Empty;
            if (metadataOffset > 0)
            {
                reader.BaseStream.Position = metadataOffset;
                metadataString = Encoding.UTF8.GetString(reader.ReadBytes(metadataLength));
            }

            ShareFileHttpHeaders contentHeaders = new()
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding.Split(HeaderDelimiter),
                ContentLanguage = contentLanguage.Split(HeaderDelimiter),
                ContentDisposition = contentDisposition,
                CacheControl = cacheControl,
            };

            return new(
                contentHeaders,
                metadataString.ToDictionary(nameof(metadataString)));
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
            length += _metadataBytes.Length;
            return length;
        }
    }
}
