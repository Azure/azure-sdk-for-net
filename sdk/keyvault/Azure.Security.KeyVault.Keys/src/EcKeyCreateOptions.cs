// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represents the attributes to assign to an Elliptic Curve key at creation.
    /// </summary>
    public class EcKeyCreateOptions : KeyCreateOptions
    {
        /// <summary>
        /// The name of the key to create.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Supported JsonWebKey key types (kty) based on the cryptographic algorithm used for the key.
        /// Possible values 'EC', 'EC-HSM.'
        /// </summary>
        public JsonWebKeyType KeyType { get; private set; }

        /// <summary>
        /// Elliptic curve name. For valid values, see <see cref="JsonWebKeyCurveName"/>. Possible values include: 'P-256', 'P-384',
        /// 'P-521', 'P-256K'.
        /// </summary>
        public JsonWebKeyCurveName? Curve { get; set; }

        /// <summary> 
        /// Determines whether or not a hardware key (HSM) is used for creation.
        /// </summary>
        ///
        /// <value><c>true</c> to use a hardware key; <c>false</c> to use a software key</value>
        public bool Hsm { get; private set; }

        /// <summary>
        /// Initializes a new instance of the EcKeyCreateOptions class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="hsm">Whether to import as a hardware key (HSM) or software key.</param>
        /// <param name="curveName">Elliptic curve name.</param>
        public EcKeyCreateOptions(string name, bool hsm, JsonWebKeyCurveName? curveName = null)
        {
            Name = name;
            Hsm = hsm;
            if(hsm)
            {
                KeyType = JsonWebKeyType.EllipticCurveHsm;
            }
            else
            {
                KeyType = JsonWebKeyType.EllipticCurve;
            }

            if (curveName.HasValue)
            {
                Curve = curveName.Value;
            }
        }
    }
}
