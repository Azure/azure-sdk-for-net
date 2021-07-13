// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubRequestBinding : BindingBase<WebPubSubRequestAttribute>
    {
        private const string HttpRequestName = "$request";
        private readonly Type _userType;
        private readonly WebPubSubOptions _options;

        public WebPubSubRequestBinding(
            BindingProviderContext context,
            IConfiguration configuration,
            INameResolver nameResolver,
            WebPubSubOptions options) : base(context, configuration, nameResolver)
        {
            _userType = context.Parameter.ParameterType;
            _options = options;
        }

        protected async override Task<IValueProvider> BuildAsync(WebPubSubRequestAttribute attrResolved, IReadOnlyDictionary<string, object> bindingData)
        {
            if (bindingData == null)
            {
                throw new ArgumentNullException(nameof(bindingData));
            }
            bindingData.TryGetValue(HttpRequestName, out var httpRequest);
            var request = httpRequest as HttpRequest;

            var httpContext = request?.HttpContext;

            if (httpContext == null)
            {
                return new WebPubSubRequestValueProvider(new WebPubSubRequest(null, new InvalidRequest(HttpStatusCode.BadRequest), HttpStatusCode.BadRequest), _userType);
            }

            // Build abuse response
            if (Utilities.RespondToServiceAbuseCheck(httpContext.Request, _options.AllowedHosts, out var abuseResponse))
            {
                var abuseRequest = new WebPubSubRequest(null, new ValidationRequest(abuseResponse.StatusCode == HttpStatusCode.OK), abuseResponse);
                return new WebPubSubRequestValueProvider(abuseRequest, _userType);
            }

            // Build service request context
            if (!TryParseRequest(request, out var connectionContext))
            {
                // Not valid WebPubSubRequest
                return new WebPubSubRequestValueProvider(new WebPubSubRequest(connectionContext, new InvalidRequest(HttpStatusCode.BadRequest, Constants.ErrorMessages.NotValidWebPubSubRequest), HttpStatusCode.BadRequest), _userType);
            }

            // Signature check
            // TODO: make the check more accurate for current function instead from global settings.
            if (!Utilities.ValidateSignature(connectionContext.ConnectionId, connectionContext.Signature, _options.AccessKeys))
            {
                return new WebPubSubRequestValueProvider(new WebPubSubRequest(connectionContext, new InvalidRequest(HttpStatusCode.Unauthorized, Constants.ErrorMessages.SignatureValidationFailed), HttpStatusCode.Unauthorized), _userType);
            }

            WebPubSubRequest wpsRequest;
            var requestType = Utilities.GetRequestType(connectionContext.EventType, connectionContext.EventName);

            switch (requestType)
            {
                case RequestType.Connect:
                    {
                        var content = await ReadString(request.Body).ConfigureAwait(false);
                        var eventRequest = JsonConvert.DeserializeObject<ConnectEventRequest>(content);
                        wpsRequest = new WebPubSubRequest(connectionContext, eventRequest);
                    }
                    break;
                case RequestType.Connected:
                    {
                        wpsRequest = new WebPubSubRequest(connectionContext, new ConnectedEventRequest());
                    }
                    break;
                case RequestType.Disconnected:
                    {
                        var content = await ReadString(request.Body).ConfigureAwait(false);
                        var eventRequest = JsonConvert.DeserializeObject<DisconnectedEventRequest>(content);
                        wpsRequest = new WebPubSubRequest(connectionContext, eventRequest);
                    }
                    break;
                case RequestType.User:
                    {
                        var contentType = MediaTypeHeaderValue.Parse(request.ContentType);
                        if (!Utilities.ValidateMediaType(contentType.MediaType, out var dataType))
                        {
                            var invalidRequest = new InvalidRequest(HttpStatusCode.BadRequest, $"{Constants.ErrorMessages.NotSupportedDataType}{request.ContentType}");
                            return new WebPubSubRequestValueProvider(new WebPubSubRequest(connectionContext, invalidRequest, HttpStatusCode.BadRequest), _userType);
                        }
                        var payload = ReadBytes(request.Body);
                        var eventRequest = new MessageEventRequest(BinaryData.FromBytes(payload), dataType);
                        wpsRequest = new WebPubSubRequest(connectionContext, eventRequest);
                    }
                    break;
                default:
                    wpsRequest = new WebPubSubRequest(connectionContext, new InvalidRequest(HttpStatusCode.NotFound, "Unknown request"));
                    break;
            }

            return new WebPubSubRequestValueProvider(wpsRequest, _userType);
        }

        private static bool TryParseRequest(HttpRequest request, out ConnectionContext context)
        {
            // ConnectionId is required in upstream request, and method is POST.
            if (!request.Headers.ContainsKey(Constants.Headers.CloudEvents.ConnectionId)
                || !request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                context = null;
                return false;
            }

            context = new ConnectionContext();
            try
            {
                context.ConnectionId = GetHeaderValueOrDefault(request.Headers, Constants.Headers.CloudEvents.ConnectionId);
                context.Hub = GetHeaderValueOrDefault(request.Headers, Constants.Headers.CloudEvents.Hub);
                context.EventType = Utilities.GetEventType(GetHeaderValueOrDefault(request.Headers, Constants.Headers.CloudEvents.Type));
                context.EventName = GetHeaderValueOrDefault(request.Headers, Constants.Headers.CloudEvents.EventName);
                context.Signature = GetHeaderValueOrDefault(request.Headers, Constants.Headers.CloudEvents.Signature);
                context.Headers = request.Headers.ToDictionary(x => x.Key, v => new StringValues(v.Value.ToArray()), StringComparer.OrdinalIgnoreCase);

                // UserId is optional, e.g. connect
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.UserId))
                {
                    context.UserId = GetHeaderValueOrDefault(request.Headers, Constants.Headers.CloudEvents.UserId);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static async Task<string> ReadString(Stream body)
        {
            string payload;
            using var ms = new MemoryStream();
            await body.CopyToAsync(ms).ConfigureAwait(false);
            ms.Position = 0;
            body.Position = 0;
            using var reader = new StreamReader(ms);
            payload = await reader.ReadToEndAsync().ConfigureAwait(false);
            return payload;
        }

        private static byte[] ReadBytes(Stream body)
        {
            using var ms = new MemoryStream();
            body.CopyTo(ms);
            return ms.ToArray();
        }

        private static string GetHeaderValueOrDefault(IHeaderDictionary header, string key)
        {
            return header.TryGetValue(key, out var value) ? value[0] : null;
        }
    }
}
