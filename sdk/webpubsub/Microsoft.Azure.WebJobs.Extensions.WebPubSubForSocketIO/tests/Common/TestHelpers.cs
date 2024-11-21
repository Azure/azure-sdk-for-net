// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    internal static class TestHelpers
    {
        public static IHost NewHost(Type type, WebPubSubForSocketIOConfigProvider ext = null, Dictionary<string, string> configuration = null)
        {
            var builder = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ITypeLocator>(new FakeTypeLocator(type));
                    services.AddAzureClientsCore();
                    if (ext != null)
                    {
                        services.AddSingleton<IExtensionConfigProvider>(ext);
                    }
                    services.AddSingleton<IExtensionConfigProvider>(new TestExtensionConfig());
                })
                .ConfigureWebJobs(webJobsBuilder =>
                {
                    webJobsBuilder.AddSocketIO();
                    webJobsBuilder.UseHostId(Guid.NewGuid().ToString("n"));
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddProvider(new TestLoggerProvider());
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
            string @namespace,
            string socketId,
            WebPubSubEventType type,
            string eventName,
            string connectionId,
            string[] signatures,
            string contentType = Constants.ContentTypes.PlainTextContentType,
            string httpMethod = "Post",
            string[] origin = null,
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
            context.Headers.Add(Constants.Headers.CloudEvents.Namespace, @namespace);
            context.Headers.Add(Constants.Headers.CloudEvents.SocketId, socketId);
            if (origin != null)
            {
                context.Headers.Add(Constants.Headers.WebHookRequestOrigin, origin);
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

        public static HttpRequest CreateHttpRequest(string method, string uriString, IHeaderDictionary headers = null, string body = null)
        {
            var context = new DefaultHttpContext();
            var services = new ServiceCollection();
            var sp = services.BuildServiceProvider();
            context.RequestServices = sp;

            var uri = new Uri(uriString);
            var request = context.Request;
            var requestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            requestFeature.Method = method;
            requestFeature.Scheme = uri.Scheme;
            requestFeature.PathBase = uri.Host;
            requestFeature.Path = uri.GetComponents(UriComponents.KeepDelimiter | UriComponents.Path, UriFormat.Unescaped);
            requestFeature.PathBase = "/";
            requestFeature.QueryString = uri.GetComponents(UriComponents.KeepDelimiter | UriComponents.Query, UriFormat.Unescaped);

            headers ??= new HeaderDictionary();

            if (!string.IsNullOrEmpty(uri.Host))
            {
                headers.Add("Host", uri.Host);
                headers.Add(Constants.Headers.WebHookRequestOrigin, uri.Host);
            }

            if (body != null)
            {
                requestFeature.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                request.ContentLength = request.Body.Length;
                headers.Add("Content-Length", request.Body.Length.ToString());
            }

            requestFeature.Headers = headers;

            return request;
        }
    }
}