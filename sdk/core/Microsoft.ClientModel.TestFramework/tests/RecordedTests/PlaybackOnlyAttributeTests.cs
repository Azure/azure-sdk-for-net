// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Reflection;
namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class PlaybackOnlyAttributeTests
{
    [Test]
    public void ApplyToTestPlaybackModeDoesNotChangeRunState()
    {
        var attribute = new PlaybackOnlyAttribute("test reason");
        var test = CreateMockTest();
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Playback"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Runnable));
        }
    }

    [Test]
    public void ApplyToTestLiveModeSetsIgnoredState()
    {
        var reason = "Requires specific recorded responses";
        var attribute = new PlaybackOnlyAttribute(reason);
        var test = CreateMockTest();
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Ignored));
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.That(skipReason, Is.Not.Null);
            Assert.That(skipReason.ToString(), Contains.Substring("Playback tests will not run when CLIENTMODEL_TEST_MODE is Live"));
            Assert.That(skipReason.ToString(), Contains.Substring(reason));
        }
    }

    [Test]
    public void ApplyToTestRecordModeSetsIgnoredState()
    {
        var reason = "Test depends on specific playback data";
        var attribute = new PlaybackOnlyAttribute(reason);
        var test = CreateMockTest();
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Record"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.Ignored));
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.That(skipReason, Is.Not.Null);
            Assert.That(skipReason.ToString(), Contains.Substring("Playback tests will not run when CLIENTMODEL_TEST_MODE is Record"));
            Assert.That(skipReason.ToString(), Contains.Substring(reason));
        }
    }

    [Test]
    public void ApplyToTestNotRunnableTestDoesNotChangeState()
    {
        var attribute = new PlaybackOnlyAttribute("test reason");
        var test = CreateMockTest();
        test.RunState = RunState.NotRunnable;
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            attribute.ApplyToTest(test);
            Assert.That(test.RunState, Is.EqualTo(RunState.NotRunnable));
        }
    }

    [Test]
    public void ApplyToTestIncludesReasonInSkipMessage()
    {
        var reason = "This specific test requires recorded authentication flows";
        var attribute = new PlaybackOnlyAttribute(reason);
        var test = CreateMockTest();
        using (new TestEnvVar("CLIENTMODEL_TEST_MODE", "Live"))
        {
            attribute.ApplyToTest(test);
            var skipReason = test.Properties.Get("_SKIPREASON").ToString();
            Assert.That(skipReason, Contains.Substring(reason));
        }
    }

    [Test]
    public void CanBeAppliedToMethod()
    {
        var method = typeof(TestClassWithPlaybackOnlyMethod).GetMethod(nameof(TestClassWithPlaybackOnlyMethod.PlaybackOnlyMethod));
        var attribute = method.GetCustomAttribute<PlaybackOnlyAttribute>();
        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void CanBeAppliedToClass()
    {
        var attribute = typeof(PlaybackOnlyTestClass).GetCustomAttribute<PlaybackOnlyAttribute>();
        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void AllowMultipleIsTrue()
    {
        var usage = typeof(PlaybackOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.That(usage.AllowMultiple, Is.True);
    }

    [Test]
    public void DifferentFromLiveOnlyAttribute()
    {
        var playbackAttr = new PlaybackOnlyAttribute("test");
        var liveAttr = new LiveOnlyAttribute();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(playbackAttr, Is.InstanceOf<PlaybackOnlyAttribute>());
            Assert.That(liveAttr, Is.InstanceOf<LiveOnlyAttribute>());
        }
        Assert.That(liveAttr.GetType(), Is.Not.EqualTo(playbackAttr.GetType()));
    }

    // Helper methods and classes
    private Test CreateMockTest()
    {
        var method = typeof(TestClassWithPlaybackOnlyMethod).GetMethod(nameof(TestClassWithPlaybackOnlyMethod.PlaybackOnlyMethod));
        var testMethod = new TestMethod(new MethodWrapper(typeof(TestClassWithPlaybackOnlyMethod), method));
        testMethod.RunState = RunState.Runnable;
        return testMethod;
    }

    public class TestClassWithPlaybackOnlyMethod
    {
        [PlaybackOnly("Requires specific recorded data")]
        public void PlaybackOnlyMethod()
        {
            // Playback only test method
        }

        [PlaybackOnly("First reason")]
        [PlaybackOnly("Second reason")]
        public void MultiplePlaybackOnlyMethod()
        {
            // Method with multiple PlaybackOnly attributes
        }
    }

    [PlaybackOnly("Class-level playback only")]
    public class PlaybackOnlyTestClass
    {
        public void TestMethod()
        {
            // Method in playback-only class
        }
    }
}
