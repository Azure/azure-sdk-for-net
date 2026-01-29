// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Identity;
using Maps;
using NUnit.Framework;

namespace System.ClientModel.Tests.Samples;

public class ConfigurationSamples
{
    [Test]
    [Ignore("Used for README")]
    public void ClientModelConfigurationReadme()
    {
        #region Snippet:ClientModelConfigurationReadme

        MapsClientOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromSeconds(120),
        };

        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new(key!);
        MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);

        #endregion
    }

    [Test]
    [Ignore("Used for README")]
    public void ConfigurationCustomizeRetries()
    {
        #region Snippet:ConfigurationCustomizeRetries

        MapsClientOptions options = new()
        {
            RetryPolicy = new ClientRetryPolicy(maxRetries: 5),
        };

        string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
        ApiKeyCredential credential = new(key!);
        MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);

        #endregion
    }

    [Test]
    public void ConfigurationAddPolicies()
    {
        #region Snippet:ConfigurationAddPerCallPolicy
        MapsClientOptions options = new();
        options.AddPolicy(new StopwatchPolicy(), PipelinePosition.PerCall);
        #endregion

        #region Snippet:ConfigurationAddPerTryPolicy
        options.AddPolicy(new StopwatchPolicy(), PipelinePosition.PerTry);
        #endregion

        #region Snippet:ConfigurationAddBeforeTransportPolicy
        options.AddPolicy(new StopwatchPolicy(), PipelinePosition.BeforeTransport);
        #endregion
    }

    #region Snippet:ConfigurationCustomPolicy
    public class StopwatchPolicy : PipelinePolicy
    {
        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            await ProcessNextAsync(message, pipeline, currentIndex);

            stopwatch.Stop();

            Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            ProcessNext(message, pipeline, currentIndex);

            stopwatch.Stop();

            Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
        }
    }
    #endregion

    [Test]
    public void ConfigurationCustomHttpClient()
    {
        #region Snippet:ConfigurationCustomHttpClient
        using HttpClientHandler handler = new()
        {
            // Reduce the max connections per server, which defaults to 50.
            MaxConnectionsPerServer = 25,

            // Preserve default System.ClientModel redirect behavior.
            AllowAutoRedirect = false,
        };

        using HttpClient httpClient = new(handler);

        MapsClientOptions options = new()
        {
            Transport = new HttpClientPipelineTransport(httpClient)
        };
        #endregion
    }

    [Test]
    [Ignore("Used for documentation")]
    public void ConfigurationUserAgent()
    {
        #region Snippet:ConfigurationUserAgent
        MapsClientOptions options = new();

        // In a library's client class constructor:
        var userAgentPolicy = new UserAgentPolicy(Assembly.GetExecutingAssembly());
        ClientPipeline pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { userAgentPolicy },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        // With custom application ID:
        var customUserAgent = new UserAgentPolicy(Assembly.GetExecutingAssembly(), "MyApp/1.0");
        ClientPipeline pipeline2 = ClientPipeline.Create(
            options,
            perCallPolicies: new[] { customUserAgent },
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        #endregion
    }

    [Test]
    public void ConfigurationCustomNetworkTimeout()
    {
        ApiKeyCredential credential = new("myKey");

        #region Snippet:ConfigurationCustomNetworkTimeout
        MapsClientOptions options = new()
        {
            // Increase the default network timeout.
            NetworkTimeout = TimeSpan.FromMinutes(5)
        };
        MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
        #endregion
    }
}
