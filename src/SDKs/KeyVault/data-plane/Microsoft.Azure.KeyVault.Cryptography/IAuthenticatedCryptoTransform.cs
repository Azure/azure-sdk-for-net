// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    public interface IAuthenticatedCryptoTransform : ICryptoTransform
    {
        byte[] Tag { get; }
    }
}
