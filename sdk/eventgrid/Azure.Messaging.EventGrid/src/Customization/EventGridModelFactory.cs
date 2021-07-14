// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.Messaging.EventGrid.SystemEvents;

namespace Azure.Messaging.EventGrid
{
#pragma warning disable CA1054 // URI-like parameters should not be strings
    [CodeGenType(nameof(EventGridModelFactory))]
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
        public static MediaJobError MediaJobError(MediaJobErrorCode? code = default, string message = default, MediaJobErrorCategory? category = default, MediaJobRetry? retry = default, IReadOnlyList<MediaJobErrorDetail> details = default)
        {
            details ??= new List<MediaJobErrorDetail>();
            return new MediaJobError(code, message, category, retry, details);
        }

        /// <summary> Initializes new instance of MediaJobFinishedEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobFinishedEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobFinishedEventData MediaJobFinishedEventData(MediaJobState? previousState = default, MediaJobState? state = default, IReadOnlyDictionary<string, string> correlationData = default, IReadOnlyList<MediaJobOutput> outputs = default)
        {
            correlationData ??= new Dictionary<string, string>();
            outputs ??= new List<MediaJobOutput>();
            return new MediaJobFinishedEventData(previousState, state, correlationData, outputs);
        }

        /// <summary> Initializes new instance of MediaJobCanceledEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobCanceledEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobCanceledEventData MediaJobCanceledEventData(MediaJobState? previousState = default, MediaJobState? state = default, IReadOnlyDictionary<string, string> correlationData = default, IReadOnlyList<MediaJobOutput> outputs = default)
        {
            correlationData ??= new Dictionary<string, string>();
            outputs ??= new List<MediaJobOutput>();
            return new MediaJobCanceledEventData(previousState, state, correlationData, outputs);
        }

        /// <summary> Initializes new instance of MediaJobErroredEventData class. </summary>
        /// <param name="previousState"> The previous state of the Job. </param>
        /// <param name="state"> The new state of the Job. </param>
        /// <param name="correlationData"> Gets the Job correlation data. </param>
        /// <param name="outputs"> Gets the Job outputs. </param>
        /// <returns> A new <see cref="SystemEvents.MediaJobErroredEventData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MediaJobErroredEventData MediaJobErroredEventData(MediaJobState? previousState = default, MediaJobState? state = default, IReadOnlyDictionary<string, string> correlationData = default, IReadOnlyList<MediaJobOutput> outputs = default)
        {
            correlationData ??= new Dictionary<string, string>();
            outputs ??= new List<MediaJobOutput>();
            return new MediaJobErroredEventData(previousState, state, correlationData, outputs);
        }

        /// <summary> Initializes new instance of MapsGeofenceEventProperties class. </summary>
        /// <param name="expiredGeofenceGeometryId"> Lists of the geometry ID of the geofence which is expired relative to the user time in the request. </param>
        /// <param name="geometries"> Lists the fence geometries that either fully contain the coordinate position or have an overlap with the searchBuffer around the fence. </param>
        /// <param name="invalidPeriodGeofenceGeometryId"> Lists of the geometry ID of the geofence which is in invalid period relative to the user time in the request. </param>
        /// <param name="isEventPublished"> True if at least one event is published to the Azure Maps event subscriber, false if no event is published to the Azure Maps event subscriber. </param>
        /// <returns> A new <see cref="SystemEvents.MapsGeofenceEventProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MapsGeofenceEventProperties MapsGeofenceEventProperties(IReadOnlyList<string> expiredGeofenceGeometryId = default, IReadOnlyList<MapsGeofenceGeometry> geometries = default, IReadOnlyList<string> invalidPeriodGeofenceGeometryId = default, bool? isEventPublished = default)
        {
            expiredGeofenceGeometryId ??= new List<string>();
            geometries ??= new List<MapsGeofenceGeometry>();
            invalidPeriodGeofenceGeometryId ??= new List<string>();
            return new MapsGeofenceEventProperties(expiredGeofenceGeometryId, geometries, invalidPeriodGeofenceGeometryId, isEventPublished);
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
        public static AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(CommunicationIdentifierModel recipientCommunicationIdentifier = default, string transactionId = default, string threadId = default, DateTimeOffset? createTime = default, long? version = default, CommunicationIdentifierModel createdByCommunicationIdentifier = default, IReadOnlyDictionary<string, object> properties = default, IReadOnlyList<AcsChatThreadParticipantProperties> participants = default)
        {
            properties ??= new Dictionary<string, object>();
            participants ??= new List<AcsChatThreadParticipantProperties>();
            return new AcsChatThreadCreatedWithUserEventData(recipientCommunicationIdentifier, transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, participants);
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
        public static AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId = default, string threadId = default, DateTimeOffset? createTime = default, long? version = default, CommunicationIdentifierModel createdByCommunicationIdentifier = default, IReadOnlyDictionary<string, object> properties = default, IReadOnlyList<AcsChatThreadParticipantProperties> participants = default)
        {
            properties ??= new Dictionary<string, object>();
            participants ??= new List<AcsChatThreadParticipantProperties>();
            return new AcsChatThreadCreatedEventData(transactionId, threadId, createTime, version, createdByCommunicationIdentifier, properties, participants);
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
        public static AcsSmsDeliveryReportReceivedEventData AcsSmsDeliveryReportReceivedEventData(string messageId = default, string @from = default, string to = default, string deliveryStatus = default, string deliveryStatusDetails = default, IReadOnlyList<AcsSmsDeliveryAttemptProperties> deliveryAttempts = default, DateTimeOffset? receivedTimestamp = default, string tag = default)
        {
            deliveryAttempts ??= new List<AcsSmsDeliveryAttemptProperties>();
            return new AcsSmsDeliveryReportReceivedEventData(messageId, @from, to, deliveryStatus, deliveryStatusDetails, deliveryAttempts, receivedTimestamp, tag);
        }

        /// <summary> Initializes new instance of AcsRecordingStorageInfoProperties class. </summary>
        /// <param name="recordingChunks"> List of details of recording chunks information. </param>
        /// <returns> A new <see cref="SystemEvents.AcsRecordingStorageInfoProperties"/> instance for mocking. </returns>
        public static AcsRecordingStorageInfoProperties AcsRecordingStorageInfoProperties(IReadOnlyList<AcsRecordingChunkInfoProperties> recordingChunks = default)
        {
            recordingChunks ??= new List<AcsRecordingChunkInfoProperties>();
            return new AcsRecordingStorageInfoProperties(recordingChunks);
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
    }
#pragma warning restore CA1054 // URI-like parameters should not be strings
}
