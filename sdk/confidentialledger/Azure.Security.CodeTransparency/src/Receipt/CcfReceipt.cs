// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Formats.Cbor;

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
        public static readonly string SupportedTreeAlgorithm = "CCF";
        /// <summary>
        /// Key ID header key.
        /// </summary>
        public static readonly ulong ReceiptHeaderKeyId = 4;
        /// <summary>
        /// Issuer header key.
        /// </summary>
        public static readonly ulong ReceiptHeaderIssuer = 391;
        /// <summary>
        /// Header key to get access to the embedded receipts.
        /// </summary>
        public static readonly int CoseHeaderEmbeddedReceipts = 394;
        /// <summary>
        /// Service identifier header key.
        /// </summary>
        public static readonly string ReceiptHeaderServiceId = "service_id";
        /// <summary>
        /// Tree algorithm header id.
        /// </summary>
        public static readonly string ReceiptHeaderTreeAlgorithm = "tree_alg";
        /// <summary>
        /// Countersign time header key.
        /// </summary>
        public static readonly string ReceiptHeaderRegistrationTime = "registration_time";
        /// <summary>
        /// CWT ISS Claim (RFC9597) defined in https://www.iana.org/assignments/cwt/cwt.xhtml
        /// </summary>
        public static readonly int CoseReceiptCwtIssLabel = 1;
        /// <summary>
        /// CWT Map Claim (RFC9597) defined in https://www.iana.org/assignments/cwt/cwt.xhtml
        /// </summary>
        public static readonly int CoseReceiptCwtMapLabel = 15;
        /// <summary>
        /// Protected header key for verifiable proofs.
        /// </summary>
        public static readonly int CosePhdrVdpLabel = 396;
        /// <summary>
        /// Protected header key for the verifiable data structure,
        /// as per COSE Receipts (draft) RFC (https://datatracker.ietf.org/doc/draft-ietf-cose-merkle-tree-proofs/)
        /// </summary>
        public static readonly int CosePhdrVdsLabel = 395;
        /// <summary>
        /// Label for the inclusion proof.
        /// </summary>
        public static readonly int CoseReceiptInclusionProofLabel = -1;
        /// <summary>
        /// Label for the leaf in the inclusion proof
        /// </summary>
        public static readonly int CcfProofLeafLabel = 1;
        /// <summary>
        /// Label for the path in the inclusion proof
        /// </summary>
        public static readonly int CcfProofPathLabel = 2;
        /// <summary>
        /// Protected header key for the tree algorithm
        /// </summary>
        public static readonly int CcfTreeAlgLabel = 2;

        internal static Dictionary<int, byte[]> ReadCborMap(CborReader reader)
        {
            var map = new Dictionary<int, byte[]>();
            reader.ReadStartMap();
            while (reader.PeekState() != CborReaderState.EndMap)
            {
                var key = reader.ReadInt32();
                var value = reader.ReadEncodedValue().ToArray();
                map[key] = value;
            }
            reader.ReadEndMap();
            return map;
        }

        /// <summary>
        /// ProofElement is a representation of a tree node (left or right) in the ledger and its hash value.
        /// </summary>
        internal class ProofElement
        {
            /// <summary>
            /// If the element is on the left side.
            /// </summary>
            public bool Left { get; set; }
            /// <summary>
            /// Computed hash of the element.
            /// </summary>
            public byte[] Hash { get; set; }
        }

        /// <summary>
        /// Representation of the countersign structure in the ledger.
        /// </summary>
        internal class Leaf
        {
            /// <summary>
            /// Internal Transaction Hash value.
            /// </summary>
            public byte[] InternalTransactionHash { get; set; }
            /// <summary>
            /// Internal evidence value.
            /// </summary>
            public string InternalEvidence { get; set; }

            /// <summary>
            /// Internal Data Hash value.
            /// </summary>
            public byte[] DataHash { get; set; }
        }

        /// <summary>
        /// Deserialize the leaf content from cbor bytes.
        /// ccf-leaf = [
        ///   internal-transaction-hash: bstr.size 32
        ///   internal-evidence: tstr.size(1..1024)
        ///   data-hash: bstr.size 32 ]
        /// </summary>
        internal static Leaf GetLeaf(byte[] leafBytes)
        {
            CborReader reader = new(leafBytes);
            reader.ReadStartArray();

            Leaf leaf = new()
            {
                InternalTransactionHash = reader.ReadByteString(),
                InternalEvidence = reader.ReadTextString(),
                DataHash = reader.ReadByteString(),
            };
            reader.ReadEndArray();

            return leaf;
        }

        /// <summary>
        /// Deserialize a List of ProofElements from the inclusion proof path cbor bytes.
        /// ccf-proof-element = [
        ///      left: bool
        ///      hash: bstr.size 32 ]
        /// </summary>
        internal static List<ProofElement> GetProofElements(byte[] proofPaths)
        {
            List<ProofElement> proofElements = new List<ProofElement>();
            CborReader proofPathsReader = new CborReader(proofPaths);
            proofPathsReader.ReadStartArray();

            while (proofPathsReader.PeekState() != CborReaderState.EndArray)
            {
                proofPathsReader.ReadStartArray();
                while (proofPathsReader.PeekState() != CborReaderState.EndArray)
                {
                    proofElements.Add(new ProofElement
                    {
                        Left = proofPathsReader.ReadBoolean(),
                        Hash = proofPathsReader.ReadByteString()
                    });
                }
                proofPathsReader.ReadEndArray();
            }
            proofPathsReader.ReadEndArray();

            return proofElements;
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
