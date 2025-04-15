// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
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
            get => Name;
            set{ return; }
        }

        ///// <summary> List of functions the certificate can fulfill. </summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public IList<string> Usage
        //{
        //    get => CertificateUsage;
        //    set{ return; }
        //}

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
            get
            {
                var r = new List<string>();
                foreach (var u in CertificateUsage)
                {
                    r.Add(u.ToString());
                }
                return r;
            }
            set
            {
                return;
            }
        }
    }
}
