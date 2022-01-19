// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
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
            var result = BuildInternal(options, perCallPolicies, perRetryPolicies, null, responseClassifier);
            return new HttpPipeline(result.Transport, result.PerCallIndex, result.PerRetryIndex, result.Policies, result.Classifier);
        }

        /// <summary>
        /// Creates an instance of <see cref="DisposableHttpPipeline"/> populated with default policies, customer provided policies from <paramref name="options"/>, client provided per call policies, and the supplied <see cref="HttpPipelineTransportOptions"/>.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="perCallPolicies">Client provided per-call policies.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <param name="transportOptions">The customer provided transport options which will be applied to the default transport. Note: If a custom transport has been supplied via the <paramref name="options"/>, these <paramref name="transportOptions"/> will be ignored.</param>
        /// <param name="responseClassifier">The client provided response classifier.</param>
        /// <returns>A new instance of <see cref="DisposableHttpPipeline"/></returns>
        public static DisposableHttpPipeline Build(ClientOptions options, HttpPipelinePolicy[] perCallPolicies, HttpPipelinePolicy[] perRetryPolicies, HttpPipelineTransportOptions transportOptions, ResponseClassifier? responseClassifier)
        {
            Argument.AssertNotNull(transportOptions, nameof(transportOptions));
            var result = BuildInternal(options, perCallPolicies, perRetryPolicies, transportOptions, responseClassifier);
            return new DisposableHttpPipeline(result.Transport, result.PerCallIndex, result.PerRetryIndex, result.Policies, result.Classifier, result.IsTransportOwned);
        }

        internal static (ResponseClassifier Classifier, HttpPipelineTransport Transport, int PerCallIndex, int PerRetryIndex, HttpPipelinePolicy[] Policies, bool IsTransportOwned) BuildInternal(
            ClientOptions options,
            HttpPipelinePolicy[] perCallPolicies,
            HttpPipelinePolicy[] perRetryPolicies,
            HttpPipelineTransportOptions? defaultTransportOptions,
            ResponseClassifier? responseClassifier)
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
            bool isTransportInternallyCreated = false;

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
                    isTransportInternallyCreated = true;
                }
            }

            policies.Add(new HttpPipelineTransportPolicy(transport, sanitizer));

            responseClassifier ??= ResponseClassifier.Shared;

            return (responseClassifier, transport, perCallIndex, perRetryIndex, policies.ToArray(), isTransportInternallyCreated);
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
