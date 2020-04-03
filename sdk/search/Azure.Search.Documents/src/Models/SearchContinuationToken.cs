// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Creates continuation tokens used for resuming a search that requires
    /// multiple requests to return the user's desired data.  This is only to
    /// support server-side paging.  Client-side paging should be handled with
    /// Skip and Size.
    /// </summary>
    internal static class SearchContinuationToken
    {
        private const string ApiVersionName = "apiVersion";
        private static readonly JsonEncodedText s_apiVersionEncodedName = JsonEncodedText.Encode(ApiVersionName);

        private const string NextLinkName = "nextLink";
        private static readonly JsonEncodedText s_nextLinkEncodedName = JsonEncodedText.Encode(NextLinkName);

        private const string NextPageParametersName = "nextPageParameters";
        private static readonly JsonEncodedText s_nextPageParametersEncodedName = JsonEncodedText.Encode(NextPageParametersName);

        /// <summary>
        /// Creates a durable, opaque continuation token that can be provided
        /// to users.
        /// </summary>
        /// <param name="nextPageUri">
        /// URI of additional results when making GET requests.
        /// </param>
        /// <param name="nextPageOptions">
        /// <see cref="SearchOptions"/> for additional results when making POST
        /// requests.
        /// </param>
        /// <returns>A continuation token.</returns>
        public static string Serialize(Uri nextPageUri, SearchOptions nextPageOptions)
        {
            // There's no continuation token if there's no next page
            if (nextPageUri == null || nextPageOptions == null)
            {
                return null;
            }
            using MemoryStream buffer = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteString(s_apiVersionEncodedName, SearchClientOptions.ContinuationTokenVersion.ToVersionString());
                writer.WriteString(s_nextLinkEncodedName, nextPageUri.ToString());
                writer.WritePropertyName(s_nextPageParametersEncodedName);
                writer.WriteObjectValue(nextPageOptions);
                writer.WriteEndObject();
            }
            return Convert.ToBase64String(buffer.ToArray());
        }

        /// <summary>
        /// Parses a continuation token and returns the corresponding to the
        /// next page's <see cref="SearchOptions"/>.
        /// </summary>
        /// <param name="continuationToken">
        /// The serialized continuation token.
        /// </param>
        /// <returns>The continuation token's next page options.</returns>
        public static SearchOptions Deserialize(string continuationToken)
        {
            Argument.AssertNotNullOrEmpty(continuationToken, nameof(continuationToken));
            byte[] decoded = Convert.FromBase64String(continuationToken);
            try
            {
                using JsonDocument json = JsonDocument.Parse(decoded);
                if (json.RootElement.ValueKind == JsonValueKind.Object &&
                    json.RootElement.TryGetProperty(ApiVersionName, out JsonElement apiVersion) &&
                    apiVersion.ValueKind == JsonValueKind.String &&
                    // Today we only validate against a single known version,
                    // but in the future we may want to support a range of
                    // valid continuation token serialization formats.  This
                    // will need to be updated accordingly.
                    string.Equals(
                        apiVersion.GetString(),
                        SearchClientOptions.ContinuationTokenVersion.ToVersionString(),
                        StringComparison.OrdinalIgnoreCase) &&
                    json.RootElement.TryGetProperty(NextPageParametersName, out JsonElement nextPageParams) &&
                    nextPageParams.ValueKind == JsonValueKind.Object)
                {
                    // We only use the nextPageParameters because we do all of
                    // our searching via HTTP POST requests
                    return SearchOptions.DeserializeSearchOptions(nextPageParams);
                }
            }
            catch (JsonException)
            {
            }

            throw new ArgumentException("Invalid continuation token", nameof(continuationToken));
        }
    }
}
