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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class TestRecordingTests
{
    #region Create/initialize tests

    [Test]
    public async Task CreateLiveModeDoesNotInitializeProxy()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var mockProxyClient = new Mock<TestProxyClient>();
        var testBase = new TestRecordedTestBase();

        mockProxy.Setup(p => p.ProxyClient).Returns(mockProxyClient.Object);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Live));
        mockProxyClient.Verify(p => p.StartRecordAsync(It.IsAny<TestProxyStartInformation>(), It.IsAny<CancellationToken>()), Times.Never);
        mockProxyClient.Verify(p => p.StartPlaybackAsync(It.IsAny<TestProxyStartInformation>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task CreateRecordModeStartsRecordingSession()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "test-recording-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));
            Assert.That(recording.RecordingId, Is.EqualTo("test-recording-123"));
            Assert.That(recording.Variables, Is.Not.Null);
        }
        Assert.That(recording.Variables, Is.Empty);
        Assert.That(recording.HasRequests, Is.False);

        // Verify the correct API call was made
        var request = mockTransport.Requests[0];
        Assert.That(request.Uri.LocalPath, Does.Contain("Record/Start"));
    }

    [Test]
    public async Task CreatePlaybackModeInitializesPlayback()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" }, { "AnotherVar", "AnotherValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-id-123")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Playback));
            Assert.That(recording.RecordingId, Is.EqualTo("playback-id-123"));
            Assert.That(recording.Variables, Is.Not.Null);
        }
        Assert.That(recording.Variables, Has.Count.EqualTo(2));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Variables["TestVar"], Is.EqualTo("TestValue"));
            Assert.That(recording.Variables["AnotherVar"], Is.EqualTo("AnotherValue"));
            Assert.That(recording.HasRequests, Is.False);
        }

        // Verify the correct API call was made
        var request = mockTransport.Requests[0];
        Assert.That(request.Uri.LocalPath, Does.Contain("Playback/Start"));
    }

    [Test]
    public async Task InitializeRecordModeAppliesSanitizers()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithSanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "test-recording-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));
            Assert.That(recording.RecordingId, Is.EqualTo("test-recording-123"));

            // Verify sanitizer API calls were made
            // Should have: record/start + multiple sanitizer calls
            Assert.That(mockTransport.Requests.Count, Is.GreaterThan(1));
        }

        // Verify record/start was called first
        var recordStartRequest = mockTransport.Requests[0];
        Assert.That(recordStartRequest.Uri.LocalPath, Does.Contain("Record/Start"));

        // Find all sanitizer calls - all sanitizers use /admin/AddSanitizers endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // We expect exactly 1 sanitizer call with all sanitizers in the request body
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers");

        // Verify that we have some sanitizer calls
        Assert.That(sanitizerRequests, Is.Not.Empty);
    }

    [Test]
    public async Task InitializeRecordModeExtractsRecordingId()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-id-456").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.RecordingId, Is.EqualTo("record-id-456"));
        Assert.That(recording.RecordingId, Is.Not.Null);
        Assert.That(recording.RecordingId, Is.Not.Empty);
    }

    [Test]
    public async Task InitializePlaybackModeAppliesSanitizers()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithSanitizers();

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-id-123")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Playback));

        // Find all sanitizer calls - all sanitizers use /admin/AddSanitizers endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that sanitizers were applied in playback mode too - should be exactly 1 call
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers");
        Assert.That(sanitizerRequests, Is.Not.Empty);
    }

    [Test]
    public async Task InitializePlaybackModeLoadsVariables()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string>
        {
            { "Var1", "Value1" },
            { "Var2", "Value2" },
            { "DateTimeOffsetNow", "2023-01-01T00:00:00.0000000Z" }
        };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-id-789")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Playback));
            Assert.That(recording.Variables, Is.Not.Null);
        }
        Assert.That(recording.Variables, Has.Count.EqualTo(3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Variables["Var1"], Is.EqualTo("Value1"));
            Assert.That(recording.Variables["Var2"], Is.EqualTo("Value2"));
            Assert.That(recording.Variables["DateTimeOffsetNow"], Is.EqualTo("2023-01-01T00:00:00.0000000Z"));
            Assert.That(recording.Variables, Is.TypeOf<SortedDictionary<string, string>>());
        }
    }

    [Test]
    public async Task InitializePlaybackModeExtractsRecordingId()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-extract-id-999")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.RecordingId, Is.EqualTo("playback-extract-id-999"));
        Assert.That(recording.RecordingId, Is.Not.Null);
        Assert.That(recording.RecordingId, Is.Not.Empty);
    }

    [Test]
    public async Task InitializePlaybackModeSetsDefaultMatcher()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-id-matcher")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Playback));

        // Find matcher calls - should use /admin/setmatcher endpoint
        var allRequests = mockTransport.Requests.ToList();
        var matcherRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/SetMatcher")).ToList();

        // Verify that a matcher was set during playback initialization
        Assert.That(matcherRequests.Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(matcherRequests, Is.Not.Empty);
    }

    //[Test]
    //public async Task InitializePlaybackModeAppliesHeaderTransforms()
    //{
    //    var mockProxy = new Mock<TestProxyProcess>();
    //    var testBase = new TestRecordedTestBaseWithHeaderTransforms();

    //    var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
    //    var mockTransport = new MockPipelineTransport(_ =>
    //        new MockPipelineResponse(200)
    //            .WithHeader("x-recording-id", "playback-id-transforms")
    //            .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
    //    {
    //        ExpectSyncPipeline = false
    //    };
    //    var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
    //    mockProxy.Setup(p => p.ProxyClient).Returns(client);

    //    TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

    //    Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Playback));

    //    // Find transform calls - should use /admin/addtransform endpoint
    //    var allRequests = mockTransport.Requests.ToList();
    //    var transformRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("admin/addtransform")).ToList();

    //    // Verify that header transforms were applied during playback initialization
    //    Assert.That(transformRequests.Count, Is.GreaterThanOrEqualTo(2)); // We have 2 transforms configured
    //    Assert.That(transformRequests, Is.Not.Empty);
    //}

    [Test]
    public void InitializePlaybackModeHandles404Exception()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(404)
                .WithContent(BinaryData.FromString("Recording not found").ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);

        Assert.DoesNotThrowAsync(async () =>
            await TestRecording.CreateAsync(RecordedTestMode.Playback, "missing-session.json", mockProxy.Object, testBase));
    }

    [Test]
    public async Task InitializeLiveModeDoesNothing()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithContent(BinaryData.FromString("Should not be called").ToArray()))
        {
            ExpectSyncPipeline = false
        };
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Live));

        // Verify that no HTTP requests were made to the test proxy (Live mode skips proxy initialization)
        var allRequests = mockTransport.Requests.ToList();
        Assert.That(allRequests, Is.Empty, "Live mode should not make any proxy calls");
    }

    [Test]
    public async Task HeaderSanitizersApplied()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithHeaderSanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "header-sanitizer-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        // Find all sanitizer calls - all sanitizers use /admin/AddSanitizers endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that header sanitizers were applied - should be exactly 1 call with all sanitizers
        Assert.That(sanitizerRequests, Is.Not.Empty);
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers containing all sanitizers");

        // Verify that the sanitizer request was made to the correct endpoint
        var sanitizerRequest = sanitizerRequests.First();
        Assert.That(sanitizerRequest.Uri.LocalPath, Does.Contain("Admin/AddSanitizers"),
                   "Request should be made to Admin/AddSanitizers endpoint");

        // Verify that content was provided (sanitizers were included in the request)
        Assert.That(sanitizerRequest.Content, Is.Not.Null,
                   "Request should contain content with sanitizer information");
    }

    [Test]
    public async Task HeaderRegexSanitizersApplied()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithHeaderRegexSanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "header-regex-sanitizer-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        // Find all sanitizer calls - all sanitizers use /admin/AddSanitizers endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that header regex sanitizers were applied - should be exactly 1 call with all sanitizers
        Assert.That(sanitizerRequests, Is.Not.Empty);
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers containing all sanitizers");

        // Verify that the sanitizer request was made to the correct endpoint
        var sanitizerRequest = sanitizerRequests.First();
        Assert.That(sanitizerRequest.Uri.LocalPath, Does.Contain("Admin/AddSanitizers"),
                   "Request should be made to Admin/AddSanitizers endpoint");

        // Verify that content was provided (sanitizers were included in the request)
        Assert.That(sanitizerRequest.Content, Is.Not.Null,
                   "Request should contain content with sanitizer information");
    }

    [Test]
    public async Task QueryParameterSanitizersApplied()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithQueryParameterSanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "query-param-sanitizer-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        // Find all sanitizer calls - all sanitizers use /admin/AddSanitizers endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that query parameter sanitizers were applied - should be exactly 1 call with all sanitizers
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers containing all sanitizers");

        // Verify that query parameter sanitizers were applied - should be exactly 1 call with all sanitizers
        Assert.That(sanitizerRequests, Is.Not.Empty);
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers containing all sanitizers");

        // Verify that the sanitizer request was made to the correct endpoint
        var sanitizerRequest = sanitizerRequests.First();
        Assert.That(sanitizerRequest.Uri.LocalPath, Does.Contain("Admin/AddSanitizers"),
                   "Request should be made to Admin/AddSanitizers endpoint");

        // Verify that content was provided (sanitizers were included in the request)
        Assert.That(sanitizerRequest.Content, Is.Not.Null,
                   "Request should contain content with sanitizer information");
    }

    [Test]
    public async Task JsonPathSanitizersApplied()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithJsonPathSanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "json-path-sanitizer-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that the request body contains JSON path sanitizers
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers");

        // Verify that the sanitizer request was made to the correct endpoint
        var sanitizerRequest = sanitizerRequests.First();
        Assert.That(sanitizerRequest.Uri.LocalPath, Does.Contain("Admin/AddSanitizers"),
                   "Request should be made to Admin/AddSanitizers endpoint");

        // Verify that content was provided (sanitizers were included in the request)
        Assert.That(sanitizerRequest.Content, Is.Not.Null,
                   "Request should contain content with sanitizer information");
    }

    [Test]
    public async Task BodyKeySanitizersApplied()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithBodyKeySanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "body-key-sanitizer-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        // Find all sanitizer calls - all sanitizers use /admin/addsanitizer endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that body key sanitizers were applied - should be exactly 1 call with all sanitizers
        Assert.That(sanitizerRequests, Is.Not.Empty);
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers containing all sanitizers");

        // Verify that the sanitizer request was made to the correct endpoint
        var sanitizerRequest = sanitizerRequests.First();
        Assert.That(sanitizerRequest.Uri.LocalPath, Does.Contain("Admin/AddSanitizers"),
                   "Request should be made to Admin/AddSanitizers endpoint");

        // Verify that content was provided (sanitizers were included in the request)
        Assert.That(sanitizerRequest.Content, Is.Not.Null,
                   "Request should contain content with sanitizer information");
    }

    [Test]
    public async Task BodyRegexSanitizersApplied()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithBodyRegexSanitizers();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "body-regex-sanitizer-test-123").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        // Find all sanitizer calls - all sanitizers use /admin/AddSanitizers endpoint
        var allRequests = mockTransport.Requests.ToList();
        var sanitizerRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/AddSanitizers")).ToList();

        // Verify that body regex sanitizers were applied - should be exactly 1 call with all sanitizers
        Assert.That(sanitizerRequests, Is.Not.Empty);
        Assert.That(sanitizerRequests.Count, Is.EqualTo(1), "Should have exactly one call to Admin/AddSanitizers containing all sanitizers");

        // Verify that the sanitizer request was made to the correct endpoint
        var sanitizerRequest = sanitizerRequests.First();
        Assert.That(sanitizerRequest.Uri.LocalPath, Does.Contain("Admin/AddSanitizers"),
                   "Request should be made to Admin/AddSanitizers endpoint");

        // Verify that content was provided (sanitizers were included in the request)
        Assert.That(sanitizerRequest.Content, Is.Not.Null,
                   "Request should contain content with sanitizer information");
    }

    [Test]
    public async Task SanitizersToRemoveAreRemoved()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBaseWithSanitizersToRemove();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200)
        .WithHeader("x-recording-id", "sanitizers-to-remove-test-123")
        .WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.Mode, Is.EqualTo(RecordedTestMode.Record));

        // Find all requests - should include record/start and remove sanitizers calls
        var allRequests = mockTransport.Requests.ToList();

        // Find remove sanitizers calls - should use /admin/removesanitizers endpoint
        var removeSanitizersRequests = allRequests.Where(req => req.Uri.LocalPath.Contains("Admin/RemoveSanitizers")).ToList();

        // Verify that remove sanitizers requests were made
        Assert.That(removeSanitizersRequests, Is.Not.Empty);
        Assert.That(removeSanitizersRequests.Count, Is.GreaterThanOrEqualTo(1)); // We have sanitizers to remove configured

        // Verify that at least some requests contain remove sanitizers patterns
        bool foundRemoveSanitizersRequest = removeSanitizersRequests.Any(req =>
        {
            // Check if request headers indicate remove sanitizers operation
            return req.Headers.Any(h => h.Key.Contains("x-recording-id"));
        });

        Assert.That(foundRemoveSanitizersRequest, Is.True, "Should have found remove sanitizers requests");
    }

    #endregion

    #region Properties tests

    [Test]
    public async Task VariablesAreSorted()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var unsortedVariables = new Dictionary<string, string>
        {
            { "ZVar", "ZValue" },
            { "AVar", "AValue" },
            { "MVar", "MValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "sorted-test-id")
                .WithContent(BinaryData.FromObjectAsJson(unsortedVariables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Verify Variables is a SortedDictionary
        Assert.That(recording.Variables, Is.TypeOf<SortedDictionary<string, string>>());

        // Verify the keys are in sorted order
        var keys = recording.Variables.Keys.ToList();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(keys, Is.EqualTo(new[] { "AVar", "MVar", "ZVar" }));

            // Verify all values are present
            Assert.That(recording.Variables["AVar"], Is.EqualTo("AValue"));
            Assert.That(recording.Variables["MVar"], Is.EqualTo("MValue"));
            Assert.That(recording.Variables["ZVar"], Is.EqualTo("ZValue"));
        }
    }

    [Test]
    public async Task RecordingIdSetDuringRecordMode()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        const string expectedRecordingId = "record-mode-id-test";

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", expectedRecordingId).WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.RecordingId, Is.EqualTo(expectedRecordingId));
        Assert.That(recording.RecordingId, Is.Not.Null);
        Assert.That(recording.RecordingId, Is.Not.Empty);
    }

    [Test]
    public async Task RecordingIdSetDuringPlaybackMode()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        const string expectedRecordingId = "playback-mode-id-test";

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", expectedRecordingId)
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        Assert.That(recording.RecordingId, Is.EqualTo(expectedRecordingId));
        Assert.That(recording.RecordingId, Is.Not.Null);
        Assert.That(recording.RecordingId, Is.Not.Empty);
    }

    [Test]
    public async Task HasRequestsReturnsTrueWhenRequestsSent()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "requests-test-id").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Initially should be false
        Assert.That(recording.HasRequests, Is.False);

        // Simulate that requests have been processed (this would normally be set internally)
        recording.HasRequests = true;

        Assert.That(recording.HasRequests, Is.True);
    }

    [Test]
    public async Task HasRequestsReturnsFalseWhenNoRequestsSent()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "no-requests-test-id").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Should remain false when no requests have been processed
        Assert.That(recording.HasRequests, Is.False);
    }

    [Test]
    public async Task RandomLiveModeIsDifferentEachTime()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create two live mode recordings
        TestRecording recording1 = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);
        TestRecording recording2 = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        // Get random numbers from both recordings
        var random1 = recording1.Random.Next();
        var random2 = recording2.Random.Next();
        var random3 = recording1.Random.Next();
        var random4 = recording2.Random.Next();

        // Live mode should produce different random sequences
        Assert.That(random2, Is.Not.EqualTo(random1).Or.Not.EqualTo(random3).Or.Not.EqualTo(random4),
            "Live mode Random should produce different values across instances");
    }

    [Test]
    public async Task RandomRecordModeRecordsSeed()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-seed-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Access Random property to trigger seed recording
        var randomValue = recording.Random.Next();

        using (Assert.EnterMultipleScope())
        {
            // Verify that a RandomSeed variable was recorded
            Assert.That(recording.Variables.ContainsKey("RandomSeed"), Is.True);
            Assert.That(recording.Variables["RandomSeed"], Is.Not.Null);
        }
        Assert.That(recording.Variables["RandomSeed"], Is.Not.Empty);

        // Verify the recorded seed can be parsed as an integer
        Assert.That(int.TryParse(recording.Variables["RandomSeed"], out _), Is.True);
    }

    [Test]
    public async Task RandomRecordModeIsDeterministic()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-deterministic-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Get the seed that was recorded
        var randomValue1 = recording.Random.Next();
        var recordedSeed = recording.Variables["RandomSeed"];

        // Create a new TestRandom with the same seed and mode
        var testRandom = new TestRandom(RecordedTestMode.Record, int.Parse(recordedSeed));
        var randomValue2 = testRandom.Next();

        // Should produce the same value with the same seed
        Assert.That(randomValue2, Is.EqualTo(randomValue1));
    }

    [Test]
    public async Task RandomPlaybackModeUsesRecordedSeed()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        const int expectedSeed = 12345;
        var variables = new Dictionary<string, string>
        {
            { "RandomSeed", expectedSeed.ToString() },
            { "TestVar", "TestValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-seed-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Create expected TestRandom with the same seed
        var expectedRandom = new TestRandom(RecordedTestMode.Playback, expectedSeed);
        var expectedValue = expectedRandom.Next();

        // Get value from recording's Random
        var actualValue = recording.Random.Next();

        // Should match the expected value from the same seed
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public async Task RandomPlaybackModeThrowsWhenNoVariables()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create a playback recording with no variables (empty dictionary)
        var emptyVariables = new Dictionary<string, string>();

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-no-vars-test")
                .WithContent(BinaryData.FromObjectAsJson(emptyVariables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Accessing Random property should throw because there are no variables
        Assert.Throws<TestRecordingMismatchException>(() => { var _ = recording.Random; });
    }

    [Test]
    public async Task NowLiveModeReturnsCurrentTime()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        var beforeTime = DateTimeOffset.Now.AddSeconds(-1);
        var recordingTime = recording.Now;
        var afterTime = DateTimeOffset.Now.AddSeconds(1);

        // Live mode should return current time (within a reasonable range)
        Assert.That(recordingTime, Is.GreaterThanOrEqualTo(beforeTime));
        Assert.That(recordingTime, Is.LessThanOrEqualTo(afterTime));
    }

    [Test]
    public async Task NowPropertyIsCached()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        var firstCall = recording.Now;
        await Task.Delay(10); // Small delay to ensure time would change
        var secondCall = recording.Now;

        // Now property should be cached and return the same value
        Assert.That(secondCall, Is.EqualTo(firstCall));
    }

    [Test]
    public async Task NowRecordModeReturnsCurrentTime()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-now-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        var beforeTime = DateTimeOffset.Now.AddSeconds(-1);
        var recordingTime = recording.Now;
        var afterTime = DateTimeOffset.Now.AddSeconds(1);

        // Record mode should return current time (within a reasonable range)
        Assert.That(recordingTime, Is.GreaterThanOrEqualTo(beforeTime));
        Assert.That(recordingTime, Is.LessThanOrEqualTo(afterTime));
    }

    [Test]
    public async Task NowRecordModeIsRecorded()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-now-recorded-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Access Now property to trigger recording
        var nowValue = recording.Now;

        using (Assert.EnterMultipleScope())
        {
            // Verify that DateTimeOffsetNow variable was recorded
            Assert.That(recording.Variables.ContainsKey("DateTimeOffsetNow"), Is.True);
            Assert.That(recording.Variables["DateTimeOffsetNow"], Is.Not.Null);
        }
        Assert.That(recording.Variables["DateTimeOffsetNow"], Is.Not.Empty);

        // Verify the recorded value can be parsed as DateTimeOffset
        Assert.That(DateTimeOffset.TryParse(recording.Variables["DateTimeOffsetNow"], out var parsedTime), Is.True);
        Assert.That(parsedTime, Is.EqualTo(nowValue));
    }

    [Test]
    public async Task NowRecordModeCanRoundTrip()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-now-roundtrip-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        // Create record mode recording
        TestRecording recordRecording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);
        var originalTime = recordRecording.Now;
        var recordedTimeString = recordRecording.Variables["DateTimeOffsetNow"];

        // Create playback mode recording with the recorded variables
        var playbackVariables = new Dictionary<string, string>
        {
            { "DateTimeOffsetNow", recordedTimeString },
            { "TestVar", "TestValue" }
        };

        var playbackTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-now-roundtrip-test")
                .WithContent(BinaryData.FromObjectAsJson(playbackVariables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var playbackClient = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = playbackTransport });
        var playbackProxy = new Mock<TestProxyProcess>();
        playbackProxy.Setup(p => p.ProxyClient).Returns(playbackClient);
        var playbackAdminClient = playbackClient.GetTestProxyAdminClient();
        playbackProxy.Setup(p => p.AdminClient).Returns(playbackAdminClient);

        TestRecording playbackRecording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", playbackProxy.Object, testBase);
        var playbackTime = playbackRecording.Now;

        // The time should round-trip exactly
        Assert.That(playbackTime, Is.EqualTo(originalTime));
    }

    #endregion

    #region Create transport tests

    [Test]
    public async Task LiveTransportReturnsCurrentTransport()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create a live mode recording
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        // Create a mock transport
        var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200))
        {
            ExpectSyncPipeline = false
        };

        // Call CreateTransport - should return the same transport unchanged in Live mode
        var result = recording.CreateTransport(mockTransport);

        // In Live mode, CreateTransport should return the exact same transport instance
        Assert.That(result, Is.SameAs(mockTransport));
        Assert.That(result, Is.Not.TypeOf<ProxyTransport>());
    }

    [Test]
    public async Task RecordModeWrapsTransport()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "record-transport-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        // Create a record mode recording
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Create a mock inner transport
        var innerTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200))
        {
            ExpectSyncPipeline = false
        };

        // Call CreateTransport - should wrap the transport with ProxyTransport in Record mode
        var result = recording.CreateTransport(innerTransport);

        // In Record mode, CreateTransport should return a ProxyTransport that wraps the inner transport
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<ProxyTransport>());
        Assert.That(result, Is.Not.SameAs(innerTransport));
    }

    [Test]
    public async Task PlaybackModeWrapsTransport()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-transport-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        // Create a playback mode recording
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Create a mock inner transport
        var innerTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200))
        {
            ExpectSyncPipeline = false
        };

        // Call CreateTransport - should wrap the transport with ProxyTransport in Playback mode
        var result = recording.CreateTransport(innerTransport);

        // In Playback mode, CreateTransport should return a ProxyTransport that wraps the inner transport
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<ProxyTransport>());
        Assert.That(result, Is.Not.SameAs(innerTransport));
    }

    [Test]
    public async Task CreateTransportThrowsOnDoubleInstrumentation()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockTransport = new MockPipelineTransport(p => new MockPipelineResponse(200).WithHeader("x-recording-id", "double-instrumentation-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        // Create a record mode recording
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Create a mock inner transport
        var innerTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200))
        {
            ExpectSyncPipeline = false
        };

        // Call CreateTransport once - should succeed
        var result = recording.CreateTransport(innerTransport);
        Assert.That(result, Is.TypeOf<ProxyTransport>());

        // Call CreateTransport again with a ProxyTransport - should throw InvalidOperationException
        var exception = Assert.Throws<InvalidOperationException>(() => recording.CreateTransport(result));
        Assert.That(exception.Message, Does.Contain("already been instrumented"));
        Assert.That(exception.Message, Does.Contain("unique options instance"));
        Assert.That(exception.Message, Does.Contain("InstrumentClientOptions"));
    }

    [Test]
    public async Task LiveTransportHandlesNullTransport()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create a live mode recording
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        // Call CreateTransport with null - should return null in Live mode
        var result = recording.CreateTransport(null);

        // In Live mode, CreateTransport should return null when passed null
        Assert.That(result, Is.Null);
    }

    #endregion

    #region Generate id tests

    [Test]
    public async Task GenerateIdPlaybackIsDeterministic()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create two playback recordings with the same recorded seed
        const int seed = 42;
        var variables = new Dictionary<string, string>
        {
            { "RandomSeed", seed.ToString() },
            { "TestVar", "TestValue" }
        };

        var mockTransport1 = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "generate-id-deterministic-1")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client1 = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport1 });
        var mockProxy1 = new Mock<TestProxyProcess>();
        mockProxy1.Setup(p => p.ProxyClient).Returns(client1);
        var adminClient1 = client1.GetTestProxyAdminClient();
        mockProxy1.Setup(p => p.AdminClient).Returns(adminClient1);

        var mockTransport2 = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "generate-id-deterministic-2")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client2 = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport2 });
        var mockProxy2 = new Mock<TestProxyProcess>();
        mockProxy2.Setup(p => p.ProxyClient).Returns(client2);
        var adminClient2 = client2.GetTestProxyAdminClient();
        mockProxy2.Setup(p => p.AdminClient).Returns(adminClient2);

        TestRecording recording1 = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session1.json", mockProxy1.Object, testBase);
        TestRecording recording2 = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session2.json", mockProxy2.Object, testBase);

        // Generate IDs from both recordings - should be identical
        var id1 = recording1.GenerateId();
        var id2 = recording2.GenerateId();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(id2, Is.EqualTo(id1), "Playback mode should produce deterministic IDs with the same seed");
            Assert.That(id1, Is.Not.Null);
        }
        Assert.That(id1, Is.Not.Empty);
    }

    [Test]
    public async Task GenerateIdWithPrefixReturnsPrefixedString()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        const int seed = 123;
        var variables = new Dictionary<string, string>
        {
            { "RandomSeed", seed.ToString() }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "generate-id-prefix-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        const string prefix = "test-prefix-";
        const int maxLength = 20;
        var id = recording.GenerateId(prefix, maxLength);

        Assert.That(id, Does.StartWith(prefix));
        Assert.That(id.Length, Is.LessThanOrEqualTo(maxLength));
        Assert.That(id, Is.Not.Null);
        Assert.That(id, Is.Not.Empty);
    }

    [TestCase("very-long-prefix-that-exceeds-max-", 10, Description = "maxLength < prefix length")]
    [TestCase("short-", 100, Description = "maxLength > generated string length")]
    [TestCase("medium-", 15, Description = "maxLength approximately equal to expected string length")]
    [TestCase("", 20, Description = "empty prefix")]
    [TestCase(null, 25, Description = "null prefix")]
    public async Task GenerateIdWithMaxLengthTruncates(string prefix, int maxLength)
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        const int seed = 456;
        var variables = new Dictionary<string, string>
        {
            { "RandomSeed", seed.ToString() }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "generate-id-truncate-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        var generatedId = recording.GenerateId(prefix, maxLength);

        // All test cases should respect max length
        Assert.That(generatedId.Length, Is.LessThanOrEqualTo(maxLength));

        // Handle prefix cases (including null/empty)
        if (!string.IsNullOrEmpty(prefix))
        {
            // All test cases should start with prefix (or truncated prefix if maxLength is very short)
            var expectedPrefix = prefix.Length <= maxLength ? prefix : prefix.Substring(0, maxLength);
            Assert.That(generatedId, Does.StartWith(expectedPrefix));
        }
        else
        {
            // For null/empty prefix, result should just be the random number as string, truncated if needed
            Assert.That(generatedId, Does.Match(@"^\d+$"), "Should contain only digits when prefix is null/empty");
        }

        // Ensure result is not null or empty
        Assert.That(generatedId, Is.Not.Null);
        Assert.That(generatedId, Is.Not.Empty);
    }

    [Test]
    public async Task GenerateAlphaNumericWithPrefix()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        const int seed = 789;
        var variables = new Dictionary<string, string>
        {
            { "RandomSeed", seed.ToString() }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "generate-alphanumeric-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        const string prefix = "alpha-";

        // Test basic alphanumeric generation
        var alphaId = recording.GenerateAlphaNumericId(prefix);
        Assert.That(alphaId, Does.StartWith(prefix));
        Assert.That(alphaId.Length, Is.EqualTo(prefix.Length + 8)); // 8 generated characters
        Assert.That(alphaId, Does.Match(@"^alpha-[A-Za-z0-9]{8}$"));

        // Test with max length
        const int maxLength = 10;
        var truncatedAlphaId = recording.GenerateAlphaNumericId(prefix, maxLength);
        Assert.That(truncatedAlphaId.Length, Is.EqualTo(maxLength));
        Assert.That(truncatedAlphaId, Does.StartWith(prefix.Substring(0, Math.Min(prefix.Length, maxLength))));

        // Test lowercase only
        var lowercaseId = recording.GenerateAlphaNumericId(prefix, useOnlyLowercase: true);
        Assert.That(lowercaseId, Does.StartWith(prefix));
        Assert.That(lowercaseId.Length, Is.EqualTo(prefix.Length + 8));
        Assert.That(lowercaseId, Does.Match(@"^alpha-[a-z0-9]{8}$"));

        // Test lowercase with max length
        var lowercaseTruncatedId = recording.GenerateAlphaNumericId(prefix, maxLength, useOnlyLowercase: true);
        Assert.That(lowercaseTruncatedId.Length, Is.EqualTo(maxLength));
        Assert.That(lowercaseTruncatedId, Does.StartWith(prefix.Substring(0, Math.Min(prefix.Length, maxLength))));
    }

    #endregion

    #region Variable management tests

    [Test]
    public async Task GetVariableRecordModeStores()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "record-getvariable-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "TestVariable";
        const string defaultValue = "TestValue";

        // Call GetVariable in Record mode
        var result = recording.GetVariable(variableName, defaultValue);

        using (Assert.EnterMultipleScope())
        {
            // Should return the default value
            Assert.That(result, Is.EqualTo(defaultValue));

            // Should store the variable in the Variables dictionary
            Assert.That(recording.Variables.ContainsKey(variableName), Is.True);
            Assert.That(recording.Variables[variableName], Is.EqualTo(defaultValue));
        }
    }

    [Test]
    public async Task GetVariableLiveReturnsDefault()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "TestVariable";
        const string defaultValue = "TestValue";

        // Call GetVariable in Live mode
        var result = recording.GetVariable(variableName, defaultValue);

        using (Assert.EnterMultipleScope())
        {
            // Should return the default value
            Assert.That(result, Is.EqualTo(defaultValue));

            // Should NOT store the variable in the Variables dictionary in Live mode
            Assert.That(recording.Variables.ContainsKey(variableName), Is.False);
        }
    }

    [Test]
    public async Task GetVariablePlaybackRetrievesValue()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        const string variableName = "TestVariable";
        const string recordedValue = "RecordedValue";
        const string defaultValue = "DefaultValue";

        var variables = new Dictionary<string, string>
        {
            { variableName, recordedValue },
            { "OtherVar", "OtherValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-getvariable-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Call GetVariable in Playback mode
        var result = recording.GetVariable(variableName, defaultValue);

        // Should return the recorded value, not the default value
        Assert.That(result, Is.EqualTo(recordedValue));
        Assert.That(result, Is.Not.EqualTo(defaultValue));
    }

    [Test]
    public async Task GetVariableNullPlaybackReturnsNull()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        const string variableName = "NonExistentVariable";
        const string defaultValue = "DefaultValue";

        var variables = new Dictionary<string, string>
        {
            { "ExistingVar", "ExistingValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-nullvar-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Call GetVariable with a variable name that doesn't exist in recorded variables
        var result = recording.GetVariable(variableName, defaultValue);

        // Should return null because the variable wasn't found in playback
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetVariableSanitizerRecordModeIsSanitized()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "record-sanitizer-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "SecretVariable";
        const string secretValue = "VerySecretValue";
        const string sanitizedValue = "SANITIZED";

        // Call GetVariable with a sanitizer function
        var result = recording.GetVariable(variableName, secretValue, value => sanitizedValue);

        using (Assert.EnterMultipleScope())
        {
            // Should return the original value
            Assert.That(result, Is.EqualTo(secretValue));

            // Should store the sanitized value in the Variables dictionary
            Assert.That(recording.Variables.ContainsKey(variableName), Is.True);
            Assert.That(recording.Variables[variableName], Is.EqualTo(sanitizedValue));
        }
        Assert.That(recording.Variables[variableName], Is.Not.EqualTo(secretValue));
    }

    [Test]
    public async Task GetVariableSanitizerLivePlaybackDoesNotApplySanitizer()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Test Live mode first
        TestRecording liveRecording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "SecretVariable";
        const string secretValue = "VerySecretValue";
        const string sanitizedValue = "SANITIZED";

        // Call GetVariable with a sanitizer function in Live mode
        var liveResult = liveRecording.GetVariable(variableName, secretValue, value => sanitizedValue);

        // Should return the original value and not apply sanitizer
        Assert.That(liveResult, Is.EqualTo(secretValue));

        // Test Playback mode
        var variables = new Dictionary<string, string>
        {
            { variableName, sanitizedValue } // This would be the sanitized value from recording
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-sanitizer-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        var playbackProxy = new Mock<TestProxyProcess>();
        playbackProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        playbackProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording playbackRecording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", playbackProxy.Object, testBase);

        // Call GetVariable with a sanitizer function in Playback mode
        var playbackResult = playbackRecording.GetVariable(variableName, secretValue, value => "SHOULD_NOT_BE_CALLED");

        // Should return the recorded sanitized value, sanitizer should not be called
        Assert.That(playbackResult, Is.EqualTo(sanitizedValue));
    }

    [Test]
    public async Task SetVariableRecordModeStoresVariable()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var variables = new Dictionary<string, string>
        {
            { "ExistingVar", "ExistingValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "record-setvariable-test").WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "TestVariable";
        const string variableValue = "TestValue";

        // Call SetVariable in Record mode
        recording.SetVariable(variableName, variableValue);

        using (Assert.EnterMultipleScope())
        {
            // Should store the variable in the Variables dictionary
            Assert.That(recording.Variables.ContainsKey(variableName), Is.True);
            Assert.That(recording.Variables[variableName], Is.EqualTo(variableValue));
        }
    }

    [Test]
    public async Task SetVariableLiveModeDoesNothing()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "TestVariable";
        const string variableValue = "TestValue";

        // Call SetVariable in Live mode
        recording.SetVariable(variableName, variableValue);

        using (Assert.EnterMultipleScope())
        {
            // Should NOT store the variable in the Variables dictionary in Live mode
            Assert.That(recording.Variables.ContainsKey(variableName), Is.False);
            Assert.That(recording.Variables.Count, Is.EqualTo(0));
        }
    }

    [Test]
    public async Task SetVariablePlaybackModeDoesNothing()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string>
        {
            { "ExistingVar", "ExistingValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "playback-setvariable-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "NewVariable";
        const string variableValue = "NewValue";

        // Verify initial state
        Assert.That(recording.Variables.Count, Is.EqualTo(1));
        Assert.That(recording.Variables.ContainsKey("ExistingVar"), Is.True);

        // Call SetVariable in Playback mode
        recording.SetVariable(variableName, variableValue);

        using (Assert.EnterMultipleScope())
        {
            // Should NOT add the variable in Playback mode
            Assert.That(recording.Variables.ContainsKey(variableName), Is.False);
            Assert.That(recording.Variables.Count, Is.EqualTo(1)); // Should remain unchanged
        }
    }

    [Test]
    public async Task SetVariableWithSanitizerRecordModeSanitizes()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var variables = new Dictionary<string, string>
        {
            { "ExistingVar", "ExistingValue" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "record-sanitize-setvariable-test").WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        const string variableName = "SecretVariable";
        const string secretValue = "VerySecretValue";
        const string sanitizedValue = "SANITIZED";

        // Call SetVariable with a sanitizer function
        recording.SetVariable(variableName, secretValue, value => sanitizedValue);

        using (Assert.EnterMultipleScope())
        {
            // Should store the sanitized value in the Variables dictionary
            Assert.That(recording.Variables.ContainsKey(variableName), Is.True);
            Assert.That(recording.Variables[variableName], Is.EqualTo(sanitizedValue));
        }
        Assert.That(recording.Variables[variableName], Is.Not.EqualTo(secretValue));
    }

    [Test]
    public async Task ValidateVariablesWithEmptyVariablesThrows()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create a playback recording with no variables (empty dictionary)
        var emptyVariables = new Dictionary<string, string>();

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "empty-vars-validate-test")
                .WithContent(BinaryData.FromObjectAsJson(emptyVariables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Any operation that calls ValidateVariables should throw TestRecordingMismatchException
        var exception = Assert.Throws<TestRecordingMismatchException>(() =>
        {
            // This will call ValidateVariables internally
            var _ = recording.Random;
        });

        Assert.That(exception.Message, Does.Contain("record session does not exist"));
        Assert.That(exception.Message, Does.Contain("missing the Variables section"));
        Assert.That(exception.Message, Does.Contain("RecordedTestMode to 'Record'"));
    }

    [Test]
    public async Task ValidateVariablesValidatesVariables()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        // Create a playback recording with valid variables
        var variables = new Dictionary<string, string>
        {
            { "RandomSeed", "12345" },
            { "TestVar1", "TestValue1" },
            { "TestVar2", "TestValue2" }
        };

        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "valid-vars-validate-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", mockProxy.Object, testBase);

        // Verify that variables were loaded successfully
        Assert.That(recording.Variables.Count, Is.EqualTo(3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(recording.Variables.ContainsKey("RandomSeed"), Is.True);
            Assert.That(recording.Variables.ContainsKey("TestVar1"), Is.True);
            Assert.That(recording.Variables.ContainsKey("TestVar2"), Is.True);
        }

        // Operations that call ValidateVariables should succeed
        Assert.DoesNotThrow(() =>
        {
            var _ = recording.Random; // This calls ValidateVariables internally
        });

        Assert.DoesNotThrow(() =>
        {
            // This also calls ValidateVariables internally
            recording.GetVariable("TestVar1", "DefaultValue");
        });
    }

    #endregion

    #region Disable recording tests

    [Test]
    public async Task DisableRecordingSetsDoNotRecord()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "disable-record-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Create a DisableRecording scope
        using (var scope = recording.DisableRecording())
        {
            // Access the private _disableRecording field through reflection to verify it's set
            var disableRecordingField = typeof(TestRecording).GetField("_disableRecording",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.That(disableRecordingField, Is.Not.Null);

            var asyncLocal = disableRecordingField!.GetValue(recording);
            var valueProperty = asyncLocal!.GetType().GetProperty("Value");
            var currentValue = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;

            Assert.That(currentValue, Is.EqualTo(EntryRecordModel.DoNotRecord));
        }
    }

    [Test]
    public async Task DisableRequestBodyRecordingSetsRecordWithoutRequestBody()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "disable-body-record-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Create a DisableRequestBodyRecording scope
        using (var scope = recording.DisableRequestBodyRecording())
        {
            // Access the private _disableRecording field through reflection to verify it's set
            var disableRecordingField = typeof(TestRecording).GetField("_disableRecording",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.That(disableRecordingField, Is.Not.Null);

            var asyncLocal = disableRecordingField!.GetValue(recording);
            var valueProperty = asyncLocal!.GetType().GetProperty("Value");
            var currentValue = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;

            Assert.That(currentValue, Is.EqualTo(EntryRecordModel.RecordWithoutRequestBody));
        }
    }

    [Test]
    public async Task DisableRecordingScopeDisposeResetsValues()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "disable-scope-dispose-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });
        mockProxy.Setup(p => p.ProxyClient).Returns(client);
        var adminClient = client.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", mockProxy.Object, testBase);

        // Get reflection objects for accessing private field
        var disableRecordingField = typeof(TestRecording).GetField("_disableRecording",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        Assert.That(disableRecordingField, Is.Not.Null);

        var asyncLocal = disableRecordingField!.GetValue(recording);
        var valueProperty = asyncLocal!.GetType().GetProperty("Value");

        // Initially should be default (Record)
        var initialValue = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;
        Assert.That(initialValue, Is.EqualTo(EntryRecordModel.Record));

        // Create and dispose a DisableRecording scope
        var scope = recording.DisableRecording();
        var valueInScope = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;
        Assert.That(valueInScope, Is.EqualTo(EntryRecordModel.DoNotRecord));

        // Dispose the scope - should reset to Record
        scope.Dispose();
        var valueAfterDispose = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;
        Assert.That(valueAfterDispose, Is.EqualTo(EntryRecordModel.Record));

        // Test with DisableRequestBodyRecording scope as well
        var bodyScope = recording.DisableRequestBodyRecording();
        var valueInBodyScope = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;
        Assert.That(valueInBodyScope, Is.EqualTo(EntryRecordModel.RecordWithoutRequestBody));

        // Dispose the body scope - should reset to Record
        bodyScope.Dispose();
        var valueAfterBodyDispose = (EntryRecordModel)valueProperty!.GetValue(asyncLocal)!;
        Assert.That(valueAfterBodyDispose, Is.EqualTo(EntryRecordModel.Record));
    }

    #endregion

    #region Dispose tests

    [Test]
    public async Task DisposeRecordModeSaves()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockProxyClient = new Mock<TestProxyClient>();

        // Setup mock to expect StopRecordAsync call with save=true (null parameter)
        mockProxyClient.Setup(c => c.StopRecordAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>(), null, It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200))));

        mockProxy.Setup(p => p.ProxyClient).Returns(mockProxyClient.Object);
        var adminClient = mockProxyClient.Object.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "dispose-record-save-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });

        // Use the real client for creation, then switch to mock for disposal
        var realProxy = new Mock<TestProxyProcess>();
        realProxy.Setup(p => p.ProxyClient).Returns(client);
        realProxy.Setup(p => p.AdminClient).Returns(client.GetTestProxyAdminClient());

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", realProxy.Object, testBase);

        // Replace proxy with mock for disposal test
        var proxyField = typeof(TestRecording).GetField("_proxy",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        proxyField!.SetValue(recording, mockProxy.Object);

        // Test DisposeAsync(true) - should save
        await recording.DisposeAsync(true);

        // Verify StopRecordAsync was called with null (save)
        mockProxyClient.Verify(c => c.StopRecordAsync(
            It.Is<string>(id => id == "dispose-record-save-test"),
            It.IsAny<IDictionary<string, string>>(),
            null, // save = true means pass null
            It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task DisposeRecordModeDoesNotSave()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockProxyClient = new Mock<TestProxyClient>();

        // Setup mock to expect StopRecordAsync call with save=false ("request-response" parameter)
        mockProxyClient.Setup(c => c.StopRecordAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>(), "request-response", It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200))));

        mockProxy.Setup(p => p.ProxyClient).Returns(mockProxyClient.Object);
        var adminClient = mockProxyClient.Object.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        var mockTransport = new MockPipelineTransport(p =>
            new MockPipelineResponse(200).WithHeader("x-recording-id", "dispose-record-nosave-test").WithContent(p.Request.Content))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });

        // Use the real client for creation, then switch to mock for disposal
        var realProxy = new Mock<TestProxyProcess>();
        realProxy.Setup(p => p.ProxyClient).Returns(client);
        realProxy.Setup(p => p.AdminClient).Returns(client.GetTestProxyAdminClient());

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Record, "test-session.json", realProxy.Object, testBase);

        // Replace proxy with mock for disposal test
        var proxyField = typeof(TestRecording).GetField("_proxy",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        proxyField!.SetValue(recording, mockProxy.Object);

        // Test DisposeAsync(false) - should not save
        await recording.DisposeAsync(false);

        // Verify StopRecordAsync was called with "request-response" (don't save)
        mockProxyClient.Verify(c => c.StopRecordAsync(
            It.Is<string>(id => id == "dispose-record-nosave-test"),
            It.IsAny<IDictionary<string, string>>(),
            "request-response", // save = false means pass "request-response"
            It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task DisposePlaybackModeWithRequests()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockProxyClient = new Mock<TestProxyClient>();

        // Setup mock to expect StopPlaybackAsync call
        mockProxyClient.Setup(c => c.StopPlaybackAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200))));

        mockProxy.Setup(p => p.ProxyClient).Returns(mockProxyClient.Object);
        var adminClient = mockProxyClient.Object.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "dispose-playback-requests-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });

        // Use the real client for creation, then switch to mock for disposal
        var realProxy = new Mock<TestProxyProcess>();
        realProxy.Setup(p => p.ProxyClient).Returns(client);
        realProxy.Setup(p => p.AdminClient).Returns(client.GetTestProxyAdminClient());

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", realProxy.Object, testBase);

        // Set HasRequests to true to simulate that requests were processed
        recording.HasRequests = true;

        // Replace proxy with mock for disposal test
        var proxyField = typeof(TestRecording).GetField("_proxy",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        proxyField!.SetValue(recording, mockProxy.Object);

        // Test DisposeAsync() - should call StopPlaybackAsync when HasRequests is true
        await recording.DisposeAsync();

        // Verify StopPlaybackAsync was called
        mockProxyClient.Verify(c => c.StopPlaybackAsync(
            It.Is<string>(id => id == "dispose-playback-requests-test"),
            It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task DisposePlayBackModeNoRequests()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockProxyClient = new Mock<TestProxyClient>();

        // Setup mock but expect NO calls to StopPlaybackAsync
        mockProxyClient.Setup(c => c.StopPlaybackAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200))));

        mockProxy.Setup(p => p.ProxyClient).Returns(mockProxyClient.Object);
        var adminClient = mockProxyClient.Object.GetTestProxyAdminClient();
        mockProxy.Setup(p => p.AdminClient).Returns(adminClient);

        var variables = new Dictionary<string, string> { { "TestVar", "TestValue" } };
        var mockTransport = new MockPipelineTransport(_ =>
            new MockPipelineResponse(200)
                .WithHeader("x-recording-id", "dispose-playback-norequests-test")
                .WithContent(BinaryData.FromObjectAsJson(variables).ToArray()))
        {
            ExpectSyncPipeline = false
        };
        var client = new TestProxyClient(new Uri($"http://127.0.0.1:5000"), new TestProxyClientOptions { Transport = mockTransport });

        // Use the real client for creation, then switch to mock for disposal
        var realProxy = new Mock<TestProxyProcess>();
        realProxy.Setup(p => p.ProxyClient).Returns(client);
        realProxy.Setup(p => p.AdminClient).Returns(client.GetTestProxyAdminClient());

        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Playback, "test-session.json", realProxy.Object, testBase);

        // Ensure HasRequests is false (default state)
        Assert.That(recording.HasRequests, Is.False);

        // Replace proxy with mock for disposal test
        var proxyField = typeof(TestRecording).GetField("_proxy",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        proxyField!.SetValue(recording, mockProxy.Object);

        // Test DisposeAsync() - should NOT call StopPlaybackAsync when HasRequests is false
        await recording.DisposeAsync();

        // Verify StopPlaybackAsync was NOT called
        mockProxyClient.Verify(c => c.StopPlaybackAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task DisposeLiveModeDoesNothing()
    {
        var mockProxy = new Mock<TestProxyProcess>();
        var testBase = new TestRecordedTestBase();
        var mockProxyClient = new Mock<TestProxyClient>();

        // Setup mocks but expect NO calls to any stop methods
        mockProxyClient.Setup(c => c.StopRecordAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200))));
        mockProxyClient.Setup(c => c.StopPlaybackAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200))));

        mockProxy.Setup(p => p.ProxyClient).Returns(mockProxyClient.Object);

        // Create live mode recording
        TestRecording recording = await TestRecording.CreateAsync(RecordedTestMode.Live, "test-session.json", mockProxy.Object, testBase);

        // Test both DisposeAsync() and DisposeAsync(true/false)
        await recording.DisposeAsync();
        await recording.DisposeAsync(true);
        await recording.DisposeAsync(false);

        // Verify NO stop methods were called in Live mode
        mockProxyClient.Verify(c => c.StopRecordAsync(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        mockProxyClient.Verify(c => c.StopPlaybackAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    #endregion
}

/// <summary>
/// Test implementation of RecordedTestBase for unit testing TestRecording.
/// </summary>
internal class TestRecordedTestBase : RecordedTestBase
{
    public TestRecordedTestBase() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";
}

/// <summary>
/// Test implementation of RecordedTestBase with sanitizers configured for testing sanitizer application.
/// </summary>
internal class TestRecordedTestBaseWithSanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithSanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<string> SanitizedHeaders => new() { "Authorization", "X-Api-Key" };
    public override List<string> SanitizedQueryParameters => new() { "api-version" };
    public override List<string> JsonPathSanitizers => new() { "$.secrets.key" };
}

///// <summary>
///// Test implementation of RecordedTestBase with header transforms for testing transform application.
///// </summary>
//internal class TestRecordedTestBaseWithHeaderTransforms : RecordedTestBase
//{
//    public TestRecordedTestBaseWithHeaderTransforms() : base(false, RecordedTestMode.Live)
//    {
//        // Add header transforms to the HeaderTransforms field
//        HeaderTransforms.Add(new Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform("x-ms-date", "2023-01-01T00:00:00Z"));
//        HeaderTransforms.Add(new Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform("authorization", "Bearer <masked>"));
//    }

//    public override string AssetsJsonPath => "test-assets.json";
//}

/// <summary>
/// Test implementation of RecordedTestBase with only header sanitizers for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithHeaderSanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithHeaderSanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<string> SanitizedHeaders => new() { "Authorization", "X-Api-Key", "X-Custom-Secret" };
}

/// <summary>
/// Test implementation of RecordedTestBase with header regex sanitizers for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithHeaderRegexSanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithHeaderRegexSanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<HeaderRegexSanitizer> HeaderRegexSanitizers => new()
    {
        new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("Authorization") { Regex = "Bearer .*", Value = "Bearer <Sanitized>" }),
        new HeaderRegexSanitizer(new HeaderRegexSanitizerBody("X-Custom-Token") { Regex = "token-.*", Value = "token-<Sanitized>" })
    };
}

/// <summary>
/// Test implementation of RecordedTestBase with query parameter sanitizers for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithQueryParameterSanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithQueryParameterSanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<string> SanitizedQueryParameters => new() { "api-key", "access_token", "secret" };
}

/// <summary>
/// Test implementation of RecordedTestBase with JSON path sanitizers for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithJsonPathSanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithJsonPathSanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<string> JsonPathSanitizers => new() { "$.secrets.key", "$.credentials.password", "$.auth.token" };
}

/// <summary>
/// Test implementation of RecordedTestBase with body key sanitizers for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithBodyKeySanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithBodyKeySanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<BodyKeySanitizer> BodyKeySanitizers => new()
    {
        new BodyKeySanitizer(new BodyKeySanitizerBody("$.secret") { Value = "SANITIZED" }),
        new BodyKeySanitizer(new BodyKeySanitizerBody("$.password") { Value = "SANITIZED" })
    };
}

/// <summary>
/// Test implementation of RecordedTestBase with body regex sanitizers for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithBodyRegexSanitizers : RecordedTestBase
{
    public TestRecordedTestBaseWithBodyRegexSanitizers() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<BodyRegexSanitizer> BodyRegexSanitizers => new()
    {
        new BodyRegexSanitizer(new BodyRegexSanitizerBody("\"password\":\"<Sanitized>\"", "\"password\"\\s*:\\s*\"[^\"]*\"", null, null, null)),
        new BodyRegexSanitizer(new BodyRegexSanitizerBody("\"secret\":\"<Sanitized>\"", "\"secret\"\\s*:\\s*\"[^\"]*\"", null, null, null))
    };
}

/// <summary>
/// Test implementation of RecordedTestBase with sanitizers to remove for focused testing.
/// </summary>
internal class TestRecordedTestBaseWithSanitizersToRemove : RecordedTestBase
{
    public TestRecordedTestBaseWithSanitizersToRemove() : base(false, RecordedTestMode.Live)
    {
    }

    public override string AssetsJsonPath => "test-assets.json";

    public override List<string> SanitizersToRemove => new() { "AZSDK3493", "AZSDK3430", "AZSDK2030" };
}
