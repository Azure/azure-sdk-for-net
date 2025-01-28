// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests
{
    public abstract class TestServerSessionBase<T> : IAsyncDisposable where T : TestServerBase
    {
        private static readonly object _serverCacheLock = new object();
        private static T? s_serverCache;

        public T? Server { get; private set; }
        public Uri Host => Server?.Host ?? throw new InvalidOperationException("Server is not instantiated");

        protected TestServerSessionBase()
        {
            Server = GetServer();
        }

        private ref T? GetServerCache()
        {
            return ref s_serverCache;
        }

        private T CreateServer()
        {
            var server = Activator.CreateInstance(typeof(T));
            if (server is null)
            {
                throw new InvalidOperationException($"Unable to construct a new instance of {typeof(T).Name}");
            }

            return (T)server;
        }

        private T GetServer()
        {
            T? server;
            lock (_serverCacheLock)
            {
                ref var cache = ref GetServerCache();
                server = cache;
                cache = null;
            }

            if (server == null)
            {
                server = CreateServer();
            }

            return server;
        }

        public abstract ValueTask DisposeAsync();

        protected void Return()
        {
            bool disposeServer = true;
            lock (_serverCacheLock)
            {
                ref var cache = ref GetServerCache();
                if (cache == null)
                {
                    cache = Server;
                    Server = null;
                    disposeServer = false;
                }
            }

            if (disposeServer)
            {
                Server?.Dispose();
            }
        }
    }
}
