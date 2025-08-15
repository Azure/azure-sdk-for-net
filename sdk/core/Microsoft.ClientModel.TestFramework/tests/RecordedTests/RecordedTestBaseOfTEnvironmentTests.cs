// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RecordedTestBaseOfTEnvironmentTests
{
    #region Constructor and Basic Properties

    [Test]
    public void ConstructorCreatesTestEnvironmentInstance()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        Assert.That(testBase.TestEnvironment, Is.Not.Null, "TestEnvironment should be created");
        Assert.That(testBase.TestEnvironment, Is.InstanceOf<TestableTestEnvironment>(), "TestEnvironment should be of correct type");
    }

    [Test]
    public void ConstructorSetsTestEnvironmentModeFromBaseMode()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Record), "Base mode should be set correctly");
            Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Record), "TestEnvironment mode should match base mode");
        }
    }

    [Test]
    public void TestEnvironmentPropertyReturnsCreatedEnvironment()
    {
        var testBase = new TestableRecordedTestBase(isAsync: false, RecordedTestMode.Playback);

        var environment = testBase.TestEnvironment;
        Assert.That(environment, Is.Not.Null, "TestEnvironment property should return environment");
        Assert.That(environment, Is.InstanceOf<TestableTestEnvironment>(), "Environment should be of correct type");
        Assert.That(environment.Mode, Is.EqualTo(RecordedTestMode.Playback), "Environment mode should be set correctly");
    }

    [Test]
    public void ConstructorCallsBaseConstructorWithCorrectParameters()
    {
        var asyncTestBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(asyncTestBase.IsAsync, Is.True, "IsAsync should be passed to base constructor");
            Assert.That(asyncTestBase.Mode, Is.EqualTo(RecordedTestMode.Live), "Mode should be passed to base constructor");
        }

        var syncTestBase = new TestableRecordedTestBase(isAsync: false, RecordedTestMode.Record);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(syncTestBase.IsAsync, Is.False, "IsAsync should be passed to base constructor");
            Assert.That(syncTestBase.Mode, Is.EqualTo(RecordedTestMode.Record), "Mode should be passed to base constructor");
        }
    }

    #endregion

    #region StartTestRecordingAsync Override

    [Test]
    public async Task StartTestRecordingAsyncCallsBaseMethod()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);

        // In Live mode, no proxy is needed so we can test the base method call directly
        await testBase.StartTestRecordingAsync();

        Assert.That(testBase.ExposedRecording, Is.Not.Null, "Base StartTestRecordingAsync should create recording");
        Assert.That(testBase.ExposedRecording.Mode, Is.EqualTo(RecordedTestMode.Live), "Recording should have correct mode");
    }

    [Test]
    public void StartTestRecordingAsyncThrowsWhenRecordingFailsToStart()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Don't set up proxy - this will cause base.StartTestRecordingAsync to fail in Record mode
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await testBase.StartTestRecordingAsync());
        Assert.That(exception.Message, Does.Contain("test proxy has not been started"), "Should throw appropriate exception when proxy not available");
    }

    [Test]
    public async Task StartTestRecordingAsyncSetsRecordingOnTestEnvironment()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);

        // Verify TestEnvironment recording is null initially
        Assert.That(testBase.TestEnvironment.SetRecordingValue, Is.Null, "TestEnvironment recording should be null initially");

        await testBase.StartTestRecordingAsync();

        // Verify TestEnvironment.SetRecording was called with the created recording
        Assert.That(testBase.TestEnvironment.SetRecordingValue, Is.Not.Null, "TestEnvironment.SetRecording should be called");
        Assert.That(testBase.TestEnvironment.SetRecordingValue, Is.SameAs(testBase.ExposedRecording), "TestEnvironment should receive the same recording instance");
    }

    [Test]
    public async Task StartTestRecordingAsyncUpdatesTestEnvironmentMode()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Playback);

        // Change mode after construction
        testBase.Mode = RecordedTestMode.Live;

        // Verify mode changed on base class
        Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Live), "Base mode should be updated");

        await testBase.StartTestRecordingAsync();

        // Verify TestEnvironment mode was synchronized during StartTestRecordingAsync
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "TestEnvironment mode should be synchronized with base mode");
    }

    #endregion

    #region Environment Integration

    [Test]
    public async Task WaitForEnvironmentCallsTestEnvironmentWaitForEnvironmentAsync()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        // Verify WaitForEnvironmentAsync hasn't been called yet
        Assert.That(testBase.TestEnvironment.WaitForEnvironmentAsyncCalled, Is.False, "WaitForEnvironmentAsync should not be called initially");

        // Call WaitForEnvironment (which is decorated with [OneTimeSetUp])
        await testBase.WaitForEnvironment();

        // Verify WaitForEnvironmentAsync was called on the TestEnvironment
        Assert.That(testBase.TestEnvironment.WaitForEnvironmentAsyncCalled, Is.True, "WaitForEnvironmentAsync should be called on TestEnvironment");
    }

    [Test]
    public void TestEnvironmentModeStaysSynchronizedWithBaseMode()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Verify initial synchronization
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Record), "Initial mode should be synchronized");

        // Change mode on base class
        testBase.Mode = RecordedTestMode.Playback;

        // Verify TestEnvironment mode is NOT automatically synchronized (only during StartTestRecordingAsync)
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Record), "TestEnvironment mode should not auto-sync");

        // Change mode again
        testBase.Mode = RecordedTestMode.Live;
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Record), "TestEnvironment mode should still not auto-sync");
    }

    #endregion

    #region Advanced Integration Tests

    [Test]
    public void MultipleInstancesCreateSeparateEnvironments()
    {
        var testBase1 = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);
        var testBase2 = new TestableRecordedTestBase(isAsync: false, RecordedTestMode.Playback);

        Assert.That(testBase1.TestEnvironment, Is.Not.SameAs(testBase2.TestEnvironment), "Each instance should have separate TestEnvironment");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase1.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Record), "First instance should have Record mode");
            Assert.That(testBase2.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Playback), "Second instance should have Playback mode");
        }
    }

    [Test]
    public async Task StartTestRecordingAsyncWithModeChangesUpdatesEnvironmentCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);

        // Verify initial state
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "Initial TestEnvironment mode should match");

        // Start recording (should synchronize modes)
        await testBase.StartTestRecordingAsync();
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "TestEnvironment mode should remain synchronized");

        // Change mode and start recording again
        testBase.Mode = RecordedTestMode.Record;

        // This would throw because Record mode needs proxy, but we're testing the mode synchronization
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await testBase.StartTestRecordingAsync());

        // Even though it threw, the mode should still be synchronized
        Assert.That(testBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Record), "TestEnvironment mode should be updated even when StartTestRecordingAsync fails");
    }

    [Test]
    public void TestEnvironmentInheritsCorrectGenericType()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        Assert.That(testBase.TestEnvironment, Is.InstanceOf<TestableTestEnvironment>(), "TestEnvironment should be of specified generic type");
        Assert.That(testBase.TestEnvironment.GetType(), Is.EqualTo(typeof(TestableTestEnvironment)), "TestEnvironment should be exact generic type");
    }

    #endregion

    #region Helper Classes

    private class TestableTestEnvironment : TestEnvironment
    {
        public bool WaitForEnvironmentAsyncCalled { get; private set; }
        public TestRecording SetRecordingValue { get; private set; }

        public override async Task WaitForEnvironmentAsync()
        {
            WaitForEnvironmentAsyncCalled = true;
            await Task.CompletedTask;
        }

        public override void SetRecording(TestRecording recording)
        {
            SetRecordingValue = recording;
            base.SetRecording(recording);
        }

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            return new Dictionary<string, string>();
        }
    }

    private class TestableRecordedTestBase : RecordedTestBase<TestableTestEnvironment>
    {
        public TestableRecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        // Expose base Recording property for testing
        public TestRecording ExposedRecording => Recording;
    }

    #endregion
}
