// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing
{
    internal class InstrumentationWithActivitySource : IDisposable
    {
        private const string RequestPath = "/api/request";
        private SampleServer server = new SampleServer();
        private SampleClient client = new SampleClient();

        public void Start(ushort port = 19999)
        {
            var url = $"http://localhost:{port.ToString(CultureInfo.InvariantCulture)}{RequestPath}/";
            this.server.Start(url);
            this.client.Start(url);
        }

        public void Dispose()
        {
            this.client.Dispose();
            this.server.Dispose();
        }

        private class SampleServer : IDisposable
        {
            private HttpListener listener = new HttpListener();

            public void Start(string url)
            {
                this.listener.Prefixes.Add(url);
                this.listener.Start();

                Task.Run(() =>
                {
                    using var source = new ActivitySource("Samples.SampleServer");

                    while (this.listener.IsListening)
                    {
                        try
                        {
                            var context = this.listener.GetContext();

                            using var activity = source.StartActivity(
                                $"{context.Request.HttpMethod}:{context.Request.Url.AbsolutePath}",
                                ActivityKind.Server);

                            var headerKeys = context.Request.Headers.AllKeys;
                            foreach (var headerKey in headerKeys)
                            {
                                string headerValue = context.Request.Headers[headerKey];
                                activity?.AddTag($"http.header.{headerKey}", headerValue);
                            }

                            activity?.AddTag("http.url", context.Request.Url.AbsolutePath);

                            string requestContent;
                            using (var childSpan = source.StartActivity("ReadStream", ActivityKind.Consumer))
                            using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                            {
                                requestContent = reader.ReadToEnd();
                                childSpan.AddEvent(new ActivityEvent("StreamReader.ReadToEnd"));
                            }

                            activity?.AddTag("request.content", requestContent);
                            activity?.AddTag("request.length", requestContent.Length.ToString(CultureInfo.InvariantCulture));

                            var echo = Encoding.UTF8.GetBytes("echo: " + requestContent);
                            context.Response.ContentEncoding = Encoding.UTF8;
                            context.Response.ContentLength64 = echo.Length;
                            context.Response.OutputStream.Write(echo, 0, echo.Length);
                            context.Response.Close();
                        }
                        catch (Exception)
                        {
                            // expected when closing the listener.
                        }
                    }
                });
            }

            public void Dispose()
            {
                this.listener.Close();
            }
        }

        private class SampleClient : IDisposable
        {
            private CancellationTokenSource cts;
            private Task requestTask;

            public void Start(string url)
            {
                this.cts = new CancellationTokenSource();
                var cancellationToken = this.cts.Token;

                this.requestTask = Task.Run(async () =>
                    {
                        using var source = new ActivitySource("Samples.SampleClient");
                        using var client = new HttpClient();

                        var count = 1;
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            var content = new StringContent($"client message: {DateTime.Now}", Encoding.UTF8);

                            using (var activity = source.StartActivity("POST:" + RequestPath, ActivityKind.Client))
                            {
                                count++;

                                activity?.AddEvent(new ActivityEvent("PostAsync:Started"));
#pragma warning disable CA2234 // Pass system uri objects instead of strings
                                using var response = await client.PostAsync(url, content, cancellationToken).ConfigureAwait(false);
#pragma warning restore CA2234 // Pass system uri objects instead of strings
                                activity?.AddEvent(new ActivityEvent("PostAsync:Ended"));

                                activity?.AddTag("http.url", url);
                                activity?.AddTag("http.status_code", $"{response.StatusCode:D}");

                                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                activity?.AddTag("response.content", responseContent);
                                activity?.AddTag("response.length", responseContent.Length.ToString(CultureInfo.InvariantCulture));

                                foreach (var header in response.Headers)
                                {
                                    if (header.Value is IEnumerable<object> enumerable)
                                    {
                                        activity?.AddTag($"http.header.{header.Key}", string.Join(",", enumerable));
                                    }
                                    else
                                    {
                                        activity?.AddTag($"http.header.{header.Key}", header.Value.ToString());
                                    }
                                }
                            }

                            try
                            {
                                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                            }
                            catch (TaskCanceledException)
                            {
                                return;
                            }
                        }
                    },
                    cancellationToken);
            }

            public void Dispose()
            {
                if (this.cts != null)
                {
                    this.cts.Cancel();
                    this.requestTask.Wait();
                    this.requestTask.Dispose();
                    this.cts.Dispose();
                }
            }
        }
    }
}
