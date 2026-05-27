// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage
{
    /// <summary>
    /// Create exceptions for common Avro error cases.
    /// </summary>
    internal partial class Errors
    {
        public static InvalidDataException InvalidAvroFieldSize(int size, int maxFieldSize)
            => new InvalidDataException($"Invalid Avro field size: {size}. Size must be between 0 and {maxFieldSize}.");
    }
}
