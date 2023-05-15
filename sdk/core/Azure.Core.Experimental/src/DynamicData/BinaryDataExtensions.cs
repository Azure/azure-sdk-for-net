// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Json;
using Azure.Core.Dynamic;

namespace Azure
{
    /// <summary>
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, DynamicData.DefaultSerializerOptions);
            return new DynamicData(mdoc.RootElement, DynamicPropertyNameHandling.None);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// <paramref name="nameHandling">The name mapping to use for reading and writing data.</paramref>
        /// </summary>
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicPropertyNameHandling nameHandling)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, DynamicData.DefaultSerializerOptions);
            return new DynamicData(mdoc.RootElement, nameHandling);
        }
    }
}
