// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    internal static partial class BlobExtensions
    {
        internal static void VerifyHttpsCustomerProvidedKey(Uri uri, CustomerProvidedKeyInfo? customerProvidedKey)
        {
            if (customerProvidedKey.HasValue && !String.Equals(uri.Scheme, Constants.Blob.Https, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Cannot use client-provided key without HTTPS.");
            }
        }
    }
}
