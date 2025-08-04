// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.TestProxy;

[TestFixture]
public class ProxyTransportTests
{
    private MockPipelineTransport _mockInnerTransport;
    private TestRecording _mockRecording;
    private Func<EntryRecordModel> _mockGetRecordingMode;

    [SetUp]
    public void SetUp()
    {
        _mockInnerTransport = new MockPipelineTransport();
        _mockRecording = new TestRecording(RecordedTestMode.Record, "test-session");
        _mockGetRecordingMode = () => EntryRecordModel.Record;
    }

    [Test]
    public void Constructor_WithNullProxyProcess_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ProxyTransport(null, _mockInnerTransport, _mockRecording, _mockGetRecordingMode));
    }

    [Test]
    public void Constructor_WithNullInnerTransport_ThrowsArgumentNullException()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        
        Assert.Throws<ArgumentNullException>(() =>
            new ProxyTransport(mockProxyProcess, null, _mockRecording, _mockGetRecordingMode));
    }

    [Test]
    public void Constructor_WithNullRecording_ThrowsArgumentNullException()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        
        Assert.Throws<ArgumentNullException>(() =>
            new ProxyTransport(mockProxyProcess, _mockInnerTransport, null, _mockGetRecordingMode));
    }

    [Test]
    public void Constructor_WithNullGetRecordingMode_ThrowsArgumentNullException()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        
        Assert.Throws<ArgumentNullException>(() =>
            new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, null));
    }

    [Test]
    public void Constructor_WithValidParameters_CreatesInstance()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        
        Assert.IsNotNull(transport);
        Assert.IsInstanceOf<PipelineTransport>(transport);
    }

    [Test]
    public void CreateMessage_WithValidRecording_ReturnsMessage()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        
        var message = transport.CreateMessage();
        
        Assert.IsNotNull(message);
        Assert.IsTrue(_mockRecording.HasRequests);
    }

    [Test]
    public void CreateMessage_WithMismatchException_ThrowsException()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        var mismatchException = new TestRecordingMismatchException("Test mismatch");
        _mockRecording.MismatchException = mismatchException;
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        
        var thrownException = Assert.Throws<TestRecordingMismatchException>(() => transport.CreateMessage());
        
        Assert.AreSame(mismatchException, thrownException);
    }

    [Test]
    public void Process_WithValidMessage_ProcessesSuccessfully()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        var message = transport.CreateMessage();
        
        Assert.DoesNotThrow(() => transport.Process(message));
    }

    [Test]
    public async Task ProcessAsync_WithValidMessage_ProcessesSuccessfully()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        var message = transport.CreateMessage();
        
        await Assert.DoesNotThrowAsync(async () => await transport.ProcessAsync(message));
    }

    [Test]
    public void Process_WithPlaybackModeAndDoNotRecord_ThrowsInvalidOperationException()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        _mockRecording = new TestRecording(RecordedTestMode.Playback, "test-session");
        _mockGetRecordingMode = () => EntryRecordModel.DoNotRecord;
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        var message = transport.CreateMessage();
        
        var exception = Assert.Throws<InvalidOperationException>(() => transport.Process(message));
        
        Assert.That(exception.Message, Does.Contain("DisableRecordingScope"));
        Assert.That(exception.Message, Does.Contain("Playback mode"));
    }

    [Test]
    public async Task ProcessAsync_WithPlaybackModeAndDoNotRecord_ThrowsInvalidOperationException()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        _mockRecording = new TestRecording(RecordedTestMode.Playback, "test-session");
        _mockGetRecordingMode = () => EntryRecordModel.DoNotRecord;
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        var message = transport.CreateMessage();
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () => await transport.ProcessAsync(message));
        
        Assert.That(exception.Message, Does.Contain("DisableRecordingScope"));
        Assert.That(exception.Message, Does.Contain("Playback mode"));
    }

    [Test]
    public void Process_WithRecordMode_AllowsDoNotRecordMode()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        _mockRecording = new TestRecording(RecordedTestMode.Record, "test-session");
        _mockGetRecordingMode = () => EntryRecordModel.DoNotRecord;
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        var message = transport.CreateMessage();
        
        Assert.DoesNotThrow(() => transport.Process(message));
    }

    [Test]
    public void Process_WithLiveModeAndDoNotRecord_ProcessesSuccessfully()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        _mockRecording = new TestRecording(RecordedTestMode.Live, "test-session");
        _mockGetRecordingMode = () => EntryRecordModel.DoNotRecord;
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        var message = transport.CreateMessage();
        
        Assert.DoesNotThrow(() => transport.Process(message));
    }

    [Test]
    public void ProxyTransport_InheritsFromPipelineTransport()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
        
        Assert.IsInstanceOf<PipelineTransport>(transport);
    }

    [Test]
    public void ProxyTransport_WithDifferentRecordingModes_BehavesCorrectly()
    {
        var mockProxyProcess = CreateMockProxyProcess();
        
        // Test each recording mode
        foreach (var mode in new[] { EntryRecordModel.Record, EntryRecordModel.RecordWithoutRequestBody })
        {
            _mockGetRecordingMode = () => mode;
            var transport = new ProxyTransport(mockProxyProcess, _mockInnerTransport, _mockRecording, _mockGetRecordingMode);
            var message = transport.CreateMessage();
            
            Assert.DoesNotThrow(() => transport.Process(message), $"Failed for mode: {mode}");
        }
    }

    private static TestProxyProcess CreateMockProxyProcess()
    {
        // Create a minimal mock that satisfies the constructor requirements
        // Since TestProxyProcess might have complex initialization, we'll create it in a way that works
        try
        {
            return new TestProxyProcess();
        }
        catch
        {
            // If the default constructor doesn't work due to missing dependencies,
            // we might need to use reflection or mocking to create a usable instance
            // For now, let's assume the constructor works in the test environment
            throw new InvalidOperationException("Unable to create TestProxyProcess for testing. This may require test proxy dependencies to be available.");
        }
    }
}
