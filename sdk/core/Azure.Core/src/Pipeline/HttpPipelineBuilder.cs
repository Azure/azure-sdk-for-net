// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Factory for creating instances of <see cref="HttpPipeline"/> populated with default policies.
    /// </summary>
    public static class HttpPipelineBuilder
    {
        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, customer provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <returns>A new instance of <see cref="HttpPipeline"/></returns>
        public static HttpPipeline Build(ClientOptions options, params HttpPipelinePolicy[] perRetryPolicies)
        {
            return Build(options, Array.Empty<HttpPipelinePolicy>(), perRetryPolicies, new ResponseClassifier());
        }

        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, customer provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="perCallPolicies">Client provided per-call policies.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <param name="responseClassifier">The client provided response classifier.</param>
        /// <returns>A new instance of <see cref="HttpPipeline"/></returns>
        public static HttpPipeline Build(ClientOptions options, HttpPipelinePolicy[] perCallPolicies, HttpPipelinePolicy[] perRetryPolicies, ResponseClassifier responseClassifier)
        {
            if (perCallPolicies == null)
            {
                throw new ArgumentNullException(nameof(perCallPolicies));
            }

            if (perRetryPolicies == null)
            {
                throw new ArgumentNullException(nameof(perRetryPolicies));
            }

            var policies = new List<HttpPipelinePolicy>();

            bool isDistributedTracingEnabled = options.Diagnostics.IsDistributedTracingEnabled;

            policies.Add(ReadClientRequestIdPolicy.Shared);

            policies.AddRange(perCallPolicies);

            policies.AddRange(options.PerCallPolicies);

            policies.Add(ClientRequestIdPolicy.Shared);

            DiagnosticsOptions diagnostics = options.Diagnostics;
            if (diagnostics.IsTelemetryEnabled)
            {
                policies.Add(CreateTelemetryPolicy(options));
            }

            RetryOptions retryOptions = options.Retry;
            policies.Add(new RetryPolicy(retryOptions.Mode, retryOptions.Delay, retryOptions.MaxDelay, retryOptions.MaxRetries));

            policies.AddRange(perRetryPolicies);

            policies.AddRange(options.PerRetryPolicies);

            if (diagnostics.IsLoggingEnabled)
            {
                string assemblyName = options.GetType().Assembly!.GetName().Name!;

                policies.Add(new LoggingPolicy(diagnostics.IsLoggingContentEnabled, diagnostics.LoggedContentSizeLimit,
                    diagnostics.LoggedHeaderNames.ToArray(), diagnostics.LoggedQueryParameters.ToArray(), assemblyName));
            }

            policies.Add(new ResponseBodyPolicy(options.Retry.NetworkTimeout));

            policies.Add(new RequestActivityPolicy(isDistributedTracingEnabled, ClientDiagnostics.GetResourceProviderNamespace(options.GetType().Assembly)));

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport,
                policies.ToArray(),
                responseClassifier);
        }

        // internal for testing
        internal static TelemetryPolicy CreateTelemetryPolicy(ClientOptions options)
        {
            const string PackagePrefix = "Azure.";

            Assembly clientAssembly = options.GetType().Assembly!;

            AssemblyInformationalVersionAttribute? versionAttribute = clientAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException($"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{clientAssembly.FullName}' (inferred from the use of options type '{options.GetType().FullName}').");
            }

            string version = versionAttribute.InformationalVersion;

            string assemblyName = clientAssembly.GetName().Name!;
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.Ordinal))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }

            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }

            return new TelemetryPolicy(assemblyName, version, options.Diagnostics.ApplicationId);
        }
    }
}
