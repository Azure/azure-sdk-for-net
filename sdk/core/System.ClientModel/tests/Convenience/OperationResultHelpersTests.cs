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
