// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Crypto certificate resource. </summary>
    public partial class CryptoCertificateResult : ResourceData
    {
        /// <summary> Name of the certificate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NamePropertiesName
        {
            get => CertificateName;
            set => CertificateName = value;
        }

        /// <summary> Role of the certificate (Root CA, etc). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Role {
            get => CertificateRole;
            set => CertificateRole = value;
        }
        ///// <summary> The signature algorithm used in the certificate. </summary>
        //public string SignatureAlgorithm { get; set; }
        /// <summary> Size of the certificate's key in bits. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? KeySize {
            get => CertificateKeySize;
            set => CertificateKeySize = value;
        }
        /// <summary> Key algorithm used in the certificate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyAlgorithm {
            get => CertificateKeyAlgorithm;
            set => CertificateKeyAlgorithm = value;
        }

        /// <summary> List of functions the certificate can fulfill. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Usage
        {
            get => CertificateUsage.Select(u => u.ToString()).ToList();
            set
            {
                // CertificateUsage does not have a setter, there is nothing to do
                return;
            }
        }
    }
}
