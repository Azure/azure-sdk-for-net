// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Infrastructure: ArmResource subclass that provides access to the Azure pipeline and the
// internal Events REST client for the "getBySingleResource" operation.
//
// Why this is needed:
// The TypeSpec generator creates the Events REST client class (with CreateGetBySingleResourceRequest
// and CreateNextGetBySingleResourceRequest) but does NOT expose a public pageable method for this
// operation on any generated resource class. Only the internal REST client exists. To preserve the
// GA 1.0.0 extension method GetHealthEventsOfSingleResource(scope, filter), we need to manually
// construct REST requests and process responses through the pipeline.
//
// This class inherits from ArmResource to get access to Pipeline, Endpoint, and Diagnostics, and
// is instantiated via ArmClient.GetCachedClient() in the pageable implementations.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> Helper to access pipeline and make REST calls for events by single resource. </summary>
    internal sealed class EventsBySingleResourceHelper : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Events _restClient;
        private readonly ResourceIdentifier _scope;

        internal EventsBySingleResourceHelper(ArmClient client, ResourceIdentifier scope) : base(client, scope)
        {
            _scope = scope;
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ResourceHealth", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _restClient = new Events(_clientDiagnostics, Pipeline, Endpoint, "2025-05-01");
        }

        /// <summary>
        /// Synchronously enumerates pages of ResourceHealthEventData for a single resource.
        /// Creates REST requests via the internal Events client, sends them through the pipeline,
        /// deserializes the JSON response, and yields pages. Handles pagination via nextLink.
        /// </summary>
        public IEnumerable<Page<ResourceHealthEventData>> GetPages(string filter, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            Uri nextLink = null;

            while (true)
            {
                HttpMessage message = nextLink == null
                    ? _restClient.CreateGetBySingleResourceRequest(_scope.ToString(), filter, context)
                    : _restClient.CreateNextGetBySingleResourceRequest(nextLink, _scope.ToString(), filter, context);

                Response response = Pipeline.ProcessMessage(message, context);
                var document = JsonDocument.Parse(response.Content);
                var items = new List<ResourceHealthEventData>();

                if (document.RootElement.TryGetProperty("value", out var valueArray))
                {
                    foreach (var item in valueArray.EnumerateArray())
                    {
                        items.Add(ResourceHealthEventData.DeserializeResourceHealthEventData(item, ModelReaderWriterOptions.Json));
                    }
                }

                string nextLinkStr = null;
                if (document.RootElement.TryGetProperty("nextLink", out var nextLinkProp))
                {
                    nextLinkStr = nextLinkProp.GetString();
                }

                yield return Page<ResourceHealthEventData>.FromValues(items, nextLinkStr, response);

                if (string.IsNullOrEmpty(nextLinkStr))
                    break;

                nextLink = new Uri(nextLinkStr);
            }
        }

        /// <summary>
        /// Asynchronously enumerates pages of ResourceHealthEventData for a single resource.
        /// Async counterpart of GetPages — uses Pipeline.ProcessMessageAsync instead of ProcessMessage.
        /// </summary>
        public async IAsyncEnumerable<Page<ResourceHealthEventData>> GetPagesAsync(string filter, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            Uri nextLink = null;

            while (true)
            {
                HttpMessage message = nextLink == null
                    ? _restClient.CreateGetBySingleResourceRequest(_scope.ToString(), filter, context)
                    : _restClient.CreateNextGetBySingleResourceRequest(nextLink, _scope.ToString(), filter, context);

                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                var document = JsonDocument.Parse(response.Content);
                var items = new List<ResourceHealthEventData>();

                if (document.RootElement.TryGetProperty("value", out var valueArray))
                {
                    foreach (var item in valueArray.EnumerateArray())
                    {
                        items.Add(ResourceHealthEventData.DeserializeResourceHealthEventData(item, ModelReaderWriterOptions.Json));
                    }
                }

                string nextLinkStr = null;
                if (document.RootElement.TryGetProperty("nextLink", out var nextLinkProp))
                {
                    nextLinkStr = nextLinkProp.GetString();
                }

                yield return Page<ResourceHealthEventData>.FromValues(items, nextLinkStr, response);

                if (string.IsNullOrEmpty(nextLinkStr))
                    break;

                nextLink = new Uri(nextLinkStr);
            }
        }
    }
}
