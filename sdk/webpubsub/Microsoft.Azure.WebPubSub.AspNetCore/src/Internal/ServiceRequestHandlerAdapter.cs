// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class ServiceRequestHandlerAdapter : ServiceRequestHandler
    {
        private readonly WebPubSubValidationOptions _options;

        public ServiceRequestHandlerAdapter(WebPubSubValidationOptions options)
        {
            _options = options;
        }

        public override async Task HandleRequest<THub>(HttpContext context, THub serviceHub)
        {
            HttpRequest request = context.Request;

            if (context == null)
            {
                return;
            }

            // abuse protection validation.
            if (request.IsValidationRequest(out ValidationRequest validationRequest))
            {
                if (_options != null)
                {
                    foreach (var item in validationRequest.RequestHosts)
                    {
                        if (_options.ContainsHost(item))
                        {
                            // return self as AllowedHost.
                            context.Response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, item);
                            return;
                        }
                    }
                }
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Abuse Protection validation failed.").ConfigureAwait(false);
                return;
            }

            if (!request.TryParseCloudEvents(out ConnectionContext connectionContext))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Unknown upstream request.").ConfigureAwait(false);
                return;
            }

            // Signature check
            if (!connectionContext.IsValidSignature(_options))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Signature validation failed.").ConfigureAwait(false);
                return;
            }

            RequestType requestType = connectionContext.GetRequestType();
            var serviceRequest = await request.ToServiceRequest(connectionContext).ConfigureAwait(false);
            switch (requestType)
            {
                case RequestType.Connect:
                    {
                        var eventRequest = serviceRequest as ConnectEventRequest;
                        var response = await serviceHub.Connect(eventRequest).ConfigureAwait(false);
                        if (response is ErrorResponse error)
                        {
                            context.Response.StatusCode = error.Code.ToStatusCode();
                            context.Response.ContentType = Constants.ContentTypes.PlainTextContentType;
                            await context.Response.WriteAsync(error.ErrorMessage).ConfigureAwait(false);
                            return;
                        }
                        else if (response is ConnectResponse connectResponse)
                        {
                            SetConnectionState(ref context, connectionContext, response);
                            await context.Response.WriteAsync(JsonSerializer.Serialize(connectResponse)).ConfigureAwait(false);
                            return;
                        }
                    }
                    break;
                case RequestType.User:
                    {
                        if (serviceRequest is InvalidRequest invalid)
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync(invalid.ErrorMessage).ConfigureAwait(false);
                            return;
                        }
                        var eventRequest = serviceRequest as MessageEventRequest;
                        var response = await serviceHub.Message(eventRequest).ConfigureAwait(false);
                        if (response is ErrorResponse error)
                        {
                            context.Response.StatusCode = error.Code.ToStatusCode();
                            context.Response.ContentType = Constants.ContentTypes.PlainTextContentType;
                            await context.Response.WriteAsync(error.ErrorMessage).ConfigureAwait(false);
                            return;
                        }
                        else if (response is MessageResponse msgResponse)
                        {
                            SetConnectionState(ref context, connectionContext, response);
                            context.Response.ContentType = msgResponse.DataType.ToContentType();
                            var payload = msgResponse.Message.ToArray();
                            await context.Response.Body.WriteAsync(payload, 0, payload.Length).ConfigureAwait(false);
                            return;
                        }
                    }
                    break;
                case RequestType.Connected:
                    {
                        var eventRequest = serviceRequest as ConnectedEventRequest;
                        await serviceHub.Connected(eventRequest).ConfigureAwait(false);
                    }
                    break;
                case RequestType.Disconnected:
                    {
                        var eventRequest = serviceRequest as DisconnectedEventRequest;
                        await serviceHub.Disconnected(eventRequest).ConfigureAwait(false);
                    }
                    break;
                default:
                    break;
            }
        }

        private static void SetConnectionState(ref HttpContext context, ConnectionContext connectionContext, ServiceResponse response)
        {
            if (connectionContext.States?.Count > 0 || response.States?.Count > 0)
            {
                var states = connectionContext.States.UpdateStates(response.States);
                if (states?.Count > 0)
                {
                    context.Response.Headers.Add(Constants.Headers.CloudEvents.State, states.ToHeaderStates());
                }
            }
        }
    }
}
