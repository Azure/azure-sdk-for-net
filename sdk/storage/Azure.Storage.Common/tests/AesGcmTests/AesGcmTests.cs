// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;
using System.Globalization;
using System;
using Azure.Storage.Shared.AesGcm;

namespace Azure.Storage.Common.AesGcm.Tests
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// From https://github.com/dotnet/runtime/blob/main/src/libraries/System.Security.Cryptography/tests/AesGcmTests.cs
    ///
    /// DO NOT ALTER UNLESS CONSULTING WITH BCL TEAM first
    /// </summary>
    [TestFixture]
    public class AesGcmTests
    {
        [Test]
        [TestCase(0, 1)]
        [TestCase(0, 30)]
        [TestCase(1, 1)]
        [TestCase(1, 100)]
        [TestCase(7, 12)]
        [TestCase(16, 16)]
        [TestCase(17, 29)]
        [TestCase(32, 7)]
        [TestCase(41, 25)]
        [TestCase(48, 22)]
        [TestCase(50, 5)]
        public void EncryptTamperAADDecrypt(int dataLength, int additionalDataLength)
        {
            byte[] additionalData = AesGcmTestHelpers.GetRandomBuffer(additionalDataLength);

            byte[] plaintext = Enumerable.Range(1, dataLength).Select((x) => (byte)x).ToArray();
            byte[] ciphertext = new byte[dataLength];
            byte[] key = AesGcmTestHelpers.GetRandomBuffer(16);
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(AesGcmWindows.NonceByteSizes.MinSize);
            byte[] tag = new byte[AesGcmWindows.TagByteSizes.MinSize];

            using (var aesGcm = new AesGcmWindows(key))
            {
                aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, additionalData);

                additionalData[0] ^= 1;

                byte[] decrypted = new byte[dataLength];
                Assert.Throws<CryptographicException>(
                    () => aesGcm.Decrypt(nonce, ciphertext, tag, decrypted, additionalData));
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(17)]
        [TestCase(29)]
        [TestCase(33)]
        public void InvalidKeyLength(int keyLength)
        {
            byte[] key = new byte[keyLength];
            Assert.Throws<CryptographicException>(() => new AesGcmWindows(key));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        public void InvalidNonceSize(int nonceSize)
        {
            int dataLength = 30;
            byte[] plaintext = Enumerable.Range(1, dataLength).Select((x) => (byte)x).ToArray();
            byte[] ciphertext = new byte[dataLength];
            byte[] key = AesGcmTestHelpers.GetRandomBuffer(16);
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(nonceSize);
            byte[] tag = new byte[AesGcmWindows.TagByteSizes.MinSize];

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentException>(() => aesGcm.Encrypt(nonce, plaintext, ciphertext, tag), "nonce");
            }
        }

        [Test]
        [TestCase(12)]
        public static void ValidNonceSize(int nonceSize)
        {
            const int dataLength = 35;
            byte[] plaintext = Enumerable.Range(1, dataLength).Select((x) => (byte)x).ToArray();
            byte[] ciphertext = new byte[dataLength];
            byte[] key = AesGcmTestHelpers.GetRandomBuffer(16);
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(nonceSize);
            byte[] tag = new byte[AesGcmWindows.TagByteSizes.MinSize];

            using (var aesGcm = new AesGcmWindows(key))
            {
                aesGcm.Encrypt(nonce, plaintext, ciphertext, tag);

                byte[] decrypted = new byte[dataLength];
                aesGcm.Decrypt(nonce, ciphertext, tag, decrypted);
                Assert.AreEqual(plaintext, decrypted);
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(17)]
        public static void InvalidTagSize(int tagSize)
        {
            int dataLength = 30;
            byte[] plaintext = Enumerable.Range(1, dataLength).Select((x) => (byte)x).ToArray();
            byte[] ciphertext = new byte[dataLength];
            byte[] key = AesGcmTestHelpers.GetRandomBuffer(16);
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(12);
            byte[] tag = new byte[tagSize];

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentException>(() => aesGcm.Encrypt(nonce, plaintext, ciphertext, tag), "tags");
            }
        }

        [Test]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        public static void ValidTagSize(int tagSize)
        {
            const int dataLength = 35;
            byte[] plaintext = Enumerable.Range(1, dataLength).Select((x) => (byte)x).ToArray();
            byte[] ciphertext = new byte[dataLength];
            byte[] key = AesGcmTestHelpers.GetRandomBuffer(16);
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(12);
            byte[] tag = new byte[tagSize];

            using (var aesGcm = new AesGcmWindows(key))
            {
                aesGcm.Encrypt(nonce, plaintext, ciphertext, tag);

                byte[] decrypted = new byte[dataLength];
                aesGcm.Decrypt(nonce, ciphertext, tag, decrypted);
                Assert.AreEqual(plaintext, decrypted);
            }
        }

        [Test]
        public static void TwoEncryptionsAndDecryptionsUsingOneInstance()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] originalData1 = Enumerable.Range(1, 15).Select((x) => (byte)x).ToArray();
            byte[] originalData2 = Enumerable.Range(14, 97).Select((x) => (byte)x).ToArray();
            byte[] associatedData2 = Enumerable.Range(100, 109).Select((x) => (byte)x).ToArray();
            byte[] nonce1 = "b41329dd64af2c3036661b46".HexToByteArray();
            byte[] nonce2 = "8ba10892e8b87d031196bf99".HexToByteArray();

            byte[] expectedCiphertext1 = "f1af1fb2d4485cc536d618475d52ff".HexToByteArray();
            byte[] expectedTag1 = "5ab65624c46b8160f34e81f5".HexToByteArray();

            byte[] expectedCiphertext2 = (
                "217bed01446d731a372a2b30ac7fcd73aed7c946d9171ae9c00b1c589ca73ba2" +
                "1c1bac79235d9ac0d0c899184dd8596b866fd96a6c1a28083557b43a5cbb5315" +
                "00e8cfbad8247c6d1deb51a7c5dfe45801a8d8d519b3fa982f546aa2d02db978" +
                "da").HexToByteArray();
            byte[] expectedTag2 = "9c75d006640ff4fb68c60c9548a45cf8".HexToByteArray();

            using (var aesGcm = new AesGcmWindows(key))
            {
                byte[] ciphertext1 = new byte[originalData1.Length];
                byte[] tag1 = new byte[expectedTag1.Length];
                aesGcm.Encrypt(nonce1, originalData1, ciphertext1, tag1);
                Assert.AreEqual(expectedCiphertext1, ciphertext1);
                Assert.AreEqual(expectedTag1, tag1);

                byte[] ciphertext2 = new byte[originalData2.Length];
                byte[] tag2 = new byte[expectedTag2.Length];
                aesGcm.Encrypt(nonce2, originalData2, ciphertext2, tag2, associatedData2);
                Assert.AreEqual(expectedCiphertext2, ciphertext2);
                Assert.AreEqual(expectedTag2, tag2);

                byte[] plaintext1 = new byte[originalData1.Length];
                aesGcm.Decrypt(nonce1, ciphertext1, tag1, plaintext1);
                Assert.AreEqual(originalData1, plaintext1);

                byte[] plaintext2 = new byte[originalData2.Length];
                aesGcm.Decrypt(nonce2, ciphertext2, tag2, plaintext2, associatedData2);
                Assert.AreEqual(originalData2, plaintext2);
            }
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(3, 4)]
        [TestCase(4, 3)]
        [TestCase(20, 120)]
        [TestCase(120, 20)]
        public static void PlaintextAndCiphertextSizeDiffer(int ptLen, int ctLen)
        {
            byte[] key = new byte[16];
            byte[] nonce = new byte[12];
            byte[] plaintext = new byte[ptLen];
            byte[] ciphertext = new byte[ctLen];
            byte[] tag = new byte[16];

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentException>(() => aesGcm.Encrypt(nonce, plaintext, ciphertext, tag));
                Assert.Throws<ArgumentException>(() => aesGcm.Decrypt(nonce, ciphertext, tag, plaintext));
            }
        }

        [Test]
        public static void NullKey()
        {
            Assert.Throws<ArgumentNullException>(() => new AesGcmWindows((byte[])null));
        }

        [Test]
        public static void EncryptDecryptNullNonce()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] plaintext = Array.Empty<byte>();
            byte[] ciphertext = Array.Empty<byte>();
            byte[] tag = new byte[16];

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentNullException>(() => aesGcm.Encrypt((byte[])null, plaintext, ciphertext, tag));
                Assert.Throws<ArgumentNullException>(() => aesGcm.Decrypt((byte[])null, ciphertext, tag, plaintext));
            }
        }

        [Test]
        public static void EncryptDecryptNullPlaintext()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] nonce = new byte[12];
            byte[] ciphertext = Array.Empty<byte>();
            byte[] tag = new byte[16];

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentNullException>(() => aesGcm.Encrypt(nonce, (byte[])null, ciphertext, tag));
                Assert.Throws<ArgumentNullException>(() => aesGcm.Decrypt(nonce, ciphertext, tag, (byte[])null));
            }
        }

        [Test]
        public static void EncryptDecryptNullCiphertext()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] nonce = new byte[12];
            byte[] plaintext = Array.Empty<byte>();
            byte[] tag = new byte[16];

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentNullException>(() => aesGcm.Encrypt(nonce, plaintext, (byte[])null, tag));
                Assert.Throws<ArgumentNullException>(() => aesGcm.Decrypt(nonce, (byte[])null, tag, plaintext));
            }
        }

        [Test]
        public static void EncryptDecryptNullTag()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] nonce = new byte[12];
            byte[] plaintext = Array.Empty<byte>();
            byte[] ciphertext = Array.Empty<byte>();

            using (var aesGcm = new AesGcmWindows(key))
            {
                Assert.Throws<ArgumentNullException>(() => aesGcm.Encrypt(nonce, plaintext, ciphertext, (byte[])null));
                Assert.Throws<ArgumentNullException>(() => aesGcm.Decrypt(nonce, ciphertext, (byte[])null, plaintext));
            }
        }

        [Test]
        public static void InplaceEncryptDecrypt()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(12);
            byte[] originalPlaintext = new byte[] { 1, 2, 8, 12, 16, 99, 0 };
            byte[] data = (byte[])originalPlaintext.Clone();
            byte[] tag = AesGcmTestHelpers.GetRandomBuffer(16);

            using (var aesGcm = new AesGcmWindows(key))
            {
                aesGcm.Encrypt(nonce, data, data, tag);
                Assert.AreNotEqual(originalPlaintext, data);

                aesGcm.Decrypt(nonce, data, tag, data);
                Assert.AreEqual(originalPlaintext, data);
            }
        }

        [Test]
        public static void InplaceEncryptTamperTagDecrypt()
        {
            byte[] key = "d5a194ed90cfe08abecd4691997ceb2c".HexToByteArray();
            byte[] nonce = AesGcmTestHelpers.GetRandomBuffer(12);
            byte[] originalPlaintext = new byte[] { 1, 2, 8, 12, 16, 99, 0 };
            byte[] data = (byte[])originalPlaintext.Clone();
            byte[] tag = new byte[16];

            using (var aesGcm = new AesGcmWindows(key))
            {
                aesGcm.Encrypt(nonce, data, data, tag);
                Assert.AreNotEqual(originalPlaintext, data);

                tag[0] ^= 1;

                Assert.Throws<CryptographicException>(
                    () => aesGcm.Decrypt(nonce, data, tag, data));
                Assert.AreEqual(new byte[data.Length], data);
            }
        }

        [Test]
        public static void AesGcmNistTests()
        {
            foreach (AeadTest test in s_nistGcmSpecTestCases)
            {
                using (var aesGcm = new AesGcmWindows(test.Key))
                {
                    byte[] ciphertext = new byte[test.Plaintext.Length];
                    byte[] tag = new byte[test.Tag.Length];
                    aesGcm.Encrypt(test.Nonce, test.Plaintext, ciphertext, tag, test.AssociatedData);
                    Assert.AreEqual(test.Ciphertext, ciphertext);
                    Assert.AreEqual(test.Tag, tag);

                    byte[] plaintext = new byte[test.Plaintext.Length];
                    aesGcm.Decrypt(test.Nonce, ciphertext, tag, plaintext, test.AssociatedData);
                    Assert.AreEqual(test.Plaintext, plaintext);
                }
            }
        }

        [Test]
        public static void AesGcmNistTestsVectorSelected()
        {
            foreach (AeadTest test in s_nistGcmTestVectorsSelectedCases)
            {
                using (var aesGcm = new AesGcmWindows(test.Key))
                {
                    byte[] ciphertext = new byte[test.Plaintext.Length];
                    byte[] tag = new byte[test.Tag.Length];
                    aesGcm.Encrypt(test.Nonce, test.Plaintext, ciphertext, tag, test.AssociatedData);
                    Assert.AreEqual(test.Ciphertext, ciphertext);
                    Assert.AreEqual(test.Tag, tag);

                    byte[] plaintext = new byte[test.Plaintext.Length];
                    aesGcm.Decrypt(test.Nonce, ciphertext, tag, plaintext, test.AssociatedData);
                    Assert.AreEqual(test.Plaintext, plaintext);
                }
            }
        }

        [Test]
        public static void AesGcmNistTestsTamperTag()
        {
            foreach (AeadTest test in s_nistGcmSpecTestCases)
            {
                using (var aesGcm = new AesGcmWindows(test.Key))
                {
                    byte[] ciphertext = new byte[test.Plaintext.Length];
                    byte[] tag = new byte[test.Tag.Length];
                    aesGcm.Encrypt(test.Nonce, test.Plaintext, ciphertext, tag, test.AssociatedData);
                    Assert.AreEqual(test.Ciphertext, ciphertext);
                    Assert.AreEqual(test.Tag, tag);

                    tag[0] ^= 1;

                    byte[] plaintext = AesGcmTestHelpers.GetRandomBuffer(test.Plaintext.Length);
                    Assert.Throws<CryptographicException>(
                        () => aesGcm.Decrypt(test.Nonce, ciphertext, tag, plaintext, test.AssociatedData));
                    Assert.AreEqual(new byte[plaintext.Length], plaintext);
                }
            }
        }

        [Test]
        public static void AesGcmNistTestsTamperTagVectorSelected()
        {
            foreach (AeadTest test in s_nistGcmTestVectorsSelectedCases)
            {
                using (var aesGcm = new AesGcmWindows(test.Key))
                {
                    byte[] ciphertext = new byte[test.Plaintext.Length];
                    byte[] tag = new byte[test.Tag.Length];
                    aesGcm.Encrypt(test.Nonce, test.Plaintext, ciphertext, tag, test.AssociatedData);
                    Assert.AreEqual(test.Ciphertext, ciphertext);
                    Assert.AreEqual(test.Tag, tag);

                    tag[0] ^= 1;

                    byte[] plaintext = AesGcmTestHelpers.GetRandomBuffer(test.Plaintext.Length);
                    Assert.Throws<CryptographicException>(
                        () => aesGcm.Decrypt(test.Nonce, ciphertext, tag, plaintext, test.AssociatedData));
                    Assert.AreEqual(new byte[plaintext.Length], plaintext);
                }
            }
        }

        [Test]
        public static void AesGcmNistTestsTamperCiphertext()
        {
            foreach (AeadTest test in s_nistGcmSpecTestCases)
            {
                if (test.Plaintext.Length > 0)
                {
                    using (var aesGcm = new AesGcmWindows(test.Key))
                    {
                        byte[] ciphertext = new byte[test.Plaintext.Length];
                        byte[] tag = new byte[test.Tag.Length];
                        aesGcm.Encrypt(test.Nonce, test.Plaintext, ciphertext, tag, test.AssociatedData);
                        Assert.AreEqual(test.Ciphertext, ciphertext);
                        Assert.AreEqual(test.Tag, tag);

                        ciphertext[0] ^= 1;

                        byte[] plaintext = AesGcmTestHelpers.GetRandomBuffer(test.Plaintext.Length);
                        Assert.Throws<CryptographicException>(
                            () => aesGcm.Decrypt(test.Nonce, ciphertext, tag, plaintext, test.AssociatedData));
                        Assert.AreEqual(new byte[plaintext.Length], plaintext);
                    }
                }
            }
        }

        [Test]
        public static void AesGcmNistTestsTamperCiphertextVectorSelected()
        {
            foreach (AeadTest test in s_nistGcmTestVectorsSelectedCases)
            {
                if (test.Plaintext.Length > 0)
                {
                    using (var aesGcm = new AesGcmWindows(test.Key))
                    {
                        byte[] ciphertext = new byte[test.Plaintext.Length];
                        byte[] tag = new byte[test.Tag.Length];
                        aesGcm.Encrypt(test.Nonce, test.Plaintext, ciphertext, tag, test.AssociatedData);
                        Assert.AreEqual(test.Ciphertext, ciphertext);
                        Assert.AreEqual(test.Tag, tag);

                        ciphertext[0] ^= 1;

                        byte[] plaintext = AesGcmTestHelpers.GetRandomBuffer(test.Plaintext.Length);
                        Assert.Throws<CryptographicException>(
                            () => aesGcm.Decrypt(test.Nonce, ciphertext, tag, plaintext, test.AssociatedData));
                        Assert.AreEqual(new byte[plaintext.Length], plaintext);
                    }
                }
            }
        }

        // https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Algorithm-Validation-Program/documents/mac/gcmtestvectors.zip
        private const string NistGcmTestVectors = "NIST GCM Test Vectors";

        // http://web.archive.org/web/20170811123217/http://csrc.nist.gov/groups/ST/toolkit//BCM/documents/proposedmodes/gcm/gcm-revised-spec.pdf
        private const string NistGcmSpecTestCases = "NIST GCM Spec test cases";

#pragma warning disable CA1034 // Nested types should not be visible
        public class AeadTest
#pragma warning restore CA1034 // Nested types should not be visible
        {
            public string Source { get; set; }
            public int CaseId { get; set; }
            public byte[] Key { get; set; }
            public byte[] Nonce { get; set; }
            public byte[] Plaintext { get; set; }
            public byte[] Ciphertext { get; set; }
            public byte[] AssociatedData { get; set; }
            public byte[] Tag { get; set; }

            private static string BitLength(byte[] data)
            {
                if (data == null)
                    return "0";
                return (data.Length * 8).ToString(CultureInfo.InvariantCulture);
            }

            public override string ToString()
            {
                return
                    $"{Source} - {CaseId} ({BitLength(Key)}/{BitLength(Nonce)}/" +
                    $"{BitLength(Plaintext)}/{BitLength(Tag)}/{BitLength(AssociatedData)})";
            }
        }

        // CaseId is unique per test case
        private static readonly AeadTest[] s_nistGcmSpecTestCases = new AeadTest[]
        {
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 1,
                Key = "00000000000000000000000000000000".HexToByteArray(),
                Nonce = "000000000000000000000000".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = null,
                Ciphertext = Array.Empty<byte>(),
                Tag = "58e2fccefa7e3061367f1d57a4e7455a".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 2,
                Key = "00000000000000000000000000000000".HexToByteArray(),
                Nonce = "000000000000000000000000".HexToByteArray(),
                Plaintext = "00000000000000000000000000000000".HexToByteArray(),
                AssociatedData = null,
                Ciphertext = "0388dace60b6a392f328c2b971b2fe78".HexToByteArray(),
                Tag = "ab6e47d42cec13bdf53a67b21257bddf".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 3,
                Key = "feffe9928665731c6d6a8f9467308308".HexToByteArray(),
                Nonce = "cafebabefacedbaddecaf888".HexToByteArray(),
                Plaintext = (
                    "d9313225f88406e5a55909c5aff5269a" +
                    "86a7a9531534f7da2e4c303d8a318a72" +
                    "1c3c0c95956809532fcf0e2449a6b525" +
                    "b16aedf5aa0de657ba637b391aafd255").HexToByteArray(),
                AssociatedData = null,
                Ciphertext = (
                    "42831ec2217774244b7221b784d0d49c" +
                    "e3aa212f2c02a4e035c17e2329aca12e" +
                    "21d514b25466931c7d8f6a5aac84aa05" +
                    "1ba30b396a0aac973d58e091473f5985").HexToByteArray(),
                Tag = "4d5c2af327cd64a62cf35abd2ba6fab4".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 4,
                Key = "feffe9928665731c6d6a8f9467308308".HexToByteArray(),
                Nonce = "cafebabefacedbaddecaf888".HexToByteArray(),
                Plaintext = (
                    "d9313225f88406e5a55909c5aff5269a" +
                    "86a7a9531534f7da2e4c303d8a318a72" +
                    "1c3c0c95956809532fcf0e2449a6b525" +
                    "b16aedf5aa0de657ba637b39").HexToByteArray(),
                AssociatedData = (
                    "feedfacedeadbeeffeedfacedeadbeef" +
                    "abaddad2").HexToByteArray(),
                Ciphertext = (
                    "42831ec2217774244b7221b784d0d49c" +
                    "e3aa212f2c02a4e035c17e2329aca12e" +
                    "21d514b25466931c7d8f6a5aac84aa05" +
                    "1ba30b396a0aac973d58e091").HexToByteArray(),
                Tag = "5bc94fbc3221a5db94fae95ae7121a47".HexToByteArray(),
            },
            // cases 5, 6 have not supported nonce size
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 7,
                Key = (
                    "00000000000000000000000000000000" +
                    "0000000000000000").HexToByteArray(),
                Nonce = "000000000000000000000000".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = null,
                Ciphertext = Array.Empty<byte>(),
                Tag = "cd33b28ac773f74ba00ed1f312572435".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 8,
                Key = (
                    "00000000000000000000000000000000" +
                    "0000000000000000").HexToByteArray(),
                Nonce = "000000000000000000000000".HexToByteArray(),
                Plaintext = "00000000000000000000000000000000".HexToByteArray(),
                AssociatedData = null,
                Ciphertext = "98e7247c07f0fe411c267e4384b0f600".HexToByteArray(),
                Tag = "2ff58d80033927ab8ef4d4587514f0fb".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 9,
                Key = (
                    "feffe9928665731c6d6a8f9467308308" +
                    "feffe9928665731c").HexToByteArray(),
                Nonce = "cafebabefacedbaddecaf888".HexToByteArray(),
                Plaintext = (
                    "d9313225f88406e5a55909c5aff5269a" +
                    "86a7a9531534f7da2e4c303d8a318a72" +
                    "1c3c0c95956809532fcf0e2449a6b525" +
                    "b16aedf5aa0de657ba637b391aafd255").HexToByteArray(),
                Ciphertext = (
                    "3980ca0b3c00e841eb06fac4872a2757" +
                    "859e1ceaa6efd984628593b40ca1e19c" +
                    "7d773d00c144c525ac619d18c84a3f47" +
                    "18e2448b2fe324d9ccda2710acade256").HexToByteArray(),
                Tag = "9924a7c8587336bfb118024db8674a14".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 10,
                Key = (
                    "feffe9928665731c6d6a8f9467308308" +
                    "feffe9928665731c").HexToByteArray(),
                Nonce = "cafebabefacedbaddecaf888".HexToByteArray(),
                Plaintext = (
                    "d9313225f88406e5a55909c5aff5269a" +
                    "86a7a9531534f7da2e4c303d8a318a72" +
                    "1c3c0c95956809532fcf0e2449a6b525" +
                    "b16aedf5aa0de657ba637b39").HexToByteArray(),
                AssociatedData = (
                    "feedfacedeadbeeffeedfacedeadbeef" +
                    "abaddad2").HexToByteArray(),
                Ciphertext = (
                    "3980ca0b3c00e841eb06fac4872a2757" +
                    "859e1ceaa6efd984628593b40ca1e19c" +
                    "7d773d00c144c525ac619d18c84a3f47" +
                    "18e2448b2fe324d9ccda2710").HexToByteArray(),
                Tag = "2519498e80f1478f37ba55bd6d27618c".HexToByteArray(),
            },
            // cases 11, 12 have not supported nonce size
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 13,
                Key = (
                    "00000000000000000000000000000000" +
                    "00000000000000000000000000000000").HexToByteArray(),
                Nonce = "000000000000000000000000".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = null,
                Ciphertext = Array.Empty<byte>(),
                Tag = "530f8afbc74536b9a963b4f1c4cb738b".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 14,
                Key = (
                    "00000000000000000000000000000000" +
                    "00000000000000000000000000000000").HexToByteArray(),
                Nonce = "000000000000000000000000".HexToByteArray(),
                Plaintext = "00000000000000000000000000000000".HexToByteArray(),
                AssociatedData = null,
                Ciphertext = "cea7403d4d606b6e074ec5d3baf39d18".HexToByteArray(),
                Tag = "d0d1c8a799996bf0265b98b5d48ab919".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 15,
                Key = (
                    "feffe9928665731c6d6a8f9467308308" +
                    "feffe9928665731c6d6a8f9467308308").HexToByteArray(),
                Nonce = "cafebabefacedbaddecaf888".HexToByteArray(),
                Plaintext = (
                    "d9313225f88406e5a55909c5aff5269a" +
                    "86a7a9531534f7da2e4c303d8a318a72" +
                    "1c3c0c95956809532fcf0e2449a6b525" +
                    "b16aedf5aa0de657ba637b391aafd255").HexToByteArray(),
                AssociatedData = null,
                Ciphertext = (
                    "522dc1f099567d07f47f37a32a84427d" +
                    "643a8cdcbfe5c0c97598a2bd2555d1aa" +
                    "8cb08e48590dbb3da7b08b1056828838" +
                    "c5f61e6393ba7a0abcc9f662898015ad").HexToByteArray(),
                Tag = "b094dac5d93471bdec1a502270e3cc6c".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmSpecTestCases,
                CaseId = 16,
                Key = (
                    "feffe9928665731c6d6a8f9467308308" +
                    "feffe9928665731c6d6a8f9467308308").HexToByteArray(),
                Nonce = "cafebabefacedbaddecaf888".HexToByteArray(),
                Plaintext = (
                    "d9313225f88406e5a55909c5aff5269a" +
                    "86a7a9531534f7da2e4c303d8a318a72" +
                    "1c3c0c95956809532fcf0e2449a6b525" +
                    "b16aedf5aa0de657ba637b39").HexToByteArray(),
                AssociatedData = (
                    "feedfacedeadbeeffeedfacedeadbeef" +
                    "abaddad2").HexToByteArray(),
                Ciphertext = (
                    "522dc1f099567d07f47f37a32a84427d" +
                    "643a8cdcbfe5c0c97598a2bd2555d1aa" +
                    "8cb08e48590dbb3da7b08b1056828838" +
                    "c5f61e6393ba7a0abcc9f662").HexToByteArray(),
                Tag = "76fc6ece0f4e1768cddf8853bb2d551b".HexToByteArray(),
            },
            // cases 17, 18 have not supported nonce size
        };

        // [ CaseId; Key.Length; Nonce.Length; Plaintext.Length; AssociatedData.Length; Tag.Length ] is unique
        private static readonly AeadTest[] s_nistGcmTestVectorsSelectedCases = new AeadTest[]
        {
            // key length = 128
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "11754cd72aec309bf52f7687212e8957".HexToByteArray(),
                Nonce = "3c819d9a9bed087615030b65".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = null,
                Ciphertext = Array.Empty<byte>(),
                Tag = "250327c674aaf477aef2675748cf6971".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "4df7a13e43c3d7b66b1a72fac5ba398e".HexToByteArray(),
                Nonce = "97179a3a2d417908dcf0fb28".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = "cbb7fc0010c255661e23b07dbd804b1e06ae70ac".HexToByteArray(),
                Ciphertext = Array.Empty<byte>(),
                Tag = "37791edae6c137ea946cfb40".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "0ef21489e942ae5240e41749346a86a2".HexToByteArray(),
                Nonce = "431ae3f1a702cc34b55b90bf".HexToByteArray(),
                Plaintext = "882deb960fd0f8c98c707ade59".HexToByteArray(),
                AssociatedData = (
                    "d6d20f982bdad4b70213bbc5f3921f068e7784c30070f" +
                    "fe5c06f0daa8019b6ed95b95ba294630c21008d749eb7" +
                    "1e83e847fb6ca797aaa3035e714cdb13a867ad90b2eba" +
                    "a652d50a5b6adc84e34afc1985449f45eed08cac3cb34").HexToByteArray(),
                Ciphertext = "ec8fdf5f4afb96ebe0e845dc3b".HexToByteArray(),
                Tag = "45d4b03158be4e07953767ee".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "594157ec4693202b030f33798b07176d".HexToByteArray(),
                Nonce = "49b12054082660803a1df3df".HexToByteArray(),
                Plaintext = (
                    "3feef98a976a1bd634f364ac428bb59cd51fb159ec178994691" +
                    "8dbd50ea6c9d594a3a31a5269b0da6936c29d063a5fa2cc8a1c").HexToByteArray(),
                AssociatedData = null,
                Ciphertext = (
                    "c1b7a46a335f23d65b8db4008a49796906e225474f4fe7d39e5" +
                    "5bf2efd97fd82d4167de082ae30fa01e465a601235d8d68bc69").HexToByteArray(),
                Tag = "ba92d3661ce8b04687e8788d55417dc2".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "0493024bab2833edef571ce7224750ab".HexToByteArray(),
                Nonce = "ab8dedbcdc57f283493fe7b3".HexToByteArray(),
                Plaintext = (
                    "5f6691c5813169d128e7af7678281085af09fb1ddacfc89e1a1" +
                    "4cf14372d74eda6298a0772a594eb5a80a4c56b65744c2347d2").HexToByteArray(),
                AssociatedData = "8aca2645dd27195855b62f7d39ace11e".HexToByteArray(),
                Ciphertext = (
                    "b5d0733ade2203f5095bff60c9f5abef7770e38a56a9699e960" +
                    "8a69969141a912a0b186f7cabe2dc187cb77331c625832510e2").HexToByteArray(),
                Tag = "d34a843edbf8234abffeb7de".HexToByteArray(),
            },
            // key length = 192
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "aa740abfadcda779220d3b406c5d7ec09a77fe9d94104539".HexToByteArray(),
                Nonce = "ab2265b4c168955561f04315".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = null,
                Ciphertext = Array.Empty<byte>(),
                Tag = "f149e2b5f0adaa9842ca5f45b768a8fc".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "c8ceaa125d2fb67e6d06e4c892d3ddf87081ef9be42fd9cb".HexToByteArray(),
                Nonce = "38b081bda77b18484252c200".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = "f284d23f6dde9a417046426f5a014b37".HexToByteArray(),
                Ciphertext = Array.Empty<byte>(),
                Tag = "a768033d680198aabb37cf09".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "c43e3bee7c89809f3f16f534a34a5526e2a1db16211dce7a".HexToByteArray(),
                Nonce = "62ec4fc5576ae52b5efcc715".HexToByteArray(),
                Plaintext = "bd4364e215aa459433f08e2fcc9184d9".HexToByteArray(),
                AssociatedData = null,
                Ciphertext = "8683a2e7241113c0c5a991d19c13d306".HexToByteArray(),
                Tag = "d874766acb70effd5890955f3c".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "f6fde0b9fbd2ac2105db66c94425c8db359987d9b706badf".HexToByteArray(),
                Nonce = "9c0df1c51d2bcbb4a3c9e759".HexToByteArray(),
                Plaintext = "58d0eb269f92491374de8675ce9fafa7".HexToByteArray(),
                AssociatedData = "a5c8d41e16165a4df9a6d59ab3556440".HexToByteArray(),
                Ciphertext = "bd0d9036e9f2a6ee82992936b2b3767b".HexToByteArray(),
                Tag = "589498ce7f55a48ecb87721308ee02".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "cf1d9456f6bd4b2fc95e40197f6950843bb2ed771f5f88dc".HexToByteArray(),
                Nonce = "0a34907cd0ec7e9b92258e14".HexToByteArray(),
                Plaintext = (
                    "cd67721f6e756727a0075b4e805d13f6702f14e572fe1cd7cd5" +
                    "5bca281d6e02176c6288703d121ea73bc923d4aae919cab5878").HexToByteArray(),
                AssociatedData = null,
                Ciphertext = (
                    "41fb3e8030d693bbbeabfeb7346ad2b4d7518594c9ef7e2f9b0" +
                    "3177ba2f2d9d10ae1dce68d370a79886dea990f472f2ab46e8b").HexToByteArray(),
                Tag = "3e169ae8466b010f51d3d88fda92".HexToByteArray(),
            },
            // key length = 256
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "b52c505a37d78eda5dd34f20c22540ea1b58963cf8e5bf8ffa85f9f2492505b4".HexToByteArray(),
                Nonce = "516c33929df5a3284ff463d7".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = null,
                Ciphertext = Array.Empty<byte>(),
                Tag = "bdc1ac884d332457a1d2664f168c76f0".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "7cb746fbd70e929a8efa65d16b1aa8a37f5b4478edc686b3a9d31631d5bf114b".HexToByteArray(),
                Nonce = "2f007847f97273c353af2b18".HexToByteArray(),
                Plaintext = Array.Empty<byte>(),
                AssociatedData = (
                    "17e84902ef33808d450f6d19b19fb3f863ca6c5476fa4" +
                    "4105ab09a34ad530b9e606ebd606529b6d088a513fdf8" +
                    "948ae78f44aff67b6f2429effc126d3c5de8cc2ca8b9b" +
                    "f7a5b4417c0a8a4f90742637d73acfbb615cde7352463").HexToByteArray(),
                Ciphertext = Array.Empty<byte>(),
                Tag = "44ecc2383ae85a8cbad1f1b0".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "810bf78086dc8f630134934f9d978e0f308858e20b21dd4d319f0e6c811d6cec".HexToByteArray(),
                Nonce = "afc220a95ad53a376dadba12".HexToByteArray(),
                Plaintext = "edd60681c4919db5e32b6e44e1".HexToByteArray(),
                AssociatedData = null,
                Ciphertext = "74e5334c28504d10116371d4c9".HexToByteArray(),
                Tag = "e6737691a08f9a08e901b3902977".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "e29e006956c7532d40bd56df5f565d57ee1ea49037404cca7b6ea9dc9e36ab0f".HexToByteArray(),
                Nonce = "ed2caad30eb367d2d89a5ffb".HexToByteArray(),
                Plaintext =
                    "b982ea6ff68af4c5202d71466f9f9f63614ad5378859a62d7a38ee32aa370bd9".HexToByteArray(),
                AssociatedData = (
                    "416a7b1db963ed683fd91bc2c5e9df3998944c3d0cbea2d2" +
                    "302c8a67249973525d0dbe8d13f806174dd983ab18854ae6").HexToByteArray(),
                Ciphertext = "656539e12450db9dd88e4113f7890e80c6186768e6c8b1fc869c42dfad7b58bf".HexToByteArray(),
                Tag = "4366e2ce0396f0410ebcb893".HexToByteArray(),
            },
            new AeadTest
            {
                Source = NistGcmTestVectors,
                CaseId = 0,
                Key = "6db07c6e834108aa97f4fb9b59378b75b6d58002f0063d8ec48af5adca3327a4".HexToByteArray(),
                Nonce = "cb2892bb9b841ff16ba0bee6".HexToByteArray(),
                Plaintext = (
                    "241f625f0560e9bf6bdb2c3734d79700d18ab0b6d0a2ae8d322" +
                    "b28195705f9db1f407b9f21372a69478b2d0b960af184c556fc").HexToByteArray(),
                AssociatedData = (
                    "e739451bbc939ae0f7b1caecf23c65112969bfbfe4b5b" +
                    "1b1c0c040cbac468e37dbef25d770f1f8b579880063c3" +
                    "37386c7033e1d0bd65924cd4ad9609c4eefc40804730a" +
                    "4474471e5a8cdda361b868074daab3e6feec3da5d5f0c").HexToByteArray(),
                Ciphertext = (
                    "19e1bf9c4b7c5f51de8a2fa0dc5d4d8cb8cbcd1c2b7df193688" +
                    "d961aa106cfd5ea9bd7c62b492df4514877b209f29e11c2efa8").HexToByteArray(),
                Tag = "4ce8aff15debc1b23c50665b9c".HexToByteArray(),
            },
        };
    }
#endif
}
