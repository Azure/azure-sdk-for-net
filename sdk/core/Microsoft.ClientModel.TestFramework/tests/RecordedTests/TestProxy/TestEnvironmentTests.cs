// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using Moq;
using System.ClientModel;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class TestEnvironmentTests
{
    #region Test Implementation

    private class TestableTestEnvironment : TestEnvironment
    {
        private readonly Dictionary<string, string> _environmentVariables = new();
        private readonly bool _shouldThrowOnWait;

        public TestableTestEnvironment(bool shouldThrowOnWait = false)
        {
            _shouldThrowOnWait = shouldThrowOnWait;
        }

        public void SetEnvironmentVariable(string name, string value)
        {
            _environmentVariables[name] = value;
        }

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            return _environmentVariables;
        }

        public override async Task WaitForEnvironmentAsync()
        {
            if (_shouldThrowOnWait)
            {
                throw new InvalidOperationException("Test exception");
            }
            await Task.CompletedTask;
        }

        // Expose protected methods for testing
        public new string GetRecordedOptionalVariable(string name) => base.GetRecordedOptionalVariable(name);
        public new string GetRecordedOptionalVariable(string name, Action<RecordedVariableOptions> options) => base.GetRecordedOptionalVariable(name, options);
        public new string GetRecordedVariable(string name) => base.GetRecordedVariable(name);
        public new string GetRecordedVariable(string name, Action<RecordedVariableOptions> options) => base.GetRecordedVariable(name, options);
        public new string GetOptionalVariable(string name) => base.GetOptionalVariable(name);
        public new string GetVariable(string name) => base.GetVariable(name);
    }

    #endregion

    #region Mode Property

    [Test]
    public void ModeCanBeSetAndRetrieved()
    {
        var environment = new TestableTestEnvironment();

        environment.Mode = RecordedTestMode.Live;
        Assert.That(environment.Mode, Is.EqualTo(RecordedTestMode.Live));

        environment.Mode = RecordedTestMode.Record;
        Assert.That(environment.Mode, Is.EqualTo(RecordedTestMode.Record));

        environment.Mode = RecordedTestMode.Playback;
        Assert.That(environment.Mode, Is.EqualTo(RecordedTestMode.Playback));

        environment.Mode = null;
        Assert.That(environment.Mode, Is.Null);
    }

    #endregion

    #region Credential Property

    [Test]
    public void CredentialInPlaybackModeReturnsMockCredential()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Playback;

        var credential = environment.Credential;

        Assert.That(credential, Is.InstanceOf<MockCredential>());
    }

    [Test]
    public void CredentialInLiveModeThrowsInvalidOperationException()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Live;

        Assert.Throws<InvalidOperationException>(() => _ = environment.Credential);
    }

    [Test]
    public void CredentialInRecordModeThrowsInvalidOperationException()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Record;

        Assert.Throws<InvalidOperationException>(() => _ = environment.Credential);
    }

    [Test]
    public void CredentialCachesInstance()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Playback;

        var credential1 = environment.Credential;
        var credential2 = environment.Credential;

        Assert.That(credential2, Is.SameAs(credential1));
    }

    #endregion

    #region PathToTestResourceBootstrappingScript Property

    [Test]
    public void PathToTestResourceBootstrappingScriptCanBeSetAndRetrieved()
    {
        var environment = new TestableTestEnvironment();
        var scriptPath = @"C:\test\bootstrap.ps1";

        environment.PathToTestResourceBootstrappingScript = scriptPath;

        Assert.That(environment.PathToTestResourceBootstrappingScript, Is.EqualTo(scriptPath));
    }

    [Test]
    public void PathToTestResourceBootstrappingScriptCanBeNull()
    {
        var environment = new TestableTestEnvironment();

        environment.PathToTestResourceBootstrappingScript = null;

        Assert.That(environment.PathToTestResourceBootstrappingScript, Is.Null);
    }

    #endregion

    #region GetOptionalVariable Method

    [Test]
    public void GetOptionalVariableWithExistingVariableReturnsValue()
    {
        var environment = new TestableTestEnvironment();
        environment.SetEnvironmentVariable("TEST_VAR", "test_value");

        var result = environment.GetOptionalVariable("TEST_VAR");

        Assert.That(result, Is.EqualTo("test_value"));
    }

    [Test]
    public void GetOptionalVariableWithNonExistingVariableReturnsNull()
    {
        var environment = new TestableTestEnvironment();

        var result = environment.GetOptionalVariable("NON_EXISTING_VAR");

        Assert.That(result, Is.Null);
    }

    [TestCase("")]
    [TestCase("   ")]
    public void GetOptionalVariableWithEmptyNameReturnsNull(string variableName)
    {
        var environment = new TestableTestEnvironment();

        var result = environment.GetOptionalVariable(variableName);

        Assert.That(result, Is.Null);
    }

    #endregion

    #region GetVariable Method

    [Test]
    public void GetVariableWithExistingVariableReturnsValue()
    {
        var environment = new TestableTestEnvironment();
        environment.SetEnvironmentVariable("REQUIRED_VAR", "required_value");

        var result = environment.GetVariable("REQUIRED_VAR");

        Assert.That(result, Is.EqualTo("required_value"));
    }

    [Test]
    public void GetVariableWithNonExistingVariableThrowsInvalidOperationException()
    {
        var environment = new TestableTestEnvironment();
        // Set a dummy script path to avoid bootstrapping exception and get to the actual variable missing exception
        environment.PathToTestResourceBootstrappingScript = @"C:\dummy\script.ps1";

        var exception = Assert.Throws<InvalidOperationException>(() => environment.GetVariable("MISSING_VAR"));
        Assert.That(exception.Message, Does.Contain("Unable to find environment variable MISSING_VAR"));
    }

    [Test]
    public void GetVariableWithNonExistingVariableAndNoBootstrapScriptThrowsBootstrapException()
    {
        var environment = new TestableTestEnvironment();
        environment.PathToTestResourceBootstrappingScript = null;

        if (!TestEnvironment.DisableBootstrapping)
        {
            var exception = Assert.Throws<InvalidOperationException>(() => environment.GetVariable("MISSING_VAR"));
            Assert.That(exception.Message, Does.Contain("PathToTestResourceBootstrappingScript is null"));
        }
        else
        {
            // If bootstrapping is disabled, should get the variable not found exception
            var exception = Assert.Throws<InvalidOperationException>(() => environment.GetVariable("MISSING_VAR"));
            Assert.That(exception.Message, Does.Contain("Unable to find environment variable MISSING_VAR"));
        }
    }

    #endregion

    #region GetRecordedOptionalVariable Method

    [Test]
    public void GetRecordedOptionalVariableInPlaybackModeReturnsRecordedValue()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Playback;

        var mockRecording = new Mock<TestRecording>();
        mockRecording.Setup(r => r.GetVariable("TEST_VAR", string.Empty, null)).Returns("recorded_value");
        environment.SetRecording(mockRecording.Object);

        var result = environment.GetRecordedOptionalVariable("TEST_VAR");

        Assert.That(result, Is.EqualTo("recorded_value"));
    }

    [Test]
    public void GetRecordedOptionalVariableInLiveModeReturnsEnvironmentValue()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Live;
        environment.SetEnvironmentVariable("TEST_VAR", "live_value");

        var result = environment.GetRecordedOptionalVariable("TEST_VAR");

        Assert.That(result, Is.EqualTo("live_value"));
    }

    [Test]
    public void GetRecordedOptionalVariableInRecordModeRecordsAndReturnsValue()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Record;
        environment.SetEnvironmentVariable("TEST_VAR", "record_value");

        var mockRecording = new Mock<TestRecording>();
        environment.SetRecording(mockRecording.Object);

        var result = environment.GetRecordedOptionalVariable("TEST_VAR");

        Assert.That(result, Is.EqualTo("record_value"));
        mockRecording.Verify(r => r.SetVariable("TEST_VAR", "record_value", null), Times.Once);
    }

    [Test]
    public void GetRecordedOptionalVariableInRecordModeWithOptionsAppliesSanitization()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Record;
        environment.SetEnvironmentVariable("SECRET_VAR", "secret_value");

        var mockRecording = new Mock<TestRecording>();
        environment.SetRecording(mockRecording.Object);

        var result = environment.GetRecordedOptionalVariable("SECRET_VAR", options => options.IsSecret("SANITIZED"));

        Assert.That(result, Is.EqualTo("secret_value"));
        mockRecording.Verify(r => r.SetVariable("SECRET_VAR", "SANITIZED", null), Times.Once);
    }

    [Test]
    public void GetRecordedOptionalVariableInRecordModeWithoutRecordingThrowsInvalidOperationException()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Record;

        var exception = Assert.Throws<InvalidOperationException>(() =>
            environment.GetRecordedOptionalVariable("TEST_VAR"));
        Assert.That(exception.Message, Does.Contain("Recorded value should not be set outside the test method invocation"));
    }

    #endregion

    #region GetRecordedVariable Method

    [Test]
    public void GetRecordedVariableWithExistingVariableReturnsValue()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Live;
        environment.SetEnvironmentVariable("TEST_VAR", "test_value");

        var result = environment.GetRecordedVariable("TEST_VAR");

        Assert.That(result, Is.EqualTo("test_value"));
    }

    [Test]
    public void GetRecordedVariableWithMissingVariableThrowsInvalidOperationException()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Live;
        // Set a dummy script path to avoid bootstrapping exception and get to the actual variable missing exception
        environment.PathToTestResourceBootstrappingScript = @"C:\dummy\script.ps1";

        var exception = Assert.Throws<InvalidOperationException>(() =>
            environment.GetRecordedVariable("MISSING_VAR"));
        Assert.That(exception.Message, Does.Contain("Unable to find environment variable MISSING_VAR"));
    }

    #endregion

    #region SetRecording Method

    [Test]
    public void SetRecordingResetsCredential()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Playback;

        // Access credential to cache it
        var initialCredential = environment.Credential;

        var mockRecording = new Mock<TestRecording>();
        environment.SetRecording(mockRecording.Object);

        // Access credential again - should be a new instance
        var newCredential = environment.Credential;

        Assert.That(newCredential, Is.Not.SameAs(initialCredential));
    }

    #endregion

    #region GetSourcePath Method

    [Test]
    public void GetSourcePathWithNullAssemblyThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => TestEnvironment.GetSourcePath(null!));
    }

    [Test]
    public void GetSourcePathWithValidAssemblyReturnsPath()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var result = TestEnvironment.GetSourcePath(assembly);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Not.Empty);
    }

    #endregion

    #region BootStrapTestResources Method

    [Test]
    public void BootStrapTestResourcesWithNullScriptPathThrowsInvalidOperationException()
    {
        var environment = new TestableTestEnvironment();
        environment.PathToTestResourceBootstrappingScript = null;

        if (!TestEnvironment.DisableBootstrapping)
        {
            var exception = Assert.Throws<InvalidOperationException>(() => environment.BootStrapTestResources());
            Assert.That(exception.Message, Does.Contain("PathToTestResourceBootstrappingScript is null"));
        }
    }

    [Test]
    public void BootStrapTestResourcesWhenBootstrappingDisabledDoesNotThrow()
    {
        var environment = new TestableTestEnvironment();
        environment.PathToTestResourceBootstrappingScript = null;

        // Set environment variable to disable bootstrapping using TestEnvVar
        using var envVar = new TestEnvVar("CLIENTMODEL_DISABLE_BOOTSTRAPPING", "true");

        // This should not throw regardless of script path if bootstrapping is disabled
        Assert.DoesNotThrow(() => environment.BootStrapTestResources());
    }

    [Test]
    public void BootStrapTestResourcesInPlaybackModeDoesNotExecute()
    {
        var environment = new TestableTestEnvironment();
        environment.Mode = RecordedTestMode.Playback;
        environment.PathToTestResourceBootstrappingScript = @"C:\nonexistent\script.ps1";

        // Should not throw even with invalid script path in Playback mode
        Assert.DoesNotThrow(() => environment.BootStrapTestResources());
    }

    #endregion

    #region Abstract Method Tests

    [Test]
    public void WaitForEnvironmentAsyncWithExceptionPropagatesException()
    {
        var environment = new TestableTestEnvironment(shouldThrowOnWait: true);

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await environment.WaitForEnvironmentAsync());
        Assert.That(exception.Message, Is.EqualTo("Test exception"));
    }

    [Test]
    public void ParseEnvironmentFileReturnsConfiguredVariables()
    {
        var environment = new TestableTestEnvironment();
        environment.SetEnvironmentVariable("KEY1", "VALUE1");
        environment.SetEnvironmentVariable("KEY2", "VALUE2");

        var result = environment.ParseEnvironmentFile();

        Assert.That(result, Contains.Key("KEY1"));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result["KEY1"], Is.EqualTo("VALUE1"));
            Assert.That(result, Contains.Key("KEY2"));
        }
        Assert.That(result["KEY2"], Is.EqualTo("VALUE2"));
    }

    #endregion
}
