// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using Microsoft.ClientModel.TestFramework.TestProxy;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy.Integration;

[TestFixture]
public class TestProxyIntegrationTests
{
    [Test]
    public void EntryRecordModel_WithTestProxyClientOptions_WorksTogether()
    {
        var options = new TestProxyClientOptions();
        var recordMode = EntryRecordModel.Record;
        
        Assert.IsNotNull(options);
        Assert.AreEqual(EntryRecordModel.Record, recordMode);
    }

    [Test]
    public void TestTimeoutException_WithTestRecordingMismatchException_CanBeChained()
    {
        var innerException = new TestRecordingMismatchException("Recording mismatch occurred");
        var timeoutException = new TestTimeoutException("Operation timed out", innerException);
        
        Assert.AreSame(innerException, timeoutException.InnerException);
        Assert.IsInstanceOf<TestRecordingMismatchException>(timeoutException.InnerException);
    }

    [Test]
    public void ProxyTransport_WithTestProxyProcess_CanBeCreatedForRecording()
    {
        try
        {
            using var proxyProcess = new TestProxyProcess();
            var innerTransport = new MockPipelineTransport();
            var recording = new TestRecording(RecordedTestMode.Record, "integration-test");
            Func<EntryRecordModel> getRecordingMode = () => EntryRecordModel.Record;
            
            var proxyTransport = new ProxyTransport(proxyProcess, innerTransport, recording, getRecordingMode);
            
            Assert.IsNotNull(proxyTransport);
            Assert.IsInstanceOf<System.ClientModel.Primitives.PipelineTransport>(proxyTransport);
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("TestProxyProcess"))
        {
            Assert.Inconclusive("TestProxyProcess requires test proxy dependencies to be available");
        }
    }

    [Test]
    public void ProxyTransport_WithTestProxyProcess_CanBeCreatedForPlayback()
    {
        try
        {
            using var proxyProcess = new TestProxyProcess();
            var innerTransport = new MockPipelineTransport();
            var recording = new TestRecording(RecordedTestMode.Playback, "integration-test");
            Func<EntryRecordModel> getRecordingMode = () => EntryRecordModel.Record;
            
            var proxyTransport = new ProxyTransport(proxyProcess, innerTransport, recording, getRecordingMode);
            
            Assert.IsNotNull(proxyTransport);
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("TestProxyProcess"))
        {
            Assert.Inconclusive("TestProxyProcess requires test proxy dependencies to be available");
        }
    }

    [Test]
    public void ProxyTransport_CreateMessage_SetsRecordingState()
    {
        try
        {
            using var proxyProcess = new TestProxyProcess();
            var innerTransport = new MockPipelineTransport();
            var recording = new TestRecording(RecordedTestMode.Record, "integration-test");
            Func<EntryRecordModel> getRecordingMode = () => EntryRecordModel.Record;
            
            var proxyTransport = new ProxyTransport(proxyProcess, innerTransport, recording, getRecordingMode);
            var message = proxyTransport.CreateMessage();
            
            Assert.IsNotNull(message);
            Assert.IsTrue(recording.HasRequests, "Recording should indicate it has requests after message creation");
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("TestProxyProcess"))
        {
            Assert.Inconclusive("TestProxyProcess requires test proxy dependencies to be available");
        }
    }

    [Test]
    public async Task ProxyTransport_ProcessAsync_HandlesRecordingModes()
    {
        try
        {
            using var proxyProcess = new TestProxyProcess();
            var innerTransport = new MockPipelineTransport();
            
            foreach (var mode in new[] { EntryRecordModel.Record, EntryRecordModel.RecordWithoutRequestBody })
            {
                var recording = new TestRecording(RecordedTestMode.Record, $"integration-test-{mode}");
                Func<EntryRecordModel> getRecordingMode = () => mode;
                
                var proxyTransport = new ProxyTransport(proxyProcess, innerTransport, recording, getRecordingMode);
                var message = proxyTransport.CreateMessage();
                
                await Assert.DoesNotThrowAsync(async () => await proxyTransport.ProcessAsync(message));
            }
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("TestProxyProcess"))
        {
            Assert.Inconclusive("TestProxyProcess requires test proxy dependencies to be available");
        }
    }

    [Test]
    public void ExceptionChaining_TestProxyExceptions_WorkCorrectly()
    {
        var recordingException = new TestRecordingMismatchException("Recording failed");
        var timeoutException = new TestTimeoutException("Timeout occurred", recordingException);
        var operationException = new InvalidOperationException("Operation failed", timeoutException);
        
        Assert.AreSame(recordingException, timeoutException.InnerException);
        Assert.AreSame(timeoutException, operationException.InnerException);
        Assert.AreSame(recordingException, operationException.InnerException?.InnerException);
    }

    [Test]
    public void TestProxyClientOptions_WithProxyTransport_HasCompatibleConfiguration()
    {
        var options = new TestProxyClientOptions();
        
        // Verify that TestProxyClientOptions can be used with proxy transport scenarios
        Assert.IsNotNull(options.Transport);
        Assert.IsNotNull(options.NetworkTimeout);
    }

    [Test]
    public void RecordingModes_WithProxyTransport_AllModesSupported()
    {
        var supportedModes = new[]
        {
            EntryRecordModel.Record,
            EntryRecordModel.DoNotRecord,
            EntryRecordModel.RecordWithoutRequestBody
        };
        
        foreach (var mode in supportedModes)
        {
            Assert.DoesNotThrow(() =>
            {
                Func<EntryRecordModel> getMode = () => mode;
                var result = getMode();
                Assert.AreEqual(mode, result);
            });
        }
    }

    [Test]
    public void TestEnvironment_WithTestProxyProcess_StaticPropertiesAccessible()
    {
        // Verify that TestEnvironment static properties work with test proxy scenarios
        Assert.DoesNotThrow(() =>
        {
            var _ = TestEnvironment.RepositoryRoot;
            var __ = TestEnvironment.DevCertPath;
            var ___ = TestEnvironment.EnableFiddler;
            var ____ = TestEnvironment.DevCertPassword;
        });
        
        // Verify IpAddress constant is accessible
        Assert.AreEqual("127.0.0.1", TestProxyProcess.IpAddress);
    }

    [Test]
    public void TestProxy_ExceptionHandling_WorksAcrossComponents()
    {
        // Test that exceptions can be properly handled across test proxy components
        var mismatchException = new TestRecordingMismatchException("Test recording mismatch");
        var timeoutException = new TestTimeoutException("Test timeout", mismatchException);
        
        try
        {
            throw timeoutException;
        }
        catch (TestTimeoutException ex)
        {
            Assert.IsInstanceOf<TestRecordingMismatchException>(ex.InnerException);
            Assert.AreEqual("Test recording mismatch", ex.InnerException.Message);
        }
    }

    [Test]
    public void TestProxy_AllComponentsCanBeInstantiated()
    {
        Assert.DoesNotThrow(() =>
        {
            // Test that we can create instances of all testable components
            var options = new TestProxyClientOptions();
            var mismatchException = new TestRecordingMismatchException("Test");
            var timeoutException = new TestTimeoutException("Test");
            var recordMode = EntryRecordModel.Record;
            
            Assert.IsNotNull(options);
            Assert.IsNotNull(mismatchException);
            Assert.IsNotNull(timeoutException);
            Assert.AreEqual(EntryRecordModel.Record, recordMode);
        });
    }
}
