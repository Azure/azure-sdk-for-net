// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
#region Snippet:Functions_EventHubs_ConfigureClientOptions

#if SNIPPET
    [assembly: FunctionsStartup(typeof(<< MyNamespace >>.ConfigureClientOptions))]
#endif

    public class ConfigureClientOptions : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder hostBuilder)
        {
            var builder = hostBuilder.Services.AddWebJobs(_ => { });

            // This method allows you to configure the options used to
            // create the Event Hubs clients.
            //
            // In this example, we're setting the transport type to
            // use web sockets so that traffic is directed over port 443
            // instead of 5671 and 5672, which are blocked by some networks.

            builder.AddEventHubs(options =>
            {
                options.TransportType = EventHubsTransportType.AmqpWebSockets;
            });

            builder.AddBuiltInBindings();
            builder.AddExecutionContextBinding();
        }
    }
#endregion
}
