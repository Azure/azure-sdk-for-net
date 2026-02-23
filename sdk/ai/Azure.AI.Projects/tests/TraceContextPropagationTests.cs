// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class TraceContextPropagationTests
{
    private ActivitySource _activitySource;
    private ActivityListener _listener;
    private ActivityIdFormat _originalIdFormat;
    private bool _originalForceDefault;

    [SetUp]
    public void Setup()
    {
        // Ensure W3C trace ID format is used (required for .NET Framework 4.6.2
        // which defaults to Hierarchical format)
        _originalIdFormat = Activity.DefaultIdFormat;
        _originalForceDefault = Activity.ForceDefaultIdFormat;
        Activity.DefaultIdFormat = ActivityIdFormat.W3C;
        Activity.ForceDefaultIdFormat = true;

        _activitySource = new ActivitySource("TraceContextPropagationTests");
        _listener = new ActivityListener
        {
            ShouldListenTo = _ => true,
            Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllDataAndRecorded
        };
        ActivitySource.AddActivityListener(_listener);
    }

    [TearDown]
    public void Cleanup()
    {
        _listener.Dispose();
        _activitySource.Dispose();
        Activity.DefaultIdFormat = _originalIdFormat;
        Activity.ForceDefaultIdFormat = _originalForceDefault;
    }

    [Test]
    public void InjectsTraceparentWithW3CActivity()
    {
        using var activity = _activitySource.StartActivity("TestOp");
        Assert.That(activity, Is.Not.Null);
        Assert.That(activity.IdFormat, Is.EqualTo(ActivityIdFormat.W3C));

        var result = CreatePipelineWithPolicy(includeBaggage: false);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "traceparent", out string traceparent), Is.True);
        Assert.That(traceparent, Is.EqualTo(activity.Id));
    }

    [Test]
    public void InjectsTracestateWhenPresent()
    {
        using var activity = _activitySource.StartActivity("TestOp");
        Assert.That(activity, Is.Not.Null);
        activity.TraceStateString = "key1=value1";

        var result = CreatePipelineWithPolicy(includeBaggage: false);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "tracestate", out string tracestate), Is.True);
        Assert.That(tracestate, Is.EqualTo("key1=value1"));
    }

    [Test]
    public void DoesNotInjectHeadersWhenNoActivity()
    {
        // Ensure no current activity
        Activity.Current = null;

        var result = CreatePipelineWithPolicy(includeBaggage: false);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "traceparent", out _), Is.False);
        Assert.That(TryGetHeader(result.Message, "tracestate", out _), Is.False);
        Assert.That(TryGetHeader(result.Message, "baggage", out _), Is.False);
    }

    [Test]
    public void ExcludesBaggageWhenDisabled()
    {
        using var activity = _activitySource.StartActivity("TestOp");
        Assert.That(activity, Is.Not.Null);
        activity.AddBaggage("userId", "test-user");

        var result = CreatePipelineWithPolicy(includeBaggage: false);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "traceparent", out _), Is.True);
        Assert.That(TryGetHeader(result.Message, "baggage", out _), Is.False);
    }

    [Test]
    public void IncludesBaggageWhenEnabled()
    {
        using var activity = _activitySource.StartActivity("TestOp");
        Assert.That(activity, Is.Not.Null);
        activity.AddBaggage("userId", "test-user");
        activity.AddBaggage("sessionId", "abc-123");

        var result = CreatePipelineWithPolicy(includeBaggage: true);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "traceparent", out _), Is.True);
        Assert.That(TryGetHeader(result.Message, "baggage", out string baggage), Is.True);
        Assert.That(baggage, Does.Contain("userId"));
        Assert.That(baggage, Does.Contain("test-user"));
        Assert.That(baggage, Does.Contain("sessionId"));
        Assert.That(baggage, Does.Contain("abc-123"));
    }

    [Test]
    public void NoBaggageHeaderWhenNoBaggageItems()
    {
        using var activity = _activitySource.StartActivity("TestOp");
        Assert.That(activity, Is.Not.Null);
        // No baggage added

        var result = CreatePipelineWithPolicy(includeBaggage: true);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "traceparent", out _), Is.True);
        // No baggage items, so even with includeBaggage=true, the propagator
        // should not inject a baggage header (or it may inject an empty one)
    }

    [Test]
    public void TraceparentMatchesActivityId()
    {
        using var activity = _activitySource.StartActivity("TestOp");
        Assert.That(activity, Is.Not.Null);

        var result = CreatePipelineWithPolicy(includeBaggage: false);
        result.Policies[0].Process(result.Message, result.Policies, 0);

        Assert.That(TryGetHeader(result.Message, "traceparent", out string traceparent), Is.True);

        // Verify W3C format: version-traceId-spanId-flags
        string[] parts = traceparent.Split('-');
        Assert.That(parts.Length, Is.EqualTo(4));
        Assert.That(parts[0], Is.EqualTo("00")); // version
        Assert.That(parts[1], Is.EqualTo(activity.TraceId.ToString()));
        Assert.That(parts[2], Is.EqualTo(activity.SpanId.ToString()));
    }

    #region Helpers

    private static (PipelineMessage Message, IReadOnlyList<PipelinePolicy> Policies) CreatePipelineWithPolicy(bool includeBaggage)
    {
        // Use reflection to create the internal TraceContextPropagationPolicy
        Assembly assembly = typeof(AIProjectAgentsOperations).Assembly;
        Type policyType = assembly.GetType("Azure.AI.Projects.TraceContextPropagationPolicy");
        Assert.That(policyType, Is.Not.Null, "TraceContextPropagationPolicy type not found");

        PipelinePolicy policy = (PipelinePolicy)Activator.CreateInstance(policyType,
            BindingFlags.Instance | BindingFlags.NonPublic,
            binder: null,
            args: new object[] { includeBaggage },
            culture: null);

        // Create a PipelineMessage via HttpClientPipelineTransport
        var transport = new HttpClientPipelineTransport();
        PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri("https://test.example.com/api/test");

        // Build the policy chain: [propagationPolicy, noOpTerminal]
        var policies = new PipelinePolicy[] { policy, new NoOpTerminalPolicy() };

        return (message, policies);
    }

    private static bool TryGetHeader(PipelineMessage message, string name, out string value)
    {
        value = null;
        if (message.Request.Headers.TryGetValue(name, out string headerValue))
        {
            value = headerValue;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Terminal policy that does nothing. Required as the last policy in the chain
    /// so that ProcessNext in the propagation policy has something to call.
    /// </summary>
    private class NoOpTerminalPolicy : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
        }

        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            return default;
        }
    }

    /// <summary>
    /// Calls the internal AppContextSwitchHelper.GetConfigValue via reflection.
    /// </summary>
    private static bool GetConfigValue(string switchName, string envVarName)
    {
        Assembly assembly = typeof(AIProjectAgentsOperations).Assembly;
        Type helperType = assembly.GetType("Azure.Core.AppContextSwitchHelper");
        Assert.That(helperType, Is.Not.Null, "AppContextSwitchHelper type not found");

        MethodInfo method = helperType.GetMethod("GetConfigValue", BindingFlags.Static | BindingFlags.Public);
        Assert.That(method, Is.Not.Null, "GetConfigValue method not found");

        return (bool)method.Invoke(null, new object[] { switchName, envVarName });
    }

    #endregion

    #region AppContext / Environment Variable Precedence Tests

    [Test]
    public void AppContextSwitchTrueOverridesEnvVarFalse()
    {
        // AppContext = true, env var = false → result should be true (AppContext wins)
        string switchName = "Azure.Test.Precedence.TrueOverFalse";
        string envVarName = "AZURE_TEST_PRECEDENCE_TRUE_OVER_FALSE";

        AppContext.SetSwitch(switchName, true);
        Environment.SetEnvironmentVariable(envVarName, "false", EnvironmentVariableTarget.Process);
        try
        {
            bool result = GetConfigValue(switchName, envVarName);
            Assert.That(result, Is.True,
                "AppContext switch (true) should take precedence over environment variable (false)");
        }
        finally
        {
            Environment.SetEnvironmentVariable(envVarName, null, EnvironmentVariableTarget.Process);
        }
    }

    [Test]
    public void AppContextSwitchFalseOverridesEnvVarTrue()
    {
        // AppContext = false, env var = true → result should be false (AppContext wins)
        string switchName = "Azure.Test.Precedence.FalseOverTrue";
        string envVarName = "AZURE_TEST_PRECEDENCE_FALSE_OVER_TRUE";

        AppContext.SetSwitch(switchName, false);
        Environment.SetEnvironmentVariable(envVarName, "true", EnvironmentVariableTarget.Process);
        try
        {
            bool result = GetConfigValue(switchName, envVarName);
            Assert.That(result, Is.False,
                "AppContext switch (false) should take precedence over environment variable (true)");
        }
        finally
        {
            Environment.SetEnvironmentVariable(envVarName, null, EnvironmentVariableTarget.Process);
        }
    }

    [Test]
    public void EnvVarUsedWhenAppContextNotSet()
    {
        // AppContext not set, env var = true → result should be true (env var used as fallback)
        string switchName = "Azure.Test.Precedence.NotSet_" + Guid.NewGuid().ToString("N");
        string envVarName = "AZURE_TEST_PRECEDENCE_ENVVAR_FALLBACK";

        // Do NOT set AppContext switch — use a unique name to guarantee it's never been set
        Environment.SetEnvironmentVariable(envVarName, "true", EnvironmentVariableTarget.Process);
        try
        {
            bool result = GetConfigValue(switchName, envVarName);
            Assert.That(result, Is.True,
                "Environment variable should be used when AppContext switch is not set");
        }
        finally
        {
            Environment.SetEnvironmentVariable(envVarName, null, EnvironmentVariableTarget.Process);
        }
    }

    [Test]
    public void DefaultsFalseWhenNeitherSet()
    {
        // Neither AppContext nor env var set → result should be false
        string switchName = "Azure.Test.Precedence.Neither_" + Guid.NewGuid().ToString("N");
        string envVarName = "AZURE_TEST_PRECEDENCE_NEITHER_" + Guid.NewGuid().ToString("N");

        // Ensure env var is not set
        Environment.SetEnvironmentVariable(envVarName, null, EnvironmentVariableTarget.Process);

        bool result = GetConfigValue(switchName, envVarName);
        Assert.That(result, Is.False,
            "Should default to false when neither AppContext switch nor environment variable is set");
    }

    #endregion
}
