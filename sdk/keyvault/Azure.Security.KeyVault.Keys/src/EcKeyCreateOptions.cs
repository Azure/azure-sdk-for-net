// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represent the key specific attributes needed in order to create a EC key.
    /// </summary>
    public class EcKeyCreateOptions : KeyCreateOptions
    {
        /// <summary>
        /// Name of the key.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of key to create.
        /// </summary>
        public KeyType KeyType { get; private set; }

        /// <summary>
        /// Elliptic curve name. For valid values, see <see cref="KeyCurveName"/>. Possible values include: 'P-256', 'P-384',
        /// 'P-521', 'P-256K'.
        /// </summary>
        public KeyCurveName? Curve { get; set; }

        /// <summary>
        /// Whether it is a hardware key (HSM) or software key.
        /// </summary>
        public bool Hsm { get; private set; }

        /// <summary>
        /// Initializes a new instance of the EcKeyCreateOptions class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="hsm">Whether to import as a hardware key (HSM) or software key.</param>
        /// <param name="curveName">Elliptic curve name.</param>
        public EcKeyCreateOptions(string name, bool hsm, KeyCurveName? curveName = null)
        {
            Name = name;

            if(hsm)
            {
                KeyType = KeyType.EllipticCurveHsm;
            }
            else
            {
                KeyType = KeyType.EllipticCurve;
            }

            if (curveName.HasValue)
            {
                Curve = curveName.Value;
            }
        }
    }
}
