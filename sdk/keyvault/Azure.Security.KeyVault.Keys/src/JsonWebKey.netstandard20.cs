// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

#if !NET461 // ECParameters is not available in net461: https://github.com/dotnet/standard/blob/master/src/netstandard/src/ApiCompatBaseline.net461.txt

using System;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys
{
    public partial class JsonWebKey
    {
        /// <summary>
        /// Creates an instance of <see cref="JsonWebKey"/> using type <see cref="KeyType.EllipticCurve"/>.
        /// </summary>
        /// <param name="ecdsa">An <see cref="ECDsa"/> provider.</param>
        /// <param name="includePrivateParameters">Whether to include private parameters.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ecdsa"/> is null.</exception>
        public JsonWebKey(ECDsa ecdsa, bool includePrivateParameters = default)
            : this(ecdsa?.ExportParameters(includePrivateParameters) ?? throw new ArgumentNullException(nameof(ecdsa)))
        {
        }

        private JsonWebKey(ECParameters ecParameters) : this()
        {
            KeyType = KeyType.EllipticCurve;

            CurveName = ecParameters.Curve.GetCurveName();
            D = ecParameters.D;
            X = ecParameters.Q.X;
            Y = ecParameters.Q.Y;
        }
    }

    internal static partial class EccExtensions
    {
        private static readonly Oid[] namedCurves = new[]
        {
            new Oid("1.2.840.10045.3.1.7", KeyCurveNameExtensions.AsString(KeyCurveName.P256)),
            new Oid("1.3.132.0.10", KeyCurveNameExtensions.AsString(KeyCurveName.P256K)),
            new Oid("1.3.132.0.34", KeyCurveNameExtensions.AsString(KeyCurveName.P384)),
            new Oid("1.3.132.0.35", KeyCurveNameExtensions.AsString(KeyCurveName.P521)),
        };

        internal static string GetCurveName(this ECCurve curve)
        {
            if (curve.IsNamed)
            {
                for (int i = 0; i < namedCurves.Length; ++i)
                {
                    Oid namedCurve = namedCurves[i];
                    if (string.Equals(namedCurve.Value, curve.Oid?.Value, StringComparison.Ordinal))
                    {
                        return namedCurve.FriendlyName;
                    }
                }
            }

            return string.Empty;
        }
    }
}

#endif
