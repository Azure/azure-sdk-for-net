// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests verifying that <see cref="ResponsesActivitySource"/> can be
/// subclassed to customize distributed tracing activity creation.
/// Tests both the default behaviour and the composition pattern:
/// call <c>base</c>, then selectively override tags via <c>SetTag</c>.
/// </summary>
public sealed class CustomActivitySourceProtocolTests
{
    // ── Default behaviour (no override) ──────────────────────────────────

    [Test]
    public async Task Default_ServiceName_IsAzureAiAgentserver()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo(ResponsesTracingConstants.ProviderName));
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ServiceName], Is.EqualTo(ResponsesTracingConstants.ServiceName));
    }

    [Test]
    public async Task Default_ActivityName_IncludesModel()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test-model" });

        Assert.That(env.DisplayName, Is.EqualTo("invoke_agent test-model"));
    }

    [Test]
    public async Task Default_ActivityName_NoModel_JustCreateResponse()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { });

        Assert.That(env.DisplayName, Is.EqualTo("invoke_agent"));
    }

    [Test]
    public async Task Default_Baggage_HasNamespacedKeys()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True);
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.Streaming), Is.True);
        // Short-key baggage removed
        Assert.That(env.Baggage.ContainsKey("provider.name"), Is.False);
    }

    // ── Composition pattern: base + selective SetTag ─────────────────────

    [Test]
    public async Task Composition_OverridesServiceIdentity_ViaSetTag()
    {
        using var env = CreateEnvWithCustomSource<CustomServiceNameActivitySource>();
        await env.PostAsync(new { model = "test" });

        // Overridden tags
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo("my.custom.provider"));
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ServiceName], Is.EqualTo("my.custom.provider"));

        // Base defaults still present
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.OperationName], Is.EqualTo(ResponsesTracingConstants.OperationName));
    }

    [Test]
    public async Task Composition_AddsNamespaceTag()
    {
        using var env = CreateEnvWithCustomSource<NamespaceActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Tags["service.namespace"], Is.EqualTo("my.namespace"));
        // Other base defaults intact
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo(ResponsesTracingConstants.ProviderName));
    }

    [Test]
    public async Task Composition_ReadsCustomHeader()
    {
        using var env = CreateEnvWithCustomSource<TenantHeaderActivitySource>();
        await env.PostWithHeadersAsync(
            new { model = "test" },
            ("X-Tenant-Id", "tenant-abc"));

        Assert.That(env.Tags["tenant.id"], Is.EqualTo("tenant-abc"));
        // Base defaults still present
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo(ResponsesTracingConstants.ProviderName));
    }

    [Test]
    public async Task Composition_StillSetsResponseId()
    {
        using var env = CreateEnvWithCustomSource<CustomServiceNameActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Tags.ContainsKey(ResponsesTracingConstants.Tags.ResponseId), Is.True);
        var responseId = env.Tags[ResponsesTracingConstants.Tags.ResponseId] as string;
        Assert.That(responseId, Is.Not.Null);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task Composition_BaseAndExtend_PreservesDefaults()
    {
        using var env = CreateEnvWithCustomSource<ExtendedActivitySource>();
        await env.PostAsync(new { model = "test" });

        // Base defaults present
        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo(ResponsesTracingConstants.ProviderName));
        // Plus the extra tag from the subclass
        Assert.That(env.Tags["custom.extended"], Is.EqualTo("extended-value"));
    }

    // ── Full override (no base call) ─────────────────────────────────────

    [Test]
    public async Task FullOverride_CanSetCompletelyDifferentTags()
    {
        using var env = CreateEnvWithCustomSource<MinimalActivitySource>();
        await env.PostAsync(new { model = "gpt-4o" });

        Assert.That(env.DisplayName, Is.EqualTo("minimal-op"));
        Assert.That(env.Tags.ContainsKey("custom.tag"), Is.True);
        Assert.That(env.Tags["custom.tag"], Is.EqualTo("yes"));

        // Default GenAI tags NOT present (base not called)
        Assert.That(env.Tags.ContainsKey(ResponsesTracingConstants.Tags.ProviderName), Is.False);
        Assert.That(env.Tags.ContainsKey(ResponsesTracingConstants.Tags.ServiceName), Is.False);
    }

    [Test]
    public async Task FullOverride_CustomActivityName()
    {
        using var env = CreateEnvWithCustomSource<CustomNameActivitySource>();
        await env.PostAsync(new { model = "gpt-4o" });

        Assert.That(env.DisplayName, Is.Not.Null);
        XAssert.StartsWith("HostedAgents-caresp_", env.DisplayName);
    }

    [Test]
    public async Task CustomSubclass_RegisteredViaDI_TakesPrecedence()
    {
        // Register custom source BEFORE AddResponsesServer — TryAddSingleton skips default
        using var env = CreateEnvWithCustomSource<CustomServiceNameActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Tags[ResponsesTracingConstants.Tags.ProviderName], Is.EqualTo("my.custom.provider"));
    }

    // ── Custom ActivitySource subclasses ─────────────────────────────────

    /// <summary>
    /// Test-visible subclass that allows constructor with name parameter.
    /// </summary>
    private class TestableActivitySource : ResponsesActivitySource
    {
        public TestableActivitySource(string? name) : base(name) { }
    }

    /// <summary>
    /// Composition pattern: call base, then override service identity tags.
    /// </summary>
    private sealed class CustomServiceNameActivitySource : TestableActivitySource
    {
        public CustomServiceNameActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = base.StartCreateResponseActivity(request, responseId, headers);
            if (activity is null)
                return null;

            activity.SetTag(ResponsesTracingConstants.Tags.ProviderName, "my.custom.provider");
            activity.SetTag(ResponsesTracingConstants.Tags.ServiceName, "my.custom.provider");
            return activity;
        }
    }

    /// <summary>
    /// Composition pattern: call base, then add namespace tag.
    /// </summary>
    private sealed class NamespaceActivitySource : TestableActivitySource
    {
        public NamespaceActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = base.StartCreateResponseActivity(request, responseId, headers);
            activity?.SetTag("service.namespace", "my.namespace");
            return activity;
        }
    }

    /// <summary>
    /// Composition pattern: call base, then read a custom header.
    /// </summary>
    private sealed class TenantHeaderActivitySource : TestableActivitySource
    {
        public TenantHeaderActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = base.StartCreateResponseActivity(request, responseId, headers);
            if (activity is not null && headers.TryGetValue("X-Tenant-Id", out var tenantId))
            {
                activity.SetTag("tenant.id", tenantId.ToString());
            }
            return activity;
        }
    }

    /// <summary>
    /// Full override: completely replaces default behaviour.
    /// </summary>
    private sealed class CustomNameActivitySource : TestableActivitySource
    {
        public CustomNameActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = Source.StartActivity($"HostedAgents-{responseId}");
            if (activity is null)
                return null;
            activity.SetTag(ResponsesTracingConstants.Tags.ResponseId, responseId);
            return activity;
        }
    }

    /// <summary>
    /// Full override: minimal tags, no base call.
    /// </summary>
    private sealed class MinimalActivitySource : TestableActivitySource
    {
        public MinimalActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = Source.StartActivity("minimal-op");
            activity?.SetTag("custom.tag", "yes");
            return activity;
        }
    }

    /// <summary>
    /// Composition pattern: call base, add extra tag.
    /// </summary>
    private sealed class ExtendedActivitySource : TestableActivitySource
    {
        public ExtendedActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = base.StartCreateResponseActivity(request, responseId, headers);
            activity?.SetTag("custom.extended", "extended-value");
            return activity;
        }
    }

    // ── Test infrastructure ──────────────────────────────────────────────

    private static TestEnv CreateEnv()
    {
        return new TestEnv();
    }

    private static TestEnv CreateEnvWithCustomSource<TSource>()
        where TSource : TestableActivitySource
    {
        return new TestEnv(typeof(TSource));
    }

    private sealed class TestEnv : IDisposable
    {
        private readonly ActivityListener _listener;
        private readonly TestHandler _handler;
        private readonly TestWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly string _sourceName;

        public readonly Dictionary<string, object?> Tags = new();
        public readonly Dictionary<string, string?> Baggage = new();
        public string? DisplayName;

        public TestEnv(Type? customSourceType = null)
        {
            _sourceName = $"Test.CustomSource.{Guid.NewGuid():N}";

            _listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == _sourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                    ActivitySamplingResult.AllDataAndRecorded,
            };
            ActivitySource.AddActivityListener(_listener);

            _handler = new TestHandler();
            _handler.EventFactory = (request, context, ct) =>
                CaptureAndYield(request, context, ct);

            // Register custom or default source with unique name for test isolation
            Action<IServiceCollection> configureTestServices = services =>
            {
                var name = _sourceName;
                if (customSourceType is not null)
                {
                    services.AddSingleton<ResponsesActivitySource>(sp =>
                        (ResponsesActivitySource)Activator.CreateInstance(customSourceType, name)!);
                }
                else
                {
                    services.AddSingleton<ResponsesActivitySource>(sp =>
                        new TestableActivitySource(name));
                }
            };

            _factory = new TestWebApplicationFactory(_handler,
                configureTestServices: configureTestServices);
            _client = _factory.CreateClient();
        }

        private async IAsyncEnumerable<ResponseStreamEvent> CaptureAndYield(
            CreateResponse request,
            ResponseContext context,
            [System.Runtime.CompilerServices.EnumeratorCancellation] System.Threading.CancellationToken ct)
        {
            var current = Activity.Current;
            if (current is not null)
            {
                DisplayName = current.DisplayName;
                foreach (var tag in current.TagObjects)
                {
                    Tags[tag.Key] = tag.Value;
                }
                foreach (var b in current.Baggage)
                {
                    Baggage.TryAdd(b.Key, b.Value);
                }
            }

            var response = new Models.ResponseObject(context.ResponseId, request.Model ?? "test");
            yield return new ResponseCreatedEvent(0, response);
            response.SetCompleted();
            yield return new ResponseCompletedEvent(0, response);
        }

        public async Task PostAsync(object payload)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/responses", content);
            Assert.That(response.IsSuccessStatusCode, Is.True, $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task PostWithHeadersAsync(object payload, params (string Key, string Value)[] extraHeaders)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(payload),
                    System.Text.Encoding.UTF8, "application/json")
            };
            foreach (var (key, value) in extraHeaders)
            {
                request.Headers.Add(key, value);
            }
            var response = await _client.SendAsync(request);
            Assert.That(response.IsSuccessStatusCode, Is.True, $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        }

        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
            _listener.Dispose();
        }
    }
}
