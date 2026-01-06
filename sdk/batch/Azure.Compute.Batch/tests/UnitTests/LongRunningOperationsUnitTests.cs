// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Moq;
using NUnit.Framework;
using Org.BouncyCastle.Asn1.Cms;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class LongRunningOperationsUnitTests
    {
        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task DeallocateNodeOperations_Normal()
        {
            // Arrange
            var mockResponse1 = new MockResponse(200).AddHeader("Retry-After", "0");
            var mockResponse = new Mock<Azure.Response>();
            string NodeId = "node1";
            string poolId = "pool1";
            int CallsToGetNode = 0;

            // Example fix for BatchNode constructor calls with <null> DateTimeOffset arguments
            BatchNode batchNodeDeallocating = new BatchNode(
                NodeId,
                null,
                BatchNodeState.Deallocating,
                null,
                DateTimeOffset.Now,
                DateTimeOffset.MinValue, // Fix: Use DateTimeOffset.MinValue instead of null
                DateTimeOffset.MinValue, // Fix: Use DateTimeOffset.MinValue instead of null
                null,
                null,
                "affinityId",
                "vmSize",
                0, 0, 0, 0,
                null, null, null, null, null, null, null, null, null
            );

            BatchNode batchNodeDeallocated = new BatchNode(
                NodeId,
                null,
                BatchNodeState.Deallocated,
                null,
                DateTimeOffset.Now,
                DateTimeOffset.MinValue, // Fix: Use DateTimeOffset.MinValue instead of null
                DateTimeOffset.MinValue, // Fix: Use DateTimeOffset.MinValue instead of null
                null,
                null,
                "affinityId",
                "vmSize",
                0, 0, 0, 0,
                null, null, null, null, null, null, null, null, null
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGetNode++ <= 2)
                 {
                     // return a node that is Deallocating
                     return Response.FromValue(batchNodeDeallocating, mockResponse1);
                 }
                 else
                 {
                     return Response.FromValue(batchNodeDeallocated, mockResponse1);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeallocateNodeOperation deallocateNodeOperation = new DeallocateNodeOperation(batchClient, NodeId + ";" + poolId);
            await deallocateNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deallocateNodeOperation.HasCompleted, Is.True);
                Assert.That(deallocateNodeOperation.HasValue, Is.True);
                Assert.That(deallocateNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(deallocateNodeOperation.Value.State, Is.EqualTo(BatchNodeState.Deallocated));
            });
        }

        [Test]
        /// <summary>
        /// Verify that if we get a not found exception we will still return
        /// </summary>
        public async Task DeallocateNodeOperations_NotFound()
        {
            // Arrange
            var mockResponse1 = new MockResponse(200).AddHeader("Retry-After", "0");
            var mockResponse = new Mock<Azure.Response>();
            string NodeId = "node1";
            string poolId = "pool1";

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.NodeNotFound.ToString(), null);
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeallocateNodeOperation deallocateNodeOperation = new DeallocateNodeOperation(batchClient, NodeId + ";" + poolId);
            await deallocateNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deallocateNodeOperation.HasCompleted, Is.True);
                Assert.That(deallocateNodeOperation.HasValue, Is.False);
            });
        }

        [Test]
        /// <summary>
        /// Verify that if we get a not found exception we will still return
        /// </summary>
        public async Task DeallocateNodeOperations_InternalError()
        {
            // Arrange
            var mockResponse1 = new MockResponse(200).AddHeader("Retry-After", "0");
            var mockResponse = new Mock<Azure.Response>();
            string NodeId = "node1";
            string poolId = "pool1";
            int CallsToGetNode = 0;

            BatchNode batchNodeDeallocated = new BatchNode(NodeId, null, BatchNodeState.Deallocated, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null,"affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGetNode++ <= 1)
                 {
                     // return a node that is Deallocating
                     throw new RequestFailedException(status: 500, message: "Internal Server Error", errorCode: BatchErrorCode.InternalError.ToString(), null);
                 }
                 else
                 {
                     return Response.FromValue(batchNodeDeallocated, mockResponse1);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeallocateNodeOperation deallocateNodeOperation = new DeallocateNodeOperation(batchClient, NodeId + ";" + poolId);

            try
            {
                await deallocateNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

                // Assert
                Assert.Fail("Expected RequestFailedException");
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Status, Is.EqualTo(500));
                // Assert
                Assert.Pass();
            }
        }

        [Test]
        /// <summary>
        /// Verify that if we get a not found exception we will still return
        /// </summary>
        public async Task DeallocateNodeOperations_ServiceBusy()
        {
            // Arrange
            var mockResponse1 = new MockResponse(200).AddHeader("Retry-After", "0");
            var mockResponse = new Mock<Azure.Response>();
            string NodeId = "node1";
            string poolId = "pool1";
            int CallsToGetNode = 0;

            BatchNode batchNodeDeallocated = new BatchNode(NodeId, null, BatchNodeState.Deallocated, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGetNode++ <= 1)
                 {
                     // return a node that is Deallocating
                     throw new RequestFailedException(status: 429, message: "Internal Server Error", errorCode: BatchErrorCode.ServerBusy.ToString(), null);
                 }
                 else
                 {
                     return Response.FromValue(batchNodeDeallocated, mockResponse1);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeallocateNodeOperation deallocateNodeOperation = new DeallocateNodeOperation(batchClient, NodeId + ";" + poolId);

            try
            {
                await deallocateNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

                // Assert
                Assert.Fail("Expected RequestFailedException");
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Status, Is.EqualTo(429));
                // Assert
                Assert.Pass();
            }
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job flow succeeds
        /// </summary>
        public async Task DeleteJobOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJob batchJob =    new BatchJob(JobId, null, null,default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobState.Completed, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions,CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.JobNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteJobOperation deleteJobOperation = new DeleteJobOperation(batchClient, JobId);
            await deleteJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deleteJobOperation.HasCompleted, Is.True);
                Assert.That(deleteJobOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job flow succeeds
        /// </summary>
        public async Task DeleteJobOperation_NewState()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;
            DateTimeOffset creationTime = DateTimeOffset.UtcNow;

            BatchJob batchJob =    new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, creationTime, BatchJobState.Completed, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobNew = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, creationTime, BatchJobState.Completed, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
               It.IsAny<string>(),
               It.IsAny<TimeSpan?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<RequestConditions>(),
               It.IsAny<IEnumerable<string>>(),
               It.IsAny<IEnumerable<string>>(),
               It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteJobOperation deleteJobOperation = new DeleteJobOperation(batchClient, JobId);
            await deleteJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deleteJobOperation.HasCompleted, Is.True);
                Assert.That(deleteJobOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that delete job flow succeeds if job is replaced
        /// </summary>
        public async Task DeleteJobOperation_NewInstance()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJob batchJob = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, default(BatchJobState),                         DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobNew = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(1), default(BatchJobState), DateTimeOffset.UtcNow.AddHours(1), null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
              It.IsAny<string>(),
              It.IsAny<TimeSpan?>(),
              It.IsAny<DateTimeOffset?>(),
              It.IsAny<RequestConditions>(),
              It.IsAny<IEnumerable<string>>(),
              It.IsAny<IEnumerable<string>>(),
              It.IsAny<CancellationToken>())
            )
            .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteJobOperation deleteJobOperation = new DeleteJobOperation(batchClient, JobId);
            await deleteJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deleteJobOperation.HasCompleted, Is.True);
                Assert.That(deleteJobOperation.HasValue, Is.True);
                Assert.That(deleteJobOperation.Value, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job schedule flow succeeds
        /// </summary>
        public async Task DeleteJobScheduleOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJobSchedule batchJobSchedule = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobScheduleState.Deleting, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJobSchedule, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.JobScheduleNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteJobScheduleOperation deleteJobScheduleOperation = new DeleteJobScheduleOperation(batchClient, JobId);
            await deleteJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deleteJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(deleteJobScheduleOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job schedule flow succeeds
        /// </summary>
        public async Task TerminateJobScheduleOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJobSchedule batchJobScheduleTerminating = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobScheduleState.Terminating, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleActive = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobScheduleState.Active, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchJobScheduleTerminating, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobScheduleActive, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            TerminateJobScheduleOperation terminateJobScheduleOperation = new TerminateJobScheduleOperation(batchClient, JobId);
            await terminateJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(terminateJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(terminateJobScheduleOperation.HasValue, Is.True);
                Assert.That(terminateJobScheduleOperation.Value, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job schedule flow succeeds
        /// </summary>
        public async Task TerminateJobScheduleOperation_NewJobSchedule()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJobSchedule batchJobScheduleTerminating = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobScheduleState.Terminating, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleActive = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow.AddHours(1), DateTimeOffset.UtcNow.AddHours(1), BatchJobScheduleState.Active, DateTimeOffset.UtcNow.AddHours(1), null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchJobScheduleTerminating, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobScheduleActive, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            TerminateJobScheduleOperation terminateJobScheduleOperation = new TerminateJobScheduleOperation(batchClient, JobId);
            await terminateJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(terminateJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(terminateJobScheduleOperation.HasValue, Is.True);
                Assert.That(terminateJobScheduleOperation.Value, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job schedule flow succeeds
        /// </summary>
        public async Task TerminateJobScheduleOperation_DeletedJobSchedule()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJobSchedule batchJobScheduleTerminating = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobScheduleState.Terminating, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleActive = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow.AddHours(1), DateTimeOffset.UtcNow.AddHours(1), BatchJobScheduleState.Active, DateTimeOffset.UtcNow.AddHours(1), null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchJobScheduleTerminating, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.JobScheduleNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            TerminateJobScheduleOperation terminateJobScheduleOperation = new TerminateJobScheduleOperation(batchClient, JobId);
            await terminateJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(terminateJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(terminateJobScheduleOperation.HasValue, Is.True);
                Assert.That(terminateJobScheduleOperation.Value, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job schedule flow succeeds
        /// </summary>
        public async Task DeleteJobScheduleOperation_NewInstancel()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJobSchedule batchJobSchedule = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobScheduleState.Deleting, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleNew = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.UtcNow.AddHours(1), DateTimeOffset.UtcNow.AddHours(1), BatchJobScheduleState.Active, DateTimeOffset.UtcNow.AddHours(1), null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                 It.IsAny<string>(),
                 It.IsAny<TimeSpan?>(),
                 It.IsAny<DateTimeOffset?>(),
                 It.IsAny<RequestConditions>(),
                 It.IsAny<IEnumerable<string>>(),
                 It.IsAny<IEnumerable<string>>(),
                 It.IsAny<CancellationToken>())
             )
              .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchJobSchedule, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobScheduleNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteJobScheduleOperation deleteJobScheduleOperation = new DeleteJobScheduleOperation(batchClient, JobId);
            await deleteJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deleteJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(deleteJobScheduleOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job schedule flow succeeds
        /// </summary>
        public async Task DeleteJobScheduleOperation_NewState()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;
            DateTimeOffset creationTime = DateTimeOffset.UtcNow;

            BatchJobSchedule batchJobSchedule = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.Now, creationTime, BatchJobScheduleState.Deleting, DateTimeOffset.Now, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleNew = new BatchJobSchedule(JobId, null, null, default(ETag), DateTimeOffset.Now, creationTime, BatchJobScheduleState.Active, DateTimeOffset.Now, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                 It.IsAny<string>(),
                 It.IsAny<TimeSpan?>(),
                 It.IsAny<DateTimeOffset?>(),
                 It.IsAny<RequestConditions>(),
                 It.IsAny<IEnumerable<string>>(),
                 It.IsAny<IEnumerable<string>>(),
                 It.IsAny<CancellationToken>())
             )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJobSchedule, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobScheduleNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteJobScheduleOperation deleteJobScheduleOperation = new DeleteJobScheduleOperation(batchClient, JobId);
            await deleteJobScheduleOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deleteJobScheduleOperation.HasCompleted, Is.True);
                Assert.That(deleteJobScheduleOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete pool flow succeeds
        /// </summary>
        public async Task DeletePoolOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string PoolID = "pool";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Deleting,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                null, // AllocationState
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.PoolNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeletePoolOperation deletePoolOperation = new DeletePoolOperation(batchClient, PoolID);
            await deletePoolOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deletePoolOperation.HasCompleted, Is.True);
                Assert.That(deletePoolOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete pool flow succeeds if a new instances is found
        /// </summary>
        public async Task DeletePoolOperation_NewInstance()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string PoolID = "pool";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Deleting,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                null, // AllocationState
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolNew = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow.AddMinutes(1), // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow.AddMinutes(1), // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow.AddMinutes(1), // StateTransitionTime (fix for CS1503: Argument 8)
                null, // AllocationState
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchPoolNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeletePoolOperation deletePoolOperation = new DeletePoolOperation(batchClient, PoolID);
            await deletePoolOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deletePoolOperation.HasCompleted, Is.True);
                Assert.That(deletePoolOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete pool flow succeeds if a new instances is found
        /// </summary>
        public async Task DeletePoolOperation_NewState()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string PoolID = "pool";
            int CallsToGet = 0;
            DateTimeOffset creationTime = DateTimeOffset.UtcNow;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                creationTime, // LastModified (fix for CS1503: Argument 5)
                creationTime, // CreationTime
                BatchPoolState.Deleting,
                creationTime, // StateTransitionTime (fix for CS1503: Argument 8)
                null, // AllocationState
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolNew = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                creationTime.AddHours(1), // LastModified (fix for CS1503: Argument 5)
                creationTime.AddHours(1), // CreationTime
                BatchPoolState.Active,
                creationTime.AddHours(1), // StateTransitionTime (fix for CS1503: Argument 8)
                null, // AllocationState
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchPoolNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeletePoolOperation deletePoolOperation = new DeletePoolOperation(batchClient, PoolID);
            await deletePoolOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(deletePoolOperation.HasCompleted, Is.True);
                Assert.That(deletePoolOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal disabling of job flow succeeds
        /// </summary>
        public async Task DisableJobOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJob batchJob =         new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobState.Disabling, DateTimeOffset.UtcNow, BatchJobState.Disabling, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobFinished = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobState.Active, DateTimeOffset.UtcNow, BatchJobState.Active, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobFinished, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DisableJobOperation disableJobOperation = new DisableJobOperation(batchClient, JobId);
            await disableJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(disableJobOperation.HasCompleted, Is.True);
                Assert.That(disableJobOperation.HasValue, Is.True);
                Assert.That(BatchJobState.Active, Is.EqualTo(disableJobOperation.Value.State));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal disabling of job flow succeeds
        /// </summary>
        public async Task EnableJobOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJob batchJob = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobState.Enabling, DateTimeOffset.UtcNow, BatchJobState.Enabling, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobFinished = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, BatchJobState.Active, DateTimeOffset.UtcNow, BatchJobState.Active, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobFinished, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            EnableJobOperation enableJobOperation = new EnableJobOperation(batchClient, JobId);
            await enableJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(enableJobOperation.HasCompleted, Is.True);
                Assert.That(enableJobOperation.HasValue, Is.True);
                Assert.That(BatchJobState.Active, Is.EqualTo(enableJobOperation.Value.State));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task RebootNodeOperation_Normal()
        {
            // Arrange
            var mockResponse1 = new MockResponse(200).AddHeader("Retry-After", "0");
            var mockResponse = new Mock<Azure.Response>();
            string NodeId = "node1";
            string poolId = "pool1";
            int CallsToGetNode = 0;

            BatchNode batchNodeRebooting = new BatchNode(NodeId, null, BatchNodeState.Rebooting, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeIdle = new BatchNode(NodeId, null, BatchNodeState.Idle, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGetNode++ <= 2)
                 {
                     return Response.FromValue(batchNodeRebooting, mockResponse1);
                 }
                 else
                 {
                     return Response.FromValue(batchNodeIdle, mockResponse1);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            RebootNodeOperation rebootNodeOperation = new RebootNodeOperation(batchClient, NodeId + ";" + poolId);
            await rebootNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(rebootNodeOperation.HasCompleted, Is.True);
                Assert.That(rebootNodeOperation.HasValue, Is.True);
                Assert.That(rebootNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(rebootNodeOperation.Value.State, Is.EqualTo(BatchNodeState.Idle));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task ReimageNodeOperation_Normal()
        {
            // Arrange
            var mockResponse1 = new MockResponse(200).AddHeader("Retry-After", "0");
            var mockResponse = new Mock<Azure.Response>();
            string NodeId = "node1";
            string poolId = "pool1";
            int CallsToGetNode = 0;

            BatchNode batchNodeRebooting = new BatchNode(NodeId, null, BatchNodeState.Reimaging, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeIdle = new BatchNode(NodeId, null, BatchNodeState.Idle, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGetNode++ <= 2)
                 {
                     return Response.FromValue(batchNodeRebooting, mockResponse1);
                 }
                 else
                 {
                     return Response.FromValue(batchNodeIdle, mockResponse1);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            ReimageNodeOperation reimageNodeOperation = new ReimageNodeOperation(batchClient, NodeId + ";" + poolId);
            await reimageNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(reimageNodeOperation.HasCompleted, Is.True);
                Assert.That(reimageNodeOperation.HasValue, Is.True);
                Assert.That(reimageNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(reimageNodeOperation.Value.State, Is.EqualTo(BatchNodeState.Idle));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task RemoveNodesOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string NodeId = "node1";
            string PoolID = "pool1";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Resizing,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolFinished = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Steady,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchPoolFinished, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            RemoveNodesOperation removeNodesOperation = new RemoveNodesOperation(batchClient, NodeId + ";" + PoolID);
            await removeNodesOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(removeNodesOperation.HasCompleted, Is.True);
                Assert.That(removeNodesOperation.HasValue, Is.True);
                Assert.That(removeNodesOperation.GetRawResponse().IsError, Is.False);
                Assert.That(removeNodesOperation.Value.AllocationState, Is.EqualTo(AllocationState.Steady));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task RemoveNodesOperation_PoolDeleted()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string NodeId = "node1";
            string PoolID = "pool1";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Resizing,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolFinished = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Steady,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.PoolNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            RemoveNodesOperation removeNodesOperation = new RemoveNodesOperation(batchClient, NodeId + ";" + PoolID);
            await removeNodesOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(removeNodesOperation.HasCompleted, Is.True);
                Assert.That(removeNodesOperation.HasValue, Is.False);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task ResizePoolOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string NodeId = "node1";
            string PoolID = "pool1";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Resizing,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolFinished = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Steady,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchPoolFinished, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            ResizePoolOperation resizePoolOperation = new ResizePoolOperation(batchClient, NodeId + ";" + PoolID);
            await resizePoolOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(resizePoolOperation.HasCompleted, Is.True);
                Assert.That(resizePoolOperation.HasValue, Is.True);
                Assert.That(resizePoolOperation.GetRawResponse().IsError, Is.False);
                Assert.That(resizePoolOperation.Value.AllocationState, Is.EqualTo(AllocationState.Steady));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task StartNodeOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string NodeId = "node1";
            string PoolID = "pool1";
            int CallsToGet = 0;

            BatchNode batchNodeStarting = new BatchNode(NodeId, null, BatchNodeState.Starting, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeIdle = new BatchNode(NodeId, null, BatchNodeState.Idle, null, DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetNodeAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string poolId, string nodeId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 1)
                 {
                     return Response.FromValue(batchNodeStarting, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchNodeIdle, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            StartNodeOperation startNodeOperation = new StartNodeOperation(batchClient, NodeId + ";" + PoolID);
            await startNodeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(startNodeOperation.HasCompleted, Is.True);
                Assert.That(startNodeOperation.HasValue, Is.True);
                Assert.That(startNodeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(startNodeOperation.Value.State, Is.EqualTo(BatchNodeState.Idle));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task StopPoolResizeOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string NodeId = "node1";
            string PoolID = "pool1";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Stopping,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolFinished = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Steady,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchPoolFinished, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            StopPoolResizeOperation stopPoolResizeOperation = new StopPoolResizeOperation(batchClient, NodeId + ";" + PoolID);
            await stopPoolResizeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(stopPoolResizeOperation.HasCompleted, Is.True);
                Assert.That(stopPoolResizeOperation.HasValue, Is.True);
                Assert.That(stopPoolResizeOperation.GetRawResponse().IsError, Is.False);
                Assert.That(stopPoolResizeOperation.Value.AllocationState, Is.EqualTo(AllocationState.Steady));
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal Deallocation flow succeeds
        /// </summary>
        public async Task StopPoolResizeOperation_PoolDeleted()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string NodeId = "node1";
            string PoolID = "pool1";
            int CallsToGet = 0;

            BatchPool batchPool = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Stopping,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );
            BatchPool batchPoolFinished = new BatchPool(
                PoolID,
                null, // DisplayName
                null, // Uri
                default(ETag), // ETag (fix for CS1503: Argument 4)
                DateTimeOffset.UtcNow, // LastModified (fix for CS1503: Argument 5)
                DateTimeOffset.UtcNow, // CreationTime
                BatchPoolState.Active,
                DateTimeOffset.UtcNow, // StateTransitionTime (fix for CS1503: Argument 8)
                AllocationState.Steady,
                null, // AllocationStateTransitionTime
                null, // VmSize
                null, // VirtualMachineConfiguration
                null, // ResizeTimeout
                null, // ResizeErrors
                0,    // CurrentDedicatedNodes (fix for CS1503: Argument 15)
                0,    // CurrentLowPriorityNodes (fix for CS1503: Argument 16)
                null, // TargetDedicatedNodes
                null, // TargetLowPriorityNodes
                null, // EnableAutoScale
                null, // AutoScaleFormula
                null, // AutoScaleEvaluationInterval
                null, // AutoScaleRun
                null, // EnableInterNodeCommunication
                null, // NetworkConfiguration
                null, // StartTask
                null, // ApplicationPackageReferences
                null, // TaskSlotsPerNode
                null, // TaskSchedulingPolicy
                null, // UserAccounts
                null, // Metadata
                null, // PoolStatistics
                null, // MountConfiguration
                null, // Identity
                null, // UpgradePolicy
                null  // serializedAdditionalRawData
            );

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     return Response.FromValue(batchPool, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.PoolNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            StopPoolResizeOperation stopPoolResizeOperation = new StopPoolResizeOperation(batchClient, NodeId + ";" + PoolID);
            await stopPoolResizeOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(stopPoolResizeOperation.HasCompleted, Is.True);
                Assert.That(stopPoolResizeOperation.HasValue, Is.False);
            });
        }

        [Test]
        /// <summary>
        /// Verify that normal delete job flow succeeds
        /// </summary>
        public async Task TerminateJobOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJob batchJob = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, default(BatchJobState), DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions,CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.JobNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            TerminateJobOperation terminateJobOperation = new TerminateJobOperation(batchClient, JobId);
            await terminateJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(terminateJobOperation.HasCompleted, Is.True);
                Assert.That(terminateJobOperation.HasValue, Is.True);
            });
        }

        [Test]
        /// <summary>
        /// Verify that delete job flow succeeds if job is replaced
        /// </summary>
        public async Task TerminateJobOperation_NewInstance()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string JobId = "job";
            int CallsToGet = 0;

            BatchJob batchJob = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, default(BatchJobState), DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobNew = new BatchJob(JobId, null, null, default(Uri), default(ETag), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(1), default(BatchJobState), DateTimeOffset.UtcNow.AddHours(1), null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<RequestConditions>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchJob, mockResponse);
                 }
                 else
                 {
                     return Response.FromValue(batchJobNew, mockResponse);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            TerminateJobOperation terminateJobOperation = new TerminateJobOperation(batchClient, JobId);
            await terminateJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(terminateJobOperation.HasCompleted, Is.True);
                Assert.That(terminateJobOperation.HasValue, Is.True);
                Assert.That(terminateJobOperation.Value, Is.True);
            });
        }
    }
}
