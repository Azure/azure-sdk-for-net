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
            return utf8Json.ToDynamicFromJson(DynamicDataOptions.Default);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicCaseMapping caseMapping, DynamicDateTimeHandling dateTimeHandling = DynamicDateTimeHandling.Rfc3339)
        {
            DynamicDataOptions options = new()
            {
                CaseMapping = caseMapping,
                DateTimeHandling = dateTimeHandling
            };

            return utf8Json.ToDynamicFromJson(options);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicDataOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, DynamicData.GetSerializerOptions(options));
            return new DynamicData(mdoc.RootElement, options);
        }
    }
}
