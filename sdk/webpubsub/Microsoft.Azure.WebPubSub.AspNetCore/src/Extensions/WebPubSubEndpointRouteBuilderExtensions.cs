// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebPubSub.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extensions for <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    public static class WebPubSubEndpointRouteBuilderExtensions
    {
        /// <summary>
        /// Maps the <see cref="WebPubSubHub"/> to the path <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="THub">User implemented <see cref="WebPubSubHub"/>.
        /// Name of the class has to match the name of the hub in the Azure portal.</typeparam>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <param name="path">The path to map the <see cref="WebPubSubHub"/>.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/>.</returns>
        public static IEndpointConventionBuilder MapWebPubSubHub<THub>(
            this IEndpointRouteBuilder endpoints,
            string path) where THub: WebPubSubHub
            => MapWebPubSubHub<THub>(endpoints, path, typeof(THub).Name);

        /// <summary>
        /// Maps the <see cref="WebPubSubHub"/> to the path "/client" with the specified hub name.
        /// </summary>
        /// <typeparam name="THub">User implemented <see cref="WebPubSubHub"/>.</typeparam>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <param name="path">The path to map the <see cref="WebPubSubHub"/>.</param>
        /// <param name="hubName">The name of the hub to connect to.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/>.</returns>
        public static IEndpointConventionBuilder MapWebPubSubHub<THub>(
            this IEndpointRouteBuilder endpoints, string path,
            string hubName) where THub : WebPubSubHub
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }
            if (string.IsNullOrEmpty(hubName))
            {
                throw new ArgumentNullException(nameof(hubName));
            }

            var marker = endpoints.ServiceProvider.GetService<WebPubSubMarkerService>() ?? throw new InvalidOperationException(
                    "Unable to find the required services. Please add all the required services by calling " +
                    "'IServiceCollection.AddWebPubSub' inside the call to 'ConfigureServices(...)' in the application startup code.");

            var adaptor = endpoints.ServiceProvider.GetService<ServiceRequestHandlerAdapter>();
            adaptor.RegisterHub<THub>(hubName);

            var app = endpoints.CreateApplicationBuilder();
            app.UseMiddleware<WebPubSubMiddleware>();

            return endpoints.Map(path, app.Build());
        }
    }
}