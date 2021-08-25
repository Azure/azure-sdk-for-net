// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Azure.Core
{
    internal static partial class LightweightPkcs8Decoder
    {
        private static readonly byte[] s_derIntegerOne = { 0x02, 0x01, 0x01 };
        private static readonly object[] s_argsFalse = new object[] { false };

        private static readonly byte[] s_ecAlgorithmId =
        {
            0x06, 0x07, 0x2A, 0x86, 0x48, 0xCE, 0x3D, 0x02, 0x01, // OID 1.2.840.10045.2.1, id-ecPublicKey
        };

        public static ECDsa DecodeECDsaPkcs8(byte[] pkcs8Bytes, ECDsa publicKey)
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

            // Curve { named curve, or curve sequence }
            ECCurveProxy curve;
            if (pkcs8Bytes[offset] == 0x06)
            {
                // Get named curve OID.
                string namedCurveOid = ReadObjectIdentifier(pkcs8Bytes, ref offset);
                curve = new ECCurveProxy(namedCurveOid);
            }
            else if (pkcs8Bytes[offset] == 0x30)
            {
                // If using explicit curve parameters, skip the sequence and take the curve from the public key.
                // Since we read D, Q.X, and Q.Y below this will provide validation without incurring the risks of manually parsing.
                if (publicKey is null)
                {
                    throw new InvalidDataException("Unsupported PKCS#8 Data");
                }

                curve = ECCurveProxy.ExportFromPublicKey(publicKey);

                // skip this sequence
                int sequenceLength = ReadPayloadTagLength(pkcs8Bytes, ref offset, 0x30);
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
                Curve = curve,
                D = ReadOctetString(pkcs8Bytes, ref offset),
            };

            byte[] q;
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
                    q = ReadBitString(pkcs8Bytes, ref offset);

                    // 04 (Uncompressed ECPoint) is almost always used.
                    if (q[0] != 0x04)
                    {
                        throw new InvalidDataException("Invalid PKCS#8 Data");
                    }

                    int privateKeySize = ecParameters.D.Length;
                    if (q.Length != 2 * privateKeySize + 1)
                    {
                        throw new InvalidDataException("Invalid PKCS#8 Data");
                    }

                    ecParameters.X = q.AsSpan(1, privateKeySize).ToArray();
                    ecParameters.Y = q.AsSpan(1 + privateKeySize).ToArray();
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

            public ECCurveProxy Curve;
            public byte[] D;
            public byte[] X;
            public byte[] Y;

            public ECDsa ToECDsa()
            {
                if (s_importParametersMethod is null)
                {
                    Type ecParametersType = typeof(ECDsa).Assembly.GetType("System.Security.Cryptography.ECParameters")
                        ?? throw new PlatformNotSupportedException("The current platform does not support reading an ECDsa private key from a PEM file");

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
                ecParameters.Curve = (ECCurve)Curve.ToObject();
                ecParameters.D = D;
                ecParameters.Q.X = X;
                ecParameters.Q.Y = Y;

                return ecParameters;
            }
        }

        private struct ECCurveProxy
        {
            private static MethodInfo s_exportParametersMethod;
            private static FieldInfo s_curveField;

            private readonly string _namedCurveOid;
            private readonly object _curve;

            public ECCurveProxy(string namedCurveOid)
            {
                _namedCurveOid = namedCurveOid;
                _curve = null;
            }

            private ECCurveProxy(object curve)
            {
                _namedCurveOid = null;
                _curve = curve;
            }

            public static ECCurveProxy ExportFromPublicKey(ECDsa publicKey)
            {
                if (s_exportParametersMethod is null)
                {
                    s_exportParametersMethod = typeof(ECDsa).GetMethod("ExportParameters", BindingFlags.Public | BindingFlags.Instance, null, new[] { typeof(bool) }, null)
                        ?? throw new PlatformNotSupportedException("The current platform does not support reading an ECDsa private key from a PEM file");

                    s_curveField = s_exportParametersMethod.ReturnType.GetField("Curve", BindingFlags.Public | BindingFlags.Instance);
                }

                object parameters = s_exportParametersMethod.Invoke(publicKey, s_argsFalse);
                object curve = s_curveField.GetValue(parameters);

                return new ECCurveProxy(curve);
            }

            // ECCurve is defined in netstandard2.0 but not net461 (introduced in net47). Separate method with no inlining to prevent TypeLoadException on net461.
            [MethodImpl(MethodImplOptions.NoInlining)]
            public object ToObject()
            {
                if (_namedCurveOid != null)
                {
                    return ECCurve.CreateFromValue(_namedCurveOid);
                }

                return _curve;
            }
        }
    }
}
