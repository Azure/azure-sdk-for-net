// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

// Copied from: https://github.com/open-telemetry/opentelemetry-dotnet-contrib/blob/Instrumentation.Http-1.9.0/test/Shared/TestHttpServer.cs

using System;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace OpenTelemetry.Tests;

internal static class TestHttpServer
{
#if NETFRAMEWORK
    private static readonly Random GlobalRandom = new();
#endif

    public static IDisposable RunServer(Action<HttpListenerContext> action, out string host, out int port)
    {
        host = "localhost";
        port = 0;
        RunningServer? server = null;

        var retryCount = 5;
        while (true)
        {
            try
            {
#if NET
                port = RandomNumberGenerator.GetInt32(2000, 5000);
#else
#pragma warning disable CA5394 // Do not use insecure randomness
                port = GlobalRandom.Next(2000, 5000);
#pragma warning restore CA5394 // Do not use insecure randomness
#endif
                server = new RunningServer(action, host, port);
                server.Start();
                break;
            }
            catch (HttpListenerException ex)
            {
                server?.Dispose();
                server = null;
                if (--retryCount <= 0)
                {
                    throw new InvalidOperationException("TestHttpServer could not be started.", ex);
                }
            }
        }

        return server;
    }

    private sealed class RunningServer : IDisposable
    {
        private readonly Task httpListenerTask;
        private readonly HttpListener listener;
        private readonly AutoResetEvent initialized = new(false);

        public RunningServer(Action<HttpListenerContext> action, string host, int port)
        {
            this.listener = new HttpListener();

            this.listener.Prefixes.Add($"http://{host}:{port}/");
            this.listener.Start();

            this.httpListenerTask = new Task(async () =>
            {
                while (true)
                {
                    try
                    {
                        var ctxTask = this.listener.GetContextAsync();

                        this.initialized.Set();

                        action(await ctxTask.ConfigureAwait(false));
                    }
                    catch (Exception ex)
                    {
                        if (ex is ObjectDisposedException
                            || (ex is HttpListenerException httpEx && httpEx.ErrorCode == 995))
                        {
                            // Listener was closed before we got into GetContextAsync or
                            // Listener was closed while we were in GetContextAsync.
                            break;
                        }

                        throw;
                    }
                }
            });
        }

        public void Start()
        {
            this.httpListenerTask.Start();
            this.initialized.WaitOne();
        }

        public void Dispose()
        {
            try
            {
                this.listener.Close();
                this.httpListenerTask?.Wait();
                this.initialized.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // swallow this exception just in case
            }
        }
    }
}
