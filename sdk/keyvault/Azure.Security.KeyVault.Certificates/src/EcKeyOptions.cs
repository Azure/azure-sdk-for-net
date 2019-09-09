// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class EcKeyOptions : KeyOptions
    {
        private const string CurvePropertyName = "crv";
        private static readonly JsonEncodedText CurvePropertyNameBytes = JsonEncodedText.Encode(CurvePropertyName);

        public KeyCurveName? Curve { get; set; }

        public EcKeyOptions(bool hsmProtected)
            : base(hsmProtected ? CertificateKeyType.EllipticCurveHsm : CertificateKeyType.EllipticCurve)
        {
        }

        internal EcKeyOptions(CertificateKeyType keyType)
            : base(keyType)
        {
        }

        internal override bool ReadProperty(JsonProperty prop)
        {
            if (!base.ReadProperty(prop) && string.CompareOrdinal(prop.Name, CurvePropertyName) == 0)
            {
                Curve = prop.Value.GetString();

                return true;
            }

            return false;
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            base.WriteProperties(json);

            if (Curve.HasValue)
            {
                json.WriteString(CurvePropertyNameBytes, Curve);
            }
        }
    }
}
