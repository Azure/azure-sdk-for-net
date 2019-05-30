// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.ExceptionServices;

namespace Azure.Core.Extensions
{
    internal class ClientRegistration<TClient, TOptions>
    {
        public string Name { get; }

        private readonly Func<TOptions, TClient> _factory;

        private TClient _cachedClient;

        private ExceptionDispatchInfo _cachedException;

        public ClientRegistration(string name, Func<TOptions, TClient> factory)
        {
            Name = name;
            _factory = factory;
        }

        public TClient GetClient(TOptions options)
        {
            _cachedException?.Throw();

            if (_cachedClient != null)
            {
                return _cachedClient;
            }

            lock (this)
            {
                _cachedException?.Throw();

                if (_cachedClient != null)
                {
                    return _cachedClient;
                }

                try
                {
                    _cachedClient = _factory(options);
                }
                catch (Exception e)
                {
                    _cachedException = ExceptionDispatchInfo.Capture(e);
                }

                return _cachedClient;
            }
        }
    }
}