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
        /// <typeparam name="THub">User implemented <see cref="WebPubSubHub"/>.</typeparam>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <param name="path">The path to map the <see cref="WebPubSubHub"/>.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/>.</returns>
        public static IEndpointConventionBuilder MapWebPubSubHub<THub>(
            this IEndpointRouteBuilder endpoints,
            string path) where THub: WebPubSubHub
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            var marker = endpoints.ServiceProvider.GetService<WebPubSubMarkerService>() ?? throw new InvalidOperationException(
                    "Unable to find the required services. Please add all the required services by calling " +
                    "'IServiceCollection.AddWebPubSub' inside the call to 'ConfigureServices(...)' in the application startup code.");

            var adaptor = endpoints.ServiceProvider.GetService<ServiceRequestHandlerAdapter>();
            adaptor.RegisterHub<THub>();

            var app = endpoints.CreateApplicationBuilder();
            app.UseMiddleware<WebPubSubMiddleware>();

            return endpoints.Map(path, app.Build());
        }
    }
}