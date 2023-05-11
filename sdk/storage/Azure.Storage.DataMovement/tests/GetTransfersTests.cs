// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// These tests aim to test the <see cref="TransferManager.GetTransfers(StorageTransferStatus)"/>
    /// </summary>
    public class GetTransfersTests
    {
        [Test]
        public void GetTransfers_Empty()
        {
            // Arrange
            TransferManager transferManager = new TransferManager();

            // Act
            List<DataTransfer> transfers = transferManager.GetTransfers().ToList();

            // Assert
            Assert.IsEmpty(transfers);
        }

        [Test]
        public void GetTransfers_Populated()
        {
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                new DataTransfer(),
                new DataTransfer(),
                new DataTransfer(),
            };
            TransferManagerFactory factory = new TransferManagerFactory(storedTransfers);
            TransferManager manager = factory.BuildTransferManager();

            // Act
            List<DataTransfer> result = manager.GetTransfers().ToList();

            // Assert
            Assert.AreEqual(storedTransfers, result);
        }

        [Test]
        [TestCase(StorageTransferStatus.Queued)]
        [TestCase(StorageTransferStatus.InProgress)]
        [TestCase(StorageTransferStatus.Paused)]
        [TestCase(StorageTransferStatus.Completed)]
        [TestCase(StorageTransferStatus.CompletedWithFailedTransfers)]
        public void GetTransfers_Filtered(StorageTransferStatus status)
        {
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.InProgress),
                new DataTransfer(StorageTransferStatus.InProgress),
                new DataTransfer(StorageTransferStatus.Paused),
                new DataTransfer(StorageTransferStatus.Paused),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.Completed),
                new DataTransfer(StorageTransferStatus.Completed),
            };
            TransferManagerFactory factory = new TransferManagerFactory(storedTransfers);
            TransferManager manager = factory.BuildTransferManager();

            // Act
            StorageTransferStatus[] statuses = new StorageTransferStatus[] { status };
            List<DataTransfer> result = manager.GetTransfers(statuses).ToList();

            // Assert
            Assert.AreEqual(storedTransfers.Where( d => d.TransferStatus == status).ToList(), result);
        }

        public void GetTransfers_FilterMultipleStatuses()
        {
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.InProgress),
                new DataTransfer(StorageTransferStatus.InProgress),
                new DataTransfer(StorageTransferStatus.Paused),
                new DataTransfer(StorageTransferStatus.Paused),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.Completed),
                new DataTransfer(StorageTransferStatus.Completed),
                new DataTransfer(StorageTransferStatus.CompletedWithSkippedTransfers)
            };
            TransferManagerFactory factory = new TransferManagerFactory(storedTransfers);
            TransferManager manager = factory.BuildTransferManager();

            // Act
            StorageTransferStatus[] statuses = new StorageTransferStatus[] {
                StorageTransferStatus.Completed,
                StorageTransferStatus.CompletedWithFailedTransfers,
                StorageTransferStatus.CompletedWithSkippedTransfers };
            List<DataTransfer> result = manager.GetTransfers(statuses).ToList();

            // Assert
            Assert.AreEqual(storedTransfers.Where(d => statuses.Contains(d.TransferStatus)).ToList(), result);
        }

        [Test]
        public void GetTransfers_Filtered_Empty()
        {
            // Arrange - Set up transfer manager with multiple transfers
            List<DataTransfer> storedTransfers = new List<DataTransfer>
            {
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.Queued),
                new DataTransfer(StorageTransferStatus.InProgress),
                new DataTransfer(StorageTransferStatus.InProgress),
                new DataTransfer(StorageTransferStatus.Paused),
                new DataTransfer(StorageTransferStatus.Paused),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.CompletedWithFailedTransfers),
                new DataTransfer(StorageTransferStatus.Completed),
                new DataTransfer(StorageTransferStatus.Completed),
            };
            TransferManagerFactory factory = new TransferManagerFactory(storedTransfers);
            TransferManager manager = factory.BuildTransferManager();

            // Act - With a transfer status not in the above stored transfers
            StorageTransferStatus[] statuses = new StorageTransferStatus[] { StorageTransferStatus.CancellationInProgress };
            List<DataTransfer> result = manager.GetTransfers(statuses).ToList();

            // Assert
            Assert.IsEmpty(result);
        }
    }
}
