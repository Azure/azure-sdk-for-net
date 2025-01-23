// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDestinationCheckpointDetails : StorageResourceCheckpointDetails
    {
        public int Version;

        /// <summary>
        /// The type of blob.
        /// </summary>
        public bool IsBlobTypeSet;
        public BlobType? BlobType;

        /// <summary>
        /// The content headers for the destination blob.
        /// </summary>
        public string CacheControl;
        public bool IsCacheControlSet;
        public byte[] CacheControlBytes;

        public string ContentDisposition;
        public bool IsContentDispositionSet;
        public byte[] ContentDispositionBytes;

        public string ContentEncoding;
        public bool IsContentEncodingSet;
        public byte[] ContentEncodingBytes;

        public string ContentLanguage;
        public bool IsContentLanguageSet;
        public byte[] ContentLanguageBytes;

        public string ContentType;
        public bool IsContentTypeSet;
        public byte[] ContentTypeBytes;

        /// <summary>
        /// The access tier of the destination blob.
        /// </summary>
        public AccessTier? AccessTierValue;

        /// <summary>
        /// The metadata for the destination blob.
        /// </summary>
        public Metadata Metadata;
        public bool IsMetadataSet;
        public byte[] MetadataBytes;

        /// <summary>
        /// The Blob tags for the destination blob.
        /// </summary>
        public Tags Tags;
        public bool PreserveTags;
        public byte[] TagsBytes;

        public override int Length => CalculateLength();

        public BlobDestinationCheckpointDetails(BlobStorageResourceContainerOptions options) : this(
            isBlobTypeSet: options?._isBlobTypeSet ?? false,
            blobType: options?.BlobType,
            blobOptions: options?.BlobOptions)
        { }

        public BlobDestinationCheckpointDetails(bool isBlobTypeSet, BlobType? blobType, BlobStorageResourceOptions blobOptions)
            : this(
                isBlobTypeSet: isBlobTypeSet,
                blobType: blobType,
                isContentTypeSet: blobOptions?._isContentTypeSet ?? false,
                contentType: blobOptions?.ContentType,
                isContentEncodingSet: blobOptions?._isContentEncodingSet ?? false,
                contentEncoding: blobOptions?.ContentEncoding,
                isContentLanguageSet: blobOptions?._isContentLanguageSet ?? false,
                contentLanguage: blobOptions?.ContentLanguage,
                isContentDispositionSet: blobOptions?._isContentDispositionSet ?? false,
                contentDisposition: blobOptions?.ContentDisposition,
                isCacheControlSet: blobOptions?._isCacheControlSet ?? false,
                cacheControl: blobOptions?.CacheControl,
                accessTier: blobOptions?.AccessTier,
                isMetadataSet: blobOptions?._isMetadataSet ?? false,
                metadata: blobOptions?.Metadata,
                preserveTags: true,
                tags: default)
        { }

        public BlobDestinationCheckpointDetails(
            bool isBlobTypeSet,
            BlobType? blobType,
            bool isContentTypeSet,
            string contentType,
            bool isContentEncodingSet,
            string contentEncoding,
            bool isContentLanguageSet,
            string contentLanguage,
            bool isContentDispositionSet,
            string contentDisposition,
            bool isCacheControlSet,
            string cacheControl,
            AccessTier? accessTier,
            bool isMetadataSet,
            Metadata metadata,
            bool preserveTags,
            Tags tags)
        {
            Version = DataMovementBlobConstants.DestinationCheckpointDetails.SchemaVersion;
            BlobType = blobType;
            IsBlobTypeSet = isBlobTypeSet;

            AccessTierValue = accessTier;

            CacheControl = cacheControl;
            IsCacheControlSet = isCacheControlSet;
            CacheControlBytes = cacheControl != default ? Encoding.UTF8.GetBytes(cacheControl) : Array.Empty<byte>();

            ContentDisposition = contentDisposition;
            IsContentDispositionSet = isContentDispositionSet;
            ContentDispositionBytes = contentDisposition != default ? Encoding.UTF8.GetBytes(contentDisposition) : Array.Empty<byte>();

            ContentEncoding = contentEncoding;
            IsContentEncodingSet = isContentEncodingSet;
            ContentEncodingBytes = contentEncoding!= default ? Encoding.UTF8.GetBytes(contentEncoding) : Array.Empty<byte>();

            ContentLanguage = contentLanguage;
            IsContentLanguageSet = isContentLanguageSet;
            ContentLanguageBytes = contentLanguage != default ? Encoding.UTF8.GetBytes(contentLanguage) : Array.Empty<byte>();

            ContentType = contentType;
            IsContentTypeSet = isContentTypeSet;
            ContentTypeBytes = contentType != default ? Encoding.UTF8.GetBytes(contentType) : Array.Empty<byte>();

            Metadata = metadata;
            IsMetadataSet = isMetadataSet;
            MetadataBytes = metadata != default ? Encoding.UTF8.GetBytes(metadata.DictionaryToString()) : Array.Empty<byte>();

            Tags = tags;
            PreserveTags = preserveTags;
            TagsBytes = tags != default ? Encoding.UTF8.GetBytes(tags.DictionaryToString()) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.Write(Version);

            // BlobType
            writer.Write(IsBlobTypeSet);
            if (IsBlobTypeSet)
            {
                writer.Write((byte)BlobType);
            }
            else
            {
                writer.Write((byte)0);
            }

            // Preserve Content Type
            writer.Write(IsContentTypeSet);
            if (IsContentTypeSet)
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
            writer.Write(IsContentEncodingSet);
            if (IsContentEncodingSet)
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
            writer.Write(IsContentLanguageSet);
            if (IsContentLanguageSet)
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
            writer.Write(IsContentDispositionSet);
            if (IsContentDispositionSet)
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
            writer.Write(IsCacheControlSet);
            if (IsCacheControlSet)
            {
                // CacheControl offset/length
                writer.WriteVariableLengthFieldInfo(CacheControlBytes.Length, ref currentVariableLengthIndex);
            }
            else
            {
                // Padding
                writer.WriteEmptyLengthOffset();
            }

            // AccessTier
            writer.Write((byte)AccessTierValue.ToJobPlanAccessTier());

            // Preserve Metadata
            writer.Write(IsMetadataSet);
            if (IsMetadataSet)
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
            if (IsMetadataSet)
            {
                writer.Write(MetadataBytes);
            }
            if (!PreserveTags)
            {
                writer.Write(TagsBytes);
            }
        }

        internal static BlobDestinationCheckpointDetails Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementBlobConstants.DestinationCheckpointDetails.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version);
            }

            // Index Values
            // BlobType
            bool isBlobTypeSet = reader.ReadBoolean();
            BlobType blobType = (BlobType)reader.ReadByte();

            // Preserve Content Type and offset/length
            bool isContentTypeSet = reader.ReadBoolean();
            int contentTypeOffset = reader.ReadInt32();
            int contentTypeLength = reader.ReadInt32();

            // Preserve Content Encoding and offset/length
            bool isContentEncodingSet = reader.ReadBoolean();
            int contentEncodingOffset = reader.ReadInt32();
            int contentEncodingLength = reader.ReadInt32();

            // Preserve Content Language and offset/length
            bool isContentLanguageSet = reader.ReadBoolean();
            int contentLanguageOffset = reader.ReadInt32();
            int contentLanguageLength = reader.ReadInt32();

            // Preserve ContentDisposition and offset/length
            bool isContentDispositionSet = reader.ReadBoolean();
            int contentDispositionOffset = reader.ReadInt32();
            int contentDispositionLength = reader.ReadInt32();

            // Preserve CacheControl and offset/length
            bool isCacheControlSet = reader.ReadBoolean();
            int cacheControlOffset = reader.ReadInt32();
            int cacheControlLength = reader.ReadInt32();

            // AccessTier
            AccessTier? accessTier = default;
            JobPlanAccessTier jobPlanAccessTier = (JobPlanAccessTier)reader.ReadByte();
            if (!jobPlanAccessTier.Equals(JobPlanAccessTier.None))
            {
                accessTier = new AccessTier(jobPlanAccessTier.ToString());
            }

            // Preserve Metadata and offset/length
            bool isMetadataSet = reader.ReadBoolean();
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

            return new BlobDestinationCheckpointDetails(
                isBlobTypeSet: isBlobTypeSet,
                blobType: blobType,
                isContentTypeSet: isContentTypeSet,
                contentType: contentType,
                isContentEncodingSet: isContentEncodingSet,
                contentEncoding: contentEncoding,
                isContentLanguageSet: isContentLanguageSet,
                contentLanguage: contentLanguage,
                isContentDispositionSet: isContentDispositionSet,
                contentDisposition: contentDisposition,
                isCacheControlSet: isCacheControlSet,
                cacheControl: cacheControl,
                accessTier: accessTier,
                isMetadataSet: isMetadataSet,
                metadata: metadataString.ToDictionary(nameof(metadataString)),
                preserveTags: preserveTags,
                tags: tagsString.ToDictionary(nameof(tagsString)));
        }

        private int CalculateLength()
        {
            // Length is calculated based on whether the property is preserved.
            // If the property is preserved, the property's length is added to the total length.
            int length = DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            if (!IsContentTypeSet)
            {
                length += ContentTypeBytes.Length;
            }
            if (!IsContentEncodingSet)
            {
                length += ContentEncodingBytes.Length;
            }
            if (!IsContentLanguageSet)
            {
                length += ContentLanguageBytes.Length;
            }
            if (!IsContentDispositionSet)
            {
                length += ContentDispositionBytes.Length;
            }
            if (!IsCacheControlSet)
            {
                length += CacheControlBytes.Length;
            }
            if (!IsMetadataSet)
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
