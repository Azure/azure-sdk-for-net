// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Storage.Queues.Models;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class SerializationUnitTests
    {
        private static readonly ModelReaderWriterOptions XmlOptions = new ModelReaderWriterOptions("X");
        private static readonly ModelReaderWriterOptions InvalidOptions = new ModelReaderWriterOptions("J");

        #region QueueGeoReplicationStatus
        private static object[] QueueGeoReplicationStatusCases =
        {
            new object[] { QueueGeoReplicationStatus.Live, "live" },
            new object[] { QueueGeoReplicationStatus.Bootstrap, "bootstrap" },
            new object[] { QueueGeoReplicationStatus.Unavailable, "unavailable" },
        };

        [TestCaseSource(nameof(QueueGeoReplicationStatusCases))]
        public void QueueGeoReplicationStatus_SerializesCorrectly(QueueGeoReplicationStatus enumValue, string expected)
        {
            Assert.AreEqual(expected, enumValue.ToSerialString());
        }

        [TestCaseSource(nameof(QueueGeoReplicationStatusCases))]
        public void QueueGeoReplicationStatus_DeserializesCorrectly(QueueGeoReplicationStatus expected, string serialValue)
        {
            Assert.AreEqual(expected, serialValue.ToQueueGeoReplicationStatus());
        }

        [TestCaseSource(nameof(QueueGeoReplicationStatusCases))]
        public void QueueGeoReplicationStatus_RoundTrips(QueueGeoReplicationStatus enumValue, string _)
        {
            Assert.AreEqual(enumValue, enumValue.ToSerialString().ToQueueGeoReplicationStatus());
        }

        [Test]
        public void QueueGeoReplicationStatus_ToSerialString_ThrowsForInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((QueueGeoReplicationStatus)999).ToSerialString());
        }

        [Test]
        public void QueueGeoReplicationStatus_ToQueueGeoReplicationStatus_ThrowsForUnknown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "unknown".ToQueueGeoReplicationStatus());
        }
        #endregion

        #region PeekedMessage Serialization
        [Test]
        public void PeekedMessage_WriteAndCreate_RoundTrips()
        {
            var original = new PeekedMessage("msg1", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(7), 3, "hello");
            IPersistableModel<PeekedMessage> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            PeekedMessage deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.MessageId, deserialized.MessageId);
            Assert.AreEqual(original.DequeueCount, deserialized.DequeueCount);
            Assert.AreEqual(original.MessageText, deserialized.MessageText);
        }

        [Test]
        public void PeekedMessage_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<PeekedMessage> persistable = new PeekedMessage("id", null, null, 0, "text");
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void PeekedMessage_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<PeekedMessage> persistable = new PeekedMessage("id", null, null, 0, "text");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void PeekedMessage_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<PeekedMessage> persistable = new PeekedMessage("id", null, null, 0, "text");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessage/>"), InvalidOptions));
        }

        [Test]
        public void PeekedMessage_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var message = new PeekedMessage("id", null, null, 0, "text");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => message.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void PeekedMessage_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(PeekedMessage.DeserializePeekedMessage(null, XmlOptions));
        }

        [Test]
        public void PeekedMessage_IXmlSerializable_Write()
        {
            var message = new PeekedMessage("id", null, null, 0, "text");
            IXmlSerializable serializable = message;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessage");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessage", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueAccessPolicy Serialization
        [Test]
        public void QueueAccessPolicy_WriteAndCreate_RoundTrips()
        {
            var original = new QueueAccessPolicy(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(1), "raup");
            IPersistableModel<QueueAccessPolicy> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueAccessPolicy deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Permissions, deserialized.Permissions);
        }

        [Test]
        public void QueueAccessPolicy_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueAccessPolicy> persistable = new QueueAccessPolicy();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueAccessPolicy_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueAccessPolicy> persistable = new QueueAccessPolicy();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueAccessPolicy_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueAccessPolicy> persistable = new QueueAccessPolicy();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<AccessPolicy/>"), InvalidOptions));
        }

        [Test]
        public void QueueAccessPolicy_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var policy = new QueueAccessPolicy();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => policy.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueAccessPolicy_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueAccessPolicy.DeserializeQueueAccessPolicy(null, XmlOptions));
        }

        [Test]
        public void QueueAccessPolicy_IXmlSerializable_Write()
        {
            var policy = new QueueAccessPolicy();
            IXmlSerializable serializable = policy;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "AccessPolicy");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("AccessPolicy", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueAnalyticsLogging Serialization
        [Test]
        public void QueueAnalyticsLogging_WriteAndCreate_RoundTrips()
        {
            var retentionPolicy = new QueueRetentionPolicy(true, 7);
            var original = new QueueAnalyticsLogging("1.0", true, false, true, retentionPolicy);
            IPersistableModel<QueueAnalyticsLogging> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueAnalyticsLogging deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Version, deserialized.Version);
            Assert.AreEqual(original.Delete, deserialized.Delete);
            Assert.AreEqual(original.Read, deserialized.Read);
            Assert.AreEqual(original.Write, deserialized.Write);
        }

        [Test]
        public void QueueAnalyticsLogging_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueAnalyticsLogging> persistable = new QueueAnalyticsLogging();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueAnalyticsLogging_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueAnalyticsLogging> persistable = new QueueAnalyticsLogging();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueAnalyticsLogging_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueAnalyticsLogging> persistable = new QueueAnalyticsLogging();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<Logging/>"), InvalidOptions));
        }

        [Test]
        public void QueueAnalyticsLogging_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var logging = new QueueAnalyticsLogging();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => logging.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueAnalyticsLogging_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueAnalyticsLogging.DeserializeQueueAnalyticsLogging(null, XmlOptions));
        }

        [Test]
        public void QueueAnalyticsLogging_IXmlSerializable_Write()
        {
            var logging = new QueueAnalyticsLogging();
            IXmlSerializable serializable = logging;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "Logging");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("Logging", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueCorsRule Serialization
        [Test]
        public void QueueCorsRule_WriteAndCreate_RoundTrips()
        {
            var original = new QueueCorsRule("*", "GET", "x-ms-*", "x-ms-request-id", 3600);
            IPersistableModel<QueueCorsRule> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueCorsRule deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.AllowedOrigins, deserialized.AllowedOrigins);
            Assert.AreEqual(original.AllowedMethods, deserialized.AllowedMethods);
            Assert.AreEqual(original.MaxAgeInSeconds, deserialized.MaxAgeInSeconds);
        }

        [Test]
        public void QueueCorsRule_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueCorsRule> persistable = new QueueCorsRule();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueCorsRule_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueCorsRule> persistable = new QueueCorsRule();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueCorsRule_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueCorsRule> persistable = new QueueCorsRule();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<CorsRule/>"), InvalidOptions));
        }

        [Test]
        public void QueueCorsRule_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var rule = new QueueCorsRule();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => rule.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueCorsRule_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueCorsRule.DeserializeQueueCorsRule(null, XmlOptions));
        }

        [Test]
        public void QueueCorsRule_IXmlSerializable_Write()
        {
            var rule = new QueueCorsRule();
            IXmlSerializable serializable = rule;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "CorsRule");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("CorsRule", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueGeoReplication Serialization
        [Test]
        public void QueueGeoReplication_WriteAndCreate_RoundTrips()
        {
            var original = new QueueGeoReplication(QueueGeoReplicationStatus.Live, DateTimeOffset.UtcNow);
            IPersistableModel<QueueGeoReplication> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueGeoReplication deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Status, deserialized.Status);
        }

        [Test]
        public void QueueGeoReplication_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueGeoReplication> persistable = new QueueGeoReplication(QueueGeoReplicationStatus.Live, null);
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueGeoReplication_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueGeoReplication> persistable = new QueueGeoReplication(QueueGeoReplicationStatus.Live, null);
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueGeoReplication_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueGeoReplication> persistable = new QueueGeoReplication(QueueGeoReplicationStatus.Live, null);
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<GeoReplication/>"), InvalidOptions));
        }

        [Test]
        public void QueueGeoReplication_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var geo = new QueueGeoReplication(QueueGeoReplicationStatus.Live, null);
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => geo.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueGeoReplication_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueGeoReplication.DeserializeQueueGeoReplication(null, XmlOptions));
        }

        [Test]
        public void QueueGeoReplication_IXmlSerializable_Write()
        {
            var geo = new QueueGeoReplication(QueueGeoReplicationStatus.Live, null);
            IXmlSerializable serializable = geo;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "GeoReplication");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("GeoReplication", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueItem Serialization
        [Test]
        public void QueueItem_WriteAndCreate_RoundTrips()
        {
            var original = new QueueItem("myqueue");
            IPersistableModel<QueueItem> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueItem deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Name, deserialized.Name);
        }

        [Test]
        public void QueueItem_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueItem> persistable = new QueueItem("q");
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueItem_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueItem> persistable = new QueueItem("q");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueItem_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueItem> persistable = new QueueItem("q");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<Queue/>"), InvalidOptions));
        }

        [Test]
        public void QueueItem_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var item = new QueueItem("q");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => item.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueItem_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueItem.DeserializeQueueItem(null, XmlOptions));
        }

        [Test]
        public void QueueItem_IXmlSerializable_Write()
        {
            var item = new QueueItem("q");
            IXmlSerializable serializable = item;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "Queue");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("Queue", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueMessage Serialization
        [Test]
        public void QueueMessage_WriteAndCreate_RoundTrips()
        {
            var original = new QueueMessage("hello");
            IPersistableModel<QueueMessage> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueMessage deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.MessageText, deserialized.MessageText);
        }

        [Test]
        public void QueueMessage_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueMessage> persistable = new QueueMessage("text");
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueMessage_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueMessage> persistable = new QueueMessage("text");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueMessage_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueMessage> persistable = new QueueMessage("text");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessage/>"), InvalidOptions));
        }

        [Test]
        public void QueueMessage_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var message = new QueueMessage("text");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => message.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueMessage_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueMessage.DeserializeQueueMessage(null, XmlOptions));
        }

        [Test]
        public void QueueMessage_IXmlSerializable_Write()
        {
            var message = new QueueMessage("text");
            IXmlSerializable serializable = message;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessage");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessage", doc.Root.Name.LocalName);
        }

        [Test]
        public void QueueMessage_ImplicitOperatorRequestContent_ReturnsContent()
        {
            var message = new QueueMessage("text");
            RequestContent content = message;
            Assert.IsNotNull(content);
        }

        [Test]
        public void QueueMessage_ImplicitOperatorRequestContent_NullReturnsNull()
        {
            QueueMessage message = null;
            RequestContent content = message;
            Assert.IsNull(content);
        }
        #endregion

        #region QueueMetrics Serialization
        [Test]
        public void QueueMetrics_WriteAndCreate_RoundTrips()
        {
            var retentionPolicy = new QueueRetentionPolicy(true, 7);
            var original = new QueueMetrics("1.0", true, true, retentionPolicy);
            IPersistableModel<QueueMetrics> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueMetrics deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Version, deserialized.Version);
            Assert.AreEqual(original.Enabled, deserialized.Enabled);
            Assert.AreEqual(original.IncludeApis, deserialized.IncludeApis);
        }

        [Test]
        public void QueueMetrics_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueMetrics> persistable = new QueueMetrics();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueMetrics_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueMetrics> persistable = new QueueMetrics();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueMetrics_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueMetrics> persistable = new QueueMetrics();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<Metrics/>"), InvalidOptions));
        }

        [Test]
        public void QueueMetrics_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var metrics = new QueueMetrics();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => metrics.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueMetrics_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueMetrics.DeserializeQueueMetrics(null, XmlOptions));
        }

        [Test]
        public void QueueMetrics_IXmlSerializable_Write()
        {
            var metrics = new QueueMetrics();
            IXmlSerializable serializable = metrics;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "Metrics");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("Metrics", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueRetentionPolicy Serialization
        [Test]
        public void QueueRetentionPolicy_WriteAndCreate_RoundTrips()
        {
            var original = new QueueRetentionPolicy(true, 7);
            IPersistableModel<QueueRetentionPolicy> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueRetentionPolicy deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Enabled, deserialized.Enabled);
            Assert.AreEqual(original.Days, deserialized.Days);
        }

        [Test]
        public void QueueRetentionPolicy_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueRetentionPolicy> persistable = new QueueRetentionPolicy();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueRetentionPolicy_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueRetentionPolicy> persistable = new QueueRetentionPolicy();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueRetentionPolicy_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueRetentionPolicy> persistable = new QueueRetentionPolicy();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<RetentionPolicy/>"), InvalidOptions));
        }

        [Test]
        public void QueueRetentionPolicy_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var policy = new QueueRetentionPolicy();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => policy.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueRetentionPolicy_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueRetentionPolicy.DeserializeQueueRetentionPolicy(null, XmlOptions));
        }

        [Test]
        public void QueueRetentionPolicy_IXmlSerializable_Write()
        {
            var policy = new QueueRetentionPolicy();
            IXmlSerializable serializable = policy;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "RetentionPolicy");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("RetentionPolicy", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueServiceProperties Serialization
        [Test]
        public void QueueServiceProperties_WriteAndCreate_RoundTrips()
        {
            var original = new QueueServiceProperties();
            original.Cors = new System.Collections.Generic.List<QueueCorsRule>();
            IPersistableModel<QueueServiceProperties> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueServiceProperties deserialized = persistable.Create(data, XmlOptions);

            Assert.IsNotNull(deserialized);
        }

        [Test]
        public void QueueServiceProperties_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueServiceProperties> persistable = new QueueServiceProperties();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueServiceProperties_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueServiceProperties> persistable = new QueueServiceProperties();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueServiceProperties_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueServiceProperties> persistable = new QueueServiceProperties();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<StorageServiceProperties/>"), InvalidOptions));
        }

        [Test]
        public void QueueServiceProperties_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var props = new QueueServiceProperties();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => props.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueServiceProperties_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueServiceProperties.DeserializeQueueServiceProperties(null, XmlOptions));
        }

        [Test]
        public void QueueServiceProperties_IXmlSerializable_Write()
        {
            var props = new QueueServiceProperties();
            props.Cors = new System.Collections.Generic.List<QueueCorsRule>();
            IXmlSerializable serializable = props;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "StorageServiceProperties");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("StorageServiceProperties", doc.Root.Name.LocalName);
        }

        [Test]
        public void QueueServiceProperties_ImplicitOperatorRequestContent_ReturnsContent()
        {
            var props = new QueueServiceProperties();
            props.Cors = new System.Collections.Generic.List<QueueCorsRule>();
            RequestContent content = props;
            Assert.IsNotNull(content);
        }

        [Test]
        public void QueueServiceProperties_ImplicitOperatorRequestContent_NullReturnsNull()
        {
            QueueServiceProperties props = null;
            RequestContent content = props;
            Assert.IsNull(content);
        }
        #endregion

        #region QueueServiceStatistics Serialization
        [Test]
        public void QueueServiceStatistics_WriteAndCreate_RoundTrips()
        {
            var original = new QueueServiceStatistics(new QueueGeoReplication(QueueGeoReplicationStatus.Live, DateTimeOffset.UtcNow));
            IPersistableModel<QueueServiceStatistics> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueServiceStatistics deserialized = persistable.Create(data, XmlOptions);

            Assert.IsNotNull(deserialized.GeoReplication);
            Assert.AreEqual(original.GeoReplication.Status, deserialized.GeoReplication.Status);
        }

        [Test]
        public void QueueServiceStatistics_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueServiceStatistics> persistable = new QueueServiceStatistics();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueServiceStatistics_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueServiceStatistics> persistable = new QueueServiceStatistics();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueServiceStatistics_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueServiceStatistics> persistable = new QueueServiceStatistics();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<StorageServiceStats/>"), InvalidOptions));
        }

        [Test]
        public void QueueServiceStatistics_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var stats = new QueueServiceStatistics();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => stats.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueServiceStatistics_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueServiceStatistics.DeserializeQueueServiceStatistics(null, XmlOptions));
        }

        [Test]
        public void QueueServiceStatistics_IXmlSerializable_Write()
        {
            var stats = new QueueServiceStatistics();
            IXmlSerializable serializable = stats;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "StorageServiceStats");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("StorageServiceStats", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueSignedIdentifier Serialization
        [Test]
        public void QueueSignedIdentifier_WriteAndCreate_RoundTrips()
        {
            var original = new QueueSignedIdentifier("myId", new QueueAccessPolicy());
            IPersistableModel<QueueSignedIdentifier> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueSignedIdentifier deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Id, deserialized.Id);
        }

        [Test]
        public void QueueSignedIdentifier_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<QueueSignedIdentifier> persistable = new QueueSignedIdentifier();
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueSignedIdentifier_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueSignedIdentifier> persistable = new QueueSignedIdentifier();
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueSignedIdentifier_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueSignedIdentifier> persistable = new QueueSignedIdentifier();
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<SignedIdentifier/>"), InvalidOptions));
        }

        [Test]
        public void QueueSignedIdentifier_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var id = new QueueSignedIdentifier();
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => id.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueSignedIdentifier_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueSignedIdentifier.DeserializeQueueSignedIdentifier(null, XmlOptions));
        }

        [Test]
        public void QueueSignedIdentifier_IXmlSerializable_Write()
        {
            var id = new QueueSignedIdentifier();
            IXmlSerializable serializable = id;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "SignedIdentifier");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("SignedIdentifier", doc.Root.Name.LocalName);
        }
        #endregion

        #region SendReceipt Serialization
        [Test]
        public void SendReceipt_WriteAndCreate_RoundTrips()
        {
            var now = DateTimeOffset.UtcNow;
            var original = new SendReceipt("msg1", now, now.AddDays(7), "pop1", now.AddMinutes(1));
            IPersistableModel<SendReceipt> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            SendReceipt deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.MessageId, deserialized.MessageId);
            Assert.AreEqual(original.PopReceipt, deserialized.PopReceipt);
        }

        [Test]
        public void SendReceipt_GetFormatFromOptions_ReturnsX()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<SendReceipt> persistable = new SendReceipt("id", now, now, "pop", now);
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void SendReceipt_Write_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<SendReceipt> persistable = new SendReceipt("id", now, now, "pop", now);
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void SendReceipt_Create_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<SendReceipt> persistable = new SendReceipt("id", now, now, "pop", now);
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessage/>"), InvalidOptions));
        }

        [Test]
        public void SendReceipt_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            var receipt = new SendReceipt("id", now, now, "pop", now);
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => receipt.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void SendReceipt_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(SendReceipt.DeserializeSendReceipt(null, XmlOptions));
        }

        [Test]
        public void SendReceipt_IXmlSerializable_Write()
        {
            var now = DateTimeOffset.UtcNow;
            var receipt = new SendReceipt("id", now, now, "pop", now);
            IXmlSerializable serializable = receipt;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessage");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessage", doc.Root.Name.LocalName);
        }
        #endregion

        #region UserDelegationKey Serialization
        [Test]
        public void UserDelegationKey_WriteAndCreate_RoundTrips()
        {
            var now = DateTimeOffset.UtcNow;
            var original = new UserDelegationKey("oid", "tid", now, now.AddHours(1), "b", "2020-02-10", "keyValue");
            IPersistableModel<UserDelegationKey> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            UserDelegationKey deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.SignedObjectId, deserialized.SignedObjectId);
            Assert.AreEqual(original.SignedTenantId, deserialized.SignedTenantId);
            Assert.AreEqual(original.Value, deserialized.Value);
        }

        [Test]
        public void UserDelegationKey_GetFormatFromOptions_ReturnsX()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<UserDelegationKey> persistable = new UserDelegationKey("oid", "tid", now, now, "b", "v", "key");
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void UserDelegationKey_Write_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<UserDelegationKey> persistable = new UserDelegationKey("oid", "tid", now, now, "b", "v", "key");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void UserDelegationKey_Create_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<UserDelegationKey> persistable = new UserDelegationKey("oid", "tid", now, now, "b", "v", "key");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<UserDelegationKey/>"), InvalidOptions));
        }

        [Test]
        public void UserDelegationKey_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            var key = new UserDelegationKey("oid", "tid", now, now, "b", "v", "key");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => key.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void UserDelegationKey_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(UserDelegationKey.DeserializeUserDelegationKey(null, XmlOptions));
        }

        [Test]
        public void UserDelegationKey_IXmlSerializable_Write()
        {
            var now = DateTimeOffset.UtcNow;
            var key = new UserDelegationKey("oid", "tid", now, now, "b", "v", "key");
            IXmlSerializable serializable = key;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "UserDelegationKey");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("UserDelegationKey", doc.Root.Name.LocalName);
        }
        #endregion

        #region KeyInfo Serialization
        [Test]
        public void KeyInfo_WriteAndCreate_RoundTrips()
        {
            var original = new KeyInfo("start", "2025-01-01", "tenantId");
            IPersistableModel<KeyInfo> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            KeyInfo deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.Start, deserialized.Start);
            Assert.AreEqual(original.Expiry, deserialized.Expiry);
        }

        [Test]
        public void KeyInfo_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<KeyInfo> persistable = new KeyInfo("2025-01-01");
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void KeyInfo_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<KeyInfo> persistable = new KeyInfo("2025-01-01");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void KeyInfo_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<KeyInfo> persistable = new KeyInfo("2025-01-01");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<KeyInfo/>"), InvalidOptions));
        }

        [Test]
        public void KeyInfo_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var keyInfo = new KeyInfo("2025-01-01");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => keyInfo.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void KeyInfo_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(KeyInfo.DeserializeKeyInfo(null, XmlOptions));
        }

        [Test]
        public void KeyInfo_IXmlSerializable_Write()
        {
            var keyInfo = new KeyInfo("2025-01-01");
            IXmlSerializable serializable = keyInfo;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "KeyInfo");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("KeyInfo", doc.Root.Name.LocalName);
        }

        [Test]
        public void KeyInfo_ImplicitOperatorRequestContent_ReturnsContent()
        {
            var keyInfo = new KeyInfo("2025-01-01");
            RequestContent content = keyInfo;
            Assert.IsNotNull(content);
        }

        [Test]
        public void KeyInfo_ImplicitOperatorRequestContent_NullReturnsNull()
        {
            KeyInfo keyInfo = null;
            RequestContent content = keyInfo;
            Assert.IsNull(content);
        }
        #endregion

        #region ListOfSentMessage Serialization
        [Test]
        public void ListOfSentMessage_WriteAndCreate_RoundTrips()
        {
            var now = DateTimeOffset.UtcNow;
            var items = new[] { new SendReceipt("id", now, now.AddDays(7), "pop", now.AddMinutes(1)) };
            var original = new ListOfSentMessage(items);
            IPersistableModel<ListOfSentMessage> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            ListOfSentMessage deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(1, deserialized.Items.Count);
            Assert.AreEqual("id", deserialized.Items[0].MessageId);
        }

        [Test]
        public void ListOfSentMessage_GetFormatFromOptions_ReturnsX()
        {
            var original = new ListOfSentMessage(new SendReceipt[0]);
            IPersistableModel<ListOfSentMessage> persistable = original;
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void ListOfSentMessage_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<ListOfSentMessage> persistable = new ListOfSentMessage(new SendReceipt[0]);
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void ListOfSentMessage_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<ListOfSentMessage> persistable = new ListOfSentMessage(new SendReceipt[0]);
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessagesList/>"), InvalidOptions));
        }

        [Test]
        public void ListOfSentMessage_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var list = new ListOfSentMessage(new SendReceipt[0]);
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => list.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void ListOfSentMessage_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(ListOfSentMessage.DeserializeListOfSentMessage(null, XmlOptions));
        }

        [Test]
        public void ListOfSentMessage_IXmlSerializable_Write()
        {
            var list = new ListOfSentMessage(new SendReceipt[0]);
            IXmlSerializable serializable = list;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessagesList");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessagesList", doc.Root.Name.LocalName);
        }
        #endregion

        #region ListQueuesResponse Serialization
        [Test]
        public void ListQueuesResponse_WriteAndCreate_RoundTrips()
        {
            var original = new ListQueuesResponse("https://account.queue.core.windows.net/", "prefix", 10, "nextMarker");
            IPersistableModel<ListQueuesResponse> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            ListQueuesResponse deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.ServiceEndpoint, deserialized.ServiceEndpoint);
            Assert.AreEqual(original.Prefix, deserialized.Prefix);
        }

        [Test]
        public void ListQueuesResponse_GetFormatFromOptions_ReturnsX()
        {
            var original = new ListQueuesResponse("https://account.queue.core.windows.net/", "", 10, "");
            IPersistableModel<ListQueuesResponse> persistable = original;
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void ListQueuesResponse_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<ListQueuesResponse> persistable = new ListQueuesResponse("https://account.queue.core.windows.net/", "", 10, "");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void ListQueuesResponse_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<ListQueuesResponse> persistable = new ListQueuesResponse("https://account.queue.core.windows.net/", "", 10, "");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<EnumerationResults/>"), InvalidOptions));
        }

        [Test]
        public void ListQueuesResponse_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var response = new ListQueuesResponse("https://account.queue.core.windows.net/", "", 10, "");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => response.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void ListQueuesResponse_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(ListQueuesResponse.DeserializeListQueuesResponse(null, XmlOptions));
        }

        [Test]
        public void ListQueuesResponse_IXmlSerializable_Write()
        {
            var response = new ListQueuesResponse("https://account.queue.core.windows.net/", "", 10, "");
            IXmlSerializable serializable = response;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "EnumerationResults");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("EnumerationResults", doc.Root.Name.LocalName);
        }
        #endregion

        #region PeekedMessages Serialization
        [Test]
        public void PeekedMessages_WriteAndCreate_RoundTrips()
        {
            var items = new[] { new PeekedMessage("id", null, null, 0, "text") };
            var original = new PeekedMessages(items);
            IPersistableModel<PeekedMessages> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            PeekedMessages deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(1, deserialized.Items.Count);
        }

        [Test]
        public void PeekedMessages_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<PeekedMessages> persistable = new PeekedMessages(new PeekedMessage[0]);
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void PeekedMessages_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<PeekedMessages> persistable = new PeekedMessages(new PeekedMessage[0]);
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void PeekedMessages_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<PeekedMessages> persistable = new PeekedMessages(new PeekedMessage[0]);
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessagesList/>"), InvalidOptions));
        }

        [Test]
        public void PeekedMessages_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var messages = new PeekedMessages(new PeekedMessage[0]);
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => messages.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void PeekedMessages_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(PeekedMessages.DeserializePeekedMessages(null, XmlOptions));
        }

        [Test]
        public void PeekedMessages_IXmlSerializable_Write()
        {
            var messages = new PeekedMessages(new PeekedMessage[0]);
            IXmlSerializable serializable = messages;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessagesList");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessagesList", doc.Root.Name.LocalName);
        }
        #endregion

        #region QueueSignedIdentifiers Serialization
        [Test]
        public void QueueSignedIdentifiers_WriteAndCreate_RoundTrips()
        {
            var items = new[] { new QueueSignedIdentifier("myId", new QueueAccessPolicy()) };
            var original = new QueueSignedIdentifiers(items);
            IPersistableModel<QueueSignedIdentifiers> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            QueueSignedIdentifiers deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(1, deserialized.Items.Count);
            Assert.AreEqual("myId", deserialized.Items[0].Id);
        }

        [Test]
        public void QueueSignedIdentifiers_GetFormatFromOptions_ReturnsX()
        {
            var original = new QueueSignedIdentifiers(new QueueSignedIdentifier[0]);
            IPersistableModel<QueueSignedIdentifiers> persistable = original;
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void QueueSignedIdentifiers_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueSignedIdentifiers> persistable = new QueueSignedIdentifiers(new QueueSignedIdentifier[0]);
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void QueueSignedIdentifiers_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<QueueSignedIdentifiers> persistable = new QueueSignedIdentifiers(new QueueSignedIdentifier[0]);
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<SignedIdentifiers/>"), InvalidOptions));
        }

        [Test]
        public void QueueSignedIdentifiers_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var ids = new QueueSignedIdentifiers(new QueueSignedIdentifier[0]);
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => ids.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void QueueSignedIdentifiers_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(QueueSignedIdentifiers.DeserializeQueueSignedIdentifiers(null, XmlOptions));
        }

        [Test]
        public void QueueSignedIdentifiers_IXmlSerializable_Write()
        {
            var ids = new QueueSignedIdentifiers(new QueueSignedIdentifier[0]);
            IXmlSerializable serializable = ids;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "SignedIdentifiers");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("SignedIdentifiers", doc.Root.Name.LocalName);
        }

        [Test]
        public void QueueSignedIdentifiers_ImplicitOperatorRequestContent_ReturnsContent()
        {
            var ids = new QueueSignedIdentifiers(new QueueSignedIdentifier[0]);
            RequestContent content = ids;
            Assert.IsNotNull(content);
        }

        [Test]
        public void QueueSignedIdentifiers_ImplicitOperatorRequestContent_NullReturnsNull()
        {
            QueueSignedIdentifiers ids = null;
            RequestContent content = ids;
            Assert.IsNull(content);
        }
        #endregion

        #region ReceivedMessage Serialization
        [Test]
        public void ReceivedMessage_WriteAndCreate_RoundTrips()
        {
            var now = DateTimeOffset.UtcNow;
            var original = new ReceivedMessage("msg1", now, now.AddDays(7), "pop1", now.AddMinutes(1), 5, "hello");
            IPersistableModel<ReceivedMessage> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            ReceivedMessage deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(original.MessageId, deserialized.MessageId);
            Assert.AreEqual(original.PopReceipt, deserialized.PopReceipt);
            Assert.AreEqual(original.DequeueCount, deserialized.DequeueCount);
            Assert.AreEqual(original.MessageText, deserialized.MessageText);
        }

        [Test]
        public void ReceivedMessage_GetFormatFromOptions_ReturnsX()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<ReceivedMessage> persistable = new ReceivedMessage("id", now, now, "pop", now, 0, "text");
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void ReceivedMessage_Write_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<ReceivedMessage> persistable = new ReceivedMessage("id", now, now, "pop", now, 0, "text");
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void ReceivedMessage_Create_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            IPersistableModel<ReceivedMessage> persistable = new ReceivedMessage("id", now, now, "pop", now, 0, "text");
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessage/>"), InvalidOptions));
        }

        [Test]
        public void ReceivedMessage_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var now = DateTimeOffset.UtcNow;
            var message = new ReceivedMessage("id", now, now, "pop", now, 0, "text");
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => message.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void ReceivedMessage_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(ReceivedMessage.DeserializeReceivedMessage(null, XmlOptions));
        }

        [Test]
        public void ReceivedMessage_IXmlSerializable_Write()
        {
            var now = DateTimeOffset.UtcNow;
            var message = new ReceivedMessage("id", now, now, "pop", now, 0, "text");
            IXmlSerializable serializable = message;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessage");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessage", doc.Root.Name.LocalName);
        }
        #endregion

        #region ReceivedMessages Serialization
        [Test]
        public void ReceivedMessages_WriteAndCreate_RoundTrips()
        {
            var now = DateTimeOffset.UtcNow;
            var items = new[] { new ReceivedMessage("id", now, now.AddDays(7), "pop", now.AddMinutes(1), 1, "text") };
            var original = new ReceivedMessages(items);
            IPersistableModel<ReceivedMessages> persistable = original;

            BinaryData data = persistable.Write(XmlOptions);
            ReceivedMessages deserialized = persistable.Create(data, XmlOptions);

            Assert.AreEqual(1, deserialized.Items.Count);
        }

        [Test]
        public void ReceivedMessages_GetFormatFromOptions_ReturnsX()
        {
            IPersistableModel<ReceivedMessages> persistable = new ReceivedMessages(new ReceivedMessage[0]);
            Assert.AreEqual("X", persistable.GetFormatFromOptions(XmlOptions));
        }

        [Test]
        public void ReceivedMessages_Write_ThrowsForInvalidFormat()
        {
            IPersistableModel<ReceivedMessages> persistable = new ReceivedMessages(new ReceivedMessage[0]);
            Assert.Throws<FormatException>(() => persistable.Write(InvalidOptions));
        }

        [Test]
        public void ReceivedMessages_Create_ThrowsForInvalidFormat()
        {
            IPersistableModel<ReceivedMessages> persistable = new ReceivedMessages(new ReceivedMessage[0]);
            Assert.Throws<FormatException>(() => persistable.Create(BinaryData.FromString("<QueueMessagesList/>"), InvalidOptions));
        }

        [Test]
        public void ReceivedMessages_XmlModelWriteCore_ThrowsForInvalidFormat()
        {
            var messages = new ReceivedMessages(new ReceivedMessage[0]);
            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            Assert.Throws<FormatException>(() => messages.XmlModelWriteCore(writer, InvalidOptions));
        }

        [Test]
        public void ReceivedMessages_Deserialize_ReturnsNullForNullElement()
        {
            Assert.IsNull(ReceivedMessages.DeserializeReceivedMessages(null, XmlOptions));
        }

        [Test]
        public void ReceivedMessages_IXmlSerializable_Write()
        {
            var messages = new ReceivedMessages(new ReceivedMessage[0]);
            IXmlSerializable serializable = messages;

            using var stream = new MemoryStream();
            using var writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            serializable.Write(writer, "QueueMessagesList");
            writer.Flush();

            stream.Position = 0;
            var doc = XDocument.Load(stream);
            Assert.AreEqual("QueueMessagesList", doc.Root.Name.LocalName);
        }
        #endregion
    }
}
