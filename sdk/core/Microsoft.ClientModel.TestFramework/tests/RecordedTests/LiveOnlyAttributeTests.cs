// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class LiveOnlyAttributeTests
{
    [Test]
    public void ApplyToTestAlwaysAddsLiveCategory()
    {
        var attribute = new LiveOnlyAttribute();
        var test = CreateMockTest();

        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            attribute.ApplyToTest(test);
            var categories = test.Properties["Category"];
            Assert.That(categories, Contains.Item("Live"));
        }
    }

    [Test]
    public void ApplyToTestLiveModeDoesNotChangeRunState()
    {
        var attribute = new LiveOnlyAttribute();
        var test = CreateMockTest();

        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Runnable));
        }
    }

    [Test]
    public void ApplyToTestRecordModeSetsIgnoredState()
    {
        var attribute = new LiveOnlyAttribute(alwaysRunLocally: false);
        var test = CreateMockTest();

        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Record"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Ignored));
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.That(skipReason?.ToString(), Contains.Substring("Live tests will not run when CLIENTMODEL_TEST_MODE is Record"));
        }
    }

    [Test]
    public void ApplyToTestPlaybackModeSetsIgnoredState()
    {
        var attribute = new LiveOnlyAttribute(alwaysRunLocally: false);
        var test = CreateMockTest();

        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Playback"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Ignored));
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.That(skipReason?.ToString(), Contains.Substring("Live tests will not run when CLIENTMODEL_TEST_MODE is Playback"));
        }
    }

    [Test]
    public void ApplyToTestAlwaysRunLocallyTrueRunsInAllModes()
    {
        var attribute = new LiveOnlyAttribute(alwaysRunLocally: true);

        var testModes = new[] { "Live", "Record", "Playback" };

        foreach (var mode in testModes)
        {
            using (new TestEnvVar("CLIENTMODEL_TEST_MODE", mode))
            {
                var test = CreateMockTest();
                attribute.ApplyToTest(test);
                Assert.That(test.RunState, Is.EqualTo(RunState.Runnable), $"Should run in {mode} mode when alwaysRunLocally=true");

                // Should still add Live category regardless of mode
                var categories = test.Properties["Category"];
                Assert.That(categories, Contains.Item("Live"));
            }
        }
    }

    [Test]
    public void ApplyToTestAlwaysRunLocallyFalseOnlyRunsInLiveMode()
    {
        var attribute = new LiveOnlyAttribute(alwaysRunLocally: false);

        var nonLiveModes = new[] { "Record", "Playback" };

        foreach (var mode in nonLiveModes)
        {
            using (new TestEnvVar("CLIENTMODEL_TEST_MODE", mode))
            {
                var test = CreateMockTest();
                attribute.ApplyToTest(test);
                Assert.That(test.RunState, Is.EqualTo(RunState.Ignored), $"Should be ignored in {mode} mode when alwaysRunLocally=false");
            }
        }
    }

    [Test]
    public void ApplyToTestNotRunnableTestDoesNotChangeState()
    {
        var attribute = new LiveOnlyAttribute();
        var test = CreateMockTest();
        test.RunState = RunState.NotRunnable;

        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Record"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.NotRunnable));
        }
    }

    [Test]
    public void ApplyToTestDefaultModeSetsIgnoredState()
    {
        // When no environment variable is set, defaults to Playback mode
        var attribute = new LiveOnlyAttribute(alwaysRunLocally: false);
        var test = CreateMockTest();

        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", null))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Ignored));
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.That(skipReason?.ToString(), Contains.Substring("Live tests will not run when CLIENTMODEL_TEST_MODE is Playback"));
        }
    }

    [Test]
    public void ReasonPropertyCanBeSetAndRetrieved()
    {
        var attribute = new LiveOnlyAttribute();
        var reason = "Requires live authentication";

        attribute.Reason = reason;

        Assert.That(attribute.Reason, Is.EqualTo(reason));
    }

    [Test]
    public void ReasonPropertyDefaultsToNull()
    {
        var attribute = new LiveOnlyAttribute();
        Assert.That(attribute.Reason, Is.Null);
    }

    [Test]
    public void CanBeAppliedToMethod()
    {
        var method = typeof(TestClassWithLiveOnlyMethod).GetMethod(nameof(TestClassWithLiveOnlyMethod.LiveOnlyMethod));
        var attribute = method?.GetCustomAttribute<LiveOnlyAttribute>();
        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void CanBeAppliedToClass()
    {
        var attribute = typeof(LiveOnlyTestClass).GetCustomAttribute<LiveOnlyAttribute>();
        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void AttributeUsage_AllowsMethodClassAndAssembly()
    {
        var usage = typeof(LiveOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.That(usage, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(usage.ValidOn.HasFlag(AttributeTargets.Method), Is.True);
            Assert.That(usage.ValidOn.HasFlag(AttributeTargets.Class), Is.True);
            Assert.That(usage.ValidOn.HasFlag(AttributeTargets.Assembly), Is.True);
            Assert.That(usage.AllowMultiple, Is.False);
            Assert.That(usage.Inherited, Is.True);
        }
    }

    // Helper methods and classes
    private Test CreateMockTest()
    {
        var method = typeof(TestClassWithLiveOnlyMethod).GetMethod(nameof(TestClassWithLiveOnlyMethod.LiveOnlyMethod));
        var testMethod = new TestMethod(new MethodWrapper(typeof(TestClassWithLiveOnlyMethod), method!));
        testMethod.RunState = RunState.Runnable;
        return testMethod;
    }

    public class TestClassWithLiveOnlyMethod
    {
        [LiveOnly]
        public void LiveOnlyMethod()
        {
            // Live only test method
        }

        [LiveOnly(Reason = "Requires live service authentication")]
        public void LiveOnlyMethodWithReason()
        {
            // Live only test method with reason
        }
    }

    [LiveOnly]
    public class LiveOnlyTestClass
    {
        public void TestMethod()
        {
            // Method in live-only class
        }
    }
}
