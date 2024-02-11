// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Messaging.EventGrid.Models;
using Azure.Messaging.EventGrid.SystemEvents;
using AcsRouterJobStatus = Azure.Messaging.EventGrid.Models.AcsRouterJobStatus;

namespace Azure.Messaging.EventGrid
{
#pragma warning disable CA1054 // URI-like parameters should not be strings
    [CodeGenType("MessagingEventGridModelFactory")]
    public static partial class EventGridModelFactory
    {
        /// <summary> Initializes new instance of MediaJobError class. </summary>
        /// <param name="code"> Error code describing the error. </param>
        /// <param name="message"> A human-readable language-dependent representation of the error. </param>
        /// <param name="category"> Helps with categorization of errors. </param>
        /// <param name="retry"> Indicates that it may be possible to retry the Job. If retry is unsuccessful, please contact Azure support via Azure Portal. </param>
        /// <param name="details"> An array of details about specific errors that led to this reported error. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobError"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobError MediaJobError(MediaJobErrorCode? code, string message, MediaJobErrorCategory? category, MediaJobRetry? retry, IReadOnlyList<MediaJobErrorDetail> details)
        {
            return MediaJobError(code, message, category, retry, (IEnumerable<MediaJobErrorDetail>) details);
        }

        /// <summary> Initializes new instance of MediaJobFinishedEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobFinishedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobFinishedEventData MediaJobFinishedEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs)
        {
            return MediaJobFinishedEventData(previousState, state, correlationData, (IEnumerable<MediaJobOutput>) outputs);
        }

        /// <summary> Initializes new instance of MediaJobCanceledEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobCanceledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobCanceledEventData MediaJobCanceledEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs)
        {
            return MediaJobCanceledEventData(previousState, state, correlationData, (IEnumerable<MediaJobOutput>) outputs);
        }

        /// <summary> Initializes new instance of MediaJobErroredEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobErroredEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobErroredEventData MediaJobErroredEventData(MediaJobState? previousState, MediaJobState? state, IReadOnlyDictionary<string, string> correlationData, IReadOnlyList<MediaJobOutput> outputs)
        {
            return MediaJobErroredEventData(previousState, state, correlationData, (IEnumerable<MediaJobOutput>) outputs);
        }

        /// <summary> Initializes new instance of MapsGeofenceEventProperties class. </summary>
        /// <param name="expiredGeofenceGeometryId"> Lists of the geometry ID of the geofence which is expired relative to the user time in the request. </param>
        /// <param name="geometries"> Lists the fence geometries that either fully contain the coordinate position or have an overlap with the searchBuffer around the fence. </param>
        /// <param name="invalidPeriodGeofenceGeometryId"> Lists of the geometry ID of the geofence which is in invalid period relative to the user time in the request. </param>
        /// <param name="isEventPublished"> True if at least one event is published to the Azure Maps event subscriber, false if no event is published to the Azure Maps event subscriber. </param>
        /// <returns> A new <see cref="SystemEvents.MapsGeofenceEventProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsGeofenceEventProperties MapsGeofenceEventProperties(IReadOnlyList<string> expiredGeofenceGeometryId, IReadOnlyList<MapsGeofenceGeometry> geometries, IReadOnlyList<string> invalidPeriodGeofenceGeometryId, bool? isEventPublished)
        {
            return MapsGeofenceEventProperties((IEnumerable<string>) expiredGeofenceGeometryId, geometries, invalidPeriodGeofenceGeometryId, isEventPublished);
        }

        /// <summary> Initializes new instance of AcsChatThreadCreatedWithUserEventData class. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedWithUserEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel createdByCommunicationIdentifier, IReadOnlyDictionary<string, object> properties, IReadOnlyList<AcsChatThreadParticipantProperties> participants)
        {
            return AcsChatThreadCreatedWithUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), participants);
        }

        /// <summary> Initializes new instance of AcsChatThreadCreatedEventData class. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel createdByCommunicationIdentifier, IReadOnlyDictionary<string, object> properties, IReadOnlyList<AcsChatThreadParticipantProperties> participants)
        {
            return AcsChatThreadCreatedEventData(transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), (IEnumerable<AcsChatThreadParticipantProperties>) participants);
        }

        /// <summary> Initializes a new instance of AcsChatThreadCreatedWithUserEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedWithUserEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel createdByCommunicationIdentifier, IReadOnlyDictionary<string, object> properties, IEnumerable<AcsChatThreadParticipantProperties> participants)
        {
            properties ??= new Dictionary<string, object>();
            participants ??= new List<AcsChatThreadParticipantProperties>();

            return new AcsChatThreadCreatedWithUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), participants?.ToList());
        }

        /// <summary> Initializes a new instance of AcsChatThreadParticipantProperties. </summary>
        /// <param name="displayName"> The name of the user. </param>
        /// <param name="participantCommunicationIdentifier"> The communication identifier of the user. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadParticipantProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadParticipantProperties AcsChatThreadParticipantProperties(string displayName, CommunicationIdentifierModel participantCommunicationIdentifier)
        {
            return new AcsChatThreadParticipantProperties(displayName, participantCommunicationIdentifier, new Dictionary<string, string>());
        }

        /// <summary> Initializes a new instance of AcsChatThreadPropertiesUpdatedPerUserEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="editedByCommunicationIdentifier"> The communication identifier of the user who updated the thread properties. </param>
        /// <param name="editTime"> The time at which the properties of the thread were updated. </param>
        /// <param name="properties"> The updated thread properties. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadPropertiesUpdatedPerUserEventData AcsChatThreadPropertiesUpdatedPerUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, DateTimeOffset? createTime = null, long? version = null, CommunicationIdentifierModel editedByCommunicationIdentifier = null, DateTimeOffset? editTime = null, IReadOnlyDictionary<string, object> properties = null)
        {
            properties ??= new Dictionary<string, object>();

            return new AcsChatThreadPropertiesUpdatedPerUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, editedByCommunicationIdentifier, editTime, new Dictionary<string, string>(), properties);
        }

        /// <summary> Initializes a new instance of AcsChatThreadPropertiesUpdatedEventData. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="editedByCommunicationIdentifier"> The communication identifier of the user who updated the thread properties. </param>
        /// <param name="editTime"> The time at which the properties of the thread were updated. </param>
        /// <param name="properties"> The updated thread properties. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadPropertiesUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadPropertiesUpdatedEventData AcsChatThreadPropertiesUpdatedEventData(string transactionId, string threadId, DateTimeOffset? createTime, long? version, CommunicationIdentifierModel editedByCommunicationIdentifier, DateTimeOffset? editTime, IReadOnlyDictionary<string, object> properties)
        {
            properties ??= new Dictionary<string, object>();

            return new AcsChatThreadPropertiesUpdatedEventData(transactionId, threadId, createTime, version, editedByCommunicationIdentifier, editTime, properties, new Dictionary<string, string>());
        }

        /// <summary> Initializes a new instance of <see cref="SystemEvents.AcsChatThreadCreatedEventData"/>. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="createTime"> The original creation time of the thread. </param>
        /// <param name="version"> The version of the thread. </param>
        /// <param name="createdByCommunicationIdentifier"> The communication identifier of the user who created the thread. </param>
        /// <param name="properties"> The thread properties. </param>
        /// <param name="participants"> The list of properties of participants who are part of the thread. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatThreadCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId = null, string threadId = null, DateTimeOffset? createTime = null, long? version = null, CommunicationIdentifierModel createdByCommunicationIdentifier = null, IReadOnlyDictionary<string, object> properties = null, IEnumerable<AcsChatThreadParticipantProperties> participants = null)
        {
            properties ??= new Dictionary<string, object>();
            participants ??= new List<AcsChatThreadParticipantProperties>();

            return new AcsChatThreadCreatedEventData(transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, new Dictionary<string, string>(), participants?.ToList());
        }

        /// <summary> Initializes new instance of AcsSmsDeliveryReportReceivedEventData class. </summary>
        /// <param name="messageId"> The identity of the SMS message. </param>
        /// <param name="from"> The identity of SMS message sender. </param>
        /// <param name="to"> The identity of SMS message receiver. </param>
        /// <param name="deliveryStatus"> Status of Delivery. </param>
        /// <param name="deliveryStatusDetails"> Details about Delivery Status. </param>
        /// <param name="deliveryAttempts"> List of details of delivery attempts made. </param>
        /// <param name="receivedTimestamp"> The time at which the SMS delivery report was received. </param>
        /// <param name="tag"> Customer Content. </param>
        /// <returns> A new <see cref="SystemEvents.AcsSmsDeliveryReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsSmsDeliveryReportReceivedEventData AcsSmsDeliveryReportReceivedEventData(string messageId, string @from, string to, string deliveryStatus, string deliveryStatusDetails, IReadOnlyList<AcsSmsDeliveryAttemptProperties> deliveryAttempts, DateTimeOffset? receivedTimestamp, string tag)
        {
            return AcsSmsDeliveryReportReceivedEventData(messageId, @from, to, deliveryStatus, deliveryStatusDetails, (IEnumerable<AcsSmsDeliveryAttemptProperties>) deliveryAttempts, receivedTimestamp, tag);
        }

        /// <summary> Initializes new instance of AcsRecordingStorageInfoProperties class. </summary>
        /// <param name="recordingChunks"> List of details of recording chunks information. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingStorageInfoProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingStorageInfoProperties AcsRecordingStorageInfoProperties(IReadOnlyList<AcsRecordingChunkInfoProperties> recordingChunks)
        {
            return AcsRecordingStorageInfoProperties((IEnumerable<AcsRecordingChunkInfoProperties>) recordingChunks);
        }

        /// <summary> Initializes new instance of ResourceWriteSuccessEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceWriteSuccessEventData"/> instance for mocking. </returns>
        public static ResourceWriteSuccessEventData ResourceWriteSuccessEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceWriteFailureEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceWriteFailureEventData"/> instance for mocking. </returns>
        public static ResourceWriteFailureEventData ResourceWriteFailureEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceWriteCancelEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceWriteCancelEventData"/> instance for mocking. </returns>
        public static ResourceWriteCancelEventData ResourceWriteCancelEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceDeleteSuccessEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceDeleteSuccessEventData"/> instance for mocking. </returns>
        public static ResourceDeleteSuccessEventData ResourceDeleteSuccessEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceDeleteFailureEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceDeleteFailureEventData"/> instance for mocking. </returns>
        public static ResourceDeleteFailureEventData ResourceDeleteFailureEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceDeleteCancelEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceDeleteCancelEventData"/> instance for mocking. </returns>
        public static ResourceDeleteCancelEventData ResourceDeleteCancelEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceActionSuccessEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceActionSuccessEventData"/> instance for mocking. </returns>
        public static ResourceActionSuccessEventData ResourceActionSuccessEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceActionFailureEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceActionFailureEventData"/> instance for mocking. </returns>
        public static ResourceActionFailureEventData ResourceActionFailureEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of ResourceActionCancelEventData class. </summary>
        /// <param name="tenantId"> The tenant ID of the resource. </param>
        /// <param name="subscriptionId"> The subscription ID of the resource. </param>
        /// <param name="resourceGroup"> The resource group of the resource. </param>
        /// <param name="resourceProvider"> The resource provider performing the operation. </param>
        /// <param name="resourceUri"> The URI of the resource in the operation. </param>
        /// <param name="operationName"> The operation that was performed. </param>
        /// <param name="status"> The status of the operation. </param>
        /// <param name="authorization"> The requested authorization for the operation. </param>
        /// <param name="claims"> The properties of the claims. </param>
        /// <param name="correlationId"> An operation ID used for troubleshooting. </param>
        /// <param name="httpRequest"> The details of the operation. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceActionCancelEventData"/> instance for mocking. </returns>
        public static ResourceActionCancelEventData ResourceActionCancelEventData(string tenantId = default, string subscriptionId = default, string resourceGroup = default, string resourceProvider = default, string resourceUri = default, string operationName = default, string status = default, string authorization = default, string claims = default, string correlationId = default, string httpRequest = default)
        {
            return new(tenantId, subscriptionId, resourceGroup, resourceProvider, resourceUri, operationName, status, JsonDocument.Parse(authorization).RootElement, JsonDocument.Parse(claims).RootElement, correlationId, JsonDocument.Parse(httpRequest).RootElement);
        }

        /// <summary> Initializes new instance of SubscriptionValidationResponse class. </summary>
        /// <param name="validationResponse"> The validation response sent by the subscriber to Azure Event Grid to complete the validation of an event subscription. </param>
        /// <returns> A new <see cref="SystemEvents.SubscriptionValidationResponse"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionValidationResponse SubscriptionValidationResponse(string validationResponse = default)
        {
            return new(validationResponse);
        }

        /// <summary> Initializes a new instance of AcsChatMessageReceivedEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageReceivedEventData AcsChatMessageReceivedEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody)
        {
            return AcsChatMessageReceivedEventData(recipientCommunicationIdentifier, transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>());
        }

        /// <summary> Initializes a new instance of AcsChatMessageReceivedInThreadEventData. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageReceivedInThreadEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageReceivedInThreadEventData AcsChatMessageReceivedInThreadEventData(string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody)
        {
            return AcsChatMessageReceivedInThreadEventData(transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>());
        }

        /// <summary> Initializes a new instance of AcsChatMessageEditedEventData. </summary>
        /// <param name="recipientCommunicationIdentifier"> The communication identifier of the target user. </param>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <param name="editTime"> The time at which the message was edited. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageEditedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageEditedEventData AcsChatMessageEditedEventData(CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody, DateTimeOffset? editTime)
        {
            return AcsChatMessageEditedEventData(recipientCommunicationIdentifier, transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>(), editTime);
        }

        /// <summary> Initializes a new instance of AcsChatMessageEditedInThreadEventData. </summary>
        /// <param name="transactionId"> The transaction id will be used as co-relation vector. </param>
        /// <param name="threadId"> The chat thread id. </param>
        /// <param name="messageId"> The chat message id. </param>
        /// <param name="senderCommunicationIdentifier"> The communication identifier of the sender. </param>
        /// <param name="senderDisplayName"> The display name of the sender. </param>
        /// <param name="composeTime"> The original compose time of the message. </param>
        /// <param name="type"> The type of the message. </param>
        /// <param name="version"> The version of the message. </param>
        /// <param name="messageBody"> The body of the chat message. </param>
        /// <param name="editTime"> The time at which the message was edited. </param>
        /// <returns> A new <see cref="SystemEvents.AcsChatMessageEditedInThreadEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsChatMessageEditedInThreadEventData AcsChatMessageEditedInThreadEventData(string transactionId, string threadId, string messageId, CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, DateTimeOffset? composeTime, string type, long? version, string messageBody, DateTimeOffset? editTime)
        {
            return AcsChatMessageEditedInThreadEventData(transactionId, threadId, messageId, senderCommunicationIdentifier, senderDisplayName, composeTime, type, version, messageBody, new ChangeTrackingDictionary<string, string>(), editTime);
        }

        /// <summary> Initializes a new instance of MediaLiveEventIngestHeartbeatEventData. </summary>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="incomingBitrate"> Gets the incoming bitrate. </param>
        /// <param name="lastTimestamp"> Gets the last timestamp. </param>
        /// <param name="timescale"> Gets the timescale of the last timestamp. </param>
        /// <param name="overlapCount"> Gets the fragment Overlap count. </param>
        /// <param name="discontinuityCount"> Gets the fragment Discontinuity count. </param>
        /// <param name="nonincreasingCount"> Gets Non increasing count. </param>
        /// <param name="unexpectedBitrate"> Gets a value indicating whether unexpected bitrate is present or not. </param>
        /// <param name="state"> Gets the state of the live event. </param>
        /// <param name="healthy"> Gets a value indicating whether preview is healthy or not. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIngestHeartbeatEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaLiveEventIngestHeartbeatEventData MediaLiveEventIngestHeartbeatEventData(string trackType, string trackName, long? bitrate, long? incomingBitrate, string lastTimestamp, string timescale, long? overlapCount, long? discontinuityCount, long? nonincreasingCount, bool? unexpectedBitrate, string state, bool? healthy)
        {
            return MediaLiveEventIngestHeartbeatEventData(trackType, trackName, default, default, bitrate, incomingBitrate, default, default, lastTimestamp, timescale, overlapCount, discontinuityCount, nonincreasingCount, unexpectedBitrate, state, healthy);
        }

        /// <summary> Initializes a new instance of MediaLiveEventIngestHeartbeatEventData. </summary>
        /// <param name="trackType"> Gets the type of the track (Audio / Video). </param>
        /// <param name="trackName"> Gets the track name. </param>
        /// <param name="transcriptionLanguage"> Gets the Live Transcription language. </param>
        /// <param name="transcriptionState"> Gets the Live Transcription state. </param>
        /// <param name="bitrate"> Gets the bitrate of the track. </param>
        /// <param name="incomingBitrate"> Gets the incoming bitrate. </param>
        /// <param name="ingestDriftValue"> Gets the track ingest drift value. </param>
        /// <param name="lastFragmentArrivalTime"> Gets the arrival UTC time of the last fragment. </param>
        /// <param name="lastTimestamp"> Gets the last timestamp. </param>
        /// <param name="timescale"> Gets the timescale of the last timestamp. </param>
        /// <param name="overlapCount"> Gets the fragment Overlap count. </param>
        /// <param name="discontinuityCount"> Gets the fragment Discontinuity count. </param>
        /// <param name="nonincreasingCount"> Gets Non increasing count. </param>
        /// <param name="unexpectedBitrate"> Gets a value indicating whether unexpected bitrate is present or not. </param>
        /// <param name="state"> Gets the state of the live event. </param>
        /// <param name="healthy"> Gets a value indicating whether preview is healthy or not. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventIngestHeartbeatEventData"/> instance for mocking. </returns>
        public static MediaLiveEventIngestHeartbeatEventData MediaLiveEventIngestHeartbeatEventData(string trackType = null, string trackName = null, string transcriptionLanguage = null, string transcriptionState = null, long? bitrate = null, long? incomingBitrate = null, int? ingestDriftValue = null, DateTimeOffset? lastFragmentArrivalTime = null, string lastTimestamp = null, string timescale = null, long? overlapCount = null, long? discontinuityCount = null, long? nonincreasingCount = null, bool? unexpectedBitrate = null, string state = null, bool? healthy = null)
        {
            return new MediaLiveEventIngestHeartbeatEventData(trackType, trackName, transcriptionLanguage, transcriptionState, bitrate, incomingBitrate, ingestDriftValue == null ? Constants.MediaEvents.NotApplicable : ingestDriftValue.Value.ToString(CultureInfo.InvariantCulture), lastFragmentArrivalTime, lastTimestamp, timescale, overlapCount, discontinuityCount, nonincreasingCount, unexpectedBitrate, state, healthy);
        }

        /// <summary> Initializes a new instance of MediaLiveEventChannelArchiveHeartbeatEventData. </summary>
        /// <param name="channelLatency"> The channel latency. </param>
        /// <param name="latencyResultCode"> The latency result code. </param>
        /// <returns> A new <see cref="SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData"/> instance for mocking. </returns>
        public static MediaLiveEventChannelArchiveHeartbeatEventData MediaLiveEventChannelArchiveHeartbeatEventData(TimeSpan? channelLatency = null, string latencyResultCode = null)
        {
            return new MediaLiveEventChannelArchiveHeartbeatEventData(channelLatency == null ? Constants.MediaEvents.NotApplicable : channelLatency.Value.Milliseconds.ToString(CultureInfo.InvariantCulture), latencyResultCode);
        }

        /// <summary> Initializes a new instance of AcsRecordingFileStatusUpdatedEventData. </summary>
        /// <param name="recordingStorageInfo"> The details of recording storage information. </param>
        /// <param name="recordingStartTime"> The time at which the recording started. </param>
        /// <param name="recordingDurationMs"> The recording duration in milliseconds. </param>
        /// <param name="sessionEndReason"> The reason for ending recording session. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingFileStatusUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(AcsRecordingStorageInfoProperties recordingStorageInfo, DateTimeOffset? recordingStartTime, long? recordingDurationMs, string sessionEndReason)
        {
            return AcsRecordingFileStatusUpdatedEventData(recordingStorageInfo: recordingStorageInfo, recordingStartTime: recordingStartTime, recordingDurationMs: recordingDurationMs, sessionEndReason: sessionEndReason, channelType: null);
        }

        /// <summary> Initializes a new instance of AcsRecordingFileStatusUpdatedEventData. </summary>
        /// <param name="recordingStorageInfo"> The details of recording storage information. </param>
        /// <param name="recordingStartTime"> The time at which the recording started. </param>
        /// <param name="recordingDurationMs"> The recording duration in milliseconds. </param>
        /// <param name="recordingContentType"> The recording content type- AudioVideo, or Audio. </param>
        /// <param name="recordingChannelType"> The recording  channel type - Mixed, Unmixed. </param>
        /// <param name="recordingFormatType"> The recording format type - Mp4, Mp3, Wav. </param>
        /// <param name="sessionEndReason"> The reason for ending recording session. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingFileStatusUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(AcsRecordingStorageInfoProperties recordingStorageInfo = null, DateTimeOffset? recordingStartTime = null, long? recordingDurationMs = null, RecordingContentType? recordingContentType = null, RecordingChannelType? recordingChannelType = null, RecordingFormatType? recordingFormatType = null, string sessionEndReason = null)
        {
            var contentType = recordingContentType != null ? new AcsRecordingContentType(recordingContentType.ToString()) : null;
            var channelType = recordingChannelType != null ? new AcsRecordingChannelType(recordingChannelType.ToString()) : null;
            var formatType = recordingFormatType != null ? new AcsRecordingFormatType(recordingFormatType.ToString()) : null;
            return AcsRecordingFileStatusUpdatedEventData(recordingStorageInfo, recordingStartTime, recordingDurationMs, contentType, channelType, formatType, sessionEndReason);
        }

        /// <summary> Initializes a new instance of AcsRecordingFileStatusUpdatedEventData. </summary>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingFileStatusUpdatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData()
        {
            return new AcsRecordingFileStatusUpdatedEventData(null, null, null, null, null, null, null);
        }

        /// <summary> Initializes a new instance of AcsRecordingChunkInfoProperties. </summary>
        /// <param name="documentId"> The documentId of the recording chunk. </param>
        /// <param name="index"> The index of the recording chunk. </param>
        /// <param name="endReason"> The reason for ending the recording chunk. </param>
        /// <param name="metadataLocation"> The location of the metadata for this chunk. </param>
        /// <param name="contentLocation"> The location of the content for this chunk. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingChunkInfoProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRecordingChunkInfoProperties AcsRecordingChunkInfoProperties(string documentId, long? index, string endReason, string metadataLocation, string contentLocation)
        {
            return AcsRecordingChunkInfoProperties(documentId: documentId, index: index, endReason: endReason, metadataLocation: metadataLocation, contentLocation: contentLocation, deleteLocation: null);
        }

        /// <summary> Initializes a new instance of ContainerRegistryEventData. </summary>
        /// <param name="id"> The event ID. </param>
        /// <param name="timestamp"> The time at which the event occurred. </param>
        /// <param name="action"> The action that encompasses the provided event. </param>
        /// <param name="target"> The target of the event. </param>
        /// <param name="request"> The request that generated the event. </param>
        /// <param name="actor"> The agent that initiated the event. For most situations, this could be from the authorization context of the request. </param>
        /// <param name="source"> The registry node that generated the event. Put differently, while the actor initiates the event, the source generates it. </param>
        /// <returns> A new <see cref="SystemEvents.ContainerRegistryEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryEventData ContainerRegistryEventData(string id, DateTimeOffset? timestamp, string action, ContainerRegistryEventTarget target, ContainerRegistryEventRequest request, ContainerRegistryEventActor actor, ContainerRegistryEventSource source)
        {
            return ContainerRegistryEventData(id: id, timestamp: timestamp, action: action, target: target, request: request, actor: actor, source: source, location: null);
        }

        /// <summary> Initializes a new instance of ContainerRegistryArtifactEventData. </summary>
        /// <param name="id"> The event ID. </param>
        /// <param name="timestamp"> The time at which the event occurred. </param>
        /// <param name="action"> The action that encompasses the provided event. </param>
        /// <param name="target"> The target of the event. </param>
        /// <returns> A new <see cref="SystemEvents.ContainerRegistryArtifactEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryArtifactEventData ContainerRegistryArtifactEventData(string id = null, DateTimeOffset? timestamp = null, string action = null, ContainerRegistryArtifactEventTarget target = null)
        {
            return ContainerRegistryArtifactEventData(id: id, timestamp: timestamp, action: action, target: target, location: null);
        }

        /// <summary> Initializes a new instance of ResourceHttpRequest. </summary>
        /// <param name="clientRequestId"> The client request ID. </param>
        /// <param name="clientIpAddress"> The client IP address. </param>
        /// <param name="method"> The request method. </param>
        /// <param name="url"> The url used in the request. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceHttpRequest"/> instance for mocking. </returns>
        public static ResourceHttpRequest ResourceHttpRequest(string clientRequestId = null, string clientIpAddress = null, RequestMethod? method = null, string url = null)
        {
            return new ResourceHttpRequest(clientRequestId, clientIpAddress, method?.Method, url);
        }

        /// <summary> Initializes a new instance of StorageDirectoryDeletedEventData. </summary>
        /// <param name="api"> The name of the API/operation that triggered this event. </param>
        /// <param name="clientRequestId"> A request id provided by the client of the storage API operation that triggered this event. </param>
        /// <param name="requestId"> The request id generated by the storage service for the storage API operation that triggered this event. </param>
        /// <param name="url"> The path to the deleted directory. </param>
        /// <param name="recursive"> Is this event for a recursive delete operation. </param>
        /// <param name="sequencer"> An opaque string value representing the logical sequence of events for any particular directory name. Users can use standard string comparison to understand the relative sequence of two events on the same directory name. </param>
        /// <param name="identity"> The identity of the requester that triggered this event. </param>
        /// <param name="storageDiagnostics"> For service use only. Diagnostic data occasionally included by the Azure Storage service. This property should be ignored by event consumers. </param>
        /// <returns> A new <see cref="SystemEvents.StorageDirectoryDeletedEventData"/> instance for mocking. </returns>
        public static StorageDirectoryDeletedEventData StorageDirectoryDeletedEventData(string api = null, string clientRequestId = null, string requestId = null, string url = null, bool? recursive = null, string sequencer = null, string identity = null, object storageDiagnostics = null)
        {
            return new StorageDirectoryDeletedEventData(api, clientRequestId, requestId, url, recursive?.ToString(), sequencer, identity, storageDiagnostics);
        }

        /// <summary> Initializes a new instance of AcsEmailDeliveryReportReceivedEventData. </summary>
        /// <param name="sender"> The Sender Email Address. </param>
        /// <param name="recipient"> The recipient Email Address. </param>
        /// <param name="messageId"> The Id of the email been sent. </param>
        /// <param name="status"> The status of the email. </param>
        /// <param name="deliveryAttemptTimestamp"> The time at which the email delivery report received timestamp. </param>
        /// <returns> A new <see cref="SystemEvents.AcsEmailDeliveryReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsEmailDeliveryReportReceivedEventData AcsEmailDeliveryReportReceivedEventData(string sender = null, string recipient = null, string messageId = null, AcsEmailDeliveryReportStatus? status = null, DateTimeOffset? deliveryAttemptTimestamp = null)
        {
            return new AcsEmailDeliveryReportReceivedEventData(sender, recipient, messageId, status, default, deliveryAttemptTimestamp);
        }

        /// <summary> Initializes a new instance of HealthcareDicomImageCreatedEventData. </summary>
        /// <param name="imageStudyInstanceUid"> Unique identifier for the Study. </param>
        /// <param name="imageSeriesInstanceUid"> Unique identifier for the Series. </param>
        /// <param name="imageSopInstanceUid"> Unique identifier for the DICOM Image. </param>
        /// <param name="serviceHostName"> Domain name of the DICOM account for this image. </param>
        /// <param name="sequenceNumber"> Sequence number of the DICOM Service within Azure Health Data Services. It is unique for every image creation and deletion within the service. </param>
        /// <returns> A new <see cref="SystemEvents.HealthcareDicomImageCreatedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareDicomImageCreatedEventData HealthcareDicomImageCreatedEventData(string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = null)
        {
            return new HealthcareDicomImageCreatedEventData(default, imageStudyInstanceUid, imageSeriesInstanceUid, imageSopInstanceUid, serviceHostName, sequenceNumber);
        }

        /// <summary> Initializes a new instance of HealthcareDicomImageDeletedEventData. </summary>
        /// <param name="imageStudyInstanceUid"> Unique identifier for the Study. </param>
        /// <param name="imageSeriesInstanceUid"> Unique identifier for the Series. </param>
        /// <param name="imageSopInstanceUid"> Unique identifier for the DICOM Image. </param>
        /// <param name="serviceHostName"> Host name of the DICOM account for this image. </param>
        /// <param name="sequenceNumber"> Sequence number of the DICOM Service within Azure Health Data Services. It is unique for every image creation and deletion within the service. </param>
        /// <returns> A new <see cref="SystemEvents.HealthcareDicomImageDeletedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareDicomImageDeletedEventData HealthcareDicomImageDeletedEventData(string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = null)
        {
            return new HealthcareDicomImageDeletedEventData(default, imageStudyInstanceUid, imageSeriesInstanceUid, imageSopInstanceUid, serviceHostName, sequenceNumber);
        }

        /// <summary> Initializes a new instance of AcsEmailEngagementTrackingReportReceivedEventData. </summary>
        /// <param name="sender"> The Sender Email Address. </param>
        /// <param name="messageId"> The Id of the email that has been sent. </param>
        /// <param name="userActionTimestamp"> The time at which the user interacted with the email. </param>
        /// <param name="engagementContext"> The context of the type of engagement user had with email. </param>
        /// <param name="userAgent"> The user agent interacting with the email. </param>
        /// <param name="engagement"> The type of engagement user have with email. </param>
        /// <returns> A new <see cref="SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsEmailEngagementTrackingReportReceivedEventData AcsEmailEngagementTrackingReportReceivedEventData(string sender, string messageId, DateTimeOffset? userActionTimestamp, string engagementContext, string userAgent, AcsUserEngagement? engagement)
        {
            return new AcsEmailEngagementTrackingReportReceivedEventData(sender, null, messageId, userActionTimestamp, engagementContext, userAgent, engagement);
        }

        /// <summary> Initializes a new instance of AcsRouterJobReceivedEventData. </summary>
        /// <param name="jobId"> Router Event Job ID. </param>
        /// <param name="channelReference"> Router Event Channel Reference. </param>
        /// <param name="channelId"> Router Event Channel ID. </param>
        /// <param name="queueId"> Router Job events Queue Id. </param>
        /// <param name="labels"> Router Job events Labels. </param>
        /// <param name="tags"> Router Jobs events Tags. </param>
        /// <param name="jobStatus"> Router Job Received Job Status. </param>
        /// <param name="classificationPolicyId"> Router Job Classification Policy Id. </param>
        /// <param name="priority"> Router Job Priority. </param>
        /// <param name="requestedWorkerSelectors"> Router Job Received Requested Worker Selectors. </param>
        /// <param name="scheduledOn"> Router Job Received Scheduled Time in UTC. </param>
        /// <param name="unavailableForMatching"> Unavailable For Matching for Router Job Received. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRouterJobReceivedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AcsRouterJobReceivedEventData AcsRouterJobReceivedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, IReadOnlyDictionary<string, string> labels = null, IReadOnlyDictionary<string, string> tags = null, Azure.Messaging.EventGrid.Models.AcsRouterJobStatus? jobStatus = null, string classificationPolicyId = null, int? priority = null, IEnumerable<AcsRouterWorkerSelector> requestedWorkerSelectors = null, DateTimeOffset? scheduledOn = null, bool unavailableForMatching = default)
        {
            labels ??= new Dictionary<string, string>();
            tags ??= new Dictionary<string, string>();
            requestedWorkerSelectors ??= new List<AcsRouterWorkerSelector>();
            Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus? status = jobStatus.HasValue ? new Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus(jobStatus.ToString()) : null;

            return new AcsRouterJobReceivedEventData(jobId, channelReference, channelId, queueId, labels, tags, status, classificationPolicyId, priority, requestedWorkerSelectors?.ToList(), scheduledOn, unavailableForMatching);
        }

        /// <summary> Initializes a new instance of ResourceNotificationsResourceUpdatedDetails. </summary>
        /// <param name="id"> id of the resource for which the event is being emitted. </param>
        /// <param name="name"> name of the resource for which the event is being emitted. </param>
        /// <param name="resourceType"> the type of the resource for which the event is being emitted. </param>
        /// <param name="location"> the location of the resource for which the event is being emitted. </param>
        /// <param name="tags"> the tags on the resource for which the event is being emitted. </param>
        /// <param name="properties"> properties in the payload of the resource for which the event is being emitted. </param>
        /// <returns> A new <see cref="SystemEvents.ResourceNotificationsResourceUpdatedDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use the other overload ResourceNotificationsResourceUpdatedDetails.")]
        public static ResourceNotificationsResourceUpdatedDetails ResourceNotificationsResourceUpdatedDetails(string id = null, string name = null, string resourceType = null, string location = null, string tags = null, IReadOnlyDictionary<string, object> properties = null)
        {
            properties ??= new Dictionary<string, object>();

            return new ResourceNotificationsResourceUpdatedDetails(id, name, resourceType, location,
                new Dictionary<string, string>(), properties)
            {
                Tags = tags
            };
        }
    }
#pragma warning restore CA1054 // URI-like parameters should not be strings
}
