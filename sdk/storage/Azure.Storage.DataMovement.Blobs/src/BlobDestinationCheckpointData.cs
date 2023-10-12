// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using static Azure.Storage.DataMovement.JobPlanExtensions;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDestinationCheckpointData : StorageResourceCheckpointData
    {
        /// <summary>
        /// Schema version.
        /// </summary>
        public int Version;

        /// <summary>
        /// The type of the destination blob.
        /// </summary>
        public BlobType BlobType;

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

        /// <summary>
        /// The encryption scope to use when uploading the destination blob.
        /// </summary>
        public string CpkScope;
        private byte[] _cpkScopeBytes;

        public override int Length => CalculateLength();

        public BlobDestinationCheckpointData(
            BlobType blobType,
            BlobHttpHeaders contentHeaders,
            AccessTier? accessTier,
            Metadata metadata,
            Tags blobTags,
            string cpkScope)
        {
            Version = DataMovementBlobConstants.DestinationJobPartHeader.SchemaVersion;
            BlobType = blobType;
            ContentHeaders = contentHeaders;
            _contentTypeBytes = ContentHeaders?.ContentType != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentType) : new byte[0];
            _contentEncodingBytes = ContentHeaders?.ContentEncoding != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentEncoding) : new byte[0];
            _contentLanguageBytes = ContentHeaders?.ContentLanguage != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentLanguage) : new byte[0];
            _contentDispositionBytes = ContentHeaders?.ContentDisposition != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentDisposition) : new byte[0];
            _cacheControlBytes = ContentHeaders?.CacheControl != default ? Encoding.UTF8.GetBytes(ContentHeaders.CacheControl) : new byte[0];
            AccessTier = accessTier;
            Metadata = metadata;
            _metadataBytes = Metadata != default ? Encoding.UTF8.GetBytes(Metadata.DictionaryToString()) : new byte[0];
            Tags = blobTags;
            _tagsBytes = Tags != default ? Encoding.UTF8.GetBytes(Tags.DictionaryToString()) : new byte[0];
            CpkScope = cpkScope;
            _cpkScopeBytes = CpkScope != default ? Encoding.UTF8.GetBytes(CpkScope) : new byte[0];
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementBlobConstants.DestinationJobPartHeader.VariableLengthStartIndex;
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.Write(Version);

            // BlobType
            writer.Write((byte)BlobType);

            // ContentType offset/length
            WriteVariableLengthFieldInfo(writer, _contentTypeBytes, ref currentVariableLengthIndex);

            // ContentEncoding offset/length
            WriteVariableLengthFieldInfo(writer, _contentEncodingBytes, ref currentVariableLengthIndex);

            // ContentLanguage offset/length
            WriteVariableLengthFieldInfo(writer, _contentLanguageBytes, ref currentVariableLengthIndex);

            // ContentDisposition offset/length
            WriteVariableLengthFieldInfo(writer, _contentDispositionBytes, ref currentVariableLengthIndex);

            // CacheControl offset/length
            WriteVariableLengthFieldInfo(writer, _cacheControlBytes, ref currentVariableLengthIndex);

            // AccessTier
            writer.Write((byte)AccessTier.ToJobPlanAccessTier());

            // Metadata offset/length
            WriteVariableLengthFieldInfo(writer, _metadataBytes, ref currentVariableLengthIndex);

            // Tags offset/length
            WriteVariableLengthFieldInfo(writer, _tagsBytes, ref currentVariableLengthIndex);

            // CpkScope offset/length
            WriteVariableLengthFieldInfo(writer, _cpkScopeBytes, ref currentVariableLengthIndex);

            writer.Write(_contentTypeBytes);
            writer.Write(_contentEncodingBytes);
            writer.Write(_contentLanguageBytes);
            writer.Write(_contentDispositionBytes);
            writer.Write(_cacheControlBytes);
            writer.Write(_metadataBytes);
            writer.Write(_tagsBytes);
            writer.Write(_cpkScopeBytes);
        }

        internal static BlobDestinationCheckpointData Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            CheckSchemaVersion(version);

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
            AccessTier accessTier = new AccessTier(jobPlanAccessTier.ToString());

            // Metadata offset/length
            int metadataOffset = reader.ReadInt32();
            int metadataLength = reader.ReadInt32();

            // Tags offset/length
            int tagsOffset = reader.ReadInt32();
            int tagsLength = reader.ReadInt32();

            // CpkScope offset/length
            int cpkScopeOffset = reader.ReadInt32();
            int cpkScopeLength = reader.ReadInt32();

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

            // CpkScope
            string cpkScope = null;
            if (cpkScopeOffset > 0)
            {
                reader.BaseStream.Position = cpkScopeOffset;
                cpkScope = reader.ReadBytes(cpkScopeLength).AsString();
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
                tagsString.ToDictionary(nameof(tagsString)),
                cpkScope);
        }

        private int CalculateLength()
        {
            // Length is fixed size fields plus length of each variable length field
            int length = DataMovementBlobConstants.DestinationJobPartHeader.VariableLengthStartIndex;
            length += _contentTypeBytes.Length;
            length += _contentEncodingBytes.Length;
            length += _contentLanguageBytes.Length;
            length += _contentDispositionBytes.Length;
            length += _cacheControlBytes.Length;
            length += _metadataBytes.Length;
            length += _tagsBytes.Length;
            length += _cpkScopeBytes.Length;
            return length;
        }

        private static void CheckSchemaVersion(int version)
        {
            if (version != DataMovementBlobConstants.DestinationJobPartHeader.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version.ToString());
            }
        }
    }
}
