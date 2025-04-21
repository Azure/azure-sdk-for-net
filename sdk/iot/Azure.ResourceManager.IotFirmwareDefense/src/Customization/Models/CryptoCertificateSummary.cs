// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Properties for cryptographic certificate summary. </summary>
    public partial class CryptoCertificateSummary : FirmwareAnalysisSummaryProperties
    {
        /// <summary> Total number of certificates found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? TotalCertificates => TotalCertificateCount;
        /// <summary> Total number of paired private keys found for the certificates. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? PairedKeys => PairedKeyCount;
        /// <summary> Total number of expired certificates found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? Expired => ExpiredCertificateCount;
        /// <summary> Total number of nearly expired certificates found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? ExpiringSoon => ExpiringSoonCertificateCount;
        /// <summary> Total number of certificates found using a weak signature algorithm. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? WeakSignature => WeakSignatureCount;
        /// <summary> Total number of certificates found that are self-signed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? SelfSigned => SelfSignedCertificateCount;
        /// <summary> Total number of certificates found that have an insecure key size for the key algorithm. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? ShortKeySize => ShortKeySizeCount;
    }
}
