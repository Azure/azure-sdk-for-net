// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes parameters used for creation of a new cryptographic key.
    /// </summary>
    public class NewKeyParameters
    {
        /// <summary>
        /// Gets or sets the desired JsonWebKey key type. Possible values include: 'EC', 'EC-HSM', 'RSA', 'RSA-HSM', 'oct'
        /// </summary>
        public string Kty { get; set; }

        /// <summary>
        /// Gets or sets the name of desired curve for used with Elliptic Curve Cryptography (ECC) algorithms.
        /// </summary>
        public string CurveName { get; set; }

        /// <summary>
        /// Gets or sets the desired key size.
        /// </summary>
        public int? KeySize { get; set; }

        /// <summary>
        /// Gets or sets the desired operations that the key will support.
        /// </summary>
        public IList<string> KeyOps { get; set; }

        /// <summary>
        /// Gets or sets the desired key management attributes.
        /// </summary>
        public KeyAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets application specific metadata in the form of key-value pairs.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
    }
}