// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP || SNIPPET
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

            public override ValueTask<WebPubSubEventResponse> OnMqttConnectAsync(MqttConnectEventRequest request, CancellationToken cancellationToken)
            {
                if (request.Mqtt.Username != "baduser")
                {
                    return ValueTask.FromResult(request.CreateMqttResponse(request.ConnectionContext.UserId, null, null) as WebPubSubEventResponse);
                }
                else
                {
                    return request.Mqtt.ProtocolVersion switch
                    {
                        MqttProtocolVersion.V311 => ValueTask.FromResult(request.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.NotAuthorized, "not authorized") as WebPubSubEventResponse),
                        MqttProtocolVersion.V500 => ValueTask.FromResult(request.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.NotAuthorized, "not authorized") as WebPubSubEventResponse),
                        _ => throw new System.NotSupportedException("Unsupported MQTT protocol version")
                    };
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

