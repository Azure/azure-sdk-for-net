// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDestinationCheckpointData : BlobCheckpointData
    {
        /// <summary>
        /// The content headers for the destination blob.
        /// </summary>
        public DataTransferProperty<string> CacheControl;
        public bool PreserveCacheControl;
        public byte[] CacheControlBytes;

        public DataTransferProperty<string> ContentDisposition;
        public bool PreserveContentDisposition;
        public byte[] ContentDispositionBytes;

        public DataTransferProperty<string> ContentEncoding;
        public bool PreserveContentEncoding;
        public byte[] ContentEncodingBytes;

        public DataTransferProperty<string> ContentLanguage;
        public bool PreserveContentLanguage;
        public byte[] ContentLanguageBytes;

        public DataTransferProperty<string> ContentType;
        public bool PreserveContentType;
        public byte[] ContentTypeBytes;

        /// <summary>
        /// The access tier of the destination blob.
        /// </summary>
        public DataTransferProperty<AccessTier?> AccessTier;
        public bool PreserveAccessTier;

        /// <summary>
        /// The metadata for the destination blob.
        /// </summary>
        public DataTransferProperty<Metadata> Metadata;
        public bool PreserveMetadata;
        public byte[] MetadataBytes;

        /// <summary>
        /// The Blob tags for the destination blob.
        /// </summary>
        public DataTransferProperty<Tags> Tags;
        public bool PreserveTags;
        public byte[] TagsBytes;

        public override int Length => CalculateLength();

        public BlobDestinationCheckpointData(
            BlobType blobType,
            DataTransferProperty<string> contentType,
            DataTransferProperty<string> contentEncoding,
            DataTransferProperty<string> contentLanguage,
            DataTransferProperty<string> contentDisposition,
            DataTransferProperty<string> cacheControl,
            DataTransferProperty<AccessTier?> accessTier,
            DataTransferProperty<Metadata> metadata,
            DataTransferProperty<Tags> tags)
            : base(DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion, blobType)
        {
            PreserveAccessTier = accessTier?.Preserve ?? true;
            AccessTier = accessTier;

            CacheControl = cacheControl;
            PreserveCacheControl = cacheControl?.Preserve ?? true;
            CacheControlBytes = cacheControl?.Value != default ? Encoding.UTF8.GetBytes(cacheControl.Value) : Array.Empty<byte>();

            ContentDisposition = contentDisposition;
            PreserveContentDisposition = contentDisposition?.Preserve ?? true;
            ContentDispositionBytes = contentDisposition?.Value != default ? Encoding.UTF8.GetBytes(contentDisposition.Value) : Array.Empty<byte>();

            ContentEncoding = contentEncoding;
            PreserveContentEncoding = contentEncoding?.Preserve ?? true;
            ContentEncodingBytes = contentEncoding?.Value != default ? Encoding.UTF8.GetBytes(contentEncoding.Value) : Array.Empty<byte>();

            ContentLanguage = contentLanguage;
            PreserveContentLanguage = contentLanguage?.Preserve ?? true;
            ContentLanguageBytes = contentLanguage?.Value != default ? Encoding.UTF8.GetBytes(contentLanguage.Value) : Array.Empty<byte>();

            ContentType = contentType;
            PreserveContentType = contentType?.Preserve ?? true;
            ContentTypeBytes = contentType?.Value != default ? Encoding.UTF8.GetBytes(contentType.Value) : Array.Empty<byte>();

            Metadata = metadata;
            PreserveMetadata = metadata?.Preserve ?? true;
            MetadataBytes = metadata?.Value != default ? Encoding.UTF8.GetBytes(metadata.Value.DictionaryToString()) : Array.Empty<byte>();

            Tags = tags;
            PreserveTags = tags?.Preserve ?? false;
            TagsBytes = tags?.Value != default ? Encoding.UTF8.GetBytes(tags.Value.DictionaryToString()) : Array.Empty<byte>();
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

            // Preserve Content Type
            writer.Write(PreserveContentType);
            if (!PreserveContentType)
            {
                // Content Type offset/length
                writer.WriteVariableLengthFieldInfo(ContentTypeBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Preserve Content Encoding
            writer.Write(PreserveContentEncoding);
            if (!PreserveContentEncoding)
            {
                // ContentEncoding offset/length
                writer.WriteVariableLengthFieldInfo(ContentEncodingBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Preserve Content Language
            writer.Write(PreserveContentLanguage);
            if (!PreserveContentLanguage)
            {
                // ContentLanguage offset/length
                writer.WriteVariableLengthFieldInfo(ContentLanguageBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Preserve Content Disposition
            writer.Write(PreserveContentDisposition);
            if (!PreserveContentDisposition)
            {
                // ContentDisposition offset/length
                writer.WriteVariableLengthFieldInfo(ContentDispositionBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Preserve Cache Control
            writer.Write(PreserveCacheControl);
            if (!PreserveCacheControl)
            {
                // CacheControl offset/length
                writer.WriteVariableLengthFieldInfo(CacheControlBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Preserve Access Tier
            writer.Write(PreserveAccessTier);
            if (!PreserveAccessTier)
            {
                // AccessTier
                writer.Write((byte)AccessTier.Value.ToJobPlanAccessTier());
            }
            else
            {
                // Write null byte value
                writer.Write((byte)0);
            }

            // Preserve Metadata
            writer.Write(PreserveMetadata);
            if (!PreserveMetadata)
            {
                // Metadata offset/length
                writer.WriteVariableLengthFieldInfo(MetadataBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // Preserve Blob Tags
            writer.Write(PreserveTags);
            if (!PreserveTags)
            {
                // Tags offset/length
                writer.WriteVariableLengthFieldInfo(TagsBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
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
            if (!PreserveMetadata)
            {
                writer.Write(MetadataBytes);
            }
            if (!PreserveTags)
            {
                writer.Write(TagsBytes);
            }
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

            // Index Values
            // BlobType
            BlobType blobType = (BlobType)reader.ReadByte();

            // Preserve Content Type and offset/length
            bool preserveContentType = reader.ReadBoolean();
            int contentTypeOffset = reader.ReadInt32();
            int contentTypeLength = reader.ReadInt32();

            // Preserve Content Encoding and offset/length
            bool preserveContentEncoding = reader.ReadBoolean();
            int contentEncodingOffset = reader.ReadInt32();
            int contentEncodingLength = reader.ReadInt32();

            // Preserve Content Language and offset/length
            bool preserveContentLanguage = reader.ReadBoolean();
            int contentLanguageOffset = reader.ReadInt32();
            int contentLanguageLength = reader.ReadInt32();

            // Preserve ContentDisposition and offset/length
            bool preserveContentDisposition = reader.ReadBoolean();
            int contentDispositionOffset = reader.ReadInt32();
            int contentDispositionLength = reader.ReadInt32();

            // Preserve CacheControl and offset/length
            bool preserveCacheControl = reader.ReadBoolean();
            int cacheControlOffset = reader.ReadInt32();
            int cacheControlLength = reader.ReadInt32();

            // Preserve AccessTier and offset/length
            bool preserveAccessTier = reader.ReadBoolean();
            AccessTier? accessTier = default;
            JobPlanAccessTier jobPlanAccessTier = (JobPlanAccessTier)reader.ReadByte();
            if (!jobPlanAccessTier.Equals(JobPlanAccessTier.None))
            {
                accessTier = new AccessTier(jobPlanAccessTier.ToString());
            }

            // Preserve Metadata and offset/length
            bool preserveMetadata = reader.ReadBoolean();
            int metadataOffset = reader.ReadInt32();
            int metadataLength = reader.ReadInt32();

            // Preserve Tags and offset/length
            bool preserveTags = reader.ReadBoolean();
            int tagsOffset = reader.ReadInt32();
            int tagsLength = reader.ReadInt32();

            // Values
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

            return new BlobDestinationCheckpointData(
                blobType: blobType,
                contentType: preserveContentType ? new(preserveContentType) : new(contentType),
                contentEncoding: preserveContentEncoding ? new(preserveContentEncoding): new(contentEncoding),
                contentLanguage: preserveContentLanguage ? new(preserveContentLanguage) : new(contentLanguage),
                contentDisposition: preserveContentDisposition ? new(preserveContentDisposition) : new(contentDisposition),
                cacheControl: preserveCacheControl ? new(preserveCacheControl): new(cacheControl),
                accessTier: preserveAccessTier ? new(preserveAccessTier) : new(accessTier),
                metadata: preserveMetadata ? new(preserveMetadata) : new(metadataString.ToDictionary(nameof(metadataString))),
                tags: preserveTags ? new(preserveTags) : new(tagsString.ToDictionary(nameof(tagsString))));
        }

        private int CalculateLength()
        {
            // Length is calculated based on whether the property is preserved.
            // If the property is preserved, the property's length is added to the total length.
            int length = DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex;
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
            if (!PreserveMetadata)
            {
                length += MetadataBytes.Length;
            }
            if (!PreserveTags)
            {
                length += TagsBytes.Length;
            }
            return length;
        }
    }
}
