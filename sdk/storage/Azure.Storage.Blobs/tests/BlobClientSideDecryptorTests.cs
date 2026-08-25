// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Cryptography.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class BlobClientSideDecryptorTests
    {
        #region GetAndValidateEncryptionDataOrDefault

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_NullMetadata_ReturnsDefault()
        {
            var result = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(null);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_NoEncryptionKey_ReturnsDefault()
        {
            var metadata = new Dictionary<string, string> { { "somekey", "somevalue" } };
            var result = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_V1_MissingIV_Throws()
        {
            var encryptionData = new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent
                {
#pragma warning disable CS0618 // obsolete
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V1_0,
#pragma warning restore CS0618 // obsolete
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesCbc256,
                },
                WrappedContentKey = new KeyEnvelope
                {
                    KeyId = "keyId",
                    EncryptedKey = new byte[] { 1, 2, 3 },
                    Algorithm = "algo"
                },
                ContentEncryptionIV = null,
                KeyWrappingMetadata = new Dictionary<string, string>
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, "1.0" }
                }
            };

            var metadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(encryptionData) }
            };

            Assert.Throws<InvalidOperationException>(() =>
                BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata));
        }

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_V1_Valid_ReturnsData()
        {
            var encryptionData = new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent
                {
#pragma warning disable CS0618 // obsolete
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V1_0,
#pragma warning restore CS0618 // obsolete
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesCbc256,
                },
                WrappedContentKey = new KeyEnvelope
                {
                    KeyId = "keyId",
                    EncryptedKey = new byte[] { 1, 2, 3 },
                    Algorithm = "algo"
                },
                ContentEncryptionIV = new byte[16],
                KeyWrappingMetadata = new Dictionary<string, string>
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, "1.0" }
                }
            };

            var metadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(encryptionData) }
            };

            var result = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata);

            Assert.IsNotNull(result);
#pragma warning disable CS0618 // obsolete
            Assert.AreEqual(ClientSideEncryptionVersionInternal.V1_0, result.EncryptionAgent.EncryptionVersion);
#pragma warning restore CS0618 // obsolete
        }

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_V2_MissingRegionInfo_Throws()
        {
            var encryptionData = new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent
                {
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V2_0,
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesGcm256,
                },
                WrappedContentKey = new KeyEnvelope
                {
                    KeyId = "keyId",
                    EncryptedKey = new byte[] { 1, 2, 3 },
                    Algorithm = "algo"
                },
                EncryptedRegionInfo = null,
                KeyWrappingMetadata = new Dictionary<string, string>
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, "2.0" }
                }
            };

            var metadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(encryptionData) }
            };

            Assert.Throws<InvalidOperationException>(() =>
                BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata));
        }

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_V2_Valid_ReturnsData()
        {
            var encryptionData = CreateV2EncryptionData();

            var metadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, EncryptionDataSerializer.Serialize(encryptionData) }
            };

            var result = BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata);

            Assert.IsNotNull(result);
            Assert.AreEqual(ClientSideEncryptionVersionInternal.V2_0, result.EncryptionAgent.EncryptionVersion);
        }

        [Test]
        public void GetAndValidateEncryptionDataOrDefault_MissingEncryptedKey_Throws()
        {
            // Construct a valid V2 encryption data, serialize it, then manipulate the JSON
            // to remove the EncryptedKey value to simulate missing key scenario.
            var encryptionData = CreateV2EncryptionData();
            string serialized = EncryptionDataSerializer.Serialize(encryptionData);
            // Replace the base64-encoded key with null in JSON
            var json = Newtonsoft.Json.Linq.JObject.Parse(serialized);
            json["WrappedContentKey"]["EncryptedKey"] = null;
            serialized = json.ToString(Newtonsoft.Json.Formatting.None);

            var metadata = new Dictionary<string, string>
            {
                { Constants.ClientSideEncryption.EncryptionDataKey, serialized }
            };

            Assert.That(() =>
                BlobClientSideDecryptor.GetAndValidateEncryptionDataOrDefault(metadata),
                Throws.InstanceOf<ArgumentNullException>());
        }

        #endregion

        #region GetEncryptedBlobRange

        [Test]
        public void GetEncryptedBlobRange_DefaultEncryptionData_ReturnsSameRange()
        {
            var originalRange = new HttpRange(100, 200);
            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, default(EncryptionData));
            Assert.AreEqual(originalRange, result.BlobRange);
        }

        [Test]
        public void GetEncryptedBlobRange_V1_ZeroOffset_NoAdjustment()
        {
            var encryptionData = CreateV1EncryptionData();
            var originalRange = new HttpRange(0, 32);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            Assert.AreEqual(0, result.BlobRange.Offset);
            Assert.AreEqual(32, result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_V1_OffsetLessThanBlockSize_AlignsToBlockBoundary()
        {
            var encryptionData = CreateV1EncryptionData();
            // Offset 5, within first block (blocksize=16), no IV needed
            var originalRange = new HttpRange(5, 10);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            // offset adjusted back by 5 (diff from block boundary), so offset=0
            Assert.AreEqual(0, result.BlobRange.Offset);
            // count adjusted: 10 + 5 = 15, rounded up to block boundary = 16
            Assert.AreEqual(16, result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_V1_OffsetBeyondBlockSize_IncludesIV()
        {
            var encryptionData = CreateV1EncryptionData();
            // Offset 20 (>16), diff from block boundary = 20%16 = 4
            var originalRange = new HttpRange(20, 10);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            // offset = 20 - 4(diff) - 16(IV) = 0
            Assert.AreEqual(0, result.BlobRange.Offset);
            // count = 10 + 4(diff) + 16(IV) = 30, rounded up to 32
            Assert.AreEqual(32, result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_V1_NullLength_ReturnsNullLength()
        {
            var encryptionData = CreateV1EncryptionData();
            var originalRange = new HttpRange(0, null);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            Assert.AreEqual(0, result.BlobRange.Offset);
            Assert.IsNull(result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_V2_ZeroOffset_NoAdjustment()
        {
            var encryptionData = CreateV2EncryptionData();
            int totalRegionSize = Constants.ClientSideEncryption.V2.NonceSize
                + Constants.ClientSideEncryption.V2.EncryptionRegionDataSize
                + Constants.ClientSideEncryption.V2.TagSize;
            var originalRange = new HttpRange(0, 100);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            Assert.AreEqual(0, result.BlobRange.Offset);
            // end is in region 0, so count = 1 * totalRegionSize
            Assert.AreEqual(totalRegionSize, result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_V2_OffsetInSecondRegion()
        {
            var encryptionData = CreateV2EncryptionData();
            int dataSize = Constants.ClientSideEncryption.V2.EncryptionRegionDataSize;
            int totalRegionSize = Constants.ClientSideEncryption.V2.NonceSize
                + dataSize
                + Constants.ClientSideEncryption.V2.TagSize;

            // Offset in second region
            var originalRange = new HttpRange(dataSize + 100, 50);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            // Region 1 start
            Assert.AreEqual(1 * totalRegionSize, result.BlobRange.Offset);
            // End is also in region 1, so count = 2 * totalRegionSize - 1 * totalRegionSize = totalRegionSize
            Assert.AreEqual(totalRegionSize, result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_V2_NullLength_ReturnsNullLength()
        {
            var encryptionData = CreateV2EncryptionData();
            var originalRange = new HttpRange(0, null);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, encryptionData);

            Assert.AreEqual(0, result.BlobRange.Offset);
            Assert.IsNull(result.BlobRange.Length);
        }

        [Test]
        public void GetEncryptedBlobRange_StringOverload_Works()
        {
            var encryptionData = CreateV2EncryptionData();
            string rawEncryptionData = EncryptionDataSerializer.Serialize(encryptionData);
            var originalRange = new HttpRange(0, 100);

            var result = BlobClientSideDecryptor.GetEncryptedBlobRange(originalRange, rawEncryptionData);

            Assert.AreEqual(0, result.BlobRange.Offset);
            Assert.IsTrue(result.BlobRange.Length > 100);
        }

        #endregion

        #region Helpers

        private static EncryptionData CreateV1EncryptionData()
        {
            return new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent
                {
#pragma warning disable CS0618 // obsolete
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V1_0,
#pragma warning restore CS0618 // obsolete
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesCbc256,
                },
                WrappedContentKey = new KeyEnvelope
                {
                    KeyId = "keyId",
                    EncryptedKey = new byte[] { 1, 2, 3 },
                    Algorithm = "algo"
                },
                ContentEncryptionIV = new byte[16],
                KeyWrappingMetadata = new Dictionary<string, string>
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, "1.0" }
                }
            };
        }

        private static EncryptionData CreateV2EncryptionData()
        {
            return new EncryptionData
            {
                EncryptionMode = Constants.ClientSideEncryption.EncryptionMode,
                EncryptionAgent = new EncryptionAgent
                {
                    EncryptionVersion = ClientSideEncryptionVersionInternal.V2_0,
                    EncryptionAlgorithm = ClientSideEncryptionAlgorithm.AesGcm256,
                },
                WrappedContentKey = new KeyEnvelope
                {
                    KeyId = "keyId",
                    EncryptedKey = new byte[] { 1, 2, 3 },
                    Algorithm = "algo"
                },
                EncryptedRegionInfo = new EncryptedRegionInfo
                {
                    DataLength = Constants.ClientSideEncryption.V2.EncryptionRegionDataSize,
                    NonceLength = Constants.ClientSideEncryption.V2.NonceSize
                },
                KeyWrappingMetadata = new Dictionary<string, string>
                {
                    { Constants.ClientSideEncryption.AgentMetadataKey, "2.0" }
                }
            };
        }

        #endregion
    }
}
