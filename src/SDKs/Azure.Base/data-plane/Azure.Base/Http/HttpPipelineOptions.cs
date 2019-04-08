// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Base.Http
{
    public class HttpClientOptions
    {
        private HttpPipelineTransport _transport = HttpClientTransport.Shared;

        public HttpPipelineTransport Transport {
            get => _transport;
            set => _transport = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool DisableTelemetry { get; set; } = false;

        public string ApplicationId { get; set; }

        public IServiceProvider ServiceProvider { get; set; } = EmptyServiceProvider.Singleton;

        public IList<HttpPipelinePolicy> PerCallPolicies { get; } = new List<HttpPipelinePolicy>();

        public IList<HttpPipelinePolicy> PerRetryPolicies { get; } = new List<HttpPipelinePolicy>();

        public void AddService(object service, Type type = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            if (!(ServiceProvider is DictionaryServiceProvider dictionaryServiceProvider))
            {
                ServiceProvider = dictionaryServiceProvider = new DictionaryServiceProvider();
            }

            dictionaryServiceProvider.Add(service, type != null ? type : service.GetType());
        }

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion

        private sealed class DictionaryServiceProvider : IServiceProvider
        {
            Dictionary<Type, object> _services = new Dictionary<Type, object>();

            public object GetService(Type serviceType)
            {
                _services.TryGetValue(serviceType, out var service);
                return service;
            }

            internal void Add(object service, Type type)
                => _services.Add(type, service);
        }

        internal sealed class EmptyServiceProvider : IServiceProvider
        {
            public static IServiceProvider Singleton { get; } = new EmptyServiceProvider();
            private EmptyServiceProvider() { }

            public object GetService(Type serviceType) => null;
        }
    }
}

