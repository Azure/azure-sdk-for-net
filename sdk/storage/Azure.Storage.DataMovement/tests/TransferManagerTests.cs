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
using Azure.Storage.DataMovement.Tests.Shared;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;

namespace Azure.Storage.DataMovement.Tests;

public class TransferManagerTests
{
    public static IEnumerable<TransferDirection> AllTransferDirections()
        => Enum.GetValues(typeof(TransferDirection)).Cast<TransferDirection>();

    private static (StepProcessor<TransferJobInternal> JobProcessor, StepProcessor<JobPartInternal> PartProcessor, StepProcessor<Func<Task>> ChunkProcessor) StepProcessors()
        => (new(), new(), new());

    private static (StorageResource Source, StorageResource Destination, Func<IDisposable> SrcThrowScope, Func<IDisposable> DstThrowScope)
        GetBasicSetupResources(bool isContainer, Uri srcUri, Uri dstUri, bool includeDelete = false)
    {
        if (isContainer)
        {
            Mock<StorageResourceContainer> srcContainer = new(MockBehavior.Strict);
            Mock<StorageResourceContainer> dstContainer = new(MockBehavior.Strict);
            (srcContainer, dstContainer).BasicSetup(srcUri, dstUri);
            StorageResourceContainerFailureWrapper srcWrapper = new(srcContainer.Object);
            StorageResourceContainerFailureWrapper dstWrapper = new(dstContainer.Object);
            return (srcWrapper, dstWrapper, srcWrapper.ThrowScope, dstWrapper.ThrowScope);
        }
        else
        {
            Mock<StorageResourceItem> srcItem = new(MockBehavior.Strict);
            Mock<StorageResourceItem> dstItem = new(MockBehavior.Strict);
            (srcItem, dstItem).BasicSetup(srcUri, dstUri);
            dstItem.Setup(item => item.DeleteIfExistsAsync(It.IsAny<CancellationToken>()));
            StorageResourceItemFailureWrapper srcWrapper = new(srcItem.Object);
            StorageResourceItemFailureWrapper dstWrapper = new(dstItem.Object);
            return (srcWrapper, dstWrapper, srcWrapper.ThrowScope, dstWrapper.ThrowScope);
        }
    }

    private static async Task ProcessChunksAssert(
        StepProcessor<Func<Task>> chunksProcessor,
        int chunksPerPart,
        int numChunks,
        int totalJobParts)
    {
        // process chunks
        int chunksStepped = await chunksProcessor.StepAll();
        // Check if all chunks stepped through
        if (chunksPerPart > 1)
        {
            // Multichunk transfer sends a completion chunk after all the other chunks stepped through.
            await Task.Delay(100);
            Assert.That(await chunksProcessor.StepAll() + chunksStepped, Is.EqualTo(numChunks + totalJobParts));
        }
        else
        {
            Assert.That(chunksStepped, Is.EqualTo(numChunks));
        }
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0), "Failed to step through chunks queue.");
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
        jobsProcessor.VerifyAsyncDisposal();
        partsProcessor.VerifyAsyncDisposal();
        chunksProcessor.VerifyAsyncDisposal();

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
        int expectedChunksInQueue = Math.Max(chunksPerPart - 1, 1) * items;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        MemoryTransferCheckpointer checkpointer = new();

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
            checkpointer,
            default);

        List<TransferOperation> transfers = new();

        // queue jobs
        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            TransferOperation transfer = await transferManager.StartTransferAsync(
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
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(items), "Jobs not added to checkpointer.");
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
        foreach (MemoryTransferCheckpointer.Job job in checkpointer.Jobs.Values)
        {
            Assert.That(job.Parts.Count, Is.EqualTo(1), "Items should be single-part.");
            Assert.That(job.Parts.Values.First().Status.State, Is.EqualTo(TransferState.Queued), "Bad part status.");
            Assert.That(job.Parts.Keys.First(), Is.EqualTo(0), "Parts should be zero-indexed.");
            Assert.That(job.EnumerationComplete, "Enumeration not marked comlete.");
            Assert.That(job.Status.State, Is.EqualTo(TransferState.InProgress), "Transfer state not updated.");
        }

        // process parts
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(items));
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(0));
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(expectedChunksInQueue), "Error during Part => Chunk processing.");
        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            srcResource.VerifySourceResourceOnPartProcess();
            dstResource.VerifyDestinationResourceOnPartProcess(chunked: chunksPerPart > 1);
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }
        foreach (MemoryTransferCheckpointer.Job job in checkpointer.Jobs.Values)
        {
            foreach (MemoryTransferCheckpointer.JobPart part in job.Parts.Values)
            {
                Assert.That(part.Status.State, Is.EqualTo(TransferState.InProgress), "Part state not updated.");
            }
        }

        await ProcessChunksAssert(
            chunksProcessor,
            chunksPerPart,
            expectedChunksInQueue,
            items);

        foreach ((Mock<StorageResourceItem> srcResource, Mock<StorageResourceItem> dstResource) in resources)
        {
            srcResource.VerifySourceResourceOnChunkProcess();
            dstResource.VerifyDestinationResourceOnChunkProcess();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        await Task.Delay(50); // TODO flaky that we need this; a random one will often fail without

        foreach (TransferOperation transfer in transfers)
        {
            Assert.That(transfer.HasCompleted);
        }
        foreach (MemoryTransferCheckpointer.Job job in checkpointer.Jobs.Values)
        {
            foreach (MemoryTransferCheckpointer.JobPart part in job.Parts.Values)
            {
                Assert.That(part.Status.State, Is.EqualTo(TransferState.Completed), "Part state not updated.");
            }
            Assert.That(job.Status.State, Is.EqualTo(TransferState.Completed), "Job state not updated.");
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

        int totalJobParts = Enumerable.Range(1, numJobs).Select(GetItemCountFromContainerIndex).Sum();
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * totalJobParts;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        MemoryTransferCheckpointer checkpointer = new();

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer,
            default);

        List<(TransferOperation Transfer, int ExpectedPartCount, Mock<StorageResourceContainer> Source, Mock<StorageResourceContainer> Destination)> transfers = new();

        foreach (int i in Enumerable.Range(1, numJobs))
        {
            Mock<StorageResourceContainer> srcResource = new(MockBehavior.Strict);
            Mock<StorageResourceContainer> dstResource = new(MockBehavior.Strict);
            (srcResource, dstResource).BasicSetup(srcUri, dstUri, GetItemCountFromContainerIndex(i), itemSize);
            TransferOperation transfer = await transferManager.StartTransferAsync(
                srcResource.Object,
                dstResource.Object,
                new()
                {
                    InitialTransferSize = chunkSize,
                    MaximumTransferChunkSize = chunkSize,
                });
            transfers.Add((transfer, GetItemCountFromContainerIndex(i), srcResource, dstResource));

            Assert.That(transfer.HasCompleted, Is.False);
            srcResource.VerifySourceResourceOnQueue();
            dstResource.VerifyDestinationResourceOnQueue();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(numJobs), "Jobs not added to checkpointer.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error during initial Job queueing.");

        // process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(numJobs), "Failed to step through jobs queue.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(0), "Failed to step through jobs queue.");
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(totalJobParts), "Error during Job => Part processing.");
        foreach ((TransferOperation transfer, int parts, Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in transfers)
        {
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(parts), "Containers should have several parts.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Keys, Is.EquivalentTo(Enumerable.Range(0, checkpointer.Jobs[transfer.Id].Parts.Count).ToList()),
                "Part nums should be sequential and zero-indexed.");
            Assert.That(checkpointer.Jobs[transfer.Id].EnumerationComplete, "Enumeration not marked comlete.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(TransferState.InProgress), "Transfer state not updated.");
            srcResource.VerifySourceResourceOnJobProcess();
            dstResource.VerifyDestinationResourceOnJobProcess();
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        // process parts
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(totalJobParts), "Failed to step through parts queue.");
        Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(0), "Failed to step through parts queue.");
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks), "Error during Part => Chunk processing.");
        foreach ((TransferOperation transfer, int parts, Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in transfers)
        {
            foreach (MemoryTransferCheckpointer.JobPart part in checkpointer.Jobs[transfer.Id].Parts.Values)
            {
                Assert.That(part.Status.State, Is.EqualTo(TransferState.InProgress), "Part state not updated.");
            }
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        await ProcessChunksAssert(
            chunksProcessor,
            chunksPerPart,
            numChunks,
            totalJobParts);

        foreach ((TransferOperation transfer, int parts, Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in transfers)
        {
            srcResource.VerifyNoOtherCalls();
            dstResource.VerifyNoOtherCalls();
        }

        await Task.Delay(10); // TODO flaky that we need this; a random one will often fail without

        foreach ((TransferOperation transfer, int parts, Mock<StorageResourceContainer> srcResource, Mock<StorageResourceContainer> dstResource) in transfers)
        {
            Assert.That(transfer.HasCompleted);
            foreach (MemoryTransferCheckpointer.JobPart part in checkpointer.Jobs[transfer.Id].Parts.Values)
            {
                Assert.That(part.Status.State, Is.EqualTo(TransferState.Completed), "Part state not updated.");
            }
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(TransferState.Completed), "Job state not updated.");
        }
    }

    [Test]
    [Combinatorial]
    public async Task TransferFailAtQueue(
        [Values(0, 1)] int failAt,
        [Values(true, false)] bool throwCleanup,
        [Values(true, false)] bool isContainer)
    {
        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        Mock<JobBuilder> jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default))
        {
            CallBase = true,
        };
        Mock<MemoryTransferCheckpointer> checkpointer = new()
        {
            CallBase = true,
        };

        (StorageResource srcResource, StorageResource dstResource, Func<IDisposable> srcThrowScope, Func<IDisposable> dstThrowScope)
            = GetBasicSetupResources(isContainer, srcUri, dstUri);

        Exception expectedException = new();
        Exception cleanupException = throwCleanup ? new() : null;
        bool expectTransferInCheckpointer = failAt == 0 && throwCleanup;
        switch (failAt)
        {
            case 0:
                jobBuilder.Setup(b => b.BuildJobAsync(It.IsAny<StorageResource>(), It.IsAny<StorageResource>(),
                    It.IsAny<TransferOptions>(), It.IsAny<ITransferCheckpointer>(), It.IsAny<string>(),
                    It.IsAny<bool>(), It.IsAny<CancellationToken>())
                ).Throws(expectedException);
                break;
            case 1:
                checkpointer.Setup(c => c.AddNewJobAsync(It.IsAny<string>(), It.IsAny<StorageResource>(),
                    It.IsAny<StorageResource>(), It.IsAny<CancellationToken>())
                ).Throws(expectedException);
                break;
        }
        if (throwCleanup)
        {
            checkpointer.Setup(c => c.TryRemoveStoredTransferAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>())
            ).Throws(cleanupException);
        }

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder.Object,
            checkpointer.Object,
            default);

        TransferOperation transfer = null;
        IConstraint throwsConstraint = throwCleanup
            ? Throws.TypeOf<AggregateException>().And.Property(nameof(AggregateException.InnerExceptions))
                .EquivalentTo(new List<Exception>() { expectedException, cleanupException })
            : Throws.Exception.EqualTo(expectedException);
        Assert.That(async () => transfer = await transferManager.StartTransferAsync(srcResource, dstResource),
            throwsConstraint);

        Assert.That(transfer, Is.Null);

        Assert.That(checkpointer.Object.Jobs.Count, Is.EqualTo(expectTransferInCheckpointer ? 1 : 0));
        checkpointer.Verify(c => c.AddNewJobAsync(It.IsAny<string>(), It.IsAny<StorageResource>(),
            It.IsAny<StorageResource>(), It.IsAny<CancellationToken>()), Times.Once);
        checkpointer.Verify(c => c.TryRemoveStoredTransferAsync(It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Once);
        checkpointer.VerifyNoOtherCalls();
    }

    [Test]
    public async Task TransferFailAtJobProcess(
        [Values(true, false)] bool isContainer,
        [ValueSource(nameof(AllTransferDirections))] TransferDirection direction)
    {
        Uri srcUri = new(direction == TransferDirection.Upload ? "file:///foo/bar" : "https://example.com/foo/bar");
        Uri dstUri = new(direction == TransferDirection.Download ? "file:///fizz/buzz" : "https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new(ClientOptions.Default));

        List<string> capturedTransferIds = new();
        List<TransferStatus> capturedTransferStatuses = new();
        Mock<ITransferCheckpointer> checkpointer = new(MockBehavior.Loose);
        checkpointer.Setup(c => c.AddNewJobAsync(Capture.In(capturedTransferIds),
            It.IsAny<StorageResource>(), It.IsAny<StorageResource>(), It.IsAny<CancellationToken>()));
        checkpointer.Setup(c => c.SetJobStatusAsync(It.IsAny<string>(), CaptureTransferStatus(capturedTransferStatuses),
            It.IsAny<CancellationToken>()));

        (StorageResource srcResource, StorageResource dstResource, Func<IDisposable> srcThrowScope, Func<IDisposable> dstThrowScope)
            = GetBasicSetupResources(isContainer, srcUri, dstUri);

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer.Object,
            default);

        // need to listen to events to get exception that takes place in processing
        List<TransferItemFailedEventArgs> failures = new();
        TransferOptions options = new();
        options.ItemTransferFailed += e => { failures.Add(e); return Task.CompletedTask; };

        TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

        using (srcThrowScope())
        {
            Assert.That(await jobsProcessor.TryStepAsync(), Is.True);
        }
        Assert.That(jobsProcessor.ItemsInQueue, Is.Zero);
        Assert.That(partsProcessor.ItemsInQueue, Is.Zero); // because of failure
        Assert.That(transfer.Status.HasFailedItems);
        Assert.That(failures, Is.Not.Empty);

        string transferId = capturedTransferIds.First();
        checkpointer.Verify(c => c.AddNewJobAsync(transferId, It.IsAny<StorageResource>(), It.IsAny<StorageResource>(),
            It.IsAny<CancellationToken>()));
        checkpointer.Verify(c => c.SetJobStatusAsync(transferId, It.IsAny<TransferStatus>(),
            It.IsAny<CancellationToken>()), Times.Exactly(3));
        Assert.That(capturedTransferStatuses[0].State, Is.EqualTo(TransferState.InProgress));
        Assert.That(capturedTransferStatuses[1].State, Is.EqualTo(TransferState.Stopping));
        Assert.That(capturedTransferStatuses[2].IsCompletedWithFailedItems);
        checkpointer.VerifyNoOtherCalls();

        // TODO checkpointer probably shouldn't be in this state.
    }

    [Test]
    public async Task TransferFailAtPartProcess(
        [Values(true, false)] bool isContainer,
        [ValueSource(nameof(AllTransferDirections))] TransferDirection direction)
    {
        Uri srcUri = new(direction == TransferDirection.Upload ? "file:///foo/bar" : "https://example.com/foo/bar");
        Uri dstUri = new(direction == TransferDirection.Download ? "file:///fizz/buzz" : "https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new(ClientOptions.Default));

        Mock<MemoryTransferCheckpointer> checkpointer = new()
        {
            CallBase = true
        };
        List<TransferStatus> capturedTransferStatuses = new();
        checkpointer.Setup(c => c.SetJobStatusAsync(It.IsAny<string>(), CaptureTransferStatus(capturedTransferStatuses),
            It.IsAny<CancellationToken>()));

        (StorageResource srcResource, StorageResource dstResource, Func<IDisposable> srcThrowScope, Func<IDisposable> dstThrowScope)
            = GetBasicSetupResources(isContainer, srcUri, dstUri, includeDelete: true);

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer.Object,
            default);

        // need to listen to events to get exception that takes place in processing
        List<TransferItemFailedEventArgs> failures = new();
        TransferOptions options = new();
        options.ItemTransferFailed += e => { failures.Add(e); return Task.CompletedTask; };

        TransferOperation transfer = await transferManager.StartTransferAsync(srcResource, dstResource, options);

        Assert.That(await jobsProcessor.TryStepAsync(), Is.True);
        Assert.That(jobsProcessor.ItemsInQueue, Is.Zero);
        Assert.That(partsProcessor.ItemsInQueue, Is.AtLeast(1));

        using (srcThrowScope())
        {
            Assert.That(await partsProcessor.StepAll(), Is.AtLeast(1));
        }
        Assert.That(partsProcessor.ItemsInQueue, Is.Zero);
        Assert.That(chunksProcessor.ItemsInQueue, Is.Zero); // because of failure

        Assert.That(transfer.Status.HasFailedItems);
        Assert.That(failures, Is.Not.Empty);

        Assert.That(capturedTransferStatuses.Count, Is.EqualTo(4));
        Assert.That(capturedTransferStatuses[0].State, Is.EqualTo(TransferState.InProgress));
        Assert.That(capturedTransferStatuses[1].State, Is.EqualTo(TransferState.InProgress));
        Assert.That(capturedTransferStatuses[2].State, Is.EqualTo(TransferState.Stopping));
        Assert.That(capturedTransferStatuses[3].IsCompletedWithFailedItems);
    }

    [Test]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(12345)]
    public async Task MultipleTransfersAddedCheckpointer(int numJobs)
    {
        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new(ClientOptions.Default));
        Mock<ITransferCheckpointer> checkpointer = new(MockBehavior.Loose);

        (StorageResource srcResource, StorageResource dstResource, Func<IDisposable> srcThrowScope, Func<IDisposable> dstThrowScope)
            = GetBasicSetupResources(false, srcUri, dstUri);

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer.Object,
            default);

        // Add jobs on separate Tasks
        var loopResult = Parallel.For(0, numJobs, i =>
        {
            Task<TransferOperation> task = transferManager.StartTransferAsync(srcResource, dstResource);
        });
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error during initial Job queueing.");
    }

    [Test]
    public async Task BasicTransfer_NoOptions()
    {
        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        MemoryTransferCheckpointer checkpointer = new();

        await using TransferManager transferManager = new(
            jobsProcessor,
            partsProcessor,
            chunksProcessor,
            jobBuilder,
            checkpointer,
            default);

        int numFiles = 3;
        Mock<StorageResourceContainer> srcResource = new(MockBehavior.Strict);
        Mock<StorageResourceContainer> dstResource = new(MockBehavior.Strict);
        (srcResource, dstResource).BasicSetup(srcUri, dstUri, numFiles);

        // Don't pass options to test default options
        TransferOperation transfer = await transferManager.StartTransferAsync(srcResource.Object, dstResource.Object);

        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(1), "Failed to step through jobs queue.");
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(numFiles), "Failed to step through parts queue.");
        await ProcessChunksAssert(chunksProcessor, 1, numFiles, numFiles);

        Assert.That(transfer.Status.HasCompletedSuccessfully);
    }

    /// <summary>
    /// <see cref="TransferStatus"/> is stateful across transfer. This makes it difficult to verify mocks, as verifications
    /// are lazily performed. This captures deep copies of statuses for custom assertion.
    /// </summary>
    private static TransferStatus CaptureTransferStatus(ICollection<TransferStatus> statuses)
        => Match.Create<TransferStatus>(status =>
        {
            statuses.Add(status.DeepCopy());
            return true;
        });
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

        items.Source.SetupGet(r => r.Length).Returns(itemSize);

        items.Destination.SetupGet(r => r.TransferType).Returns(default(TransferOrder));
        items.Destination.SetupGet(r => r.MaxSupportedSingleTransferSize).Returns(Constants.GB);
        items.Destination.SetupGet(r => r.MaxSupportedChunkSize).Returns(Constants.GB);
        items.Destination.SetupGet(r => r.MaxSupportedChunkCount).Returns(int.MaxValue);

        items.Source.Setup(r => r.ShouldItemTransferAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));

        items.Source.Setup(r => r.GetPropertiesAsync(It.IsAny<CancellationToken>()))
            .Returns((CancellationToken cancellationToken) =>
            {
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                return Task.FromResult(new StorageResourceItemProperties()
                {
                    ResourceLength = itemSize
                });
            });

        items.Destination.Setup(r => r.ValidateTransferAsync(It.IsAny<string>(), It.IsAny<StorageResource>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        items.Destination.Setup(r => r.SetPermissionsAsync(It.IsAny<StorageResourceItem>(), It.IsAny<StorageResourceItemProperties>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        items.Source.Setup(r => r.ReadStreamAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
            .Returns<long, long?, CancellationToken>((position, length, cancellationToken) =>
            {
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                return Task.FromResult(new StorageResourceReadStreamResult(
                    new Mock<Stream>().Object,
                    new HttpRange(position, length),
                    new() { ResourceLength = itemSize }));
            });

        items.Source.Setup(r => r.IsContainer).Returns(false);

        items.Source.Setup(r => r.ProviderId).Returns("mock");

        items.Destination.Setup(r => r.CopyFromStreamAsync(
            It.IsAny<Stream>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<long>(),
            It.IsAny<StorageResourceWriteToOffsetOptions>(), It.IsAny<CancellationToken>()))
            .Returns<Stream, long, bool, long, StorageResourceWriteToOffsetOptions, CancellationToken>((stream, length, overwrite, offset, options, cancellationToken) =>
            {
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                return Task.CompletedTask;
            });

        items.Destination.Setup(r => r.CompleteTransferAsync(
            It.IsAny<bool>(),
            It.IsAny<StorageResourceCompleteTransferOptions>(),
            It.IsAny<CancellationToken>()))
            .Returns<bool, StorageResourceCompleteTransferOptions, CancellationToken>((isFinal, options, cancellationToken) =>
            {
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                return Task.CompletedTask;
            });

        items.Destination.Setup(r => r.IsContainer).Returns(false);

        items.Destination.Setup(r => r.ProviderId).Returns("mock");
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

        containers.Destination.Setup(r => r.ValidateTransferAsync(It.IsAny<string>(), It.IsAny<StorageResource>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        containers.Source.Setup(r => r.GetStorageResourcesAsync(It.IsAny<StorageResourceContainer>(), It.IsAny<CancellationToken>()))
            .Returns(SubResourcesAsAsyncEnumerable);

        containers.Source.Setup(r => r.GetStorageResourceReference(It.IsAny<string>(), It.IsAny<string>()))
            .Returns<string, string>((path, resId) => subResources
                .Where(pair => pair.Source.Object.Uri.AbsolutePath.Contains(path))
                .FirstOrDefault().Source?.Object
        );

        containers.Destination.Setup(r => r.GetStorageResourceReference(It.IsAny<string>(), It.IsAny<string>()))
            .Returns<string, string>((path, resId) => subResources
                .Where(pair => pair.Source.Object.Uri.AbsolutePath.Contains(path))
                .FirstOrDefault().Destination?.Object
        );

        containers.Source.Setup(r => r.IsContainer).Returns(true);

        containers.Source.Setup(r => r.ProviderId).Returns("mock");

        containers.Destination.Setup(r => r.IsContainer).Returns(true);

        containers.Destination.Setup(r => r.ProviderId).Returns("mock");
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
        dstResource.Verify(b => b.ValidateTransferAsync(It.IsAny<string>(), It.IsAny<StorageResource>(), It.IsAny<CancellationToken>()), Times.Once());
    }

    public static void VerifySourceResourceOnQueue(this Mock<StorageResourceContainer> srcResource)
    {
        srcResource.VerifyGet(r => r.Uri);
    }

    public static void VerifyDestinationResourceOnQueue(this Mock<StorageResourceContainer> dstResource)
    {
        dstResource.VerifyGet(r => r.Uri);
        dstResource.Verify(b => b.ValidateTransferAsync(It.IsAny<string>(), It.IsAny<StorageResource>(), It.IsAny<CancellationToken>()), Times.Once());
    }

    public static void VerifySourceResourceOnJobProcess(this Mock<StorageResourceItem> srcResource)
    {
        srcResource.VerifyGet(r => r.Uri);
        srcResource.VerifyGet(r => r.ResourceId);
        srcResource.VerifyGet(r => r.IsContainer);
    }

    public static void VerifyDestinationResourceOnJobProcess(this Mock<StorageResourceItem> dstResource)
    {
        dstResource.VerifyGet(r => r.Uri);
        dstResource.VerifyGet(r => r.ResourceId);
        dstResource.VerifyGet(r => r.MaxSupportedSingleTransferSize);
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

    public static void VerifyDestinationResourceOnPartProcess(this Mock<StorageResourceItem> dstResource, bool chunked)
    {
        dstResource.VerifyGet(r => r.TransferType, Times.AtMost(9999));
        if (chunked)
        {
            dstResource.VerifyGet(r => r.MaxSupportedChunkCount, Times.Once);
        }
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
