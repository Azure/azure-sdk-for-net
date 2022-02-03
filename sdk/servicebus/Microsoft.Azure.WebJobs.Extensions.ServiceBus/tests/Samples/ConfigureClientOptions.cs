// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
#region Snippet:Functions_ServiceBus_ConfigureClientOptions

#if SNIPPET
    [assembly: FunctionsStartup(typeof(<< MyNamespace >>.ConfigureClientOptions))]
#endif

    public class ConfigureClientOptions : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder hostBuilder)
        {
            var builder = hostBuilder.Services.AddWebJobs(_ => { });

            // This method allows you to configure the options used to
            // create the Service Bus client.
            //
            // In this example, we're setting the transport type to
            // use web sockets so that traffic is directed over port 443
            // instead of 5671 and 5672, which are blocked by some networks.

            builder.AddServiceBus(options =>
            {
                options.TransportType = ServiceBusTransportType.AmqpWebSockets;
            });

            builder.AddBuiltInBindings();
            builder.AddExecutionContextBinding();
        }
    }
#endregion
}
