// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class FeatureFlagClient
    {
        private const string AcceptDateTimeFormat = "R";

        private static Response<FeatureFlag> CreateResponse(Response response)
        {
            var options = ModelReaderWriterOptions.Json;
            FeatureFlag result = FeatureFlag.DeserializeFeatureFlag(response.Content.ToObjectFromJson<JsonElement>(), options);
            return Response.FromValue(result, response);
        }

        private static Response<FeatureFlag> CreateResourceModifiedResponse(Response response)
        {
            return new NoBodyResponse<FeatureFlag>(response);
        }

        private static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            Debug.Assert(connectionString != null); // callers check this

            var parsed = ConnectionString.Parse(connectionString);

            uri = new Uri(parsed.GetRequired("Endpoint"));
            credential = parsed.GetRequired("Id");
            try
            {
                secret = Convert.FromBase64String(parsed.GetRequired("Secret"));
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Specified Secret value isn't a valid base64 string");
            }
        }

        private HttpMessage CreateNextGetFeatureFlagsRequest(string nextLink, string syncToken, string acceptDatetime, MatchConditions matchConditions, RequestContext context)
        {
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (syncToken != null)
            {
                request.Headers.SetValue("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.SetValue("Accept-Datetime", acceptDatetime);
            }
            if (matchConditions != null)
            {
                request.Headers.Add(matchConditions);
            }
            request.Headers.SetValue("Accept", "application/problem+json, application/vnd.microsoft.appconfig.kvset+json");
            return message;
        }

        private HttpMessage CreateNextGetRevisionsRequest(string nextLink, string syncToken, string acceptDatetime, RequestContext context)
        {
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            if (syncToken != null)
            {
                request.Headers.SetValue("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.SetValue("Accept-Datetime", acceptDatetime);
            }
            request.Headers.SetValue("Accept", "application/problem+json, application/vnd.microsoft.appconfig.kvset+json");
            return message;
        }

        /// <summary>
        /// Parses the response of a <see cref="GetFeatureFlags(FeatureFlagSelector, CancellationToken)"/> request.
        /// The "@nextLink" JSON property is not reliable since the service does not return a response body for 304
        /// responses. This method also attempts to extract the next link address from the "Link" header.
        /// </summary>
        private (List<FeatureFlag> Values, string NextLink) ParseGetGetFeatureFlagsResponse(Response response)
        {
            var values = new List<FeatureFlag>();
            string nextLink = null;

            if (response.Status == 200)
            {
                var document = response.ContentStream != null ? JsonDocument.Parse(response.ContentStream) : JsonDocument.Parse(response.Content);

                if (document.RootElement.TryGetProperty("items", out var itemsValue))
                {
                    foreach (var jsonItem in itemsValue.EnumerateArray())
                    {
                        FeatureFlag setting = FeatureFlag.DeserializeFeatureFlag(jsonItem, default);
                        values.Add(setting);
                    }
                }

                if (document.RootElement.TryGetProperty("@nextLink", out var nextLinkValue))
                {
                    nextLink = nextLinkValue.GetString();
                }
            }

            // The "Link" header is formatted as:
            // <nextLink>; rel="next"
            if (nextLink == null && response.Headers.TryGetValue("Link", out string linkHeader))
            {
                int nextLinkEndIndex = linkHeader.IndexOf('>');
                nextLink = linkHeader.Substring(1, nextLinkEndIndex - 1);
            }

            return (values, nextLink);
        }
    }
}
