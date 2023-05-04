// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
            List<DataTransfer> transfers = transferManager.GetTransfers();

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
            List<DataTransfer> result = manager.GetTransfers();

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
            List<DataTransfer> result = manager.GetTransfers(status);

            // Assert
            Assert.AreEqual(storedTransfers.Where( d => d.TransferStatus == status).ToList(), result);
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
            List<DataTransfer> result = manager.GetTransfers(StorageTransferStatus.CancellationInProgress);

            // Assert
            Assert.IsEmpty(result);
        }
    }
}
