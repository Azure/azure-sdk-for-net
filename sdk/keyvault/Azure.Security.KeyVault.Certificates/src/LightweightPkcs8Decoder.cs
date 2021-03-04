// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Azure.Core
{
    internal partial class LightweightPkcs8Decoder
    {
        private static readonly byte[] s_derIntegerOne = { 0x02, 0x01, 0x01 };

        private static readonly byte[] s_ecAlgorithmId =
        {
            0x06, 0x07, 0x2A, 0x86, 0x48, 0xCE, 0x3D, 0x02, 0x01, // OID 1.2.840.10045.2.1, id-ecPublicKey
        };

        public static ECDsa DecodeECDsaPkcs8(byte[] pkcs8Bytes)
        {
            // Based on https://tools.ietf.org/html/rfc5208 and https://www.secg.org/sec1-v2.pdf

            int offset = 0;

            // PrivateKeyInfo SEQUENCE
            ConsumeFullPayloadTag(pkcs8Bytes, ref offset, 0x30);

            // PKCS#8 PrivateKeyInfo.version == 0
            ConsumeMatch(pkcs8Bytes, ref offset, s_derIntegerZero);

            // PKCS#8 PrivateKeyInfo.sequence { AlgorithmIdentifier, CurveName }
            ReadPayloadTagLength(pkcs8Bytes, ref offset, 0x30);

            // id-ecPublicKey AlgorithmIdentifier value
            ConsumeMatch(pkcs8Bytes, ref offset, s_ecAlgorithmId);

            // CurveName: may be OID or within a sequence from Key Vault.
            string curveNameOid;
            if (pkcs8Bytes[offset] == 0x06)
            {
                // Get OID for P-256K, P384, and P-521 from Key Vault.
                curveNameOid = ReadObjectIdentifier(pkcs8Bytes, ref offset);
            }
            else if (pkcs8Bytes[offset] == 0x30)
            {
                // Get OID for P-256 from Key Vault.
                int sequenceLength = ReadPayloadTagLength(pkcs8Bytes, ref offset, 0x30);
                int innerOffset = offset;

                // version == 1
                ConsumeMatch(pkcs8Bytes, ref innerOffset, s_derIntegerOne);

                // SEQUENCE
                ReadPayloadTagLength(pkcs8Bytes, ref innerOffset, 0x30);

                // curveName
                curveNameOid = ReadObjectIdentifier(pkcs8Bytes, ref innerOffset);

                // The prime-field OID is used by Key Vault for P-256K but is not supported by .NET.
                // Instead, use the secp256k1 OID which is also used by Azure.Security.KeyVault.Keys.
                if ("1.2.840.10045.1.1".Equals(curveNameOid, StringComparison.Ordinal))
                {
                    curveNameOid = "1.3.132.0.10";
                }

                // skip remaining sequence
                offset += sequenceLength;
            }
            else
            {
                throw new InvalidDataException("Invalid PKCS#8 Data");
            }

            // ECPrivateKey value
            int privateKeyInfoLength = ReadPayloadTagLength(pkcs8Bytes, ref offset, 0x04);
            int privateKeyInfoEnd = offset + privateKeyInfoLength;

            // ECPrivateKey SEQUENCE
            ReadPayloadTagLength(pkcs8Bytes, ref offset, 0x30);
            // ECPrivateKey.version == 1
            ConsumeMatch(pkcs8Bytes, ref offset, s_derIntegerOne);

            // ECPrivateKey.privateKey
            ECParametersProxy ecParameters = new ECParametersProxy
            {
                Curve = curveNameOid,
                D = ReadOctetString(pkcs8Bytes, ref offset)
            };

            byte[] publicKey;
            while (offset < privateKeyInfoEnd)
            {
                byte tag = pkcs8Bytes[offset++];
                int length = ReadLength(pkcs8Bytes, ref offset);

                // Optional ECDomainParameters [0]
                if ((tag & 0xa0) == tag)
                {
                    // Not expected; skip for now.
                    offset += length;
                }
                // Optional PublicKey [1]
                else if ((tag & 0xa1) == tag)
                {
                    // Adapted from https://github.com/dotnet/runtime/blob/be74b4bd/src/libraries/Common/src/System/Security/Cryptography/EccKeyFormatHelper.cs#L115
                    publicKey = ReadBitString(pkcs8Bytes, ref offset);

                    // 04 (Uncompressed ECPoint) is almost always used.
                    if (publicKey[0] != 0x04)
                    {
                        throw new InvalidDataException("Invalid PKCS#8 Data");
                    }

                    int privateKeySize = ecParameters.D.Length;
                    if (publicKey.Length != 2 * privateKeySize + 1)
                    {
                        throw new InvalidDataException("Invalid PKCS#8 Data");
                    }

                    ecParameters.X = publicKey.AsSpan(1, privateKeySize).ToArray();
                    ecParameters.Y = publicKey.AsSpan(1 + privateKeySize).ToArray();
                }
                else
                {
                    // Unexpected
                    throw new InvalidDataException("Invalid PKCS#8 Data");
                }
            }

            // Optional attributes from Key Vault.
            if (offset < pkcs8Bytes.Length)
            {
                ConsumeFullPayloadTag(pkcs8Bytes, ref offset, 0xa0);
            }

            return ecParameters.ToECDsa();
        }

        private struct ECParametersProxy
        {
            private static MethodInfo s_importParametersMethod;

            public string Curve;
            public byte[] D;
            public byte[] X;
            public byte[] Y;

            public ECDsa ToECDsa()
            {
                if (s_importParametersMethod is null)
                {
                    Type ecParametersType = typeof(ECDsa).Assembly.GetType("System.Security.Cryptography.ECParameters") ??
                        throw new PlatformNotSupportedException("The current platform does not support reading an ECDsa private key from a PEM file");

                    s_importParametersMethod = typeof(ECDsa).GetMethod("ImportParameters", BindingFlags.Instance | BindingFlags.Public, null, new[] { ecParametersType }, null);
                }

                ECDsa ecdsa = null;
                try
                {
                    ecdsa = ECDsa.Create();
                    s_importParametersMethod.Invoke(ecdsa, new[] { ToObject() });

                    // Make sure ecdsa is disposed if ImportParameters above fails.
                    ECDsa ret = ecdsa;
                    ecdsa = null;

                    return ret;
                }
                finally
                {
                    ecdsa?.Dispose();
                }
            }

            // ECParameters is defined in netstandard2.0 but not net461 (introduced in net47). Separate method with no inlining to prevent TypeLoadException on net461.
            [MethodImpl(MethodImplOptions.NoInlining)]
            public object ToObject()
            {
                ECParameters ecParameters = new ECParameters();
                ecParameters.Curve = ECCurve.CreateFromValue(Curve);
                ecParameters.D = D;
                ecParameters.Q.X = X;
                ecParameters.Q.Y = Y;

                return ecParameters;
            }
        }
    }
}
