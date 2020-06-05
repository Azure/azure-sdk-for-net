// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Cryptography.Models
{
    /// <summary>
    /// Represents the encryption data that is stored on the service.
    /// </summary>
    internal class EncryptionData
    {
        /// <summary>
        /// The blob encryption mode.
        /// </summary>
        public string EncryptionMode { get; set; }

        /// <summary>
        /// A <see cref="KeyEnvelope"/> object that stores the wrapping algorithm, key identifier and the encrypted key.
        /// </summary>
        public KeyEnvelope WrappedContentKey { get; set; }

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

        internal static async Task<EncryptionData> CreateInternalV1_0(
            byte[] contentEncryptionIv,
            string keyWrapAlgorithm,
            byte[] contentEncryptionKey,
            IKeyEncryptionKey keyEncryptionKey,
            bool async,
            CancellationToken cancellationToken)
            => new EncryptionData()
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                ContentEncryptionIV = contentEncryptionIv,
                EncryptionAgent = new EncryptionAgent()
                {
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesCbc256,
                    EncryptionVersion = ClientSideEncryptionVersion.V1_0
                },
                KeyWrappingMetadata = new Dictionary<string, string>()
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, AgentString }
                },
                WrappedContentKey = new KeyEnvelope()
                {
                    Algorithm = keyWrapAlgorithm,
                    EncryptedKey = async
                        ? await keyEncryptionKey.WrapKeyAsync(keyWrapAlgorithm, contentEncryptionKey, cancellationToken).ConfigureAwait(false)
                        : keyEncryptionKey.WrapKey(keyWrapAlgorithm, contentEncryptionKey, cancellationToken),
                    KeyId = keyEncryptionKey.KeyId
                }
            };

        /// <summary>
        /// Singleton string identifying this encryption library.
        /// </summary>
        private static string AgentString { get; } = GenerateAgentString();

        private static string GenerateAgentString()
        {
            Assembly assembly = typeof(EncryptionData).Assembly;
            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            return $"azsdk-net-{assembly.GetName().Name}/{assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion} {platformInformation}";
        }
    }
}
