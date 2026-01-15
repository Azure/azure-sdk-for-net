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

            Assert.That(model.Code, Is.EqualTo(MediaJobErrorCode.ConfigurationUnsupported));
            Assert.That(model.Message, Is.EqualTo("message"));
            Assert.That(model.Category, Is.EqualTo(MediaJobErrorCategory.Configuration));
        }

        [Test]
        public void CanCreateMediaJobFinishedEventData()
        {
            var model = EventGridModelFactory.MediaJobFinishedEventData(MediaJobState.Canceling, MediaJobState.Canceled, null, null);

            Assert.That(model.PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That(model.State, Is.EqualTo(MediaJobState.Canceled));
        }

        [Test]
        public void CanCreateMediaJobCanceledEventData()
        {
            var model = EventGridModelFactory.MediaJobCanceledEventData(MediaJobState.Canceling, MediaJobState.Canceled, null, null);

            Assert.That(model.PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That(model.State, Is.EqualTo(MediaJobState.Canceled));
        }

        [Test]
        public void CanCreateMediaJobErroredEventData()
        {
            var model = EventGridModelFactory.MediaJobErroredEventData(MediaJobState.Canceling, MediaJobState.Canceled, null, null);

            Assert.That(model.PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That(model.State, Is.EqualTo(MediaJobState.Canceled));
        }

        [Test]
        public void CanCreateMapsGeofenceEventProperties()
        {
            var model = EventGridModelFactory.MapsGeofenceEventProperties(new[]{"geometry"}, Array.Empty<MapsGeofenceGeometry>(), Array.Empty<string>(), true);

            CollectionAssert.Contains(model.ExpiredGeofenceGeometryId, "geometry");
            Assert.That(model.IsEventPublished, Is.True);
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

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
            Assert.That(model.Version, Is.EqualTo(1));
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

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
            Assert.That(model.Version, Is.EqualTo(1));
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

            Assert.That(model.MessageId, Is.EqualTo("message"));
            Assert.That(model.From, Is.EqualTo("from"));
            Assert.That(model.To, Is.EqualTo("to"));
            Assert.That(model.DeliveryStatus, Is.EqualTo("status"));
            Assert.That(model.DeliveryStatusDetails, Is.EqualTo("details"));
            Assert.That(model.Tag, Is.EqualTo("tag"));
        }

        [Test]
        public void CanCreateAcsRecordingStorageInfoProperties()
        {
            var model = EventGridModelFactory.AcsRecordingStorageInfoProperties(
                new List<AcsRecordingChunkInfoProperties>
                {
                    EventGridModelFactory.AcsRecordingChunkInfoProperties("document", 0, "reason", "location", "content")
                });

            Assert.That(model.RecordingChunks.First().DocumentId, Is.EqualTo("document"));
            Assert.That(model.RecordingChunks.First().Index, Is.EqualTo(0));
            Assert.That(model.RecordingChunks.First().EndReason, Is.EqualTo("reason"));
            Assert.That(model.RecordingChunks.First().MetadataLocation, Is.EqualTo("location"));
            Assert.That(model.RecordingChunks.First().ContentLocation, Is.EqualTo("content"));
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

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
            Assert.That(model.MessageId, Is.EqualTo("message"));
            Assert.That(model.SenderDisplayName, Is.EqualTo("sender"));
            Assert.That(model.Type, Is.EqualTo("type"));
            Assert.That(model.Version, Is.EqualTo(1));
            Assert.That(model.MessageBody, Is.EqualTo("body"));
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

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
            Assert.That(model.MessageId, Is.EqualTo("message"));
            Assert.That(model.SenderDisplayName, Is.EqualTo("sender"));
            Assert.That(model.Type, Is.EqualTo("type"));
            Assert.That(model.Version, Is.EqualTo(1));
        }

        [Test]
        public void CanCreateAcsChatEventInThreadBaseProperties()
        {
            var model = EventGridModelFactory.AcsChatEventInThreadBaseProperties(
                "transaction",
                "thread");

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
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

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
            Assert.That(model.MessageId, Is.EqualTo("message"));
            Assert.That(model.SenderDisplayName, Is.EqualTo("sender"));
            Assert.That(model.Type, Is.EqualTo("type"));
            Assert.That(model.Version, Is.EqualTo(1));
            Assert.That(model.MessageBody, Is.EqualTo("body"));
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

            Assert.That(model.TransactionId, Is.EqualTo("transaction"));
            Assert.That(model.ThreadId, Is.EqualTo("thread"));
            Assert.That(model.MessageId, Is.EqualTo("message"));
            Assert.That(model.SenderDisplayName, Is.EqualTo("sender"));
            Assert.That(model.Type, Is.EqualTo("type"));
            Assert.That(model.Version, Is.EqualTo(1));
            Assert.That(model.MessageBody, Is.EqualTo("body"));
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

            Assert.That(model.TrackType, Is.EqualTo("type"));
            Assert.That(model.TrackName, Is.EqualTo("name"));
            Assert.That(model.Bitrate, Is.EqualTo(5));
            Assert.That(model.IncomingBitrate, Is.EqualTo(10));
            Assert.That(model.LastTimestamp, Is.EqualTo("stamp"));
            Assert.That(model.Timescale, Is.EqualTo("scale"));
            Assert.That(model.OverlapCount, Is.EqualTo(1));
            Assert.That(model.DiscontinuityCount, Is.EqualTo(1));
            Assert.That(model.NonincreasingCount, Is.EqualTo(1));
            Assert.That(model.UnexpectedBitrate, Is.True);
            Assert.That(model.State, Is.EqualTo("state"));
            Assert.That(model.Healthy, Is.True);
        }

        [Test]
        public void CanCreateMediaLiveEventChannelArchiveHeartbeatEventData()
        {
            var model = EventGridModelFactory.MediaLiveEventChannelArchiveHeartbeatEventData(
                TimeSpan.Zero,
                "result");

            Assert.That(model.ChannelLatency, Is.EqualTo(TimeSpan.Zero));
            Assert.That(model.LatencyResultCode, Is.EqualTo("result"));
        }

        [Test]
        public void CanCreateAcsRecordingFileStatusUpdatedEventData()
        {
            var model = EventGridModelFactory.AcsRecordingFileStatusUpdatedEventData(
                EventGridModelFactory.AcsRecordingStorageInfoProperties(),
                DateTimeOffset.Now,
                10,
                "reason");

            Assert.That(model.RecordingDurationMs, Is.EqualTo(10));
            Assert.That(model.SessionEndReason, Is.EqualTo("reason"));

            model = EventGridModelFactory.AcsRecordingFileStatusUpdatedEventData(
                EventGridModelFactory.AcsRecordingStorageInfoProperties(),
                DateTimeOffset.Now,
                10,
                RecordingContentType.Audio,
                RecordingChannelType.Mixed,
                RecordingFormatType.Mp3);

            Assert.That(model.RecordingDurationMs, Is.EqualTo(10));
            Assert.That(model.ContentType, Is.EqualTo(AcsRecordingContentType.Audio));
            Assert.That(model.ChannelType, Is.EqualTo(AcsRecordingChannelType.Mixed));
            Assert.That(model.FormatType, Is.EqualTo(AcsRecordingFormatType.Mp3));

            // back compat
            Assert.That(model.RecordingContentType, Is.EqualTo(RecordingContentType.Audio));
            Assert.That(model.RecordingChannelType, Is.EqualTo(RecordingChannelType.Mixed));
            Assert.That(model.RecordingFormatType, Is.EqualTo(RecordingFormatType.Mp3));

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

            Assert.That(model.DocumentId, Is.EqualTo("document"));
            Assert.That(model.Index, Is.EqualTo(0));
            Assert.That(model.EndReason, Is.EqualTo("reason"));
            Assert.That(model.MetadataLocation, Is.EqualTo("location"));
            Assert.That(model.ContentLocation, Is.EqualTo("contentLocation"));
            Assert.That(model.DeleteLocation, Is.EqualTo("delete"));
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

            Assert.That(model.Id, Is.EqualTo("id"));
            Assert.That(model.Action, Is.EqualTo("action"));
        }

        [Test]
        public void CanCreateContainerRegistryArtifactEventData()
        {
            var model = EventGridModelFactory.ContainerRegistryArtifactEventData(
                "id",
                DateTimeOffset.Now,
                "action",
                EventGridModelFactory.ContainerRegistryArtifactEventTarget());

            Assert.That(model.Id, Is.EqualTo("id"));
            Assert.That(model.Action, Is.EqualTo("action"));
        }
    }
}
