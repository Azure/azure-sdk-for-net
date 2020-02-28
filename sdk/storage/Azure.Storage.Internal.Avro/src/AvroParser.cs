// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable CA1801 // It's a proof of concept

namespace Azure.Storage.Internal.Avro
{
    /// <summary>
    /// Basic Avro parser that implements only the features required for Azure
    /// Storage client libraries.
    /// </summary>
    internal static class AvroParser
    {
        /// <summary>
        /// Parse an Avro document.
        /// </summary>
        /// <param name="content">Raw Avro.</param>
        /// <returns>Parsed Avro.</returns>
        public static object Parse(object content) => 42;
    }
}
