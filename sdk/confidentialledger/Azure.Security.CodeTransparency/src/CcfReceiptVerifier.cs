// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Formats.Cbor;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Cose;
using System.Text;
using static Azure.Security.CodeTransparency.CcfReceipt;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// CcfReceiptVerifier contains the methods to verify a CCF SCITT receipt's integrity and its
    /// inclusion in the Signing Transparency Service. Verification requires the receipt, the
    /// COSE_Sign1 signed statement that was submitted to the service, and the service's public
    /// receipt-verification key. The receipt can also be embedded in the COSE_Sign1 envelope.
    /// </summary>
    public class CcfReceiptVerifier
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CcfReceiptVerifier"/>.
        /// </summary>
        public CcfReceiptVerifier()
        {
        }

        /// <summary>
        /// Verifies a CCF SCITT receipt against a signed statement using the supplied verification key.
        /// If verification fails, an exception is thrown explaining which step failed.
        /// #1 Reference: https://datatracker.ietf.org/doc/draft-ietf-scitt-architecture/
        /// #2 Reference: https://datatracker.ietf.org/doc/draft-birkholz-cose-receipts-ccf-profile/
        /// </summary>
        /// <param name="receiptCoseSign1Bytes">Receipt in COSE_Sign1 CBOR bytes.</param>
        /// <param name="signedStatementCoseSign1Bytes">The input signed statement bytes.</param>
        /// <param name="verificationKey">The service public key used to verify the receipt.</param>
        /// <exception cref="ArgumentNullException"><paramref name="verificationKey"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the verification fails.</exception>
        public static void Verify(byte[] receiptCoseSign1Bytes, byte[] signedStatementCoseSign1Bytes, CodeTransparencyVerificationKey verificationKey)
        {
            if (verificationKey == null)
            {
                throw new ArgumentNullException(nameof(verificationKey));
            }

            VerifyCore(receiptCoseSign1Bytes, signedStatementCoseSign1Bytes, verificationKey);
        }

        /// <summary>
        /// Verifies a CCF SCITT receipt against a signed statement using a caller-owned <see cref="ECDsa"/> key.
        /// The supplied key ID must match the key ID in the receipt.
        /// </summary>
        /// <param name="receiptCoseSign1Bytes">Receipt in COSE_Sign1 CBOR bytes.</param>
        /// <param name="signedStatementCoseSign1Bytes">The input signed statement bytes.</param>
        /// <param name="keyId">The case-sensitive key ID that identifies <paramref name="publicKey"/>.</param>
        /// <param name="publicKey">The caller-owned ECDSA public key used to verify the receipt.</param>
        /// <exception cref="ArgumentException"><paramref name="keyId"/> is null or empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="publicKey"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the verification fails.</exception>
        public static void Verify(byte[] receiptCoseSign1Bytes, byte[] signedStatementCoseSign1Bytes, string keyId, ECDsa publicKey)
        {
            var verificationKey = new CodeTransparencyVerificationKey(keyId, publicKey);
            VerifyCore(receiptCoseSign1Bytes, signedStatementCoseSign1Bytes, verificationKey);
        }

        /// <summary>
        /// Verifies a CCF SCITT receipt against a signed statement. The key ID is extracted from the receipt
        /// and matched, case-sensitively, against the supplied key set.
        /// </summary>
        /// <param name="receiptCoseSign1Bytes">Receipt in COSE_Sign1 CBOR bytes.</param>
        /// <param name="signedStatementCoseSign1Bytes">The input signed statement bytes.</param>
        /// <param name="verificationKeys">The service public keys used to verify the receipt.</param>
        /// <exception cref="ArgumentNullException"><paramref name="verificationKeys"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the verification fails or no matching key is found.</exception>
        public static void Verify(byte[] receiptCoseSign1Bytes, byte[] signedStatementCoseSign1Bytes, CodeTransparencyVerificationKeySet verificationKeys)
        {
            if (verificationKeys == null)
            {
                throw new ArgumentNullException(nameof(verificationKeys));
            }

            string keyId = ExtractReceiptKeyId(receiptCoseSign1Bytes);
            if (!verificationKeys.TryGetKey(keyId, out CodeTransparencyVerificationKey verificationKey))
            {
                throw new InvalidOperationException($"Key with ID '{keyId}' not found.");
            }

            VerifyCore(receiptCoseSign1Bytes, signedStatementCoseSign1Bytes, verificationKey);
        }

        private static string ExtractReceiptKeyId(byte[] receiptBytes)
        {
            CoseSign1Message receipt = CoseMessage.DecodeSign1(receiptBytes);
            if (!receipt.ProtectedHeaders.TryGetValue(CoseHeaderLabel.KeyIdentifier, out CoseHeaderValue kid))
            {
                throw new InvalidOperationException("KID not found.");
            }

            return Encoding.UTF8.GetString(kid.GetValueAsBytes());
        }

        private static void VerifyCore(byte[] receiptBytes, byte[] signedStatementBytes, CodeTransparencyVerificationKey verificationKey)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] claimsDigest = sha256.ComputeHash(signedStatementBytes);

            // Extract the expected KID from the public key used for verification,
            // and check it against the value set in the COSE header before using
            // it to verify the proofs.
            byte[] expectedKid = Encoding.UTF8.GetBytes(verificationKey.KeyId);

            CoseSign1Message receipt = CoseMessage.DecodeSign1(receiptBytes);

            // Get Alg from ProtectedHeaders
            if (!receipt.ProtectedHeaders.TryGetValue(CoseHeaderLabel.Algorithm, out CoseHeaderValue alg))
            {
                throw new InvalidOperationException("Alg not found");
            }

            // Validate alg based on https://www.iana.org/assignments/cose/cose.xhtml#algorithms
            // The receipt algorithm must match the algorithm implied by the verification key's curve/size.
            int algValue = alg.GetValueAsInt32();
            if (algValue != verificationKey.CoseAlgorithm)
            {
                throw new InvalidOperationException($"The ECDsa key uses the wrong algorithm. Expected {verificationKey.CoseAlgorithm} Found {algValue}");
            }

            if (!receipt.ProtectedHeaders.TryGetValue(CoseHeaderLabel.KeyIdentifier, out CoseHeaderValue kid) ||
                !expectedKid.SequenceEqual(kid.GetValueAsBytes()))
            {
                throw new InvalidOperationException("KID mismatch.");
            }

            // Get VDS from ProtectedHeaders
            if (!receipt.ProtectedHeaders.TryGetValue(new CoseHeaderLabel(CosePhdrVdsLabel), out CoseHeaderValue vds))
            {
                throw new InvalidOperationException("Verifiable Data Structure is required");
            }

            if (vds.GetValueAsInt32() != CcfTreeAlgLabel)
            {
                throw new InvalidOperationException("Verifiable Data Structure is not CCF.");
            }

            if (!receipt.UnprotectedHeaders.TryGetValue(new CoseHeaderLabel(CosePhdrVdpLabel), out CoseHeaderValue vdp))
            {
                throw new InvalidOperationException($"Verifiable data proof {CosePhdrVdpLabel} is required");
            }

            var proofBytes = vdp.EncodedValue.ToArray();
            CborReader cborReader = new CborReader(proofBytes);
            Dictionary<int, byte[]> proof = ReadCborMap(cborReader);

            if (!proof.TryGetValue(CoseReceiptInclusionProofLabel, out var proofs))
            {
                throw new InvalidOperationException("Inclusion proof is required");
            }

            // InclusionProofs is an array of cbor bytestr
            List<byte[]> inclusionProofs = new List<byte[]>();
            CborReader proofsReader = new CborReader(proofs);
            proofsReader.ReadStartArray();
            if (proofsReader.PeekState() == CborReaderState.EndArray)
            {
                throw new InvalidOperationException("At least one inclusion proof is expected");
            }
            while (proofsReader.PeekState() != CborReaderState.EndArray)
            {
                inclusionProofs.Add(proofsReader.ReadByteString());
            }
            proofsReader.ReadEndArray();

            using ECDsa ecdsaKey = verificationKey.ToECDsa();

            // Retrieve all the inclusion proof, if any
            foreach (byte[] inclusionProofBytes in inclusionProofs)
            {
                CborReader reader1 = new(inclusionProofBytes);
                Dictionary<int, byte[]> inclusionProof = ReadCborMap(reader1);

                // Ensure Leaf exists in inclusionProof
                if (!inclusionProof.TryGetValue(CcfProofLeafLabel, out var leafBytes))
                {
                    throw new InvalidOperationException("Leaf must be present");
                }

                // Ensure Path exist in inclusionProof
                if (!inclusionProof.TryGetValue(CcfProofPathLabel, out var proofPaths))
                {
                    throw new InvalidOperationException("Path must be present");
                }

                // Deserialize leafBytes into a Leaf
                Leaf leaf = GetLeaf(leafBytes);

                // Deserialize the ProofPaths into a List of ProofElement
                List<ProofElement> proofElements = GetProofElements(proofPaths);

                byte[] accumulator = sha256.ComputeHash(
                    CombineByteArrays(
                        leaf.InternalTransactionHash,
                        sha256.ComputeHash(Encoding.UTF8.GetBytes(leaf.InternalEvidence)),
                        leaf.DataHash));

                foreach (ProofElement proofElement in proofElements)
                {
                    if (proofElement.Left)
                    {
                        accumulator = sha256.ComputeHash(CombineByteArrays(proofElement.Hash, accumulator));
                    }
                    else
                    {
                        accumulator = sha256.ComputeHash(CombineByteArrays(accumulator, proofElement.Hash));
                    }
                }

                if (!receipt.VerifyDetached(ecdsaKey, new ReadOnlySpan<byte>(accumulator)))
                {
                    throw new InvalidOperationException("Signature verification failed");
                }

                // Ensure claimsDigest matches the Leaf dataHash
                if (!claimsDigest.SequenceEqual(leaf.DataHash))
                {
                    throw new InvalidOperationException($"Claim digest mismatch: {BitConverter.ToString(leaf.DataHash)} != {BitConverter.ToString(claimsDigest)}");
                }
            }
        }
    }
}
