﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Gets the name of the key to create.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the key type of the <see cref="JsonWebKey"/> to create, including <see cref="KeyType.Ec"/> and <see cref="KeyType.EcHsm"/>.
        /// </summary>
        public KeyType KeyType { get; }

        /// <summary>
        /// Gets or sets the elliptic curve name. See <see cref="KeyCurveName"/> for possible values. If null, the service default is used.
        /// </summary>
        public KeyCurveName? CurveName { get; set; }

        /// <summary>
        /// Gets a value indicating whether to create a hardware-protected key in a hardware security module (HSM).
        /// </summary>
        /// <value><c>true</c> to create a hardware-protected key; otherwise, <c>false</c> to create a software key.</value>
        public bool HardwareProtected { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEcKeyOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the key to create.</param>
        /// <param name="hardwareProtected">True to create a hardware-protected key in a hardware security module (HSM). The default is false to create a software key.</param>
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
