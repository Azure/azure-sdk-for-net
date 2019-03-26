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
        static readonly HttpPipelinePolicy s_defaultRetryPolicy = new FixedRetryPolicy(3, TimeSpan.Zero,
            //429, // Too Many Requests TODO (pri 2): this needs to throttle based on x-ms-retry-after 
            500, // Internal Server Error 
            503, // Service Unavailable
            504  // Gateway Timeout
        );

        ServiceProvider _container;

        List<HttpPipelinePolicy> _perCallPolicies;

        HttpPipelinePolicy _retryPolicy;
        bool _retryPolicySet;
        
        List<HttpPipelinePolicy> _perRetryPolicies;

        HttpPipelinePolicy _loggingPolicy = LoggingPolicy.Shared;
        HttpPipelineTransport _transport = HttpClientTransport.Shared;

        public void ReplaceLoggingPolicy(HttpPipelinePolicy loggingPolicy)
        {
            _loggingPolicy = loggingPolicy;
        }

        public void ReplaceRetryPolicy(HttpPipelinePolicy retryPolicy)
        {
            _retryPolicy = retryPolicy;
            _retryPolicySet = true;
        }

        public void ReplaceTransport(HttpPipelineTransport transport)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            _transport = transport;
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

        int PolicyCount {
            get {
                int numberOfPolicies = 2; // HttpPipelineTransport, TelemetryPolicy

                if (_loggingPolicy != null) numberOfPolicies++;
                if (_retryPolicy != null) numberOfPolicies++;

                if (_perCallPolicies != null) numberOfPolicies += _perCallPolicies.Count;
                if (_perRetryPolicies != null) numberOfPolicies += _perRetryPolicies.Count;

                return numberOfPolicies;
            }
        }

        protected virtual string ComponentName { get; } = "Azure.Base";
        protected virtual string ComponentVersion { get; } = "1.0.0";
        protected virtual HttpPipelinePolicy DefaultRetryPolicy { get; } = s_defaultRetryPolicy;

        public HttpPipeline CreatePipeline()
        {
            HttpPipelinePolicy[] policies = new HttpPipelinePolicy[PolicyCount];
            int index = 0;

            policies[index++] = new TelemetryPolicy(ComponentName, ComponentVersion);
        
            if (_perCallPolicies != null) {
                foreach (var policy in _perCallPolicies) {  
                    policies[index++] = policy;
                }
            }
            if (!_retryPolicySet) {
                _retryPolicy = DefaultRetryPolicy;
            }
            else if (_retryPolicy != null) {
                policies[index++] = _retryPolicy;
            }
            if (_perRetryPolicies != null) {
                foreach (var policy in _perRetryPolicies) {
                    policies[index++] = policy;
                }
            }
            if (_loggingPolicy != null) {
                policies[index++] = _loggingPolicy;
            }
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

        public enum PolicyRunner
        {
            Auto,
            RunsRightBeforeTransport,
            RunsOncePerCall,
            RuncOncePerRetry
        }
    }
}

