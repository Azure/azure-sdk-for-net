// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            WebPubSubOptions options) : base (context, configuration, nameResolver)
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
                return new WebPubSubRequestValueProvider(new WebPubSubRequest(null, WebPubSubRequestStatus.Unknown, HttpStatusCode.BadRequest), _userType);
            }

            // Build abuse response
            if (Utilities.RespondToServiceAbuseCheck(httpContext.Request, _options.AllowedHosts, out var abuseResponse))
            {
                var abuseRequest = new WebPubSubRequest(null, WebPubSubRequestStatus.RequestValid, abuseResponse)
                {
                    IsAbuseRequest = true
                };
                return new WebPubSubRequestValueProvider(abuseRequest, _userType);
            }

            // Build service request context
            if (!TryParseRequest(request, out var connectionContext))
            {
                // Not valid WebPubSubRequest
                return new WebPubSubRequestValueProvider(new WebPubSubRequest(connectionContext, WebPubSubRequestStatus.Unknown, HttpStatusCode.BadRequest), _userType);
            }

            // Signature check
            if (!Utilities.ValidateSignature(connectionContext.ConnectionId, connectionContext.Signature, _options.AccessKeys))
            {
                return new WebPubSubRequestValueProvider(new WebPubSubRequest(connectionContext, WebPubSubRequestStatus.SignatureInvalid, HttpStatusCode.Unauthorized), _userType);
            }

            var wpsRequest = new WebPubSubRequest(connectionContext, WebPubSubRequestStatus.RequestValid);
            var requestType = Utilities.GetRequestType(connectionContext.EventType, connectionContext.EventName);

            // Build request body and reset head to avoid break normal HttpRequest.
            var streamContent = new MemoryStream();
            await request.Body.CopyToAsync(streamContent).ConfigureAwait(false);
            request.Body.Position = 0;

            switch (requestType)
            {
                case RequestType.Connect:
                    using (var sr = new StreamReader(streamContent))
                    {
                        var content = await sr.ReadToEndAsync().ConfigureAwait(false);
                        wpsRequest.Request = JsonConvert.DeserializeObject<ConnectEventRequest>(content);
                    }
                    break;
                case RequestType.Disconnect:
                    using (var sr = new StreamReader(streamContent))
                    {
                        var content = await sr.ReadToEndAsync().ConfigureAwait(false);
                        wpsRequest.Request = JsonConvert.DeserializeObject<DisconnectEventRequest>(content);
                    }
                    break;
                case RequestType.User:
                    var contentType = MediaTypeHeaderValue.Parse(request.ContentType);
                    if (!Utilities.ValidateMediaType(contentType.MediaType, out var dataType))
                    {
                        return new WebPubSubRequestValueProvider(new WebPubSubRequest(connectionContext, WebPubSubRequestStatus.ContentTypeInvalid, HttpStatusCode.BadRequest), _userType);
                    }
                    wpsRequest.Request = new MessageEventRequest(BinaryData.FromBytes(streamContent.ToArray()), dataType);
                    break;
                default:
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

        private static string GetHeaderValueOrDefault(IHeaderDictionary header, string key)
        {
            return header.TryGetValue(key, out var value) ? value[0] : string.Empty;
        }
    }
}
