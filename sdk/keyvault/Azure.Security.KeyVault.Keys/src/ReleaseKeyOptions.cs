// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Options for <see cref="KeyClient.ReleaseKey(string, string, string, ReleaseKeyOptions, System.Threading.CancellationToken)"/> and
    /// <see cref="KeyClient.ReleaseKeyAsync(string, string, string, ReleaseKeyOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ReleaseKeyOptions : IJsonSerializable
    {
        private static readonly JsonEncodedText s_targetAttestationTokenPropertyNameBytes = JsonEncodedText.Encode("target");
        private static readonly JsonEncodedText s_noncePropertyNameBytes = JsonEncodedText.Encode("nonce");
        private static readonly JsonEncodedText s_algorithmPropertyNameBytes = JsonEncodedText.Encode("enc");

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseKeyOptions"/> class.
        /// </summary>
        public ReleaseKeyOptions()
        {
        }

        /// <summary>
        /// Gets or sets a client-provided nonce for freshness.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Gets or sets tThe encryption algorithm to use to protected the exported key material.
        /// </summary>
        public KeyExportEncryptionAlgorithm? Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the attestation assertion for the target of the key release.
        /// </summary>
        internal string TargetAttestationToken { get; set; }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(TargetAttestationToken))
            {
                json.WriteString(s_targetAttestationTokenPropertyNameBytes, TargetAttestationToken);
            }

            if (!string.IsNullOrEmpty(Nonce))
            {
                json.WriteString(s_noncePropertyNameBytes, Nonce);
            }

            if (Algorithm.HasValue)
            {
                json.WriteString(s_algorithmPropertyNameBytes, Algorithm.ToString());
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
