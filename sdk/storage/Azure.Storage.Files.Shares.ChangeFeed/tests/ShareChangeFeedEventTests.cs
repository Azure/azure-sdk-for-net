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
            var dataDict = new Dictionary<string, object>
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

            var record = new Dictionary<string, object>
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
            var evt = new ShareChangeFeedEvent(record);

            // Assert
            Assert.AreEqual(1L, evt.SchemaVersion);
            Assert.AreEqual(ShareChangeFeedReasonType.SmbCreate, evt.Reason);
            Assert.AreEqual(ShareChangeFeedProtocol.Smb, evt.Protocol);
            Assert.AreEqual(Guid.Parse("62616073-8020-0000-00ff-233467060cc0"), evt.Id);
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
            var record = new Dictionary<string, object>
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

            var evt = new ShareChangeFeedEvent(record);

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
    }
}
