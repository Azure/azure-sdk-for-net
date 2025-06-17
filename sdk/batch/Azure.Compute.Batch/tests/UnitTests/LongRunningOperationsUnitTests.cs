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
        /// Verify that normal delete certificate flow succeeds
        /// </summary>
        public async Task DeleteCertificateOperation_Normal()
        {
            // Arrange
            var mockResponse = new MockResponse(200).AddHeader("Retry-After", "0");
            string Thumbprint = "thumbprint";
            string ThumbprintAlgorithm = "thumbprintAlgorithm";
            int CallsToGetCertificate = 0;

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
                 if (CallsToGetCertificate++ <= 2)
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
            int CallsToGetCertificate = 0;

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
             .ReturnsAsync((string jobId, TimeSpan? timeOutInSeconds, DateTimeOffset? ocpDate, IEnumerable<string> select, IEnumerable<string> expand, RequestConditions requestConditions,CancellationToken cancellationToken) =>
             {
                 if (CallsToGetCertificate++ <= 2)
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
    }
}
