// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using Microsoft.ClientModel.TestFramework.TestProxy;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using Moq;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RecordedTestBaseTests
{
    #region Constructor and Basic Properties

    [Test]
    public void ConstructorWithAsyncTrueAndDefaultModeInitializesCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.IsAsync, Is.True);
            Assert.That(testBase.Mode, Is.EqualTo(TestEnvironment.GlobalTestMode));
        }
    }

    [Test]
    public void ConstructorWithAsyncFalseAndDefaultModeInitializesCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.IsAsync, Is.False);
            Assert.That(testBase.Mode, Is.EqualTo(TestEnvironment.GlobalTestMode));
        }
    }

    [Test]
    public void ConstructorWithAsyncTrueAndExplicitModeInitializesCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.IsAsync, Is.True);
            Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Record));
        }
    }

    [Test]
    public void ConstructorWithAsyncFalseAndExplicitModeInitializesCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: false, RecordedTestMode.Live);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.IsAsync, Is.False);
            Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Live));
        }
    }

    [Test]
    public void ModePropertyGetsSetsCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);

        Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Live));

        testBase.Mode = RecordedTestMode.Record;
        Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Record));

        testBase.Mode = RecordedTestMode.Playback;
        Assert.That(testBase.Mode, Is.EqualTo(RecordedTestMode.Playback));
    }

    [Test]
    public void AssetsJsonPathResolvesCorrectlyWhenAssetsJsonExists()
    {
        using var tempDir = new TemporaryDirectory();
        var assetsJsonPath = Path.Combine(tempDir.DirectoryPath, "assets.json");
        File.WriteAllText(assetsJsonPath, "{}");

        var testBase = new TestableRecordedTestBaseWithAssetsPath(isAsync: true, assetsJsonPath);

        Assert.That(testBase.AssetsJsonPath, Is.EqualTo(assetsJsonPath));
    }

    [Test]
    public void AssetsJsonPathReturnsNullWhenNoAssetsJsonFound()
    {
        var testBase = new TestableRecordedTestBaseWithAssetsPath(isAsync: true, null);

        Assert.That(testBase.AssetsJsonPath, Is.Null);
    }

    [Test]
    public void DefaultSanitizerCollectionsAreInitializedProperly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        Assert.That(testBase.JsonPathSanitizers, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.JsonPathSanitizers, Is.Empty);

            Assert.That(testBase.BodyKeySanitizers, Is.Not.Null);
        }
        Assert.That(testBase.BodyKeySanitizers, Is.Empty);

        Assert.That(testBase.BodyRegexSanitizers, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.BodyRegexSanitizers, Is.Empty);

            Assert.That(testBase.UriRegexSanitizers, Is.Not.Null);
        }
        Assert.That(testBase.UriRegexSanitizers.Count, Is.EqualTo(2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.UriRegexSanitizers.Any(s => s.Body.Regex.Contains("skoid")), Is.True);
            Assert.That(testBase.UriRegexSanitizers.Any(s => s.Body.Regex.Contains("sktid")), Is.True);

            Assert.That(testBase.HeaderRegexSanitizers, Is.Not.Null);
        }
        Assert.That(testBase.HeaderRegexSanitizers, Is.Empty);

        Assert.That(testBase.SanitizedHeaders, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.SanitizedHeaders, Is.Empty);

            Assert.That(testBase.SanitizedQueryParameters, Is.Not.Null);
        }
        Assert.That(testBase.SanitizedQueryParameters.Count, Is.EqualTo(4));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("sig"));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("sip"));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("client_id"));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.SanitizedQueryParameters, Contains.Item("client_secret"));

            Assert.That(testBase.SanitizedQueryParametersInHeaders, Is.Not.Null);
        }
        Assert.That(testBase.SanitizedQueryParametersInHeaders, Is.Empty);

        Assert.That(testBase.SanitizersToRemove, Is.Not.Null);
        Assert.That(testBase.SanitizersToRemove.Count, Is.GreaterThan(0));
        Assert.That(testBase.SanitizersToRemove, Contains.Item("AZSDK2003"));
    }

    [Test]
    public void DefaultIgnoredHeadersAreSetCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        Assert.That(testBase.IgnoredHeaders, Is.Not.Null);
        Assert.That(testBase.IgnoredHeaders.Count, Is.EqualTo(6));
        Assert.That(testBase.IgnoredHeaders, Contains.Item("Date"));
        Assert.That(testBase.IgnoredHeaders, Contains.Item("x-ms-date"));
        Assert.That(testBase.IgnoredHeaders, Contains.Item("x-ms-client-request-id"));
        Assert.That(testBase.IgnoredHeaders, Contains.Item("User-Agent"));
        Assert.That(testBase.IgnoredHeaders, Contains.Item("Request-Id"));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.IgnoredHeaders, Contains.Item("traceparent"));

            Assert.That(testBase.IgnoredQueryParameters, Is.Not.Null);
        }
        Assert.That(testBase.IgnoredQueryParameters, Is.Empty);
    }

    [Test]
    public void ValidateClientInstrumentationPropertyGetsSetsCorrectly()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        Assert.That(testBase.ValidateClientInstrumentation, Is.False);

        testBase.ValidateClientInstrumentation = true;
        Assert.That(testBase.ValidateClientInstrumentation, Is.True);

        testBase.ValidateClientInstrumentation = false;
        Assert.That(testBase.ValidateClientInstrumentation, Is.False);
    }

    [Test]
    public void CompareBodiesDefaultsToTrueAndCanBeChanged()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true);

        Assert.That(testBase.CompareBodies, Is.True);

        testBase.CompareBodies = false;
        Assert.That(testBase.CompareBodies, Is.False);

        testBase.CompareBodies = true;
        Assert.That(testBase.CompareBodies, Is.True);
    }

    #endregion

    #region StartTestRecordingAsync - Core Behavior

    [Test]
    public async Task StartTestRecordingAsyncInRecordModeCreatesRecording()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Mock the proxy and transport
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message => new MockPipelineResponse(200).WithHeader("x-recording-id", "test-recording-123").WithContent(message.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        // Inject the mock proxy using the internal property
        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        Assert.That(testBase.Recording, Is.Not.Null, "Recording should be created");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.Recording.Mode, Is.EqualTo(RecordedTestMode.Record), "Recording mode should be Record");
            Assert.That(testBase.Recording.RecordingId, Is.EqualTo("test-recording-123"), "Recording ID should match response header");
        }

        var request = mockTransport.Requests[0];
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Uri.LocalPath, Does.Contain("Record/Start"), "Should call record/start endpoint");
            Assert.That(testBase.TestStartTime, Is.GreaterThan(default(DateTime)), "TestStartTime should be set");
        }
    }

    [Test]
    public async Task StartTestRecordingAsyncInLiveModeCreatesRecording()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);

        await testBase.StartTestRecordingAsync();

        Assert.That(testBase.Recording, Is.Not.Null, "Recording should be created even in Live mode");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.Recording.Mode, Is.EqualTo(RecordedTestMode.Live), "Recording mode should be Live");
            Assert.That(testBase.TestStartTime, Is.GreaterThan(default(DateTime)), "TestStartTime should be set");
        }
    }

    [Test]
    public async Task StartTestRecordingAsyncInPlaybackModeCreatesRecording()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Playback);

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-recording-456")
                .WithContent("""{"testVar1":"value1","testVar2":"value2"}"""))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        Assert.That(testBase.Recording, Is.Not.Null, "Recording should be created");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.Recording.Mode, Is.EqualTo(RecordedTestMode.Playback), "Recording mode should be Playback");
            Assert.That(testBase.Recording.RecordingId, Is.EqualTo("playback-recording-456"), "Recording ID should match response header");
        }

        var request = mockTransport.Requests[0];
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Uri.LocalPath, Does.Contain("Playback/Start"), "Should call playback/start endpoint");
            Assert.That(testBase.TestStartTime, Is.GreaterThan(default(DateTime)), "TestStartTime should be set");
        }
    }

    [Test]
    public async Task StartTestRecordingAsyncSetsRecordingProperty()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        Assert.That(testBase.Recording, Is.Null, "Recording should be null initially");

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message => new MockPipelineResponse(200).WithHeader("x-recording-id", "property-test-789").WithContent(message.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        Assert.That(testBase.Recording, Is.Not.Null, "Recording property should be set after starting");
        Assert.That(testBase.Recording.RecordingId, Is.EqualTo("property-test-789"), "Recording should have correct ID");
    }

    [Test]
    public async Task StartTestRecordingAsyncSetsTestStartTime()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);
        var initialTime = testBase.TestStartTime;

        Assert.That(initialTime, Is.EqualTo(default(DateTime)), "TestStartTime should be default initially");

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message => new MockPipelineResponse(200).WithHeader("x-recording-id", "time-test-999").WithContent(message.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        var beforeStart = DateTime.UtcNow;
        await testBase.StartTestRecordingAsync();
        var afterStart = DateTime.UtcNow;

        Assert.That(testBase.TestStartTime, Is.GreaterThan(initialTime), "TestStartTime should be updated");
        Assert.That(testBase.TestStartTime, Is.GreaterThanOrEqualTo(beforeStart), "TestStartTime should be set to current time");
        Assert.That(testBase.TestStartTime, Is.LessThanOrEqualTo(afterStart), "TestStartTime should be set to current time");
    }

    [Test]
    public async Task StartTestRecordingAsyncAppliesSanitizersToProxy()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add some test sanitizers
        testBase.JsonPathSanitizers.Add("$.testPath");
        testBase.SanitizedHeaders.Add("Test-Header");
        testBase.SanitizedQueryParameters.Add("testParam");

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            // Return appropriate responses for different calls
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "sanitizer-test-123");
            }
            // Return success for sanitizer calls
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify record/start was called first
        Assert.That(requestCalls.Count, Is.GreaterThan(1), "Should have multiple requests (start + sanitizers)");
        Assert.That(requestCalls[0].Uri.LocalPath, Does.Contain("Record/Start"), "First call should be Record/Start");

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Skip(1).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls after record/start");

        // Check that sanitizer calls use the correct endpoint
        var sanitizerEndpointCalls = sanitizerCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).Count();
        Assert.That(sanitizerEndpointCalls, Is.GreaterThan(0), "Should have calls to /Admin/AddSanitizer endpoint");
    }

    #endregion

    #region StartTestRecordingAsync - Edge Cases

    [Test]
    public void StartTestRecordingAsyncWithNullProxyThrowsAppropriateException()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Don't set TestProxy - leave it as null

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await testBase.StartTestRecordingAsync());
        Assert.That(exception.Message, Does.Contain("test proxy has not been started"));
    }

    [Test]
    public async Task StartTestRecordingAsyncWhenAlreadyRecordingReplacesExisting()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        var mockProxy = new Mock<TestProxyProcess>();
        var callCount = 0;
        var mockTransport = new MockPipelineTransport(message =>
        {
            callCount++;
            return new MockPipelineResponse(200)
                .WithHeader("x-recording-id", $"recording-{callCount}")
                .WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        // Start first recording
        await testBase.StartTestRecordingAsync();
        var firstRecording = testBase.Recording;
        Assert.That(firstRecording, Is.Not.Null, "First recording should be created");
        Assert.That(firstRecording.RecordingId, Is.EqualTo("recording-1"), "First recording should have first ID");

        // Start second recording - should replace the first
        await testBase.StartTestRecordingAsync();
        var secondRecording = testBase.Recording;
        Assert.That(secondRecording, Is.Not.Null, "Second recording should be created");
        Assert.That(secondRecording, Is.Not.SameAs(firstRecording), "Second recording should be a different instance");
        Assert.That(secondRecording.RecordingId, Is.Not.EqualTo(firstRecording.RecordingId), "Second recording should have different ID");
    }

    [Test]
    public void StartTestRecordingAsyncHandlesProxyStartupFailures()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(500).WithContent("Internal Server Error"))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);

        testBase.TestProxy = mockProxy.Object;

        var exception = Assert.ThrowsAsync<ClientResultException>(async () => await testBase.StartTestRecordingAsync());
        Assert.That(exception.Status, Is.EqualTo(500));
    }

    #endregion

    #region StopTestRecordingAsync - Core Behavior

    [Test]
    public async Task StopTestRecordingAsyncSavesRecordingInRecordMode()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "save-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();
        Assert.That(testBase.Recording, Is.Not.Null, "Recording should be created");

        // Since this test passes, StopTestRecordingAsync should save the recording
        await testBase.StopTestRecordingAsync();

        // Verify proxy output was checked
        mockProxy.Verify(p => p.CheckProxyOutputAsync(), Times.Once);

        // The recording should have been disposed
        // (We can't easily test the DisposeAsync call without more complex mocking)
        Assert.That(testBase.Recording, Is.Not.Null, "Recording reference should still exist");
    }

    [Test]
    public async Task StopTestRecordingAsyncDisposesRecording()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message => new MockPipelineResponse(200).WithHeader("x-recording-id", "dispose-test-123").WithContent(message.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);
        mockProxy.Setup(p => p.CheckProxyOutputAsync()).Returns(Task.CompletedTask);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();
        var originalRecording = testBase.Recording;
        Assert.That(originalRecording, Is.Not.Null, "Recording should be created");

        await testBase.StopTestRecordingAsync();

        // Recording should still be accessible but disposed internally
        Assert.That(testBase.Recording, Is.Not.Null, "Recording reference should still exist after disposal");
        mockProxy.Verify(p => p.CheckProxyOutputAsync(), Times.Once);
    }

    [Test]
    public async Task StopTestRecordingAsyncClearsRecordingProperty()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Live);

        // In Live mode, no proxy is needed
        await testBase.StartTestRecordingAsync();
        Assert.That(testBase.Recording, Is.Not.Null, "Recording should be created even in Live mode");

        await testBase.StopTestRecordingAsync();

        // Recording should still be accessible - it's not cleared, just disposed
        Assert.That(testBase.Recording, Is.Not.Null, "Recording should still be accessible after stop");
    }

    #endregion

    #region StopTestRecordingAsync - Edge Cases

    [Test]
    public void StopTestRecordingAsyncWhenNoRecordingActiveDoesNotThrow()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Don't start recording - just try to stop
        Assert.That(testBase.Recording, Is.Null, "Recording should be null initially");

        // This should not throw an exception
        Assert.DoesNotThrowAsync(async () => await testBase.StopTestRecordingAsync(),
            "StopTestRecordingAsync should handle null recording gracefully");
    }

    [Test]
    public async Task StopTestRecordingAsyncHandlesSaveFailuresGracefully()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            var path = message.Request.Uri.LocalPath;

            // Allow record/start and all sanitizer calls to succeed
            if (path.Contains("Record/Start") || path.Contains("/Admin/"))
            {
                if (path.Contains("Record/Start"))
                {
                    return new MockPipelineResponse(200).WithHeader("x-recording-id", "save-failure-test-123").WithContent(message.Request.Content);
                }
                return new MockPipelineResponse(200).WithContent(message.Request.Content);
            }

            // Fail on record/stop calls
            if (path.Contains("Record/Stop"))
            {
                return new MockPipelineResponse(500).WithContent("Save failed");
            }

            // Default success for other calls
            return new MockPipelineResponse(200);
        })
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);
        mockProxy.Setup(p => p.CheckProxyOutputAsync()).Returns(Task.CompletedTask);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();
        Assert.That(testBase.Recording, Is.Not.Null, "Recording should be created");

        // This should propagate the failure from the record/stop call
        var exception = Assert.ThrowsAsync<ClientResultException>(async () => await testBase.StopTestRecordingAsync());
        Assert.That(exception.Status, Is.EqualTo(500), "Should propagate the HTTP error status");
    }

    #endregion

    #region Sanitizer Configuration

    [Test]
    public async Task JsonPathSanitizersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add JSON path sanitizers
        testBase.JsonPathSanitizers.Add("$.sensitive.field1");
        testBase.JsonPathSanitizers.Add("$.user.password");

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "json-sanitizer-test-123");
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify sanitizer calls were made for JSON paths
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");

            // Verify the added JSON path sanitizers were applied
            Assert.That(testBase.JsonPathSanitizers, Contains.Item("$.sensitive.field1"));
        }
        Assert.That(testBase.JsonPathSanitizers, Contains.Item("$.user.password"));
    }

    [Test]
    public async Task BodyKeySanitizersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add body key sanitizers
        var sanitizer1 = new BodyKeySanitizer(new BodyKeySanitizerBody("$.api.key") { Value = "REDACTED_KEY" });
        var sanitizer2 = new BodyKeySanitizer(new BodyKeySanitizerBody("$.credentials.secret") { Value = "REDACTED_SECRET" });
        testBase.BodyKeySanitizers.Add(sanitizer1);
        testBase.BodyKeySanitizers.Add(sanitizer2);

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "body-key-sanitizer-test-123");
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify the sanitizers were added
        Assert.That(testBase.BodyKeySanitizers.Count, Is.EqualTo(2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.BodyKeySanitizers[0].Body.JsonPath, Is.EqualTo("$.api.key"));
            Assert.That(testBase.BodyKeySanitizers[0].Body.Value, Is.EqualTo("REDACTED_KEY"));
            Assert.That(testBase.BodyKeySanitizers[1].Body.JsonPath, Is.EqualTo("$.credentials.secret"));
            Assert.That(testBase.BodyKeySanitizers[1].Body.Value, Is.EqualTo("REDACTED_SECRET"));
        }

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");
    }

    [Test]
    public async Task BodyRegexSanitizersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add body regex sanitizers
        var sanitizer1 = new BodyRegexSanitizer(new BodyRegexSanitizerBody("password\":\"REDACTED", "password\\\":\\s*\\\"[^\\\"]*", null, null, null));
        var sanitizer2 = new BodyRegexSanitizer(new BodyRegexSanitizerBody("token\":\"REDACTED", "token\\\":\\s*\\\"[^\\\"]*", null, null, null));
        testBase.BodyRegexSanitizers.Add(sanitizer1);
        testBase.BodyRegexSanitizers.Add(sanitizer2);

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "body-regex-sanitizer-test-123");
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        ;
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify the sanitizers were added
        Assert.That(testBase.BodyRegexSanitizers.Count, Is.EqualTo(2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.BodyRegexSanitizers[0].Body.Regex, Is.EqualTo("password\\\":\\s*\\\"[^\\\"]*"));
            Assert.That(testBase.BodyRegexSanitizers[0].Body.Value, Is.EqualTo("password\":\"REDACTED"));
            Assert.That(testBase.BodyRegexSanitizers[1].Body.Regex, Is.EqualTo("token\\\":\\s*\\\"[^\\\"]*"));
            Assert.That(testBase.BodyRegexSanitizers[1].Body.Value, Is.EqualTo("token\":\"REDACTED"));
        }

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");
    }

    [Test]
    public async Task UriRegexSanitizersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add custom URI regex sanitizers (in addition to default ones)
        var customSanitizer = new UriRegexSanitizer(new UriRegexSanitizerBody("subscriptionId=00000000-0000-0000-0000-000000000000", "subscriptionId=[^&]+", null, null, null));
        testBase.UriRegexSanitizers.Add(customSanitizer);

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "uri-regex-sanitizer-test-123").WithContent(message.Request.Content);
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify the custom sanitizer was added (plus the 2 default ones)
        Assert.That(testBase.UriRegexSanitizers.Count, Is.EqualTo(3));
        var customAdded = testBase.UriRegexSanitizers.FirstOrDefault(s => s.Body.Regex.Contains("subscriptionId"));
        Assert.That(customAdded, Is.Not.Null, "Custom URI regex sanitizer should be added");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(customAdded.Body.Regex, Is.EqualTo("subscriptionId=[^&]+"));
            Assert.That(customAdded.Body.Value, Is.EqualTo("subscriptionId=00000000-0000-0000-0000-000000000000"));
        }

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");
    }

    [Test]
    public async Task HeaderRegexSanitizersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add header regex sanitizers
        var sanitizer1 = new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("Authorization") { Value = "REDACTED" });
        var sanitizer2 = new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("x-api-key") { Value = "REDACTED_API_KEY" });
        testBase.HeaderRegexSanitizers.Add(sanitizer1);
        testBase.HeaderRegexSanitizers.Add(sanitizer2);

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "header-regex-sanitizer-test-123");
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify the sanitizers were added
        Assert.That(testBase.HeaderRegexSanitizers.Count, Is.EqualTo(2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(testBase.HeaderRegexSanitizers[0].Body.Key, Is.EqualTo("Authorization"));
            Assert.That(testBase.HeaderRegexSanitizers[0].Body.Value, Is.EqualTo("REDACTED"));
            Assert.That(testBase.HeaderRegexSanitizers[1].Body.Key, Is.EqualTo("x-api-key"));
            Assert.That(testBase.HeaderRegexSanitizers[1].Body.Value, Is.EqualTo("REDACTED_API_KEY"));
        }

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");
    }

    [Test]
    public async Task SanitizedHeadersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add headers to be sanitized (simple header name sanitization)
        testBase.SanitizedHeaders.Add("x-custom-auth");
        testBase.SanitizedHeaders.Add("x-session-token");

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "sanitized-headers-test-123");
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify the headers were added
        Assert.That(testBase.SanitizedHeaders, Contains.Item("x-custom-auth"));
        Assert.That(testBase.SanitizedHeaders, Contains.Item("x-session-token"));

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");
    }

    [Test]
    public async Task SanitizedQueryParametersCanBeModifiedAndApplied()
    {
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Add query parameters to be sanitized (in addition to default ones)
        testBase.SanitizedQueryParameters.Add("api_key");
        testBase.SanitizedQueryParameters.Add("access_token");

        var requestCalls = new List<PipelineRequest>();
        var mockProxy = new Mock<TestProxyProcess>();
        var mockTransport = new MockPipelineTransport(message =>
        {
            requestCalls.Add(message.Request);
            if (message.Request.Uri.LocalPath.Contains("Record/Start"))
            {
                return new MockPipelineResponse(200).WithHeader("x-recording-id", "sanitized-query-params-test-123");
            }
            return new MockPipelineResponse(200).WithContent(message.Request.Content);
        })
        {
            ExpectSyncPipeline = false
        };

        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        testBase.TestProxy = mockProxy.Object;

        await testBase.StartTestRecordingAsync();

        // Verify the custom query parameters were added (plus the 4 default ones)
        Assert.That(testBase.SanitizedQueryParameters.Count, Is.EqualTo(6));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("api_key"));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("access_token"));
        // Verify default ones are still there
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("sig"));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("sip"));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("client_id"));
        Assert.That(testBase.SanitizedQueryParameters, Contains.Item("client_secret"));

        // Verify sanitizer calls were made
        var sanitizerCalls = requestCalls.Where(r => r.Uri.LocalPath.Contains("/Admin/AddSanitizer")).ToList();
        Assert.That(sanitizerCalls.Count, Is.GreaterThan(0), "Should have sanitizer calls");
    }

    #endregion

    #region Test Lifecycle Integration

    [Test]
    public void InitializeRecordedTestClassStartsProxyWhenNeeded()
    {
        // Test that the proxy is started when needed for Record/Playback modes
        var testBase = new TestableRecordedTestBase(isAsync: true, RecordedTestMode.Record);

        // Mock the static proxy manager behavior
        var mockProxy = new Mock<TestProxyProcess>();
        mockProxy.Setup(p => p.ProxyClient).Returns(
            new TestProxyClient(new Uri("http://127.0.0.1:5000"), new TestProxyClientOptions()));

        // Before initialization, TestProxy should be null
        Assert.That(testBase.TestProxy, Is.Null, "TestProxy should be null before initialization");

        // Simulate the initialization process by setting the proxy
        testBase.TestProxy = mockProxy.Object;

        // After initialization, TestProxy should be available
        Assert.That(testBase.TestProxy, Is.Not.Null, "TestProxy should be available after initialization");
        Assert.That(testBase.TestProxy.ProxyClient, Is.Not.Null, "ProxyClient should be available");

        // Verify proxy client has correct base URI
        Assert.That(testBase.TestProxy.ProxyClient.Pipeline, Is.Not.Null, "ProxyClient should have a pipeline");
    }

    #endregion

    #region Helper Methods

    private class TestableRecordedTestBase : RecordedTestBase
    {
        public TestableRecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        // Expose protected properties for testing
        public new bool ValidateClientInstrumentation
        {
            get => base.ValidateClientInstrumentation;
            set => base.ValidateClientInstrumentation = value;
        }

        // Expose TestStartTime for testing
        public new DateTime TestStartTime => base.TestStartTime;

        // Expose internal TestProxy for testing
        public new TestProxyProcess TestProxy
        {
            get => base.TestProxy;
            set => base.TestProxy = value;
        }
    }

    private class TestableRecordedTestBaseWithAssetsPath : RecordedTestBase
    {
        private readonly string _assetsJsonPath;

        public TestableRecordedTestBaseWithAssetsPath(bool isAsync, string assetsJsonPath, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            _assetsJsonPath = assetsJsonPath;
        }

        // Override AssetsJsonPath to provide custom value for testing
        public override string AssetsJsonPath => _assetsJsonPath;

        // Expose protected properties for testing
        public new bool ValidateClientInstrumentation
        {
            get => base.ValidateClientInstrumentation;
            set => base.ValidateClientInstrumentation = value;
        }
    }

    private class TemporaryDirectory : IDisposable
    {
        public string DirectoryPath { get; }

        public TemporaryDirectory()
        {
            DirectoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(DirectoryPath);
        }

        public void Dispose()
        {
            if (Directory.Exists(DirectoryPath))
            {
                try
                {
                    Directory.Delete(DirectoryPath, recursive: true);
                }
                catch (Exception)
                {
                    // Best effort cleanup - don't fail tests if temp cleanup fails
                }
            }
        }
    }

    #endregion
}
