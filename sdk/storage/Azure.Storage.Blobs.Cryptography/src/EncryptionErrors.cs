// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Specialized
{
    internal static class EncryptionErrors
    {
        public static ArgumentException KeyNotFound(string keyId)
            => new ArgumentException($"Could not resolve key of id `{keyId}`.");

        public static ArgumentException BadEncryptionAgent(string agent)
            => new ArgumentException("Invalid Encryption Agent. This version of the client library does not understand" +
                $"the Encryption Agent protocol \"{agent}\" set on the blob.");

        public static ArgumentException BadEncryptionAlgorithm(string algorithm)
            => new ArgumentException($"Invalid Encryption Algorithm \"{algorithm}\" found on the resource. This version of the client" +
                "library does not support the given encryption algorithm.");

        public static ArgumentException NoKeyAccessor(params string[] names)
            => new ArgumentException($"One of [{string.Join(", ", names)}] must be non-null.");

        public static InvalidOperationException MissingEncryptionMetadata(string field)
            => new InvalidOperationException($"Missing field \"{field}\" in encryption metadata");
    }
}
