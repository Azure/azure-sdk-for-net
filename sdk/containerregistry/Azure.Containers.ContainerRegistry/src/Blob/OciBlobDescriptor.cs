// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            using (SHA256 sha256 = SHA256.Create())
            {
                var position = stream.Position;
                string digest = default;

                // Compute and print the hash values for each file in directory.
                try
                {
                    stream.Position = 0;
                    var hashValue = sha256.ComputeHash(stream);
                    digest = "sha256:" + PrintByteArray(hashValue);
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

        // Display the byte array in a readable format.
        private static string PrintByteArray(byte[] array)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                builder.AppendFormat($"{array[i]:X2}");
#pragma warning restore CA1305 // Specify IFormatProvider
            }
#pragma warning disable CA1304 // Specify CultureInfo
            return builder.ToString().ToLower();
#pragma warning restore CA1304 // Specify CultureInfo
        }
    }
}
