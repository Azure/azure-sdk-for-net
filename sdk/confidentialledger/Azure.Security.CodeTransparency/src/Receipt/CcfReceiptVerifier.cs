// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Formats.Cbor;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Cose;
using System.Text;
using Azure.Core;
using static Azure.Security.CodeTransparency.Receipt.CcfReceipt;

namespace Azure.Security.CodeTransparency.Receipt
{
    /// <summary>
    /// CcfReceiptVerifier class contains the methods to verify the CCF SCITT receipt
    /// integrity and the inclusion in the Signing Transparency Service. The verification
    /// requires the receipt, the COSE_Sign1 envelope and the service certificate. The
    /// COSE_Sign1 envelope is the payload that was submitted to the Signing Transparency
    /// Service. The receipt is a cryptographic proof issued by the Signing Transparency
    /// Service after the successful submission of the signature. The service certificate
    /// is the public key of the Signing Transparency Service that was used to endorse the
    /// receipt.
    /// The receipt can also be embedded in the COSE_Sign1 envelope.
    /// </summary>
    public class CcfReceiptVerifier
    {
        /// <summary>
        /// SHA-256 hash function.
        /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/ section 9.2.2. Hash Algorithms.
        /// </summary>
        private static readonly SHA256 s_sha256 = SHA256.Create();

        /// <summary>
        /// Verify a CCF SCITT receipt.
        /// If the verification fails, an exception is thrown explaining in which step the verification failed.
        /// #1 Reference: https://datatracker.ietf.org/doc/draft-ietf-scitt-architecture/
        /// #2 Reference: https://datatracker.ietf.org/doc/draft-birkholz-cose-receipts-ccf-profile/
        /// </summary>
        /// <param name="jsonWebKey">The service certificate key (JWK).</param>
        /// <param name="receiptBytes">Receipt in COSE_Sign1 cbor bytes.</param>
        /// <param name="signedStatementBytes">The input signed statement bytes.</param>
        /// <exception cref="InvalidOperationException">Thrown when the verification fails.</exception>
        public static void VerifyTransparentStatementReceipt(JsonWebKey jsonWebKey, byte[] receiptBytes, byte[] signedStatementBytes)
        {
            byte[] claimsDigest = s_sha256.ComputeHash(signedStatementBytes);

            // Extract the expected KID from the public key used for verification,
            // and check it against the value set in the COSE header before using
            // it to verify the proofs.
            byte[] expectedKid = Encoding.UTF8.GetBytes(jsonWebKey.Kid);

            CoseSign1Message receipt = CoseMessage.DecodeSign1(receiptBytes);

            // Get Alg from ProtectedHeaders
            if (!receipt.ProtectedHeaders.TryGetValue(CoseHeaderLabel.Algorithm, out CoseHeaderValue alg))
            {
                throw new InvalidOperationException("Alg not found");
            }

            // Validate alg based on https://www.iana.org/assignments/cose/cose.xhtml#algorithms
            // Get the ECDsa key size from the certificate
            int algValue = alg.GetValueAsInt32();

            switch (jsonWebKey.Crv)
            {
                case "P-256":
                    if (algValue != -7)
                        throw new InvalidOperationException($"The ECDsa key uses the wrong algorithm. Expected -7 Found {algValue}");
                    break;
                case "P-384":
                    if (algValue != -35)
                        throw new InvalidOperationException($"The ECDsa key uses the wrong algorithm. Expected -35 Found {algValue}");
                    break;
                case "P-512":
                    if (algValue != -39)
                        throw new InvalidOperationException($"The ECDsa key uses the wrong algorithm. Expected -39 Found {algValue}");
                    break;
                default:
                    throw new InvalidOperationException("ECDsa key and Alg mismatch.");
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

            if (proofs == null || proofs.Length == 0)
            {
                throw new InvalidOperationException("At least one inclusion proof is required");
            }

            // InclusionProofs is an array of cbor bytestr
            List<byte[]> inclusionProofs = new List<byte[]>();
            CborReader proofsReader = new CborReader(proofs);
            proofsReader.ReadStartArray();
            while (proofsReader.PeekState() != CborReaderState.EndArray)
            {
                inclusionProofs.Add(proofsReader.ReadByteString());
            }
            proofsReader.ReadEndArray();

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

                byte[] accumulator = s_sha256.ComputeHash(
                    CombineByteArrays(
                        leaf.InternalTransactionHash,
                        s_sha256.ComputeHash(Encoding.UTF8.GetBytes(leaf.InternalEvidence)),
                        leaf.DataHash));

                foreach (ProofElement proofElement in proofElements)
                {
                    if (proofElement.Left)
                    {
                        accumulator = s_sha256.ComputeHash(CombineByteArrays(proofElement.Hash, accumulator));
                    }
                    else
                    {
                        accumulator = s_sha256.ComputeHash(CombineByteArrays(accumulator, proofElement.Hash));
                    }
                }

                // We are mapping our JWK with AKV JWK in order to leverage the already established
                // ECDsa conversion given a JWK.
                KeyVault.Keys.JsonWebKey tmpAkvKey = new KeyVault.Keys.JsonWebKey(null)
                {
                    CurveName = jsonWebKey.Crv,
                    X = Base64Url.Decode(jsonWebKey.X),
                    Y = Base64Url.Decode(jsonWebKey.Y),
                    Id = jsonWebKey.Kid,
                    KeyType = jsonWebKey.Kty
                };

                using ECDsa ecdsaKey = tmpAkvKey.ToECDsa(false);

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
