// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using Models;
    using Newtonsoft.Json;

    internal class SearchContinuationTokenConverter : JsonConverter
    {
        // MAINTENANCE NOTE: Remember to change this when the REST API version changes.
        private const string TargetApiVersion = "2019-05-06";

        public override bool CanConvert(Type objectType) => objectType == typeof(SearchContinuationToken);

        public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
        {
            Payload payload = serializer.Deserialize<Payload>(reader);

            Uri nextLinkUri;
            try
            {
                nextLinkUri = new Uri(payload.NextLink);
            }
            catch (FormatException e)
            {
                throw new JsonSerializationException(
                    "Cannot deserialize continuation token. Failed to parse nextLink because it is not a valid URL.", 
                    e);
            }

            string apiVersion = ParseApiVersion(nextLinkUri.Query);

            if (string.IsNullOrWhiteSpace(apiVersion))
            {
                throw new JsonSerializationException(
                    "Cannot deserialize continuation token because the api-version is missing.");
            }

            if (apiVersion != TargetApiVersion)
            {
                string message =
                    "Cannot deserialize a continuation token for a different api-version. Token contains version " +
                    $"'{apiVersion}'; Expected version '{TargetApiVersion}'.";

                throw new JsonSerializationException(message);
            }

            return new SearchContinuationToken(payload.NextLink, payload.NextPageParameters);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = (SearchContinuationToken)value;

            var payload = 
                new Payload()
                {
                    NextLink = token.NextLink,
                    NextPageParameters = token.NextPageParameters
                };

            serializer.Serialize(writer, payload);
        }

        private static string ParseApiVersion(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            if (query[0] == '?')
            {
                query = query.Substring(1);
            }

            string[] pairs = query.Split('&');

            foreach (string pair in pairs)
            {
                string[] nameAndValue = pair.Split('=');

                if (nameAndValue.Length == 2 && nameAndValue[0] == "api-version")
                {
                    return nameAndValue[1];
                }
            }

            return null;
        }

        private class Payload
        {
            [JsonProperty("@odata.nextLink")]
            public string NextLink { get; set; }

            [JsonProperty("@search.nextPageParameters")]
            public SearchRequest NextPageParameters { get; set; }
        }
    }
}
