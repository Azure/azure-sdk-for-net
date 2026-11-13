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
/// subclassed to customize baggage propagation during response processing.
/// Tests both the default behaviour and the composition pattern:
/// call <c>base</c>, then add extra baggage items.
/// </summary>
public sealed class CustomActivitySourceProtocolTests
{
    // ── Default behaviour (no override) ──────────────────────────────────

    [Test]
    public async Task Default_Baggage_HasNamespacedKeys()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True);
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.Streaming), Is.True);
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.ConversationId), Is.True);
        // Short-key baggage removed
        Assert.That(env.Baggage.ContainsKey("provider.name"), Is.False);
        Assert.That(env.Baggage.ContainsKey("streaming"), Is.False);
    }

    [Test]
    public async Task Default_Baggage_ResponseId_HasExpectedPrefix()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        var responseId = env.Baggage[ResponsesTracingConstants.Baggage.ResponseId];
        Assert.That(responseId, Is.Not.Null);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task Default_Baggage_StreamingIsTrue_WhenStreamSet()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test", stream = true });

        Assert.That(env.Baggage[ResponsesTracingConstants.Baggage.Streaming], Is.EqualTo("True"));
    }

    [Test]
    public async Task Default_Baggage_StreamingIsFalse_WhenStreamNotSet()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Baggage[ResponsesTracingConstants.Baggage.Streaming], Is.EqualTo("False"));
    }

    [Test]
    public async Task Default_NoInvokeAgentSpan_Created()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        // No invoke_agent span — Activity.Current is the ASP.NET Core request activity
        // (or null if no listener); we verify no custom display name was set
        if (env.DisplayName is not null)
        {
            Assert.That(env.DisplayName, Does.Not.Contain("invoke_agent"));
        }
    }

    // ── XRequestId propagation ──────────────────────────────────────────

    [Test]
    public async Task Default_XRequestId_PropagatedAsBaggage()
    {
        using var env = CreateEnv();
        await env.PostWithHeadersAsync(
            new { model = "test" },
            ("X-Request-Id", "req-abc-123"));

        Assert.That(env.Baggage[ResponsesTracingConstants.Baggage.RequestId], Is.EqualTo("req-abc-123"));
    }

    [Test]
    public async Task Default_NoXRequestId_OmittedFromBaggage()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.RequestId), Is.False);
    }

    // ── Composition pattern: base + extra baggage ────────────────────────

    [Test]
    public async Task Composition_AddsExtraBaggage_WhilePreservingDefaults()
    {
        using var env = CreateEnvWithCustomSource<ExtraBaggageActivitySource>();
        await env.PostAsync(new { model = "test" });

        // Base defaults present
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True);
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.Streaming), Is.True);
        // Extra baggage from override
        Assert.That(env.Baggage["custom.tenant"], Is.EqualTo("tenant-from-override"));
    }

    [Test]
    public async Task Composition_ReadsCustomHeader_AddsToBaggage()
    {
        using var env = CreateEnvWithCustomSource<TenantHeaderActivitySource>();
        await env.PostWithHeadersAsync(
            new { model = "test" },
            ("X-Tenant-Id", "tenant-abc"));

        // Base defaults present
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.True);
        // Custom baggage from header
        Assert.That(env.Baggage["custom.tenant.id"], Is.EqualTo("tenant-abc"));
    }

    // ── Full override (no base call) ─────────────────────────────────────

    [Test]
    public async Task FullOverride_CanSetCompletelyDifferentBaggage()
    {
        using var env = CreateEnvWithCustomSource<MinimalActivitySource>();
        await env.PostAsync(new { model = "gpt-4o" });

        // Custom baggage present
        Assert.That(env.Baggage["custom.only"], Is.EqualTo("minimal"));
        // Default baggage NOT present (base not called)
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.ResponseId), Is.False);
        Assert.That(env.Baggage.ContainsKey(ResponsesTracingConstants.Baggage.Streaming), Is.False);
    }

    [Test]
    public async Task CustomSubclass_RegisteredViaDI_TakesPrecedence()
    {
        using var env = CreateEnvWithCustomSource<ExtraBaggageActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.That(env.Baggage["custom.tenant"], Is.EqualTo("tenant-from-override"));
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
    /// Composition pattern: call base, then add extra baggage.
    /// </summary>
    private sealed class ExtraBaggageActivitySource : TestableActivitySource
    {
        public ExtraBaggageActivitySource(string? name) : base(name) { }

        public override void PropagateResponseBaggage(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            base.PropagateResponseBaggage(request, responseId, headers);
            Activity.Current?.AddBaggage("custom.tenant", "tenant-from-override");
        }
    }

    /// <summary>
    /// Composition pattern: call base, then read a custom header into baggage.
    /// </summary>
    private sealed class TenantHeaderActivitySource : TestableActivitySource
    {
        public TenantHeaderActivitySource(string? name) : base(name) { }

        public override void PropagateResponseBaggage(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            base.PropagateResponseBaggage(request, responseId, headers);
            if (headers.TryGetValue("X-Tenant-Id", out var tenantId))
            {
                Activity.Current?.AddBaggage("custom.tenant.id", tenantId.ToString());
            }
        }
    }

    /// <summary>
    /// Full override: completely replaces default baggage propagation.
    /// </summary>
    private sealed class MinimalActivitySource : TestableActivitySource
    {
        public MinimalActivitySource(string? name) : base(name) { }

        public override void PropagateResponseBaggage(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            // Intentionally do NOT call base — only set custom baggage
            Activity.Current?.AddBaggage("custom.only", "minimal");
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
                ShouldListenTo = _ => true,
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
