// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
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

        public static ArgumentException InvalidDateTimeUtc(string dateTime) =>
            new ArgumentException($"{dateTime} must be UTC");

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

        /// <summary>
        /// Determine if an exception should be treated as a failure for our
        /// client diagnostics.  This lets us allow list a select few error
        /// cases - like precondition failures - to avoid cluttering customer
        /// logs.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>Whether the exception should be treated as a failure.</returns>
        public static bool IsDiagnosticFailure(Exception ex) =>
            // Any exception other than RequestFailedException is a failure
            !(ex is RequestFailedException e) ||

            // Any status code other than 412 is a failure
            e.Status != 412 ||

            // The following 412s are not considered failures
            (e.ErrorCode != BlobErrorCode.ConditionNotMet &&
             e.ErrorCode != BlobErrorCode.SourceConditionNotMet &&
             e.ErrorCode != BlobErrorCode.TargetConditionNotMet);
    }
}
