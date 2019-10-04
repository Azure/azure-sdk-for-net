// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Text;
using System.Runtime.Serialization;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// Represents the encryption data that is stored on the service.
    /// </summary>
    [DataContract]
    public struct EncryptionData
    {

        /// <summary>
        /// The blob encryption mode.
        /// </summary>
        [DataMember]
        public string EncryptionMode { get; set; }

        /// <summary>
        /// A {@link WrappedKey} object that stores the wrapping algorithm, key identifier and the encrypted key.
        /// </summary>
        [DataMember]
        public WrappedKey WrappedContentKey { get; set; }

        /// <summary>
        /// The encryption agent.
        /// </summary>
        [DataMember]
        public EncryptionAgent EncryptionAgent { get; set; }

        /// <summary>
        /// The content encryption IV.
        /// </summary>
        [IgnoreDataMember]
        public byte[] ContentEncryptionIV { get; set; }

        /// <summary>
        /// Base64-encoded content encryption IV.
        /// </summary>
        [DataMember(Name = "ContentEncryptionIV")]
        public string Base64ContentEncryptionIV
        {
            get => Convert.ToBase64String(ContentEncryptionIV);
            set => ContentEncryptionIV = Convert.FromBase64String(value);
        }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary>
        /// Metadata for encryption. Currently used only for storing the encryption library, but may contain other data.
        /// </summary>
        [DataMember]
        public Metadata KeyWrappingMetadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
