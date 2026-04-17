// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using NUnit.Framework;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    internal class BlobStorageResourceTests
    {
        [Test]
        public void Snapshot_CanBeSetAlone()
        {
            // Arrange
            var options = new BlobStorageResourceOptions();

            // Act
            options.Snapshot = "2024-01-01T00:00:00.0000000Z";

            // Assert
            Assert.AreEqual("2024-01-01T00:00:00.0000000Z", options.Snapshot);
            Assert.IsNull(options.VersionId);
        }

        [Test]
        public void VersionId_CanBeSetAlone()
        {
            // Arrange
            var options = new BlobStorageResourceOptions();

            // Act
            options.VersionId = "2024-01-01T00:00:00.0000000Z";

            // Assert
            Assert.AreEqual("2024-01-01T00:00:00.0000000Z", options.VersionId);
            Assert.IsNull(options.Snapshot);
        }

        [Test]
        public void Snapshot_ThrowsWhenVersionIdAlreadySet()
        {
            // Arrange
            var options = new BlobStorageResourceOptions
            {
                VersionId = "2024-01-01T00:00:00.0000000Z"
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                options.Snapshot = "2024-01-02T00:00:00.0000000Z";
            });

            Assert.IsTrue(ex.Message.Contains("Cannot set both snapshot and versionId"));
        }

        [Test]
        public void VersionId_ThrowsWhenSnapshotAlreadySet()
        {
            // Arrange
            var options = new BlobStorageResourceOptions
            {
                Snapshot = "2024-01-01T00:00:00.0000000Z"
            };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                options.VersionId = "2024-01-02T00:00:00.0000000Z";
            });

            Assert.IsTrue(ex.Message.Contains("Cannot set both snapshot and versionId"));
        }

        [Test]
        public void Snapshot_CanBeSetAfterVersionIdSetToNull()
        {
            // Arrange
            var options = new BlobStorageResourceOptions
            {
                VersionId = "2024-01-01T00:00:00.0000000Z"
            };
            options.VersionId = null;

            // Act
            options.Snapshot = "2024-01-02T00:00:00.0000000Z";

            // Assert
            Assert.AreEqual("2024-01-02T00:00:00.0000000Z", options.Snapshot);
            Assert.IsNull(options.VersionId);
        }

        [Test]
        public void VersionId_CanBeSetAfterSnapshotSetToNull()
        {
            // Arrange
            var options = new BlobStorageResourceOptions
            {
                Snapshot = "2024-01-01T00:00:00.0000000Z"
            };
            options.Snapshot = null;

            // Act
            options.VersionId = "2024-01-02T00:00:00.0000000Z";

            // Assert
            Assert.AreEqual("2024-01-02T00:00:00.0000000Z", options.VersionId);
            Assert.IsNull(options.Snapshot);
        }

        [Test]
        public void Snapshot_CanBeSetAfterVersionIdSetToEmptyString()
        {
            // Arrange
            var options = new BlobStorageResourceOptions
            {
                VersionId = "2024-01-01T00:00:00.0000000Z"
            };
            options.VersionId = string.Empty;

            // Act
            options.Snapshot = "2024-01-02T00:00:00.0000000Z";

            // Assert
            Assert.AreEqual("2024-01-02T00:00:00.0000000Z", options.Snapshot);
            Assert.AreEqual(string.Empty, options.VersionId);
        }
    }
}
