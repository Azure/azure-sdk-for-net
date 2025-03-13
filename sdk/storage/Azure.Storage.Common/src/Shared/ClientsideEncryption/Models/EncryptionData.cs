// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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
        /// The content encryption IV. Only present for v1.0.
        /// </summary>
        public byte[] ContentEncryptionIV { get; set; }

        /// <summary>
        /// Information about structure of authenticated encryption blocks. Only present for v2.0.
        /// </summary>
        public EncryptedRegionInfo EncryptedRegionInfo { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary>
        /// Metadata for encryption. Currently used only for storing the encryption library, but may contain other data.
        /// </summary>
        public Metadata KeyWrappingMetadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        internal static async ValueTask<EncryptionData> CreateInternalV1_0(
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
#pragma warning disable CS0618 // obsolete
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V1_0
#pragma warning restore CS0618 // obsolete
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

        internal static async Task<EncryptionData> CreateInternalV2_0(
            string keyWrapAlgorithm,
            byte[] contentEncryptionKey,
            IKeyEncryptionKey keyEncryptionKey,
            bool async,
            CancellationToken cancellationToken)
        {
            // v2.0 binds content encryption key with protocol version under a single keywrap
            int keyOffset = Constants.ClientSideEncryption.V2.WrappedDataVersionLength;
            var dataToWrap = new byte[keyOffset + contentEncryptionKey.Length];
            Encoding.UTF8.GetBytes(ClientSideEncryptionVersionInternal.V2_0.Serialize()).CopyTo(dataToWrap, 0);
            contentEncryptionKey.CopyTo(dataToWrap, keyOffset);

            return new EncryptionData()
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent()
                {
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesGcm256,
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V2_0
                },
                EncryptedRegionInfo = new EncryptedRegionInfo()
                {
                    DataLength = Constants.ClientSideEncryption.V2.EncryptionRegionDataSize,
                    NonceLength = Constants.ClientSideEncryption.V2.NonceSize,
                },
                KeyWrappingMetadata = new Dictionary<string, string>()
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, AgentString }
                },
                WrappedContentKey = new KeyEnvelope()
                {
                    Algorithm = keyWrapAlgorithm,
                    EncryptedKey = async
                        ? await keyEncryptionKey.WrapKeyAsync(keyWrapAlgorithm, dataToWrap, cancellationToken).ConfigureAwait(false)
                        : keyEncryptionKey.WrapKey(keyWrapAlgorithm, dataToWrap, cancellationToken),
                    KeyId = keyEncryptionKey.KeyId
                }
            };
        }

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
