// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    internal partial class GlobalRulestackRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of GlobalRulestackRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public GlobalRulestackRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2025-10-08";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateListAppIdsRequest(string globalRulestackName, string appIdVersion, string appPrefix, string skip, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/", false);
            uri.AppendPath(globalRulestackName, true);
            uri.AppendPath("/listAppIds", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (appIdVersion != null)
            {
                uri.AppendQuery("appIdVersion", appIdVersion, true);
            }
            if (appPrefix != null)
            {
                uri.AppendQuery("appPrefix", appPrefix, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip, true);
            }
            if (top != null)
            {
                uri.AppendQuery("top", top.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateListCountriesRequest(string globalRulestackName, string skip, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/", false);
            uri.AppendPath(globalRulestackName, true);
            uri.AppendPath("/listCountries", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (skip != null)
            {
                uri.AppendQuery("skip", skip, true);
            }
            if (top != null)
            {
                uri.AppendQuery("top", top.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateListFirewallsRequest(string globalRulestackName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/", false);
            uri.AppendPath(globalRulestackName, true);
            uri.AppendPath("/listFirewalls", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateListPredefinedUrlCategoriesRequest(string globalRulestackName, string skip, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/PaloAltoNetworks.Cloudngfw/globalRulestacks/", false);
            uri.AppendPath(globalRulestackName, true);
            uri.AppendPath("/listPredefinedUrlCategories", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (skip != null)
            {
                uri.AppendQuery("skip", skip, true);
            }
            if (top != null)
            {
                uri.AppendQuery("top", top.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }
    }
}
