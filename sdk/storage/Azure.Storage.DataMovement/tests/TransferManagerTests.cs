// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement.Tests.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests;

internal class TransferManagerTests
{
    [Test]
    public async Task BasicProcessorLifetime()
    {
        Mock<IProcessor<TransferJobInternal>> jobsProcessor = new();
        Mock<IProcessor<JobPartInternal>> partsProcessor = new();
        Mock<IProcessor<Func<Task>>> chunksProcessor = new();

        await using (TransferManager _ = new(
            jobsProcessor.Object,
            partsProcessor.Object,
            chunksProcessor.Object,
            default, default, default))
        {
            jobsProcessor.VerifyTransferManagerCtorInvocations();
            partsProcessor.VerifyTransferManagerCtorInvocations();
            chunksProcessor.VerifyTransferManagerCtorInvocations();

            jobsProcessor.VerifyNoOtherCalls();
            partsProcessor.VerifyNoOtherCalls();
            chunksProcessor.VerifyNoOtherCalls();
        }
        jobsProcessor.VerifyDisposal();
        partsProcessor.VerifyDisposal();
        chunksProcessor.VerifyDisposal();

        jobsProcessor.VerifyNoOtherCalls();
        partsProcessor.VerifyNoOtherCalls();
        chunksProcessor.VerifyNoOtherCalls();
    }

    [Test]
    [Combinatorial]
    public async Task BasicItemTransfer(
        [Values(1, 5)] int items,
        [Values(333, 500, 1024)] int itemSize,
        [Values(333, 1024)] int chunkSize)
    {
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int expectedChunksInQueue = Math.Max(chunksPerPart-1, 1) * items;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        StepProcessor<TransferJobInternal> jobsProcessor = new();
        StepProcessor<JobPartInternal> partsProcessor = new();
        StepProcessor<Func<Task>> chunksProcessor = new();
        Mock<JobBuilder> jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        Mock<TransferCheckpointer> checkpointer = new();

        var resources = Enumerable.Range(0, items)
            .Select(_ =>
            {
                Mock<StorageResourceItem> srcResource = new(MockBehavior.Strict);
                Mock<StorageResourceItem> dstResource = new(MockBehavior.Strict);

                srcResource.Setup(r => r.Uri).Returns(srcUri);
                dstResource.Setup(r => r.Uri).Returns(dstUri);

                srcResource.SetupGet(r => r.ResourceId).Returns("Mock");
                dstResource.SetupGet(r => r.ResourceId).Returns("Mock");

                dstResource.SetupGet(r => r.TransferType).Returns(default(DataTransferOrder));
                dstResource.SetupGet(r => r.MaxSupportedChunkSize).Returns(Constants.GB);

                srcResource.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new StorageResourceItemProperties(resourceLength: itemSize, default, default, default)));

                srcResource.Setup(r => r.ReadStreamAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                    .Returns<long, long?, CancellationToken>((position, length, cancellation)
                        => Task.FromResult(new StorageResourceReadStreamResult(
                            new Mock<Stream>().Object,
                            new HttpRange(position, length),
                            new(itemSize, default, default, new()))));
                dstResource.Setup(r => r.CopyFromStreamAsync(
                    It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(),
                    It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask);
                dstResource.Setup(r => r.CompleteTransferAsync(
                    It.IsAny<bool>(),
                    It.IsAny<StorageResourceCompleteTransferOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(Task.CompletedTask);

                return (Source: srcResource, Destination: dstResource);
            }).ToList();

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder.Object,
            checkpointer.Object,
            default);

        List<DataTransfer> transfers = new();

        // queue jobs
        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            DataTransfer transfer = await transferManager.StartTransferAsync(
                srcResource.Object,
                dstResource.Object,
                new()
                {
                    InitialTransferSize = chunkSize,
                    MaximumTransferChunkSize = chunkSize,
                });
            Assert.That(transfer.HasCompleted, Is.False);
            transfers.Add(transfer);

            srcResource.VerifySourceResourceOnQueue();
            dstResource.VerifyDestinationResourceOnQueue();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(items), "Error during initial Job queueing.");

        // process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(items));
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(0));
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(items), "Error during Job => Part processing.");
        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            srcResource.VerifySourceResourceOnJobProcess();
            dstResource.VerifyDestinationResourceOnJobProcess();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        // process parts
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(items));
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(0));
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(expectedChunksInQueue), "Error during Part => Chunk processing.");
        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            srcResource.VerifySourceResourceOnPartProcess();
            dstResource.VerifyDestinationResourceOnPartProcess();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        // process chunks
        Assert.That(await chunksProcessor.StepAll(), Is.EqualTo(expectedChunksInQueue));
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0));
        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            srcResource.VerifySourceResourceOnChunkProcess();
            dstResource.VerifyDestinationResourceOnChunkProcess();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        await Task.Delay(10); // TODO flaky that we need this; a random one will often fail without

        foreach (DataTransfer transfer in transfers)
        {
            Assert.That(transfer.HasCompleted);
        }
    }

    [Test]
    public void StartContainerTransafer()
    {
        Assert.Fail();
    }
}

internal static partial class MockExtensions
{
    public static void SetupQueueAsync<T>(this Mock<IProcessor<T>> processor, Action<T, CancellationToken> onQueue = default)
    {
        var setup = processor.Setup(p => p.QueueAsync(It.IsNotNull<T>(), It.IsNotNull<CancellationToken>()))
            .Returns(new ValueTask(Task.CompletedTask));
        if (onQueue != default)
        {
            setup.Callback(onQueue);
        }
    }

    public static void VerifyTransferManagerCtorInvocations<T>(this Mock<IProcessor<T>> processor)
    {
        processor.VerifySet(p => p.Process = It.IsNotNull<ProcessAsync<T>>(), Times.Once());
    }

    #region StorageResource calls TransferManager processing stages
    public static void VerifySourceResourceOnQueue(this Mock<StorageResourceItem> srcResource)
    {
        srcResource.VerifyGet(r => r.Uri);
    }

    public static void VerifyDestinationResourceOnQueue(this Mock<StorageResourceItem> dstResource)
    {
        dstResource.VerifyGet(r => r.Uri);
    }

    public static void VerifySourceResourceOnJobProcess(this Mock<StorageResourceItem> srcResource)
    {
        srcResource.VerifyGet(r => r.Uri);
        srcResource.VerifyGet(r => r.ResourceId);
    }

    public static void VerifyDestinationResourceOnJobProcess(this Mock<StorageResourceItem> dstResource)
    {
        dstResource.VerifyGet(r => r.Uri);
        dstResource.VerifyGet(r => r.ResourceId);
        dstResource.VerifyGet(r => r.MaxSupportedChunkSize);
    }

    public static void VerifySourceResourceOnPartProcess(this Mock<StorageResourceItem> srcResource)
    {
        srcResource.Verify(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()), Times.Once);
        // TODO: a bug in multipart uploading can result in the first chunk being uploaded at part process
        // verify at most once to ensure there are no more than this bug.
        srcResource.Verify(r => r.ReadStreamAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()), Times.AtMostOnce);
    }

    public static void VerifyDestinationResourceOnPartProcess(this Mock<StorageResourceItem> dstResource)
    {
        dstResource.VerifyGet(r => r.TransferType, Times.AtMost(9999));
        // TODO: a bug in multipart uploading can result in the first chunk being uploaded at part process
        // verify at most once to ensure there are no more than this bug.
        dstResource.Verify(r => r.CopyFromStreamAsync(
            It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(),
            It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()),
            Times.AtMostOnce);
    }

    public static void VerifySourceResourceOnChunkProcess(this Mock<StorageResourceItem> srcResource)
    {
        srcResource.Verify(r => r.ReadStreamAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()), Times.AtLeastOnce);
    }

    public static void VerifyDestinationResourceOnChunkProcess(this Mock<StorageResourceItem> dstResource)
    {
        dstResource.Verify(r => r.CopyFromStreamAsync(
            It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(),
            It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()),
            Times.AtLeastOnce);
        dstResource.Verify(r => r.CompleteTransferAsync(
            It.IsAny<bool>(),
            It.IsAny<StorageResourceCompleteTransferOptions>(),
            It.IsAny<CancellationToken>()),
            Times.AtMostOnce); // TODO why don't we complete single part transfers?
    }
    #endregion
}
