﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Create exceptions for common error cases.
    /// </summary>
    internal class BlobErrors : Errors
    {
        public static ArgumentOutOfRangeException BlobConditionsMustBeDefault(params string[] conditions) =>
            new ArgumentOutOfRangeException($"The {String.Join(" and ", conditions)} conditions must have their default values because they are ignored by the blob service");

        public static InvalidOperationException BlobOrContainerMissing(string leaseClient,
            string blobBaseClient,
            string blobContainerClient) =>
            new InvalidOperationException($"{leaseClient} requires either a {blobBaseClient} or {blobContainerClient}");

        public static ArgumentException InvalidDateTimeUtc(string dateTime) =>
            new ArgumentException($"{dateTime} must be UTC");

        internal static void VerifyHttpsCustomerProvidedKey(Uri uri, CustomerProvidedKey? customerProvidedKey)
        {
            if (customerProvidedKey.HasValue && !String.Equals(uri.Scheme, Constants.Blob.Https, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Cannot use client-provided key without HTTPS.");
            }
        }
    }
}
