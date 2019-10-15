// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Models
{
    /// <summary>
    /// Represents the encryption data that is stored on the service.
    /// </summary>
    public class EncryptionData
    {
        /// <summary>
        /// The blob encryption mode.
        /// </summary>
        public string EncryptionMode { get; set; }

        /// <summary>
        /// A <see cref="WrappedKey"/> object that stores the wrapping algorithm, key identifier and the encrypted key.
        /// </summary>
        public WrappedKey WrappedContentKey { get; set; }

        /// <summary>
        /// The encryption agent.
        /// </summary>
        public EncryptionAgent EncryptionAgent { get; set; }

        /// <summary>
        /// The content encryption IV.
        /// </summary>
        public byte[] ContentEncryptionIV { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary>
        /// Metadata for encryption. Currently used only for storing the encryption library, but may contain other data.
        /// </summary>
        public Metadata KeyWrappingMetadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Serializes this object to JSON.
        /// </summary>
        /// <returns></returns>
        public string Serialize()
            => JsonSerializer.Serialize(this);

        /// <summary>
        /// Deserializes an <see cref="EncryptionData"/> from JSON.
        /// </summary>
        /// <param name="json">JSON to deserialize.</param>
        /// <returns></returns>
        public static EncryptionData Deserialize(string json)
            => JsonSerializer.Deserialize<EncryptionData>(json);
    }
}
