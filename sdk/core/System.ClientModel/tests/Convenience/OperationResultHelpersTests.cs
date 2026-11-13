// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests;

public class OperationResultHelpersTests
{
    [Test]
    public void ReturnsImmediatelyWithoutPolling()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            MockPipelineResponse response = new(202);
            response.SetHeader("Operation-Location", "/operations/1");
            return response.SetContent("""{"status":"running"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        Assert.IsFalse(operation.HasCompleted);
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task ProcessMessageAsyncWaitsUntilCompleted()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                response.SetHeader("Retry-After", "0");
                return response.SetContent("""{"status":"running"}""");
            }

            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        OperationResult operation = await OperationResultHelpers.ProcessMessageAsync(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: true);

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task PollsOperationLocationUntilTerminalStatus()
    {
        int requestCount = 0;
        Uri? pollingUri = null;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response.SetContent("""{"status":"running"}""");
            }

            pollingUri = message.Request.Uri;
            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        Assert.IsFalse(operation.HasCompleted);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(new Uri("https://example.com/operations/1"), pollingUri);
    }

    [Test]
    public async Task PollsAzureAsyncOperationWhenOperationLocationIsMissing()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Azure-AsyncOperation", "/status/1");
                return response;
            }

            Assert.AreEqual(new Uri("https://example.com/status/1"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.AzureAsyncOperation,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task PollsLocationWhenOtherPollingHeadersAreMissing()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Location", "/operations/1");
                return response;
            }

            Assert.AreEqual(new Uri("https://example.com/operations/1"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"id":"job-1"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.Location,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual("""{"id":"job-1"}""", operation.GetRawResponse().Content.ToString());
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task OperationLocationTakesPrecedenceOverOtherPollingHeaders()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operation-location/1");
                response.SetHeader("Azure-AsyncOperation", "/azure-async-operation/1");
                response.SetHeader("Location", "/location/1");
                return response;
            }

            Assert.AreEqual(new Uri("https://example.com/operation-location/1"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public void CompletesWhenNoPollingLocationIsReturned()
    {
        MockPipelineTransport transport = new(
            "Transport",
            _ => new MockPipelineResponse(200).SetContent("""{"id":"job"}"""));
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        Assert.IsTrue(operation.HasCompleted);
    }

    [Test]
    public async Task PollsAfterEmptyInitialResponse()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response;
            }

            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        Assert.IsFalse(operation.HasCompleted);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task PreservesApiVersionOnPollingUri()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response;
            }

            Assert.AreEqual(
                new Uri("https://example.com/operations/1?api-version=2026-01-01"),
                message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(
            new Uri("https://example.com/jobs?api-version=2026-01-01"),
            "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task GetsFinalResponseFromOriginalUri()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response.SetContent("""{"status":"running"}""");
            }

            if (requestCount == 2)
            {
                return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
            }

            Assert.AreEqual(new Uri("https://example.com/jobs/1"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"id":"job-1"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs/1"), "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OriginalUri,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual("""{"id":"job-1"}""", operation.GetRawResponse().Content.ToString());
        Assert.AreEqual(3, requestCount);
    }

    [Test]
    public async Task GetsFinalResponseFromResourceLocation()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response;
            }

            if (requestCount == 2)
            {
                return new MockPipelineResponse(200).SetContent(
                    """{"status":"succeeded","resourceLocation":"/jobs/1"}""");
            }

            Assert.AreEqual(new Uri("https://example.com/jobs/1"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"id":"job-1"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.Location,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual("""{"id":"job-1"}""", operation.GetRawResponse().Content.ToString());
        Assert.AreEqual(3, requestCount);
    }

    [Test]
    public async Task LocationOverrideUsesLatestLocationHeader()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                response.SetHeader("Location", "/jobs/initial");
                return response;
            }

            if (requestCount == 2)
            {
                MockPipelineResponse response = new(200);
                response.SetHeader("Location", "/jobs/final");
                return response.SetContent("""{"status":"succeeded"}""");
            }

            Assert.AreEqual(new Uri("https://example.com/jobs/final"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"id":"job-final"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.LocationOverride,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual("""{"id":"job-final"}""", operation.GetRawResponse().Content.ToString());
        Assert.AreEqual(3, requestCount);
    }

    [Test]
    public void PutGetsFinalResponseFromOriginalUri()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                response.SetHeader("Retry-After", "0");
                return response;
            }

            if (requestCount == 2)
            {
                return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
            }

            Assert.AreEqual(new Uri("https://example.com/jobs/1"), message.Request.Uri);
            return new MockPipelineResponse(200).SetContent("""{"id":"job-1"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs/1"), "PUT");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.Location,
            waitUntilCompleted: true);

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual("""{"id":"job-1"}""", operation.GetRawResponse().Content.ToString());
        Assert.AreEqual(3, requestCount);
    }

    [TestCase("failed")]
    [TestCase("canceled")]
    [TestCase("cancelled")]
    public async Task TerminalFailureStatusCompletesOperation(string status)
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response;
            }

            return new MockPipelineResponse(200).SetContent($$"""{"status":"{{status}}"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual($$"""{"status":"{{status}}"}""", operation.GetRawResponse().Content.ToString());
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task UpdatingCompletedOperationDoesNotSendAnotherRequest()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            return new MockPipelineResponse(200).SetContent("""{"id":"job-1"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs/1"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        ClientResult result = await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreSame(operation.GetRawResponse(), result.GetRawResponse());
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public void WaitUntilCompletedPreservesErrorOptions()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                response.SetHeader("Retry-After", "0");
                return response.SetContent("""{"status":"running"}""");
            }

            return new MockPipelineResponse(400);
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        RequestOptions options = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow,
        };
        message.Apply(options);

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: true);

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public void InitialServerErrorThrows()
    {
        MockPipelineTransport transport = new(
            "Transport",
            _ => new MockPipelineResponse(500).SetContent("""{"error":"failed"}"""));
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        ClientResultException exception = Assert.Throws<ClientResultException>(() =>
            OperationResultHelpers.ProcessMessage(
                pipeline,
                message,
                options: null,
                OperationFinalStateVia.OperationLocation,
                waitUntilCompleted: false))!;

        Assert.AreEqual(500, exception.Status);
    }

    [Test]
    public void PollingServerErrorThrows()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response;
            }

            return new MockPipelineResponse(500).SetContent("""{"error":"failed"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");
        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        ClientResultException exception = Assert.Throws<ClientResultException>(() => operation.UpdateStatus())!;

        Assert.AreEqual(500, exception.Status);
        Assert.Greater(requestCount, 1);
    }

    [Test]
    public async Task WaitUsesSuppliedCancellationTokenForPollingRequest()
    {
        using CancellationTokenSource cancellationSource = new();
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", message =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                response.SetHeader("Retry-After", "0");
                return response;
            }

            Assert.IsTrue(message.CancellationToken.CanBeCanceled);
            return new MockPipelineResponse(200).SetContent("""{"status":"succeeded"}""");
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs"), "POST");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        await operation.WaitForCompletionAsync(cancellationSource.Token);

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task DeleteCompletesWhenPollingReturnsNotFound()
    {
        int requestCount = 0;
        MockPipelineTransport transport = new("Transport", _ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                MockPipelineResponse response = new(202);
                response.SetHeader("Operation-Location", "/operations/1");
                return response;
            }

            return new MockPipelineResponse(404);
        });
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com/jobs/1"), "DELETE");

        OperationResult operation = OperationResultHelpers.ProcessMessage(
            pipeline,
            message,
            options: null,
            OperationFinalStateVia.OperationLocation,
            waitUntilCompleted: false);

        await operation.UpdateStatusAsync();

        Assert.IsTrue(operation.HasCompleted);
        Assert.AreEqual(404, operation.GetRawResponse().Status);
        Assert.AreEqual(2, requestCount);
    }
}
