// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        private readonly Dictionary<(string hub, string category, string @event), SignalRMethodExecutor> _executors =
            new Dictionary<(string, string, string), SignalRMethodExecutor>(TupleStringIgnoreCasesComparer.Instance);

        private readonly IRequestResolver _resolver;

        public SignalRTriggerDispatcher(IRequestResolver resolver = null)
        {
            _resolver = resolver ?? new SignalRRequestResolver();
        }

        public void Map((string hubName, string category, string @event) key, ExecutionContext executor)
        {
            if (!_executors.ContainsKey(key))
            {
                if (string.Equals(key.category, Category.Connections, StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(key.@event, Event.Connected, StringComparison.OrdinalIgnoreCase))
                    {
                        _executors.Add(key, new SignalRConnectMethodExecutor(_resolver, executor));
                        return;
                    }
                    if (string.Equals(key.@event, Event.Disconnected, StringComparison.OrdinalIgnoreCase))
                    {
                        _executors.Add(key, new SignalRDisconnectMethodExecutor(_resolver, executor));
                        return;
                    }
                    throw new SignalRTriggerException($"Event {key.@event} is not supported in connections");
                }
                if (string.Equals(key.category, Category.Messages, StringComparison.OrdinalIgnoreCase))
                {
                    _executors.Add(key, new SignalRInvocationMethodExecutor(_resolver, executor));
                    return;
                }
                throw new SignalRTriggerException($"Category {key.category} is not supported");
            }

            throw new SignalRTriggerException(
                $"Duplicated key parameter hub: {key.hubName}, category: {key.category}, event: {key.@event}");
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, CancellationToken token = default)
        {
            // TODO: More details about response
            if (!_resolver.ValidateContentType(req))
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            if (!TryGetDispatchingKey(req, out var key))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (_executors.TryGetValue(key, out var executor))
            {
                try
                {
                    return await executor.ExecuteAsync(req);
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

        private bool TryGetDispatchingKey(HttpRequestMessage request, out (string hub, string category, string @event) key)
        {
            key.hub = request.Headers.GetValues(Constants.AsrsHubNameHeader).First();
            key.category = request.Headers.GetValues(Constants.AsrsCategory).First();
            key.@event = request.Headers.GetValues(Constants.AsrsEvent).First();
            return !string.IsNullOrEmpty(key.hub) &&
                   !string.IsNullOrEmpty(key.category) &&
                   !string.IsNullOrEmpty(key.@event);
        }
    }
}