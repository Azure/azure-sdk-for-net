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
    public async Task Default_ServiceName_IsAzureAiResponses()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.AreEqual("azure.ai.responses", env.Tags["gen_ai.provider.name"]);
        Assert.AreEqual("azure.ai.responses", env.Tags["service.name"]);
        Assert.AreEqual("azure.ai.responses", env.Tags["gen_ai.system"]);
    }

    [Test]
    public async Task Default_ActivityName_IncludesModel()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test-model" });

        Assert.AreEqual("create_response test-model", env.DisplayName);
    }

    [Test]
    public async Task Default_ActivityName_NoModel_JustCreateResponse()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { });

        Assert.AreEqual("create_response", env.DisplayName);
    }

    [Test]
    public async Task Default_Baggage_ProviderName_IsAzureAiResponses()
    {
        using var env = CreateEnv();
        await env.PostAsync(new { model = "test" });

        Assert.AreEqual("azure.ai.responses", env.Baggage["provider.name"]);
    }

    // ── Composition pattern: base + selective SetTag ─────────────────────

    [Test]
    public async Task Composition_OverridesServiceIdentity_ViaSetTag()
    {
        using var env = CreateEnvWithCustomSource<CustomServiceNameActivitySource>();
        await env.PostAsync(new { model = "test" });

        // Overridden tags
        Assert.AreEqual("my.custom.provider", env.Tags["gen_ai.provider.name"]);
        Assert.AreEqual("my.custom.provider", env.Tags["service.name"]);
        Assert.AreEqual("my.custom.provider", env.Tags["gen_ai.system"]);
        // Overridden baggage
        Assert.AreEqual("my.custom.provider", env.Baggage["provider.name"]);

        // Base defaults still present
        Assert.AreEqual("create_response", env.Tags["gen_ai.operation.name"]);
    }

    [Test]
    public async Task Composition_AddsNamespaceTag()
    {
        using var env = CreateEnvWithCustomSource<NamespaceActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.AreEqual("my.namespace", env.Tags["service.namespace"]);
        // Other base defaults intact
        Assert.AreEqual("azure.ai.responses", env.Tags["gen_ai.provider.name"]);
    }

    [Test]
    public async Task Composition_ReadsCustomHeader()
    {
        using var env = CreateEnvWithCustomSource<TenantHeaderActivitySource>();
        await env.PostWithHeadersAsync(
            new { model = "test" },
            ("X-Tenant-Id", "tenant-abc"));

        Assert.AreEqual("tenant-abc", env.Tags["tenant.id"]);
        // Base defaults still present
        Assert.AreEqual("azure.ai.responses", env.Tags["gen_ai.provider.name"]);
    }

    [Test]
    public async Task Composition_StillSetsResponseId()
    {
        using var env = CreateEnvWithCustomSource<CustomServiceNameActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.IsTrue(env.Tags.ContainsKey("gen_ai.response.id"));
        var responseId = env.Tags["gen_ai.response.id"] as string;
        Assert.IsNotNull(responseId);
        XAssert.StartsWith("caresp_", responseId);
    }

    [Test]
    public async Task Composition_BaseAndExtend_PreservesDefaults()
    {
        using var env = CreateEnvWithCustomSource<ExtendedActivitySource>();
        await env.PostAsync(new { model = "test" });

        // Base defaults present
        Assert.AreEqual("azure.ai.responses", env.Tags["gen_ai.provider.name"]);
        // Plus the extra tag from the subclass
        Assert.AreEqual("extended-value", env.Tags["custom.extended"]);
    }

    // ── Full override (no base call) ─────────────────────────────────────

    [Test]
    public async Task FullOverride_CanSetCompletelyDifferentTags()
    {
        using var env = CreateEnvWithCustomSource<MinimalActivitySource>();
        await env.PostAsync(new { model = "gpt-4o" });

        Assert.AreEqual("minimal-op", env.DisplayName);
        Assert.IsTrue(env.Tags.ContainsKey("custom.tag"));
        Assert.AreEqual("yes", env.Tags["custom.tag"]);

        // Default GenAI tags NOT present (base not called)
        Assert.IsFalse(env.Tags.ContainsKey("gen_ai.provider.name"));
        Assert.IsFalse(env.Tags.ContainsKey("service.name"));
        Assert.IsFalse(env.Tags.ContainsKey("gen_ai.system"));
    }

    [Test]
    public async Task FullOverride_CustomActivityName()
    {
        using var env = CreateEnvWithCustomSource<CustomNameActivitySource>();
        await env.PostAsync(new { model = "gpt-4o" });

        Assert.IsNotNull(env.DisplayName);
        XAssert.StartsWith("HostedAgents-caresp_", env.DisplayName);
    }

    [Test]
    public async Task CustomSubclass_RegisteredViaDI_TakesPrecedence()
    {
        // Register custom source BEFORE AddResponsesServer — TryAddSingleton skips default
        using var env = CreateEnvWithCustomSource<CustomServiceNameActivitySource>();
        await env.PostAsync(new { model = "test" });

        Assert.AreEqual("my.custom.provider", env.Tags["gen_ai.provider.name"]);
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
            if (activity is null) return null;

            activity.SetTag("gen_ai.provider.name", "my.custom.provider");
            activity.SetTag("service.name", "my.custom.provider");
            activity.SetTag("gen_ai.system", "my.custom.provider");
            activity.AddBaggage("provider.name", "my.custom.provider");
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
            if (activity is null) return null;
            activity.SetTag("gen_ai.response.id", responseId);
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
            IResponseContext context,
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

            var response = new Models.Response(context.ResponseId, request.Model ?? "test");
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
            Assert.IsTrue(response.IsSuccessStatusCode,
                $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
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
            Assert.IsTrue(response.IsSuccessStatusCode,
                $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        }

        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
            _listener.Dispose();
        }
    }
}
