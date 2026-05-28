// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Factory for creating instances of <see cref="HttpPipeline"/> populated with default policies.
    /// </summary>
    public static class HttpPipelineBuilder
    {
        private static int DefaultPolicyCount = 8;

        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, user-provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The user-provided client options object.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <returns>A new instance of <see cref="HttpPipeline"/></returns>
        public static HttpPipeline Build(ClientOptions options, params HttpPipelinePolicy[] perRetryPolicies)
        {
            return Build(options, Array.Empty<HttpPipelinePolicy>(), perRetryPolicies, ResponseClassifier.Shared);
        }

        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, user-provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The user-provided client options object.</param>
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
            var pipelineOptions = new HttpPipelineOptions(options) { ResponseClassifier = responseClassifier };
            ((List<HttpPipelinePolicy>)pipelineOptions.PerCallPolicies).AddRange(perCallPolicies);
            ((List<HttpPipelinePolicy>)pipelineOptions.PerRetryPolicies).AddRange(perRetryPolicies);
            var result = BuildInternal(pipelineOptions, null);

            return new HttpPipeline(result.Transport, result.PerCallIndex, result.PerRetryIndex, result.Policies, result.Classifier);
        }

        /// <summary>
        /// Creates an instance of <see cref="DisposableHttpPipeline"/> populated with default policies, user-provided policies from <paramref name="options"/>, client provided per call policies, and the supplied <see cref="HttpPipelineTransportOptions"/>.
        /// </summary>
        /// <param name="options">The user-provided client options object.</param>
        /// <param name="perCallPolicies">Client provided per-call policies.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <param name="transportOptions">The user-provided transport options which will be applied to the default transport. Note: If a custom transport has been supplied via the <paramref name="options"/>, these <paramref name="transportOptions"/> will be ignored.</param>
        /// <param name="responseClassifier">The client provided response classifier.</param>
        /// <returns>A new instance of <see cref="DisposableHttpPipeline"/></returns>
        public static DisposableHttpPipeline Build(ClientOptions options, HttpPipelinePolicy[] perCallPolicies, HttpPipelinePolicy[] perRetryPolicies, HttpPipelineTransportOptions transportOptions, ResponseClassifier? responseClassifier)
        {
            Argument.AssertNotNull(transportOptions, nameof(transportOptions));

            var pipelineOptions = new HttpPipelineOptions(options) { ResponseClassifier = responseClassifier };
            ((List<HttpPipelinePolicy>)pipelineOptions.PerCallPolicies).AddRange(perCallPolicies);
            ((List<HttpPipelinePolicy>)pipelineOptions.PerRetryPolicies).AddRange(perRetryPolicies);
            var result = BuildInternal(pipelineOptions, transportOptions);
            return new DisposableHttpPipeline(result.Transport, result.PerCallIndex, result.PerRetryIndex, result.Policies, result.Classifier, result.IsTransportOwned);
        }

        /// <summary>
        /// Creates an instance of <see cref="HttpPipeline"/> populated with default policies, user-provided policies from <paramref name="options"/> and client provided per call policies.
        /// </summary>
        /// <param name="options">The configuration options used to build the <see cref="HttpPipeline"/></param>
        /// <returns>A new instance of <see cref="HttpPipeline"/></returns>
        public static HttpPipeline Build(HttpPipelineOptions options)
        {
            var result = BuildInternal(options, null);
            return new HttpPipeline(result.Transport, result.PerCallIndex, result.PerRetryIndex, result.Policies, result.Classifier);
        }

        /// <summary>
        /// Creates an instance of <see cref="DisposableHttpPipeline"/> populated with default policies, user-provided policies from <paramref name="options"/>, client provided per call policies, and the supplied <see cref="HttpPipelineTransportOptions"/>.
        /// </summary>
        /// <param name="options">The configuration options used to build the <see cref="DisposableHttpPipeline"/></param>
        /// <param name="transportOptions">The user-provided transport options which will be applied to the default transport. Note: If a custom transport has been supplied via the <paramref name="options"/>, these <paramref name="transportOptions"/> will be ignored.</param>
        /// <returns>A new instance of <see cref="DisposableHttpPipeline"/></returns>
        public static DisposableHttpPipeline Build(HttpPipelineOptions options, HttpPipelineTransportOptions transportOptions)
        {
            Argument.AssertNotNull(transportOptions, nameof(transportOptions));
            var result = BuildInternal(options, transportOptions);
            return new DisposableHttpPipeline(result.Transport, result.PerCallIndex, result.PerRetryIndex, result.Policies, result.Classifier, result.IsTransportOwned);
        }

        internal static (ResponseClassifier Classifier, HttpPipelineTransport Transport, int PerCallIndex, int PerRetryIndex, HttpPipelinePolicy[] Policies, bool IsTransportOwned) BuildInternal(
            HttpPipelineOptions buildOptions,
            HttpPipelineTransportOptions? defaultTransportOptions)
        {
            Argument.AssertNotNull(buildOptions.PerCallPolicies, nameof(buildOptions.PerCallPolicies));
            Argument.AssertNotNull(buildOptions.PerRetryPolicies, nameof(buildOptions.PerRetryPolicies));

            var policies = new List<HttpPipelinePolicy>(DefaultPolicyCount +
                                                        (buildOptions.ClientOptions.Policies?.Count ?? 0) +
                                                        buildOptions.PerCallPolicies.Count +
                                                        buildOptions.PerRetryPolicies.Count);

            void AddUserPolicies(HttpPipelinePosition position)
            {
                if (buildOptions.ClientOptions.Policies != null)
                {
                    foreach (var policy in buildOptions.ClientOptions.Policies)
                    {
                        // skip null policies to ensure that calculations for perCallIndex and perRetryIndex are accurate
                        if (policy.Position == position && policy.Policy != null)
                        {
                            policies.Add(policy.Policy);
                        }
                    }
                }
            }

            // A helper to ensure that we only add non-null policies to the policies list
            // This ensures that calculations for perCallIndex and perRetryIndex are accurate
            void AddNonNullPolicies(HttpPipelinePolicy[] policiesToAdd)
            {
                for (int i = 0; i < policiesToAdd.Length; i++)
                {
                    var policy = policiesToAdd[i];
                    if (policy != null)
                    {
                        policies.Add(policy);
                    }
                }
            }

            DiagnosticsOptions diagnostics = buildOptions.ClientOptions.Diagnostics;

            var sanitizer = new HttpMessageSanitizer(diagnostics.LoggedQueryParameters.ToArray(), diagnostics.LoggedHeaderNames.ToArray());

            bool isDistributedTracingEnabled = buildOptions.ClientOptions.Diagnostics.IsDistributedTracingEnabled;

            policies.Add(ReadClientRequestIdPolicy.Shared);

            AddNonNullPolicies(buildOptions.PerCallPolicies.ToArray());

            AddUserPolicies(HttpPipelinePosition.PerCall);

            var perCallIndex = policies.Count;

            policies.Add(ClientRequestIdPolicy.Shared);

            if (diagnostics.IsTelemetryEnabled)
            {
                policies.Add(CreateTelemetryPolicy(buildOptions.ClientOptions));
            }

            var retryOptions = buildOptions.ClientOptions.Retry;
            policies.Add(
                buildOptions.ClientOptions.RetryPolicy ??
                new RetryPolicy(
                    retryOptions.MaxRetries,
                    retryOptions.Mode == RetryMode.Exponential ?
                        DelayStrategy.CreateExponentialDelayStrategy(retryOptions.Delay, retryOptions.MaxDelay) :
                        DelayStrategy.CreateFixedDelayStrategy(retryOptions.Delay)));

            var redirectPolicy = defaultTransportOptions?.IsClientRedirectEnabled switch
            {
                true => new RedirectPolicy(true),
                _ => RedirectPolicy.Shared,
            };
            policies.Add(redirectPolicy);

            AddNonNullPolicies(buildOptions.PerRetryPolicies.ToArray());

            AddUserPolicies(HttpPipelinePosition.PerRetry);

            var perRetryIndex = policies.Count;

            if (diagnostics.IsLoggingEnabled)
            {
                string assemblyName = buildOptions.ClientOptions.GetType().Assembly!.GetName().Name!;

                policies.Add(new LoggingPolicy(diagnostics.IsLoggingContentEnabled, diagnostics.LoggedContentSizeLimit, sanitizer, assemblyName));
            }

            policies.Add(new ResponseBodyPolicy(buildOptions.ClientOptions.Retry.NetworkTimeout));

            policies.Add(new RequestActivityPolicy(isDistributedTracingEnabled, ClientDiagnostics.GetResourceProviderNamespace(buildOptions.ClientOptions.GetType().Assembly), sanitizer));

            AddUserPolicies(HttpPipelinePosition.BeforeTransport);

            // Override the provided Transport with the provided transport options if the transport has not been set after default construction and options are not null.
            HttpPipelineTransport transport = buildOptions.ClientOptions.Transport;
            bool isTransportInternallyCreated = false;

            if (defaultTransportOptions != null)
            {
                if (buildOptions.ClientOptions.IsCustomTransportSet)
                {
                    // Log that we were unable to override the custom transport
                    AzureCoreEventSource.Singleton.PipelineTransportOptionsNotApplied(buildOptions.ClientOptions.GetType());
                }
                else
                {
                    transport = HttpPipelineTransport.Create(defaultTransportOptions);
                    isTransportInternallyCreated = true;
                }
            }

            policies.Add(new HttpPipelineTransportPolicy(transport, sanitizer, buildOptions.RequestFailedDetailsParser));

            buildOptions.ResponseClassifier ??= ResponseClassifier.Shared;

            return (buildOptions.ResponseClassifier, transport, perCallIndex, perRetryIndex, policies.ToArray(), isTransportInternallyCreated);
        }

        // internal for testing
        internal static TelemetryPolicy CreateTelemetryPolicy(ClientOptions options)
        {
            var type = options.GetType();
            var userAgentValue = new TelemetryDetails(type.Assembly, options.Diagnostics.ApplicationId);
            return new TelemetryPolicy(userAgentValue);
        }
    }
}
