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

            Assert.That(entry, Is.Not.Null);
            DateTime expectedRequestStartTime = new DateTime(635457986589681025L, DateTimeKind.Utc);
            Assert.That(entry.RequestStartTime, Is.EqualTo(expectedRequestStartTime));
            Assert.That(entry.RequestStartTime.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(entry.OperationType, Is.EqualTo(StorageServiceOperationType.PutBlob));
            Assert.That(entry.ServiceType, Is.EqualTo(StorageServiceType.Blob));
            Assert.That(entry.RequestedObjectKey, Is.EqualTo(requestedObjectKey));
        }

        [Test]
        public void TryParse_IfMalformedStartTime_ReturnsNull()
        {
            string[] fields = CreateArray("<INVALID>", "PutBlob", "blob", @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt");

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.That(entry, Is.Null);
        }

        [Test]
        public void TryParse_IfUnrecognizedService_IgnoresIt()
        {
            string[] fields = CreateArray("2014-09-08T18:44:18.9681025Z", "PutBlob", "INVALID", @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt");

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.That(entry, Is.Not.Null);
            Assert.That(entry.ServiceType.HasValue, Is.False);
        }

        [Test]
        public void TryParse_IfUnrecognizedOperation_IgnoresIt()
        {
            string[] fields = CreateArray("2014-09-08T18:44:18.9681025Z", "INVALID", "blob", @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt");

            StorageAnalyticsLogEntry entry = StorageAnalyticsLogEntry.TryParse(fields);

            Assert.That(entry, Is.Not.Null);
            Assert.That(entry.OperationType.HasValue, Is.False);
        }

        [TestCase(StorageServiceOperationType.PutBlob, StorageServiceType.Blob, @"/storagesample/sample-container/""0x8D199A96CB71468""/sample-blob.txt", "sample-container", @"""0x8D199A96CB71468""/sample-blob.txt")]
        [TestCase(StorageServiceOperationType.CopyBlobDestination, StorageServiceType.Blob, @"https://storagesample.blob.core.windows.net/sample-container/sample-blob.txt", "sample-container", "sample-blob.txt")]
        public void ToBlobPath_IfValidBlobOperationEntry_ReturnsBlobPath(object operationType, object serviceType, string requestedObjectKey, string expectedContainerName, string expectedBlobName)
        {
            StorageAnalyticsLogEntry entry = CreateEntry(
                "2014-09-08T18:44:18.9681025Z",
                (StorageServiceOperationType)operationType,
                (StorageServiceType)serviceType, requestedObjectKey);

            BlobPath blobPath = entry.ToBlobPath();

            Assert.That(blobPath, Is.Not.Null);
            Assert.That(blobPath.ContainerName, Is.EqualTo(expectedContainerName));
            Assert.That(blobPath.BlobName, Is.EqualTo(expectedBlobName));
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
            Assert.That(blobPath, Is.Null);
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
            Assert.That(blob, Is.Null);
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
