// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography
{
    internal interface IAuthenticatedCryptographicTransform : IDisposable
    {
        TransformMode TransformMode { get; }

        int NonceLength { get; }

        int TagLength { get; }

        /// <summary>
        /// Apply this transform.
        /// </summary>
        /// <param name="input">
        /// Input data block to transform.
        /// </param>
        /// <param name="output">
        /// Span to write transformed contents to.
        /// </param>
        /// <returns>
        /// Number of bytes written to output.
        /// </returns>
        int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output);
    }
}
