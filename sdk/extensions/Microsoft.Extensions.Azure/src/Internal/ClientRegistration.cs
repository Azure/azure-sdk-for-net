// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Azure.Core;

namespace Microsoft.Extensions.Azure
{
    internal class ClientRegistration<TClient> : IDisposable, IAsyncDisposable
    {
        public string Name { get; set; }
        public object Version { get; set; }

        private readonly bool _requiresCredential;
        private readonly Func<IServiceProvider, object, TokenCredential, TClient> _factory;

        private readonly object _cacheLock = new();

        private bool _clientInitialized;
        private TClient _cachedClient;
        private ExceptionDispatchInfo _cachedException;

        public ClientRegistration(string name, bool requiresCredential, Func<IServiceProvider, object, TokenCredential, TClient> factory)
        {
            Name = name;
            _requiresCredential = requiresCredential;
            _factory = factory;
        }

        public TClient GetClient(IServiceProvider serviceProvider, object options, TokenCredential tokenCredential)
        {
            if (TryGetCachedClientOrThrow(out var cachedClient))
            {
                return cachedClient;
            }

            lock (_cacheLock)
            {
                if (TryGetCachedClientOrThrow(out cachedClient))
                {
                    return cachedClient;
                }

                if (_requiresCredential && tokenCredential == null)
                {
                    throw new InvalidOperationException("Client registration requires a TokenCredential. Configure it using UseCredential method.");
                }

                try
                {
                    _cachedClient = _factory(serviceProvider, options, tokenCredential);
                    _clientInitialized = true;
                }
                catch (Exception e)
                {
                    _cachedException = ExceptionDispatchInfo.Capture(e);
                    throw;
                }

                return _cachedClient;
            }
        }

        /// <summary>
        /// Client registration can be in one of 4 states:
        ///  - _clientInitialized is false, _cachedException is null: _factory has never been called, client hasn't been initialized yet
        ///  - _clientInitialized is false, _cachedException is not null: _factory has been called, but exception has happened. Client isn't been initialized.
        ///  - _clientInitialized is true, _cachedClient is not null: client has been initialized and is not disposed yet
        ///  - _clientInitialized is true, _cachedClient is null: client has been initialized and is disposed
        /// </summary>
        /// <param name="cachedClient"></param>
        /// <returns>True if client is initialized and not disposed, otherwise false.</returns>
        private bool TryGetCachedClientOrThrow(out TClient cachedClient)
        {
            _cachedException?.Throw();
            if (_clientInitialized)
            {
                cachedClient = _cachedClient ?? throw new ObjectDisposedException(nameof(ClientRegistration<TClient>));
                return true;
            }

            cachedClient = default;
            return false;
        }

        public async ValueTask DisposeAsync()
        {
            if (!_clientInitialized)
            {
                return;
            }

            if (_cachedClient is null)
            {
                return;
            }

            IDisposable disposableClient;
            IAsyncDisposable asyncDisposableClient;
            lock (_cacheLock)
            {
                disposableClient = _cachedClient as IDisposable;
                asyncDisposableClient = _cachedClient as IAsyncDisposable;
                _cachedClient = default;
            }

            if (asyncDisposableClient is not null)
            {
                await asyncDisposableClient.DisposeAsync().ConfigureAwait(false);
            }
            else if (disposableClient is not null)
            {
                disposableClient.Dispose();
            }
        }

        public void Dispose()
        {
            if (!_clientInitialized)
            {
                return;
            }

            if (_cachedClient is null)
            {
                return;
            }

            IDisposable disposableClient;
            IAsyncDisposable asyncDisposableClient;
            lock (_cacheLock)
            {
                disposableClient = _cachedClient as IDisposable;
                asyncDisposableClient = _cachedClient as IAsyncDisposable;
                _cachedClient = default;
            }

            if (disposableClient is not null)
            {
                disposableClient.Dispose();
            }
            else if (asyncDisposableClient is not null)
            {
                asyncDisposableClient.DisposeAsync().GetAwaiter().GetResult();
            }
        }
    }
}