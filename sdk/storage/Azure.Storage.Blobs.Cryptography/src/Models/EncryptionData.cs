using System;
using System.Collections.Generic;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// Represents the encryption data that is stored on the service.
    /// </summary>
    internal struct EncryptionData
    {

        /// <summary>
        /// The blob encryption mode.
        /// </summary>
        public string EncryptionMode { get; set; }

        /// <summary>
        /// A {@link WrappedKey} object that stores the wrapping algorithm, key identifier and the encrypted key.
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

        /// <summary>
        /// Metadata for encryption. Currently used only for storing the encryption library, but may contain other data.
        /// </summary>
        public Metadata KeyWrappingMetadata { get; set; }
    }
}
