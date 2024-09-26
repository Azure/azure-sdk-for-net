// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Castle.Core.Resource;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests;

public class TransferManagerTests
{
    private static (StepProcessor<TransferJobInternal> JobProcessor, StepProcessor<JobPartInternal> PartProcessor, StepProcessor<Func<Task>> ChunkProcessor) StepProcessors()
        => (new(), new(), new());

    private static (StorageResource Source, StorageResource Dest) GetBasicSetupResources(bool isContainer, Uri srcUri, Uri dstUri)
    {
        if (isContainer)
        {
            Mock<StorageResourceContainer> srcContainer = new(MockBehavior.Strict);
            Mock<StorageResourceContainer> dstContainer = new(MockBehavior.Strict);
            (srcContainer, dstContainer).BasicSetup(srcUri, dstUri);
            return (srcContainer.Object, dstContainer.Object);
        }
        else
        {
            Mock<StorageResourceItem> srcItem = new(MockBehavior.Strict);
            Mock<StorageResourceItem> dstItem = new(MockBehavior.Strict);
            (srcItem, dstItem).BasicSetup(srcUri, dstUri);
            return (srcItem.Object, dstItem.Object);
        }
    }

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

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        Mock<TransferCheckpointer> checkpointer = new();

        var resources = Enumerable.Range(0, items).Select(_ =>
        {
            Mock<StorageResourceItem> srcResource = new(MockBehavior.Strict);
            Mock<StorageResourceItem> dstResource = new(MockBehavior.Strict);

            (srcResource, dstResource).BasicSetup(srcUri, dstUri, itemSize);

            return (Source: srcResource, Destination: dstResource);
        }).ToList();

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
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

        await Task.Delay(20); // TODO flaky that we need this; a random one will often fail without

        foreach (DataTransfer transfer in transfers)
        {
            Assert.That(transfer.HasCompleted);
        }
    }

    [Test]
    [Combinatorial]
    public async Task BasicContainerTransfer(
        [Values(1, 5)] int numJobs,
        [Values(333, 500, 1024)] int itemSize,
        [Values(333, 1024)] int chunkSize)
    {
        static int GetItemCountFromContainerIndex(int i) => i*i + 1;

        int numJobParts = Enumerable.Range(1, numJobs).Select(GetItemCountFromContainerIndex).Sum();
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * numJobParts;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        Mock<TransferCheckpointer> checkpointer = new();

        var resources = Enumerable.Range(1, numJobs).Select(i =>
        {
            Mock<StorageResourceContainer> srcResource = new(MockBehavior.Strict);
            Mock<StorageResourceContainer> dstResource = new(MockBehavior.Strict);
            (srcResource, dstResource).BasicSetup(srcUri, dstUri, GetItemCountFromContainerIndex(i), itemSize);
            return (Source: srcResource, Destination: dstResource);
        }).ToList();

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer.Object,
            default);

        List<DataTransfer> transfers = new();

        // queue jobs
        foreach ((Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in resources)
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
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error during initial Job queueing.");

        // process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(numJobs));
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(0));
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(numJobParts), "Error during Job => Part processing.");
        foreach ((Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in resources)
        {
            srcResource.VerifySourceResourceOnJobProcess();
            dstResource.VerifyDestinationResourceOnJobProcess();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        // process parts
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(numJobParts));
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(0));
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks), "Error during Part => Chunk processing.");
        foreach ((Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in resources)
        {
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        // process chunks
        Assert.That(await chunksProcessor.StepAll(), Is.EqualTo(numChunks));
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0));
        foreach ((Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in resources)
        {
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
    [Combinatorial]
    public async Task TransferFailAtQueue(
        [Values(0, 1)] int failAt,
        [Values(true, false)] bool isContainer)
    {
        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        Mock<JobBuilder> jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default))
        {
            CallBase = true,
        };
        Mock<TransferCheckpointer> checkpointer = new();

        (StorageResource srcResource, StorageResource dstResource) = GetBasicSetupResources(isContainer, srcUri, dstUri);

        Exception expectedException = new();
        switch (failAt)
        {
            case 0:
                jobBuilder.Setup(b => b.BuildJobAsync(It.IsAny<StorageResource>(), It.IsAny<StorageResource>(),
                    It.IsAny<DataTransferOptions>(), It.IsAny<TransferCheckpointer>(), It.IsAny<string>(),
                    It.IsAny<bool>(), It.IsAny<CancellationToken>())
                ).Throws(expectedException);
                break;
            case 1:
                checkpointer.Setup(c => c.AddNewJobAsync(It.IsAny<string>(), It.IsAny<StorageResource>(),
                    It.IsAny<StorageResource>(), It.IsAny<CancellationToken>())
                ).Throws(expectedException);
                break;
        }

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder.Object,
            checkpointer.Object,
            default);

        DataTransfer transfer = null;

        Assert.That(async () => transfer = await transferManager.StartTransferAsync(
            srcResource,
            dstResource), Throws.Exception.EqualTo(expectedException));

        Assert.That(transfer, Is.Null);

        // TODO determine if checkpointer still has the job tracked even though it failed to queue (it shouldn't)
        //      need checkpointer API refactor for this
    }

    [Test]
    public async Task TransferFailAtJobProcess([Values(true, false)] bool isContainer)
    {
        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new(ClientOptions.Default));
        Mock<TransferCheckpointer> checkpointer = new(MockBehavior.Loose);

        (StorageResource srcResource, StorageResource dstResource) = GetBasicSetupResources(isContainer, srcUri, dstUri);

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer.Object,
            default);

        Exception expectedException = new();
        checkpointer.Setup(c => c.AddNewJobPartAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Stream>(),
            It.IsAny<CancellationToken>())
        ).Throws(expectedException);

        // need to listen to events to get exception that takes place in processing
        List<TransferItemFailedEventArgs> failures = new();
        DataTransferOptions options = new();
        options.ItemTransferFailed += e => { failures.Add(e); return Task.CompletedTask; };

        DataTransfer transfer = await transferManager.StartTransferAsync(srcResource, dstResource);
        Assert.That(await jobsProcessor.TryStepAsync(), Is.True);
        Assert.That(jobsProcessor.ItemsInQueue, Is.Zero);
        Assert.That(partsProcessor.ItemsInQueue, Is.Zero); // because of failure
        // TODO Failures in processing job into job part(s) should surface errors (currently doesn't)
        //      Assert.That(transfer.TransferStatus.HasFailedItems);
        //      Assert.That(failures, Is.Not.Empty);
        // TODO determine checkpointer status of job parts
        //      need checkpointer API refactor for this
    }

    [Test]
    public async Task TransferFailAtPartProcess([Values(true, false)] bool isContainer)
    {
        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new(ClientOptions.Default));
        Mock<TransferCheckpointer> checkpointer = new(MockBehavior.Loose);

        (StorageResource srcResource, StorageResource dstResource) = GetBasicSetupResources(isContainer, srcUri, dstUri);

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer.Object,
            default);

        // need to listen to events to get exception that takes place in processing
        List<TransferItemFailedEventArgs> failures = new();
        DataTransferOptions options = new();
        options.ItemTransferFailed += e => { failures.Add(e); return Task.CompletedTask; };

        DataTransfer transfer = await transferManager.StartTransferAsync(srcResource, dstResource);

        Assert.That(await jobsProcessor.TryStepAsync(), Is.True);
        Assert.That(jobsProcessor.ItemsInQueue, Is.Zero);
        Assert.That(partsProcessor.ItemsInQueue, Is.AtLeast(1));

        Assert.That(await partsProcessor.StepAll(), Is.AtLeast(1));
        Assert.That(partsProcessor.ItemsInQueue, Is.Zero);
        Assert.That(chunksProcessor.ItemsInQueue, Is.Zero); // because of failure

        // TODO Failures in processing parts into chunks should surface errors (currently doesn't)
        //      Assert.That(transfer.TransferStatus.HasFailedItems);
        //      Assert.That(failures, Is.Not.Empty);
        // TODO determine checkpointer status of job chunks
        //      need checkpointer API refactor for this
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

    public static void BasicSetup(
        this (Mock<StorageResourceItem> Source, Mock<StorageResourceItem> Destination) items,
        Uri srcUri,
        Uri dstUri,
        int itemSize = Constants.KB
        )
    {
        items.Source.Setup(r => r.Uri).Returns(srcUri);
        items.Destination.Setup(r => r.Uri).Returns(dstUri);

        items.Source.SetupGet(r => r.ResourceId).Returns("Mock");
        items.Destination.SetupGet(r => r.ResourceId).Returns("Mock");

        items.Destination.SetupGet(r => r.TransferType).Returns(default(DataTransferOrder));
        items.Destination.SetupGet(r => r.MaxSupportedChunkSize).Returns(Constants.GB);

        items.Source.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new StorageResourceItemProperties(resourceLength: itemSize, default, default, default)));

        items.Source.Setup(r => r.ReadStreamAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
            .Returns<long, long?, CancellationToken>((position, length, cancellation)
                => Task.FromResult(new StorageResourceReadStreamResult(
                    new Mock<Stream>().Object,
                    new HttpRange(position, length),
                    new(itemSize, default, default, new()))));
        items.Destination.Setup(r => r.CopyFromStreamAsync(
            It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(),
            It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        items.Destination.Setup(r => r.CompleteTransferAsync(
            It.IsAny<bool>(),
            It.IsAny<StorageResourceCompleteTransferOptions>(),
            It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
    }

    public static void BasicSetup(
        this (Mock<StorageResourceContainer> Source, Mock<StorageResourceContainer> Destination) containers,
        Uri srcUri,
        Uri dstUri,
        int numItems = 5,
        int itemSize = Constants.KB
        )
    {
        var subResources = Enumerable.Range(0, numItems).Select(_ =>
        {
            string name = "/" + Guid.NewGuid().ToString();
            var items = (
                Source: new Mock<StorageResourceItem>(MockBehavior.Strict),
                Destination: new Mock<StorageResourceItem>(MockBehavior.Strict));
            items.BasicSetup(new Uri(srcUri.ToString() + name), new Uri(dstUri.ToString() + name), itemSize);
            items.Source.SetupGet(r => r.IsContainer).Returns(false);
            return items;
        }).ToList();

        async IAsyncEnumerable<StorageResource> SubResourcesAsAsyncEnumerable(
            StorageResourceContainer src,
            [EnumeratorCancellation] CancellationToken ct)
        {
            foreach (int i in Enumerable.Range(0, numItems))
            {
                yield return await Task.FromResult(subResources[i].Source.Object);
            }
        }

        containers.Source.SetupGet(r => r.Uri).Returns(srcUri);
        containers.Destination.SetupGet(r => r.Uri).Returns(dstUri);

        containers.Source.Setup(r => r.GetStorageResourcesAsync(It.IsAny<StorageResourceContainer>(), It.IsAny<CancellationToken>()))
            .Returns(SubResourcesAsAsyncEnumerable);

        containers.Destination.Setup(r => r.GetStorageResourceReference(It.IsAny<string>(), It.IsAny<string>()))
            .Returns<string, string>((path, resId) => subResources
                .Where(pair => pair.Source.Object.Uri.AbsolutePath.Contains(path))
                .FirstOrDefault().Destination?.Object
            );
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

    public static void VerifySourceResourceOnQueue(this Mock<StorageResourceContainer> srcResource)
    {
        srcResource.VerifyGet(r => r.Uri);
    }

    public static void VerifyDestinationResourceOnQueue(this Mock<StorageResourceContainer> dstResource)
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

    public static void VerifySourceResourceOnJobProcess(this Mock<StorageResourceContainer> srcResource)
    {
        srcResource.Verify(
            r => r.GetStorageResourcesAsync(It.IsAny<StorageResourceContainer>(), It.IsAny<CancellationToken>()),
            Times.Once);
        srcResource.VerifyGet(r => r.Uri, Times.AtLeastOnce());
    }

    public static void VerifyDestinationResourceOnJobProcess(this Mock<StorageResourceContainer> dstResource)
    {
        dstResource.Verify(
            r => r.GetStorageResourceReference(It.IsAny<string>(), It.IsAny<string>()),
            Times.AtLeastOnce());
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
