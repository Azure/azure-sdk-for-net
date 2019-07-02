// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.ExceptionServices;

namespace Azure.Core.Extensions
{
    internal class ClientRegistration<TClient, TOptions>
    {
        public string Name { get; }

        private readonly Func<TOptions, TokenCredential, TClient> _factory;

        private readonly object _cacheLock = new object();

        private TClient _cachedClient;

        private ExceptionDispatchInfo _cachedException;

        public ClientRegistration(string name, Func<TOptions, TokenCredential, TClient> factory)
        {
            Name = name;
            _factory = factory;
        }

        public TClient GetClient(TOptions options, TokenCredential tokenCredential)
        {
            _cachedException?.Throw();

            if (_cachedClient != null)
            {
                return _cachedClient;
            }

            lock (_cacheLock)
            {
                _cachedException?.Throw();

                if (_cachedClient != null)
                {
                    return _cachedClient;
                }

                try
                {
                    _cachedClient = _factory(options, tokenCredential);
                }
                catch (Exception e)
                {
                    _cachedException = ExceptionDispatchInfo.Capture(e);
                    throw;
                }

                return _cachedClient;
            }
        }
    }
}