// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileDestinationCheckpointData : StorageResourceCheckpointData
    {
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

        public override int Length => 0;

        public ShareFileDestinationCheckpointData(
            ShareFileHttpHeaders contentHeaders,
            Metadata metadata)
        {
            //Version = throw new NotImplementedException();
            ContentHeaders = contentHeaders;
            _contentTypeBytes = ContentHeaders?.ContentType != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentType) : Array.Empty<byte>();
            _contentEncodingBytes = ContentHeaders?.ContentEncoding != default ? Encoding.UTF8.GetBytes(string.Join(Constants.CommaString, ContentHeaders.ContentEncoding)) : Array.Empty<byte>();
            _contentLanguageBytes = ContentHeaders?.ContentLanguage != default ? Encoding.UTF8.GetBytes(string.Join(Constants.CommaString, ContentHeaders.ContentLanguage)) : Array.Empty<byte>();
            _contentDispositionBytes = ContentHeaders?.ContentDisposition != default ? Encoding.UTF8.GetBytes(ContentHeaders.ContentDisposition) : Array.Empty<byte>();
            _cacheControlBytes = ContentHeaders?.CacheControl != default ? Encoding.UTF8.GetBytes(ContentHeaders.CacheControl) : Array.Empty<byte>();
            Metadata = metadata;
            _metadataBytes = Metadata != default ? Encoding.UTF8.GetBytes(Metadata.DictionaryToString()) : Array.Empty<byte>();
        }

        protected override void Serialize(Stream stream)
        {
        }
    }
}
