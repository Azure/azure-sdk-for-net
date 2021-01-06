// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.ExceptionServices;
using Azure.Core;

namespace Microsoft.Extensions.Azure
{
    internal class ClientRegistration<TClient>
    {
        public string Name { get; set; }
        public object Version { get; set; }
        public bool RequiresTokenCredential { get; set; }

        private readonly Func<object, TokenCredential, TClient> _factory;

        private readonly object _cacheLock = new object();

        private TClient _cachedClient;

        private ExceptionDispatchInfo _cachedException;

        public ClientRegistration(string name, Func<object, TokenCredential, TClient> factory)
        {
            Name = name;
            _factory = factory;
        }

        public TClient GetClient(object options, TokenCredential tokenCredential)
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

                if (RequiresTokenCredential && tokenCredential == null)
                {
                    throw new InvalidOperationException("Client registration requires a TokenCredential. Configure it using UseCredential method.");
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