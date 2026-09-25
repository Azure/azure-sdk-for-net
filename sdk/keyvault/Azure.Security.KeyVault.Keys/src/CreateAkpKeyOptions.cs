// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The properties needed to create an Algorithm Key Pair (AKP) key, such as ML-DSA, using the <see cref="KeyClient"/>.
    /// </summary>
    public class CreateAkpKeyOptions : CreateKeyOptions
    {
        /// <summary>
        /// Gets the name of the key to create.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the key type of the <see cref="JsonWebKey"/> to create, including <see cref="KeyType.Akp"/> and <see cref="KeyType.AkpHsm"/>.
        /// </summary>
        public KeyType KeyType { get; }

        /// <summary>
        /// Gets the algorithm identifier for the Algorithm Key Pair (AKP) key. See <see cref="AkpAlgorithm"/> for possible values.
        /// </summary>
        public AkpAlgorithm Algorithm { get; }

        /// <summary>
        /// Gets a value indicating whether to create a hardware-protected key in a hardware security module (HSM).
        /// </summary>
        /// <value><c>true</c> to create a hardware-protected key; otherwise, <c>false</c> to create a software key.</value>
        public bool HardwareProtected { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAkpKeyOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the key to create.</param>
        /// <param name="algorithm">The algorithm identifier for the Algorithm Key Pair (AKP) key. See <see cref="AkpAlgorithm"/> for possible values.</param>
        /// <param name="hardwareProtected">True to create a hardware-protected key in a hardware security module (HSM). The default is false to create a software key.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null, or <paramref name="algorithm"/> is not set.</exception>
        public CreateAkpKeyOptions(string name, AkpAlgorithm algorithm, bool hardwareProtected = false)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(algorithm.ToString(), nameof(algorithm));

            Name = name;
            Algorithm = algorithm;
            HardwareProtected = hardwareProtected;
            if (hardwareProtected)
            {
                KeyType = KeyType.AkpHsm;
            }
            else
            {
                KeyType = KeyType.Akp;
            }
        }
    }
}
