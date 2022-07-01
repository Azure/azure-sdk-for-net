// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Options for <see cref="KeyClient.ReleaseKey(ReleaseKeyOptions, System.Threading.CancellationToken)"/> and
    /// <see cref="KeyClient.ReleaseKeyAsync(ReleaseKeyOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ReleaseKeyOptions : IJsonSerializable
    {
        private static readonly JsonEncodedText s_targetAttestationTokenPropertyNameBytes = JsonEncodedText.Encode("target");
        private static readonly JsonEncodedText s_noncePropertyNameBytes = JsonEncodedText.Encode("nonce");
        private static readonly JsonEncodedText s_algorithmPropertyNameBytes = JsonEncodedText.Encode("enc");

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseKeyOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the key to release.</param>
        /// <param name="targetAttestationToken">The attestation assertion for the target of the key release.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="targetAttestationToken"/> contains an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="targetAttestationToken"/> is null.</exception>
        public ReleaseKeyOptions(string name, string targetAttestationToken)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(targetAttestationToken, nameof(targetAttestationToken));

            Name = name;
            TargetAttestationToken = targetAttestationToken;
        }

        /// <summary>
        /// Gets the name of the key to release.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the optional version of the key to release.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets a client-provided nonce for freshness.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Gets or sets tThe encryption algorithm to use to protected the exported key material.
        /// </summary>
        public KeyExportEncryptionAlgorithm? Algorithm { get; set; }

        /// <summary>
        /// Gets the attestation assertion for the target of the key release.
        /// </summary>
        public string TargetAttestationToken { get; }

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
