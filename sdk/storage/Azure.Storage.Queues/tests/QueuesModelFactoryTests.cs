// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class QueuesModelFactoryTests
    {
        #region QueueServiceProperties
        [Test]
        public void QueueServiceProperties_WithAllParameters()
        {
            var logging = QueuesModelFactory.QueueAnalyticsLogging();
            var hourMetrics = QueuesModelFactory.QueueMetrics();
            var minuteMetrics = QueuesModelFactory.QueueMetrics();
            var cors = new List<QueueCorsRule> { QueuesModelFactory.QueueCorsRule() };

            var result = QueuesModelFactory.QueueServiceProperties(logging, hourMetrics, minuteMetrics, cors);

            Assert.AreSame(logging, result.Logging);
            Assert.AreSame(hourMetrics, result.HourMetrics);
            Assert.AreSame(minuteMetrics, result.MinuteMetrics);
            Assert.AreEqual(1, result.Cors.Count);
        }

        [Test]
        public void QueueServiceProperties_WithDefaults()
        {
            var result = QueuesModelFactory.QueueServiceProperties();

            Assert.IsNull(result.Logging);
            Assert.IsNull(result.HourMetrics);
            Assert.IsNull(result.MinuteMetrics);
            Assert.IsNotNull(result.Cors);
        }
        #endregion

        #region QueueAnalyticsLogging
        [Test]
        public void QueueAnalyticsLogging_WithAllParameters()
        {
            var retentionPolicy = QueuesModelFactory.QueueRetentionPolicy(true, 7);

            var result = QueuesModelFactory.QueueAnalyticsLogging("1.0", true, false, true, retentionPolicy);

            Assert.AreEqual("1.0", result.Version);
            Assert.IsTrue(result.Delete);
            Assert.IsFalse(result.Read);
            Assert.IsTrue(result.Write);
            Assert.AreSame(retentionPolicy, result.RetentionPolicy);
        }

        [Test]
        public void QueueAnalyticsLogging_WithDefaults()
        {
            var result = QueuesModelFactory.QueueAnalyticsLogging();

            Assert.IsNull(result.Version);
            Assert.IsFalse(result.Delete);
            Assert.IsFalse(result.Read);
            Assert.IsFalse(result.Write);
            Assert.IsNull(result.RetentionPolicy);
        }
        #endregion

        #region QueueRetentionPolicy
        [Test]
        public void QueueRetentionPolicy_WithAllParameters()
        {
            var result = QueuesModelFactory.QueueRetentionPolicy(true, 7);

            Assert.IsTrue(result.Enabled);
            Assert.AreEqual(7, result.Days);
        }

        [Test]
        public void QueueRetentionPolicy_WithDefaults()
        {
            var result = QueuesModelFactory.QueueRetentionPolicy();

            Assert.IsFalse(result.Enabled);
            Assert.IsNull(result.Days);
        }
        #endregion

        #region QueueMetrics
        [Test]
        public void QueueMetrics_WithAllParameters()
        {
            var retentionPolicy = QueuesModelFactory.QueueRetentionPolicy(true, 7);

            var result = QueuesModelFactory.QueueMetrics("1.0", true, true, retentionPolicy);

            Assert.AreEqual("1.0", result.Version);
            Assert.IsTrue(result.Enabled);
            Assert.IsTrue(result.IncludeApis);
            Assert.AreSame(retentionPolicy, result.RetentionPolicy);
        }

        [Test]
        public void QueueMetrics_WithDefaults()
        {
            var result = QueuesModelFactory.QueueMetrics();

            Assert.IsNull(result.Version);
            Assert.IsFalse(result.Enabled);
            Assert.IsNull(result.IncludeApis);
            Assert.IsNull(result.RetentionPolicy);
        }
        #endregion

        #region QueueCorsRule
        [Test]
        public void QueueCorsRule_WithAllParameters()
        {
            var result = QueuesModelFactory.QueueCorsRule("*", "GET", "x-ms-*", "x-ms-request-id", 3600);

            Assert.AreEqual("*", result.AllowedOrigins);
            Assert.AreEqual("GET", result.AllowedMethods);
            Assert.AreEqual("x-ms-*", result.AllowedHeaders);
            Assert.AreEqual("x-ms-request-id", result.ExposedHeaders);
            Assert.AreEqual(3600, result.MaxAgeInSeconds);
        }

        [Test]
        public void QueueCorsRule_WithDefaults()
        {
            var result = QueuesModelFactory.QueueCorsRule();

            Assert.IsNull(result.AllowedOrigins);
            Assert.IsNull(result.AllowedMethods);
            Assert.IsNull(result.AllowedHeaders);
            Assert.IsNull(result.ExposedHeaders);
            Assert.AreEqual(0, result.MaxAgeInSeconds);
        }
        #endregion

        #region QueueAccessPolicy
        [Test]
        public void QueueAccessPolicy_WithAllParameters()
        {
            var startsOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(1);

            var result = QueuesModelFactory.QueueAccessPolicy(startsOn, expiresOn, "raup");

            Assert.AreEqual(startsOn, result.StartsOn);
            Assert.AreEqual(expiresOn, result.ExpiresOn);
            Assert.AreEqual("raup", result.Permissions);
        }

        [Test]
        public void QueueAccessPolicy_WithDefaults()
        {
            var result = QueuesModelFactory.QueueAccessPolicy();

            Assert.IsNull(result.StartsOn);
            Assert.IsNull(result.ExpiresOn);
            Assert.IsNull(result.Permissions);
        }
        #endregion

        #region QueueMessage (string overload)
        [Test]
        public void QueueMessage_StringOverload_WithAllParameters()
        {
            var nextVisibleOn = DateTimeOffset.UtcNow.AddMinutes(1);
            var insertedOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(7);

            var result = QueuesModelFactory.QueueMessage("msgId", "popReceipt", "hello", 3, nextVisibleOn, insertedOn, expiresOn);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.AreEqual("popReceipt", result.PopReceipt);
            Assert.AreEqual("hello", result.Body.ToString());
            Assert.AreEqual(3, result.DequeueCount);
            Assert.AreEqual(nextVisibleOn, result.NextVisibleOn);
            Assert.AreEqual(insertedOn, result.InsertedOn);
            Assert.AreEqual(expiresOn, result.ExpiresOn);
        }

        [Test]
        public void QueueMessage_StringOverload_WithRequiredOnly()
        {
            var result = QueuesModelFactory.QueueMessage("msgId", "popReceipt", "hello", 0);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.AreEqual("popReceipt", result.PopReceipt);
            Assert.AreEqual("hello", result.Body.ToString());
            Assert.AreEqual(0, result.DequeueCount);
            Assert.IsNull(result.NextVisibleOn);
            Assert.IsNull(result.InsertedOn);
            Assert.IsNull(result.ExpiresOn);
        }
        #endregion

        #region QueueMessage (BinaryData overload)
        [Test]
        public void QueueMessage_BinaryDataOverload_WithAllParameters()
        {
            var body = new BinaryData("hello");
            var nextVisibleOn = DateTimeOffset.UtcNow.AddMinutes(1);
            var insertedOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(7);

            var result = QueuesModelFactory.QueueMessage("msgId", "popReceipt", body, 3, nextVisibleOn, insertedOn, expiresOn);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.AreEqual("popReceipt", result.PopReceipt);
            Assert.AreSame(body, result.Body);
            Assert.AreEqual(3, result.DequeueCount);
            Assert.AreEqual(nextVisibleOn, result.NextVisibleOn);
            Assert.AreEqual(insertedOn, result.InsertedOn);
            Assert.AreEqual(expiresOn, result.ExpiresOn);
        }

        [Test]
        public void QueueMessage_BinaryDataOverload_WithRequiredOnly()
        {
            var body = new BinaryData("hello");

            var result = QueuesModelFactory.QueueMessage("msgId", "popReceipt", body, 0);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.IsNull(result.NextVisibleOn);
        }
        #endregion

        #region PeekedMessage (string overload)
        [Test]
        public void PeekedMessage_StringOverload_WithAllParameters()
        {
            var insertedOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(7);

            var result = QueuesModelFactory.PeekedMessage("msgId", "hello", 3, insertedOn, expiresOn);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.AreEqual("hello", result.Body.ToString());
            Assert.AreEqual(3, result.DequeueCount);
            Assert.AreEqual(insertedOn, result.InsertedOn);
            Assert.AreEqual(expiresOn, result.ExpiresOn);
        }

        [Test]
        public void PeekedMessage_StringOverload_WithRequiredOnly()
        {
            var result = QueuesModelFactory.PeekedMessage("msgId", "hello", 0);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.IsNull(result.InsertedOn);
            Assert.IsNull(result.ExpiresOn);
        }
        #endregion

        #region PeekedMessage (BinaryData overload)
        [Test]
        public void PeekedMessage_BinaryDataOverload_WithAllParameters()
        {
            var body = new BinaryData("hello");
            var insertedOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(7);

            var result = QueuesModelFactory.PeekedMessage("msgId", body, 3, insertedOn, expiresOn);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.AreSame(body, result.Body);
            Assert.AreEqual(3, result.DequeueCount);
            Assert.AreEqual(insertedOn, result.InsertedOn);
            Assert.AreEqual(expiresOn, result.ExpiresOn);
        }

        [Test]
        public void PeekedMessage_BinaryDataOverload_WithRequiredOnly()
        {
            var body = new BinaryData("hello");

            var result = QueuesModelFactory.PeekedMessage("msgId", body, 0);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.IsNull(result.InsertedOn);
            Assert.IsNull(result.ExpiresOn);
        }
        #endregion

        #region QueueItem
        [Test]
        public void QueueItem_WithAllParameters()
        {
            var metadata = new Dictionary<string, string> { { "key", "value" } };

            var result = QueuesModelFactory.QueueItem("myqueue", metadata);

            Assert.AreEqual("myqueue", result.Name);
            Assert.AreSame(metadata, result.Metadata);
        }

        [Test]
        public void QueueItem_WithDefaults()
        {
            var result = QueuesModelFactory.QueueItem("myqueue");

            Assert.AreEqual("myqueue", result.Name);
            Assert.IsNull(result.Metadata);
        }
        #endregion

        #region QueueProperties (int overload)
        [Test]
        public void QueueProperties_IntOverload_SetsProperties()
        {
            var metadata = new Dictionary<string, string> { { "key", "value" } };

            var result = QueuesModelFactory.QueueProperties(metadata, 42);

            Assert.AreSame(metadata, result.Metadata);
            Assert.AreEqual(42, result.ApproximateMessagesCount);
        }
        #endregion

        #region QueueProperties (long overload)
        [Test]
        public void QueueProperties_LongOverload_SetsProperties()
        {
            var metadata = new Dictionary<string, string> { { "key", "value" } };

            var result = QueuesModelFactory.QueueProperties(metadata, 100L);

            Assert.AreSame(metadata, result.Metadata);
            Assert.AreEqual(100L, result.ApproximateMessagesCountLong);
        }
        #endregion

        #region QueueServiceStatistics
        [Test]
        public void QueueServiceStatistics_WithGeoReplication()
        {
            var geoReplication = QueuesModelFactory.QueueGeoReplication(QueueGeoReplicationStatus.Live, DateTimeOffset.UtcNow);

            var result = QueuesModelFactory.QueueServiceStatistics(geoReplication);

            Assert.AreSame(geoReplication, result.GeoReplication);
        }

        [Test]
        public void QueueServiceStatistics_WithDefaults()
        {
            var result = QueuesModelFactory.QueueServiceStatistics();

            Assert.IsNull(result.GeoReplication);
        }
        #endregion

        #region UpdateReceipt
        [Test]
        public void UpdateReceipt_SetsProperties()
        {
            var nextVisibleOn = DateTimeOffset.UtcNow.AddMinutes(1);

            var result = QueuesModelFactory.UpdateReceipt("popReceipt", nextVisibleOn);

            Assert.AreEqual("popReceipt", result.PopReceipt);
            Assert.AreEqual(nextVisibleOn, result.NextVisibleOn);
        }
        #endregion

        #region SendReceipt
        [Test]
        public void SendReceipt_SetsProperties()
        {
            var insertionTime = DateTimeOffset.UtcNow;
            var expirationTime = DateTimeOffset.UtcNow.AddDays(7);
            var timeNextVisible = DateTimeOffset.UtcNow.AddMinutes(1);

            var result = QueuesModelFactory.SendReceipt("msgId", insertionTime, expirationTime, "popReceipt", timeNextVisible);

            Assert.AreEqual("msgId", result.MessageId);
            Assert.AreEqual(insertionTime, result.InsertionTime);
            Assert.AreEqual(expirationTime, result.ExpirationTime);
            Assert.AreEqual("popReceipt", result.PopReceipt);
            Assert.AreEqual(timeNextVisible, result.TimeNextVisible);
        }
        #endregion

        #region QueueGeoReplication
        [Test]
        public void QueueGeoReplication_WithAllParameters()
        {
            var lastSyncedOn = DateTimeOffset.UtcNow;

            var result = QueuesModelFactory.QueueGeoReplication(QueueGeoReplicationStatus.Live, lastSyncedOn);

            Assert.AreEqual(QueueGeoReplicationStatus.Live, result.Status);
            Assert.AreEqual(lastSyncedOn, result.LastSyncedOn);
        }

        [Test]
        public void QueueGeoReplication_WithDefaults()
        {
            var result = QueuesModelFactory.QueueGeoReplication(QueueGeoReplicationStatus.Bootstrap);

            Assert.AreEqual(QueueGeoReplicationStatus.Bootstrap, result.Status);
            Assert.IsNull(result.LastSyncedOn);
        }
        #endregion

        #region UserDelegationKey (8-param overload)
        [Test]
        public void UserDelegationKey_8Param_WithAllParameters()
        {
            var startsOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);

            var result = QueuesModelFactory.UserDelegationKey("oid", "tid", startsOn, expiresOn, "b", "2020-02-10", "delegatedTid", "keyValue");

            Assert.AreEqual("oid", result.SignedObjectId);
            Assert.AreEqual("tid", result.SignedTenantId);
            Assert.AreEqual(startsOn, result.SignedStartsOn);
            Assert.AreEqual(expiresOn, result.SignedExpiresOn);
            Assert.AreEqual("b", result.SignedService);
            Assert.AreEqual("2020-02-10", result.SignedVersion);
            Assert.AreEqual("delegatedTid", result.SignedDelegatedUserTenantId);
            Assert.AreEqual("keyValue", result.Value);
        }

        [Test]
        public void UserDelegationKey_8Param_WithDefaults()
        {
            var result = QueuesModelFactory.UserDelegationKey();

            Assert.IsNull(result.SignedObjectId);
            Assert.IsNull(result.SignedDelegatedUserTenantId);
            Assert.IsNull(result.Value);
        }
        #endregion

        #region UserDelegationKey (7-param overload)
        [Test]
        public void UserDelegationKey_7Param_SetsProperties()
        {
            var startsOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);

            var result = QueuesModelFactory.UserDelegationKey("oid", "tid", startsOn, expiresOn, "b", "2020-02-10", "keyValue");

            Assert.AreEqual("oid", result.SignedObjectId);
            Assert.AreEqual("tid", result.SignedTenantId);
            Assert.AreEqual(startsOn, result.SignedStartsOn);
            Assert.AreEqual(expiresOn, result.SignedExpiresOn);
            Assert.AreEqual("b", result.SignedService);
            Assert.AreEqual("2020-02-10", result.SignedVersion);
            Assert.AreEqual("keyValue", result.Value);
        }
        #endregion

        #region QueueSignedIdentifier
        [Test]
        public void QueueSignedIdentifier_SetsProperties()
        {
            var accessPolicy = QueuesModelFactory.QueueAccessPolicy(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(1), "r");

            var result = new QueueSignedIdentifier()
            {
                Id = "myPolicy",
                AccessPolicy = accessPolicy,
            };

            Assert.AreEqual("myPolicy", result.Id);
            Assert.AreSame(accessPolicy, result.AccessPolicy);
        }
        #endregion
    }
}
