// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Reflection;
namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;
[TestFixture]
public class PlaybackOnlyAttributeTests
{
    [Test]
    public void Constructor_WithReason_CreatesValidInstance()
    {
        var reason = "This test requires specific recorded data";
        var attribute = new PlaybackOnlyAttribute(reason);
        Assert.IsNotNull(attribute);
        Assert.IsInstanceOf<PlaybackOnlyAttribute>(attribute);
    }
    [Test]
    public void Constructor_WithNullReason_AllowsNull()
    {
        var attribute = new PlaybackOnlyAttribute(null);
        Assert.IsNotNull(attribute);
    }
    [Test]
    public void Constructor_WithEmptyReason_AllowsEmpty()
    {
        var attribute = new PlaybackOnlyAttribute("");
        Assert.IsNotNull(attribute);
    }
    [Test]
    public void Inheritance_ExtendsNUnitAttribute()
    {
        var attribute = new PlaybackOnlyAttribute("test reason");
        Assert.IsInstanceOf<NUnitAttribute>(attribute);
    }
    [Test]
    public void Interface_ImplementsIApplyToTest()
    {
        var attribute = new PlaybackOnlyAttribute("test reason");
        Assert.IsInstanceOf<IApplyToTest>(attribute);
    }
    [Test]
    public void AttributeUsage_AllowsMethodClassAndAssembly()
    {
        var usage = typeof(PlaybackOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsNotNull(usage);
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Method));
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Class));
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Assembly));
        Assert.IsTrue(usage.AllowMultiple); // Unlike LiveOnly, PlaybackOnly allows multiple
        Assert.IsTrue(usage.Inherited);
    }
    [Test]
    public void ApplyToTest_WithPlaybackMode_DoesNotChangeRunState()
    {
        var attribute = new PlaybackOnlyAttribute("test reason");
        var test = CreateMockTest();
        using (new MockTestEnvironment(RecordedTestMode.Playback))
        {
            attribute.ApplyToTest(test);
            Assert.AreEqual(RunState.Runnable, test.RunState);
        }
    }
    [Test]
    public void ApplyToTest_WithLiveMode_SetsIgnoredState()
    {
        var reason = "Requires specific recorded responses";
        var attribute = new PlaybackOnlyAttribute(reason);
        var test = CreateMockTest();
        using (new MockTestEnvironment(RecordedTestMode.Live))
        {
            attribute.ApplyToTest(test);
            Assert.AreEqual(RunState.Ignored, test.RunState);
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.IsNotNull(skipReason);
            Assert.That(skipReason.ToString(), Contains.Substring("Playback tests will not run when CLIENTMODEL_TEST_MODE is Live"));
            Assert.That(skipReason.ToString(), Contains.Substring(reason));
        }
    }
    [Test]
    public void ApplyToTest_WithRecordMode_SetsIgnoredState()
    {
        var reason = "Test depends on specific playback data";
        var attribute = new PlaybackOnlyAttribute(reason);
        var test = CreateMockTest();
        using (new MockTestEnvironment(RecordedTestMode.Record))
        {
            attribute.ApplyToTest(test);
            Assert.AreEqual(RunState.Ignored, test.RunState);
            var skipReason = test.Properties.Get("_SKIPREASON");
            Assert.IsNotNull(skipReason);
            Assert.That(skipReason.ToString(), Contains.Substring("Playback tests will not run when CLIENTMODEL_TEST_MODE is Record"));
            Assert.That(skipReason.ToString(), Contains.Substring(reason));
        }
    }
    [Test]
    public void ApplyToTest_WithNotRunnableTest_DoesNotChangeState()
    {
        var attribute = new PlaybackOnlyAttribute("test reason");
        var test = CreateMockTest();
        test.RunState = RunState.NotRunnable;
        using (new MockTestEnvironment(RecordedTestMode.Live))
        {
            attribute.ApplyToTest(test);
            Assert.AreEqual(RunState.NotRunnable, test.RunState);
        }
    }
    [Test]
    public void ApplyToTest_IncludesReasonInSkipMessage()
    {
        var reason = "This specific test requires recorded authentication flows";
        var attribute = new PlaybackOnlyAttribute(reason);
        var test = CreateMockTest();
        using (new MockTestEnvironment(RecordedTestMode.Live))
        {
            attribute.ApplyToTest(test);
            var skipReason = test.Properties.Get("_SKIPREASON").ToString();
            Assert.That(skipReason, Contains.Substring(reason));
        }
    }
    [Test]
    public void Attribute_CanBeAppliedToMethod()
    {
        var method = typeof(TestClassWithPlaybackOnlyMethod).GetMethod(nameof(TestClassWithPlaybackOnlyMethod.PlaybackOnlyMethod));
        var attribute = method.GetCustomAttribute<PlaybackOnlyAttribute>();
        Assert.IsNotNull(attribute);
    }
    [Test]
    public void Attribute_CanBeAppliedToClass()
    {
        var attribute = typeof(PlaybackOnlyTestClass).GetCustomAttribute<PlaybackOnlyAttribute>();
        Assert.IsNotNull(attribute);
    }
    [Test]
    public void AllowMultiple_IsTrue()
    {
        var usage = typeof(PlaybackOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsTrue(usage.AllowMultiple);
    }
    [Test]
    public void PlaybackOnly_DifferentFromLiveOnly()
    {
        var playbackAttr = new PlaybackOnlyAttribute("test");
        var liveAttr = new LiveOnlyAttribute();
        Assert.IsInstanceOf<PlaybackOnlyAttribute>(playbackAttr);
        Assert.IsInstanceOf<LiveOnlyAttribute>(liveAttr);
        Assert.AreNotEqual(playbackAttr.GetType(), liveAttr.GetType());
    }
    // Helper methods and classes
    private Test CreateMockTest()
    {
        var method = typeof(TestClassWithPlaybackOnlyMethod).GetMethod(nameof(TestClassWithPlaybackOnlyMethod.PlaybackOnlyMethod));
        return new TestMethod(new MethodWrapper(typeof(TestClassWithPlaybackOnlyMethod), method));
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
    // Mock class to simulate TestEnvironment.GlobalTestMode
    public class MockTestEnvironment : IDisposable
    {
        private readonly RecordedTestMode _mode;
        public MockTestEnvironment(RecordedTestMode mode)
        {
            _mode = mode;
        }
        public void Dispose()
        {
            // Restore original mode if needed
        }
    }
}
