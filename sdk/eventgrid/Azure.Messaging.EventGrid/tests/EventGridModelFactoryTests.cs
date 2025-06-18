// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.EventGrid.Models;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    /// <summary>
    /// Tests for events that have generated factory methods as well as hand-written factory methods (for back compat).
    /// This should ensure there are no ambiguous or recursive calls when using the factory methods.
    /// The calls are made to the handwritten methods as these contain a subset of the parameters from the generated methods
    /// and would surface any ambiguity/recursion issues.
    /// </summary>
    public class EventGridModelFactoryTests
    {
        [Test]
        public void CanCreateMediaJobError()
        {
            var model = EventGridModelFactory.MediaJobError(MediaJobErrorCode.ConfigurationUnsupported, "message", MediaJobErrorCategory.Configuration,
                MediaJobRetry.MayRetry, new MediaJobErrorDetail[] { });

            Assert.AreEqual(MediaJobErrorCode.ConfigurationUnsupported, model.Code);
            Assert.AreEqual("message", model.Message);
            Assert.AreEqual(MediaJobErrorCategory.Configuration, model.Category);
        }

        [Test]
        public void CanCreateMediaJobFinishedEventData()
        {
            var model = EventGridModelFactory.MediaJobFinishedEventData(MediaJobState.Canceling, MediaJobState.Canceled, null, null);

            Assert.AreEqual(MediaJobState.Canceling, model.PreviousState);
            Assert.AreEqual(MediaJobState.Canceled, model.State);
        }

        [Test]
        public void CanCreateMediaJobCanceledEventData()
        {
            var model = EventGridModelFactory.MediaJobCanceledEventData(MediaJobState.Canceling, MediaJobState.Canceled, null, null);

            Assert.AreEqual(MediaJobState.Canceling, model.PreviousState);
            Assert.AreEqual(MediaJobState.Canceled, model.State);
        }

        [Test]
        public void CanCreateMediaJobErroredEventData()
        {
            var model = EventGridModelFactory.MediaJobErroredEventData(MediaJobState.Canceling, MediaJobState.Canceled, null, null);

            Assert.AreEqual(MediaJobState.Canceling, model.PreviousState);
            Assert.AreEqual(MediaJobState.Canceled, model.State);
        }

        [Test]
        public void CanCreateMapsGeofenceEventProperties()
        {
            var model = EventGridModelFactory.MapsGeofenceEventProperties(new[]{"geometry"}, Array.Empty<MapsGeofenceGeometry>(), Array.Empty<string>(), true);

            CollectionAssert.Contains(model.ExpiredGeofenceGeometryId, "geometry");
            Assert.True(model.IsEventPublished);
        }

        [Test]
        public void CanCreateAcsChatThreadCreatedWithUserEventData()
        {
            var model = EventGridModelFactory.AcsChatThreadCreatedWithUserEventData(
                EventGridModelFactory.CommunicationIdentifierModel(),
                "transaction",
                "thread",
                DateTimeOffset.Now,
                1,
                EventGridModelFactory.CommunicationIdentifierModel(),
                new Dictionary<string, object>(),
                new List<AcsChatThreadParticipantProperties>());

            Assert.AreEqual("transaction", model.TransactionId);
            Assert.AreEqual("thread", model.ThreadId);
            Assert.AreEqual(1, model.Version);
        }

        [Test]
        public void CanCreateAcsChatThreadCreatedEventData()
        {
            var model = EventGridModelFactory.AcsChatThreadCreatedEventData(
                "transaction",
                "thread",
                DateTimeOffset.Now,
                1,
                EventGridModelFactory.CommunicationIdentifierModel(),
                new Dictionary<string, object>(),
                new List<AcsChatThreadParticipantProperties>());

            Assert.AreEqual("transaction", model.TransactionId);
            Assert.AreEqual("thread", model.ThreadId);
            Assert.AreEqual(1, model.Version);
        }

        [Test]
        public void CanCreateAcsSmsDeliveryReportReceivedEventData()
        {
            var model = EventGridModelFactory.AcsSmsDeliveryReportReceivedEventData(
                "message",
                "from",
                "to",
                "status",
                "details",
                new List<AcsSmsDeliveryAttemptProperties>(),
                DateTimeOffset.Now,
                "tag");

            Assert.AreEqual("message", model.MessageId);
            Assert.AreEqual("from", model.From);
            Assert.AreEqual("to", model.To);
            Assert.AreEqual("status", model.DeliveryStatus);
            Assert.AreEqual("details", model.DeliveryStatusDetails);
            Assert.AreEqual("tag", model.Tag);
        }

        [Test]
        public void CanCreateAcsRecordingStorageInfoProperties()
        {
            var model = EventGridModelFactory.AcsRecordingStorageInfoProperties(
                new List<AcsRecordingChunkInfoProperties>
                {
                    EventGridModelFactory.AcsRecordingChunkInfoProperties("document", 0, "reason", "location", "content")
                });

            Assert.AreEqual("document", model.RecordingChunks.First().DocumentId);
            Assert.AreEqual(0, model.RecordingChunks.First().Index);
            Assert.AreEqual("reason", model.RecordingChunks.First().EndReason);
            Assert.AreEqual("location", model.RecordingChunks.First().MetadataLocation);
            Assert.AreEqual("content", model.RecordingChunks.First().ContentLocation);
        }

        [Test]
        public void CanCreateAcsChatMessageReceivedInThreadEventData()
        {
            var model = EventGridModelFactory.AcsChatMessageReceivedInThreadEventData(
                "transaction",
                "thread",
                "message",
                EventGridModelFactory.CommunicationIdentifierModel(),
                "sender",
                DateTimeOffset.Now,
                "type",
                1,
                "body",
                new Dictionary<string, string>());

                Assert.AreEqual("transaction", model.TransactionId);
                Assert.AreEqual("thread", model.ThreadId);
                Assert.AreEqual("message", model.MessageId);
                Assert.AreEqual("sender", model.SenderDisplayName);
                Assert.AreEqual("type", model.Type);
                Assert.AreEqual(1, model.Version);
                Assert.AreEqual("body", model.MessageBody);
        }

        [Test]
        public void CanCreateAcsChatMessageEventInThreadBaseProperties()
        {
            var model = EventGridModelFactory.AcsChatMessageEventInThreadBaseProperties(
                "transaction",
                "thread",
                "message",
                EventGridModelFactory.CommunicationIdentifierModel(),
                "sender",
                DateTimeOffset.Now,
                "type",
                1);

            Assert.AreEqual("transaction", model.TransactionId);
            Assert.AreEqual("thread", model.ThreadId);
            Assert.AreEqual("message", model.MessageId);
            Assert.AreEqual("sender", model.SenderDisplayName);
            Assert.AreEqual("type", model.Type);
            Assert.AreEqual(1, model.Version);
        }

        [Test]
        public void CanCreateAcsChatEventInThreadBaseProperties()
        {
            var model = EventGridModelFactory.AcsChatEventInThreadBaseProperties(
                "transaction",
                "thread");

            Assert.AreEqual("transaction", model.TransactionId);
            Assert.AreEqual("thread", model.ThreadId);
        }

        [Test]
        public void CanCreateAcsChatMessageEditedEventData()
        {
            var model = EventGridModelFactory.AcsChatMessageEditedEventData(
                EventGridModelFactory.CommunicationIdentifierModel(),
                "transaction",
                "thread",
                "message",
                EventGridModelFactory.CommunicationIdentifierModel(),
                "sender",
                DateTimeOffset.Now,
                "type",
                1,
                "body",
                new Dictionary<string, string>(),
                DateTimeOffset.Now);

            Assert.AreEqual("transaction", model.TransactionId);
            Assert.AreEqual("thread", model.ThreadId);
            Assert.AreEqual("message", model.MessageId);
            Assert.AreEqual("sender", model.SenderDisplayName);
            Assert.AreEqual("type", model.Type);
            Assert.AreEqual(1, model.Version);
            Assert.AreEqual("body", model.MessageBody);
        }

        [Test]
        public void CanCreateAcsChatMessageEditedInThreadEventData()
        {
            var model = EventGridModelFactory.AcsChatMessageEditedInThreadEventData(
                "transaction",
                "thread",
                "message",
                EventGridModelFactory.CommunicationIdentifierModel(),
                "sender",
                DateTimeOffset.Now,
                "type",
                1,
                "body",
                new Dictionary<string, string>(),
                DateTimeOffset.Now);

            Assert.AreEqual("transaction", model.TransactionId);
            Assert.AreEqual("thread", model.ThreadId);
            Assert.AreEqual("message", model.MessageId);
            Assert.AreEqual("sender", model.SenderDisplayName);
            Assert.AreEqual("type", model.Type);
            Assert.AreEqual(1, model.Version);
            Assert.AreEqual("body", model.MessageBody);
        }

        [Test]
        public void CanCreateMediaLiveEventIngestHeartbeatEventData()
        {
            var model = EventGridModelFactory.MediaLiveEventIngestHeartbeatEventData(
                "type",
                "name",
                5,
                10,
                "stamp",
                "scale",
                1,
                1,
                1,
                true,
                "state",
                true);

                Assert.AreEqual("type", model.TrackType);
                Assert.AreEqual("name", model.TrackName);
                Assert.AreEqual(5, model.Bitrate);
                Assert.AreEqual(10, model.IncomingBitrate);
                Assert.AreEqual("stamp", model.LastTimestamp);
                Assert.AreEqual("scale", model.Timescale);
                Assert.AreEqual(1, model.OverlapCount);
                Assert.AreEqual(1, model.DiscontinuityCount);
                Assert.AreEqual(1, model.NonincreasingCount);
                Assert.IsTrue(model.UnexpectedBitrate);
                Assert.AreEqual("state", model.State);
                Assert.IsTrue(model.Healthy);
        }

        [Test]
        public void CanCreateMediaLiveEventChannelArchiveHeartbeatEventData()
        {
            var model = EventGridModelFactory.MediaLiveEventChannelArchiveHeartbeatEventData(
                TimeSpan.Zero,
                "result");

            Assert.AreEqual(TimeSpan.Zero, model.ChannelLatency);
            Assert.AreEqual("result", model.LatencyResultCode);
        }

        [Test]
        public void CanCreateAcsRecordingFileStatusUpdatedEventData()
        {
            var model = EventGridModelFactory.AcsRecordingFileStatusUpdatedEventData(
                EventGridModelFactory.AcsRecordingStorageInfoProperties(),
                DateTimeOffset.Now,
                10,
                "reason");

            Assert.AreEqual(10, model.RecordingDurationMs);
            Assert.AreEqual("reason", model.SessionEndReason);

            model = EventGridModelFactory.AcsRecordingFileStatusUpdatedEventData(
                EventGridModelFactory.AcsRecordingStorageInfoProperties(),
                DateTimeOffset.Now,
                10,
                RecordingContentType.Audio,
                RecordingChannelType.Mixed,
                RecordingFormatType.Mp3);

            Assert.AreEqual(10, model.RecordingDurationMs);
            Assert.AreEqual(AcsRecordingContentType.Audio, model.ContentType);
            Assert.AreEqual(AcsRecordingChannelType.Mixed, model.ChannelType);
            Assert.AreEqual(AcsRecordingFormatType.Mp3, model.FormatType);

            // back compat
            Assert.AreEqual(RecordingContentType.Audio, model.RecordingContentType);
            Assert.AreEqual(RecordingChannelType.Mixed, model.RecordingChannelType);
            Assert.AreEqual(RecordingFormatType.Mp3, model.RecordingFormatType);

            // empty params
            model = EventGridModelFactory.AcsRecordingFileStatusUpdatedEventData(contentType: "contentTypeIsRequired");
            Assert.IsNotNull(model);
        }

        [Test]
        public void CanCreateAcsRecordingChunkInfoProperties()
        {
            var model = EventGridModelFactory.AcsRecordingChunkInfoProperties(
                "document",
                0,
                "reason",
                "location",
                "contentLocation",
                "delete");

            Assert.AreEqual("document", model.DocumentId);
            Assert.AreEqual(0, model.Index);
            Assert.AreEqual("reason", model.EndReason);
            Assert.AreEqual("location", model.MetadataLocation);
            Assert.AreEqual("contentLocation", model.ContentLocation);
            Assert.AreEqual("delete", model.DeleteLocation);
        }

        [Test]
        public void CanCreateContainerRegistryEventData()
        {
            var model = EventGridModelFactory.ContainerRegistryEventData(
                "id",
                DateTimeOffset.Now,
                "action",
                EventGridModelFactory.ContainerRegistryEventTarget(),
                EventGridModelFactory.ContainerRegistryEventRequest(),
                EventGridModelFactory.ContainerRegistryEventActor(),
                EventGridModelFactory.ContainerRegistryEventSource());

            Assert.AreEqual("id", model.Id);
            Assert.AreEqual("action", model.Action);
        }

        [Test]
        public void CanCreateContainerRegistryArtifactEventData()
        {
            var model = EventGridModelFactory.ContainerRegistryArtifactEventData(
                "id",
                DateTimeOffset.Now,
                "action",
                EventGridModelFactory.ContainerRegistryArtifactEventTarget());

            Assert.AreEqual("id", model.Id);
            Assert.AreEqual("action", model.Action);
        }
    }
}
