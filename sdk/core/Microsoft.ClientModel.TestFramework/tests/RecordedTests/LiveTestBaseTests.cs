// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class LiveTestBaseTests
{
    #region Constructor and Basic Properties

    [Test]
    public void ConstructorCreatesTestEnvironmentInstance()
    {
        var liveTestBase = new TestableLiveTestBase();

        Assert.That(liveTestBase.TestEnvironment, Is.Not.Null, "TestEnvironment should be created");
        Assert.That(liveTestBase.TestEnvironment, Is.InstanceOf<TestableTestEnvironment>(), "TestEnvironment should be of correct type");
    }

    [Test]
    public void ConstructorSetsTestEnvironmentToLiveMode()
    {
        var liveTestBase = new TestableLiveTestBase();

        Assert.That(liveTestBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "TestEnvironment should be set to Live mode");
    }

    [Test]
    public void TestEnvironmentPropertyReturnsCreatedEnvironment()
    {
        var liveTestBase = new TestableLiveTestBase();

        var environment = liveTestBase.TestEnvironment;
        Assert.That(environment, Is.Not.Null, "TestEnvironment property should return environment");
        Assert.That(environment, Is.InstanceOf<TestableTestEnvironment>(), "Environment should be of correct type");
        Assert.That(environment.Mode, Is.EqualTo(RecordedTestMode.Live), "Environment should be in Live mode");
    }

    [Test]
    public void MultipleInstancesCreateSeparateEnvironments()
    {
        var liveTestBase1 = new TestableLiveTestBase();
        var liveTestBase2 = new TestableLiveTestBase();

        Assert.That(liveTestBase1.TestEnvironment, Is.Not.SameAs(liveTestBase2.TestEnvironment), "Each instance should have separate TestEnvironment");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(liveTestBase1.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "First instance should be in Live mode");
            Assert.That(liveTestBase2.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "Second instance should be in Live mode");
        }
    }

    #endregion

    #region LiveOnly Attribute

    [Test]
    public void ClassHasLiveOnlyAttribute()
    {
        var liveOnlyAttributes = typeof(TestableLiveTestBase).GetCustomAttributes(typeof(LiveOnlyAttribute), true);

        Assert.That(liveOnlyAttributes, Is.Not.Empty, "LiveTestBase should have LiveOnlyAttribute");
        Assert.That(liveOnlyAttributes.Length, Is.EqualTo(1), "Should have exactly one LiveOnlyAttribute");
    }

    #endregion

    #region WaitForEnvironment Method

    [Test]
    public async Task WaitForEnvironmentCallsTestEnvironmentWaitForEnvironmentAsync()
    {
        var liveTestBase = new TestableLiveTestBase();

        // Verify WaitForEnvironmentAsync hasn't been called yet
        Assert.That(liveTestBase.TestEnvironment.WaitForEnvironmentAsyncCalled, Is.False, "WaitForEnvironmentAsync should not be called initially");

        // Call WaitForEnvironment (which is decorated with [OneTimeSetUp])
        await liveTestBase.WaitForEnvironment();

        // Verify WaitForEnvironmentAsync was called on the TestEnvironment
        Assert.That(liveTestBase.TestEnvironment.WaitForEnvironmentAsyncCalled, Is.True, "WaitForEnvironmentAsync should be called on TestEnvironment");
    }

    [Test]
    public void WaitForEnvironmentHasOneTimeSetUpAttribute()
    {
        var methodInfo = typeof(TestableLiveTestBase).GetMethod("WaitForEnvironment");

        Assert.That(methodInfo, Is.Not.Null, "WaitForEnvironment method should exist");

        var oneTimeSetUpAttributes = methodInfo!.GetCustomAttributes(typeof(OneTimeSetUpAttribute), true);
        Assert.That(oneTimeSetUpAttributes, Is.Not.Empty, "WaitForEnvironment should have OneTimeSetUpAttribute");
        Assert.That(oneTimeSetUpAttributes.Length, Is.EqualTo(1), "Should have exactly one OneTimeSetUpAttribute");
    }

    [Test]
    public async Task WaitForEnvironmentCanBeCalledMultipleTimes()
    {
        var liveTestBase = new TestableLiveTestBase();

        // Call WaitForEnvironment multiple times
        await liveTestBase.WaitForEnvironment();
        await liveTestBase.WaitForEnvironment();
        await liveTestBase.WaitForEnvironment();

        using (Assert.EnterMultipleScope())
        {
            // Should complete without throwing and environment should still be valid
            Assert.That(liveTestBase.TestEnvironment.WaitForEnvironmentAsyncCalled, Is.True, "WaitForEnvironmentAsync should have been called");
            Assert.That(liveTestBase.TestEnvironment.Mode, Is.EqualTo(RecordedTestMode.Live), "Environment should still be in Live mode");
        }
    }

    #endregion

    #region Generic Type Validation

    [Test]
    public void TestEnvironmentInheritsCorrectGenericType()
    {
        var liveTestBase = new TestableLiveTestBase();

        Assert.That(liveTestBase.TestEnvironment, Is.InstanceOf<TestableTestEnvironment>(), "TestEnvironment should be of specified generic type");
        Assert.That(liveTestBase.TestEnvironment.GetType(), Is.EqualTo(typeof(TestableTestEnvironment)), "TestEnvironment should be exact generic type");
    }

    #endregion

    #region Helper Classes

    private class TestableTestEnvironment : TestEnvironment
    {
        public bool WaitForEnvironmentAsyncCalled { get; private set; }

        public override async Task WaitForEnvironmentAsync()
        {
            WaitForEnvironmentAsyncCalled = true;
            await Task.CompletedTask;
        }

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            return new Dictionary<string, string>();
        }
    }

    [LiveOnly] // Required since LiveTestBase has this attribute
    private class TestableLiveTestBase : LiveTestBase<TestableTestEnvironment>
    {
        // Expose TestEnvironment property for testing (it's already protected)
        public new TestableTestEnvironment TestEnvironment => base.TestEnvironment;
    }

    #endregion
}
