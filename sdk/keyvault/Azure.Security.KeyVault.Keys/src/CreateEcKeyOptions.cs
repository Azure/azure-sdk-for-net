// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The properties needed to create an Elliptic Curve key using the <see cref="KeyClient"/>.
    /// </summary>
    public class CreateEcKeyOptions : CreateKeyOptions
    {
        /// <summary>
        /// The name of the key to create.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Supported JsonWebKey key types (kty) based on the cryptographic algorithm used for the key.
        /// Possible values 'EC', 'EC-HSM.'
        /// </summary>
        public KeyType KeyType { get; }

        /// <summary>
        /// Elliptic curve name. For valid values, see <see cref="KeyCurveName"/>. Possible values include: 'P-256', 'P-384',
        /// 'P-521', 'P-256K'.
        /// </summary>
        public KeyCurveName? CurveName { get; set; }

        /// <summary>
        /// Determines whether or not a hardware-protected key (HSM) is used for creation.
        /// </summary>
        ///
        /// <value><c>true</c> to use a hardware-protected key; <c>false</c> to use a software key</value>
        public bool HardwareProtected { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEcKeyOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="hardwareProtected">True to create a hardware-protected (HSM) key. The default is false to create a software key.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public CreateEcKeyOptions(string name, bool hardwareProtected = false)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
            HardwareProtected = hardwareProtected;
            if (hardwareProtected)
            {
                KeyType = KeyType.EcHsm;
            }
            else
            {
                KeyType = KeyType.Ec;
            }
        }
    }
}
