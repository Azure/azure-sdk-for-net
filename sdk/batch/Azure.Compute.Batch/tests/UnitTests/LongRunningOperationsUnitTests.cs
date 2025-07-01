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

            BatchNode batchNodeDeallocating = new BatchNode(NodeId, null, BatchNodeState.Deallocating, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeDeallocated = new BatchNode(NodeId, null, BatchNodeState.Deallocated, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);

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

            // Assert
            Assert.IsTrue(deallocateNodeOperation.HasCompleted);
            Assert.IsTrue(deallocateNodeOperation.HasValue);
            Assert.IsFalse(deallocateNodeOperation.GetRawResponse().IsError);
            Assert.AreEqual(BatchNodeState.Deallocated, deallocateNodeOperation.Value.State);
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

            // Assert
            Assert.IsTrue(deallocateNodeOperation.HasCompleted);
            Assert.IsFalse(deallocateNodeOperation.HasValue);
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

            BatchNode batchNodeDeallocated = new BatchNode(NodeId, null, BatchNodeState.Deallocated, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);

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
                Assert.AreEqual(ex.Status, 500);
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

            BatchNode batchNodeDeallocated = new BatchNode(NodeId, null, BatchNodeState.Deallocated, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);

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
                Assert.AreEqual(ex.Status, 429);
                // Assert
                Assert.Pass();
            }
        }

        [Test]
        /// <summary>
        /// Verify that normal delete certificate flow succeeds
        /// </summary>
        public async Task DeleteCertificateOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string Thumbprint = "thumbprint";
            string ThumbprintAlgorithm = "thumbprintAlgorithm";
            int CallsToGet = 0;

            BatchCertificate batchCertificate = new BatchCertificate(Thumbprint, ThumbprintAlgorithm, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetCertificateAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>())
            )
             .ReturnsAsync((string thumbprintAlgorithm, string thumbprint, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, CancellationToken cancellationToken) =>
             {
                 if (CallsToGet++ <= 2)
                 {
                     // return a certificate that is deleting
                     return Response.FromValue(batchCertificate, mockResponse);
                 }
                 else
                 {
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.CertificateNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            DeleteCertificateOperation deleteCertificateOperation = new DeleteCertificateOperation(batchClient, Thumbprint + ";" + ThumbprintAlgorithm);
            await deleteCertificateOperation.WaitForCompletionAsync().ConfigureAwait(false);

            // Assert
            Assert.IsTrue(deleteCertificateOperation.HasCompleted);
            Assert.IsTrue(deleteCertificateOperation.HasValue);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, BatchJobState.Deleting, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deleteJobOperation.HasCompleted);
            Assert.IsTrue(deleteJobOperation.HasValue);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, creationTime, BatchJobState.Deleting, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobNew = new BatchJob(JobId, null, null, null, null, null, creationTime, BatchJobState.Completed, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deleteJobOperation.HasCompleted);
            Assert.IsTrue(deleteJobOperation.HasValue);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, BatchJobState.Deleting, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobNew = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow.AddHours(1), BatchJobState.Active, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deleteJobOperation.HasCompleted);
            Assert.IsTrue(deleteJobOperation.HasValue);
            Assert.IsTrue(deleteJobOperation.Value);
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

            BatchJobSchedule batchJobSchedule = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow, BatchJobScheduleState.Deleting, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deleteJobScheduleOperation.HasCompleted);
            Assert.IsTrue(deleteJobScheduleOperation.HasValue);
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

            BatchJobSchedule batchJobScheduleTerminating = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow, BatchJobScheduleState.Terminating, null, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleActive = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow, BatchJobScheduleState.Active, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(terminateJobScheduleOperation.HasCompleted);
            Assert.IsTrue(terminateJobScheduleOperation.HasValue);
            Assert.IsTrue(terminateJobScheduleOperation.Value);
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

            BatchJobSchedule batchJobScheduleTerminating = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow, BatchJobScheduleState.Terminating, null, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleActive = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow.AddHours(1), BatchJobScheduleState.Active, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(terminateJobScheduleOperation.HasCompleted);
            Assert.IsTrue(terminateJobScheduleOperation.HasValue);
            Assert.IsTrue(terminateJobScheduleOperation.Value);
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

            BatchJobSchedule batchJobScheduleTerminating = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow, BatchJobScheduleState.Terminating, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(terminateJobScheduleOperation.HasCompleted);
            Assert.IsTrue(terminateJobScheduleOperation.HasValue);
            Assert.IsTrue(terminateJobScheduleOperation.Value);
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

            BatchJobSchedule batchJobSchedule = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow, BatchJobScheduleState.Deleting, null, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleNew = new BatchJobSchedule(JobId, null, null, null, null, DateTimeOffset.UtcNow.AddHours(1), BatchJobScheduleState.Active, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deleteJobScheduleOperation.HasCompleted);
            Assert.IsTrue(deleteJobScheduleOperation.HasValue);
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

            BatchJobSchedule batchJobSchedule = new BatchJobSchedule(JobId, null, null, null, null, creationTime, BatchJobScheduleState.Deleting, null, null, null, null, null, null, null, null, null);
            BatchJobSchedule batchJobScheduleNew = new BatchJobSchedule(JobId, null, null, null, null, creationTime, BatchJobScheduleState.Active, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobScheduleAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deleteJobScheduleOperation.HasCompleted);
            Assert.IsTrue(deleteJobScheduleOperation.HasValue);
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

            BatchPool batchPool = new BatchPool(PoolID, null,null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Deleting, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null,null, null,null,null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deletePoolOperation.HasCompleted);
            Assert.IsTrue(deletePoolOperation.HasValue);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Deleting, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolNew = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow.AddMinutes(1), BatchPoolState.Active, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deletePoolOperation.HasCompleted);
            Assert.IsTrue(deletePoolOperation.HasValue);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, creationTime, BatchPoolState.Deleting, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolNew = new BatchPool(PoolID, null, null, null, null, creationTime, BatchPoolState.Active, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(deletePoolOperation.HasCompleted);
            Assert.IsTrue(deletePoolOperation.HasValue);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, BatchJobState.Disabling, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobFinished = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, BatchJobState.Active, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(disableJobOperation.HasCompleted);
            Assert.IsTrue(disableJobOperation.HasValue);
            Assert.AreEqual(disableJobOperation.Value.State, BatchJobState.Active);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, BatchJobState.Enabling, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobFinished = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, BatchJobState.Active, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(enableJobOperation.HasCompleted);
            Assert.IsTrue(enableJobOperation.HasValue);
            Assert.AreEqual(enableJobOperation.Value.State, BatchJobState.Active);
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

            BatchNode batchNodeRebooting = new BatchNode(NodeId, null, BatchNodeState.Rebooting, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeIdle = new BatchNode(NodeId, null, BatchNodeState.Idle, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);

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

            // Assert
            Assert.IsTrue(rebootNodeOperation.HasCompleted);
            Assert.IsTrue(rebootNodeOperation.HasValue);
            Assert.IsFalse(rebootNodeOperation.GetRawResponse().IsError);
            Assert.AreEqual(BatchNodeState.Idle, rebootNodeOperation.Value.State);
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

            BatchNode batchNodeRebooting = new BatchNode(NodeId, null, BatchNodeState.Reimaging, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeIdle = new BatchNode(NodeId, null, BatchNodeState.Idle, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);

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

            // Assert
            Assert.IsTrue(reimageNodeOperation.HasCompleted);
            Assert.IsTrue(reimageNodeOperation.HasValue);
            Assert.IsFalse(reimageNodeOperation.GetRawResponse().IsError);
            Assert.AreEqual(BatchNodeState.Idle, reimageNodeOperation.Value.State);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Resizing, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolFinished = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Steady, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(removeNodesOperation.HasCompleted);
            Assert.IsTrue(removeNodesOperation.HasValue);
            Assert.IsFalse(removeNodesOperation.GetRawResponse().IsError);
            Assert.AreEqual(AllocationState.Steady, removeNodesOperation.Value.AllocationState);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Resizing, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolFinished = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Steady, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(removeNodesOperation.HasCompleted);
            Assert.IsFalse(removeNodesOperation.HasValue);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Resizing, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolFinished = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Steady, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(resizePoolOperation.HasCompleted);
            Assert.IsTrue(resizePoolOperation.HasValue);
            Assert.IsFalse(resizePoolOperation.GetRawResponse().IsError);
            Assert.AreEqual(AllocationState.Steady, resizePoolOperation.Value.AllocationState);
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

            BatchNode batchNodeStarting = new BatchNode(NodeId, null, BatchNodeState.Starting, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);
            BatchNode batchNodeIdle = new BatchNode(NodeId, null, BatchNodeState.Idle, null, null, null, null, null, "affinityId", "vmSize", 0, 0, 0, 0, null, null, null, null, null, null, null, null, null, null);

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

            // Assert
            Assert.IsTrue(startNodeOperation.HasCompleted);
            Assert.IsTrue(startNodeOperation.HasValue);
            Assert.IsFalse(startNodeOperation.GetRawResponse().IsError);
            Assert.AreEqual(BatchNodeState.Idle, startNodeOperation.Value.State);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Stopping, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolFinished = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Steady, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(stopPoolResizeOperation.HasCompleted);
            Assert.IsTrue(stopPoolResizeOperation.HasValue);
            Assert.IsFalse(stopPoolResizeOperation.GetRawResponse().IsError);
            Assert.AreEqual(AllocationState.Steady, stopPoolResizeOperation.Value.AllocationState);
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

            BatchPool batchPool = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Stopping, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            BatchPool batchPoolFinished = new BatchPool(PoolID, null, null, null, null, DateTimeOffset.UtcNow, BatchPoolState.Active, null, AllocationState.Steady, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetPoolAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(stopPoolResizeOperation.HasCompleted);
            Assert.IsFalse(stopPoolResizeOperation.HasValue);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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
                     throw new RequestFailedException(status: 404, message: "Not Found", errorCode: BatchErrorCode.JobNotFound.ToString(), null);
                 }
             }
             );

            BatchClient batchClient = clientMock.Object;

            // Act
            TerminateJobOperation terminateJobOperation = new TerminateJobOperation(batchClient, JobId);
            await terminateJobOperation.WaitForCompletionAsync().ConfigureAwait(false);

            // Assert
            Assert.IsTrue(terminateJobOperation.HasCompleted);
            Assert.IsTrue(terminateJobOperation.HasValue);
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

            BatchJob batchJob = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow, null, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);
            BatchJob batchJobNew = new BatchJob(JobId, null, null, null, null, null, DateTimeOffset.UtcNow.AddHours(1), null, null, null, null, null, null, null, null, null, null, null, null, new BatchPoolInfo(), null, null, null, null, null, null, null);

            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.GetJobAsync(
                It.IsAny<string>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<RequestConditions>(),
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

            // Assert
            Assert.IsTrue(terminateJobOperation.HasCompleted);
            Assert.IsTrue(terminateJobOperation.HasValue);
            Assert.IsTrue(terminateJobOperation.Value);
        }
    }
}
