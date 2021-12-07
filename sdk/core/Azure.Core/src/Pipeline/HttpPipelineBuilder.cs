// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core.Diagnostics;

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
            return Build(options, Array.Empty<HttpPipelinePolicy>(), perRetryPolicies, ResponseClassifier.Shared);
        }

        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, customer provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="perCallPolicies">Client provided per-call policies.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <param name="responseClassifier">The client provided response classifier.</param>
        /// <returns>A new instance of <see cref="HttpPipeline"/></returns>
        public static HttpPipeline Build(
            ClientOptions options,
            HttpPipelinePolicy[] perCallPolicies,
            HttpPipelinePolicy[] perRetryPolicies,
            ResponseClassifier? responseClassifier)
        {
            return Build(options, perCallPolicies, perRetryPolicies, responseClassifier, null);
        }

        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, customer provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="perCallPolicies">Client provided per-call policies.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <param name="responseClassifier">The client provided response classifier.</param>
        /// <param name="defaultTransportOptions">The customer provided transport options which will be applied to the default transport.</param>
        /// <returns>A new instance of <see cref="HttpPipeline"/></returns>
        public static HttpPipeline Build(ClientOptions options, HttpPipelinePolicy[] perCallPolicies, HttpPipelinePolicy[] perRetryPolicies, ResponseClassifier? responseClassifier, HttpPipelineTransportOptions? defaultTransportOptions)
        {
            if (perCallPolicies == null)
            {
                throw new ArgumentNullException(nameof(perCallPolicies));
            }

            if (perRetryPolicies == null)
            {
                throw new ArgumentNullException(nameof(perRetryPolicies));
            }

            var policies = new List<HttpPipelinePolicy>(8 +
                                                        (options.Policies?.Count ?? 0) +
                                                        perCallPolicies.Length +
                                                        perRetryPolicies.Length);

            void AddCustomerPolicies(HttpPipelinePosition position)
            {
                if (options.Policies != null)
                {
                    foreach (var policy in options.Policies)
                    {
                        if (policy.Position == position)
                        {
                            policies.Add(policy.Policy);
                        }
                    }
                }
            }

            DiagnosticsOptions diagnostics = options.Diagnostics;

            var sanitizer = new HttpMessageSanitizer(diagnostics.LoggedQueryParameters.ToArray(), diagnostics.LoggedHeaderNames.ToArray());

            bool isDistributedTracingEnabled = options.Diagnostics.IsDistributedTracingEnabled;

            policies.Add(ReadClientRequestIdPolicy.Shared);

            policies.AddRange(perCallPolicies);

            AddCustomerPolicies(HttpPipelinePosition.PerCall);

            policies.RemoveAll(static policy => policy == null);
            var perCallIndex = policies.Count;

            policies.Add(ClientRequestIdPolicy.Shared);

            if (diagnostics.IsTelemetryEnabled)
            {
                policies.Add(CreateTelemetryPolicy(options));
            }

            RetryOptions retryOptions = options.Retry;
            policies.Add(new RetryPolicy(retryOptions.Mode, retryOptions.Delay, retryOptions.MaxDelay, retryOptions.MaxRetries));

            policies.Add(RedirectPolicy.Shared);

            policies.AddRange(perRetryPolicies);

            AddCustomerPolicies(HttpPipelinePosition.PerRetry);

            policies.RemoveAll(static policy => policy == null);

            var perRetryIndex = policies.Count;

            if (diagnostics.IsLoggingEnabled)
            {
                string assemblyName = options.GetType().Assembly!.GetName().Name!;

                policies.Add(new LoggingPolicy(diagnostics.IsLoggingContentEnabled, diagnostics.LoggedContentSizeLimit, sanitizer, assemblyName));
            }

            policies.Add(new ResponseBodyPolicy(options.Retry.NetworkTimeout));

            policies.Add(new RequestActivityPolicy(isDistributedTracingEnabled, ClientDiagnostics.GetResourceProviderNamespace(options.GetType().Assembly), sanitizer));

            AddCustomerPolicies(HttpPipelinePosition.BeforeTransport);
            policies.RemoveAll(static policy => policy == null);

            // Override the provided Transport with the provided transport options if the transport has not been set after default construction and options are not null.
            HttpPipelineTransport transport = options.Transport;
            bool disposablePipeline = false;
            if (defaultTransportOptions != null)
            {
                if (options.IsCustomTransportSet)
                {
                    if (AzureCoreEventSource.Singleton.IsEnabled())
                    {
                        // Log that we were unable to override the custom transport
                        AzureCoreEventSource.Singleton.PipelineTransportOptionsNotApplied(options?.GetType().FullName ?? String.Empty);
                    }
                }
                else
                {
                    transport = HttpPipelineTransport.Create(defaultTransportOptions);
                }
            }

            policies.Add(new HttpPipelineTransportPolicy(transport, sanitizer));

            responseClassifier ??= ResponseClassifier.Shared;

            if (disposablePipeline)
            {
                return new DisposableHttpPipeline(transport,
                    perCallIndex,
                    perRetryIndex,
                    policies.ToArray(),
                    responseClassifier);
            }

            return new HttpPipeline(transport,
                perCallIndex,
                perRetryIndex,
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
