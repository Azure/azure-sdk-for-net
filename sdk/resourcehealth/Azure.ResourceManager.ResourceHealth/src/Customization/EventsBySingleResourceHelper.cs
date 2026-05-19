// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ResourceHealth
{
    internal sealed class EventsBySingleResourceHelper : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Events _restClient;
        private readonly ResourceIdentifier _scope;

        // This ArmResource shim exists so the compatibility pageable can reuse the generated REST client methods,
        // because the generator emitted CreateGetBySingleResourceRequest/CreateNextGetBySingleResourceRequest but not the public pageable API.
        internal EventsBySingleResourceHelper(ArmClient client, ResourceIdentifier scope) : base(client, scope)
        {
            _scope = scope;
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ResourceHealth", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _restClient = new Events(_clientDiagnostics, Pipeline, Endpoint, "2025-05-01");
        }

        // Manually drives the generated REST requests because Azure.Core.Page<Event> under ArmProviderActionSync did not produce a generated CollectionResult/public pageable method;
        // replacing this would require the spec to use a custom list result model with explicit @pageItems/@nextLink.
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

        // Async counterpart to GetPages for the same generator gap; it preserves the GA-compatible public shape without changing the shared TypeSpec response model.
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
