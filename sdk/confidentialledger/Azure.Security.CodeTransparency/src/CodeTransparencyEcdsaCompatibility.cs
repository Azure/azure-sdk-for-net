// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace Azure.Security.CodeTransparency
{
    internal static class CodeTransparencyEcdsaCompatibility
    {
        public static void ExportPublicPoint(ECDsa key, string expectedCurveName, out byte[] x, out byte[] y)
        {
#if NETSTANDARD2_0
            if (!TryExportParameters(key, expectedCurveName, out x, out y))
            {
                ExportCngPublicPoint(key, expectedCurveName, out x, out y);
            }
#else
            ECParameters parameters = key.ExportParameters(false);
            ValidateCurve(parameters.Curve.Oid, expectedCurveName);
            x = CloneCoordinate(parameters.Q.X);
            y = CloneCoordinate(parameters.Q.Y);
#endif
        }

        public static ECDsa Create(string curveName, byte[] x, byte[] y)
        {
#if NETSTANDARD2_0
            return TryCreateWithParameters(curveName, x, y, out ECDsa key)
                ? key
                : CreateFromCngPublicBlob(curveName, x, y);
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

#if NETSTANDARD2_0
        private static bool TryExportParameters(ECDsa key, string expectedCurveName, out byte[] x, out byte[] y)
        {
            try
            {
                MethodInfo export = key.GetType().GetMethod("ExportParameters", new[] { typeof(bool) });
                object parameters = Invoke(export, key, false);
                object point = GetField(parameters, "Q");
                x = CloneCoordinate(GetField(point, "X") as byte[]);
                y = CloneCoordinate(GetField(point, "Y") as byte[]);
                ValidateCurve(parameters, expectedCurveName);
                return true;
            }
            catch (TypeLoadException)
            {
                x = null;
                y = null;
                return false;
            }
        }

        private static bool TryCreateWithParameters(string curveName, byte[] x, byte[] y, out ECDsa key)
        {
            try
            {
                Type parametersType = GetAlgorithmsType("System.Security.Cryptography.ECParameters");
                Type pointType = GetAlgorithmsType("System.Security.Cryptography.ECPoint");
                Type curveType = GetAlgorithmsType("System.Security.Cryptography.ECCurve");
                Type namedCurvesType = curveType.GetNestedType("NamedCurves", BindingFlags.Public);

                object point = Activator.CreateInstance(pointType);
                SetField(point, "X", CloneCoordinate(x));
                SetField(point, "Y", CloneCoordinate(y));

                object parameters = Activator.CreateInstance(parametersType);
                SetField(parameters, "Curve", namedCurvesType.GetProperty(GetNamedCurveProperty(curveName), BindingFlags.Public | BindingFlags.Static).GetValue(null));
                SetField(parameters, "Q", point);

                MethodInfo create = typeof(ECDsa).GetMethod("Create", BindingFlags.Public | BindingFlags.Static, null, new[] { parametersType }, null);
                key = (ECDsa)Invoke(create, null, parameters);
                return true;
            }
            catch (TypeLoadException)
            {
                key = null;
                return false;
            }
        }

        private static Type GetAlgorithmsType(string typeName)
        {
            return Type.GetType($"{typeName}, System.Security.Cryptography.Algorithms", throwOnError: true);
        }

        private static object GetField(object instance, string fieldName)
        {
            return instance.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance).GetValue(instance);
        }

        private static void SetField(object instance, string fieldName, object value)
        {
            instance.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance).SetValue(instance, value);
        }

        private static object Invoke(MethodInfo method, object instance, params object[] arguments)
        {
            if (method == null)
            {
                throw new MissingMethodException("The runtime does not provide the required ECDSA parameter API.");
            }

            try
            {
                return method.Invoke(instance, arguments);
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        private static void ValidateCurve(object parameters, string expectedCurveName)
        {
            object curve = GetField(parameters, "Curve");
            object oid = curve.GetType().GetProperty("Oid", BindingFlags.Public | BindingFlags.Instance).GetValue(curve);
            ValidateCurve((Oid)oid, expectedCurveName);
        }

        private static void ExportCngPublicPoint(ECDsa key, string expectedCurveName, out byte[] x, out byte[] y)
        {
            Type blobFormatType = GetCngType("System.Security.Cryptography.CngKeyBlobFormat");
            object blobFormat = blobFormatType.GetProperty("EccPublicBlob", BindingFlags.Public | BindingFlags.Static).GetValue(null);
            PropertyInfo keyProperty = key.GetType().GetProperty("Key", BindingFlags.Public | BindingFlags.Instance);
            if (keyProperty == null)
            {
                throw new PlatformNotSupportedException("This runtime cannot export ECDSA public keys without ECParameters.");
            }

            object cngKey = keyProperty.GetValue(key);
            try
            {
                MethodInfo export = cngKey.GetType().GetMethod("Export", new[] { blobFormatType });
                byte[] blob = (byte[])Invoke(export, cngKey, blobFormat);
                ReadCngPublicBlob(blob, expectedCurveName, out x, out y);
            }
            finally
            {
                (cngKey as IDisposable)?.Dispose();
            }
        }

        private static ECDsa CreateFromCngPublicBlob(string curveName, byte[] x, byte[] y)
        {
            byte[] blob = CreateCngPublicBlob(curveName, x, y);
            Type cngKeyType = GetCngType("System.Security.Cryptography.CngKey");
            Type blobFormatType = GetCngType("System.Security.Cryptography.CngKeyBlobFormat");
            object blobFormat = blobFormatType.GetProperty("EccPublicBlob", BindingFlags.Public | BindingFlags.Static).GetValue(null);
            MethodInfo import = cngKeyType.GetMethod("Import", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(byte[]), blobFormatType }, null);
            object cngKey = Invoke(import, null, blob, blobFormat);
            try
            {
                Type ecdsaCngType = GetCngType("System.Security.Cryptography.ECDsaCng");
                ConstructorInfo constructor = ecdsaCngType.GetConstructor(new[] { cngKeyType });
                return (ECDsa)constructor.Invoke(new[] { cngKey });
            }
            finally
            {
                (cngKey as IDisposable)?.Dispose();
            }
        }

        private static Type GetCngType(string typeName)
        {
            return Type.GetType($"{typeName}, System.Security.Cryptography.Cng", throwOnError: true);
        }

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

        private static string GetNamedCurveProperty(string curveName)
        {
            return curveName switch
            {
                "P-256" => "nistP256",
                "P-384" => "nistP384",
                "P-521" => "nistP521",
                _ => throw new NotSupportedException($"Unsupported curve '{curveName}'."),
            };
        }

#if !NETSTANDARD2_0
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
