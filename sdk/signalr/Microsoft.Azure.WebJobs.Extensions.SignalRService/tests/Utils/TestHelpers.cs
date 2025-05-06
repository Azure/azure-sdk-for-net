// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Constants = Microsoft.Azure.WebJobs.Extensions.SignalRService.Constants;

namespace SignalRServiceExtension.Tests.Utils
{
    internal static class TestHelpers
    {
        public static IHost NewHost(Type type, SignalRConfigProvider ext = null, Dictionary<string, string> configuration = null, ILoggerProvider loggerProvider = null)
        {
            var builder = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ITypeLocator>(new FakeTypeLocator(type));
                    if (ext != null)
                    {
                        services.AddSingleton<IExtensionConfigProvider>(ext);
                    }
                    services.AddSingleton<IExtensionConfigProvider>(new TestExtensionConfig());
                    services.AddAzureClientsCore();
                })
                .ConfigureWebJobs(webJobsBuilder =>
                {
                    webJobsBuilder.AddSignalR();
                    webJobsBuilder.UseHostId(Guid.NewGuid().ToString("n"));
                    webJobsBuilder.Services.AddSingleton<IEndpointRouter>(new TestRouter());
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddProvider(loggerProvider);
                });

            if (configuration != null)
            {
                builder.ConfigureAppConfiguration(b =>
                {
                    b.AddInMemoryCollection(configuration);
                });
            }

            return builder.Build();
        }

        public static JobHost GetJobHost(this IHost host)
        {
            return host.Services.GetService<IJobHost>() as JobHost;
        }

        public static HttpRequestMessage CreateHttpRequestMessage(string hub, string category, string @event, string connectionId,
            string contentType = Constants.JsonContentType, byte[] content = null, string[] signatures = null)
        {
            var context = new DefaultHttpContext();
            context.Request.ContentType = contentType;
            context.Request.Method = "Post";
            context.Request.Headers.Append(Constants.AsrsHubNameHeader, hub);
            context.Request.Headers.Append(Constants.AsrsCategory, category);
            context.Request.Headers.Append(Constants.AsrsEvent, @event);
            context.Request.Headers.Append(Constants.AsrsConnectionIdHeader, connectionId);
            if (signatures != null)
            {
                context.Request.Headers.Append(Constants.AsrsSignature, string.Join(",", signatures));
            }
            context.Request.Body = content == null ? Stream.Null : new MemoryStream(content);

            return CreateHttpRequestMessageFromContext(context);
        }

        private static HttpRequestMessage CreateHttpRequestMessageFromContext(HttpContext httpContext)
        {
            var httpRequest = httpContext.Request;
            var uriString =
                httpRequest.Scheme + "://" +
                httpRequest.Host +
                httpRequest.PathBase +
                httpRequest.Path +
                httpRequest.QueryString;

            var message = new HttpRequestMessage(new HttpMethod(httpRequest.Method), uriString);

            // This allows us to pass the message through APIs defined in legacy code and then
            // operate on the HttpContext inside.
#if NET5_0_OR_GREATER
            message.Options.Set(new HttpRequestOptionsKey<HttpContext>(nameof(HttpContext)), httpContext);
#else
            message.Properties[nameof(HttpContext)] = httpContext;
#endif
            message.Content = new StreamContent(httpRequest.Body);

            foreach (var header in httpRequest.Headers)
            {
                // Every header should be able to fit into one of the two header collections.
                // Try message.Headers first since that accepts more of them.
                if (!message.Headers.TryAddWithoutValidation(header.Key, (IEnumerable<string>)header.Value))
                {
                    message.Content.Headers.TryAddWithoutValidation(header.Key, (IEnumerable<string>)header.Value);
                }
            }

            return message;
        }
    }
}