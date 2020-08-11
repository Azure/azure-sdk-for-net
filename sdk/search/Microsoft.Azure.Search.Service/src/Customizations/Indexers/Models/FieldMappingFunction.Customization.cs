// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    public partial class FieldMappingFunction
    {
        /// <summary>
        /// Creates a field mapping function that performs URL-safe Base64 encoding of the input string. Assumes that
        /// the input is UTF-8 encoded.
        /// </summary>
        /// <remarks>
        /// <para>Sample use case: Only URL-safe characters can appear in a search document key (because customers
        /// must be able to address the document using the Lookup API, for example). If your data contains URL-unsafe
        /// characters and you want to use it to populate a key field in your search index, use this function. 
        /// </para>
        /// <para>
        /// For details on the encoding used, see <see href="https://docs.microsoft.com/azure/search/search-indexer-field-mappings">Field mappings and transformations using Azure Cognitive Search indexers</see>.
        /// Calling this method is the same as calling <c cref="Base64Encode(bool)"/> with <c>useHttpServerUtilityUrlTokenEncode</c> set to <c>true</c>.
        /// </para>
        /// </remarks>
        /// <returns>A new field mapping function.</returns>
        public static FieldMappingFunction Base64Encode() => new FieldMappingFunction("base64Encode");

        /// <summary>
        /// Creates a field mapping function that performs URL-safe Base64 encoding of the input string. Assumes that
        /// the input is UTF-8 encoded.
        /// </summary>
        /// <param name="useHttpServerUtilityUrlTokenEncode">Determines how Base64 encoding is performed. See <see href="https://docs.microsoft.com/azure/search/search-indexer-field-mappings">Field mappings and transformations using Azure Cognitive Search indexers</see> for details.</param>
        /// <remarks>
        /// Sample use case: Only URL-safe characters can appear in a search document key (because customers
        /// must be able to address the document using the Lookup API, for example). If your data contains URL-unsafe
        /// characters and you want to use it to populate a key field in your search index, use this function. 
        /// </remarks>
        /// <returns>A new field mapping function.</returns>
        public static FieldMappingFunction Base64Encode(bool useHttpServerUtilityUrlTokenEncode) => 
            new FieldMappingFunction(
                "base64Encode", 
                new Dictionary<string, object>
                {
                    [nameof(useHttpServerUtilityUrlTokenEncode)] = useHttpServerUtilityUrlTokenEncode
                });

        /// <summary>
        /// Creates a field mapping function that performs a simple URL-safe encoding of the input string, 
        /// using UTF-8 encoding format.
        /// </summary>
        /// <remarks>
        /// Sample use case: This field mapping function can be used as an alternative to Base64Encode if only the URL
        /// unsafe characters of a key field need to be safely converted, while other characters can remain as-is.
        /// </remarks>
        /// <returns>A new field mapping function</returns>
        public static FieldMappingFunction UrlEncode() => new FieldMappingFunction("urlEncode");

        /// <summary>
        /// Creates a field mapping function that performs url decoding of the input string. It assumes that the input
        /// string has been url decoded with UTF-8 encoding format. 
        /// </summary>
        /// <remarks>
        /// Sample use case: Some clients that try to update blob custom metadata (which need to be ASCII-encoded) might
        /// choose to URL encode the data. To ingest that custom metadata and make search meaningful, the URL decode
        /// field mapping function can be used while populating the search index.
        /// </remarks>
        /// <returns>A new field mapping function</returns>
        public static FieldMappingFunction UrlDecode() => new FieldMappingFunction("urlDecode");

        /// <summary>
        /// Creates a field mapping function that performs Base64 decoding of the input string. The input is assumed
        /// to a URL-safe Base64-encoded string. 
        /// </summary>
        /// <remarks>
        /// <para>Sample use case: Blob custom metadata values must be ASCII-encoded. You can use Base64 encoding to
        /// represent arbitrary Unicode strings in blob custom metadata. However, to make search meaningful, you can
        /// use this function to turn the encoded data back into "regular" strings when populating your search index. 
        /// </para>
        /// <para>
        /// For details on the decoding used, see <see href="https://docs.microsoft.com/azure/search/search-indexer-field-mappings">Field mappings and transformations using Azure Cognitive Search indexers</see>.
        /// Calling this method is the same as calling <c cref="Base64Decode(bool)"/> with <c>useHttpServerUtilityUrlTokenDecode</c> set to <c>true</c>.
        /// </para>
        /// </remarks>
        /// <returns>A new field mapping function.</returns>
        public static FieldMappingFunction Base64Decode() => new FieldMappingFunction("base64Decode");

        /// <summary>
        /// Creates a field mapping function that performs Base64 decoding of the input string. The input is assumed
        /// to a URL-safe Base64-encoded string. 
        /// </summary>
        /// <param name="useHttpServerUtilityUrlTokenDecode">Determines how Base64 decoding is performed. See <see href="https://docs.microsoft.com/azure/search/search-indexer-field-mappings">Field mappings and transformations using Azure Cognitive Search indexers</see> for details.</param>
        /// <remarks>
        /// Sample use case: Blob custom metadata values must be ASCII-encoded. You can use Base64 encoding to
        /// represent arbitrary Unicode strings in blob custom metadata. However, to make search meaningful, you can
        /// use this function to turn the encoded data back into "regular" strings when populating your search index. 
        /// </remarks>
        /// <returns>A new field mapping function.</returns>
        public static FieldMappingFunction Base64Decode(bool useHttpServerUtilityUrlTokenDecode) =>
            new FieldMappingFunction(
                "base64Decode",
                new Dictionary<string, object>
                {
                    [nameof(useHttpServerUtilityUrlTokenDecode)] = useHttpServerUtilityUrlTokenDecode
                });

        /// <summary>
        /// Creates a field mapping function that splits a string field using the specified delimiter, and picks the
        /// token at the specified position in the resulting split.
        /// </summary>
        /// <param name="delimiter">A string to use as the separator when splitting the input string.</param>
        /// <param name="position">An integer zero-based position of the token to pick after the input string is split.</param>
        /// <remarks>
        /// <para>
        /// For example, if the input is Jane Doe, the delimiter is " " (space) and the position is 0, the result is
        /// Jane; if the position is 1, the result is Doe. If the position refers to a token that doesn't exist, an
        /// error will be returned.
        /// </para>
        /// <para>
        /// Sample use case: Your data source contains a PersonName field, and you want to index it as two separate
        /// FirstName and LastName fields. You can use this function to split the input using the space character as
        /// the delimiter.
        /// </para>
        /// </remarks>
        /// <returns>A new field mapping function.</returns>
        public static FieldMappingFunction ExtractTokenAtPosition(string delimiter, int position) =>
            new FieldMappingFunction(
                "extractTokenAtPosition", 
                new Dictionary<string, object>
                {
                    [nameof(delimiter)] = delimiter,
                    [nameof(position)] = position
                });

        /// <summary>
        /// Creates a field mapping function that transforms a string formatted as a JSON array of strings into a string array that can be used to
        /// populate a Collection(Edm.String) field in the index.
        /// </summary>
        /// <remarks>
        /// <para>
        /// For example, if the input string is ["red", "white", "blue"], then the target field of type Collection(Edm.String) will be populated
        /// with the three values red, white and blue. For input values that cannot be parsed as JSON string arrays, an error will be returned.
        /// </para>
        /// <para>
        /// Sample use case: Azure SQL database doesn't have a built-in data type that naturally maps to Collection(Edm.String) fields in Azure
        /// Search. To populate string collection fields, format your source data as a JSON string array and use this function.
        /// </para>
        /// </remarks>
        /// <returns>A new field mapping function.</returns>
        public static FieldMappingFunction JsonArrayToStringCollection() => new FieldMappingFunction("jsonArrayToStringCollection");
    }
}
