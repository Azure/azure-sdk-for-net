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
            Assembly clientAssembly = options.GetType().Assembly;
            AzureSdkClientLibraryAttribute componentAttribute = clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{clientAssembly.FullName}'.");
            }

            return new TelemetryPolicy(componentAttribute.ComponentName, clientAssembly.GetName().Version.ToString(), options.Diagnostics.ApplicationId);
        }
    }
}
