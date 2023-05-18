// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Dynamic;
using Azure.Core.Json;

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
            return utf8Json.ToDynamicFromJson(DynamicCaseMapping.None);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// <paramref name="caseMapping">The case mapping to use for reading and writing data members.</paramref>
        /// </summary>
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicCaseMapping caseMapping)
        {
            JsonSerializerOptions options = DynamicData.GetSerializerOptions(caseMapping);
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, options);
            return new DynamicData(mdoc.RootElement, caseMapping);
        }
    }
}
