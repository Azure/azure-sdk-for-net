// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerDispatcher : ISignalRTriggerDispatcher
    {
        private readonly Dictionary<(string Hub, string Category, string @Event), SignalRMethodExecutor> _executors =
            new(TupleStringIgnoreCasesComparer.Instance);

        private readonly IRequestResolver _resolver;

        public SignalRTriggerDispatcher(IRequestResolver resolver = null)
        {
            _resolver = resolver ?? new SignalRRequestResolver();
        }

        public void Map((string HubName, string Category, string @Event) key, ExecutionContext executor)
        {
            if (!_executors.ContainsKey(key))
            {
                if (string.Equals(key.Category, Category.Connections, StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(key.@Event, Event.Connected, StringComparison.OrdinalIgnoreCase))
                    {
                        _executors.Add(key, new SignalRConnectMethodExecutor(_resolver, executor));
                        return;
                    }
                    if (string.Equals(key.@Event, Event.Disconnected, StringComparison.OrdinalIgnoreCase))
                    {
                        _executors.Add(key, new SignalRDisconnectMethodExecutor(_resolver, executor));
                        return;
                    }
                    throw new SignalRTriggerException($"Event {key.@Event} is not supported in connections");
                }
                if (string.Equals(key.Category, Category.Messages, StringComparison.OrdinalIgnoreCase))
                {
                    _executors.Add(key, new SignalRInvocationMethodExecutor(_resolver, executor));
                    return;
                }
                throw new SignalRTriggerException($"Category {key.Category} is not supported");
            }

            throw new SignalRTriggerException(
                $"Duplicated key parameter hub: {key.HubName}, category: {key.Category}, event: {key.@Event}");
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, CancellationToken token = default)
        {
            // TODO: More details about response
            if (!_resolver.ValidateContentType(req))
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            if (!SignalRTriggerDispatcher.TryGetDispatchingKey(req, out var key))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (_executors.TryGetValue(key, out var executor))
            {
                try
                {
                    return await executor.ExecuteAsync(req).ConfigureAwait(false);
                }
                //TODO: Different response for more details exceptions
                catch (SignalRTriggerAuthorizeFailedException ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        ReasonPhrase = ex.Message
                    };
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        ReasonPhrase = ex.Message
                    };
                }
            }

            // No target hub in functions
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private static bool TryGetDispatchingKey(HttpRequestMessage request, out (string Hub, string Category, string @Event) key)
        {
            key.Hub = request.Headers.GetValues(Constants.AsrsHubNameHeader).First();
            key.Category = request.Headers.GetValues(Constants.AsrsCategory).First();
            key.@Event = request.Headers.GetValues(Constants.AsrsEvent).First();
            return !string.IsNullOrEmpty(key.Hub) &&
                   !string.IsNullOrEmpty(key.Category) &&
                   !string.IsNullOrEmpty(key.@Event);
        }
    }
}