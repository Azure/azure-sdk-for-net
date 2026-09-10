// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Batch.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class SerializationUnitTests
    {
        #region BlobDeleteType
        private static object[] BlobDeleteTypeCases =
        {
            new object[] { BlobDeleteType.None, "None" },
            new object[] { BlobDeleteType.Permanent, "Permanent" },
        };

        [TestCaseSource(nameof(BlobDeleteTypeCases))]
        public void BlobDeleteType_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((BlobDeleteType) enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(BlobDeleteTypeCases))]
        public void BlobDeleteType_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToBlobDeleteType());
        }

        [TestCaseSource(nameof(BlobDeleteTypeCases))]
        public void BlobDeleteType_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue,(int) ((BlobDeleteType) enumValue).ToSerialString().ToBlobDeleteType());
        }

        [Test]
        public void BlobDeleteType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((BlobDeleteType)999).ToSerialString());
        }

        [Test]
        public void BlobDeleteType_ToBlobDeleteType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Unknown".ToBlobDeleteType());
        }
        #endregion

        #region DeleteSnapshotsOptionType
        private static object[] DeleteSnapshotsOptionTypeCases =
        {
            new object[] { DeleteSnapshotsOptionType.Only, "only" },
            new object[] { DeleteSnapshotsOptionType.Include, "include" },
        };

        [TestCaseSource(nameof(DeleteSnapshotsOptionTypeCases))]
        public void DeleteSnapshotsOptionType_SerializesCorrectly(int enumValue, string expected)
        {
            Assert.AreEqual(expected, ((DeleteSnapshotsOptionType) enumValue).ToSerialString());
        }

        [TestCaseSource(nameof(DeleteSnapshotsOptionTypeCases))]
        public void DeleteSnapshotsOptionType_DeserializesCorrectly(int expected, string serialValue)
        {
            Assert.AreEqual(expected, (int) serialValue.ToDeleteSnapshotsOptionType());
        }

        [TestCaseSource(nameof(DeleteSnapshotsOptionTypeCases))]
        public void DeleteSnapshotsOptionType_RoundTrips(int enumValue, string _)
        {
            Assert.AreEqual(enumValue, (int) ((DeleteSnapshotsOptionType) enumValue).ToSerialString().ToDeleteSnapshotsOptionType());
        }

        [Test]
        public void DeleteSnapshotsOptionType_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((DeleteSnapshotsOptionType)999).ToSerialString());
        }

        [Test]
        public void DeleteSnapshotsOptionType_ToDeleteSnapshotsOptionType_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToDeleteSnapshotsOptionType());
        }
        #endregion
    }
}
