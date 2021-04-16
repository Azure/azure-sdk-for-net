using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

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
            private Type _type;

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
            var context = new DefaultHttpContext();
            context.Request.ContentType = contentType;
            context.Request.Method = httpMethod;
            context.Request.Headers.Add(Constants.Headers.CloudEvents.Hub, hub);
            context.Request.Headers.Add(Constants.Headers.CloudEvents.Type, GetFormedType(type, eventName));
            context.Request.Headers.Add(Constants.Headers.CloudEvents.EventName, eventName);
            context.Request.Headers.Add(Constants.Headers.CloudEvents.ConnectionId, connectionId);
            context.Request.Headers.Add(Constants.Headers.CloudEvents.Signature, string.Join(',', signatures));
            if (host != null)
            {
                context.Request.Headers.Add(Constants.Headers.WebHookRequestOrigin, host);
            }
            if (userId != null)
            {
                context.Request.Headers.Add(Constants.Headers.CloudEvents.UserId, userId);
            }
            context.Request.Body = payload == null ? Stream.Null : new MemoryStream(payload);

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

            message.Properties[nameof(HttpContext)] = httpContext;

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