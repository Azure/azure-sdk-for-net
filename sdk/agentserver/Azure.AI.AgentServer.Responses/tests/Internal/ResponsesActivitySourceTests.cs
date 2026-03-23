// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        Assert.AreEqual(ResponsesTracingConstants.ServiceName, ResponsesActivitySource.DefaultServiceName);
    }

    [Test]
    public void DefaultProviderName_IsExpected()
    {
        Assert.AreEqual(ResponsesTracingConstants.ProviderName, ResponsesActivitySource.DefaultProviderName);
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
        Assert.AreEqual("caresp_123", activity.GetTagItem(ResponsesTracingConstants.Tags.ResponseId));
        Assert.AreEqual(ResponsesTracingConstants.ProviderName, activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName));
        Assert.AreEqual(ResponsesTracingConstants.ServiceName, activity.GetTagItem(ResponsesTracingConstants.Tags.ServiceName));
        Assert.AreEqual(ResponsesTracingConstants.ServiceName, activity.GetTagItem(ResponsesTracingConstants.Tags.System));
        Assert.AreEqual(ResponsesTracingConstants.OperationName, activity.GetTagItem(ResponsesTracingConstants.Tags.OperationName));
        Assert.AreEqual("gpt-4o", activity.GetTagItem(ResponsesTracingConstants.Tags.RequestModel));
    }

    // ── Namespaced parity tags (azure.ai.agentserver.responses.*) ─────

    [Test]
    public void StartCreateResponseActivity_SetsNamespacedParityTags()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse
        {
            Model = "test",
            Stream = true,
            Conversation = BinaryData.FromString("\"conv_abc\"")
        };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_parity", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("caresp_parity", activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedResponseId));
        Assert.AreEqual("conv_abc", activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedConversationId));
        Assert.AreEqual(true, activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming));
    }

    [Test]
    public void StartCreateResponseActivity_NonStreaming_SetsStreamingFalse()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_ns", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual(false, activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming));
    }

    [Test]
    public void StartCreateResponseActivity_NoConversation_SetsEmptyConversationId()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual(string.Empty, activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedConversationId));
    }

    [Test]
    public void StartCreateResponseActivity_RemovedTags_NotPresent()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test", Stream = true };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-123" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);
        // response.mode and request.id tags were removed for parity
        Assert.IsNull(activity.GetTagItem("response.mode"));
        Assert.IsNull(activity.GetTagItem("request.id"));
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
        Assert.IsNull(activity.GetTagItem(ResponsesTracingConstants.Tags.RequestModel));
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
        Assert.AreEqual("my-agent", activity.GetTagItem(ResponsesTracingConstants.Tags.AgentName));
        Assert.AreEqual("my-agent:1.0", activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId));
        Assert.AreEqual("1.0", activity.GetTagItem(ResponsesTracingConstants.Tags.AgentVersion));
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
        Assert.AreEqual("my-agent", activity.GetTagItem(ResponsesTracingConstants.Tags.AgentName));
        Assert.AreEqual("my-agent", activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId));
        Assert.IsNull(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentVersion));
    }

    [Test]
    public void StartCreateResponseActivity_NoAgent_SetsEmptyAgentId()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.IsNull(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentName));
        // Core parity: gen_ai.agent.id = "" when agent is null
        Assert.AreEqual(string.Empty, activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId));
        Assert.IsNull(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentVersion));
    }

    [Test]
    public void StartCreateResponseActivity_XRequestId_SetsBaggageOnly()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-abc" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);
        // X-Request-Id is no longer a span tag — only baggage
        Assert.IsNull(activity.GetTagItem("request.id"));
        Assert.AreEqual("req-abc", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId));
    }

    [Test]
    public void StartCreateResponseActivity_NoXRequestId_OmitsRequestIdBaggage()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.IsNull(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId));
    }

    [Test]
    public void StartCreateResponseActivity_LongXRequestId_BaggageTruncatedTo256()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };
        var longId = new string('x', 512);
        var headers = new HeaderDictionary { ["X-Request-Id"] = longId };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.IsNotNull(activity);
        var baggageValue = activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId);
        Assert.IsNotNull(baggageValue);
        Assert.AreEqual(256, baggageValue!.Length);
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
        Assert.AreEqual("conv_123", activity.GetTagItem(ResponsesTracingConstants.Tags.ConversationId));
    }

    // ── StartCreateResponseActivity — baggage ────────────────────────────

    [Test]
    public void StartCreateResponseActivity_SetsNamespacedBaggageItems()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse
        {
            Model = "test",
            Stream = true,
            Conversation = BinaryData.FromString("\"conv_xyz\"")
        };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-999" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_456", headers);

        Assert.IsNotNull(activity);
        Assert.AreEqual("caresp_456", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ResponseId));
        Assert.AreEqual("conv_xyz", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ConversationId));
        Assert.AreEqual("True", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming));
        Assert.AreEqual("req-999", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId));
    }

    [Test]
    public void StartCreateResponseActivity_MinimalRequest_SetsRequiredBaggage()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_789", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("caresp_789", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ResponseId));
        Assert.AreEqual(string.Empty, activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ConversationId));
        Assert.AreEqual("False", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming));
        Assert.IsNull(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId));
    }

    [Test]
    public void StartCreateResponseActivity_RemovedShortKeyBaggage_NotPresent()
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
            request, "caresp_rm", headers);

        Assert.IsNotNull(activity);
        // Short-key baggage items were removed for parity
        Assert.IsNull(activity.GetBaggageItem("response.id"));
        Assert.IsNull(activity.GetBaggageItem("streaming"));
        Assert.IsNull(activity.GetBaggageItem("provider.name"));
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
        Assert.AreEqual(ResponsesTracingConstants.ProviderName, activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName));

        // SetTag replaces existing value
        activity.SetTag(ResponsesTracingConstants.Tags.ProviderName, "my-custom-provider");
        Assert.AreEqual("my-custom-provider", activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName));
    }

    [Test]
    public void AddBaggage_GetBaggageItem_ReturnsMostRecentValue()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.IsNotNull(activity);
        Assert.AreEqual("False", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming));

        // AddBaggage prepends — GetBaggageItem returns most recent
        activity.AddBaggage(ResponsesTracingConstants.Baggage.Streaming, "True");
        Assert.AreEqual("True", activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming));
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
        Assert.IsNull(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName)); // base not called
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
        Assert.AreEqual("create_response", activity.GetTagItem(ResponsesTracingConstants.Tags.OperationName));

        // Overridden tags
        Assert.AreEqual("my-service", activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName));
        Assert.AreEqual("my-service", activity.GetTagItem(ResponsesTracingConstants.Tags.ServiceName));
        Assert.AreEqual("my-service", activity.GetTagItem(ResponsesTracingConstants.Tags.System));

        // Extra tags from custom header
        Assert.AreEqual("hello", activity.GetTagItem("custom.header"));
        Assert.AreEqual("my.ns", activity.GetTagItem("service.namespace"));
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
            activity.SetTag(ResponsesTracingConstants.Tags.ProviderName, "my-service");
            activity.SetTag(ResponsesTracingConstants.Tags.ServiceName, "my-service");
            activity.SetTag(ResponsesTracingConstants.Tags.System, "my-service");

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
