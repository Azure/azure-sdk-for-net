// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class ConstructorUnitTests
    {
        #region KeyInfo
        [Test]
        public void KeyInfo_PublicConstructor_SetsExpiry()
        {
            string expiry = "2025-01-01T00:00:00Z";
            var keyInfo = new KeyInfo(expiry);

            Assert.AreEqual(expiry, keyInfo.Expiry);
            Assert.IsNull(keyInfo.Start);
            Assert.IsNull(keyInfo.DelegatedUserTid);
        }

        [Test]
        public void KeyInfo_InternalConstructor_SetsAllProperties()
        {
            string start = "2024-01-01T00:00:00Z";
            string expiry = "2025-01-01T00:00:00Z";
            string delegatedUserTid = "tenant-id";

            var keyInfo = new KeyInfo(start, expiry, delegatedUserTid);

            Assert.AreEqual(start, keyInfo.Start);
            Assert.AreEqual(expiry, keyInfo.Expiry);
            Assert.AreEqual(delegatedUserTid, keyInfo.DelegatedUserTid);
        }
        #endregion

        #region ListOfSentMessage
        [Test]
        public void ListOfSentMessage_IEnumerableConstructor_CopiesList()
        {
            IEnumerable<SendReceipt> items = new List<SendReceipt>
            {
                new SendReceipt("id1", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(7), "pop1", DateTimeOffset.UtcNow.AddMinutes(1)),
            };
            var list = new ListOfSentMessage(items);

            Assert.AreEqual(1, list.Items.Count);
        }

        [Test]
        public void ListOfSentMessage_IListConstructor_AssignsList()
        {
            IList<SendReceipt> items = new List<SendReceipt>
            {
                new SendReceipt("id1", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(7), "pop1", DateTimeOffset.UtcNow.AddMinutes(1)),
            };
            var list = new ListOfSentMessage(items);

            Assert.AreSame(items, list.Items);
        }
        #endregion

        #region ListQueuesResponse
        [Test]
        public void ListQueuesResponse_ShortConstructor_SetsProperties()
        {
            var response = new ListQueuesResponse("https://account.queue.core.windows.net/", "prefix", 10, "nextMarker");

            Assert.AreEqual("https://account.queue.core.windows.net/", response.ServiceEndpoint);
            Assert.AreEqual("prefix", response.Prefix);
            Assert.AreEqual(10, response.MaxResults);
            Assert.AreEqual("nextMarker", response.NextMarker);
            Assert.IsNotNull(response.QueueItems);
            Assert.IsNull(response.Marker);
        }

        [Test]
        public void ListQueuesResponse_FullConstructor_SetsAllProperties()
        {
            var queueItems = new List<QueueItem>();
            var response = new ListQueuesResponse("https://account.queue.core.windows.net/", "prefix", "marker", 10, queueItems, "nextMarker");

            Assert.AreEqual("https://account.queue.core.windows.net/", response.ServiceEndpoint);
            Assert.AreEqual("prefix", response.Prefix);
            Assert.AreEqual("marker", response.Marker);
            Assert.AreEqual(10, response.MaxResults);
            Assert.AreSame(queueItems, response.QueueItems);
            Assert.AreEqual("nextMarker", response.NextMarker);
        }
        #endregion

        #region PeekedMessage
        [Test]
        public void PeekedMessage_InternalConstructor_SetsAllProperties()
        {
            var insertedOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(7);
            var message = new PeekedMessage("msgId", insertedOn, expiresOn, 3, "hello");

            Assert.AreEqual("msgId", message.MessageId);
            Assert.AreEqual(insertedOn, message.InsertedOn);
            Assert.AreEqual(expiresOn, message.ExpiresOn);
            Assert.AreEqual(3, message.DequeueCount);
            Assert.AreEqual("hello", message.MessageText);
        }
        #endregion

        #region PeekedMessages
        [Test]
        public void PeekedMessages_IEnumerableConstructor_CopiesList()
        {
            IEnumerable<PeekedMessage> items = new List<PeekedMessage>
            {
                new PeekedMessage("id1", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(7), 1, "text"),
            };
            var peeked = new PeekedMessages(items);

            Assert.AreEqual(1, peeked.Items.Count);
        }

        [Test]
        public void PeekedMessages_IListConstructor_AssignsList()
        {
            IList<PeekedMessage> items = new List<PeekedMessage>
            {
                new PeekedMessage("id1", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(7), 1, "text"),
            };
            var peeked = new PeekedMessages(items);

            Assert.AreSame(items, peeked.Items);
        }
        #endregion

        #region QueueAccessPolicy
        [Test]
        public void QueueAccessPolicy_PublicConstructor_DefaultValues()
        {
            var policy = new QueueAccessPolicy();

            Assert.IsNull(policy.StartsOn);
            Assert.IsNull(policy.ExpiresOn);
            Assert.IsNull(policy.Permissions);
        }

        [Test]
        public void QueueAccessPolicy_InternalConstructor_SetsAllProperties()
        {
            var startsOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddDays(1);
            var policy = new QueueAccessPolicy(startsOn, expiresOn, "raup");

            Assert.AreEqual(startsOn, policy.StartsOn);
            Assert.AreEqual(expiresOn, policy.ExpiresOn);
            Assert.AreEqual("raup", policy.Permissions);
        }
        #endregion

        #region QueueAnalyticsLogging
        [Test]
        public void QueueAnalyticsLogging_InternalConstructor_SetsAllProperties()
        {
            var retentionPolicy = new QueueRetentionPolicy();
            var logging = new QueueAnalyticsLogging("1.0", true, false, true, retentionPolicy);

            Assert.AreEqual("1.0", logging.Version);
            Assert.IsTrue(logging.Delete);
            Assert.IsFalse(logging.Read);
            Assert.IsTrue(logging.Write);
            Assert.AreSame(retentionPolicy, logging.RetentionPolicy);
        }

        [Test]
        public void QueueAnalyticsLogging_SkipInitialization_False_InitializesRetentionPolicy()
        {
            var logging = new QueueAnalyticsLogging(skipInitialization: false);

            Assert.IsNotNull(logging.RetentionPolicy);
        }

        [Test]
        public void QueueAnalyticsLogging_SkipInitialization_True_DoesNotInitialize()
        {
            var logging = new QueueAnalyticsLogging(skipInitialization: true);

            Assert.IsNull(logging.RetentionPolicy);
        }
        #endregion

        #region QueueCorsRule
        [Test]
        public void QueueCorsRule_InternalConstructor_SetsAllProperties()
        {
            var rule = new QueueCorsRule("*", "GET", "x-ms-*", "x-ms-request-id", 3600);

            Assert.AreEqual("*", rule.AllowedOrigins);
            Assert.AreEqual("GET", rule.AllowedMethods);
            Assert.AreEqual("x-ms-*", rule.AllowedHeaders);
            Assert.AreEqual("x-ms-request-id", rule.ExposedHeaders);
            Assert.AreEqual(3600, rule.MaxAgeInSeconds);
        }
        #endregion

        #region QueueGeoReplication
        [Test]
        public void QueueGeoReplication_InternalParameterizedConstructor_SetsAllProperties()
        {
            var lastSyncedOn = DateTimeOffset.UtcNow;
            var geoReplication = new QueueGeoReplication(QueueGeoReplicationStatus.Live, lastSyncedOn);

            Assert.AreEqual(QueueGeoReplicationStatus.Live, geoReplication.Status);
            Assert.AreEqual(lastSyncedOn, geoReplication.LastSyncedOn);
        }
        #endregion

        #region QueueItem
        [Test]
        public void QueueItem_SingleParamConstructor_SetsNameAndInitializesMetadata()
        {
            var item = new QueueItem("myqueue");

            Assert.AreEqual("myqueue", item.Name);
            Assert.IsNotNull(item.Metadata);
        }

        [Test]
        public void QueueItem_FullConstructor_SetsNameAndMetadata()
        {
            var metadata = new Dictionary<string, string> { { "key", "value" } };
            var item = new QueueItem("myqueue", metadata);

            Assert.AreEqual("myqueue", item.Name);
            Assert.AreSame(metadata, item.Metadata);
        }
        #endregion

        #region QueueMessage
        [Test]
        public void QueueMessage_ParameterlessConstructor_CreatesInstance()
        {
            var message = new QueueMessage();

            Assert.IsNull(message.MessageId);
            Assert.IsNull(message.Body);
        }

        [Test]
        public void QueueMessage_StringConstructor_SetsMessageText()
        {
            var message = new QueueMessage("hello");

            Assert.AreEqual("hello", message.MessageText);
        }
        #endregion

        #region QueueMetrics
        [Test]
        public void QueueMetrics_InternalConstructor_SetsAllProperties()
        {
            var retentionPolicy = new QueueRetentionPolicy();
            var metrics = new QueueMetrics("1.0", true, true, retentionPolicy);

            Assert.AreEqual("1.0", metrics.Version);
            Assert.IsTrue(metrics.Enabled);
            Assert.IsTrue(metrics.IncludeApis);
            Assert.AreSame(retentionPolicy, metrics.RetentionPolicy);
        }

        [Test]
        public void QueueMetrics_SkipInitialization_False_InitializesRetentionPolicy()
        {
            var metrics = new QueueMetrics(skipInitialization: false);

            Assert.IsNotNull(metrics.RetentionPolicy);
        }

        [Test]
        public void QueueMetrics_SkipInitialization_True_DoesNotInitialize()
        {
            var metrics = new QueueMetrics(skipInitialization: true);

            Assert.IsNull(metrics.RetentionPolicy);
        }
        #endregion

        #region QueueRetentionPolicy
        [Test]
        public void QueueRetentionPolicy_InternalBoolConstructor_SetsEnabled()
        {
            var policy = new QueueRetentionPolicy(enabled: true);

            Assert.IsTrue(policy.Enabled);
        }

        [Test]
        public void QueueRetentionPolicy_InternalFullConstructor_SetsAllProperties()
        {
            var policy = new QueueRetentionPolicy(enabled: true, days: 7);

            Assert.IsTrue(policy.Enabled);
            Assert.AreEqual(7, policy.Days);
        }
        #endregion

        #region QueueServiceProperties
        [Test]
        public void QueueServiceProperties_InternalConstructor_SetsAllProperties()
        {
            var logging = new QueueAnalyticsLogging();
            var hourMetrics = new QueueMetrics();
            var minuteMetrics = new QueueMetrics();
            var cors = new List<QueueCorsRule>();
            var props = new QueueServiceProperties(logging, hourMetrics, minuteMetrics, cors);

            Assert.AreSame(logging, props.Logging);
            Assert.AreSame(hourMetrics, props.HourMetrics);
            Assert.AreSame(minuteMetrics, props.MinuteMetrics);
            Assert.AreSame(cors, props.Cors);
        }

        [Test]
        public void QueueServiceProperties_SkipInitialization_False_InitializesNestedObjects()
        {
            var props = new QueueServiceProperties(skipInitialization: false);

            Assert.IsNotNull(props.Logging);
            Assert.IsNotNull(props.HourMetrics);
            Assert.IsNotNull(props.MinuteMetrics);
        }

        [Test]
        public void QueueServiceProperties_SkipInitialization_True_DoesNotInitialize()
        {
            var props = new QueueServiceProperties(skipInitialization: true);

            Assert.IsNull(props.Logging);
            Assert.IsNull(props.HourMetrics);
            Assert.IsNull(props.MinuteMetrics);
        }
        #endregion

        #region QueueServiceStatistics
        [Test]
        public void QueueServiceStatistics_ParameterlessConstructor_CreatesInstance()
        {
            var stats = new QueueServiceStatistics();

            Assert.IsNull(stats.GeoReplication);
        }

        [Test]
        public void QueueServiceStatistics_GeoReplicationConstructor_SetsProperty()
        {
            var geoReplication = new QueueGeoReplication(QueueGeoReplicationStatus.Live, DateTimeOffset.UtcNow);
            var stats = new QueueServiceStatistics(geoReplication);

            Assert.AreSame(geoReplication, stats.GeoReplication);
        }
        #endregion

        #region QueueSignedIdentifier
        [Test]
        public void QueueSignedIdentifier_InternalConstructor_SetsIdAndAccessPolicy()
        {
            var accessPolicy = new QueueAccessPolicy();
            var identifier = new QueueSignedIdentifier("myId", accessPolicy);

            Assert.AreEqual("myId", identifier.Id);
            Assert.AreSame(accessPolicy, identifier.AccessPolicy);
        }

        [Test]
        public void QueueSignedIdentifier_SkipInitialization_False_InitializesAccessPolicy()
        {
            var identifier = new QueueSignedIdentifier(skipInitialization: false);

            Assert.IsNotNull(identifier.AccessPolicy);
        }

        [Test]
        public void QueueSignedIdentifier_SkipInitialization_True_DoesNotInitialize()
        {
            var identifier = new QueueSignedIdentifier(skipInitialization: true);

            Assert.IsNull(identifier.AccessPolicy);
        }
        #endregion

        #region QueueSignedIdentifiers
        [Test]
        public void QueueSignedIdentifiers_IEnumerableConstructor_CopiesList()
        {
            IEnumerable<QueueSignedIdentifier> items = new List<QueueSignedIdentifier>
            {
                new QueueSignedIdentifier(),
            };
            var identifiers = new QueueSignedIdentifiers(items);

            Assert.AreEqual(1, identifiers.Items.Count);
        }

        [Test]
        public void QueueSignedIdentifiers_IEnumerableConstructor_ThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new QueueSignedIdentifiers((IEnumerable<QueueSignedIdentifier>)null));
        }

        [Test]
        public void QueueSignedIdentifiers_IListConstructor_AssignsList()
        {
            IList<QueueSignedIdentifier> items = new List<QueueSignedIdentifier>
            {
                new QueueSignedIdentifier(),
            };
            var identifiers = new QueueSignedIdentifiers(items);

            Assert.AreSame(items, identifiers.Items);
        }
        #endregion

        #region ReceivedMessage
        [Test]
        public void ReceivedMessage_Constructor_SetsAllProperties()
        {
            var insertionTime = DateTimeOffset.UtcNow;
            var expirationTime = DateTimeOffset.UtcNow.AddDays(7);
            var timeNextVisible = DateTimeOffset.UtcNow.AddMinutes(1);

            var message = new ReceivedMessage("msgId", insertionTime, expirationTime, "pop1", timeNextVisible, 5, "hello");

            Assert.AreEqual("msgId", message.MessageId);
            Assert.AreEqual(insertionTime, message.InsertionTime);
            Assert.AreEqual(expirationTime, message.ExpirationTime);
            Assert.AreEqual("pop1", message.PopReceipt);
            Assert.AreEqual(timeNextVisible, message.TimeNextVisible);
            Assert.AreEqual(5, message.DequeueCount);
            Assert.AreEqual("hello", message.MessageText);
        }
        #endregion

        #region ReceivedMessages
        [Test]
        public void ReceivedMessages_IEnumerableConstructor_CopiesList()
        {
            var now = DateTimeOffset.UtcNow;
            IEnumerable<ReceivedMessage> items = new List<ReceivedMessage>
            {
                new ReceivedMessage("id1", now, now.AddDays(7), "pop1", now.AddMinutes(1), 1, "text"),
            };
            var received = new ReceivedMessages(items);

            Assert.AreEqual(1, received.Items.Count);
        }

        [Test]
        public void ReceivedMessages_IListConstructor_AssignsList()
        {
            var now = DateTimeOffset.UtcNow;
            IList<ReceivedMessage> items = new List<ReceivedMessage>
            {
                new ReceivedMessage("id1", now, now.AddDays(7), "pop1", now.AddMinutes(1), 1, "text"),
            };
            var received = new ReceivedMessages(items);

            Assert.AreSame(items, received.Items);
        }
        #endregion

        #region SendReceipt
        [Test]
        public void SendReceipt_ParameterlessConstructor_CreatesInstance()
        {
            var receipt = new SendReceipt();

            Assert.IsNull(receipt.MessageId);
            Assert.IsNull(receipt.PopReceipt);
        }

        [Test]
        public void SendReceipt_FullConstructor_SetsAllProperties()
        {
            var insertionTime = DateTimeOffset.UtcNow;
            var expirationTime = DateTimeOffset.UtcNow.AddDays(7);
            var timeNextVisible = DateTimeOffset.UtcNow.AddMinutes(1);

            var receipt = new SendReceipt("msgId", insertionTime, expirationTime, "pop1", timeNextVisible);

            Assert.AreEqual("msgId", receipt.MessageId);
            Assert.AreEqual(insertionTime, receipt.InsertionTime);
            Assert.AreEqual(expirationTime, receipt.ExpirationTime);
            Assert.AreEqual("pop1", receipt.PopReceipt);
            Assert.AreEqual(timeNextVisible, receipt.TimeNextVisible);
        }
        #endregion

        #region UserDelegationKey
        [Test]
        public void UserDelegationKey_7ParamConstructor_SetsAllProperties()
        {
            var startsOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);

            var key = new UserDelegationKey("oid", "tid", startsOn, expiresOn, "b", "2020-02-10", "keyValue");

            Assert.AreEqual("oid", key.SignedObjectId);
            Assert.AreEqual("tid", key.SignedTenantId);
            Assert.AreEqual(startsOn, key.SignedStartsOn);
            Assert.AreEqual(expiresOn, key.SignedExpiresOn);
            Assert.AreEqual("b", key.SignedService);
            Assert.AreEqual("2020-02-10", key.SignedVersion);
            Assert.AreEqual("keyValue", key.Value);
            Assert.IsNull(key.SignedDelegatedUserTenantId);
        }

        [Test]
        public void UserDelegationKey_8ParamConstructor_SetsAllProperties()
        {
            var startsOn = DateTimeOffset.UtcNow;
            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);

            var key = new UserDelegationKey("oid", "tid", startsOn, expiresOn, "b", "2020-02-10", "delegatedTid", "keyValue");

            Assert.AreEqual("oid", key.SignedObjectId);
            Assert.AreEqual("tid", key.SignedTenantId);
            Assert.AreEqual(startsOn, key.SignedStartsOn);
            Assert.AreEqual(expiresOn, key.SignedExpiresOn);
            Assert.AreEqual("b", key.SignedService);
            Assert.AreEqual("2020-02-10", key.SignedVersion);
            Assert.AreEqual("delegatedTid", key.SignedDelegatedUserTenantId);
            Assert.AreEqual("keyValue", key.Value);
        }
        #endregion
    }
}
