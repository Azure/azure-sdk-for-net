// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Base.Http
{
    public class HttpPipelineOptions
    {
        ServiceProvider _container;

        HttpPipelineTransport _transport;
        List<HttpPipelinePolicy> _perCallPolicies;
        List<HttpPipelinePolicy> _perRetryPolicies;

        public HttpPipelineTransport Transport {
            get => _transport;
            set {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _transport = value;
            }
        }

        public HttpPipelinePolicy RetryPolicy { get; set; }

        public bool DisableTelemetry { get; set; } = false;

        public string ApplicationId { get; set; }

        public HttpPipelineOptions(HttpPipelineTransport transport)
            => _transport = transport;

        public HttpPipelineOptions() : this( HttpClientTransport.Shared)
        { }

        public void AddPerCallPolicy(HttpPipelinePolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));

            if (_perCallPolicies == null) _perCallPolicies = new List<HttpPipelinePolicy>();
            _perCallPolicies.Add(policy);
        }

        public void AddPerRetryPolicy(HttpPipelinePolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));

            if (_perRetryPolicies == null) _perRetryPolicies = new List<HttpPipelinePolicy>();
            _perRetryPolicies.Add(policy);
        }

        public void AddService(object service, Type type = null)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            if (_container == null) _container = new ServiceProvider();
            _container.Add(service, type != null ? type : service.GetType());
        }

        int PolicyCount {
            get {
                int numberOfPolicies = 2; // HttpPipelineTransport nad Logging
                if (DisableTelemetry == false) numberOfPolicies++; // AddHeadersPolicy

                if (RetryPolicy != null) numberOfPolicies++;

                if (_perCallPolicies != null) numberOfPolicies += _perCallPolicies.Count;
                if (_perRetryPolicies != null) numberOfPolicies += _perRetryPolicies.Count;

                return numberOfPolicies;
            }
        }

        public HttpPipeline Build(string componentName, string componentVersion)
        {
            HttpPipelinePolicy[] policies = new HttpPipelinePolicy[PolicyCount];
            int index = 0;

            if (DisableTelemetry == false) {
                var addHeadersPolicy = new AddHeadersPolicy();
                policies[index++] = addHeadersPolicy;

                var ua = HttpHeader.Common.CreateUserAgent(componentName, componentVersion, ApplicationId);
                addHeadersPolicy.AddHeader(ua);
            }
            if (_perCallPolicies != null) {
                foreach (var policy in _perCallPolicies) {
                    policies[index++] = policy;
                }
            }
            if (RetryPolicy != null) {
                policies[index++] = RetryPolicy;
            }
            if (_perRetryPolicies != null) {
                foreach (var policy in _perRetryPolicies) {
                    policies[index++] = policy;
                }
            }
            policies[index++] = new LoggingPolicy();
            policies[index++] = _transport;

            var container = _container == null ? EmptyServiceProvider.Singleton : _container;
            var pipeline = new HttpPipeline(policies, container);
            return pipeline;
        }

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion

        sealed class ServiceProvider : IServiceProvider
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

