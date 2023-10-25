// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Containers.ContainerRegistry
{
    internal class BlobHelper
    {
        private const string ClientAndServerDigestsDontMatchMessage = "The server-computed digest does not match the client-computed digest.";
        internal const string ContentDigestDoesntMatchRequestedMessage = "The digest computed from the downloaded content does not match the requested digest.";
        internal const string ManifestDigestDoestMatchRequestedMessage = "The digest of the received manifest does not match the requested digest reference.";

        internal static string ComputeDigest(Stream stream)
        {
            // According to https://docs.docker.com/registry/spec/api/#content-digests, compliant
            // registry implementations use sha256.

            using SHA256 sha256 = SHA256.Create();
            var position = stream.Position;

            try
            {
                stream.Position = 0;
                var hashValue = sha256.ComputeHash(stream);
                return FormatDigest(hashValue);
            }
            finally
            {
                stream.Position = position;
            }
        }

        internal static string ComputeDigest(BinaryData data)
        {
            using SHA256 sha256 = SHA256.Create();
            var hashValue = sha256.ComputeHash(data.ToArray());
            return FormatDigest(hashValue);
        }

        internal static string FormatDigest(byte[] hash)
        {
            return BytesToString(hash);
        }

        private static string BytesToString(byte[] bytes)
        {
            var builder = new StringBuilder(72);
            builder.Append("sha256:");
            for (int i = 0; i < bytes.Length; i++)
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                builder.AppendFormat("{0:x2}", bytes[i]);
#pragma warning restore CA1305 // Specify IFormatProvider
            }
            return builder.ToString();
        }

        internal static void ValidateDigest(string clientDigest, string serverDigest, string message = default)
        {
            if (!clientDigest.Equals(serverDigest, StringComparison.OrdinalIgnoreCase))
            {
                throw new RequestFailedException(200, message ?? ClientAndServerDigestsDontMatchMessage);
            }
        }
    }
}
