// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for <see cref="ShareChangeFeedEvent"/> deserialization from Avro record dictionaries
    /// and for the equality semantics of reason type and protocol value types.
    /// </summary>
    public class ShareChangeFeedEventTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedEventTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that all top-level and nested fields are correctly deserialized from a complete Avro record dictionary.
        /// </summary>
        [Test]
        public void Deserialization_AllFields()
        {
            // Arrange
            Dictionary<string, object> dataDict = new Dictionary<string, object>
            {
                { "FileId", "9223442405598953472" },
                { "ParentFileId", "9223442405598958712" },
                { "Etag", "0x8D9F2171BE32588" },
                { "FileName", "sample.txt" },
                { "FullFilePath", "dir/sample.txt" },
                { "IsDirectory", "false" },
                { "Description", "test description" },
                { "Initiator", "user@example.com" },
                // Nested Identity dict exercises the recursive deserialization path
                { "Identity", new Dictionary<string, object>
                    {
                        { "EntraOID", "550e8400-e29b-41d4-a716-446655440000" },
                        { "SID", "S-1-5-21-3623811015-3361044348-30300820-1013" }
                    }
                }
            };

            Dictionary<string, object> record = new Dictionary<string, object>
            {
                { "SchemaVersion", 1L },
                { "Reason", "SmbCreate" },
                { "Protocol", "SMB" },
                { "EventTime", "2024-01-15T08:12:11.5746587Z" },
                { "Id", "62616073-8020-0000-00ff-233467060cc0" },
                { "Cvnt", 100L },
                { "Data", dataDict }
            };

            // Act
            ShareChangeFeedEvent evt = new ShareChangeFeedEvent(record);

            // Assert
            Assert.AreEqual(1L, evt.SchemaVersion);
            Assert.AreEqual(ShareChangeFeedReasonType.SmbCreate, evt.Reason);
            Assert.AreEqual(ShareChangeFeedProtocol.Smb, evt.Protocol);
            Assert.AreEqual("62616073-8020-0000-00ff-233467060cc0", evt.Id);
            Assert.AreEqual(100L, evt.ContainerVersionNumber);

            Assert.IsNotNull(evt.EventData);
            Assert.AreEqual("9223442405598953472", evt.EventData.FileId);
            Assert.AreEqual("9223442405598958712", evt.EventData.ParentFileId);
            Assert.AreEqual(new ETag("0x8D9F2171BE32588"), evt.EventData.ETag);
            Assert.AreEqual("sample.txt", evt.EventData.FileName);
            Assert.AreEqual("dir/sample.txt", evt.EventData.FullFilePath);
            Assert.IsFalse(evt.EventData.IsDirectory);
            Assert.AreEqual("test description", evt.EventData.Description);
            Assert.AreEqual("user@example.com", evt.EventData.Initiator);

            // Verify nested Identity was deserialized
            Assert.IsNotNull(evt.EventData.Identity);
            Assert.AreEqual("550e8400-e29b-41d4-a716-446655440000", evt.EventData.Identity.EntraObjectId);
            Assert.AreEqual("S-1-5-21-3623811015-3361044348-30300820-1013", evt.EventData.Identity.SecurityIdentifier);
        }

        /// <summary>
        /// Verifies that IsDirectory is correctly deserialized as true and that REST protocol and reason are mapped.
        /// </summary>
        [Test]
        public void Deserialization_IsDirectory_True()
        {
            Dictionary<string, object> record = new Dictionary<string, object>
            {
                { "SchemaVersion", 1L },
                { "Reason", "RestCreate" },
                { "Protocol", "REST" },
                { "EventTime", "2024-01-15T08:00:00Z" },
                { "Id", "a1b2c3d4-e5f6-7890-abcd-ef1234567890" },
                { "Cvnt", 50L },
                { "Data", new Dictionary<string, object>
                    {
                        { "FileId", "123" },
                        { "IsDirectory", "true" },
                        { "FileName", "mydir" },
                    }
                }
            };

            ShareChangeFeedEvent evt = new ShareChangeFeedEvent(record);

            Assert.AreEqual(ShareChangeFeedReasonType.RestCreate, evt.Reason);
            Assert.AreEqual(ShareChangeFeedProtocol.Rest, evt.Protocol);
            Assert.IsTrue(evt.EventData.IsDirectory);
        }

        /// <summary>
        /// Verifies equality and inequality operators on <see cref="ShareChangeFeedReasonType"/> extensible enum values.
        /// </summary>
        [Test]
        public void ReasonType_Equality()
        {
            Assert.AreEqual(ShareChangeFeedReasonType.SmbCreate, new ShareChangeFeedReasonType("SmbCreate"));
            Assert.AreNotEqual(ShareChangeFeedReasonType.SmbCreate, ShareChangeFeedReasonType.SmbDelete);
            Assert.IsTrue(ShareChangeFeedReasonType.RestWrite == new ShareChangeFeedReasonType("RestWrite"));
        }

        /// <summary>
        /// Verifies equality and inequality operators on <see cref="ShareChangeFeedProtocol"/> extensible enum values.
        /// </summary>
        [Test]
        public void Protocol_Equality()
        {
            Assert.AreEqual(ShareChangeFeedProtocol.Smb, new ShareChangeFeedProtocol("SMB"));
            Assert.AreNotEqual(ShareChangeFeedProtocol.Smb, ShareChangeFeedProtocol.Rest);
        }

        /// <summary>
        /// Returns a fully populated event-record dictionary so individual tests can mutate one
        /// field at a time while keeping the rest valid.
        /// </summary>
        private static Dictionary<string, object> ValidRecord() => new Dictionary<string, object>
        {
            { "SchemaVersion", 1L },
            { "Reason", "SmbCreate" },
            { "Protocol", "SMB" },
            { "EventTime", "2024-01-15T08:12:11.5746587Z" },
            { "Id", "evt-1" },
            { "Cvnt", 100L },
            { "Data", new Dictionary<string, object> { { "FileId", "1" } } },
        };

        [Test]
        public void Deserialization_MissingCvnt_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("Cvnt");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Cvnt", ex.Message);
        }

        [Test]
        public void Deserialization_MissingSchemaVersion_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("SchemaVersion");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("SchemaVersion", ex.Message);
        }

        [Test]
        public void Deserialization_MissingReason_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("Reason");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Reason", ex.Message);
        }

        [Test]
        public void Deserialization_MissingProtocol_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("Protocol");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Protocol", ex.Message);
        }

        [Test]
        public void Deserialization_MissingEventTime_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("EventTime");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("EventTime", ex.Message);
        }

        [Test]
        public void Deserialization_MissingId_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("Id");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Id", ex.Message);
        }

        [Test]
        public void Deserialization_MissingData_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record.Remove("Data");

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Data", ex.Message);
        }

        [TestCase("not-a-date")]
        [TestCase("")]
        public void Deserialization_InvalidEventTimeFormat_Throws(string invalidTime)
        {
            Dictionary<string, object> record = ValidRecord();
            record["EventTime"] = invalidTime;

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("EventTime", ex.Message);
        }

        [Test]
        public void Deserialization_WrongTypeCvnt_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record["Cvnt"] = "100";

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Cvnt", ex.Message);
        }

        [Test]
        public void Deserialization_DataWrongType_Throws()
        {
            Dictionary<string, object> record = ValidRecord();
            record["Data"] = "not-a-dict";

            FormatException ex = Assert.Throws<FormatException>(() => new ShareChangeFeedEvent(record));
            StringAssert.Contains("Data", ex.Message);
        }

        // Gap 36: extensible-enum coverage.

        [Test]
        public void ReasonType_IsCaseSensitive()
        {
            // Reason equality is Ordinal — case matters for matching well-known values.
            Assert.AreNotEqual(ShareChangeFeedReasonType.SmbCreate, new ShareChangeFeedReasonType("smbcreate"));
            Assert.AreNotEqual(ShareChangeFeedReasonType.SmbCreate, new ShareChangeFeedReasonType("SMBCREATE"));
        }

        [Test]
        public void Protocol_IsCaseInsensitive()
        {
            // Protocol equality is OrdinalIgnoreCase — service may emit any case.
            Assert.AreEqual(ShareChangeFeedProtocol.Smb, new ShareChangeFeedProtocol("smb"));
            Assert.AreEqual(ShareChangeFeedProtocol.Smb, new ShareChangeFeedProtocol("Smb"));
            Assert.AreEqual(ShareChangeFeedProtocol.Rest, new ShareChangeFeedProtocol("rest"));
        }

        [Test]
        public void ReasonType_NotEqualOperator()
        {
            Assert.IsTrue(ShareChangeFeedReasonType.SmbCreate != ShareChangeFeedReasonType.SmbDelete);
            Assert.IsFalse(ShareChangeFeedReasonType.SmbCreate != new ShareChangeFeedReasonType("SmbCreate"));
        }

        [Test]
        public void ReasonType_GetHashCode_ConsistentForEqualInstances()
        {
            ShareChangeFeedReasonType a = ShareChangeFeedReasonType.SmbCreate;
            ShareChangeFeedReasonType b = new ShareChangeFeedReasonType("SmbCreate");
            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void ReasonType_UnknownForwardCompatValue_Allowed()
        {
            // A future service version may emit an unknown reason. The struct must accept and
            // round-trip the value without throwing, so callers can switch on ToString().
            ShareChangeFeedReasonType future = new ShareChangeFeedReasonType("FutureUnknownOp");
            Assert.AreEqual("FutureUnknownOp", future.ToString());
            Assert.AreEqual(future, new ShareChangeFeedReasonType("FutureUnknownOp"));
            Assert.AreNotEqual(future, ShareChangeFeedReasonType.SmbCreate);
        }

        [Test]
        public void ReasonType_NullValue_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ShareChangeFeedReasonType(null));
        }
    }
}
