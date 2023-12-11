// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDestinationCheckpointData : BlobCheckpointData
    {
        /// <summary>
        /// The content headers for the destination blob.
        /// </summary>
        public BlobHttpHeaders ContentHeaders;
        private byte[] _contentTypeBytes;
        private byte[] _contentEncodingBytes;
        private byte[] _contentLanguageBytes;
        private byte[] _contentDispositionBytes;
        private byte[] _cacheControlBytes;

        /// <summary>
        /// The access tier of the destination blob.
        /// </summary>
        public AccessTier? AccessTier;

        /// <summary>
        /// The metadate for the destination blob.
        /// </summary>
        public Metadata Metadata;
        private byte[] _metadataBytes;

        /// <summary>
        /// The Blob tags for the destination blob.
        /// </summary>
        public Tags Tags;
        private byte[] _tagsBytes;

        public override int Length => CalculateLength();

        public BlobDestinationCheckpointData(
            BlobType blobType,
            BlobHttpHeaders contentHeaders,
            AccessTier? accessTier,
            Metadata metadata,
            Tags blobTags)
            : base(DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion, blobType)
        {
            ContentHeaders = contentHeaders;
            _contentTypeBytes = ContentHeaders?.ContentType != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentType) : Array.Empty<byte>();
            _contentEncodingBytes = ContentHeaders?.ContentEncoding != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentEncoding) : Array.Empty<byte>();
            _contentLanguageBytes = ContentHeaders?.ContentLanguage != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentLanguage) : Array.Empty<byte>();
            _contentDispositionBytes = ContentHeaders?.ContentDisposition != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentDisposition) : Array.Empty<byte>();
            _cacheControlBytes = ContentHeaders?.CacheControl != default ? Encoding.UTF8.GetBytes(ContentHeaders.CacheControl) : Array.Empty<byte>();
            AccessTier = accessTier;
            Metadata = metadata;
            _metadataBytes = Metadata != default ? Encoding.UTF8.GetBytes(Metadata.DictionaryToString()) : Array.Empty<byte>();
            Tags = blobTags;
            _tagsBytes = Tags != default ? Encoding.UTF8.GetBytes(Tags.DictionaryToString()) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex;
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.Write(Version);

            // BlobType
            writer.Write((byte)BlobType);

            // ContentType offset/length
            writer.WriteVariableLengthFieldInfo(_contentTypeBytes.Length, ref currentVariableLengthIndex);

            // ContentEncoding offset/length
            writer.WriteVariableLengthFieldInfo(_contentEncodingBytes.Length, ref currentVariableLengthIndex);

            // ContentLanguage offset/length
            writer.WriteVariableLengthFieldInfo(_contentLanguageBytes.Length, ref currentVariableLengthIndex);

            // ContentDisposition offset/length
            writer.WriteVariableLengthFieldInfo(_contentDispositionBytes.Length, ref currentVariableLengthIndex);

            // CacheControl offset/length
            writer.WriteVariableLengthFieldInfo(_cacheControlBytes.Length, ref currentVariableLengthIndex);

            // AccessTier
            writer.Write((byte)AccessTier.ToJobPlanAccessTier());

            // Metadata offset/length
            writer.WriteVariableLengthFieldInfo(_metadataBytes.Length, ref currentVariableLengthIndex);

            // Tags offset/length
            writer.WriteVariableLengthFieldInfo(_tagsBytes.Length, ref currentVariableLengthIndex);

            writer.Write(_contentTypeBytes);
            writer.Write(_contentEncodingBytes);
            writer.Write(_contentLanguageBytes);
            writer.Write(_contentDispositionBytes);
            writer.Write(_cacheControlBytes);
            writer.Write(_metadataBytes);
            writer.Write(_tagsBytes);
        }

        internal static BlobDestinationCheckpointData Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version.ToString());
            }

            // BlobType
            BlobType blobType = (BlobType)reader.ReadByte();

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

            // AccessTier
            JobPlanAccessTier jobPlanAccessTier = (JobPlanAccessTier)reader.ReadByte();
            AccessTier? accessTier = default;
            if (!jobPlanAccessTier.Equals(JobPlanAccessTier.None))
            {
                accessTier = new AccessTier(jobPlanAccessTier.ToString());
            }

            // Metadata offset/length
            int metadataOffset = reader.ReadInt32();
            int metadataLength = reader.ReadInt32();

            // Tags offset/length
            int tagsOffset = reader.ReadInt32();
            int tagsLength = reader.ReadInt32();

            // ContentType
            string contentType = null;
            if (contentTypeOffset > 0)
            {
                reader.BaseStream.Position = contentTypeOffset;
                contentType = reader.ReadBytes(contentTypeLength).AsString();
            }

            // ContentEncoding
            string contentEncoding = null;
            if (contentEncodingOffset > 0)
            {
                reader.BaseStream.Position = contentEncodingOffset;
                contentEncoding = reader.ReadBytes(contentEncodingLength).AsString();
            }

            // ContentLanguage
            string contentLanguage = null;
            if (contentLanguageOffset > 0)
            {
                reader.BaseStream.Position = contentLanguageOffset;
                contentLanguage = reader.ReadBytes(contentLanguageLength).AsString();
            }

            // ContentDisposition
            string contentDisposition = null;
            if (contentDispositionOffset > 0)
            {
                reader.BaseStream.Position = contentDispositionOffset;
                contentDisposition = reader.ReadBytes(contentDispositionLength).AsString();
            }

            // CacheControl
            string cacheControl = null;
            if (cacheControlOffset > 0)
            {
                reader.BaseStream.Position = cacheControlOffset;
                cacheControl = reader.ReadBytes(cacheControlLength).AsString();
            }

            // Metadata
            string metadataString = string.Empty;
            if (metadataOffset > 0)
            {
                reader.BaseStream.Position = metadataOffset;
                metadataString = reader.ReadBytes(metadataLength).AsString();
            }

            // Tags
            string tagsString = string.Empty;
            if (tagsOffset > 0)
            {
                reader.BaseStream.Position = tagsOffset;
                tagsString = reader.ReadBytes(tagsLength).AsString();
            }

            BlobHttpHeaders contentHeaders = new BlobHttpHeaders()
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                ContentLanguage = contentLanguage,
                ContentDisposition = contentDisposition,
                CacheControl = cacheControl,
            };

            return new BlobDestinationCheckpointData(
                blobType,
                contentHeaders,
                accessTier,
                metadataString.ToDictionary(nameof(metadataString)),
                tagsString.ToDictionary(nameof(tagsString)));
        }

        private int CalculateLength()
        {
            // Length is fixed size fields plus length of each variable length field
            int length = DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex;
            length += _contentTypeBytes.Length;
            length += _contentEncodingBytes.Length;
            length += _contentLanguageBytes.Length;
            length += _contentDispositionBytes.Length;
            length += _cacheControlBytes.Length;
            length += _metadataBytes.Length;
            length += _tagsBytes.Length;
            return length;
        }
    }
}
