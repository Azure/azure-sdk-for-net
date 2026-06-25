// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal class BlobErrors : Errors
    {
        public static ArgumentOutOfRangeException BlobConditionsMustBeDefault(params string[] conditions) =>
            new ArgumentOutOfRangeException($"The {string.Join(" and ", conditions)} conditions must have their default values because they are ignored by the blob service");

        public static InvalidOperationException BlobOrContainerMissing(string leaseClient,
            string blobBaseClient,
            string blobContainerClient) =>
            new InvalidOperationException($"{leaseClient} requires either a {blobBaseClient} or {blobContainerClient}");

        public static RequestFailedException InvalidRangeWithNonEmptyBlob(RequestFailedException ex) =>
            new RequestFailedException("Invalid range exception during ranged download despite non-empty blob", ex);

        internal static void VerifyHttpsCustomerProvidedKey(Uri uri, CustomerProvidedKey? customerProvidedKey)
        {
            if (customerProvidedKey.HasValue && !string.Equals(uri.Scheme, Constants.Https, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Cannot use client-provided key without HTTPS.");
            }
        }

        internal static void VerifyCpkAndEncryptionScopeNotBothSet(CustomerProvidedKey? customerProvidedKey, string encryptionScope)
        {
            if (customerProvidedKey.HasValue && encryptionScope != null)
            {
                throw new ArgumentException("CustomerProvidedKey and EncryptionScope cannot both be set");
            }
        }

        public static ArgumentException ParsingFullHttpRangeFailed(string range)
            => new ArgumentException("Could not obtain the total length from HTTP range " + range);

        public static void VerifyParallelismGreaterThanOne(int parallelism)
        {
            if (parallelism <= 1)
            {
                throw new ArgumentException("Parallel must be greater than 1 for parallel download.", nameof(parallelism));
            }
        }

        public static void VerifyNoExtraData(int extraDataLength)
        {
            if (extraDataLength > 0)
            {
                throw new InvalidOperationException("The response contained more data than was indicated by the Content-Length header.");
            }
        }
    }
}
