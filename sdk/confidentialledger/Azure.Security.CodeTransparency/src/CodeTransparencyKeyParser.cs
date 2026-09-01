// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Formats.Cbor;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Normalizes the two service key encodings - the JSON JWK Set returned by <c>/jwks</c> and the CBOR
    /// COSE_Key / COSE_Key_Set returned by <c>/.well-known/scitt-keys</c> - into the SDK's public
    /// <see cref="CodeTransparencyVerificationKey"/> and <see cref="CodeTransparencyVerificationKeySet"/> types.
    /// </summary>
    internal static class CodeTransparencyKeyParser
    {
        // COSE_Key map labels, see RFC 9052 (COSE) and RFC 9053.
        private const int CoseKeyLabelKty = 1;
        private const int CoseKeyLabelKid = 2;
        private const int CoseKeyLabelCrv = -1;
        private const int CoseKeyLabelX = -2;
        private const int CoseKeyLabelY = -3;
        private const int CoseKeyLabelD = -4;

        // COSE key type (kty) value for a two-coordinate elliptic curve key.
        private const int CoseKeyTypeEc2 = 2;

        // COSE elliptic curve identifiers, see https://www.iana.org/assignments/cose/cose.xhtml#elliptic-curves
        private const int CoseCurveP256 = 1;
        private const int CoseCurveP384 = 2;
        private const int CoseCurveP521 = 3;

        /// <summary>Parses a JWK Set JSON document (the <c>/jwks</c> response body).</summary>
        public static CodeTransparencyVerificationKeySet ParseJwksJson(ReadOnlySpan<byte> json)
        {
            using JsonDocument document = JsonDocument.Parse(json.ToArray());
            JsonElement root = document.RootElement;

            if (root.ValueKind != JsonValueKind.Object || !root.TryGetProperty("keys", out JsonElement keysElement) ||
                keysElement.ValueKind != JsonValueKind.Array)
            {
                throw new FormatException("The JWK Set response is missing a 'keys' array.");
            }

            var keys = new List<CodeTransparencyVerificationKey>();
            foreach (JsonElement keyElement in keysElement.EnumerateArray())
            {
                keys.Add(ParseJwk(keyElement));
            }

            return new CodeTransparencyVerificationKeySet(keys);
        }

        private static CodeTransparencyVerificationKey ParseJwk(JsonElement jwk)
        {
            if (jwk.ValueKind != JsonValueKind.Object)
            {
                throw new FormatException("A JWK entry is not a JSON object.");
            }

            // Reject any private/symmetric material even though the public contract should not include it.
            foreach (string privateMember in new[] { "d", "dp", "dq", "k", "p", "q", "qi" })
            {
                if (jwk.TryGetProperty(privateMember, out _))
                {
                    throw new FormatException("A JWK entry contains private or symmetric key material, which is not allowed for a verification key.");
                }
            }

            string kty = GetRequiredString(jwk, "kty");
            if (!string.Equals(kty, "EC", StringComparison.Ordinal))
            {
                throw new NotSupportedException($"Unsupported JWK key type '{kty}'. Only 'EC' is supported.");
            }

            string kid = GetRequiredString(jwk, "kid");
            string crv = GetRequiredString(jwk, "crv");
            (ECCurve curve, int fieldSize) = MapJwkCurve(crv);

            byte[] x = NormalizeCoordinate(DecodeBase64Url(jwk, "x"), fieldSize, kid);
            byte[] y = NormalizeCoordinate(DecodeBase64Url(jwk, "y"), fieldSize, kid);

            return CodeTransparencyVerificationKey.FromPublicPoint(kid, curve, x, y);
        }

        /// <summary>Parses a COSE_Key_Set (CBOR array of COSE_Key maps).</summary>
        public static CodeTransparencyVerificationKeySet ParseCoseKeySet(ReadOnlyMemory<byte> cbor)
        {
            var reader = new CborReader(cbor);
            var keys = new List<CodeTransparencyVerificationKey>();

            try
            {
                reader.ReadStartArray();
                while (reader.PeekState() != CborReaderState.EndArray)
                {
                    keys.Add(ReadCoseKey(reader));
                }
                reader.ReadEndArray();
            }
            catch (CborContentException ex)
            {
                throw new FormatException("The COSE_Key_Set response is not valid CBOR.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new FormatException("The COSE_Key_Set response is not a valid COSE_Key_Set.", ex);
            }

            return new CodeTransparencyVerificationKeySet(keys);
        }

        /// <summary>Parses a single COSE_Key (CBOR map).</summary>
        public static CodeTransparencyVerificationKey ParseCoseKey(ReadOnlyMemory<byte> cbor)
        {
            var reader = new CborReader(cbor);
            try
            {
                return ReadCoseKey(reader);
            }
            catch (CborContentException ex)
            {
                throw new FormatException("The COSE_Key response is not valid CBOR.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new FormatException("The COSE_Key response is not a valid COSE_Key.", ex);
            }
        }

        private static CodeTransparencyVerificationKey ReadCoseKey(CborReader reader)
        {
            reader.ReadStartMap();

            int? kty = null;
            int? crv = null;
            byte[] kidBytes = null;
            byte[] x = null;
            byte[] y = null;
            bool hasPrivateKey = false;

            while (reader.PeekState() != CborReaderState.EndMap)
            {
                CborReaderState labelState = reader.PeekState();
                if (labelState != CborReaderState.UnsignedInteger && labelState != CborReaderState.NegativeInteger)
                {
                    // COSE also permits text-string labels; skip any label the SDK does not understand.
                    reader.SkipValue();
                    reader.SkipValue();
                    continue;
                }

                int label = reader.ReadInt32();
                switch (label)
                {
                    case CoseKeyLabelKty:
                        kty = reader.ReadInt32();
                        break;
                    case CoseKeyLabelKid:
                        kidBytes = reader.ReadByteString();
                        break;
                    case CoseKeyLabelCrv:
                        crv = reader.ReadInt32();
                        break;
                    case CoseKeyLabelX:
                        x = reader.ReadByteString();
                        break;
                    case CoseKeyLabelY:
                        // For EC2 keys 'y' may be a full coordinate byte string or a boolean sign bit (compressed).
                        if (reader.PeekState() == CborReaderState.Boolean)
                        {
                            reader.ReadBoolean();
                            throw new NotSupportedException("Compressed COSE_Key EC points are not supported.");
                        }
                        y = reader.ReadByteString();
                        break;
                    case CoseKeyLabelD:
                        hasPrivateKey = true;
                        reader.SkipValue();
                        break;
                    default:
                        reader.SkipValue();
                        break;
                }
            }

            reader.ReadEndMap();

            if (hasPrivateKey)
            {
                throw new FormatException("A COSE_Key contains private key material, which is not allowed for a verification key.");
            }
            if (kty != CoseKeyTypeEc2)
            {
                throw new NotSupportedException($"Unsupported COSE_Key type '{kty}'. Only EC2 (2) is supported.");
            }
            if (kidBytes == null || kidBytes.Length == 0)
            {
                throw new FormatException("A COSE_Key is missing its key ID (label 2).");
            }
            if (crv == null)
            {
                throw new FormatException("A COSE_Key is missing its curve (label -1).");
            }
            if (x == null || y == null)
            {
                throw new FormatException("A COSE_Key is missing an EC coordinate.");
            }

            // The service uses textual UTF-8 key IDs.
            string kid = Encoding.UTF8.GetString(kidBytes);
            (ECCurve curve, int fieldSize) = MapCoseCurve(crv.Value);

            return CodeTransparencyVerificationKey.FromPublicPoint(
                kid,
                curve,
                NormalizeCoordinate(x, fieldSize, kid),
                NormalizeCoordinate(y, fieldSize, kid));
        }

        private static (ECCurve Curve, int FieldSize) MapJwkCurve(string curveName)
        {
            return curveName switch
            {
                "P-256" => (ECCurve.NamedCurves.nistP256, 32),
                "P-384" => (ECCurve.NamedCurves.nistP384, 48),
                "P-521" => (ECCurve.NamedCurves.nistP521, 66),
                _ => throw new NotSupportedException($"Unsupported JWK curve '{curveName}'. Only P-256, P-384, and P-521 are supported."),
            };
        }

        private static (ECCurve Curve, int FieldSize) MapCoseCurve(int curve)
        {
            return curve switch
            {
                CoseCurveP256 => (ECCurve.NamedCurves.nistP256, 32),
                CoseCurveP384 => (ECCurve.NamedCurves.nistP384, 48),
                CoseCurveP521 => (ECCurve.NamedCurves.nistP521, 66),
                _ => throw new NotSupportedException($"Unsupported COSE curve '{curve}'. Only P-256 (1), P-384 (2), and P-521 (3) are supported."),
            };
        }

        private static string GetRequiredString(JsonElement element, string propertyName)
        {
            if (!element.TryGetProperty(propertyName, out JsonElement value) || value.ValueKind != JsonValueKind.String)
            {
                throw new FormatException($"A JWK entry is missing the required '{propertyName}' member.");
            }

            string result = value.GetString();
            if (string.IsNullOrEmpty(result))
            {
                throw new FormatException($"A JWK entry has an empty '{propertyName}' member.");
            }

            return result;
        }

        private static byte[] DecodeBase64Url(JsonElement jwk, string propertyName)
        {
            string encoded = GetRequiredString(jwk, propertyName);
            try
            {
                return Base64Url.Decode(encoded);
            }
            catch (FormatException ex)
            {
                throw new FormatException($"The JWK '{propertyName}' member is not valid base64url.", ex);
            }
        }

        private static byte[] NormalizeCoordinate(byte[] coordinate, int fieldSize, string keyId)
        {
            if (coordinate == null || coordinate.Length == 0)
            {
                throw new FormatException($"The public key coordinates for key '{keyId}' are malformed.");
            }
            if (coordinate.Length == fieldSize)
            {
                return coordinate;
            }
            if (coordinate.Length < fieldSize)
            {
                // Left-pad shorter big-endian coordinates to the curve field size.
                var padded = new byte[fieldSize];
                Buffer.BlockCopy(coordinate, 0, padded, fieldSize - coordinate.Length, coordinate.Length);
                return padded;
            }
            // Allow a single leading zero byte (occasionally present on big-endian encodings).
            if (coordinate.Length == fieldSize + 1 && coordinate[0] == 0)
            {
                var trimmed = new byte[fieldSize];
                Buffer.BlockCopy(coordinate, 1, trimmed, 0, fieldSize);
                return trimmed;
            }

            throw new FormatException($"The public key coordinates for key '{keyId}' are malformed for the specified curve.");
        }
    }
}
