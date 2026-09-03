// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests
{
    public abstract class TestServerSessionBase<T> : IAsyncDisposable where T : TestServerBase
    {
        private static readonly object _serverCacheLock = new object();
        private static readonly SemaphoreSlim _serverLease = new(1, 1);
        private static T? s_serverCache;
        private bool _hasServerLease;

        public T? Server { get; private set; }
        public Uri Host => Server?.Host ?? throw new InvalidOperationException("Server is not instantiated");

        protected TestServerSessionBase()
        {
            _serverLease.Wait();
            try
            {
                Server = GetServer();
                _hasServerLease = true;
            }
            catch
            {
                _serverLease.Release();
                throw;
            }
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
            if (!_hasServerLease)
            {
                return;
            }

            bool disposeServer = true;
            try
            {
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
                    Server = null;
                }
            }
            finally
            {
                _hasServerLease = false;
                _serverLease.Release();
            }
        }
    }
}
