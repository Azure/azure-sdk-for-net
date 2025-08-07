// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Properties for cryptographic key summary. </summary>
    public partial class CryptoKeySummary : FirmwareAnalysisSummaryProperties
    {
        /// <summary> Total number of cryptographic keys found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? TotalKeys => TotalKeyCount;
        /// <summary> Total number of (non-certificate) public keys found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? PublicKeys => PublicKeyCount;
        /// <summary> Total number of private keys found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? PrivateKeys => PrivateKeyCount;
        /// <summary> Total number of keys found that have a matching paired key or certificate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? PairedKeys => PairedKeyCount;
        /// <summary> Total number of keys found that have an insecure key size for the algorithm. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? ShortKeySize => ShortKeySizeCount;
    }
}
