// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Security.CodeTransparency
{
    internal static class CodeTransparencyEcdsaCompatibility
    {
        public static void ExportPublicPoint(ECDsa key, string expectedCurveName, out byte[] x, out byte[] y)
        {
#if NETFRAMEWORK
            if (!(key is ECDsaCng cng))
            {
                throw new PlatformNotSupportedException("Only ECDsaCng keys are supported on .NET Framework.");
            }

            byte[] blob = cng.Key.Export(CngKeyBlobFormat.EccPublicBlob);
            ReadCngPublicBlob(blob, expectedCurveName, out x, out y);
#else
            ECParameters parameters = key.ExportParameters(false);
            ValidateCurve(parameters.Curve.Oid, expectedCurveName);
            x = CloneCoordinate(parameters.Q.X);
            y = CloneCoordinate(parameters.Q.Y);
#endif
        }

        public static ECDsa Create(string curveName, byte[] x, byte[] y)
        {
#if NETFRAMEWORK
            byte[] blob = CreateCngPublicBlob(curveName, x, y);
            using (CngKey key = CngKey.Import(blob, CngKeyBlobFormat.EccPublicBlob))
            {
                return new ECDsaCng(key);
            }
#else
            return ECDsa.Create(new ECParameters
            {
                Curve = GetNamedCurve(curveName),
                Q = new ECPoint
                {
                    X = CloneCoordinate(x),
                    Y = CloneCoordinate(y),
                },
            });
#endif
        }

#if NETFRAMEWORK
        private static byte[] CreateCngPublicBlob(string curveName, byte[] x, byte[] y)
        {
            int fieldSize = GetFieldSize(curveName);
            if (x?.Length != fieldSize || y?.Length != fieldSize)
            {
                throw new CryptographicException("The ECDSA public point has an unexpected coordinate length.");
            }

            var blob = new byte[8 + (fieldSize * 2)];
            Buffer.BlockCopy(BitConverter.GetBytes(GetCngMagic(curveName)), 0, blob, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(fieldSize), 0, blob, 4, 4);
            Buffer.BlockCopy(x, 0, blob, 8, fieldSize);
            Buffer.BlockCopy(y, 0, blob, 8 + fieldSize, fieldSize);
            return blob;
        }

        private static void ReadCngPublicBlob(byte[] blob, string expectedCurveName, out byte[] x, out byte[] y)
        {
            int fieldSize = GetFieldSize(expectedCurveName);
            if (blob == null ||
                blob.Length != 8 + (fieldSize * 2) ||
                BitConverter.ToUInt32(blob, 0) != GetCngMagic(expectedCurveName) ||
                BitConverter.ToInt32(blob, 4) != fieldSize)
            {
                throw new NotSupportedException("The ECDSA key does not use the expected named curve.");
            }

            x = new byte[fieldSize];
            y = new byte[fieldSize];
            Buffer.BlockCopy(blob, 8, x, 0, fieldSize);
            Buffer.BlockCopy(blob, 8 + fieldSize, y, 0, fieldSize);
        }

        private static uint GetCngMagic(string curveName)
        {
            return curveName switch
            {
                "P-256" => 0x31534345,
                "P-384" => 0x33534345,
                "P-521" => 0x35534345,
                _ => throw new NotSupportedException($"Unsupported curve '{curveName}'."),
            };
        }

        private static int GetFieldSize(string curveName)
        {
            return curveName switch
            {
                "P-256" => 32,
                "P-384" => 48,
                "P-521" => 66,
                _ => throw new NotSupportedException($"Unsupported curve '{curveName}'."),
            };
        }
#endif

        private static byte[] CloneCoordinate(byte[] coordinate)
        {
            if (coordinate == null || coordinate.Length == 0)
            {
                throw new CryptographicException("The ECDSA key does not contain a public point.");
            }

            return (byte[])coordinate.Clone();
        }

        private static void ValidateCurve(Oid oid, string expectedCurveName)
        {
            string identifier = oid?.Value ?? oid?.FriendlyName;
            string actualCurveName = identifier switch
            {
                "1.2.840.10045.3.1.7" => "P-256",
                "nistP256" => "P-256",
                "1.3.132.0.34" => "P-384",
                "nistP384" => "P-384",
                "1.3.132.0.35" => "P-521",
                "nistP521" => "P-521",
                _ => null,
            };

            if (!string.Equals(actualCurveName, expectedCurveName, StringComparison.Ordinal))
            {
                throw new NotSupportedException($"Unsupported ECDSA curve '{oid?.FriendlyName ?? oid?.Value ?? "unknown"}'. Only P-256, P-384, and P-521 are supported.");
            }
        }

#if !NETFRAMEWORK
        private static ECCurve GetNamedCurve(string curveName)
        {
            return curveName switch
            {
                "P-256" => ECCurve.NamedCurves.nistP256,
                "P-384" => ECCurve.NamedCurves.nistP384,
                "P-521" => ECCurve.NamedCurves.nistP521,
                _ => throw new NotSupportedException($"Unsupported curve '{curveName}'."),
            };
        }
#endif
    }
}
