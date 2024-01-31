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
            DataTransferProperty<string> cacheControl,
            DataTransferProperty<string> contentDisposition,
            DataTransferProperty<string> contentEncoding,
            DataTransferProperty<string> contentLanguage,
            DataTransferProperty<string> contentType,
            DataTransferProperty<AccessTier?> accessTier,
            DataTransferProperty<Metadata> metadata,
            DataTransferProperty<Tags> blobTags)
            : base(DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion, blobType)
        {
            AccessTier = accessTier;
            PreserveAccessTier = accessTier.Preserve;

            PreserveCacheControl = cacheControl?.Preserve ?? true;
            CacheControlBytes = cacheControl?.Value != default ? Encoding.UTF8.GetBytes(cacheControl.Value) : Array.Empty<byte>();

            PreserveContentDisposition = contentDisposition?.Preserve ?? true;
            ContentDispositionBytes = contentDisposition?.Value != default ? Encoding.UTF8.GetBytes(contentDisposition.Value) : Array.Empty<byte>();

            PreserveContentEncoding = contentEncoding?.Preserve ?? true;
            ContentEncodingBytes = contentEncoding?.Value != default ? Encoding.UTF8.GetBytes(contentEncoding.Value) : Array.Empty<byte>();

            PreserveContentLanguage = contentLanguage?.Preserve ?? true;
            ContentLanguageBytes = contentLanguage?.Value != default ? Encoding.UTF8.GetBytes(contentLanguage.Value) : Array.Empty<byte>();

            PreserveContentType = contentType?.Preserve ?? true;
            ContentTypeBytes = contentType?.Value != default ? Encoding.UTF8.GetBytes(contentType.Value) : Array.Empty<byte>();

            Metadata = metadata;
            PreserveMetadata = metadata?.Preserve ?? true;
            MetadataBytes = metadata?.Value != default ? Encoding.UTF8.GetBytes(metadata.Value.DictionaryToString()) : Array.Empty<byte>();

            Tags = blobTags;
            PreserveTags = blobTags?.Preserve ?? false; // We default to false, as Tags requires more permissions to get tags of a blob.
            TagsBytes = blobTags?.Value != default ? Encoding.UTF8.GetBytes(blobTags?.Value.DictionaryToString()) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementBlobConstants.DestinationCheckpointData.OptionalIndexValuesStartIndex;
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.Write(Version);

            // BlobType
            writer.Write((byte)BlobType);

            // Preserve Content Type
            writer.Write(PreserveContentType);

            // ContentType offset/length
            if (!PreserveContentType)
            {
                writer.WriteVariableLengthFieldInfo(ContentTypeBytes.Length, ref currentVariableLengthIndex);
            }

            // Preserve Content Encoding
            writer.Write(PreserveContentEncoding);

            // ContentEncoding offset/length
            if (!PreserveContentEncoding)
            {
                writer.WriteVariableLengthFieldInfo(ContentEncodingBytes.Length, ref currentVariableLengthIndex);
            }

            // Preserve Content Language
            writer.Write(PreserveContentLanguage);

            // ContentLanguage offset/length
            if (!PreserveContentLanguage)
            {
                writer.WriteVariableLengthFieldInfo(ContentLanguageBytes.Length, ref currentVariableLengthIndex);
            }

            // Preserve Content Disposition
            writer.Write(PreserveContentDisposition);

            // ContentDisposition offset/length
            if (!PreserveContentDisposition)
            {
                writer.WriteVariableLengthFieldInfo(ContentDispositionBytes.Length, ref currentVariableLengthIndex);
            }

            // Preserve Cache Control
            writer.Write(PreserveCacheControl);

            // CacheControl offset/length
            if (!PreserveCacheControl)
            {
                writer.WriteVariableLengthFieldInfo(CacheControlBytes.Length, ref currentVariableLengthIndex);
            }

            // Preserve Access Tier
            writer.Write(PreserveAccessTier);

            // AccessTier
            if (!PreserveAccessTier)
            {
                writer.Write((byte) AccessTier.Value.ToJobPlanAccessTier());
            }

            // Preserve Metadata
            writer.Write(PreserveMetadata);

            // Metadata offset/length
            writer.WriteVariableLengthFieldInfo(MetadataBytes.Length, ref currentVariableLengthIndex);

            // Preserve Tags
            writer.Write(PreserveTags);

            // Tags offset/length
            writer.WriteVariableLengthFieldInfo(TagsBytes.Length, ref currentVariableLengthIndex);

            writer.Write(ContentTypeBytes);
            writer.Write(ContentEncodingBytes);
            writer.Write(ContentLanguageBytes);
            writer.Write(ContentDispositionBytes);
            writer.Write(CacheControlBytes);
            writer.Write(MetadataBytes);
            writer.Write(TagsBytes);
        }

        internal static BlobDestinationCheckpointData Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int contentTypeOffset = 0;
            int contentTypeLength = 0;
            int contentEncodingOffset = 0;
            int contentEncodingLength = 0;
            int contentLanguageOffset = 0;
            int contentLanguageLength = 0;
            int contentDispositionOffset = 0;
            int contentDispositionLength = 0;
            int cacheControlOffset = 0;
            int cacheControlLength = 0;
            int metadataOffset = 0;
            int metadataLength = 0;
            int tagsOffset = 0;
            int tagsLength = 0;

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

            // Preserve Content Type
            bool preserveContentType = reader.ReadBoolean();

            // Preserve Content Encoding
            bool preserveContentEncoding = reader.ReadBoolean();

            // Preserve Content Language
            bool preserveContentLanguage= reader.ReadBoolean();

            // ContentDisposition
            bool preserveContentDisposition= reader.ReadBoolean();

            // CacheControl
            bool preserveCacheControl = reader.ReadBoolean();

            // AccessTier
            bool preserveAccessTier = reader.ReadBoolean();

            // Metadata
            bool preserveMetadata = reader.ReadBoolean();

            // Tags
            bool preserveTags = reader.ReadBoolean();

            // Preserved Offset and Lengths
            // ContentType offset/length
            if (preserveContentType)
            {
                contentTypeOffset = reader.ReadInt32();
                contentTypeLength = reader.ReadInt32();
            }

            // Content Encoding offset/length
            if (preserveContentEncoding)
            {
                contentEncodingOffset = reader.ReadInt32();
                contentEncodingLength = reader.ReadInt32();
            }

            // Content Language offset/length
            if (preserveContentLanguage)
            {
                contentLanguageOffset = reader.ReadInt32();
                contentLanguageLength = reader.ReadInt32();
            }

            // Content Disposition offset/length
            if (preserveContentDisposition)
            {
                contentDispositionOffset = reader.ReadInt32();
                contentDispositionLength = reader.ReadInt32();
            }

            // Cache Control offset/length
            if (preserveCacheControl)
            {
                cacheControlOffset = reader.ReadInt32();
                cacheControlLength = reader.ReadInt32();
            }

            // Metadata offset/length
            if (preserveMetadata)
            {
                metadataOffset = reader.ReadInt32();
                metadataLength = reader.ReadInt32();
            }

            // Tags offset/length
            if (preserveTags)
            {
                tagsOffset = reader.ReadInt32();
                tagsLength = reader.ReadInt32();
            }

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

            // Access Tier
            JobPlanAccessTier jobPlanAccessTier = default;
            AccessTier? accessTier = default;
            if (preserveAccessTier)
            {
                jobPlanAccessTier = (JobPlanAccessTier)reader.ReadByte();
                if (!jobPlanAccessTier.Equals(JobPlanAccessTier.None))
                {
                    accessTier = new AccessTier(jobPlanAccessTier.ToString());
                }
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
                blobType,
                preserveCacheControl ? new(cacheControl) : new(preserveCacheControl),
                preserveContentDisposition ? new(contentDisposition) : new(preserveContentDisposition),
                preserveContentEncoding ? new(contentEncoding) : new(preserveContentEncoding),
                preserveContentLanguage ? new(contentLanguage) : new(preserveContentLanguage),
                preserveContentType ? new(contentType) : new(preserveContentType),
                preserveAccessTier ? new(accessTier) : new(preserveAccessTier),
                preserveMetadata ? new(metadataString.ToDictionary(nameof(metadataString))) : new(preserveMetadata),
                preserveTags ? new(tagsString.ToDictionary(nameof(tagsString))) : new(preserveTags));
        }

        private int CalculateLength()
        {
            // Length is calculated based on whether the property is preserved.
            // If the property is preserved, the property's length is added to the total length.
            int length = DataMovementBlobConstants.DestinationCheckpointData.OptionalIndexValuesStartIndex;
            if (PreserveContentType)
            {
                length += ContentTypeBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveContentEncoding)
            {
                length += ContentEncodingBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveContentLanguage)
            {
                length += ContentLanguageBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveContentDisposition)
            {
                length += ContentDispositionBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveCacheControl)
            {
                length += CacheControlBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveAccessTier)
            {
                length += DataMovementConstants.OneByte
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveMetadata)
            {
                length += MetadataBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            if (PreserveTags)
            {
                length += TagsBytes.Length
                    + DataMovementConstants.OneByte
                    + DataMovementConstants.IntSizeInBytes;
            }
            return length;
        }
    }
}
