// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Formats.Cbor;
using System.Security.Cryptography.Cose;
using System.Collections.Generic;

// cspell:ignore bstr
namespace Azure.Security.CodeTransparency.Receipt
{
    /// <summary>
    /// CcfReceipt class which enables encoding, decoding and verification of receipts issued from the Code Transparency Service.
    /// This class encapsulates the representation and the available operations of CBOR encoded CCF SCITT receipts.
    /// This is a reference implementation for a proposed draft IETF specification: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ .
    /// </summary>
    public class CcfReceipt
    {
        /// <summary>
        /// Expected tree algorithm value in the receipt.
        /// </summary>
        public const string SUPPORTED_TREE_ALGORITHM = "CCF";
        /// <summary>
        /// Key ID header key.
        /// </summary>
        public const ulong RECEIPT_HEADER_KEY_ID = 4;
        /// <summary>
        /// Issuer header key.
        /// </summary>
        public const ulong RECEIPT_HEADER_ISSUER = 391;
        /// <summary>
        /// Header key to get access to the embedded receipts.
        /// </summary>
        public const int COSE_HEADER_EMBEDDED_RECEIPTS = 394;
        /// <summary>
        /// Service identifier header key.
        /// </summary>
        public const string RECEIPT_HEADER_SERVICE_ID = "service_id";
        /// <summary>
        /// Tree algorithm header id.
        /// </summary>
        public const string RECEIPT_HEADER_TREE_ALGORITHM = "tree_alg";
        /// <summary>
        /// Countersign time header key.
        /// </summary>
        public const string RECEIPT_HEADER_REGISTRATION_TIME = "registration_time";
        /// <summary>
        /// SHA-256 hash function.
        /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/ section 9.2.2. Hash Algorithms.
        /// </summary>
        private static readonly SHA256 s_sha256 = SHA256.Create();

        /// <summary>
        /// Not yet decoded SignProtected structure, also referred to as protected headers.
        /// </summary>
        /// <seealso cref="SignProtected"/>
        public byte[] SignProtectedRaw { get; set; }

        /// <summary>
        /// ReceiptContents contains inclusion proof of the registration in the service and the signature.
        /// </summary>
        public ReceiptContents Contents { get; set; }

        /// <summary>
        /// Decode CBOR receipt bytes into CcfReceipt.
        /// </summary>
        /// <param name="cbor">Receipt bytes.</param>
        /// <returns>CcfReceipt object.</returns>
        /// <exception cref="Exception"></exception>
        public static CcfReceipt Deserialize(byte[] cbor)
        {
            try
            {
                CborReader reader = new(cbor);
                return Deserialize(reader);
            }
            catch (Exception ex)
            {
                throw new Exception($"Deserialize: Failed to parse Plain Receipt object. Message: {{{ex.Message}}}.");
            }
        }

        /// <summary>
        /// Decode CBOR receipt bytes into CcfReceipt.
        /// </summary>
        /// <param name="reader">CborReader.</param>
        /// <returns>CcfReceipt object.</returns>
        /// <exception cref="Exception"></exception>
        public static CcfReceipt Deserialize(CborReader reader)
        {
            try
            {
                CcfReceipt receiptData = new();
                ReceiptContents receiptContents = new();
                List<ProofElement> proofElements = new();
                LeafInfo leafInfo = new();

                reader.ReadStartArray();

                receiptData.SignProtectedRaw = reader.ReadByteString();
                reader.ReadStartArray();
                receiptContents.Signature = reader.ReadByteString();
                receiptContents.NodeCertificate = reader.ReadByteString();
                reader.ReadStartArray();
                reader.ReadStartArray();
                while (reader.PeekState() == CborReaderState.Boolean)
                {
                    ProofElement proofElement = new()
                    {
                        Left = reader.ReadBoolean(),
                        Hash = reader.ReadByteString()
                    };
                    proofElements.Add(proofElement);
                    reader.ReadEndArray();
                    if (reader.PeekState() == CborReaderState.EndArray)
                        break;
                    else
                        reader.ReadStartArray();
                }
                reader.ReadEndArray();
                reader.ReadStartArray();
                leafInfo.InternalHash = reader.ReadByteString();
                leafInfo.InternalData = reader.ReadByteString();
                reader.ReadEndArray();
                reader.ReadEndArray();
                reader.ReadEndArray();

                receiptContents.ProofElements = proofElements;
                receiptContents.LeafInfo = leafInfo;
                receiptData.Contents = receiptContents;
                return receiptData;
            }
            catch (Exception ex)
            {
                throw new Exception($"Deserialize: Failed to get receipt model. Message: {{{ex.Message}}}.");
            }
        }

        /// <summary>
        /// Decodes COSE_Sign1 unprotected header value that contains an array of receipts.
        /// </summary>
        /// <param name="cbor">receipts encoded into CBOR array.</param>
        /// <returns>List of CcfReceipt.</returns>
        /// <exception cref="Exception"></exception>
        public static List<CcfReceipt> DeserializeMany(byte[] cbor)
        {
            try
            {
                List<CcfReceipt> receiptList = new();
                CborReader reader = new(cbor);
                reader.ReadStartArray();
                while (reader.PeekState() == CborReaderState.StartArray)
                {
                    receiptList.Add(Deserialize(reader));
                }
                reader.ReadEndArray();
                return receiptList;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeserializeMany: Failed to parse receipts bytes. Message: {{{ex.Message}}}.");
            }
        }

        /// <summary>
        /// Decodes the protected headers.
        /// </summary>
        /// <returns>SignProtected headers.</returns>
        public SignProtected GetSignProtected()
        {
            return SignProtected.Deserialize(SignProtectedRaw);
        }

        /// <summary>
        /// Verify CCF SCITT receipt.
        /// </summary>
        /// <param name="coseSign1Bytes">COSE_Sign1 cbor bytes.</param>
        /// <param name="serviceCert">Service certificate that endorsed the receipt issuer.</param>
        public void VerifyReceipt(byte[] coseSign1Bytes, X509Certificate2 serviceCert)
        {
            CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(coseSign1Bytes);
            SignProtected signProtected = GetSignProtected();
            if (signProtected.TreeAlg != SUPPORTED_TREE_ALGORITHM)
                throw new ArgumentException("VerifyReceipt: unsupported tree algorithm");

            byte[] signedRootHash = RecomputeSignedRootHash(coseSign1Message);
            if (!VerifySignature(signedRootHash, serviceCert, signProtected))
            {
                throw new ArgumentException("VerifyReceipt: signature invalid");
            }
        }

        /// <summary>
        /// Recompute the signed root hash using the COSE_Sign1 envelope and receipt contents.
        /// </summary>
        /// <param name="coseSign1Message">CoseSign1Message message object.</param>
        /// <returns>Computed root hash byte array.</returns>
        protected byte[] RecomputeSignedRootHash(CoseSign1Message coseSign1Message)
        {
            byte[] leafBytes = ComputeLeaf(coseSign1Message);
            byte[] leafHash = s_sha256.ComputeHash(leafBytes);
            return Contents.ComputeRootHash(leafHash);
        }

        /// <summary>
        /// Compute leaf value with the help of CounterSignStruct bytes.
        /// </summary>
        /// <param name="coseSign1Message">CoseSign1Message message object</param>
        /// <returns>Computed leaf bytes.</returns>
        /// <exception cref="Exception"></exception>
        protected byte[] ComputeLeaf(CoseSign1Message coseSign1Message)
        {
            byte[] countersignCbor;
            try
            {
                countersignCbor = CounterSignStruct.Build(this, coseSign1Message).Serialize();
            }
            catch (Exception)
            {
                throw new Exception("ComputeLeaf: could not marshal countersign into cbor");
            }
            byte[] countersignCborHash = s_sha256.ComputeHash(countersignCbor);
            return Contents.LeafInfo.LeafBytes(countersignCborHash);
        }

        /// <summary>
        /// VerifySignature checks the integrity of the receipt signature against the parsed node certificate.
        /// Node certificate is also verified against the service certificate.
        /// This function is a simplified version of x509.Certificate.CheckSignature but without the forced hashing of the data as it is already hashed.
        /// </summary>
        /// <param name="signedRootHash">Computed signedRootHash byte array.</param>
        /// <param name="serviceCert">Service certificate.</param>
        /// <param name="signProtected">SignProtected object.</param>
        /// <returns>Success/Failure as bool value.</returns>
        protected bool VerifySignature(byte[] signedRootHash, X509Certificate2 serviceCert, SignProtected signProtected)
        {
            bool verifyHash = false;
            X509Certificate2 receiptNodeCert = ParseAndVerifyNodeCert(serviceCert, signProtected);

            using (ECDsa ecdsa = receiptNodeCert.GetECDsaPublicKey())
            {
                if (ecdsa != null)
                {
                    // Verify IEEE encoding format signature with signed root hash
                    verifyHash = ecdsa.VerifyHash(signedRootHash, Contents.Signature);
                }
            }
            return verifyHash;
        }

        /// <summary>
        /// Get the node certificate from the receipt and verify it against the service certificate before returning.
        /// </summary>
        /// <param name="serviceCert">Service certificate</param>
        /// <param name="signProtected">SignProtected object</param>
        /// <returns>Verified node certificate.</returns>
        /// <exception cref="Exception"></exception>
        protected X509Certificate2 ParseAndVerifyNodeCert(X509Certificate2 serviceCert, SignProtected signProtected)
        {
            X509Certificate2 nodeCert = new(Contents.NodeCertificate);

            bool verifyCertChain = VerifyReceiptCertificateChain(nodeCert, serviceCert, signProtected);
            if (!verifyCertChain)
                throw new Exception("VerifyReceiptCertificateChain: Certificate chain verification failed.");

            return nodeCert;
        }

        /// <summary>
        /// ReceiptContents contains the inclusion proof.
        /// </summary>
        public class ReceiptContents
        {
            /// <summary>
            /// Ledger issued signature over its root.
            /// </summary>
            public byte[] Signature { get; set; }
            /// <summary>
            /// Identity of the public key to validate the receipt signature.
            /// </summary>
            public byte[] NodeCertificate { get; set; }
            /// <summary>
            /// Path of tree elements leading to the leaf.
            /// </summary>
            public List<ProofElement> ProofElements { get; set; }
            /// <summary>
            /// Leaf element.
            /// </summary>
            public LeafInfo LeafInfo { get; set; }

            /// <summary>
            /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ section 6.2.2.1.  Verifying an Inclusion Proof
            /// </summary>
            /// <param name="leafHash">Computed leaf hash bytes.</param>
            /// <returns>Computed byte array.</returns>
            public byte[] ComputeRootHash(byte[] leafHash)
            {
                byte[] hash = leafHash;
                foreach (ProofElement proofElement in ProofElements)
                    if ((bool)proofElement.Left)
                        hash = s_sha256.ComputeHash(CombineByteArrays(proofElement.Hash, hash));
                    else
                        hash = s_sha256.ComputeHash(CombineByteArrays(hash, proofElement.Hash));
                return hash;
            }
        }

        /// <summary>
        /// ProofElement is a representation of a tree node (left or right) in the ledger and its hash value.
        /// </summary>
        public class ProofElement
        {
            /// <summary>
            /// If the element is on the left side.
            /// </summary>
            public bool? Left { get; set; }
            /// <summary>
            /// Computed hash of the element.
            /// </summary>
            public byte[] Hash { get; set; }
        }

        /// <summary>
        /// Representation of the countersign structure in the ledger.
        /// </summary>
        public class LeafInfo
        {
            /// <summary>
            /// Internal hash value.
            /// </summary>
            public byte[] InternalHash { get; set; }
            /// <summary>
            /// Internal data value.
            /// </summary>
            public byte[] InternalData { get; set; }

            /// <summary>
            /// DataHash is either the HASH of the CBOR-encoded
            /// Countersign_structure of the signed envelope, using the CBOR
            /// encoding described in Section 6, or a bytestring of size HASH_SIZE
            /// filled with zeroes for auxiliary ledger entries.
            /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ section 5.3. Encoding Signed Envelopes into Tree Leaves.
            /// </summary>
            /// <param name="dataHash">Computed dataHash byte array.</param>
            /// <returns>Leaf byte array.</returns>
            /// <exception cref="Exception"></exception>
            public byte[] LeafBytes(byte[] dataHash)
            {
                int sha256Size = s_sha256.HashSize / 8;
                if (InternalHash.Length != sha256Size)
                    throw new Exception("LeafBytes: invalid InternalHash size");
                if (dataHash.Length != sha256Size)
                    throw new Exception("LeafBytes: invalid dataHash size");
                if (InternalData.Length > 1024)
                    throw new Exception("LeafBytes: internal data too long");

                return CombineByteArrays(InternalHash, s_sha256.ComputeHash(InternalData), dataHash);
            }
        }

        /// <summary>
        /// SignProtected is also called protected headers or just protected in other specifications.
        /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ section 4.1  Countersigner Header Parameters.
        /// </summary>
        public class SignProtected
        {
            /// <summary>
            /// Stable ledger id.
            /// </summary>
            public string ServiceId { get; set; }
            /// <summary>
            /// The algorithm used, we support only CCF.
            /// </summary>
            public string TreeAlg { get; set; }
            /// <summary>
            /// Identifier to select the key from the list of available ones.
            /// </summary>
            public string KeyId { get; set; }
            /// <summary>
            /// DID issuer string.
            /// </summary>
            public string Issuer { get; set; }
            /// <summary>
            /// Time of the receipt issue.
            /// </summary>
            public ulong SignedAt { get; set; }

            /// <summary>
            /// Decode COSE_Sign1 protected headers.
            /// </summary>
            /// <param name="signProtectedBytes">COSE_Sign1 protected header bytes.</param>
            /// <returns>SignProtected object.</returns>
            /// <exception cref="Exception"></exception>
            public static SignProtected Deserialize(byte[] signProtectedBytes)
            {
                try
                {
                    SignProtected signProtected = new();
                    CborReader reader = new(signProtectedBytes);
                    reader.ReadStartMap();
                    while (reader.PeekState() != CborReaderState.EndMap)
                    {
                        if (reader.PeekState() == CborReaderState.UnsignedInteger)
                        {
                            ulong key = reader.ReadUInt64();
                            if (key == RECEIPT_HEADER_KEY_ID)
                                signProtected.KeyId = reader.PeekState() == CborReaderState.ByteString ? Encoding.Default.GetString(reader.ReadByteString()) : reader.ReadTextString();
                            else if (key == RECEIPT_HEADER_ISSUER)
                                signProtected.Issuer = reader.ReadTextString();
                        }
                        else
                            switch (reader.ReadTextString())
                            {
                                case RECEIPT_HEADER_SERVICE_ID: signProtected.ServiceId = reader.ReadTextString(); break;
                                case RECEIPT_HEADER_TREE_ALGORITHM: signProtected.TreeAlg = reader.ReadTextString(); break;
                                case RECEIPT_HEADER_REGISTRATION_TIME: signProtected.SignedAt = reader.ReadUInt64(); break;
                            }
                    }
                    reader.ReadEndMap();
                    return signProtected;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Deserialize: Failed to parse SignProtected object. Message: {{{ex.Message}}}.");
                }
            }
        }

        /// <summary>
        /// Definition of a CounterSignStruct object
        /// Countersign_structure = [
        ///	  context: "CounterSignatureV2",
        ///	  body_protected: empty_or_serialized_map,
        ///	  sign_protected: empty_or_serialized_map,
        ///	  external_aad: bstr,
        ///	  payload: bstr,
        ///	  other_fields: [
        ///		signature: bstr
        ///	  ]
        /// ]
        /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ section 4. COSE_Sign1 Countersigning.
        /// </summary>
        public class CounterSignStruct
        {
            /// <summary>
            /// String representation of the type of countersignature.
            /// </summary>
            public string Context { get; set; }
            /// <summary>
            /// Protected headers from the COSE_Sign1 envelope.
            /// </summary>
            public byte[] BodyProtected { get; set; }
            /// <summary>
            /// Protected headers from the receipt.
            /// </summary>
            public byte[] SignProtected { get; set; }
            /// <summary>
            /// Empty additional data as mentioned in the specification.
            /// </summary>
            public readonly byte[] ExternalAad = new byte[] { };
            /// <summary>
            /// Payload from COSE_Sign1 envelope.
            /// </summary>
            public byte[] Payload { get; set; }
            /// <summary>
            /// Additional fields where the receipt signature is added.
            /// </summary>
            public OtherCounterSignFields OtherFields { get; set; }

            /// <summary>
            /// Serialize to CBOR.
            /// </summary>
            /// <returns>CBOR bytes.</returns>
            public byte[] Serialize()
            {
                CborWriter writer = new(CborConformanceMode.Strict);
                writer.WriteStartArray(6);
                writer.WriteTextString(Context);
                writer.WriteByteString(BodyProtected);
                writer.WriteByteString(SignProtected);
                writer.WriteByteString(ExternalAad);
                writer.WriteByteString(Payload);
                writer.WriteStartArray(1);
                writer.WriteByteString(OtherFields.Signature);
                writer.WriteEndArray();
                writer.WriteEndArray();
                return writer.Encode();
            }

            /// <summary>
            /// Build CounterSignStruct used as a source for the countersignature.
            /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ section 4. COSE_Sign1 Countersigning
            /// </summary>
            /// <param name="receipt">Receipt object.</param>
            /// <param name="coseSign1Message">CoseSign1Message object.</param>
            /// <returns>CounterSignStruct object.</returns>
            public static CounterSignStruct Build(CcfReceipt receipt, CoseSign1Message coseSign1Message)
            {
                return new()
                {
                    Context = "CounterSignatureV2",
                    BodyProtected = coseSign1Message.RawProtectedHeaders.ToArray(),
                    SignProtected = receipt.SignProtectedRaw,
                    Payload = coseSign1Message.Content.Value.ToArray(),
                    OtherFields = new OtherCounterSignFields { Signature = coseSign1Message.Signature.ToArray() }
                };
            }
        }

        /// <summary>
        /// Contains the original signature copied from the COSE_Sign1 envelope.
        /// </summary>
        public class OtherCounterSignFields
        {
            /// <summary>
            /// COSE_Sign1 signature bytes.
            /// </summary>
            public byte[] Signature { get; set; }
        }

        /// <summary>
        /// Verify the certificate chain established by the node certificate embedded in the receipt and the fixed service certificate in the service parameters.
        /// Reference: https://datatracker.ietf.org/doc/draft-birkholz-scitt-receipts/03/ section 6.5.5  Verifying certificate chain.
        /// </summary>
        /// <param name="nodeCert">Node certificate.</param>
        /// <param name="parentCert">Service certificate.</param>
        /// <param name="signProtected">SignProtected object.</param>
        /// <returns>Bool value based on cert chain verification.</returns>
        /// <exception cref="Exception"></exception>
        internal static bool VerifyReceiptCertificateChain(X509Certificate2 nodeCert, X509Certificate2 parentCert, SignProtected signProtected)
        {
            X509Chain chain = new();
            chain.ChainPolicy.ExtraStore.Add(parentCert);

            // Add policies for cert chain
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            // Verification of cert validity for the IssueAt date time
            chain.ChainPolicy.VerificationTime = DateTimeOffset.FromUnixTimeSeconds(unchecked((long)signProtected.SignedAt)).UtcDateTime;

            // Build chain to do the preliminary validation.
            if (!chain.Build(nodeCert))
            {
                StringBuilder message = new("VerifyReceiptCertificateChain: Certificate chain verification failed. Reason: ");
                for (int i = 0, j = 1; i < chain.ChainStatus.Length; i++)
                {
                    if (chain.ChainStatus[i].Status == X509ChainStatusFlags.UntrustedRoot)
                        continue;
                    message.Append(j++.ToString()).Append(". ").Append(chain.ChainStatus[i].StatusInformation).Append(". ");
                }
                throw new Exception("VerifyReceiptCertificateChain: Certificate chain verification failed. Reason: " + message.ToString());
            }

            // Make sure we have the same number of elements.
            if (chain.ChainElements.Count != chain.ChainPolicy.ExtraStore.Count + 1)
                return false;

            // Make sure all the thumbprints of the CAs match up.
            // The first one should be 'nodeCert', leading up to the root CA.
            for (int i = 1; i < chain.ChainElements.Count; i++)
            {
                if (chain.ChainElements[i].Certificate.Thumbprint != chain.ChainPolicy.ExtraStore[i - 1].Thumbprint)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Merge two byte arrays.
        /// </summary>
        /// <param name="first">First byte array.</param>
        /// <param name="second">Second byte array.</param>
        /// <returns>Merged byte array.</returns>
        internal static byte[] CombineByteArrays(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        /// <summary>
        /// Get the subset array from the input array based on startIndex and length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array from which subset array needed</param>
        /// <param name="startIndex">Start index for the subset array</param>
        /// <param name="length">Length of the subset array from startIndex</param>
        /// <returns>Subset of array.</returns>
        internal static T[] RangeSubset<T>(T[] array, int startIndex, int length)
        {
            T[] subset = new T[length];
            Array.Copy(array, startIndex, subset, 0, length);
            return subset;
        }

        /// <summary>
        /// Merge three byte arrays.
        /// </summary>
        /// <param name="first">First byte array.</param>
        /// <param name="second">Second byte array.</param>
        /// <param name="third">Third byte array.</param>
        /// <returns>Merged byte array.</returns>
        internal static byte[] CombineByteArrays(byte[] first, byte[] second, byte[] third)
        {
            byte[] ret = new byte[first.Length + second.Length + third.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            Buffer.BlockCopy(third, 0, ret, first.Length + second.Length, third.Length);
            return ret;
        }
    }
}
