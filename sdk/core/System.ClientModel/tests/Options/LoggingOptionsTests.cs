// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ClientModel.ReferenceClients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace System.ClientModel.Tests.Options;

public class LoggingOptionsTests
{
    [Test]
    public void CanUseHttpClientLoggingInsteadOfScmHttpLogging()
    {
        ServiceCollection services = new();

        // see https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory
        services.AddHttpClient();

        // see https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.httpclientloggingservicecollectionextensions.addextendedhttpclientlogging?view=net-8.0
        //services.AddExtendedHttpClientLogging();

        services.AddOptions<RequestResponseClientOptions>();

        services.AddSingleton<RequestResponseClient>(serviceProvider =>
        {
            // Configure client to use HttpClient logging instead of SCM HTTP logging.
            // Preserve other SCM-based client logging.
            HttpClient httpClient = serviceProvider.GetRequiredService<HttpClient>();
            RequestResponseClientOptions options = serviceProvider.GetRequiredService<RequestResponseClientOptions>();
            options.Diagnostics.EnableHttpLogging = false;
            options.Transport = new HttpClientPipelineTransport(httpClient);
            return new RequestResponseClient(options);
        });
    }

    [Test]
    public void CanReplaceScmLoggingWithCustomHttpLogging_NoDI()
    {
        RequestResponseClientOptions options = new();
        options.Diagnostics.AllowedHeaderNames.Add("my-safe-header");

        // Replace the SCM HTTP logging policy with custom HTTP logging policy.
        options.HttpLoggingPolicy = new CustomHttpLoggingPolicy(options.Diagnostics);

        // The only HTTP logging this client will do is via the custom policy.
        RequestResponseClient client = new RequestResponseClient(options);
    }

    [Test]
    public void CanAddCustomHttpLoggingAndPreserveScmHttpLogging_NoDI()
    {
        RequestResponseClientOptions options = new();
        options.Diagnostics.AllowedHeaderNames.Add("my-safe-header");

        // Add custom HTTP logging to the pipeline, in addition to SCM HTTP logging.
        options.AddPolicy(
            new CustomHttpLoggingPolicy(options.Diagnostics),
            PipelinePosition.BeforeTransport);

        // This client will log HTTP details in both the SCM HTTP logging policy
        // and the custom HTTP logging policy.
        RequestResponseClient client = new RequestResponseClient(options);
    }

    [Test]
    public void CanAddCustomHttpLogging_WithDI()
    {
        // TBD
    }

    #region Helpers
    public class CustomHttpLoggingPolicy : PipelinePolicy
    {
        private readonly ILogger _iLogger;

        public CustomHttpLoggingPolicy(DiagnosticOptions options)
        {
            _iLogger = options.LoggerFactory?.CreateLogger("CustomHttpLoggingPolicy") ?? NullLogger.Instance;
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            ProcessNext(message, pipeline, currentIndex);

            _iLogger.LogInformation("Response status code: {CorrelationId}, {Status}", message.Response!.ClientRequestId, message.Response!.Status);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            await ProcessNextAsync(message, pipeline, currentIndex);

            _iLogger.LogInformation("Response status code: {CorrelationId}, {Status}", message.Response!.ClientRequestId, message.Response!.Status);
        }
    }
    #endregion
}
