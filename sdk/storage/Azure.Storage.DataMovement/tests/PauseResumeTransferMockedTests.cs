﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Moq;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.MemoryTransferCheckpointer;

namespace Azure.Storage.DataMovement.Tests;

public class PauseResumeTransferMockedTests
{
    private (StepProcessor<TransferJobInternal> JobProcessor, StepProcessor<JobPartInternal> PartProcessor, StepProcessor<Func<Task>> ChunkProcessor) StepProcessors()
        => (new(), new(), new());

    private Dictionary<DataTransferState, int> GetJobsStateCount(List<DataTransfer> transfers, MemoryTransferCheckpointer checkpointer)
    {
        Dictionary<DataTransferState, int> jobsStateCount = new();
        // initialize jobsStateCount
        foreach (DataTransferState state in Enum.GetValues(typeof(DataTransferState)))
        {
            jobsStateCount[state] = 0;
        }
        // populate jobsStateCount
        foreach (DataTransfer transfer in transfers)
        {
            var job = checkpointer.Jobs[transfer.Id];
            ++jobsStateCount[job.Status.State];
        }
        return jobsStateCount;
    }

    private Dictionary<DataTransferState, int> GetJobPartsStateCount(List<DataTransfer> transfers, MemoryTransferCheckpointer checkpointer)
    {
        Dictionary<DataTransferState, int> jobPartsStateCount = new();
        // initialize jobPartsStateCount
        foreach (DataTransferState state in Enum.GetValues(typeof(DataTransferState)))
        {
            jobPartsStateCount[state] = 0;
        }
        // populate jobPartsStateCount
        foreach (DataTransfer transfer in transfers)
        {
            var job = checkpointer.Jobs[transfer.Id];
            foreach (var jobPartEntry in job.Parts)
            {
                JobPart jobPart = jobPartEntry.Value;
                ++jobPartsStateCount[jobPart.Status.State];
            }
        }
        return jobPartsStateCount;
    }

    [Test]
    [Combinatorial]
    public async Task PauseDuringJobProcessing_ItemTransfer(
        [Values(2, 6)] int items,
        [Values(333, 500, 1024)] int itemSize,
        [Values(333, 1024)] int chunkSize,
        [Values(PauseLocation.PauseProcessHalfway,
            PauseLocation.PauseProcessStart)] PauseLocation pauseLocation)
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
            transfers.Add(transfer);

            // Assert that job plan file is created properly
            Assert.That(checkpointer.Jobs.ContainsKey(transfer.Id), Is.True, "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(0), "Job Part files should not exist before job processing");
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(transfers.Count), "Error during Job plan file creation.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(items), "Error during initial Job queueing.");

        // Setup PauseProcessHalfway & PauseProcessStart before issuing pause
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Let half of the jobs process without Pause
            Assert.That(await jobsProcessor.StepMany(items / 2), Is.EqualTo(items / 2), "Error in job processing half");
            Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(items / 2), "Error in job processing half");
        }
        else
        {
            Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(items), "Error in job processing all");
        }

        // Issue Pause for all of the transfers
        foreach (DataTransfer transfer in transfers)
        {
            Task pauseTask = transferManager.PauseTransferIfRunningAsync(transfer.Id);
            Assert.That(DataTransferState.Pausing, Is.EqualTo(transfer.TransferStatus.State), "Error in transitioning to Pausing state");
        }

        // Process (the rest of) jobs
        await jobsProcessor.StepAll();

        await Task.Delay(50);
        int pausedJobsCount = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int queuedPartsCount = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Queued];
        int jobPartsCreatedCount = transfers.Sum(transfer => checkpointer.Jobs[transfer.Id].Parts.Count);

        // Assert that we properly paused for PauseProcessHalfway & PauseProcessStart
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            Assert.That(pausedJobsCount, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(queuedPartsCount, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(jobPartsCreatedCount, Is.EqualTo(items / 2), "Error in Pausing half");
        }
        else
        {
            Assert.That(pausedJobsCount, Is.EqualTo(items), "Error in Pausing all");
            Assert.That(queuedPartsCount, Is.EqualTo(0), "Error in Pausing all");
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(0), "Error in Pausing all");
            Assert.That(jobPartsCreatedCount, Is.EqualTo(0), "Error in Pausing all");
            Assert.Pass();
        }

        // At this point, we are continuing with the leftovers from PauseProcessHalfway
        // Process parts
        await partsProcessor.StepAll();

        await Task.Delay(50);
        int pausedJobsCount2 = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int pausedPartsCount2 = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        Assert.That(pausedJobsCount2, Is.EqualTo(items), "Error in transitioning all jobs to Paused state");
        // only half of the job part checkpointers are created in PauseProcessHalfway so only half will be in Paused state
        Assert.That(pausedPartsCount2, Is.EqualTo(items / 2), "Error in transitioning all created job parts to Paused state");
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0), "Error: no items should proceed to chunking");
    }

    [Test]
    [Combinatorial]
    public async Task PauseDuringPartProcessing_ItemTransfer(
        [Values(2, 6)] int items,
        [Values(333, 500, 1024)] int itemSize,
        [Values(333, 1024)] int chunkSize,
        [Values(PauseLocation.PauseProcessHalfway,
            PauseLocation.PauseProcessStart)] PauseLocation pauseLocation)
    {
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * items;

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
            transfers.Add(transfer);

            // Assert that job plan file is created properly
            Assert.That(checkpointer.Jobs.ContainsKey(transfer.Id), Is.True, "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(0), "Job Part files should not exist before job processing");
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(transfers.Count), "Error during Job plan file creation.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(items), "Error during initial Job queueing.");

        // Process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(items), "Error during job processing");

        // At this point, job part files should be created for each transfer item
        foreach (DataTransfer transfer in transfers)
        {
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.InProgress), "Error transitioning Job to InProgress after job processing");
            var partsDict = checkpointer.Jobs[transfer.Id].Parts;
            Assert.That(partsDict.Count, Is.EqualTo(1), "Error during Job part file creation.");
            Assert.That(partsDict.First().Value.Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job part file creation.");
        }

        // Setup PauseProcessHalfway & PauseProcessStart before issuing pause
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Let half of the parts process without Pause
            Assert.That(await partsProcessor.StepMany(items / 2), Is.EqualTo(items / 2), "Error in part processing half");
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(items / 2), "Error in part processing half");
        }
        else
        {
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(items), "Error in part processing all");
        }

        // Issue Pause for all of the transfers
        foreach (DataTransfer transfer in transfers)
        {
            Task pauseTask = transferManager.PauseTransferIfRunningAsync(transfer.Id);
            Assert.That(DataTransferState.Pausing, Is.EqualTo(transfer.TransferStatus.State), "Error in transitioning to Pausing state");
        }

        // Process (the rest of) parts
        await partsProcessor.StepAll();

        await Task.Delay(50);
        int pausedJobsCount = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int pausedPartsCount = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Paused];

        // Assert that we properly paused for PauseProcessHalfway & PauseProcessStart
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            Assert.That(pausedJobsCount, Is.EqualTo(items / 2), "Error in Pausing half"); // cus jobs is 1:1 with job parts in item transfer
            Assert.That(pausedPartsCount, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks / 2), "Error in Pausing half");
        }
        else
        {
            Assert.That(pausedJobsCount, Is.EqualTo(items), "Error in Pausing all");
            Assert.That(pausedPartsCount, Is.EqualTo(items), "Error in Pausing all");
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0), "Error in Pausing all");
        }

        // At this point, we are continuing with the leftovers from PauseProcessHalfway
        // Process chunks
        await chunksProcessor.StepAll();

        await Task.Delay(50);
        // All jobs and job parts should be paused now
        int pausedJobsCount2 = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int pausedPartsCount2 = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        Assert.That(pausedJobsCount2, Is.EqualTo(items), "Error in transitioning all jobs to Paused state");
        Assert.That(pausedPartsCount2, Is.EqualTo(items), "Error in transitioning all job parts to Paused state");
    }

    [Test]
    [Combinatorial]
    public async Task PauseDuringChunkProcessing_ItemTransfer(
        [Values(2, 6)] int items,
        [Values(1024)] int itemSize,
        [Values(1024)] int chunkSize,
        [Values(PauseLocation.PauseProcessHalfway,
            PauseLocation.PauseProcessStart)] PauseLocation pauseLocation)
    {
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * items;

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
            transfers.Add(transfer);

            // Assert that job plan file is created properly
            Assert.That(checkpointer.Jobs.ContainsKey(transfer.Id), Is.True, "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(0), "Job Part files should not exist before job processing");
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(transfers.Count), "Error during Job plan file creation.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(items), "Error during initial Job queueing.");

        // Process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(items), "Error during job processing");

        // At this point, job part files should be created for each transfer item
        foreach (DataTransfer transfer in transfers)
        {
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.InProgress), "Error transitioning Job to InProgress after job processing");
            var partsDict = checkpointer.Jobs[transfer.Id].Parts;
            Assert.That(partsDict.Count, Is.EqualTo(1), "Error during Job part file creation.");
            Assert.That(partsDict.First().Value.Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job part file creation.");
        }

        // Process parts
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(items), "Error in part processing");

        // Setup PauseProcessHalfway & PauseProcessStart before issuing pause
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Let half of the chunks process without Pause
            Assert.That(await chunksProcessor.StepMany(numChunks / 2), Is.EqualTo(numChunks / 2), "Error in chunk processing half");
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks / 2), "Error in chunk processing half");
        }
        else
        {
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks), "Error in chunk processing all");
        }

        // Issue Pause for all of the transfers
        foreach (DataTransfer transfer in transfers)
        {
            Task pauseTask = transferManager.PauseTransferIfRunningAsync(transfer.Id);
            if (pauseLocation == PauseLocation.PauseProcessStart)
            {
                Assert.That(DataTransferState.Pausing, Is.EqualTo(transfer.TransferStatus.State), "Error in transitioning to Pausing state");
            }
            else
            {
                // the half that processed before the pause will be in Completed state
                Assert.That(transfer.TransferStatus.State,
                    Is.AnyOf(DataTransferState.Pausing, DataTransferState.Completed),
                    "Error: Transfer state for PauseProcessHalfway should be either Pausing or Completed");
            }
        }

        // Process (the rest of) chunks
        await chunksProcessor.StepAll();

        await Task.Delay(50);
        var jobsStateCount = GetJobsStateCount(transfers, checkpointer);
        int pausedJobsCount = jobsStateCount[DataTransferState.Paused];
        int completedJobsCount = jobsStateCount[DataTransferState.Completed];
        var partsStateCount = GetJobPartsStateCount(transfers, checkpointer);
        int pausedPartsCount = partsStateCount[DataTransferState.Paused];
        int completedPartsCount = partsStateCount[DataTransferState.Completed];

        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Because for this test, 1 chunk = 1 job part = 1 job/transfer
            // so pausing half of the chunks should yield half of the jobs and job parts in Paused state
            Assert.That(pausedJobsCount, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(completedJobsCount, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(pausedPartsCount, Is.EqualTo(items / 2), "Error in Pausing half");
            Assert.That(completedPartsCount, Is.EqualTo(items / 2), "Error in Pausing half");
        }
        else
        {
            Assert.That(pausedJobsCount, Is.EqualTo(items), "Error in Pausing all");
            Assert.That(completedJobsCount, Is.EqualTo(0), "Error in Pausing all");
            Assert.That(pausedPartsCount, Is.EqualTo(items), "Error in Pausing all");
            Assert.That(completedPartsCount, Is.EqualTo(0), "Error in Pausing all");
        }
    }

    [Test]
    [Combinatorial]
    public async Task PauseDuringJobProcessing_ContainerTransfer(
    [Values(2, 6)] int numJobs,
    [Values(333, 500, 1024)] int itemSize,
    [Values(333, 1024)] int chunkSize,
    [Values(PauseLocation.PauseProcessHalfway,
            PauseLocation.PauseProcessStart)] PauseLocation pauseLocation)
    {
        static int GetItemCountFromContainerIndex(int i) => i * 2;

        int numJobParts = Enumerable.Range(1, numJobs).Select(GetItemCountFromContainerIndex).Sum();
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * numJobParts;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        MemoryTransferCheckpointer checkpointer = new();

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
            checkpointer,
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
            transfers.Add(transfer);

            // Assert that job plan file is created properly
            Assert.That(checkpointer.Jobs.ContainsKey(transfer.Id), Is.True, "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(0), "Job Part files should not exist before job processing");
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(transfers.Count), "Error during Job plan file creation.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error during initial Job queueing.");

        // Setup PauseProcessHalfway & PauseProcessStart before issuing pause
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Let half of the jobs process without Pause
            Assert.That(await jobsProcessor.StepMany(numJobs / 2), Is.EqualTo(numJobs / 2), "Error in job processing half");
            Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs / 2), "Error in job processing half");
        }
        else
        {
            Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error in job processing all");
        }

        // Issue Pause for all of the transfers
        foreach (DataTransfer transfer in transfers)
        {
            Task pauseTask = transferManager.PauseTransferIfRunningAsync(transfer.Id);
            Assert.That(DataTransferState.Pausing, Is.EqualTo(transfer.TransferStatus.State), "Error in transitioning to Pausing state");
        }

        // Process (the rest of) jobs
        await jobsProcessor.StepAll();

        await Task.Delay(50);
        int pausedJobsCount = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int queuedPartsCount = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Queued];
        int expectedPartsCreatedCount = Enumerable.Range(1, numJobs/2).Select(GetItemCountFromContainerIndex).Sum();
        int jobPartsCreatedCount = transfers.Sum(transfer => checkpointer.Jobs[transfer.Id].Parts.Count);

        // Assert that we properly paused for PauseProcessHalfway & PauseProcessStart
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            Assert.That(pausedJobsCount, Is.EqualTo(numJobs / 2), "Error in Pausing half");
            Assert.That(queuedPartsCount, Is.EqualTo(expectedPartsCreatedCount), "Error in Pausing half");
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(expectedPartsCreatedCount), "Error in Pausing half");
            Assert.That(jobPartsCreatedCount, Is.EqualTo(expectedPartsCreatedCount), "Error in Pausing half");
        }
        else
        {
            Assert.That(pausedJobsCount, Is.EqualTo(numJobs), "Error in Pausing all");
            Assert.That(queuedPartsCount, Is.EqualTo(0), "Error in Pausing all");
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(0), "Error in Pausing all");
            Assert.That(jobPartsCreatedCount, Is.EqualTo(0), "Error in Pausing all");
            Assert.Pass();
        }

        // At this point, we are continuing with the leftovers from PauseProcessStart
        // Process parts
        await partsProcessor.StepAll();

        await Task.Delay(50);
        int pausedJobsCount2 = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int pausedPartsCount2 = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        Assert.That(pausedJobsCount2, Is.EqualTo(numJobs), "Error in transitioning all jobs to Paused state");
        Assert.That(pausedPartsCount2, Is.EqualTo(expectedPartsCreatedCount), "Error in transitioning all created job parts to Paused state");
        Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0), "Error: no items should proceed to chunking");
    }

    [Test]
    [Combinatorial]
    public async Task PauseDuringPartProcessing_ContainerTransfer(
        [Values(2, 6)] int numJobs,
        [Values(333, 500, 1024)] int itemSize,
        [Values(333, 1024)] int chunkSize,
        [Values(PauseLocation.PauseProcessHalfway,
            PauseLocation.PauseProcessStart)] PauseLocation pauseLocation)
    {
        static int GetItemCountFromContainerIndex(int i) => i * 2;

        int numJobParts = Enumerable.Range(1, numJobs).Select(GetItemCountFromContainerIndex).Sum();
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * numJobParts;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        MemoryTransferCheckpointer checkpointer = new();

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
            checkpointer,
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
            transfers.Add(transfer);

            // Assert that job plan file is created properly
            Assert.That(checkpointer.Jobs.ContainsKey(transfer.Id), Is.True, "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(0), "Job Part files should not exist before job processing");
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(transfers.Count), "Error during Job plan file creation.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error during initial Job queueing.");

        // process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(numJobs), "Error during job processing");

        // At this point, job part files should be created for each transfer item
        for (int i = 0; i < transfers.Count; i++)
        {
            DataTransfer transfer = transfers[i];
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.InProgress), "Error transitioning Job to InProgress after job processing");
            int expectedItemCount = GetItemCountFromContainerIndex(i + 1);
            var partsDict = checkpointer.Jobs[transfer.Id].Parts;
            Assert.That(partsDict.Count, Is.EqualTo(expectedItemCount), "Error during Job part file creation.");
            Assert.That(partsDict.Values.All(part => part.Status.State == DataTransferState.Queued),
                Is.True, "Error during Job part file creation: Not all parts are in the Queued state.");
        }

        // Setup PauseProcessHalfway & PauseProcessStart before issuing pause
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Let half of the parts process without Pause
            Assert.That(await partsProcessor.StepMany(numJobParts / 2), Is.EqualTo(numJobParts / 2), "Error in part processing half");
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(numJobParts / 2), "Error in part processing half");
        }
        else
        {
            Assert.That(partsProcessor.ItemsInQueue, Is.EqualTo(numJobParts), "Error in part processing all");
        }

        // Issue Pause for all of the transfers
        foreach (DataTransfer transfer in transfers)
        {
            Task pauseTask = transferManager.PauseTransferIfRunningAsync(transfer.Id);
            Assert.That(DataTransferState.Pausing, Is.EqualTo(transfer.TransferStatus.State), "Error in transitioning to Pausing state");
        }

        // Process (the rest of) parts
        await partsProcessor.StepAll();

        await Task.Delay(50);
        int pausedPartsCount = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Paused];

        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            Assert.That(pausedPartsCount, Is.EqualTo(numJobParts / 2), "Error in Pausing half");
            Assert.That(chunksProcessor.ItemsInQueue, Is.AtLeast(1), "Error in Pausing half");
        }
        else
        {
            Assert.That(pausedPartsCount, Is.EqualTo(numJobParts), "Error in Pausing all");
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(0), "Error in Pausing all");
        }

        // At this point, we are continuing with the leftovers from PauseProcessHalfway
        // Process chunks
        await chunksProcessor.StepAll();

        await Task.Delay(50);
        // All jobs and job parts should be paused now
        int pausedJobsCount2 = GetJobsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        int pausedPartsCount2 = GetJobPartsStateCount(transfers, checkpointer)[DataTransferState.Paused];
        Assert.That(pausedJobsCount2, Is.EqualTo(numJobs), "Error in transitioning all jobs to Paused state");
        Assert.That(pausedPartsCount2, Is.EqualTo(numJobParts), "Error in transitioning all parts to Paused state");
    }

    [Test]
    [Combinatorial]
    public async Task PauseDuringChunkProcessing_ContainerTransfer(
    [Values(2, 6)] int numJobs,
    [Values(1024)] int itemSize,
    [Values(1024)] int chunkSize,
    [Values(PauseLocation.PauseProcessHalfway,
            PauseLocation.PauseProcessStart)] PauseLocation pauseLocation)
    {
        static int GetItemCountFromContainerIndex(int i) => i * 2;

        int numJobParts = Enumerable.Range(1, numJobs).Select(GetItemCountFromContainerIndex).Sum();
        int chunksPerPart = (int)Math.Ceiling((float)itemSize / chunkSize);
        // TODO: below should be only `items * chunksPerPart` but can't in some cases due to
        //       a bug in how work items are processed on multipart uploads.
        int numChunks = Math.Max(chunksPerPart - 1, 1) * numJobParts;

        Uri srcUri = new("file:///foo/bar");
        Uri dstUri = new("https://example.com/fizz/buzz");

        (var jobsProcessor, var partsProcessor, var chunksProcessor) = StepProcessors();
        JobBuilder jobBuilder = new(ArrayPool<byte>.Shared, default, new ClientDiagnostics(ClientOptions.Default));
        MemoryTransferCheckpointer checkpointer = new();

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
            checkpointer,
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
            transfers.Add(transfer);

            // Assert that job plan file is created properly
            Assert.That(checkpointer.Jobs.ContainsKey(transfer.Id), Is.True, "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.Queued), "Error during Job plan file creation.");
            Assert.That(checkpointer.Jobs[transfer.Id].Parts.Count, Is.EqualTo(0), "Job Part files should not exist before job processing");
        }
        Assert.That(checkpointer.Jobs.Count, Is.EqualTo(transfers.Count), "Error during Job plan file creation.");
        Assert.That(jobsProcessor.ItemsInQueue, Is.EqualTo(numJobs), "Error during initial Job queueing.");

        // Process jobs
        Assert.That(await jobsProcessor.StepAll(), Is.EqualTo(numJobs), "Error processing jobs");

        // At this point, job part files should be created for each transfer item
        for (int i = 0; i < transfers.Count; i++)
        {
            DataTransfer transfer = transfers[i];
            Assert.That(checkpointer.Jobs[transfer.Id].Status.State, Is.EqualTo(DataTransferState.InProgress), "Error transitioning Job to InProgress after job processing");
            int expectedItemCount = GetItemCountFromContainerIndex(i + 1);
            var partsDict = checkpointer.Jobs[transfer.Id].Parts;
            Assert.That(partsDict.Count, Is.EqualTo(expectedItemCount), "Error during Job part file creation.");
            Assert.That(partsDict.Values.All(part => part.Status.State == DataTransferState.Queued),
                Is.True, "Error during Job part file creation: Not all parts are in the Queued state.");
        }

        // Process parts
        Assert.That(await partsProcessor.StepAll(), Is.EqualTo(numJobParts), "Error processing job parts");

        // Setup PauseProcessHalfway & PauseProcessStart before issuing pause
        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // Let half of the chunks process without Pause
            Assert.That(await chunksProcessor.StepMany(numChunks / 2), Is.EqualTo(numChunks / 2), "Error in chunk processing half");
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks / 2), "Error in chunk processing half");
        }
        else
        {
            Assert.That(chunksProcessor.ItemsInQueue, Is.EqualTo(numChunks), "Error in chunk processing all");
        }

        // Issue Pause for all transfers
        foreach (DataTransfer transfer in transfers)
        {
            Task pauseTask = transferManager.PauseTransferIfRunningAsync(transfer.Id);
            if (pauseLocation == PauseLocation.PauseProcessStart)
            {
                Assert.That(DataTransferState.Pausing, Is.EqualTo(transfer.TransferStatus.State), "Error in transitioning to Pausing state");
            }
            else
            {
                Assert.That(transfer.TransferStatus.State,
                    Is.AnyOf(DataTransferState.Pausing, DataTransferState.Completed),
                    "Error: Transfer state for PauseProcessHalfway should be either Pausing or Completed");
            }
        }

        // Process (the rest of) chunks
        await chunksProcessor.StepAll();

        await Task.Delay(50);
        var jobsStateCount = GetJobsStateCount(transfers, checkpointer);
        int pausedJobsCount = jobsStateCount[DataTransferState.Paused];
        int completedJobsCount = jobsStateCount[DataTransferState.Completed];
        var partsStateCount = GetJobPartsStateCount(transfers, checkpointer);
        int pausedPartsCount = partsStateCount[DataTransferState.Paused];
        int completedPartsCount = partsStateCount[DataTransferState.Completed];

        if (pauseLocation == PauseLocation.PauseProcessHalfway)
        {
            // For this test, job parts is 1:1 with job chunks
            Assert.That(pausedPartsCount, Is.EqualTo(numJobParts / 2), "Error in Pausing half");
            Assert.That(completedPartsCount, Is.EqualTo(numJobParts / 2), "Error in Pausing half");
        }
        else
        {
            Assert.That(pausedJobsCount, Is.EqualTo(numJobs), "Error in Pausing all");
            Assert.That(completedJobsCount, Is.EqualTo(0), "Error in Pausing all");
            Assert.That(pausedPartsCount, Is.EqualTo(numJobParts), "Error in Pausing all");
            Assert.That(completedPartsCount, Is.EqualTo(0), "Error in Pausing all");
        }
    }

    public enum PauseLocation
    {
        PauseProcessHalfway,
        PauseProcessStart
    }
}
