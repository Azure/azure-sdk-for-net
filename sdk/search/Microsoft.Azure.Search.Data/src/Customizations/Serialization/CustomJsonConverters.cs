// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Search.Serialization.Internal
{
    /// <summary>
    /// Provides access to custom <see cref="JsonConverter" /> instances used by the Azure
    /// Search .NET SDK. For test purposes only.
    /// </summary>
    /// <remarks>
    /// This class is part of the internal implementation of the Azure Cognitive Search .NET SDK. It is not
    /// intended to be used directly by application code.
    /// </remarks>
    public static class CustomJsonConverters
    {
        /// <summary>
        /// Creates a new converter that converts between dates serialized in ISO 8601 format in JSON strings and
        /// <see cref="System.DateTime" /> instances.
        /// </summary>
        /// <returns>A JSON converter.</returns>
        public static JsonConverter CreateDateTimeConverter() => new Iso8601DateTimeConverter();

        /// <summary>
        /// Creates a new converter that deserializes JSON objects and arrays to .NET types instead
        /// of <see cref="JObject" /> and <see cref="JArray" />.
        /// </summary>
        /// <returns>A JSON converter.</returns>
        public static JsonConverter CreateDocumentConverter() => new DocumentConverter();

        /// <summary>
        /// Creates a new converter that serializes doubles to and from the OData EDM wire format.
        /// </summary>
        /// <returns>A JSON converter.</returns>
        public static JsonConverter CreateDoubleConverter() => new EdmDoubleConverter();

        /// <summary>
        /// Creates a new converter that converts between
        /// <see cref="GeographyPoint" /> objects and Geo-JSON points.
        /// </summary>
        /// <returns>A JSON converter.</returns>
        public static JsonConverter CreateGeoJsonPointConverter() => new GeoJsonPointConverter();

        /// <summary>
        /// Creates a collection of all custom converters.
        /// </summary>
        /// <returns>An enumerable sequence of JSON converters.</returns>
        public static IEnumerable<JsonConverter> CreateAllConverters()
        {
            yield return CreateDateTimeConverter();
            yield return CreateDocumentConverter();
            yield return CreateDoubleConverter();
            yield return CreateGeoJsonPointConverter();
        }
    }
}
