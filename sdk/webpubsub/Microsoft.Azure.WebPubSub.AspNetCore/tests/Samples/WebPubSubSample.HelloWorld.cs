// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP || SNIPPET
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests.Samples
{
    public class WebPubSubSample
    {
        #region Snippet:WebPubSubDependencyInjection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebPubSub(o =>
            {
                o.ServiceEndpoint = new("<connection-string>");
            }).AddWebPubSubServiceClient<SampleHub>();
        }
        #endregion

        #region Snippet:WebPubSubMapHub
        public void Configure(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapWebPubSubHub<SampleHub>("/eventhandler");
            });
        }
        #endregion

        #region Snippet:HandleConnectEvent
        private sealed class SampleHub : WebPubSubHub
        {
            internal WebPubSubServiceClient<SampleHub> _serviceClient;

            // Need to ensure service client is injected by call `AddServiceHub<SampleHub>` in ConfigureServices.
            public SampleHub(WebPubSubServiceClient<SampleHub> serviceClient)
            {
                _serviceClient = serviceClient;
            }

            public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                var response = new ConnectEventResponse
                {
                    UserId = request.ConnectionContext.UserId
                };
                return new ValueTask<ConnectEventResponse>(response);
            }
        }
        #endregion

        #region Snippet:HandleMqttConnectEvent
        private sealed class SampleHub2 : WebPubSubHub
        {
            internal WebPubSubServiceClient<SampleHub> _serviceClient;

            // Need to ensure service client is injected by call `AddServiceHub<SampleHub2>` in ConfigureServices.
            public SampleHub2(WebPubSubServiceClient<SampleHub> serviceClient)
            {
                _serviceClient = serviceClient;
            }

            public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                // By converting the request to MqttConnectEventRequest, you can get the MQTT specific information.
                if (request is MqttConnectEventRequest mqttRequest)
                {
                    if (mqttRequest.Mqtt.Username != "baduser")
                    {
                        var response = mqttRequest.CreateMqttResponse(mqttRequest.ConnectionContext.UserId, null, null);
                        // You can customize the user properties that will be sent to the client in the MQTT CONNACK packet.
                        response.Mqtt.UserProperties = new List<MqttUserProperty>()
                        {
                            new("name", "value")
                        };
                        return ValueTask.FromResult(response as ConnectEventResponse);
                    }
                    else
                    {
                        var errorResponse = mqttRequest.Mqtt.ProtocolVersion switch
                        {
                            // You can specify the MQTT specific error code and message.
                            MqttProtocolVersion.V311 => mqttRequest.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.NotAuthorized, "not authorized"),
                            MqttProtocolVersion.V500 => mqttRequest.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.Banned, "The user is banned."),
                            _ => throw new System.NotSupportedException("Unsupported MQTT protocol version")
                        };
                        // You can customize the user properties that will be sent to the client in the MQTT CONNACK packet.
                        errorResponse.Mqtt.UserProperties = new List<MqttUserProperty>()
                        {
                            new("name", "value")
                        };
                        throw new MqttConnectionException(errorResponse);
                    }
                }
                else
                {
                    // If you don't need to handle MQTT specific logic, you can still return a general response for MQTT clients.
                    return ValueTask.FromResult(request.CreateResponse(request.ConnectionContext.UserId, null, request.Subprotocols.FirstOrDefault(), null));
                }
            }
        }
        #endregion

        #region Snippet:HandleMqttConnectedEvent
        private sealed class SampleHub3 : WebPubSubHub
        {
            internal WebPubSubServiceClient<SampleHub> _serviceClient;

            // Need to ensure service client is injected by call `AddServiceHub<SampleHub3>` in ConfigureServices.
            public SampleHub3(WebPubSubServiceClient<SampleHub> serviceClient)
            {
                _serviceClient = serviceClient;
            }

            public override Task OnConnectedAsync(ConnectedEventRequest request)
            {
                if (request.ConnectionContext is MqttConnectionContext mqttContext)
                {
                    // Have your own logic here
                }
                return Task.CompletedTask;
            }
        }
        #endregion

        #region Snippet:HandleMqttDisconnectedEvent
        private sealed class SampleHub4 : WebPubSubHub
        {
            internal WebPubSubServiceClient<SampleHub> _serviceClient;

            // Need to ensure service client is injected by call `AddServiceHub<SampleHub4>` in ConfigureServices.
            public SampleHub4(WebPubSubServiceClient<SampleHub> serviceClient)
            {
                _serviceClient = serviceClient;
            }

            public override Task OnDisconnectedAsync(DisconnectedEventRequest request)
            {
                if (request is MqttDisconnectedEventRequest mqttDisconnected)
                {
                    // Have your own logic here
                }
                return Task.CompletedTask;
            }
        }
        #endregion
    }
}
#endif

