// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

#if NET461 // ECParameters is not available in net461: https://github.com/dotnet/standard/blob/master/src/netstandard/src/ApiCompatBaseline.net461.txt

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
            ecParameters = default;
        }
    }

    internal static partial class EccExtensions
    {
        internal static ECParameters ExportParameters(this ECDsa ecdsa, bool includePrivateParameters)
        {
            includePrivateParameters = false;
            return default;
        }
    }

    internal struct ECParameters
    {
    }
}

#endif
