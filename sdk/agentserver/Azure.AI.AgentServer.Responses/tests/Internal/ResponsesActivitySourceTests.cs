// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
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
        Assert.That(ResponsesActivitySource.DefaultName, Is.EqualTo("Azure.AI.AgentServer.Responses"));
    }

    [Test]
    public void DefaultServiceName_IsExpected()
    {
        Assert.That(ResponsesActivitySource.DefaultServiceName, Is.EqualTo(ResponsesTracingConstants.ServiceName));
    }

    [Test]
    public void DefaultProviderName_IsExpected()
    {
        Assert.That(ResponsesActivitySource.DefaultProviderName, Is.EqualTo(ResponsesTracingConstants.ProviderName));
    }

    // ── Constructor / Name ───────────────────────────────────────────────

    [Test]
    public void DefaultConstructor_UsesDefaultName()
    {
        var source = new ResponsesActivitySource();
        Assert.That(source.Name, Is.EqualTo("Azure.AI.AgentServer.Responses"));
    }

    [Test]
    public void CustomName_UsesProvidedValue()
    {
        var source = new TestActivitySource("My.Custom.Source");
        Assert.That(source.Name, Is.EqualTo("My.Custom.Source"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void NullOrEmptyName_FallsBackToDefault(string? name)
    {
        var source = new TestActivitySource(name);
        Assert.That(source.Name, Is.EqualTo("Azure.AI.AgentServer.Responses"));
    }

    // ── StartCreateResponseActivity — tags ───────────────────────────────

    [Test]
    public void StartCreateResponseActivity_SetsGenAiTags()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "gpt-4o", Stream = true };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_123", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.Kind, Is.EqualTo(ActivityKind.Server));
        Assert.That(activity.DisplayName, Is.EqualTo("invoke_agent gpt-4o"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ResponseId), Is.EqualTo("caresp_123"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName), Is.EqualTo(ResponsesTracingConstants.ProviderName));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ServiceName), Is.EqualTo(ResponsesTracingConstants.ServiceName));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.OperationName), Is.EqualTo(ResponsesTracingConstants.OperationName));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.RequestModel), Is.EqualTo("gpt-4o"));
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

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedResponseId), Is.EqualTo("caresp_parity"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedConversationId), Is.EqualTo("conv_abc"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming), Is.EqualTo(true));
    }

    [Test]
    public void StartCreateResponseActivity_NonStreaming_SetsStreamingFalse()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_ns", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedStreaming), Is.EqualTo(false));
    }

    [Test]
    public void StartCreateResponseActivity_SetsFoundryProjectId_WhenEnvSet()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID",
            "/subscriptions/1234/resourceGroups/rg/providers/Microsoft.MachineLearningServices/workspaces/ws");
        FoundryEnvironment.Reload();

        try
        {
            var source = CreateListeningSource();
            var request = new CreateResponse { Model = "test" };

            using var activity = source.StartCreateResponseActivity(
                request, "caresp_proj", EmptyHeaders());

            Assert.That(activity, Is.Not.Null);
            Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.FoundryProjectId),
                Is.EqualTo("/subscriptions/1234/resourceGroups/rg/providers/Microsoft.MachineLearningServices/workspaces/ws"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
            FoundryEnvironment.Reload();
        }
    }

    [Test]
    public void StartCreateResponseActivity_SetsFoundryProjectId_EmptyWhenNoEnv()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID", null);
        FoundryEnvironment.Reload();

        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_noproj", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.FoundryProjectId),
            Is.EqualTo(string.Empty));
    }

    [Test]
    public void StartCreateResponseActivity_NoConversation_SetsEmptyConversationId()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.NamespacedConversationId), Is.EqualTo(string.Empty));
    }

    [Test]
    public void StartCreateResponseActivity_RemovedTags_NotPresent()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test", Stream = true };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-123" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.That(activity, Is.Not.Null);
        // response.mode and request.id tags were removed for parity
        Assert.That(activity.GetTagItem("response.mode"), Is.Null);
        Assert.That(activity.GetTagItem("request.id"), Is.Null);
    }

    [Test]
    public void StartCreateResponseActivity_EmptyModel_OmitsModelTag()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.DisplayName, Is.EqualTo("invoke_agent"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.RequestModel), Is.Null);
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

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentName), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId), Is.EqualTo("my-agent:1.0"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentVersion), Is.EqualTo("1.0"));
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

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentName), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId), Is.EqualTo("my-agent"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentVersion), Is.Null);
    }

    [Test]
    public void StartCreateResponseActivity_NoAgent_SetsEmptyAgentId()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentName), Is.Null);
        // Core parity: gen_ai.agent.id = "" when agent is null
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentId), Is.EqualTo(string.Empty));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.AgentVersion), Is.Null);
    }

    [Test]
    public void StartCreateResponseActivity_XRequestId_SetsBaggageOnly()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-abc" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.That(activity, Is.Not.Null);
        // X-Request-Id is no longer a span tag — only baggage
        Assert.That(activity.GetTagItem("request.id"), Is.Null);
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId), Is.EqualTo("req-abc"));
    }

    [Test]
    public void StartCreateResponseActivity_NoXRequestId_OmitsRequestIdBaggage()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId), Is.Null);
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

        Assert.That(activity, Is.Not.Null);
        var baggageValue = activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId);
        Assert.That(baggageValue, Is.Not.Null);
        Assert.That(baggageValue!.Length, Is.EqualTo(256));
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

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ConversationId), Is.EqualTo("conv_123"));
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

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ResponseId), Is.EqualTo("caresp_456"));
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ConversationId), Is.EqualTo("conv_xyz"));
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming), Is.EqualTo("True"));
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId), Is.EqualTo("req-999"));
    }

    [Test]
    public void StartCreateResponseActivity_MinimalRequest_SetsRequiredBaggage()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "caresp_789", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ResponseId), Is.EqualTo("caresp_789"));
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.ConversationId), Is.EqualTo(string.Empty));
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming), Is.EqualTo("False"));
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId), Is.Null);
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

        Assert.That(activity, Is.Not.Null);
        // Short-key baggage items were removed for parity
        Assert.That(activity.GetBaggageItem("response.id"), Is.Null);
        Assert.That(activity.GetBaggageItem("streaming"), Is.Null);
        Assert.That(activity.GetBaggageItem("provider.name"), Is.Null);
        Assert.That(activity.GetBaggageItem("conversation.id"), Is.Null);
        Assert.That(activity.GetBaggageItem("agent.name"), Is.Null);
        Assert.That(activity.GetBaggageItem("agent.id"), Is.Null);
        Assert.That(activity.GetBaggageItem("request.id"), Is.Null);
    }

    // ── Composition pattern: base + selective override ───────────────────

    [Test]
    public void SetTag_ReplacesExistingValue()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName), Is.EqualTo(ResponsesTracingConstants.ProviderName));

        // SetTag replaces existing value
        activity.SetTag(ResponsesTracingConstants.Tags.ProviderName, "my-custom-provider");
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName), Is.EqualTo("my-custom-provider"));
    }

    [Test]
    public void AddBaggage_GetBaggageItem_ReturnsMostRecentValue()
    {
        var source = CreateListeningSource();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming), Is.EqualTo("False"));

        // AddBaggage prepends — GetBaggageItem returns most recent
        activity.AddBaggage(ResponsesTracingConstants.Baggage.Streaming, "True");
        Assert.That(activity.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming), Is.EqualTo("True"));
    }

    [Test]
    public void VirtualOverride_CanCompletelyReplaceBehaviour()
    {
        var source = CreateListeningSource<FullOverrideActivitySource>();
        var request = new CreateResponse { Model = "test" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", EmptyHeaders());

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.DisplayName, Is.EqualTo("custom-op"));
        Assert.That(activity.GetTagItem("custom.tag"), Is.EqualTo("overridden"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName), Is.Null); // base not called
    }

    [Test]
    public void VirtualOverride_CanCallBaseAndSelectively_OverrideTags()
    {
        var source = CreateListeningSource<SelectiveOverrideActivitySource>();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary { ["X-Custom"] = "hello" };

        using var activity = source.StartCreateResponseActivity(
            request, "id", headers);

        Assert.That(activity, Is.Not.Null);

        // Base defaults present
        Assert.That(activity.DisplayName, Is.EqualTo("invoke_agent test"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.OperationName), Is.EqualTo("invoke_agent"));

        // Overridden tags
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ProviderName), Is.EqualTo("my-service"));
        Assert.That(activity.GetTagItem(ResponsesTracingConstants.Tags.ServiceName), Is.EqualTo("my-service"));

        // Extra tags from custom header
        Assert.That(activity.GetTagItem("custom.header"), Is.EqualTo("hello"));
        Assert.That(activity.GetTagItem("service.namespace"), Is.EqualTo("my.ns"));
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

        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.GetTagItem("tenant.id"), Is.EqualTo("tenant-123"));
        Assert.That(activity.GetTagItem("correlation.id"), Is.EqualTo("corr-456"));
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
            if (activity is null)
                return null;

            // Replace service identity
            activity.SetTag(ResponsesTracingConstants.Tags.ProviderName, "my-service");
            activity.SetTag(ResponsesTracingConstants.Tags.ServiceName, "my-service");

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
            if (activity is null)
                return null;

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
