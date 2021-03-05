﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlockInfo.
    /// </summary>
    public partial class BlockInfo
    {
        /// <summary>
        /// This header is returned so that the client can check for message content integrity.
        /// The value of this header is computed by the Blob service; it is not necessarily the same value specified in the request headers.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header is returned so that the client can check for message content integrity.
        /// The value of this header is computed by the Blob service; it is not necessarily the same value specified in the request headers.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentCrc64 { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the block. This header is only returned when the block was
        /// encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// Returns the name of the encryption scope used to encrypt the blob contents and application metadata.
        /// Note that the absence of this header implies use of the default account encryption scope.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of BlockInfo instances.
        /// You can use BlobsModelFactory.BlockInfo instead.
        /// </summary>
        internal BlockInfo() { }
    }
}
