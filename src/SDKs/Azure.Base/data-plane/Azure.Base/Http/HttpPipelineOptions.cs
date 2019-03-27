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

        static readonly RetryPolicy s_defaultRetryPolicy = new FixedRetryPolicy(3, TimeSpan.Zero,
            //429, // Too Many Requests TODO (pri 2): this needs to throttle based on x-ms-retry-after 
            500, // Internal Server Error 
            503, // Service Unavailable
            504  // Gateway Timeout
        );

        List<HttpPipelinePolicy> _perCallPolicies;
        HttpPipelinePolicy _retryPolicy = s_defaultRetryPolicy;
        List<HttpPipelinePolicy> _perRetryPolicies;
        HttpPipelinePolicy _loggingPolicy = Pipeline.LoggingPolicy.Shared;
        HttpPipelineTransport _transpot = HttpClientTransport.Shared;

        public HttpPipelinePolicy RetryPolicy {
            get => _retryPolicy;
            set => _retryPolicy = value;
        }

        public HttpPipelinePolicy LoggingPolicy {
            get => _loggingPolicy;
            set => _loggingPolicy = value;
        }

        public HttpPipelineTransport Transport {
            get => _transpot;
            set {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _transpot = value;
            }
        }

        public void AddOption(HttpPipelineOption option) => option.Register(this);
        
        public void AddPolicy(HttpPipelinePolicy policy, PolicyRunner runner = PolicyRunner.Auto)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));

            switch (runner) {
                case PolicyRunner.Auto:
                    policy.Register(this);
                    break;
                case PolicyRunner.RuncOncePerRetry:
                    if (_perRetryPolicies == null) _perRetryPolicies = new List<HttpPipelinePolicy>();
                    _perRetryPolicies.Add(policy);
                    break;
                case PolicyRunner.RunsOncePerCall:
                    if (_perCallPolicies == null) _perCallPolicies = new List<HttpPipelinePolicy>();
                    _perCallPolicies.Add(policy);
                    break;
            }
        }

        public void AddService(object service, Type type)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (_container == null) _container = new ServiceProvider();
            _container.Add(service, type);
        }

        protected string ComponentName { get; set; } = "Azure.Base";
        protected string ComponentVersion { get; set; } = "1.0.0";

        protected internal virtual HttpPipeline CreatePipeline()
        {
            HttpPipelinePolicy[] policies = new HttpPipelinePolicy[ComputePolicyCount()];
            int index = 0;

            policies[index++] = new TelemetryPolicy(ComponentName, ComponentVersion);
        
            if (_perCallPolicies != null) {
                foreach (var policy in _perCallPolicies) {  
                    policies[index++] = policy;
                }
            }
            else if (RetryPolicy != null) {
                policies[index++] = RetryPolicy;
            }
            if (_perRetryPolicies != null) {
                foreach (var policy in _perRetryPolicies) {
                    policies[index++] = policy;
                }
            }
            if (LoggingPolicy != null) {
                policies[index++] = LoggingPolicy;
            }
            policies[index++] = Transport;

            var container = _container == null ? EmptyServiceProvider.Singleton : _container;
            var pipeline = new HttpPipeline(policies, container);
            return pipeline;

            int ComputePolicyCount() {
                int numberOfPolicies = 2; // HttpPipelineTransport, TelemetryPolicy

                if (_loggingPolicy != null) numberOfPolicies++;
                if (RetryPolicy != null) numberOfPolicies++;

                if (_perCallPolicies != null) numberOfPolicies += _perCallPolicies.Count;
                if (_perRetryPolicies != null) numberOfPolicies += _perRetryPolicies.Count;

                return numberOfPolicies;
            }
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

        public enum PolicyRunner
        {
            Auto,
            RunsRightBeforeTransport,
            RunsOncePerCall,
            RuncOncePerRetry
        }
    }
}

