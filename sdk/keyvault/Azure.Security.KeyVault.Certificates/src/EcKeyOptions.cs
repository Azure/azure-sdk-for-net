// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Propeties of an EC (EllipticCurve) key backing a certificate
    /// </summary>
    public class EcKeyOptions : KeyOptions
    {
        private const string CurvePropertyName = "crv";
        private static readonly JsonEncodedText s_curvePropertyNameBytes = JsonEncodedText.Encode(CurvePropertyName);

        /// <summary>
        /// The curve which back the EC key
        /// </summary>
        public CertificateKeyCurveName? Curve { get; set; }

        /// <summary>
        /// Creates EcKeyOptions for use with a <see cref="CertificatePolicy"/>
        /// </summary>
        /// <param name="hsmProtected">Specifies whether the key should be protected in the HSM</param>
        public EcKeyOptions(bool hsmProtected)
            : base(hsmProtected ? CertificateKeyType.EllipticCurveHsm : CertificateKeyType.EllipticCurve)
        {
        }

        internal EcKeyOptions(CertificateKeyType keyType)
            : base(keyType)
        {
        }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case CurvePropertyName:
                    Curve = prop.Value.GetString();
                    break;

                default:
                    base.ReadProperty(prop);
                    break;
            }
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            base.WriteProperties(json);

            if (Curve.HasValue)
            {
                json.WriteString(s_curvePropertyNameBytes, Curve.ToString());
            }
        }
    }
}
