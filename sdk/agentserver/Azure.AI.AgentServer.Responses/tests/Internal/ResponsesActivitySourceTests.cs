// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

/// <summary>
/// Tests for <see cref="ResponsesActivitySource"/>: constants, the virtual
/// <see cref="ResponsesActivitySource.PropagateResponseBaggage"/> method,
/// and subclass composition patterns.
/// </summary>
public sealed class ResponsesActivitySourceTests : IDisposable
{
    private readonly ActivitySource _testSource = new($"Test.ResponsesUnit.{Guid.NewGuid():N}");
    private readonly List<ActivityListener> _listeners = new();

    public ResponsesActivitySourceTests()
    {
        var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == _testSource.Name,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(listener);
        _listeners.Add(listener);
    }

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

    // ── PropagateResponseBaggage — baggage on Activity.Current ──────────

    [Test]
    public void PropagateResponseBaggage_SetsBaggageOnCurrentActivity()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "gpt-4o", Stream = true };

        source.PropagateResponseBaggage(request, "caresp_123", EmptyHeaders());

        Assert.That(parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.ResponseId), Is.EqualTo("caresp_123"));
        Assert.That(parent.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming), Is.EqualTo("True"));
        Assert.That(parent.GetBaggageItem(ResponsesTracingConstants.Baggage.ConversationId), Is.EqualTo(string.Empty));
    }

    [Test]
    public void PropagateResponseBaggage_DoesNotCreateNewActivity()
    {
        using var parent = _testSource.StartActivity("test-parent");
        var activityBefore = Activity.Current;

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "test" };

        source.PropagateResponseBaggage(request, "caresp_456", EmptyHeaders());

        Assert.That(Activity.Current, Is.SameAs(activityBefore));
    }

    [Test]
    public void PropagateResponseBaggage_SetsConversationId()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse
        {
            Model = "test",
            Conversation = BinaryData.FromString("\"conv_xyz\"")
        };

        source.PropagateResponseBaggage(request, "caresp_789", EmptyHeaders());

        Assert.That(parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.ConversationId), Is.EqualTo("conv_xyz"));
    }

    [Test]
    public void PropagateResponseBaggage_NonStreaming_SetsFalse()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "test" };

        source.PropagateResponseBaggage(request, "id", EmptyHeaders());

        Assert.That(parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.Streaming), Is.EqualTo("False"));
    }

    [Test]
    public void PropagateResponseBaggage_XRequestId_SetsBaggage()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "test" };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-abc" };

        source.PropagateResponseBaggage(request, "id", headers);

        Assert.That(parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId), Is.EqualTo("req-abc"));
    }

    [Test]
    public void PropagateResponseBaggage_NoXRequestId_OmitsRequestIdBaggage()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "test" };

        source.PropagateResponseBaggage(request, "id", EmptyHeaders());

        Assert.That(parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId), Is.Null);
    }

    [Test]
    public void PropagateResponseBaggage_LongXRequestId_TruncatedTo256()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "test" };
        var longId = new string('x', 512);
        var headers = new HeaderDictionary { ["X-Request-Id"] = longId };

        source.PropagateResponseBaggage(request, "id", headers);

        var baggageValue = parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.RequestId);
        Assert.That(baggageValue, Is.Not.Null);
        Assert.That(baggageValue!.Length, Is.EqualTo(256));
    }

    [Test]
    public void PropagateResponseBaggage_NoOp_WhenNoCurrentActivity()
    {
        // Ensure no current activity
        Activity.Current = null;

        var source = new ResponsesActivitySource();
        var request = new CreateResponse { Model = "test" };

        // Should not throw
        Assert.DoesNotThrow(() =>
            source.PropagateResponseBaggage(request, "id", EmptyHeaders()));
    }

    [Test]
    public void PropagateResponseBaggage_RemovedShortKeyBaggage_NotPresent()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ResponsesActivitySource();
        var request = new CreateResponse
        {
            Model = "test",
            Stream = true,
            Conversation = BinaryData.FromString("\"conv_xyz\"")
        };
        var headers = new HeaderDictionary { ["X-Request-Id"] = "req-999" };

        source.PropagateResponseBaggage(request, "caresp_rm", headers);

        // Short-key baggage items should not be present
        Assert.That(parent!.GetBaggageItem("response.id"), Is.Null);
        Assert.That(parent.GetBaggageItem("streaming"), Is.Null);
        Assert.That(parent.GetBaggageItem("provider.name"), Is.Null);
        Assert.That(parent.GetBaggageItem("conversation.id"), Is.Null);
        Assert.That(parent.GetBaggageItem("agent.name"), Is.Null);
        Assert.That(parent.GetBaggageItem("agent.id"), Is.Null);
        Assert.That(parent.GetBaggageItem("request.id"), Is.Null);
    }

    // ── Virtual override ─────────────────────────────────────────────────

    [Test]
    public void VirtualOverride_CanAddExtraBaggage()
    {
        using var parent = _testSource.StartActivity("test-parent");
        Assert.That(parent, Is.Not.Null);

        var source = new ExtraBaggageActivitySource();
        var request = new CreateResponse { Model = "test" };

        source.PropagateResponseBaggage(request, "caresp_override", EmptyHeaders());

        // Base baggage present
        Assert.That(parent!.GetBaggageItem(ResponsesTracingConstants.Baggage.ResponseId), Is.EqualTo("caresp_override"));
        // Extra baggage from override
        Assert.That(parent.GetBaggageItem("custom.baggage"), Is.EqualTo("custom-value"));
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
    /// Override that adds extra baggage after calling base.
    /// </summary>
    private sealed class ExtraBaggageActivitySource : ResponsesActivitySource
    {
        public override void PropagateResponseBaggage(
            CreateResponse request, string responseId, IHeaderDictionary headers)
        {
            base.PropagateResponseBaggage(request, responseId, headers);
            Activity.Current?.AddBaggage("custom.baggage", "custom-value");
        }
    }

    // ── Helpers ──────────────────────────────────────────────────────────

    private static IHeaderDictionary EmptyHeaders() => new HeaderDictionary();

    public void Dispose()
    {
        _testSource.Dispose();
        foreach (var l in _listeners)
            l.Dispose();
    }
}
