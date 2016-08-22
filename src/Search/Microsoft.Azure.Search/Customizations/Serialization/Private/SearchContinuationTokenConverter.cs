// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using Models;
    using Newtonsoft.Json;

    internal class SearchContinuationTokenConverter : ConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SearchContinuationToken);
        }

        public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
        {
            SearchContinuationTokenPayload payload = serializer.Deserialize<SearchContinuationTokenPayload>(reader);

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

            if (apiVersion != Consts.TargetApiVersion)
            {
                const string MessageFormat =
                    "Cannot deserialize a continuation token for a different api-version. Token contains version " +
                    "'{0}'; Expected version '{1}'.";

                string message = string.Format(MessageFormat, apiVersion, Consts.TargetApiVersion);
                throw new JsonSerializationException(message);
            }

            return new SearchContinuationToken(payload.NextLink, payload.NextPageParameters);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            SearchContinuationToken token = (SearchContinuationToken)value;

            var payload = 
                new SearchContinuationTokenPayload()
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
    }
}
