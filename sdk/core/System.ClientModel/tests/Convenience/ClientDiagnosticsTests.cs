// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

[NonParallelizable]
public class ClientDiagnosticsTests
{
    private const string TestNamespace = "SampleClients";
    private const string ActivitySourceName = "SampleClients.Client";
    private const string ScopeName = "Client.Method";
    private const string ScmScopeLabel = "scm.sdk.scope";
    private static readonly string ScmScopeValue = bool.TrueString;

    #region DiagnosticScopeFactory

    [Test]
    public void CreateScopeReturnsDisabledScopeWhenTracingDisabled()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: false);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.Start();

        Assert.IsFalse(scope.IsEnabled);
        Assert.IsNull(Activity.Current);
        Assert.AreEqual(0, listener.Activities.Count);
    }

    [Test]
    public void CreateScopeStartsActivityWhenEnabled()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        Assert.IsTrue(scope.IsEnabled);

        scope.Start();

        Assert.IsNotNull(Activity.Current);
        Assert.AreEqual(ScopeName, Activity.Current!.OperationName);
        Assert.AreEqual(ActivityKind.Internal, Activity.Current.Kind);
        Assert.AreEqual(1, listener.Activities.Count);
    }

    [Test]
    public void CreateScopeUsesRequestedActivityKind()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName, ActivityKind.Client);
        scope.Start();

        Assert.IsNotNull(Activity.Current);
        Assert.AreEqual(ActivityKind.Client, Activity.Current!.Kind);
    }

    [Test]
    [TestCase(ActivityKind.Client, ActivityKind.Client)]
    [TestCase(ActivityKind.Internal, ActivityKind.Internal)]
    [TestCase(ActivityKind.Internal, ActivityKind.Client)]
    [TestCase(ActivityKind.Client, ActivityKind.Internal)]
    public void NestedClientAndInternalScopesAreSuppressed(ActivityKind parentKind, ActivityKind childKind)
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true, suppressNestedClientActivities: true);

        using DiagnosticScope parent = factory.CreateScope(ScopeName, parentKind);
        parent.Start();

        using DiagnosticScope child = factory.CreateScope(ScopeName, childKind);

        Assert.IsTrue(parent.IsEnabled);
        Assert.AreEqual(ScmScopeValue, Activity.Current!.GetCustomProperty(ScmScopeLabel));
        Assert.IsFalse(child.IsEnabled);
    }

    [Test]
    [TestCase(ActivityKind.Producer, ActivityKind.Producer)]
    [TestCase(ActivityKind.Client, ActivityKind.Server)]
    [TestCase(ActivityKind.Internal, ActivityKind.Producer)]
    public void NestedNonClientScopesAreNotSuppressed(ActivityKind parentKind, ActivityKind childKind)
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true, suppressNestedClientActivities: true);

        using DiagnosticScope parent = factory.CreateScope(ScopeName, parentKind);
        parent.Start();

        using DiagnosticScope child = factory.CreateScope(ScopeName, childKind);

        Assert.IsTrue(parent.IsEnabled);
        Assert.IsTrue(child.IsEnabled);
    }

    [Test]
    public void NestedScopesAreNotSuppressedWhenSuppressionDisabled()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true, suppressNestedClientActivities: false);

        using DiagnosticScope parent = factory.CreateScope(ScopeName);
        parent.Start();

        using DiagnosticScope child = factory.CreateScope(ScopeName);

        Assert.IsTrue(parent.IsEnabled);
        Assert.IsTrue(child.IsEnabled);
    }

    #endregion

    #region ClientDiagnostics

    [Test]
    public void ClientDiagnosticsCreatesScopeWithExplicitNamespace()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        ClientPipelineOptions options = new() { EnableDistributedTracing = true };
        ClientDiagnostics diagnostics = new(TestNamespace, options);

        using DiagnosticScope scope = diagnostics.CreateScope(ScopeName);
        scope.Start();

        Assert.IsTrue(scope.IsEnabled);
        Assert.IsNotNull(Activity.Current);
        Assert.AreEqual(ScopeName, Activity.Current!.OperationName);
        Assert.AreEqual(1, listener.Activities.Count);
    }

    [Test]
    public void ClientDiagnosticsRespectsDisabledTracing()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        ClientPipelineOptions options = new() { EnableDistributedTracing = false };
        ClientDiagnostics diagnostics = new(TestNamespace, options);

        using DiagnosticScope scope = diagnostics.CreateScope(ScopeName);
        scope.Start();

        Assert.IsFalse(scope.IsEnabled);
        Assert.IsNull(Activity.Current);
        Assert.AreEqual(0, listener.Activities.Count);
    }

    [Test]
    public void ClientDiagnosticsEnablesTracingByDefault()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        ClientPipelineOptions options = new();
        ClientDiagnostics diagnostics = new(TestNamespace, options);

        using DiagnosticScope scope = diagnostics.CreateScope(ScopeName);
        scope.Start();

        Assert.IsTrue(scope.IsEnabled);
        Assert.IsNotNull(Activity.Current);
        Assert.AreEqual(1, listener.Activities.Count);
    }

    #endregion

    #region DiagnosticScope

    [Test]
    public void DefaultScopeIsDisabledAndNoOp()
    {
        DiagnosticScope scope = default;

        Assert.IsFalse(scope.IsEnabled);

        // None of these should throw on a disabled scope.
        Assert.DoesNotThrow(() =>
        {
            scope.Start();
            scope.AddAttribute("key", "value");
            scope.AddIntegerAttribute("int", 1);
            scope.AddLongAttribute("long", 1L);
            scope.SetDisplayName("display");
            scope.Failed("error");
            scope.Dispose();
        });
    }

    [Test]
    public void AttributesAddedBeforeStartAreApplied()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.AddAttribute("stringKey", "stringValue");
        scope.AddIntegerAttribute("intKey", 42);
        scope.AddLongAttribute("longKey", 100L);
        scope.Start();

        Activity activity = Activity.Current!;
        Assert.AreEqual("stringValue", activity.GetTagItem("stringKey"));
        Assert.AreEqual(42, activity.GetTagItem("intKey"));
        Assert.AreEqual(100L, activity.GetTagItem("longKey"));
    }

    [Test]
    public void AttributesAddedAfterStartAreApplied()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.Start();
        scope.AddAttribute("stringKey", "stringValue");

        Assert.AreEqual("stringValue", Activity.Current!.GetTagItem("stringKey"));
    }

    [Test]
    public void NullAttributeValueIsIgnored()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.AddAttribute("nullKey", (string?)null);
        scope.Start();

        Assert.IsNull(Activity.Current!.GetTagItem("nullKey"));
    }

    [Test]
    public void AttributeWithCustomFormatterIsApplied()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.AddAttribute("formatted", 5, static value => $"value-{value}");
        scope.Start();

        Assert.AreEqual("value-5", Activity.Current!.GetTagItem("formatted"));
    }

    [Test]
    public void SetDisplayNameOverridesOperationName()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.Start();
        scope.SetDisplayName("Custom Display Name");

        Assert.AreEqual("Custom Display Name", Activity.Current!.DisplayName);
    }

    [Test]
    public void AddLinkBeforeStartIsApplied()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        ActivityTraceId traceId = ActivityTraceId.CreateRandom();
        ActivitySpanId spanId = ActivitySpanId.CreateRandom();
        string traceparent = $"00-{traceId}-{spanId}-01";

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.AddLink(traceparent, null);
        scope.Start();

        Activity activity = Activity.Current!;
        Assert.AreEqual(1, activity.Links.Count());
        Assert.AreEqual(traceId, activity.Links.Single().Context.TraceId);
        Assert.AreEqual(spanId, activity.Links.Single().Context.SpanId);
    }

    [Test]
    public void SetTraceContextBeforeStartSetsParent()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        ActivityTraceId traceId = ActivityTraceId.CreateRandom();
        ActivitySpanId spanId = ActivitySpanId.CreateRandom();
        string traceparent = $"00-{traceId}-{spanId}-01";

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.SetTraceContext(traceparent);
        scope.Start();

        Activity activity = Activity.Current!;
        Assert.AreEqual(spanId, activity.ParentSpanId);
        StringAssert.Contains(traceId.ToString(), activity.ParentId);
    }

    [Test]
    public void FailedWithExceptionSetsErrorStatusAndType()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.Start();

        InvalidOperationException exception = new("boom");
        scope.Failed(exception);

        Activity activity = Activity.Current!;
        Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
        Assert.AreEqual("boom", activity.StatusDescription);
        Assert.AreEqual("System.InvalidOperationException", activity.GetTagItem("error.type"));
    }

    [Test]
    public void FailedWithClientResultExceptionUsesStatusAsErrorType()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.Start();

        MockPipelineResponse response = new(500, "Internal Server Error");
        ClientResultException exception = new("failed", response);
        scope.Failed(exception);

        Activity activity = Activity.Current!;
        Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
        Assert.AreEqual("500", activity.GetTagItem("error.type"));
    }

    [Test]
    public void FailedWithErrorCodeSetsErrorStatusAndType()
    {
        using TestClientActivityListener listener = new(ActivitySourceName);
        DiagnosticScopeFactory factory = new(TestNamespace, isActivityEnabled: true);

        using DiagnosticScope scope = factory.CreateScope(ScopeName);
        scope.Start();
        scope.Failed("MyErrorCode");

        Activity activity = Activity.Current!;
        Assert.AreEqual(ActivityStatusCode.Error, activity.Status);
        Assert.AreEqual("MyErrorCode", activity.GetTagItem("error.type"));
    }

    #endregion
}
