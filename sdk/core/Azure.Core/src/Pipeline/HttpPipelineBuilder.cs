// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public static class HttpPipelineBuilder
    {
        public static HttpPipeline Build(ClientOptions options, bool bufferResponse = true, params HttpPipelinePolicy[] clientPolicies)
        {
            var policies = new List<HttpPipelinePolicy>();

            policies.AddRange(options.PerCallPolicies);

            policies.Add(ClientRequestIdPolicy.Shared);

            if (options.Diagnostics.IsTelemetryEnabled)
            {
                policies.Add(CreateTelemetryPolicy(options));
            }

            RetryOptions retryOptions = options.Retry;
            policies.Add(new RetryPolicy(retryOptions.Mode, retryOptions.Delay, retryOptions.MaxDelay, retryOptions.MaxRetries));

            policies.AddRange(clientPolicies);

            policies.AddRange(options.PerRetryPolicies);

            if (options.Diagnostics.IsLoggingEnabled)
            {
                policies.Add(LoggingPolicy.Shared);
            }

            if (bufferResponse)
            {
                policies.Add(BufferResponsePolicy.Shared);
            }

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport, policies.ToArray(), options.ResponseClassifier);
        }

        // internal for testing
        internal static TelemetryPolicy CreateTelemetryPolicy(ClientOptions options)
        {
            const string PackagePrefix = "Azure.";

            Assembly clientAssembly = options.GetType().Assembly;

            AssemblyInformationalVersionAttribute versionAttribute = clientAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException("Client SDK assemblies are required to have InformationalVersionAttribute");
            }

            string version = versionAttribute.InformationalVersion;

            string assemblyName = clientAssembly.GetName().Name;
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.OrdinalIgnoreCase))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }

            return new TelemetryPolicy(assemblyName, version, options.Diagnostics.ApplicationId);
        }
    }
}
