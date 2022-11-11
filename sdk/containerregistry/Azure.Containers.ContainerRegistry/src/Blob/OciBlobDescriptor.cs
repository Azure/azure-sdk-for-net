﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("Descriptor")]
    public partial class OciBlobDescriptor
    {
        /// <summary> Layer media type. </summary>
        public string MediaType { get; set; }
        /// <summary> Layer size. </summary>
        public long? Size { get; set; }
        /// <summary> Layer digest. </summary>
        public string Digest { get; set; }

        /// <summary> Additional information provided through arbitrary metadata. </summary>
        public OciAnnotations Annotations { get; set; }

        /// <summary> Specifies a list of URIs from which this object may be downloaded. </summary>
        internal IList<Uri> Urls { get; }

        internal static string ComputeDigest(Stream stream)
        {
            Debug.Assert(stream.CanSeek, "Should only be called on seekable streams.");

            using (SHA256 sha256 = SHA256.Create())
            {
                var position = stream.Position;
                string digest = default;

                // Compute and print the hash values for each file in directory.
                try
                {
                    stream.Position = 0;
                    var hashValue = sha256.ComputeHash(stream);
                    digest = FormatDigest(hashValue);
                }
                catch (IOException e)
                {
                    Console.WriteLine($"I/O Exception: {e.Message}");
                    throw;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine($"Access Exception: {e.Message}");
                    throw;
                }
                finally
                {
                    stream.Position = position;
                }

                return digest;
            }
        }

        internal static string FormatDigest(byte[] hash)
        {
            return $"sha256:{BytesToString(hash)}";
        }

        private static string BytesToString(byte[] bytes)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                builder.AppendFormat("{0:X2}", bytes[i]);
#pragma warning restore CA1305 // Specify IFormatProvider
            }
#pragma warning disable CA1304 // Specify CultureInfo
            return builder.ToString().ToLower();
#pragma warning restore CA1304 // Specify CultureInfo
        }
    }
}
