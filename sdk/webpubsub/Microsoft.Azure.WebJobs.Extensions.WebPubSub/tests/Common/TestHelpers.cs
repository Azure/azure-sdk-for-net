// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    internal static class TestHelpers
    {
        public static IHost NewHost(Type type, WebPubSubConfigProvider ext = null, Dictionary<string, string> configuration = null, ILoggerProvider loggerProvider = null)
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
                })
                .ConfigureWebJobs(webJobsBuilder =>
                {
                    webJobsBuilder.AddWebPubSub();
                    webJobsBuilder.UseHostId(Guid.NewGuid().ToString("n"));
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

        private sealed class FakeTypeLocator : ITypeLocator
        {
            private readonly Type _type;

            public FakeTypeLocator(Type type)
            {
                _type = type;
            }

            public IReadOnlyList<Type> GetTypes()
            {
                return new Type[] { _type };
            }
        }

        public static JobHost GetJobHost(this IHost host)
        {
            return host.Services.GetService<IJobHost>() as JobHost;
        }

        private static string GetFormedType(WebPubSubEventType type, string eventName)
        {
            return type == WebPubSubEventType.User ?
                $"{Constants.Headers.CloudEvents.TypeUserPrefix}{eventName}" :
                $"{Constants.Headers.CloudEvents.TypeSystemPrefix}{eventName}";
        }

        public static HttpRequestMessage CreateHttpRequestMessage(
            string hub,
            WebPubSubEventType type,
            string eventName,
            string connectionId,
            string[] signatures,
            string contentType = Constants.ContentTypes.PlainTextContentType,
            string httpMethod = "Post",
            string host = null,
            string userId = "testuser",
            byte[] payload = null)
        {
            var context = new HttpRequestMessage()
            {
                Method = new HttpMethod(httpMethod)
            };
            context.Headers.Add(Constants.Headers.CloudEvents.Hub, hub);
            context.Headers.Add(Constants.Headers.CloudEvents.Type, GetFormedType(type, eventName));
            context.Headers.Add(Constants.Headers.CloudEvents.EventName, eventName);
            context.Headers.Add(Constants.Headers.CloudEvents.ConnectionId, connectionId);
            context.Headers.Add(Constants.Headers.CloudEvents.Signature, string.Join(",", signatures));
            if (host != null)
            {
                context.Headers.Add(Constants.Headers.WebHookRequestOrigin, host);
            }
            if (userId != null)
            {
                context.Headers.Add(Constants.Headers.CloudEvents.UserId, userId);
            }

            if (payload != null)
            {
                context.Content = new StreamContent(new MemoryStream(payload));
                context.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            }

            foreach (var header in context.Headers)
            {
                context.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return context;
        }
    }
}