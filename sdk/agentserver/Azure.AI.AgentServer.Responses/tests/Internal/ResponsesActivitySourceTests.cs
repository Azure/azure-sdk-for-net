using System.Diagnostics;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

/// <summary>
/// Tests for <see cref="ResponsesActivitySource"/>: name defaults, the virtual
/// <see cref="ResponsesActivitySource.StartCreateResponseActivity"/> method,
/// and the composition pattern (call base → override specific tags).
/// </summary>
public sealed class ResponsesActivitySourceTests : IDisposable
{
    private readonly List<ActivityListener> _listeners = new();

    // ── Constants ────────────────────────────────────────────────────────

    [Test]
    public void DefaultName_IsExpected()
    {
        Assert.AreEqual("Azure.AI.AgentServer.Responses", ResponsesActivitySource.DefaultName);
    }

    [Test]
    public void DefaultServiceName_IsExpected()
    {
        Assert.AreEqual("azure.ai.responses", ResponsesActivitySource.DefaultServiceName);
    }

    // ── Constructor / Name ───────────────────────────────────────────────

    [Test]
    public void DefaultConstructor_UsesDefaultName()
    {
        var source = new ResponsesActivitySource();
        Assert.AreEqual("Azure.AI.AgentServer.Responses", source.Name);
    }

    [Test]
    public void CustomName_UsesProvidedValue()
    {
        var source = new TestActivitySource("My.Custom.Source");
        Assert.AreEqual("My.Custom.Source", source.Name);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void NullOrEmptyName_FallsBackToDefault(string? name)
    {
        var source = new TestActivitySource(name);
        Assert.AreEqual("Azure.AI.AgentServer.Responses", source.Name);
    }

    // ── StartCreateResponseActivity — tags ───────────────────────────────

    [Test]
    public void StartCreateResponseActivity_SetsGenAiTags()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "gpt-4o", Stream = true };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_123", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("create_response gpt-4o", activity.DisplayName);
        Assert.AreEqual("caresp_123", activity.GetTagItem("gen_ai.response.id"));
        Assert.AreEqual("azure.ai.responses", activity.GetTagItem("gen_ai.provider.name"));
        Assert.AreEqual("azure.ai.responses", activity.GetTagItem("service.name"));
        Assert.AreEqual("azure.ai.responses", activity.GetTagItem("gen_ai.system"));
        Assert.AreEqual("create_response", activity.GetTagItem("gen_ai.operation.name"));
        Assert.AreEqual("gpt-4o", activity.GetTagItem("gen_ai.request.model"));
    }

    [Test]
    public void StartCreateResponseActivity_ModeTag_Streaming()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test", Stream = true };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("streaming", activity.GetTagItem("response.mode"));
    }

    [Test]
    public void StartCreateResponseActivity_ModeTag_Background()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test", Background = true };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("background", activity.GetTagItem("response.mode"));
    }

    [Test]
    public void StartCreateResponseActivity_ModeTag_StreamingBackground()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test", Stream = true, Background = true };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("streaming+background", activity.GetTagItem("response.mode"));
    }

    [Test]
    public void StartCreateResponseActivity_ModeTag_Default()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("default", activity.GetTagItem("response.mode"));
    }

    [Test]
    public void StartCreateResponseActivity_EmptyModel_OmitsModelTag()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("create_response", activity.DisplayName);
        Assert.IsNull(activity.GetTagItem("gen_ai.request.model"));
    }

    [Test]
    public void StartCreateResponseActivity_AgentTags_WithVersion()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse
        {
            Model = "test",
            AgentReference = new AgentReference("my-agent") { Version = "1.0" }
        };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("my-agent", activity.GetTagItem("gen_ai.agent.name"));
        Assert.AreEqual("my-agent:1.0", activity.GetTagItem("gen_ai.agent.id"));
        Assert.AreEqual("1.0", activity.GetTagItem("gen_ai.agent.version"));
    }

    [Test]
    public void StartCreateResponseActivity_AgentTags_WithoutVersion()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse
        {
            Model = "test",
            AgentReference = new AgentReference("my-agent")
        };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("my-agent", activity.GetTagItem("gen_ai.agent.name"));
        Assert.AreEqual("my-agent", activity.GetTagItem("gen_ai.agent.id"));
        Assert.IsNull(activity.GetTagItem("gen_ai.agent.version"));
    }

    [Test]
    public void StartCreateResponseActivity_NoAgent_OmitsAgentTags()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.IsNull(activity.GetTagItem("gen_ai.agent.name"));
        Assert.IsNull(activity.GetTagItem("gen_ai.agent.id"));
        Assert.IsNull(activity.GetTagItem("gen_ai.agent.version"));
    }

    [Test]
    public void StartCreateResponseActivity_XRequestId_FromHeaders()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-abc" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);
        Assert.AreEqual("req-abc", activity.GetTagItem("request.id"));
    }

    [Test]
    public void StartCreateResponseActivity_NoXRequestId_OmitsTag()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.IsNull(activity.GetTagItem("request.id"));
    }

    [Test]
    public void StartCreateResponseActivity_LongXRequestId_TruncatedTo256()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };
        var longId = new string('x', 512);
        var headers = new HeaderDictionary { ["X-Request-Id"] = longId };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);
        var tagValue = activity.GetTagItem("request.id") as string;
        Assert.IsNotNull(tagValue);
        Assert.AreEqual(256, tagValue!.Length);
    }

    [Test]
    public void StartCreateResponseActivity_ConversationId_SetsTag()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse
        {
            Model = "test",
            Conversation = BinaryData.FromString("\"conv_123\"")
        };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("conv_123", activity.GetTagItem("gen_ai.conversation.id"));
    }

    // ── StartCreateResponseActivity — baggage ────────────────────────────

    [Test]
    public void StartCreateResponseActivity_SetsBaggageItems()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse
        {
            Model = "test",
            Stream = true,
            AgentReference = new AgentReference("my-agent") { Version = "2.0" },
            Conversation = BinaryData.FromString("\"conv_xyz\"")
        };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-999" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_456", headers);

        Assert.IsNotNull(activity);
        Assert.AreEqual("caresp_456", activity.GetBaggageItem("response.id"));
        Assert.AreEqual("true", activity.GetBaggageItem("streaming"));
        Assert.AreEqual("azure.ai.responses", activity.GetBaggageItem("provider.name"));
        Assert.AreEqual("conv_xyz", activity.GetBaggageItem("conversation.id"));
        Assert.AreEqual("my-agent", activity.GetBaggageItem("agent.name"));
        Assert.AreEqual("my-agent:2.0", activity.GetBaggageItem("agent.id"));
        Assert.AreEqual("req-999", activity.GetBaggageItem("request.id"));
    }

    [Test]
    public void StartCreateResponseActivity_NoBaggage_ForMissingOptionalFields()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_789", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("caresp_789", activity.GetBaggageItem("response.id"));
        Assert.AreEqual("false", activity.GetBaggageItem("streaming"));
        Assert.AreEqual("azure.ai.responses", activity.GetBaggageItem("provider.name"));
        Assert.IsNull(activity.GetBaggageItem("conversation.id"));
        Assert.IsNull(activity.GetBaggageItem("agent.name"));
        Assert.IsNull(activity.GetBaggageItem("agent.id"));
        Assert.IsNull(activity.GetBaggageItem("request.id"));
    }

    // ── Composition pattern: base + selective override ───────────────────

    [Test]
    public void SetTag_ReplacesExistingValue()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("azure.ai.responses", activity.GetTagItem("gen_ai.provider.name"));

        // SetTag replaces existing value
        activity.SetTag("gen_ai.provider.name", "my-custom-provider");
        Assert.AreEqual("my-custom-provider", activity.GetTagItem("gen_ai.provider.name"));
    }

    [Test]
    public void AddBaggage_GetBaggageItem_ReturnsMostRecentValue()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("azure.ai.responses", activity.GetBaggageItem("provider.name"));

        // AddBaggage prepends — GetBaggageItem returns most recent
        activity.AddBaggage("provider.name", "my-custom-provider");
        Assert.AreEqual("my-custom-provider", activity.GetBaggageItem("provider.name"));
    }

    [Test]
    public void VirtualOverride_CanCompletelyReplaceBehaviour()
    {
        var source = CreateListeningSource<FullOverrideActivitySource>();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("custom-op", activity.DisplayName);
        Assert.AreEqual("overridden", activity.GetTagItem("custom.tag"));
        Assert.IsNull(activity.GetTagItem("gen_ai.provider.name")); // base not called
    }

    [Test]
    public void VirtualOverride_CanCallBaseAndSelectively_OverrideTags()
    {
        var source = CreateListeningSource<SelectiveOverrideActivitySource>();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary { ["X-Custom"] = "hello" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);

        // Base defaults present
        Assert.AreEqual("create_response test", activity.DisplayName);
        Assert.AreEqual("create_response", activity.GetTagItem("gen_ai.operation.name"));

        // Overridden tags
        Assert.AreEqual("my-service", activity.GetTagItem("gen_ai.provider.name"));
        Assert.AreEqual("my-service", activity.GetTagItem("service.name"));
        Assert.AreEqual("my-service", activity.GetTagItem("gen_ai.system"));

        // Extra tags from custom header
        Assert.AreEqual("hello", activity.GetTagItem("custom.header"));
        Assert.AreEqual("my.ns", activity.GetTagItem("service.namespace"));

        // Overridden baggage
        Assert.AreEqual("my-service", activity.GetBaggageItem("provider.name"));
    }

    [Test]
    public void VirtualOverride_CanReadCustomHeaders()
    {
        var source = CreateListeningSource<HeaderReadingActivitySource>();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary
        {
            ["X-Tenant-Id"] = "tenant-123",
            ["X-Correlation-Id"] = "corr-456"
        };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);
        Assert.AreEqual("tenant-123", activity.GetTagItem("tenant.id"));
        Assert.AreEqual("corr-456", activity.GetTagItem("correlation.id"));
    }

    // ── Test subclasses ──────────────────────────────────────────────────

    /// <summary>
    /// Subclass that exposes a custom name constructor for testing.
    /// </summary>
    private class TestActivitySource : ResponsesActivitySource
    {
        public TestActivitySource(string? name) : base(name) { }
    }

    /// <summary>
    /// Completely replaces default behaviour.
    /// </summary>
    private sealed class FullOverrideActivitySource : TestActivitySource
    {
        public FullOverrideActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = Source.StartActivity("custom-op");
            activity?.SetTag("custom.tag", "overridden");
            return activity;
        }
    }

    /// <summary>
    /// Calls base, then selectively replaces service identity and reads a custom header.
    /// Demonstrates the composition pattern with zero duplication of default logic.
    /// </summary>
    private sealed class SelectiveOverrideActivitySource : TestActivitySource
    {
        public SelectiveOverrideActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = base.StartCreateResponseActivity(request, responseId, headers);
            if (activity is null) return null;

            // Replace service identity
            activity.SetTag("gen_ai.provider.name", "my-service");
            activity.SetTag("service.name", "my-service");
            activity.SetTag("gen_ai.system", "my-service");
            activity.AddBaggage("provider.name", "my-service");

            // Add extra tags
            activity.SetTag("service.namespace", "my.ns");
            if (headers.TryGetValue("X-Custom", out var customVal))
            {
                activity.SetTag("custom.header", customVal.ToString());
            }

            return activity;
        }
    }

    /// <summary>
    /// Reads arbitrary custom headers to show the headers dict pattern.
    /// </summary>
    private sealed class HeaderReadingActivitySource : TestActivitySource
    {
        public HeaderReadingActivitySource(string? name) : base(name) { }

        public override Activity? StartCreateResponseActivity(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            var activity = base.StartCreateResponseActivity(request, responseId, headers);
            if (activity is null) return null;

            if (headers.TryGetValue("X-Tenant-Id", out var tenantId))
                activity.SetTag("tenant.id", tenantId.ToString());

            if (headers.TryGetValue("X-Correlation-Id", out var corrId))
                activity.SetTag("correlation.id", corrId.ToString());

            return activity;
        }
    }

    // ── Helpers ──────────────────────────────────────────────────────────

    private ResponsesActivitySource CreateListeningSource()
    {
        return CreateListeningSource<TestActivitySource>();
    }

    private T CreateListeningSource<T>() where T : TestActivitySource
    {
        var name = $"Test.{Guid.NewGuid():N}";
        AddListener(name);
        return (T)Activator.CreateInstance(typeof(T), name)!;
    }

    private void AddListener(string sourceName)
    {
        var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);
        _listeners.Add(listener);
    }

    private static IHeaderDictionary EmptyHeaders() => new HeaderDictionary();

    public void Dispose()
    {
        foreach (var l in _listeners)
            l.Dispose();
    }
}
