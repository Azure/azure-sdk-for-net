// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class StorageAnalyticsLogEntryTests
    {
        [Test]
        public void TryParse_IfValidFieldValues_ReturnsLogEntryInstance()
        {
            string requestStartTime = "2014-09-08T18:44:18.9681025Z";
            string operationType = "PutBlob";
            string serviceType = "blob";
            string requestedObjectKey = @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt";
            string[] fields = CreateArray(requestStartTime, operationType, serviceType, requestedObjectKey);

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.NotNull(entry);
            DateTime expectedRequestStartTime = new DateTime(635457986589681025L, DateTimeKind.Utc);
            Assert.AreEqual(expectedRequestStartTime, entry.RequestStartTime);
            Assert.AreEqual(DateTimeKind.Utc, entry.RequestStartTime.Kind);
            Assert.AreEqual(StorageServiceOperationType.PutBlob, entry.OperationType);
            Assert.AreEqual(StorageServiceType.Blob, entry.ServiceType);
            Assert.AreEqual(requestedObjectKey, entry.RequestedObjectKey);
        }

        [Test]
        public void TryParse_IfMalformedStartTime_ReturnsNull()
        {
            string[] fields = CreateArray("<INVALID>", "PutBlob", "blob", @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt");

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.Null(entry);
        }

        [Test]
        public void TryParse_IfUnrecognizedService_IgnoresIt()
        {
            string[] fields = CreateArray("2014-09-08T18:44:18.9681025Z", "PutBlob", "INVALID", @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt");

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.NotNull(entry);
            Assert.False(entry.ServiceType.HasValue);
        }

        [Test]
        public void TryParse_IfUnrecognizedOperation_IgnoresIt()
        {
            string[] fields = CreateArray("2014-09-08T18:44:18.9681025Z", "INVALID", "blob", @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt");

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.NotNull(entry);
            Assert.False(entry.OperationType.HasValue);
        }

        [TestCase(StorageServiceOperationType.PutBlob, StorageServiceType.Blob, @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt", "sample-container", @"""0x8D199A96CB71468""/sample-blob.txt")]
        [TestCase(StorageServiceOperationType.CopyBlobDestination, StorageServiceType.Blob, @"https://storagesample.blob.core.windows.net/sample-container/sample-blob.txt", "sample-container", "sample-blob.txt")]
        public void ToBlobPath_IfValidBlobOperationEntry_ReturnsBlobPath(object operationType, object serviceType, string requestedObjectKey, string expectedContainerName, string expectedBlobName)
        {
            StorageAnalyticsLogEntry entry = CreateEntry(
                "2014-09-08T18:44:18.9681025Z",
                (StorageServiceOperationType) operationType,
                (StorageServiceType) serviceType, requestedObjectKey);

            BlobPath blobPath = entry.ToBlobPath();

            Assert.NotNull(blobPath);
            Assert.AreEqual(expectedContainerName, blobPath.ContainerName);
            Assert.AreEqual(expectedBlobName, blobPath.BlobName);
        }

        [TestCase(@"random-string-with-no-slashes")]
        [TestCase(@"https://random.url.com")]
        [TestCase(@"/")]
        [TestCase(@"")]
        [TestCase(@"\\")]
        public void ToBlobPath_IfMalformedObjectKey_ReturnsNull(string requestedObjectKey)
        {
            StorageAnalyticsLogEntry entry = CreateEntry("2014-09-08T18:44:18.9681025Z", StorageServiceOperationType.PutBlob, StorageServiceType.Blob, requestedObjectKey);

            BlobPath blobPath = entry.ToBlobPath();
            Assert.Null(blobPath);
        }

        [TestCase(@"http://random:aaa/path???qw")]
        [TestCase(@"\\\")]
        public void ToBlobPath_IfMalformedUri_PropogatesUriFormatException(string requestedObjectKey)
        {
            StorageAnalyticsLogEntry entry = CreateEntry("2014-09-08T18:44:18.9681025Z", StorageServiceOperationType.PutBlob, StorageServiceType.Blob, requestedObjectKey);

            Assert.Throws<UriFormatException>(() => entry.ToBlobPath());
        }

        [Test]
        public void ToBlobPath_IfMalformedBlobPath_ReturnsNull()
        {
            string requestedObjectKey = "/account/malformed-blob-path";
            StorageAnalyticsLogEntry entry = CreateEntry("2014-09-08T18:44:18.9681025Z", StorageServiceOperationType.PutBlob, StorageServiceType.Blob, requestedObjectKey);

            BlobPath blob = entry.ToBlobPath();
            Assert.Null(blob);
        }

        private static StorageAnalyticsLogEntry CreateEntry(string requestStartTime, StorageServiceOperationType operationType, StorageServiceType serviceType, string requestedObjectKey)
        {
            StorageAnalyticsLogEntry entry = new StorageAnalyticsLogEntry();
            entry.RequestStartTime = DateTime.Parse(requestStartTime, CultureInfo.InvariantCulture);
            entry.OperationType = operationType;
            entry.ServiceType = serviceType;
            entry.RequestedObjectKey = requestedObjectKey;

            return entry;
        }

        private static string[] CreateArray(string requestStartTime, string operationType, string serviceType, string requestedObjectKey)
        {
            string[] fields = new string[(int)StorageAnalyticsLogColumnId.LastColumn + 1];
            fields[(int)StorageAnalyticsLogColumnId.ServiceType] = serviceType;
            fields[(int)StorageAnalyticsLogColumnId.OperationType] = operationType;
            fields[(int)StorageAnalyticsLogColumnId.RequestStartTime] = requestStartTime;
            fields[(int)StorageAnalyticsLogColumnId.RequestedObjectKey] = requestedObjectKey;
            return fields;
        }
    }
}
