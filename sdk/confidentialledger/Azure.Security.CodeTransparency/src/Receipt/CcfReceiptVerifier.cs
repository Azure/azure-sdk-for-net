// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Cose;
using System.Collections.Generic;

namespace Azure.Security.CodeTransparency.Receipt
{
    /// <summary>
    /// CcfReceiptVerifier class contains the methods to verify the CCF SCITT receipt
    /// integrity and the inclusion in the Code Transparency Service. The verification
    /// requires the receipt, the COSE_Sign1 envelope and the service certificate. The
    /// COSE_Sign1 envelope is the payload that was submitted to the Code Transparency
    /// Service. The receipt is a cryptographic proof issued by the Code Transparency
    /// Service after the successful submission of the signature. The service certificate
    /// is the public key of the Code Transparency Service that was used to endorse the
    /// receipt.
    /// The receipt can also be embedded in the COSE_Sign1 envelope.
    /// </summary>
    public class CcfReceiptVerifier
    {
        /// <summary>
        /// Verify the receipt integrity against the COSE_Sign1 envelope
        /// and check if receipt was endorsed by the service cert.
        /// In the case of receipts being embedded in the signature then verify
        /// all of them.
        /// Receipt is expected to have the DID issuer to get the certificate from.
        /// </summary>
        /// <param name="ccfReceiptOrCoseBytes">Receipt cbor or Cose_Sign1 (with an embedded receipt) bytes.</param>
        /// <param name="coseSign1Bytes">Cose_Sign1 cbor bytes.</param>
        /// <param name="didResolver">Optional custom DID resolver <see cref="DidWebReference" />.</param>
        public static void RunVerification(byte[] ccfReceiptOrCoseBytes, byte[] coseSign1Bytes = default, Func<DidWebReference, DidDocument> didResolver = null)
        {
            List<Exception> failures = new();
            List<CcfReceipt> receiptList = new();

            // if a second argument signature is not passed, it is expected
            // that the first argument will be the signature with the
            // embedded receipts
            if (coseSign1Bytes == null)
            {
                coseSign1Bytes = ccfReceiptOrCoseBytes;
                CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(ccfReceiptOrCoseBytes);
                // Embedded receipt bytes contain receipt under the map with key as 394 and the value as the receipt bytes
                byte[] receiptHeaderBytes = coseSign1Message.UnprotectedHeaders[new CoseHeaderLabel(CcfReceipt.COSE_HEADER_EMBEDDED_RECEIPTS)].EncodedValue.ToArray();

                receiptList.AddRange(CcfReceipt.DeserializeMany(receiptHeaderBytes));
            }
            else
            {
                // for a raw receipt
                receiptList.Add(CcfReceipt.Deserialize(ccfReceiptOrCoseBytes));
            }
            // Verify each receipt and keep success counter
            foreach (CcfReceipt receipt in receiptList)
            {
                try
                {
                    X509Certificate2 serviceCertificate = new DidWebReference(receipt).GetCert(didResolver);
                    receipt.VerifyReceipt(coseSign1Bytes, serviceCertificate);
                }
                catch (Exception e)
                {
                    failures.Add(e);
                }
            }
            if (failures.Count > 0)
            {
                throw new AggregateException(failures);
            }
        }

        /// <summary>
        /// Verify the receipt integrity against the COSE_Sign1 envelope
        /// and check if receipt was endorsed by the given service certificate.
        /// In the case of receipts being embedded in the signature then verify
        /// all of them.
        /// </summary>
        /// <param name="serviceCertificate">Service certificate which endorsed the receipt signature.</param>
        /// <param name="ccfReceiptOrCoseBytes">Receipt cbor or Cose_Sign1 (with an embedded receipt) bytes.</param>
        /// <param name="coseSign1Bytes">Cose_Sign1 cbor bytes.</param>
        public static void RunVerification(X509Certificate2 serviceCertificate, byte[] ccfReceiptOrCoseBytes, byte[] coseSign1Bytes = default)
        {
            List<Exception> failures = new();
            List<CcfReceipt> receiptList = new();

            // if a second argument signature is not passed, it is expected
            // that the first argument will be the signature with the
            // embedded receipts
            if (coseSign1Bytes == null)
            {
                coseSign1Bytes = ccfReceiptOrCoseBytes;
                CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(ccfReceiptOrCoseBytes);
                // Embedded receipt bytes contain receipt under the map with key as 394 and the value as the receipt bytes
                byte[] receiptHeaderBytes = coseSign1Message.UnprotectedHeaders[new CoseHeaderLabel(CcfReceipt.COSE_HEADER_EMBEDDED_RECEIPTS)].EncodedValue.ToArray();

                receiptList.AddRange(CcfReceipt.DeserializeMany(receiptHeaderBytes));
            }
            else
            {
                // for a raw receipt
                receiptList.Add(CcfReceipt.Deserialize(ccfReceiptOrCoseBytes));
            }
            // Verify each receipt and keep success counter
            foreach (CcfReceipt receipt in receiptList)
            {
                try
                {
                    receipt.VerifyReceipt(coseSign1Bytes, serviceCertificate);
                }
                catch (Exception e)
                {
                    failures.Add(e);
                }
            }
            if (failures.Count > 0)
            {
                throw new AggregateException(failures);
            }
        }
    }
}
