namespace Azure.Messaging.EventGrid
{
    public partial class EventGridEvent
    {
        public EventGridEvent(string subject, string eventType, string dataVersion, System.BinaryData data) { }
        public EventGridEvent(string subject, string eventType, string dataVersion, object data, System.Type dataSerializationType = null) { }
        public System.BinaryData Data { get { throw null; } set { } }
        public string DataVersion { get { throw null; } set { } }
        public System.DateTimeOffset EventTime { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
        public static Azure.Messaging.EventGrid.EventGridEvent Parse(System.BinaryData json) { throw null; }
        public static Azure.Messaging.EventGrid.EventGridEvent[] ParseMany(System.BinaryData json) { throw null; }
        public bool TryGetSystemEventData(out object eventData) { throw null; }
    }
    public static partial class EventGridExtensions
    {
        public static bool TryGetSystemEventData(this Azure.Messaging.CloudEvent cloudEvent, out object eventData) { throw null; }
    }
    public static partial class EventGridModelFactory
    {
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties AcsChatEventBaseProperties(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties AcsChatEventInThreadBaseProperties(string transactionId = null, string threadId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData AcsChatMessageDeletedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?), System.DateTimeOffset? deleteTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData AcsChatMessageDeletedInThreadEventData(string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?), System.DateTimeOffset? deleteTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData AcsChatMessageEditedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?), string messageBody = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.DateTimeOffset? editTime = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData AcsChatMessageEditedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, string messageId, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, System.DateTimeOffset? composeTime, string type, long? version, string messageBody, System.DateTimeOffset? editTime) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData AcsChatMessageEditedInThreadEventData(string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?), string messageBody = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.DateTimeOffset? editTime = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData AcsChatMessageEditedInThreadEventData(string transactionId, string threadId, string messageId, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, System.DateTimeOffset? composeTime, string type, long? version, string messageBody, System.DateTimeOffset? editTime) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties AcsChatMessageEventBaseProperties(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties AcsChatMessageEventInThreadBaseProperties(string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData AcsChatMessageReceivedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, string messageId, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, System.DateTimeOffset? composeTime, string type, long? version, string messageBody) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData AcsChatMessageReceivedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?), string messageBody = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData AcsChatMessageReceivedInThreadEventData(string transactionId, string threadId, string messageId, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier, string senderDisplayName, System.DateTimeOffset? composeTime, string type, long? version, string messageBody) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData AcsChatMessageReceivedInThreadEventData(string transactionId = null, string threadId = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel senderCommunicationIdentifier = null, string senderDisplayName = null, System.DateTimeOffset? composeTime = default(System.DateTimeOffset?), string type = null, long? version = default(long?), string messageBody = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData AcsChatParticipantAddedToThreadEventData(string transactionId = null, string threadId = null, System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel addedByCommunicationIdentifier = null, Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties participantAdded = null, long? version = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData AcsChatParticipantAddedToThreadWithUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel addedByCommunicationIdentifier = null, Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties participantAdded = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData AcsChatParticipantRemovedFromThreadEventData(string transactionId = null, string threadId = null, System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel removedByCommunicationIdentifier = null, Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties participantRemoved = null, long? version = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData AcsChatParticipantRemovedFromThreadWithUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel removedByCommunicationIdentifier = null, Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties participantRemoved = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel createdByCommunicationIdentifier = null, System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> participants = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData AcsChatThreadCreatedEventData(string transactionId, string threadId, System.DateTimeOffset? createTime, long? version, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel createdByCommunicationIdentifier, System.Collections.Generic.IReadOnlyDictionary<string, object> properties, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> participants) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, System.DateTimeOffset? createTime, long? version, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel createdByCommunicationIdentifier, System.Collections.Generic.IReadOnlyDictionary<string, object> properties, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> participants) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel createdByCommunicationIdentifier = null, System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> participants = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData AcsChatThreadCreatedWithUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier, string transactionId, string threadId, System.DateTimeOffset? createTime, long? version, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel createdByCommunicationIdentifier, System.Collections.Generic.IReadOnlyDictionary<string, object> properties, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> participants) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData AcsChatThreadDeletedEventData(string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel deletedByCommunicationIdentifier = null, System.DateTimeOffset? deleteTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties AcsChatThreadEventBaseProperties(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties AcsChatThreadEventInThreadBaseProperties(string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties AcsChatThreadParticipantProperties(string displayName, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel participantCommunicationIdentifier) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties AcsChatThreadParticipantProperties(string displayName = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel participantCommunicationIdentifier = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData AcsChatThreadPropertiesUpdatedEventData(string transactionId, string threadId, System.DateTimeOffset? createTime, long? version, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel editedByCommunicationIdentifier, System.DateTimeOffset? editTime, System.Collections.Generic.IReadOnlyDictionary<string, object> properties) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData AcsChatThreadPropertiesUpdatedEventData(string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel editedByCommunicationIdentifier = null, System.DateTimeOffset? editTime = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData AcsChatThreadPropertiesUpdatedPerUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel editedByCommunicationIdentifier = null, System.DateTimeOffset? editTime = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData AcsChatThreadPropertiesUpdatedPerUserEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel editedByCommunicationIdentifier = null, System.DateTimeOffset? editTime = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData AcsChatThreadWithUserDeletedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel recipientCommunicationIdentifier = null, string transactionId = null, string threadId = null, System.DateTimeOffset? createTime = default(System.DateTimeOffset?), long? version = default(long?), Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel deletedByCommunicationIdentifier = null, System.DateTimeOffset? deleteTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData AcsEmailDeliveryReportReceivedEventData(string sender = null, string recipient = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus? status = default(Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus?), Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails deliveryStatusDetails = null, System.DateTimeOffset? deliveryAttemptTimestamp = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData AcsEmailDeliveryReportReceivedEventData(string sender = null, string recipient = null, string messageId = null, Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus? status = default(Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus?), System.DateTimeOffset? deliveryAttemptTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails AcsEmailDeliveryReportStatusDetails(string statusMessage = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData AcsEmailEngagementTrackingReportReceivedEventData(string sender, string messageId, System.DateTimeOffset? userActionTimestamp, string engagementContext, string userAgent, Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement? engagement) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData AcsEmailEngagementTrackingReportReceivedEventData(string sender = null, string recipient = null, string messageId = null, System.DateTimeOffset? userActionTimestamp = default(System.DateTimeOffset?), string engagementContext = null, string userAgent = null, Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement? engagement = default(Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext AcsIncomingCallCustomContext(System.Collections.Generic.IReadOnlyDictionary<string, string> sipHeaders = null, System.Collections.Generic.IReadOnlyDictionary<string, string> voipHeaders = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData AcsIncomingCallEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel toCommunicationIdentifier = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel fromCommunicationIdentifier = null, string serverCallId = null, string callerDisplayName = null, Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext customContext = null, string incomingCallContext = null, string correlationId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties AcsRecordingChunkInfoProperties(string documentId, long? index, string endReason, string metadataLocation, string contentLocation) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties AcsRecordingChunkInfoProperties(string documentId = null, long? index = default(long?), string endReason = null, string metadataLocation = null, string contentLocation = null, string deleteLocation = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties recordingStorageInfo = null, System.DateTimeOffset? recordingStartTime = default(System.DateTimeOffset?), long? recordingDurationMs = default(long?), Azure.Messaging.EventGrid.Models.RecordingContentType? recordingContentType = default(Azure.Messaging.EventGrid.Models.RecordingContentType?), Azure.Messaging.EventGrid.Models.RecordingChannelType? recordingChannelType = default(Azure.Messaging.EventGrid.Models.RecordingChannelType?), Azure.Messaging.EventGrid.Models.RecordingFormatType? recordingFormatType = default(Azure.Messaging.EventGrid.Models.RecordingFormatType?), string sessionEndReason = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties recordingStorageInfo = null, System.DateTimeOffset? recordingStartTime = default(System.DateTimeOffset?), long? recordingDurationMs = default(long?), Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType? contentType = default(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType?), Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType? channelType = default(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType?), Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType? formatType = default(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType?), string sessionEndReason = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData AcsRecordingFileStatusUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties recordingStorageInfo, System.DateTimeOffset? recordingStartTime, long? recordingDurationMs, string sessionEndReason) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties AcsRecordingStorageInfoProperties(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties> recordingChunks = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties AcsRecordingStorageInfoProperties(System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties> recordingChunks) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration AcsRouterChannelConfiguration(string channelId = null, int? capacityCostPerJob = default(int?), int? maxNumberOfJobs = default(int?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData AcsRouterEventData(string jobId = null, string channelReference = null, string channelId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData AcsRouterJobCancelledEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string note = null, string dispositionCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData AcsRouterJobClassifiedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails queueDetails = null, string classificationPolicyId = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> attachedWorkerSelectors = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData AcsRouterJobClosedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string assignmentId = null, string workerId = null, string dispositionCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData AcsRouterJobCompletedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string assignmentId = null, string workerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData AcsRouterJobDeletedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData AcsRouterJobEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData AcsRouterJobExceptionTriggeredEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string ruleKey = null, string exceptionRuleId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData AcsRouterJobQueuedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> attachedWorkerSelectors = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> requestedWorkerSelectors = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData AcsRouterJobReceivedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Messaging.EventGrid.Models.AcsRouterJobStatus? jobStatus = default(Azure.Messaging.EventGrid.Models.AcsRouterJobStatus?), string classificationPolicyId = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> requestedWorkerSelectors = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), bool unavailableForMatching = false) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData AcsRouterJobReceivedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus? status = default(Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus?), string classificationPolicyId = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> requestedWorkerSelectors = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), bool unavailableForMatching = false) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData AcsRouterJobSchedulingFailedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> expiredAttachedWorkerSelectors = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> expiredRequestedWorkerSelectors = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), string failureReason = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData AcsRouterJobUnassignedEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string assignmentId = null, string workerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData AcsRouterJobWaitingForActivationEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> expiredAttachedWorkerSelectors = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> expiredRequestedWorkerSelectors = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), bool unavailableForMatching = false) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData AcsRouterJobWorkerSelectorsExpiredEventData(string jobId = null, string channelReference = null, string channelId = null, string queueId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> expiredRequestedWorkerSelectors = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> expiredAttachedWorkerSelectors = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails AcsRouterQueueDetails(string id = null, string name = null, System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData AcsRouterWorkerDeletedEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData AcsRouterWorkerDeregisteredEventData(string workerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData AcsRouterWorkerEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData AcsRouterWorkerOfferAcceptedEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null, string queueId = null, string offerId = null, string assignmentId = null, int? jobPriority = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, string> workerLabels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> workerTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobLabels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobTags = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData AcsRouterWorkerOfferDeclinedEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null, string queueId = null, string offerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData AcsRouterWorkerOfferExpiredEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null, string queueId = null, string offerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData AcsRouterWorkerOfferIssuedEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null, string queueId = null, string offerId = null, int? jobPriority = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, string> workerLabels = null, System.DateTimeOffset? offeredOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> workerTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobLabels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobTags = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData AcsRouterWorkerOfferRevokedEventData(string jobId = null, string channelReference = null, string channelId = null, string workerId = null, string queueId = null, string offerId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData AcsRouterWorkerRegisteredEventData(string workerId = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails> queueAssignments = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration> channelConfigurations = null, int? totalCapacity = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, string> labels = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties AcsSmsDeliveryAttemptProperties(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), int? segmentsSucceeded = default(int?), int? segmentsFailed = default(int?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData AcsSmsDeliveryReportReceivedEventData(string messageId = null, string from = null, string to = null, string deliveryStatus = null, string deliveryStatusDetails = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties> deliveryAttempts = null, System.DateTimeOffset? receivedTimestamp = default(System.DateTimeOffset?), string tag = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData AcsSmsDeliveryReportReceivedEventData(string messageId, string from, string to, string deliveryStatus, string deliveryStatusDetails, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties> deliveryAttempts, System.DateTimeOffset? receivedTimestamp, string tag) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties AcsSmsEventBaseProperties(string messageId = null, string from = null, string to = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData AcsSmsReceivedEventData(string messageId = null, string from = null, string to = null, string message = null, System.DateTimeOffset? receivedTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData AcsUserDisconnectedEventData(Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel userCommunicationIdentifier = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData ApiManagementApiCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData ApiManagementApiDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData ApiManagementApiReleaseCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData ApiManagementApiReleaseDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData ApiManagementApiReleaseUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData ApiManagementApiUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData ApiManagementGatewayApiAddedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData ApiManagementGatewayApiRemovedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData ApiManagementGatewayCertificateAuthorityCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData ApiManagementGatewayCertificateAuthorityDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData ApiManagementGatewayCertificateAuthorityUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData ApiManagementGatewayCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData ApiManagementGatewayDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData ApiManagementGatewayHostnameConfigurationCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData ApiManagementGatewayHostnameConfigurationDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData ApiManagementGatewayHostnameConfigurationUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData ApiManagementGatewayUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData ApiManagementProductCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData ApiManagementProductDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData ApiManagementProductUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData ApiManagementSubscriptionCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData ApiManagementSubscriptionDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData ApiManagementSubscriptionUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData ApiManagementUserCreatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData ApiManagementUserDeletedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData ApiManagementUserUpdatedEventData(string resourceUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData AppConfigurationKeyValueDeletedEventData(string key = null, string label = null, string etag = null, string syncToken = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData AppConfigurationKeyValueModifiedEventData(string key = null, string label = null, string etag = null, string syncToken = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData AppConfigurationSnapshotCreatedEventData(string name = null, string eTag = null, string syncToken = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData AppConfigurationSnapshotEventData(string name = null, string eTag = null, string syncToken = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData AppConfigurationSnapshotModifiedEventData(string name = null, string eTag = null, string syncToken = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail(Azure.Messaging.EventGrid.SystemEvents.AppAction? action = default(Azure.Messaging.EventGrid.SystemEvents.AppAction?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail AppServicePlanEventTypeDetail(Azure.Messaging.EventGrid.SystemEvents.StampKind? stampKind = default(Azure.Messaging.EventGrid.SystemEvents.StampKind?), Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction? action = default(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction?), Azure.Messaging.EventGrid.SystemEvents.AsyncStatus? status = default(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel CommunicationIdentifierModel(string rawId = null, Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel communicationUser = null, Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel phoneNumber = null, Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel microsoftTeamsUser = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel CommunicationUserIdentifierModel(string id = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData ContainerRegistryArtifactEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget target = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData ContainerRegistryArtifactEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, string location = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget target = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry connectedRegistry = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget ContainerRegistryArtifactEventTarget(string mediaType = null, long? size = default(long?), string digest = null, string repository = null, string tag = null, string name = null, string version = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData ContainerRegistryChartDeletedEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, string location = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget target = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry connectedRegistry = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData ContainerRegistryChartPushedEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, string location = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget target = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry connectedRegistry = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor ContainerRegistryEventActor(string name = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry ContainerRegistryEventConnectedRegistry(string name = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData ContainerRegistryEventData(string id, System.DateTimeOffset? timestamp, string action, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget target, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest request, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor actor, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource source) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData ContainerRegistryEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, string location = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget target = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest request = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor actor = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource source = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry connectedRegistry = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest ContainerRegistryEventRequest(string id = null, string addr = null, string host = null, string method = null, string useragent = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource ContainerRegistryEventSource(string addr = null, string instanceID = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget ContainerRegistryEventTarget(string mediaType = null, long? size = default(long?), string digest = null, long? length = default(long?), string repository = null, string url = null, string tag = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData ContainerRegistryImageDeletedEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, string location = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget target = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest request = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor actor = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource source = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry connectedRegistry = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData ContainerRegistryImagePushedEventData(string id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, string location = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget target = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest request = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor actor = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource source = null, Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry connectedRegistry = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData ContainerServiceClusterSupportEndedEventData(string kubernetesVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData ContainerServiceClusterSupportEndingEventData(string kubernetesVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData ContainerServiceClusterSupportEventData(string kubernetesVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData ContainerServiceNewKubernetesVersionAvailableEventData(string latestSupportedKubernetesVersion = null, string latestStableKubernetesVersion = null, string lowestMinorKubernetesVersion = null, string latestPreviewKubernetesVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData ContainerServiceNodePoolRollingEventData(string nodePoolName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData ContainerServiceNodePoolRollingFailedEventData(string nodePoolName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData ContainerServiceNodePoolRollingStartedEventData(string nodePoolName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData ContainerServiceNodePoolRollingSucceededEventData(string nodePoolName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData DataBoxCopyCompletedEventData(string serialNumber = null, Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName? stageName = default(Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName?), System.DateTimeOffset? stageTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData DataBoxCopyStartedEventData(string serialNumber = null, Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName? stageName = default(Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName?), System.DateTimeOffset? stageTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData DataBoxOrderCompletedEventData(string serialNumber = null, Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName? stageName = default(Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName?), System.DateTimeOffset? stageTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo DeviceConnectionStateEventInfo(string sequenceNumber = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties DeviceConnectionStateEventProperties(string deviceId = null, string moduleId = null, string hubName = null, Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo deviceConnectionStateEventInfo = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties DeviceLifeCycleEventProperties(string deviceId = null, string hubName = null, Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo twin = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties DeviceTelemetryEventProperties(object body = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> systemProperties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo DeviceTwinInfo(string authenticationType = null, float? cloudToDeviceMessageCount = default(float?), string connectionState = null, string deviceId = null, string etag = null, string lastActivityTime = null, Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties properties = null, string status = null, string statusUpdateTime = null, float? version = default(float?), Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint x509Thumbprint = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties DeviceTwinInfoProperties(Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties desired = null, Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties reported = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint DeviceTwinInfoX509Thumbprint(string primaryThumbprint = null, string secondaryThumbprint = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata DeviceTwinMetadata(string lastUpdated = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties DeviceTwinProperties(Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata metadata = null, float? version = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData EventGridMqttClientCreatedOrUpdatedEventData(string clientAuthenticationName = null, string clientName = null, string namespaceName = null, Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState? state = default(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> attributes = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData EventGridMqttClientDeletedEventData(string clientAuthenticationName = null, string clientName = null, string namespaceName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData EventGridMqttClientEventData(string clientAuthenticationName = null, string clientName = null, string namespaceName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData EventGridMqttClientSessionConnectedEventData(string clientAuthenticationName = null, string clientName = null, string namespaceName = null, string clientSessionName = null, long? sequenceNumber = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData EventGridMqttClientSessionDisconnectedEventData(string clientAuthenticationName = null, string clientName = null, string namespaceName = null, string clientSessionName = null, long? sequenceNumber = default(long?), Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason? disconnectionReason = default(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData EventHubCaptureFileCreatedEventData(string fileurl = null, string fileType = null, string partitionId = null, int? sizeInBytes = default(int?), int? eventCount = default(int?), int? firstSequenceNumber = default(int?), int? lastSequenceNumber = default(int?), System.DateTimeOffset? firstEnqueueTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastEnqueueTime = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData HealthcareDicomImageCreatedEventData(string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData HealthcareDicomImageCreatedEventData(string partitionName = null, string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData HealthcareDicomImageDeletedEventData(string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData HealthcareDicomImageDeletedEventData(string partitionName = null, string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData HealthcareDicomImageUpdatedEventData(string partitionName = null, string imageStudyInstanceUid = null, string imageSeriesInstanceUid = null, string imageSopInstanceUid = null, string serviceHostName = null, long? sequenceNumber = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData HealthcareFhirResourceCreatedEventData(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType? fhirResourceType = default(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType?), string fhirServiceHostName = null, string fhirResourceId = null, long? fhirResourceVersionId = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData HealthcareFhirResourceDeletedEventData(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType? fhirResourceType = default(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType?), string fhirServiceHostName = null, string fhirResourceId = null, long? fhirResourceVersionId = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData HealthcareFhirResourceUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType? fhirResourceType = default(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType?), string fhirServiceHostName = null, string fhirResourceId = null, long? fhirResourceVersionId = default(long?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData IotHubDeviceConnectedEventData(string deviceId = null, string moduleId = null, string hubName = null, Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo deviceConnectionStateEventInfo = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData IotHubDeviceCreatedEventData(string deviceId = null, string hubName = null, Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo twin = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData IotHubDeviceDeletedEventData(string deviceId = null, string hubName = null, Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo twin = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData IotHubDeviceDisconnectedEventData(string deviceId = null, string moduleId = null, string hubName = null, Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo deviceConnectionStateEventInfo = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData IotHubDeviceTelemetryEventData(object body = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> systemProperties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData KeyVaultAccessPolicyChangedEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData KeyVaultCertificateExpiredEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData KeyVaultCertificateNearExpiryEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData KeyVaultCertificateNewVersionCreatedEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData KeyVaultKeyExpiredEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData KeyVaultKeyNearExpiryEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData KeyVaultKeyNewVersionCreatedEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData KeyVaultSecretExpiredEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData KeyVaultSecretNearExpiryEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData KeyVaultSecretNewVersionCreatedEventData(string id = null, string vaultName = null, string objectType = null, string objectName = null, string version = null, float? nbf = default(float?), float? exp = default(float?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData MachineLearningServicesDatasetDriftDetectedEventData(string dataDriftId = null, string dataDriftName = null, string runId = null, string baseDatasetId = null, string targetDatasetId = null, double? driftCoefficient = default(double?), System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData MachineLearningServicesModelDeployedEventData(string serviceName = null, string serviceComputeType = null, string modelIds = null, object serviceTags = null, object serviceProperties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData MachineLearningServicesModelRegisteredEventData(string modelName = null, string modelVersion = null, object modelTags = null, object modelProperties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData MachineLearningServicesRunCompletedEventData(string experimentId = null, string experimentName = null, string runId = null, string runType = null, object runTags = null, object runProperties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData MachineLearningServicesRunStatusChangedEventData(string experimentId = null, string experimentName = null, string runId = null, string runType = null, object runTags = null, object runProperties = null, string runStatus = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData MapsGeofenceEnteredEventData(System.Collections.Generic.IEnumerable<string> expiredGeofenceGeometryId = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> geometries = null, System.Collections.Generic.IEnumerable<string> invalidPeriodGeofenceGeometryId = null, bool? isEventPublished = default(bool?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties MapsGeofenceEventProperties(System.Collections.Generic.IEnumerable<string> expiredGeofenceGeometryId = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> geometries = null, System.Collections.Generic.IEnumerable<string> invalidPeriodGeofenceGeometryId = null, bool? isEventPublished = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties MapsGeofenceEventProperties(System.Collections.Generic.IReadOnlyList<string> expiredGeofenceGeometryId, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> geometries, System.Collections.Generic.IReadOnlyList<string> invalidPeriodGeofenceGeometryId, bool? isEventPublished) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData MapsGeofenceExitedEventData(System.Collections.Generic.IEnumerable<string> expiredGeofenceGeometryId = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> geometries = null, System.Collections.Generic.IEnumerable<string> invalidPeriodGeofenceGeometryId = null, bool? isEventPublished = default(bool?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry MapsGeofenceGeometry(string deviceId = null, float? distance = default(float?), string geometryId = null, float? nearestLat = default(float?), float? nearestLon = default(float?), string udId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData MapsGeofenceResultEventData(System.Collections.Generic.IEnumerable<string> expiredGeofenceGeometryId = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> geometries = null, System.Collections.Generic.IEnumerable<string> invalidPeriodGeofenceGeometryId = null, bool? isEventPublished = default(bool?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData MediaJobCanceledEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> outputs = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData MediaJobCanceledEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState, Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state, System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> outputs) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData MediaJobCancelingEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobError MediaJobError(Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCode? code = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCode?), string message = null, Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCategory? category = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCategory?), Azure.Messaging.EventGrid.SystemEvents.MediaJobRetry? retry = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobRetry?), System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail> details = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobError MediaJobError(Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCode? code, string message, Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCategory? category, Azure.Messaging.EventGrid.SystemEvents.MediaJobRetry? retry, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail> details) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail MediaJobErrorDetail(string code = null, string message = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData MediaJobErroredEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> outputs = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData MediaJobErroredEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState, Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state, System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> outputs) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData MediaJobFinishedEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null, System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> outputs = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData MediaJobFinishedEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState, Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state, System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData, System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> outputs) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput MediaJobOutput(string odataType = null, Azure.Messaging.EventGrid.SystemEvents.MediaJobError error = null, string label = null, long progress = (long)0, Azure.Messaging.EventGrid.SystemEvents.MediaJobState state = Azure.Messaging.EventGrid.SystemEvents.MediaJobState.Canceled) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset MediaJobOutputAsset(string odataType = null, Azure.Messaging.EventGrid.SystemEvents.MediaJobError error = null, string label = null, long progress = (long)0, Azure.Messaging.EventGrid.SystemEvents.MediaJobState state = Azure.Messaging.EventGrid.SystemEvents.MediaJobState.Canceled, string assetName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData MediaJobOutputCanceledEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData MediaJobOutputCancelingEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData MediaJobOutputErroredEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData MediaJobOutputFinishedEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData MediaJobOutputProcessingEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData MediaJobOutputProgressEventData(string label = null, long? progress = default(long?), System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData MediaJobOutputScheduledEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData MediaJobOutputStateChangeEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput output = null, System.Collections.Generic.IReadOnlyDictionary<string, string> jobCorrelationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData MediaJobProcessingEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData MediaJobScheduledEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData MediaJobStateChangeEventData(Azure.Messaging.EventGrid.SystemEvents.MediaJobState? previousState = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), Azure.Messaging.EventGrid.SystemEvents.MediaJobState? state = default(Azure.Messaging.EventGrid.SystemEvents.MediaJobState?), System.Collections.Generic.IReadOnlyDictionary<string, string> correlationData = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData MediaLiveEventChannelArchiveHeartbeatEventData(System.TimeSpan? channelLatency = default(System.TimeSpan?), string latencyResultCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData MediaLiveEventConnectionRejectedEventData(string ingestUrl = null, string streamId = null, string encoderIp = null, string encoderPort = null, string resultCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData MediaLiveEventEncoderConnectedEventData(string ingestUrl = null, string streamId = null, string encoderIp = null, string encoderPort = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData MediaLiveEventEncoderDisconnectedEventData(string ingestUrl = null, string streamId = null, string encoderIp = null, string encoderPort = null, string resultCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData MediaLiveEventIncomingDataChunkDroppedEventData(string timestamp = null, string trackType = null, long? bitrate = default(long?), string timescale = null, string resultCode = null, string trackName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData MediaLiveEventIncomingStreamReceivedEventData(string ingestUrl = null, string trackType = null, string trackName = null, long? bitrate = default(long?), string encoderIp = null, string encoderPort = null, string timestamp = null, string duration = null, string timescale = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData MediaLiveEventIncomingStreamsOutOfSyncEventData(string minLastTimestamp = null, string typeOfStreamWithMinLastTimestamp = null, string maxLastTimestamp = null, string typeOfStreamWithMaxLastTimestamp = null, string timescaleOfMinLastTimestamp = null, string timescaleOfMaxLastTimestamp = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData MediaLiveEventIncomingVideoStreamsOutOfSyncEventData(string firstTimestamp = null, string firstDuration = null, string secondTimestamp = null, string secondDuration = null, string timescale = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData MediaLiveEventIngestHeartbeatEventData(string trackType, string trackName, long? bitrate, long? incomingBitrate, string lastTimestamp, string timescale, long? overlapCount, long? discontinuityCount, long? nonincreasingCount, bool? unexpectedBitrate, string state, bool? healthy) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData MediaLiveEventIngestHeartbeatEventData(string trackType = null, string trackName = null, string transcriptionLanguage = null, string transcriptionState = null, long? bitrate = default(long?), long? incomingBitrate = default(long?), int? ingestDriftValue = default(int?), System.DateTimeOffset? lastFragmentArrivalTime = default(System.DateTimeOffset?), string lastTimestamp = null, string timescale = null, long? overlapCount = default(long?), long? discontinuityCount = default(long?), long? nonincreasingCount = default(long?), bool? unexpectedBitrate = default(bool?), string state = null, bool? healthy = default(bool?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData MediaLiveEventTrackDiscontinuityDetectedEventData(string trackType = null, string trackName = null, long? bitrate = default(long?), string previousTimestamp = null, string newTimestamp = null, string timescale = null, string discontinuityGap = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel MicrosoftTeamsUserIdentifierModel(string userId = null, bool? isAnonymous = default(bool?), Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel? cloud = default(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel PhoneNumberIdentifierModel(string value = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData PolicyInsightsPolicyStateChangedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string policyAssignmentId = null, string policyDefinitionId = null, string policyDefinitionReferenceId = null, string complianceState = null, string subscriptionId = null, string complianceReasonCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData PolicyInsightsPolicyStateCreatedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string policyAssignmentId = null, string policyDefinitionId = null, string policyDefinitionReferenceId = null, string complianceState = null, string subscriptionId = null, string complianceReasonCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData PolicyInsightsPolicyStateDeletedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string policyAssignmentId = null, string policyDefinitionId = null, string policyDefinitionReferenceId = null, string complianceState = null, string subscriptionId = null, string complianceReasonCode = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData RedisExportRdbCompletedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string name = null, string status = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData RedisImportRdbCompletedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string name = null, string status = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData RedisPatchingCompletedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string name = null, string status = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData RedisScalingCompletedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string name = null, string status = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData ResourceActionCancelEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData ResourceActionFailureEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData ResourceActionSuccessEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization ResourceAuthorization(string scope = null, string action = null, System.Collections.Generic.IReadOnlyDictionary<string, string> evidence = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData ResourceDeleteCancelEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData ResourceDeleteFailureEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData ResourceDeleteSuccessEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest ResourceHttpRequest(string clientRequestId = null, string clientIpAddress = null, Azure.Core.RequestMethod? method = default(Azure.Core.RequestMethod?), string url = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData ResourceNotificationsHealthResourcesAnnotatedEventData(Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails resourceDetails = null, Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails operationalDetails = null, string apiVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData(Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails resourceDetails = null, Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails operationalDetails = null, string apiVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails ResourceNotificationsOperationalDetails(System.DateTimeOffset? resourceEventTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData ResourceNotificationsResourceDeletedEventData(Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails resourceDetails = null, Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails operationalDetails = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData ResourceNotificationsResourceManagementCreatedOrUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails resourceDetails = null, Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails operationalDetails = null, string apiVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData ResourceNotificationsResourceManagementDeletedEventData(Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails resourceDetails = null, Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails operationalDetails = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails ResourceNotificationsResourceUpdatedDetails(string id = null, string name = null, string resourceType = null, string location = null, System.Collections.Generic.IReadOnlyDictionary<string, string> resourceTags = null, System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete. Use the other overload ResourceNotificationsResourceUpdatedDetails.")]
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails ResourceNotificationsResourceUpdatedDetails(string id = null, string name = null, string resourceType = null, string location = null, string tags = null, System.Collections.Generic.IReadOnlyDictionary<string, object> properties = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData ResourceNotificationsResourceUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails resourceDetails = null, Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails operationalDetails = null, string apiVersion = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData ResourceWriteCancelEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData ResourceWriteFailureEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData ResourceWriteSuccessEventData(string tenantId = null, string subscriptionId = null, string resourceGroup = null, string resourceProvider = null, string resourceUri = null, string operationName = null, string status = null, string authorization = null, string claims = null, string correlationId = null, string httpRequest = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData(string namespaceName = null, string requestUri = null, string entityType = null, string queueName = null, string topicName = null, string subscriptionName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData ServiceBusActiveMessagesAvailableWithNoListenersEventData(string namespaceName = null, string requestUri = null, string entityType = null, string queueName = null, string topicName = null, string subscriptionName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData(string namespaceName = null, string requestUri = null, string entityType = null, string queueName = null, string topicName = null, string subscriptionName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData ServiceBusDeadletterMessagesAvailableWithNoListenersEventData(string namespaceName = null, string requestUri = null, string entityType = null, string queueName = null, string topicName = null, string subscriptionName = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData SignalRServiceClientConnectionConnectedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string hubName = null, string connectionId = null, string userId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData SignalRServiceClientConnectionDisconnectedEventData(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string hubName = null, string connectionId = null, string userId = null, string errorMessage = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData StorageAsyncOperationInitiatedEventData(string api = null, string clientRequestId = null, string requestId = null, string contentType = null, long? contentLength = default(long?), string blobType = null, string url = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData StorageBlobCreatedEventData(string api = null, string clientRequestId = null, string requestId = null, string eTag = null, string contentType = null, long? contentLength = default(long?), long? contentOffset = default(long?), string blobType = null, string url = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData StorageBlobDeletedEventData(string api = null, string clientRequestId = null, string requestId = null, string contentType = null, string blobType = null, string url = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData StorageBlobInventoryPolicyCompletedEventData(System.DateTimeOffset? scheduleDateTime = default(System.DateTimeOffset?), string accountName = null, string ruleName = null, string policyRunStatus = null, string policyRunStatusMessage = null, string policyRunId = null, string manifestBlobUrl = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData StorageBlobRenamedEventData(string api = null, string clientRequestId = null, string requestId = null, string sourceUrl = null, string destinationUrl = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData StorageBlobTierChangedEventData(string api = null, string clientRequestId = null, string requestId = null, string contentType = null, long? contentLength = default(long?), string blobType = null, string url = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData StorageDirectoryCreatedEventData(string api = null, string clientRequestId = null, string requestId = null, string eTag = null, string url = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData StorageDirectoryDeletedEventData(string api = null, string clientRequestId = null, string requestId = null, string url = null, bool? recursive = default(bool?), string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData StorageDirectoryRenamedEventData(string api = null, string clientRequestId = null, string requestId = null, string sourceUrl = null, string destinationUrl = null, string sequencer = null, string identity = null, object storageDiagnostics = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail StorageLifecyclePolicyActionSummaryDetail(long? totalObjectsCount = default(long?), long? successCount = default(long?), string errorList = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData StorageLifecyclePolicyCompletedEventData(string scheduleTime = null, Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail deleteSummary = null, Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail tierToCoolSummary = null, Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail tierToArchiveSummary = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData StorageTaskCompletedEventData(Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus? status = default(Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus?), System.DateTimeOffset? completedDateTime = default(System.DateTimeOffset?), string taskExecutionId = null, string taskName = null, System.Uri summaryReportBlobUri = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData StorageTaskQueuedEventData(System.DateTimeOffset? queuedDateTime = default(System.DateTimeOffset?), string taskExecutionId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData SubscriptionDeletedEventData(string eventSubscriptionId = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData SubscriptionValidationEventData(string validationCode = null, string validationUrl = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse SubscriptionValidationResponse(string validationResponse = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData WebAppServicePlanUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail appServicePlanEventTypeDetail = null, Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku sku = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku WebAppServicePlanUpdatedEventDataSku(string name = null, string tier = null, string size = null, string family = null, string capacity = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData WebAppUpdatedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData WebBackupOperationCompletedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData WebBackupOperationFailedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData WebBackupOperationStartedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData WebRestoreOperationCompletedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData WebRestoreOperationFailedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData WebRestoreOperationStartedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData WebSlotSwapCompletedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData WebSlotSwapFailedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData WebSlotSwapStartedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData WebSlotSwapWithPreviewCancelledEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData WebSlotSwapWithPreviewStartedEventData(Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail appEventTypeDetail = null, string name = null, string clientRequestId = null, string correlationRequestId = null, string requestId = null, string address = null, string verb = null) { throw null; }
    }
    public partial class EventGridPublisherClient
    {
        protected EventGridPublisherClient() { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureSasCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options = null) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response SendEncodedCloudEvents(System.ReadOnlyMemory<byte> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEncodedCloudEventsAsync(System.ReadOnlyMemory<byte> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(Azure.Messaging.CloudEvent cloudEvent, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(Azure.Messaging.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(Azure.Messaging.EventGrid.EventGridEvent eventGridEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvent(System.BinaryData customEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Messaging.CloudEvent cloudEvent, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Messaging.CloudEvent cloudEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(Azure.Messaging.EventGrid.EventGridEvent eventGridEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventAsync(System.BinaryData customEvent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.EventGridEvent> eventGridEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<System.BinaryData> customEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.EventGridEvent> eventGridEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<System.BinaryData> customEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPublisherClientOptions : Azure.Core.ClientOptions
    {
        public EventGridPublisherClientOptions(Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion.V2018_01_01) { }
        public enum ServiceVersion
        {
            V2018_01_01 = 1,
        }
    }
    public partial class EventGridSasBuilder
    {
        public EventGridSasBuilder(System.Uri endpoint, System.DateTimeOffset expiresOn) { }
        public Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion ApiVersion { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string GenerateSas(Azure.AzureKeyCredential key) { throw null; }
    }
    public static partial class SystemEventNames
    {
        public const string AcsChatMessageDeleted = "Microsoft.Communication.ChatMessageDeleted";
        public const string AcsChatMessageDeletedInThread = "Microsoft.Communication.ChatMessageDeletedInThread";
        public const string AcsChatMessageEdited = "Microsoft.Communication.ChatMessageEdited";
        public const string AcsChatMessageEditedInThread = "Microsoft.Communication.ChatMessageEditedInThread";
        public const string AcsChatMessageReceived = "Microsoft.Communication.ChatMessageReceived";
        public const string AcsChatMessageReceivedInThread = "Microsoft.Communication.ChatMessageReceivedInThread";
        public const string AcsChatParticipantAddedToThread = "Microsoft.Communication.ChatThreadParticipantAdded";
        public const string AcsChatParticipantAddedToThreadWithUser = "Microsoft.Communication.ChatParticipantAddedToThreadWithUser";
        public const string AcsChatParticipantRemovedFromThread = "Microsoft.Communication.ChatThreadParticipantRemoved";
        public const string AcsChatParticipantRemovedFromThreadWithUser = "Microsoft.Communication.ChatParticipantRemovedFromThreadWithUser";
        public const string AcsChatThreadCreated = "Microsoft.Communication.ChatThreadCreated";
        public const string AcsChatThreadCreatedWithUser = "Microsoft.Communication.ChatThreadCreatedWithUser";
        public const string AcsChatThreadDeleted = "Microsoft.Communication.ChatThreadDeleted";
        public const string AcsChatThreadPropertiesUpdated = "Microsoft.Communication.ChatThreadPropertiesUpdated";
        public const string AcsChatThreadPropertiesUpdatedPerUser = "Microsoft.Communication.ChatThreadPropertiesUpdatedPerUser";
        public const string AcsChatThreadWithUserDeleted = "Microsoft.Communication.ChatThreadWithUserDeleted";
        public const string AcsEmailDeliveryReportReceived = "Microsoft.Communication.EmailDeliveryReportReceived";
        public const string AcsEmailEngagementTrackingReportReceived = "Microsoft.Communication.EmailEngagementTrackingReportReceived";
        public const string AcsIncomingCall = "Microsoft.Communication.IncomingCall";
        public const string AcsRecordingFileStatusUpdated = "Microsoft.Communication.RecordingFileStatusUpdated";
        public const string AcsRouterJobCancelled = "Microsoft.Communication.RouterJobCancelled";
        public const string AcsRouterJobClassificationFailed = "Microsoft.Communication.RouterJobClassificationFailed";
        public const string AcsRouterJobClassified = "Microsoft.Communication.RouterJobClassified";
        public const string AcsRouterJobClosed = "Microsoft.Communication.RouterJobClosed";
        public const string AcsRouterJobCompleted = "Microsoft.Communication.RouterJobCompleted";
        public const string AcsRouterJobDeleted = "Microsoft.Communication.RouterJobDeleted";
        public const string AcsRouterJobExceptionTriggered = "Microsoft.Communication.RouterJobExceptionTriggered";
        public const string AcsRouterJobQueued = "Microsoft.Communication.RouterJobQueued";
        public const string AcsRouterJobReceived = "Microsoft.Communication.RouterJobReceived";
        public const string AcsRouterJobSchedulingFailed = "Microsoft.Communication.RouterJobSchedulingFailed";
        public const string AcsRouterJobUnassigned = "Microsoft.Communication.RouterJobUnassigned";
        public const string AcsRouterJobWaitingForActivation = "Microsoft.Communication.RouterJobWaitingForActivation";
        public const string AcsRouterJobWorkerSelectorsExpired = "Microsoft.Communication.RouterJobWorkerSelectorsExpired";
        public const string AcsRouterWorkerDeleted = "Microsoft.Communication.RouterWorkerDeleted";
        public const string AcsRouterWorkerDeregistered = "Microsoft.Communication.RouterWorkerDeregistered";
        public const string AcsRouterWorkerOfferAccepted = "Microsoft.Communication.RouterWorkerOfferAccepted";
        public const string AcsRouterWorkerOfferDeclined = "Microsoft.Communication.RouterWorkerOfferDeclined";
        public const string AcsRouterWorkerOfferExpired = "Microsoft.Communication.RouterWorkerOfferExpired";
        public const string AcsRouterWorkerOfferIssued = "Microsoft.Communication.RouterWorkerOfferIssued";
        public const string AcsRouterWorkerOfferRevoked = "Microsoft.Communication.RouterWorkerOfferRevoked";
        public const string AcsRouterWorkerRegistered = "Microsoft.Communication.RouterWorkerRegistered";
        public const string AcsSmsDeliveryReportReceived = "Microsoft.Communication.SMSDeliveryReportReceived";
        public const string AcsSmsReceived = "Microsoft.Communication.SMSReceived";
        public const string AcsUserDisconnected = "Microsoft.Communication.UserDisconnected";
        public const string ApiManagementApiCreated = "Microsoft.ApiManagement.APICreated";
        public const string ApiManagementApiDeleted = "Microsoft.ApiManagement.APIDeleted";
        public const string ApiManagementApiReleaseCreated = "Microsoft.ApiManagement.APIReleaseCreated";
        public const string ApiManagementApiReleaseDeleted = "Microsoft.ApiManagement.APIReleaseDeleted";
        public const string ApiManagementApiReleaseUpdated = "Microsoft.ApiManagement.APIReleaseUpdated";
        public const string ApiManagementApiUpdated = "Microsoft.ApiManagement.APIUpdated";
        public const string ApiManagementGatewayApiAdded = "Microsoft.ApiManagement.GatewayAPIAdded";
        public const string ApiManagementGatewayApiRemoved = "Microsoft.ApiManagement.GatewayAPIRemoved";
        public const string ApiManagementGatewayCertificateAuthorityCreated = "Microsoft.ApiManagement.GatewayCertificateAuthorityCreated";
        public const string ApiManagementGatewayCertificateAuthorityDeleted = "Microsoft.ApiManagement.GatewayCertificateAuthorityDeleted";
        public const string ApiManagementGatewayCertificateAuthorityUpdated = "Microsoft.ApiManagement.GatewayCertificateAuthorityUpdated";
        public const string ApiManagementGatewayCreated = "Microsoft.ApiManagement.GatewayCreated";
        public const string ApiManagementGatewayDeleted = "Microsoft.ApiManagement.GatewayDeleted";
        public const string ApiManagementGatewayHostnameConfigurationCreated = "Microsoft.ApiManagement.GatewayHostnameConfigurationCreated";
        public const string ApiManagementGatewayHostnameConfigurationDeleted = "Microsoft.ApiManagement.GatewayHostnameConfigurationDeleted";
        public const string ApiManagementGatewayHostnameConfigurationUpdated = "Microsoft.ApiManagement.GatewayHostnameConfigurationUpdated";
        public const string ApiManagementGatewayUpdated = "Microsoft.ApiManagement.GatewayUpdated";
        public const string ApiManagementProductCreated = "Microsoft.ApiManagement.ProductCreated";
        public const string ApiManagementProductDeleted = "Microsoft.ApiManagement.ProductDeleted";
        public const string ApiManagementProductUpdated = "Microsoft.ApiManagement.ProductUpdated";
        public const string ApiManagementSubscriptionCreated = "Microsoft.ApiManagement.SubscriptionCreated";
        public const string ApiManagementSubscriptionDeleted = "Microsoft.ApiManagement.SubscriptionDeleted";
        public const string ApiManagementSubscriptionUpdated = "Microsoft.ApiManagement.SubscriptionUpdated";
        public const string ApiManagementUserCreated = "Microsoft.ApiManagement.UserCreated";
        public const string ApiManagementUserDeleted = "Microsoft.ApiManagement.UserDeleted";
        public const string ApiManagementUserUpdated = "Microsoft.ApiManagement.UserUpdated";
        public const string AppConfigurationKeyValueDeleted = "Microsoft.AppConfiguration.KeyValueDeleted";
        public const string AppConfigurationKeyValueModified = "Microsoft.AppConfiguration.KeyValueModified";
        public const string AppConfigurationSnapshotCreated = "Microsoft.AppConfiguration.SnapshotCreated";
        public const string AppConfigurationSnapshotModified = "Microsoft.AppConfiguration.SnapshotModified";
        public const string ContainerRegistryChartDeleted = "Microsoft.ContainerRegistry.ChartDeleted";
        public const string ContainerRegistryChartPushed = "Microsoft.ContainerRegistry.ChartPushed";
        public const string ContainerRegistryImageDeleted = "Microsoft.ContainerRegistry.ImageDeleted";
        public const string ContainerRegistryImagePushed = "Microsoft.ContainerRegistry.ImagePushed";
        public const string ContainerServiceClusterSupportEnded = "Microsoft.ContainerService.ClusterSupportEnded";
        public const string ContainerServiceClusterSupportEnding = "Microsoft.ContainerService.ClusterSupportEnding";
        public const string ContainerServiceNewKubernetesVersionAvailable = "Microsoft.ContainerService.NewKubernetesVersionAvailable";
        public const string ContainerServiceNodePoolRollingFailed = "Microsoft.ContainerService.NodePoolRollingFailed";
        public const string ContainerServiceNodePoolRollingStarted = "Microsoft.ContainerService.NodePoolRollingStarted";
        public const string ContainerServiceNodePoolRollingSucceeded = "Microsoft.ContainerService.NodePoolRollingSucceeded";
        public const string DataBoxCopyCompleted = "Microsoft.DataBox.CopyCompleted";
        public const string DataBoxCopyStarted = "Microsoft.DataBox.CopyStarted";
        public const string DataBoxOrderCompleted = "Microsoft.DataBox.OrderCompleted";
        public const string EventGridMqttClientCreatedOrUpdated = "Microsoft.EventGrid.MQTTClientCreatedOrUpdated";
        public const string EventGridMqttClientDeleted = "Microsoft.EventGrid.MQTTClientDeleted";
        public const string EventGridMqttClientSessionConnected = "Microsoft.EventGrid.MQTTClientSessionConnected";
        public const string EventGridMqttClientSessionDisconnected = "Microsoft.EventGrid.MQTTClientSessionDisconnected";
        public const string EventGridSubscriptionDeleted = "Microsoft.EventGrid.SubscriptionDeletedEvent";
        public const string EventGridSubscriptionValidation = "Microsoft.EventGrid.SubscriptionValidationEvent";
        public const string EventHubCaptureFileCreated = "Microsoft.EventHub.CaptureFileCreated";
        public const string HealthcareDicomImageCreated = "Microsoft.HealthcareApis.DicomImageCreated";
        public const string HealthcareDicomImageDeleted = "Microsoft.HealthcareApis.DicomImageDeleted";
        public const string HealthcareDicomImageUpdated = "Microsoft.HealthcareApis.DicomImageUpdated";
        public const string HealthcareFhirResourceCreated = "Microsoft.HealthcareApis.FhirResourceCreated";
        public const string HealthcareFhirResourceDeleted = "Microsoft.HealthcareApis.FhirResourceDeleted";
        public const string HealthcareFhirResourceUpdated = "Microsoft.HealthcareApis.FhirResourceUpdated";
        public const string IotHubDeviceConnected = "Microsoft.Devices.DeviceConnected";
        public const string IotHubDeviceCreated = "Microsoft.Devices.DeviceCreated";
        public const string IotHubDeviceDeleted = "Microsoft.Devices.DeviceDeleted";
        public const string IotHubDeviceDisconnected = "Microsoft.Devices.DeviceDisconnected";
        public const string IotHubDeviceTelemetry = "Microsoft.Devices.DeviceTelemetry";
        public const string KeyVaultAccessPolicyChanged = "Microsoft.KeyVault.VaultAccessPolicyChanged";
        public const string KeyVaultCertificateExpired = "Microsoft.KeyVault.CertificateExpired";
        public const string KeyVaultCertificateNearExpiry = "Microsoft.KeyVault.CertificateNearExpiry";
        public const string KeyVaultCertificateNewVersionCreated = "Microsoft.KeyVault.CertificateNewVersionCreated";
        public const string KeyVaultKeyExpired = "Microsoft.KeyVault.KeyExpired";
        public const string KeyVaultKeyNearExpiry = "Microsoft.KeyVault.KeyNearExpiry";
        public const string KeyVaultKeyNewVersionCreated = "Microsoft.KeyVault.KeyNewVersionCreated";
        public const string KeyVaultSecretExpired = "Microsoft.KeyVault.SecretExpired";
        public const string KeyVaultSecretNearExpiry = "Microsoft.KeyVault.SecretNearExpiry";
        public const string KeyVaultSecretNewVersionCreated = "Microsoft.KeyVault.SecretNewVersionCreated";
        public const string MachineLearningServicesDatasetDriftDetected = "Microsoft.MachineLearningServices.DatasetDriftDetected";
        public const string MachineLearningServicesModelDeployed = "Microsoft.MachineLearningServices.ModelDeployed";
        public const string MachineLearningServicesModelRegistered = "Microsoft.MachineLearningServices.ModelRegistered";
        public const string MachineLearningServicesRunCompleted = "Microsoft.MachineLearningServices.RunCompleted";
        public const string MachineLearningServicesRunStatusChanged = "Microsoft.MachineLearningServices.RunStatusChanged";
        public const string MapsGeofenceEntered = "Microsoft.Maps.GeofenceEntered";
        public const string MapsGeofenceExited = "Microsoft.Maps.GeofenceExited";
        public const string MapsGeofenceResult = "Microsoft.Maps.GeofenceResult";
        public const string MediaJobCanceled = "Microsoft.Media.JobCanceled";
        public const string MediaJobCanceling = "Microsoft.Media.JobCanceling";
        public const string MediaJobErrored = "Microsoft.Media.JobErrored";
        public const string MediaJobFinished = "Microsoft.Media.JobFinished";
        public const string MediaJobOutputCanceled = "Microsoft.Media.JobOutputCanceled";
        public const string MediaJobOutputCanceling = "Microsoft.Media.JobOutputCanceling";
        public const string MediaJobOutputErrored = "Microsoft.Media.JobOutputErrored";
        public const string MediaJobOutputFinished = "Microsoft.Media.JobOutputFinished";
        public const string MediaJobOutputProcessing = "Microsoft.Media.JobOutputProcessing";
        public const string MediaJobOutputProgress = "Microsoft.Media.JobOutputProgress";
        public const string MediaJobOutputScheduled = "Microsoft.Media.JobOutputScheduled";
        public const string MediaJobOutputStateChange = "Microsoft.Media.JobOutputStateChange";
        public const string MediaJobProcessing = "Microsoft.Media.JobProcessing";
        public const string MediaJobScheduled = "Microsoft.Media.JobScheduled";
        public const string MediaJobStateChange = "Microsoft.Media.JobStateChange";
        public const string MediaLiveEventChannelArchiveHeartbeat = "Microsoft.Media.LiveEventChannelArchiveHeartbeat";
        public const string MediaLiveEventConnectionRejected = "Microsoft.Media.LiveEventConnectionRejected";
        public const string MediaLiveEventEncoderConnected = "Microsoft.Media.LiveEventEncoderConnected";
        public const string MediaLiveEventEncoderDisconnected = "Microsoft.Media.LiveEventEncoderDisconnected";
        public const string MediaLiveEventIncomingDataChunkDropped = "Microsoft.Media.LiveEventIncomingDataChunkDropped";
        public const string MediaLiveEventIncomingStreamReceived = "Microsoft.Media.LiveEventIncomingStreamReceived";
        public const string MediaLiveEventIncomingStreamsOutOfSync = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";
        public const string MediaLiveEventIncomingVideoStreamsOutOfSync = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";
        public const string MediaLiveEventIngestHeartbeat = "Microsoft.Media.LiveEventIngestHeartbeat";
        public const string MediaLiveEventTrackDiscontinuityDetected = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";
        public const string PolicyInsightsPolicyStateChanged = "Microsoft.PolicyInsights.PolicyStateChanged";
        public const string PolicyInsightsPolicyStateCreated = "Microsoft.PolicyInsights.PolicyStateCreated";
        public const string PolicyInsightsPolicyStateDeleted = "Microsoft.PolicyInsights.PolicyStateDeleted";
        public const string RedisExportRdbCompleted = "Microsoft.Cache.ExportRDBCompleted";
        public const string RedisImportRdbCompleted = "Microsoft.Cache.ImportRDBCompleted";
        public const string RedisPatchingCompleted = "Microsoft.Cache.PatchingCompleted";
        public const string RedisScalingCompleted = "Microsoft.Cache.ScalingCompleted";
        public const string ResourceActionCancel = "Microsoft.Resources.ResourceActionCancel";
        public const string ResourceActionFailure = "Microsoft.Resources.ResourceActionFailure";
        public const string ResourceActionSuccess = "Microsoft.Resources.ResourceActionSuccess";
        public const string ResourceDeleteCancel = "Microsoft.Resources.ResourceDeleteCancel";
        public const string ResourceDeleteFailure = "Microsoft.Resources.ResourceDeleteFailure";
        public const string ResourceDeleteSuccess = "Microsoft.Resources.ResourceDeleteSuccess";
        public const string ResourceNotificationsHealthResourcesAnnotated = "Microsoft.ResourceNotifications.HealthResources.ResourceAnnotated";
        public const string ResourceNotificationsHealthResourcesAvailabilityStatusChanged = "Microsoft.ResourceNotifications.HealthResources.AvailabilityStatusChanged";
        public const string ResourceNotificationsResourceManagementCreatedOrUpdated = "Microsoft.ResourceNotifications.Resources.CreatedOrUpdated";
        public const string ResourceNotificationsResourceManagementDeleted = "Microsoft.ResourceNotifications.Resources.Deleted";
        public const string ResourceWriteCancel = "Microsoft.Resources.ResourceWriteCancel";
        public const string ResourceWriteFailure = "Microsoft.Resources.ResourceWriteFailure";
        public const string ResourceWriteSuccess = "Microsoft.Resources.ResourceWriteSuccess";
        public const string ServiceBusActiveMessagesAvailablePeriodicNotifications = "Microsoft.ServiceBus.ActiveMessagesAvailablePeriodicNotifications";
        public const string ServiceBusActiveMessagesAvailableWithNoListeners = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";
        public const string ServiceBusDeadletterMessagesAvailablePeriodicNotifications = "Microsoft.ServiceBus.DeadletterMessagesAvailablePeriodicNotifications";
        public const string ServiceBusDeadletterMessagesAvailableWithNoListener = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListeners";
        public const string SignalRServiceClientConnectionConnected = "Microsoft.SignalRService.ClientConnectionConnected";
        public const string SignalRServiceClientConnectionDisconnected = "Microsoft.SignalRService.ClientConnectionDisconnected";
        public const string StorageAsyncOperationInitiated = "Microsoft.Storage.AsyncOperationInitiated";
        public const string StorageBlobCreated = "Microsoft.Storage.BlobCreated";
        public const string StorageBlobDeleted = "Microsoft.Storage.BlobDeleted";
        public const string StorageBlobInventoryPolicyCompleted = "Microsoft.Storage.BlobInventoryPolicyCompleted";
        public const string StorageBlobRenamed = "Microsoft.Storage.BlobRenamed";
        public const string StorageBlobTierChanged = "Microsoft.Storage.BlobTierChanged";
        public const string StorageDirectoryCreated = "Microsoft.Storage.DirectoryCreated";
        public const string StorageDirectoryDeleted = "Microsoft.Storage.DirectoryDeleted";
        public const string StorageDirectoryRenamed = "Microsoft.Storage.DirectoryRenamed";
        public const string StorageLifecyclePolicyCompleted = "Microsoft.Storage.LifecyclePolicyCompleted";
        public const string StorageTaskCompleted = "Microsoft.Storage.StorageTaskCompleted";
        public const string StorageTaskQueued = "Microsoft.Storage.StorageTaskQueued";
        public const string WebAppServicePlanUpdated = "Microsoft.Web.AppServicePlanUpdated";
        public const string WebAppUpdated = "Microsoft.Web.AppUpdated";
        public const string WebBackupOperationCompleted = "Microsoft.Web.BackupOperationCompleted";
        public const string WebBackupOperationFailed = "Microsoft.Web.BackupOperationFailed";
        public const string WebBackupOperationStarted = "Microsoft.Web.BackupOperationStarted";
        public const string WebRestoreOperationCompleted = "Microsoft.Web.RestoreOperationCompleted";
        public const string WebRestoreOperationFailed = "Microsoft.Web.RestoreOperationFailed";
        public const string WebRestoreOperationStarted = "Microsoft.Web.RestoreOperationStarted";
        public const string WebSlotSwapCompleted = "Microsoft.Web.SlotSwapCompleted";
        public const string WebSlotSwapFailed = "Microsoft.Web.SlotSwapFailed";
        public const string WebSlotSwapStarted = "Microsoft.Web.SlotSwapStarted";
        public const string WebSlotSwapWithPreviewCancelled = "Microsoft.Web.SlotSwapWithPreviewCancelled";
        public const string WebSlotSwapWithPreviewStarted = "Microsoft.Web.SlotSwapWithPreviewStarted";
    }
}
namespace Azure.Messaging.EventGrid.Models
{
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRouterJobStatus : System.IEquatable<Azure.Messaging.EventGrid.Models.AcsRouterJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRouterJobStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Assigned { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Cancelled { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus ClassificationFailed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Closed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Created { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus PendingClassification { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus PendingSchedule { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Queued { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus Scheduled { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus ScheduleFailed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterJobStatus WaitingForActivation { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.AcsRouterJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.AcsRouterJobStatus left, Azure.Messaging.EventGrid.Models.AcsRouterJobStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.AcsRouterJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.AcsRouterJobStatus left, Azure.Messaging.EventGrid.Models.AcsRouterJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRouterLabelOperator : System.IEquatable<Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRouterLabelOperator(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator Equal { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator Greater { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator Less { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator LessThanOrEqual { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator NotEqual { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator left, Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator left, Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRouterWorkerSelectorState : System.IEquatable<Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRouterWorkerSelectorState(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState Active { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState Expired { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState left, Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState left, Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingChannelType : System.IEquatable<Azure.Messaging.EventGrid.Models.RecordingChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingChannelType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.RecordingChannelType Mixed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.RecordingChannelType Unmixed { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.RecordingChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.RecordingChannelType left, Azure.Messaging.EventGrid.Models.RecordingChannelType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.RecordingChannelType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.RecordingChannelType left, Azure.Messaging.EventGrid.Models.RecordingChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingContentType : System.IEquatable<Azure.Messaging.EventGrid.Models.RecordingContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingContentType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.RecordingContentType Audio { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.RecordingContentType AudioVideo { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.RecordingContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.RecordingContentType left, Azure.Messaging.EventGrid.Models.RecordingContentType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.RecordingContentType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.RecordingContentType left, Azure.Messaging.EventGrid.Models.RecordingContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordingFormatType : System.IEquatable<Azure.Messaging.EventGrid.Models.RecordingFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordingFormatType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.RecordingFormatType Mp3 { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.RecordingFormatType Mp4 { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.RecordingFormatType Wav { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.RecordingFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.RecordingFormatType left, Azure.Messaging.EventGrid.Models.RecordingFormatType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.RecordingFormatType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.RecordingFormatType left, Azure.Messaging.EventGrid.Models.RecordingFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsChatEventBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>
    {
        internal AcsChatEventBaseProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel RecipientCommunicationIdentifier { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public string TransactionId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatEventInThreadBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>
    {
        internal AcsChatEventInThreadBaseProperties() { }
        public string ThreadId { get { throw null; } }
        public string TransactionId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>
    {
        internal AcsChatMessageDeletedEventData() { }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageDeletedInThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>
    {
        internal AcsChatMessageDeletedInThreadEventData() { }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageDeletedInThreadEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageEditedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>
    {
        internal AcsChatMessageEditedEventData() { }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public string MessageBody { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageEditedInThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>
    {
        internal AcsChatMessageEditedInThreadEventData() { }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public string MessageBody { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEditedInThreadEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageEventBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>
    {
        internal AcsChatMessageEventBaseProperties() { }
        public System.DateTimeOffset? ComposeTime { get { throw null; } }
        public string MessageId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel SenderCommunicationIdentifier { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string Type { get { throw null; } }
        public long? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageEventInThreadBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>
    {
        internal AcsChatMessageEventInThreadBaseProperties() { }
        public System.DateTimeOffset? ComposeTime { get { throw null; } }
        public string MessageId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel SenderCommunicationIdentifier { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string Type { get { throw null; } }
        public long? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>
    {
        internal AcsChatMessageReceivedEventData() { }
        public string MessageBody { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatMessageReceivedInThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>
    {
        internal AcsChatMessageReceivedInThreadEventData() { }
        public string MessageBody { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageReceivedInThreadEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatParticipantAddedToThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>
    {
        internal AcsChatParticipantAddedToThreadEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel AddedByCommunicationIdentifier { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantAdded { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public long? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatParticipantAddedToThreadWithUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>
    {
        internal AcsChatParticipantAddedToThreadWithUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel AddedByCommunicationIdentifier { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantAdded { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantAddedToThreadWithUserEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatParticipantRemovedFromThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>
    {
        internal AcsChatParticipantRemovedFromThreadEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantRemoved { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel RemovedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public long? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatParticipantRemovedFromThreadWithUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>
    {
        internal AcsChatParticipantRemovedFromThreadWithUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantRemoved { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel RemovedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatParticipantRemovedFromThreadWithUserEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadCreatedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>
    {
        internal AcsChatThreadCreatedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel CreatedByCommunicationIdentifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> Participants { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadCreatedWithUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>
    {
        internal AcsChatThreadCreatedWithUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel CreatedByCommunicationIdentifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> Participants { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadCreatedWithUserEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>
    {
        internal AcsChatThreadDeletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel DeletedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadEventBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>
    {
        internal AcsChatThreadEventBaseProperties() { }
        public System.DateTimeOffset? CreateTime { get { throw null; } }
        public long? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadEventInThreadBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>
    {
        internal AcsChatThreadEventInThreadBaseProperties() { }
        public System.DateTimeOffset? CreateTime { get { throw null; } }
        public long? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadParticipantProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>
    {
        internal AcsChatThreadParticipantProperties() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel ParticipantCommunicationIdentifier { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadPropertiesUpdatedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>
    {
        internal AcsChatThreadPropertiesUpdatedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel EditedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadPropertiesUpdatedPerUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>
    {
        internal AcsChatThreadPropertiesUpdatedPerUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel EditedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadPropertiesUpdatedPerUserEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsChatThreadWithUserDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>
    {
        internal AcsChatThreadWithUserDeletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel DeletedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadWithUserDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsEmailDeliveryReportReceivedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>
    {
        internal AcsEmailDeliveryReportReceivedEventData() { }
        public System.DateTimeOffset? DeliveryAttemptTimestamp { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails DeliveryStatusDetails { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string Recipient { get { throw null; } }
        public string Sender { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus? Status { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsEmailDeliveryReportStatus : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsEmailDeliveryReportStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus Bounced { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus Delivered { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus FilteredSpam { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus Quarantined { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus Suppressed { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus left, Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus left, Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsEmailDeliveryReportStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>
    {
        internal AcsEmailDeliveryReportStatusDetails() { }
        public string StatusMessage { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailDeliveryReportStatusDetails>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsEmailEngagementTrackingReportReceivedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>
    {
        internal AcsEmailEngagementTrackingReportReceivedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement? Engagement { get { throw null; } }
        public string EngagementContext { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string Recipient { get { throw null; } }
        public string Sender { get { throw null; } }
        public System.DateTimeOffset? UserActionTimestamp { get { throw null; } }
        public string UserAgent { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsEmailEngagementTrackingReportReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsIncomingCallCustomContext : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>
    {
        internal AcsIncomingCallCustomContext() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SipHeaders { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> VoipHeaders { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsIncomingCallEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>
    {
        internal AcsIncomingCallEventData() { }
        public string CallerDisplayName { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallCustomContext CustomContext { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel FromCommunicationIdentifier { get { throw null; } }
        public string IncomingCallContext { get { throw null; } }
        public string ServerCallId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel ToCommunicationIdentifier { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsIncomingCallEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRecordingChannelType : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRecordingChannelType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType Mixed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType Unmixed { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType left, Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType left, Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsRecordingChunkInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>
    {
        internal AcsRecordingChunkInfoProperties() { }
        public string ContentLocation { get { throw null; } }
        public string DeleteLocation { get { throw null; } }
        public string DocumentId { get { throw null; } }
        public string EndReason { get { throw null; } }
        public long? Index { get { throw null; } }
        public string MetadataLocation { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRecordingContentType : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRecordingContentType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType Audio { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType AudioVideo { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType left, Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType left, Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsRecordingFileStatusUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>
    {
        internal AcsRecordingFileStatusUpdatedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChannelType? ChannelType { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRecordingContentType? ContentType { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType? FormatType { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.RecordingChannelType? RecordingChannelType { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.RecordingContentType? RecordingContentType { get { throw null; } }
        public long? RecordingDurationMs { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.RecordingFormatType? RecordingFormatType { get { throw null; } }
        public System.DateTimeOffset? RecordingStartTime { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties RecordingStorageInfo { get { throw null; } }
        public string SessionEndReason { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFileStatusUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRecordingFormatType : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRecordingFormatType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType Mp3 { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType Mp4 { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType Wav { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType left, Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType left, Azure.Messaging.EventGrid.SystemEvents.AcsRecordingFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsRecordingStorageInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>
    {
        internal AcsRecordingStorageInfoProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingChunkInfoProperties> RecordingChunks { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRecordingStorageInfoProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterChannelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>
    {
        internal AcsRouterChannelConfiguration() { }
        public int? CapacityCostPerJob { get { throw null; } }
        public string ChannelId { get { throw null; } }
        public int? MaxNumberOfJobs { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>
    {
        internal AcsRouterEventData() { }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } }
        public string JobId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobCancelledEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>
    {
        internal AcsRouterJobCancelledEventData() { }
        public string DispositionCode { get { throw null; } }
        public string Note { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCancelledEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobClassificationFailedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>
    {
        internal AcsRouterJobClassificationFailedEventData() { }
        public string ClassificationPolicyId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassificationFailedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobClassifiedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>
    {
        internal AcsRouterJobClassifiedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> AttachedWorkerSelectors { get { throw null; } }
        public string ClassificationPolicyId { get { throw null; } }
        public int? Priority { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails QueueDetails { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClassifiedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobClosedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>
    {
        internal AcsRouterJobClosedEventData() { }
        public string AssignmentId { get { throw null; } }
        public string DispositionCode { get { throw null; } }
        public string WorkerId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobClosedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobCompletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>
    {
        internal AcsRouterJobCompletedEventData() { }
        public string AssignmentId { get { throw null; } }
        public string WorkerId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>
    {
        internal AcsRouterJobDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>
    {
        internal AcsRouterJobEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Labels { get { throw null; } }
        public string QueueId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobExceptionTriggeredEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>
    {
        internal AcsRouterJobExceptionTriggeredEventData() { }
        public string ExceptionRuleId { get { throw null; } }
        public string RuleKey { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobExceptionTriggeredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobQueuedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>
    {
        internal AcsRouterJobQueuedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> AttachedWorkerSelectors { get { throw null; } }
        public int? Priority { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobQueuedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>
    {
        internal AcsRouterJobReceivedEventData() { }
        public string ClassificationPolicyId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.AcsRouterJobStatus? JobStatus { get { throw null; } }
        public int? Priority { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus? Status { get { throw null; } }
        public bool UnavailableForMatching { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobSchedulingFailedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>
    {
        internal AcsRouterJobSchedulingFailedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> ExpiredAttachedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> ExpiredRequestedWorkerSelectors { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public int? Priority { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobSchedulingFailedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRouterJobStatus : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRouterJobStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Assigned { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Cancelled { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus ClassificationFailed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Closed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Created { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus PendingClassification { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus PendingSchedule { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Queued { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus Scheduled { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus ScheduleFailed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus WaitingForActivation { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus left, Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus left, Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsRouterJobUnassignedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>
    {
        internal AcsRouterJobUnassignedEventData() { }
        public string AssignmentId { get { throw null; } }
        public string WorkerId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobUnassignedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobWaitingForActivationEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>
    {
        internal AcsRouterJobWaitingForActivationEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> ExpiredAttachedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> ExpiredRequestedWorkerSelectors { get { throw null; } }
        public int? Priority { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public bool UnavailableForMatching { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWaitingForActivationEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterJobWorkerSelectorsExpiredEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>
    {
        internal AcsRouterJobWorkerSelectorsExpiredEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> ExpiredAttachedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector> ExpiredRequestedWorkerSelectors { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobWorkerSelectorsExpiredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRouterLabelOperator : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRouterLabelOperator(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator Equal { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator Greater { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator Less { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator LessThanOrEqual { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator NotEqual { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator left, Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator left, Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsRouterQueueDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>
    {
        internal AcsRouterQueueDetails() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>
    {
        internal AcsRouterWorkerDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerDeregisteredEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>
    {
        internal AcsRouterWorkerDeregisteredEventData() { }
        public string WorkerId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerDeregisteredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>
    {
        internal AcsRouterWorkerEventData() { }
        public string WorkerId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerOfferAcceptedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>
    {
        internal AcsRouterWorkerOfferAcceptedEventData() { }
        public string AssignmentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobLabels { get { throw null; } }
        public int? JobPriority { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobTags { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string QueueId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> WorkerLabels { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> WorkerTags { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferAcceptedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerOfferDeclinedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>
    {
        internal AcsRouterWorkerOfferDeclinedEventData() { }
        public string OfferId { get { throw null; } }
        public string QueueId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferDeclinedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerOfferExpiredEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>
    {
        internal AcsRouterWorkerOfferExpiredEventData() { }
        public string OfferId { get { throw null; } }
        public string QueueId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferExpiredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerOfferIssuedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>
    {
        internal AcsRouterWorkerOfferIssuedEventData() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobLabels { get { throw null; } }
        public int? JobPriority { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobTags { get { throw null; } }
        public System.DateTimeOffset? OfferedOn { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string QueueId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> WorkerLabels { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> WorkerTags { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferIssuedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerOfferRevokedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>
    {
        internal AcsRouterWorkerOfferRevokedEventData() { }
        public string OfferId { get { throw null; } }
        public string QueueId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerOfferRevokedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerRegisteredEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>
    {
        internal AcsRouterWorkerRegisteredEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterChannelConfiguration> ChannelConfigurations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Labels { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsRouterQueueDetails> QueueAssignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public int? TotalCapacity { get { throw null; } }
        public string WorkerId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerRegisteredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsRouterWorkerSelector : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>
    {
        internal AcsRouterWorkerSelector() { }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } }
        public string Key { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator? LabelOperator { get { throw null; } }
        public object LabelValue { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator? Operator { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState? SelectorState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState? State { get { throw null; } }
        public System.TimeSpan? TimeToLive { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelector>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsRouterWorkerSelectorState : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsRouterWorkerSelectorState(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState Active { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState Expired { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState left, Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState left, Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcsSmsDeliveryAttemptProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>
    {
        internal AcsSmsDeliveryAttemptProperties() { }
        public int? SegmentsFailed { get { throw null; } }
        public int? SegmentsSucceeded { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsSmsDeliveryReportReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>
    {
        internal AcsSmsDeliveryReportReceivedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties> DeliveryAttempts { get { throw null; } }
        public string DeliveryStatus { get { throw null; } }
        public string DeliveryStatusDetails { get { throw null; } }
        public System.DateTimeOffset? ReceivedTimestamp { get { throw null; } }
        public string Tag { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryReportReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsSmsEventBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>
    {
        internal AcsSmsEventBaseProperties() { }
        public string From { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string To { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsSmsReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>
    {
        internal AcsSmsReceivedEventData() { }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? ReceivedTimestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsSmsReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AcsUserDisconnectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>
    {
        internal AcsUserDisconnectedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel UserCommunicationIdentifier { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AcsUserDisconnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcsUserEngagement : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcsUserEngagement(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement Click { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement View { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement left, Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement left, Azure.Messaging.EventGrid.SystemEvents.AcsUserEngagement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiManagementApiCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>
    {
        internal ApiManagementApiCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementApiDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>
    {
        internal ApiManagementApiDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementApiReleaseCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>
    {
        internal ApiManagementApiReleaseCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementApiReleaseDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>
    {
        internal ApiManagementApiReleaseDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementApiReleaseUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>
    {
        internal ApiManagementApiReleaseUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiReleaseUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementApiUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>
    {
        internal ApiManagementApiUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementApiUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayApiAddedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>
    {
        internal ApiManagementGatewayApiAddedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiAddedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayApiRemovedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>
    {
        internal ApiManagementGatewayApiRemovedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayApiRemovedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayCertificateAuthorityCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>
    {
        internal ApiManagementGatewayCertificateAuthorityCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayCertificateAuthorityDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>
    {
        internal ApiManagementGatewayCertificateAuthorityDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayCertificateAuthorityUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>
    {
        internal ApiManagementGatewayCertificateAuthorityUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCertificateAuthorityUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>
    {
        internal ApiManagementGatewayCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>
    {
        internal ApiManagementGatewayDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayHostnameConfigurationCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>
    {
        internal ApiManagementGatewayHostnameConfigurationCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayHostnameConfigurationDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>
    {
        internal ApiManagementGatewayHostnameConfigurationDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayHostnameConfigurationUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>
    {
        internal ApiManagementGatewayHostnameConfigurationUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayHostnameConfigurationUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementGatewayUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>
    {
        internal ApiManagementGatewayUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementGatewayUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementProductCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>
    {
        internal ApiManagementProductCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementProductDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>
    {
        internal ApiManagementProductDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementProductUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>
    {
        internal ApiManagementProductUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementProductUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementSubscriptionCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>
    {
        internal ApiManagementSubscriptionCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementSubscriptionDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>
    {
        internal ApiManagementSubscriptionDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementSubscriptionUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>
    {
        internal ApiManagementSubscriptionUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementSubscriptionUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementUserCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>
    {
        internal ApiManagementUserCreatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementUserDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>
    {
        internal ApiManagementUserDeletedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiManagementUserUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>
    {
        internal ApiManagementUserUpdatedEventData() { }
        public string ResourceUri { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ApiManagementUserUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppAction : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AppAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppAction(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction ChangedAppSettings { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Restarted { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Started { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Stopped { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AppAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AppAction left, Azure.Messaging.EventGrid.SystemEvents.AppAction right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AppAction (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AppAction left, Azure.Messaging.EventGrid.SystemEvents.AppAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationKeyValueDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>
    {
        internal AppConfigurationKeyValueDeletedEventData() { }
        public string Etag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public string SyncToken { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationKeyValueModifiedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>
    {
        internal AppConfigurationKeyValueModifiedEventData() { }
        public string Etag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public string SyncToken { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationKeyValueModifiedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationSnapshotCreatedEventData : Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>
    {
        internal AppConfigurationSnapshotCreatedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationSnapshotEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>
    {
        internal AppConfigurationSnapshotEventData() { }
        public string ETag { get { throw null; } }
        public string Name { get { throw null; } }
        public string SyncToken { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationSnapshotModifiedEventData : Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>
    {
        internal AppConfigurationSnapshotModifiedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppConfigurationSnapshotModifiedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppEventTypeDetail : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>
    {
        internal AppEventTypeDetail() { }
        public Azure.Messaging.EventGrid.SystemEvents.AppAction? Action { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServicePlanAction : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServicePlanAction(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction Updated { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction left, Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction left, Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServicePlanEventTypeDetail : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>
    {
        internal AppServicePlanEventTypeDetail() { }
        public Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction? Action { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StampKind? StampKind { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AsyncStatus? Status { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AsyncStatus : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AsyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AsyncStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AsyncStatus Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AsyncStatus Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AsyncStatus Started { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus left, Azure.Messaging.EventGrid.SystemEvents.AsyncStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AsyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus left, Azure.Messaging.EventGrid.SystemEvents.AsyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationCloudEnvironmentModel : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationCloudEnvironmentModel(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel Dod { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel Gcch { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel Public { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel left, Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel left, Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunicationIdentifierModel : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>
    {
        internal CommunicationIdentifierModel() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel CommunicationUser { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel MicrosoftTeamsUser { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel PhoneNumber { get { throw null; } }
        public string RawId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunicationUserIdentifierModel : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>
    {
        internal CommunicationUserIdentifierModel() { }
        public string Id { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryArtifactEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>
    {
        internal ContainerRegistryArtifactEventData() { }
        public string Action { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry ConnectedRegistry { get { throw null; } }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryArtifactEventTarget : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>
    {
        internal ContainerRegistryArtifactEventTarget() { }
        public string Digest { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Name { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryChartDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>
    {
        internal ContainerRegistryChartDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryChartPushedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>
    {
        internal ContainerRegistryChartPushedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryChartPushedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEventActor : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>
    {
        internal ContainerRegistryEventActor() { }
        public string Name { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEventConnectedRegistry : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>
    {
        internal ContainerRegistryEventConnectedRegistry() { }
        public string Name { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>
    {
        internal ContainerRegistryEventData() { }
        public string Action { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor Actor { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventConnectedRegistry ConnectedRegistry { get { throw null; } }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest Request { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource Source { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEventRequest : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>
    {
        internal ContainerRegistryEventRequest() { }
        public string Addr { get { throw null; } }
        public string Host { get { throw null; } }
        public string Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string Useragent { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEventSource : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>
    {
        internal ContainerRegistryEventSource() { }
        public string Addr { get { throw null; } }
        public string InstanceID { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEventTarget : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>
    {
        internal ContainerRegistryEventTarget() { }
        public string Digest { get { throw null; } }
        public long? Length { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImageDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>
    {
        internal ContainerRegistryImageDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImageDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImagePushedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>
    {
        internal ContainerRegistryImagePushedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryImagePushedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceClusterSupportEndedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>
    {
        internal ContainerServiceClusterSupportEndedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceClusterSupportEndingEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>
    {
        internal ContainerServiceClusterSupportEndingEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEndingEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceClusterSupportEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>
    {
        internal ContainerServiceClusterSupportEventData() { }
        public string KubernetesVersion { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceClusterSupportEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceNewKubernetesVersionAvailableEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>
    {
        internal ContainerServiceNewKubernetesVersionAvailableEventData() { }
        public string LatestPreviewKubernetesVersion { get { throw null; } }
        public string LatestStableKubernetesVersion { get { throw null; } }
        public string LatestSupportedKubernetesVersion { get { throw null; } }
        public string LowestMinorKubernetesVersion { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNewKubernetesVersionAvailableEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceNodePoolRollingEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>
    {
        internal ContainerServiceNodePoolRollingEventData() { }
        public string NodePoolName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceNodePoolRollingFailedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>
    {
        internal ContainerServiceNodePoolRollingFailedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingFailedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceNodePoolRollingStartedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>
    {
        internal ContainerServiceNodePoolRollingStartedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingStartedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceNodePoolRollingSucceededEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>
    {
        internal ContainerServiceNodePoolRollingSucceededEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ContainerServiceNodePoolRollingSucceededEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxCopyCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>
    {
        internal DataBoxCopyCompletedEventData() { }
        public string SerialNumber { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName? StageName { get { throw null; } }
        public System.DateTimeOffset? StageTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxCopyStartedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>
    {
        internal DataBoxCopyStartedEventData() { }
        public string SerialNumber { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName? StageName { get { throw null; } }
        public System.DateTimeOffset? StageTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxCopyStartedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxOrderCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>
    {
        internal DataBoxOrderCompletedEventData() { }
        public string SerialNumber { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName? StageName { get { throw null; } }
        public System.DateTimeOffset? StageTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DataBoxOrderCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxStageName : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxStageName(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName CopyCompleted { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName CopyStarted { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName OrderCompleted { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName left, Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName left, Azure.Messaging.EventGrid.SystemEvents.DataBoxStageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceConnectionStateEventInfo : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>
    {
        internal DeviceConnectionStateEventInfo() { }
        public string SequenceNumber { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceConnectionStateEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>
    {
        internal DeviceConnectionStateEventProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo DeviceConnectionStateEventInfo { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string HubName { get { throw null; } }
        public string ModuleId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceLifeCycleEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>
    {
        internal DeviceLifeCycleEventProperties() { }
        public string DeviceId { get { throw null; } }
        public string HubName { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo Twin { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceTelemetryEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>
    {
        internal DeviceTelemetryEventProperties() { }
        public object Body { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemProperties { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceTwinInfo : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>
    {
        internal DeviceTwinInfo() { }
        public string AuthenticationType { get { throw null; } }
        public float? CloudToDeviceMessageCount { get { throw null; } }
        public string ConnectionState { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string Etag { get { throw null; } }
        public string LastActivityTime { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusUpdateTime { get { throw null; } }
        public float? Version { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint X509Thumbprint { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceTwinInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>
    {
        internal DeviceTwinInfoProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties Desired { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties Reported { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceTwinInfoX509Thumbprint : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>
    {
        internal DeviceTwinInfoX509Thumbprint() { }
        public string PrimaryThumbprint { get { throw null; } }
        public string SecondaryThumbprint { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceTwinMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>
    {
        internal DeviceTwinMetadata() { }
        public string LastUpdated { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceTwinProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>
    {
        internal DeviceTwinProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata Metadata { get { throw null; } }
        public float? Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridMqttClientCreatedOrUpdatedEventData : Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>
    {
        internal EventGridMqttClientCreatedOrUpdatedEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Attributes { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState? State { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientCreatedOrUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridMqttClientDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>
    {
        internal EventGridMqttClientDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridMqttClientDisconnectionReason : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridMqttClientDisconnectionReason(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ClientAuthenticationError { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ClientAuthorizationError { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ClientError { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ClientInitiatedDisconnect { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ConnectionLost { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason IPForbidden { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason QuotaExceeded { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ServerError { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason ServerInitiatedDisconnect { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason SessionOverflow { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason SessionTakenOver { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason left, Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason left, Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridMqttClientEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>
    {
        internal EventGridMqttClientEventData() { }
        public string ClientAuthenticationName { get { throw null; } }
        public string ClientName { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridMqttClientSessionConnectedEventData : Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>
    {
        internal EventGridMqttClientSessionConnectedEventData() { }
        public string ClientSessionName { get { throw null; } }
        public long? SequenceNumber { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionConnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridMqttClientSessionDisconnectedEventData : Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>
    {
        internal EventGridMqttClientSessionDisconnectedEventData() { }
        public string ClientSessionName { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientDisconnectionReason? DisconnectionReason { get { throw null; } }
        public long? SequenceNumber { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientSessionDisconnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridMqttClientState : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridMqttClientState(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState Disabled { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState Enabled { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState left, Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState left, Azure.Messaging.EventGrid.SystemEvents.EventGridMqttClientState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubCaptureFileCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>
    {
        internal EventHubCaptureFileCreatedEventData() { }
        public int? EventCount { get { throw null; } }
        public string FileType { get { throw null; } }
        public string Fileurl { get { throw null; } }
        public System.DateTimeOffset? FirstEnqueueTime { get { throw null; } }
        public int? FirstSequenceNumber { get { throw null; } }
        public System.DateTimeOffset? LastEnqueueTime { get { throw null; } }
        public int? LastSequenceNumber { get { throw null; } }
        public string PartitionId { get { throw null; } }
        public int? SizeInBytes { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.EventHubCaptureFileCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareDicomImageCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>
    {
        internal HealthcareDicomImageCreatedEventData() { }
        public string ImageSeriesInstanceUid { get { throw null; } }
        public string ImageSopInstanceUid { get { throw null; } }
        public string ImageStudyInstanceUid { get { throw null; } }
        public string PartitionName { get { throw null; } }
        public long? SequenceNumber { get { throw null; } }
        public string ServiceHostName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareDicomImageDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>
    {
        internal HealthcareDicomImageDeletedEventData() { }
        public string ImageSeriesInstanceUid { get { throw null; } }
        public string ImageSopInstanceUid { get { throw null; } }
        public string ImageStudyInstanceUid { get { throw null; } }
        public string PartitionName { get { throw null; } }
        public long? SequenceNumber { get { throw null; } }
        public string ServiceHostName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareDicomImageUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>
    {
        internal HealthcareDicomImageUpdatedEventData() { }
        public string ImageSeriesInstanceUid { get { throw null; } }
        public string ImageSopInstanceUid { get { throw null; } }
        public string ImageStudyInstanceUid { get { throw null; } }
        public string PartitionName { get { throw null; } }
        public long? SequenceNumber { get { throw null; } }
        public string ServiceHostName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareDicomImageUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareFhirResourceCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>
    {
        internal HealthcareFhirResourceCreatedEventData() { }
        public string FhirResourceId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType? FhirResourceType { get { throw null; } }
        public long? FhirResourceVersionId { get { throw null; } }
        public string FhirServiceHostName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareFhirResourceDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>
    {
        internal HealthcareFhirResourceDeletedEventData() { }
        public string FhirResourceId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType? FhirResourceType { get { throw null; } }
        public long? FhirResourceVersionId { get { throw null; } }
        public string FhirServiceHostName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareFhirResourceType : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareFhirResourceType(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Account { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ActivityDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType AdverseEvent { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType AllergyIntolerance { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Appointment { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType AppointmentResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType AuditEvent { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Basic { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Binary { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType BiologicallyDerivedProduct { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType BodySite { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType BodyStructure { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Bundle { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CapabilityStatement { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CarePlan { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CareTeam { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CatalogEntry { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ChargeItem { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ChargeItemDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Claim { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ClaimResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ClinicalImpression { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CodeSystem { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Communication { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CommunicationRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CompartmentDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Composition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ConceptMap { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Condition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Consent { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Contract { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Coverage { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CoverageEligibilityRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType CoverageEligibilityResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DataElement { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DetectedIssue { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Device { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DeviceComponent { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DeviceDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DeviceMetric { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DeviceRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DeviceUseStatement { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DiagnosticReport { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DocumentManifest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DocumentReference { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType DomainResource { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EffectEvidenceSynthesis { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EligibilityRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EligibilityResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Encounter { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Endpoint { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EnrollmentRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EnrollmentResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EpisodeOfCare { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EventDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Evidence { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType EvidenceVariable { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ExampleScenario { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ExpansionProfile { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ExplanationOfBenefit { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType FamilyMemberHistory { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Flag { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Goal { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType GraphDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Group { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType GuidanceResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType HealthcareService { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ImagingManifest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ImagingStudy { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Immunization { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ImmunizationEvaluation { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ImmunizationRecommendation { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ImplementationGuide { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType InsurancePlan { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Invoice { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Library { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Linkage { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType List { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Location { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Measure { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MeasureReport { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Media { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Medication { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicationAdministration { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicationDispense { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicationKnowledge { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicationRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicationStatement { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProduct { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductAuthorization { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductContraindication { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductIndication { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductIngredient { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductInteraction { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductManufactured { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductPackaged { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductPharmaceutical { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MedicinalProductUndesirableEffect { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MessageDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MessageHeader { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType MolecularSequence { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType NamingSystem { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType NutritionOrder { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Observation { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ObservationDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType OperationDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType OperationOutcome { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Organization { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType OrganizationAffiliation { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Parameters { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Patient { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType PaymentNotice { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType PaymentReconciliation { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Person { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType PlanDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Practitioner { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType PractitionerRole { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Procedure { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ProcedureRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ProcessRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ProcessResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Provenance { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Questionnaire { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType QuestionnaireResponse { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ReferralRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType RelatedPerson { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType RequestGroup { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ResearchDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ResearchElementDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ResearchStudy { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ResearchSubject { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Resource { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType RiskAssessment { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType RiskEvidenceSynthesis { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Schedule { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SearchParameter { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Sequence { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ServiceDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ServiceRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Slot { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Specimen { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SpecimenDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType StructureDefinition { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType StructureMap { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Subscription { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Substance { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SubstanceNucleicAcid { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SubstancePolymer { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SubstanceProtein { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SubstanceReferenceInformation { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SubstanceSourceMaterial { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SubstanceSpecification { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SupplyDelivery { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType SupplyRequest { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType Task { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType TerminologyCapabilities { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType TestReport { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType TestScript { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType ValueSet { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType VerificationResult { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType VisionPrescription { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType left, Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType left, Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareFhirResourceUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>
    {
        internal HealthcareFhirResourceUpdatedEventData() { }
        public string FhirResourceId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceType? FhirResourceType { get { throw null; } }
        public long? FhirResourceVersionId { get { throw null; } }
        public string FhirServiceHostName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.HealthcareFhirResourceUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDeviceConnectedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>
    {
        internal IotHubDeviceConnectedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceConnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDeviceCreatedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>
    {
        internal IotHubDeviceCreatedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDeviceDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>
    {
        internal IotHubDeviceDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDeviceDisconnectedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>
    {
        internal IotHubDeviceDisconnectedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceDisconnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDeviceTelemetryEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>
    {
        internal IotHubDeviceTelemetryEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.IotHubDeviceTelemetryEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultAccessPolicyChangedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>
    {
        internal KeyVaultAccessPolicyChangedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultAccessPolicyChangedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultCertificateExpiredEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>
    {
        internal KeyVaultCertificateExpiredEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateExpiredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultCertificateNearExpiryEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>
    {
        internal KeyVaultCertificateNearExpiryEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNearExpiryEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultCertificateNewVersionCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>
    {
        internal KeyVaultCertificateNewVersionCreatedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultCertificateNewVersionCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultKeyExpiredEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>
    {
        internal KeyVaultKeyExpiredEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyExpiredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultKeyNearExpiryEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>
    {
        internal KeyVaultKeyNearExpiryEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNearExpiryEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultKeyNewVersionCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>
    {
        internal KeyVaultKeyNewVersionCreatedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultKeyNewVersionCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretExpiredEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>
    {
        internal KeyVaultSecretExpiredEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretExpiredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretNearExpiryEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>
    {
        internal KeyVaultSecretNearExpiryEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNearExpiryEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretNewVersionCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>
    {
        internal KeyVaultSecretNewVersionCreatedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.KeyVaultSecretNewVersionCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServicesDatasetDriftDetectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>
    {
        internal MachineLearningServicesDatasetDriftDetectedEventData() { }
        public string BaseDatasetId { get { throw null; } }
        public string DataDriftId { get { throw null; } }
        public string DataDriftName { get { throw null; } }
        public double? DriftCoefficient { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string RunId { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string TargetDatasetId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesDatasetDriftDetectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServicesModelDeployedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>
    {
        internal MachineLearningServicesModelDeployedEventData() { }
        public string ModelIds { get { throw null; } }
        public string ServiceComputeType { get { throw null; } }
        public string ServiceName { get { throw null; } }
        public object ServiceProperties { get { throw null; } }
        public object ServiceTags { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelDeployedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServicesModelRegisteredEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>
    {
        internal MachineLearningServicesModelRegisteredEventData() { }
        public string ModelName { get { throw null; } }
        public object ModelProperties { get { throw null; } }
        public object ModelTags { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesModelRegisteredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServicesRunCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>
    {
        internal MachineLearningServicesRunCompletedEventData() { }
        public string ExperimentId { get { throw null; } }
        public string ExperimentName { get { throw null; } }
        public string RunId { get { throw null; } }
        public object RunProperties { get { throw null; } }
        public object RunTags { get { throw null; } }
        public string RunType { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServicesRunStatusChangedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>
    {
        internal MachineLearningServicesRunStatusChangedEventData() { }
        public string ExperimentId { get { throw null; } }
        public string ExperimentName { get { throw null; } }
        public string RunId { get { throw null; } }
        public object RunProperties { get { throw null; } }
        public string RunStatus { get { throw null; } }
        public object RunTags { get { throw null; } }
        public string RunType { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MachineLearningServicesRunStatusChangedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsGeofenceEnteredEventData : Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>
    {
        internal MapsGeofenceEnteredEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEnteredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsGeofenceEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>
    {
        internal MapsGeofenceEventProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ExpiredGeofenceGeometryId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> Geometries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InvalidPeriodGeofenceGeometryId { get { throw null; } }
        public bool? IsEventPublished { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsGeofenceExitedEventData : Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>
    {
        internal MapsGeofenceExitedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceExitedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsGeofenceGeometry : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>
    {
        internal MapsGeofenceGeometry() { }
        public string DeviceId { get { throw null; } }
        public float? Distance { get { throw null; } }
        public string GeometryId { get { throw null; } }
        public float? NearestLat { get { throw null; } }
        public float? NearestLon { get { throw null; } }
        public string UdId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsGeofenceResultEventData : Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>
    {
        internal MapsGeofenceResultEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceResultEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobCanceledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>
    {
        internal MediaJobCanceledEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCanceledEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobCancelingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>
    {
        internal MediaJobCancelingEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobCancelingEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobError : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>
    {
        internal MediaJobError() { }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCategory? Category { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCode? Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobRetry? Retry { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobError System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobError System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobError>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MediaJobErrorCategory
    {
        Service = 0,
        Download = 1,
        Upload = 2,
        Configuration = 3,
        Content = 4,
        Account = 5,
    }
    public enum MediaJobErrorCode
    {
        ServiceError = 0,
        ServiceTransientError = 1,
        DownloadNotAccessible = 2,
        DownloadTransientError = 3,
        UploadNotAccessible = 4,
        UploadTransientError = 5,
        ConfigurationUnsupported = 6,
        ContentMalformed = 7,
        ContentUnsupported = 8,
        IdentityUnsupported = 9,
    }
    public partial class MediaJobErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>
    {
        internal MediaJobErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobErroredEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>
    {
        internal MediaJobErroredEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobErroredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobFinishedEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>
    {
        internal MediaJobFinishedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobFinishedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutput : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>
    {
        internal MediaJobOutput() { }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobError Error { get { throw null; } }
        public string Label { get { throw null; } }
        public long Progress { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState State { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputAsset : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>
    {
        internal MediaJobOutputAsset() { }
        public string AssetName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputAsset>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputCanceledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>
    {
        internal MediaJobOutputCanceledEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCanceledEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputCancelingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>
    {
        internal MediaJobOutputCancelingEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputCancelingEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputErroredEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>
    {
        internal MediaJobOutputErroredEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputErroredEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputFinishedEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>
    {
        internal MediaJobOutputFinishedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputFinishedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputProcessingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>
    {
        internal MediaJobOutputProcessingEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProcessingEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputProgressEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>
    {
        internal MediaJobOutputProgressEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobCorrelationData { get { throw null; } }
        public string Label { get { throw null; } }
        public long? Progress { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputProgressEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputScheduledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>
    {
        internal MediaJobOutputScheduledEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputScheduledEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobOutputStateChangeEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>
    {
        internal MediaJobOutputStateChangeEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobCorrelationData { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput Output { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? PreviousState { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaJobProcessingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>
    {
        internal MediaJobProcessingEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobProcessingEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MediaJobRetry
    {
        DoNotRetry = 0,
        MayRetry = 1,
    }
    public partial class MediaJobScheduledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>
    {
        internal MediaJobScheduledEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobScheduledEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MediaJobState
    {
        Canceled = 0,
        Canceling = 1,
        Error = 2,
        Finished = 3,
        Processing = 4,
        Queued = 5,
        Scheduled = 6,
    }
    public partial class MediaJobStateChangeEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>
    {
        internal MediaJobStateChangeEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CorrelationData { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? PreviousState { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? State { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventChannelArchiveHeartbeatEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>
    {
        internal MediaLiveEventChannelArchiveHeartbeatEventData() { }
        public System.TimeSpan? ChannelLatency { get { throw null; } }
        public string LatencyResultCode { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventChannelArchiveHeartbeatEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventConnectionRejectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>
    {
        internal MediaLiveEventConnectionRejectedEventData() { }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string ResultCode { get { throw null; } }
        public string StreamId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventConnectionRejectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventEncoderConnectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>
    {
        internal MediaLiveEventEncoderConnectedEventData() { }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string StreamId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderConnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventEncoderDisconnectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>
    {
        internal MediaLiveEventEncoderDisconnectedEventData() { }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string ResultCode { get { throw null; } }
        public string StreamId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventEncoderDisconnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventIncomingDataChunkDroppedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>
    {
        internal MediaLiveEventIncomingDataChunkDroppedEventData() { }
        public long? Bitrate { get { throw null; } }
        public string ResultCode { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingDataChunkDroppedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventIncomingStreamReceivedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>
    {
        internal MediaLiveEventIncomingStreamReceivedEventData() { }
        public long? Bitrate { get { throw null; } }
        public string Duration { get { throw null; } }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamReceivedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventIncomingStreamsOutOfSyncEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>
    {
        internal MediaLiveEventIncomingStreamsOutOfSyncEventData() { }
        public string MaxLastTimestamp { get { throw null; } }
        public string MinLastTimestamp { get { throw null; } }
        public string TimescaleOfMaxLastTimestamp { get { throw null; } }
        public string TimescaleOfMinLastTimestamp { get { throw null; } }
        public string TypeOfStreamWithMaxLastTimestamp { get { throw null; } }
        public string TypeOfStreamWithMinLastTimestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingStreamsOutOfSyncEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventIncomingVideoStreamsOutOfSyncEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>
    {
        internal MediaLiveEventIncomingVideoStreamsOutOfSyncEventData() { }
        public string FirstDuration { get { throw null; } }
        public string FirstTimestamp { get { throw null; } }
        public string SecondDuration { get { throw null; } }
        public string SecondTimestamp { get { throw null; } }
        public string Timescale { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventIngestHeartbeatEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>
    {
        internal MediaLiveEventIngestHeartbeatEventData() { }
        public long? Bitrate { get { throw null; } }
        public long? DiscontinuityCount { get { throw null; } }
        public bool? Healthy { get { throw null; } }
        public long? IncomingBitrate { get { throw null; } }
        public int? IngestDriftValue { get { throw null; } }
        public System.DateTimeOffset? LastFragmentArrivalTime { get { throw null; } }
        public string LastTimestamp { get { throw null; } }
        public long? NonincreasingCount { get { throw null; } }
        public long? OverlapCount { get { throw null; } }
        public string State { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
        public string TranscriptionLanguage { get { throw null; } }
        public string TranscriptionState { get { throw null; } }
        public bool? UnexpectedBitrate { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventIngestHeartbeatEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaLiveEventTrackDiscontinuityDetectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>
    {
        internal MediaLiveEventTrackDiscontinuityDetectedEventData() { }
        public long? Bitrate { get { throw null; } }
        public string DiscontinuityGap { get { throw null; } }
        public string NewTimestamp { get { throw null; } }
        public string PreviousTimestamp { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MediaLiveEventTrackDiscontinuityDetectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftTeamsUserIdentifierModel : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>
    {
        internal MicrosoftTeamsUserIdentifierModel() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel? Cloud { get { throw null; } }
        public bool? IsAnonymous { get { throw null; } }
        public string UserId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PhoneNumberIdentifierModel : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>
    {
        internal PhoneNumberIdentifierModel() { }
        public string Value { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyInsightsPolicyStateChangedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>
    {
        internal PolicyInsightsPolicyStateChangedEventData() { }
        public string ComplianceReasonCode { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public string PolicyAssignmentId { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateChangedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyInsightsPolicyStateCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>
    {
        internal PolicyInsightsPolicyStateCreatedEventData() { }
        public string ComplianceReasonCode { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public string PolicyAssignmentId { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyInsightsPolicyStateDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>
    {
        internal PolicyInsightsPolicyStateDeletedEventData() { }
        public string ComplianceReasonCode { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public string PolicyAssignmentId { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.PolicyInsightsPolicyStateDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisExportRdbCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>
    {
        internal RedisExportRdbCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisExportRdbCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisImportRdbCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>
    {
        internal RedisImportRdbCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisImportRdbCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisPatchingCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>
    {
        internal RedisPatchingCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisPatchingCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisScalingCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>
    {
        internal RedisScalingCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.RedisScalingCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceActionCancelEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>
    {
        internal ResourceActionCancelEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionCancelEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceActionFailureEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>
    {
        internal ResourceActionFailureEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionFailureEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceActionSuccessEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>
    {
        internal ResourceActionSuccessEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceActionSuccessEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>
    {
        internal ResourceAuthorization() { }
        public string Action { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Evidence { get { throw null; } }
        public string Scope { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceDeleteCancelEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>
    {
        internal ResourceDeleteCancelEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteCancelEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceDeleteFailureEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>
    {
        internal ResourceDeleteFailureEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteFailureEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceDeleteSuccessEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>
    {
        internal ResourceDeleteSuccessEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceDeleteSuccessEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHttpRequest : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>
    {
        internal ResourceHttpRequest() { }
        public string ClientIpAddress { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public Azure.Core.RequestMethod Method { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsHealthResourcesAnnotatedEventData : Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>
    {
        internal ResourceNotificationsHealthResourcesAnnotatedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAnnotatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData : Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>
    {
        internal ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsOperationalDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>
    {
        internal ResourceNotificationsOperationalDetails() { }
        public System.DateTimeOffset? ResourceEventTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsResourceDeletedDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>
    {
        internal ResourceNotificationsResourceDeletedDetails() { }
        public Azure.Core.ResourceIdentifier Resource { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsResourceDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>
    {
        internal ResourceNotificationsResourceDeletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails OperationalDetails { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedDetails ResourceDetails { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsResourceManagementCreatedOrUpdatedEventData : Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>
    {
        internal ResourceNotificationsResourceManagementCreatedOrUpdatedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementCreatedOrUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsResourceManagementDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceDeletedEventData, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>
    {
        internal ResourceNotificationsResourceManagementDeletedEventData() { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceManagementDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsResourceUpdatedDetails : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>
    {
        internal ResourceNotificationsResourceUpdatedDetails() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Location { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
        public Azure.Core.ResourceIdentifier Resource { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ResourceTags { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ResourceType { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property will always be null. Use ResourceTags instead.")]
        public string Tags { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNotificationsResourceUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>
    {
        internal ResourceNotificationsResourceUpdatedEventData() { }
        public string ApiVersion { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsOperationalDetails OperationalDetails { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedDetails ResourceDetails { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceNotificationsResourceUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceWriteCancelEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>
    {
        internal ResourceWriteCancelEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteCancelEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceWriteFailureEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>
    {
        internal ResourceWriteFailureEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteFailureEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceWriteSuccessEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>
    {
        internal ResourceWriteSuccessEventData() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Authorization { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceAuthorization AuthorizationValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Claims { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClaimsValue { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string HttpRequest { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ResourceHttpRequest HttpRequestValue { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ResourceWriteSuccessEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>
    {
        internal ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusActiveMessagesAvailableWithNoListenersEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>
    {
        internal ServiceBusActiveMessagesAvailableWithNoListenersEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusActiveMessagesAvailableWithNoListenersEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>
    {
        internal ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusDeadletterMessagesAvailableWithNoListenersEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>
    {
        internal ServiceBusDeadletterMessagesAvailableWithNoListenersEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.ServiceBusDeadletterMessagesAvailableWithNoListenersEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRServiceClientConnectionConnectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>
    {
        internal SignalRServiceClientConnectionConnectedEventData() { }
        public string ConnectionId { get { throw null; } }
        public string HubName { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string UserId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionConnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalRServiceClientConnectionDisconnectedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>
    {
        internal SignalRServiceClientConnectionDisconnectedEventData() { }
        public string ConnectionId { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string HubName { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string UserId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SignalRServiceClientConnectionDisconnectedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StampKind : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.StampKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StampKind(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StampKind AseV1 { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.StampKind AseV2 { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.StampKind Public { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.StampKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.StampKind left, Azure.Messaging.EventGrid.SystemEvents.StampKind right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.StampKind (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.StampKind left, Azure.Messaging.EventGrid.SystemEvents.StampKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAsyncOperationInitiatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>
    {
        internal StorageAsyncOperationInitiatedEventData() { }
        public string Api { get { throw null; } }
        public string BlobType { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public long? ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageAsyncOperationInitiatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBlobCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>
    {
        internal StorageBlobCreatedEventData() { }
        public string Api { get { throw null; } }
        public string BlobType { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public long? ContentLength { get { throw null; } }
        public long? ContentOffset { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBlobDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>
    {
        internal StorageBlobDeletedEventData() { }
        public string Api { get { throw null; } }
        public string BlobType { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBlobInventoryPolicyCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>
    {
        internal StorageBlobInventoryPolicyCompletedEventData() { }
        public string AccountName { get { throw null; } }
        public string ManifestBlobUrl { get { throw null; } }
        public string PolicyRunId { get { throw null; } }
        public string PolicyRunStatus { get { throw null; } }
        public string PolicyRunStatusMessage { get { throw null; } }
        public string RuleName { get { throw null; } }
        public System.DateTimeOffset? ScheduleDateTime { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobInventoryPolicyCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBlobRenamedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>
    {
        internal StorageBlobRenamedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string DestinationUrl { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public string SourceUrl { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobRenamedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBlobTierChangedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>
    {
        internal StorageBlobTierChangedEventData() { }
        public string Api { get { throw null; } }
        public string BlobType { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public long? ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageBlobTierChangedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDirectoryCreatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>
    {
        internal StorageDirectoryCreatedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryCreatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDirectoryDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>
    {
        internal StorageDirectoryDeletedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string Identity { get { throw null; } }
        public bool? Recursive { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageDirectoryRenamedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>
    {
        internal StorageDirectoryRenamedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string DestinationUrl { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public string SourceUrl { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageDirectoryRenamedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageLifecyclePolicyActionSummaryDetail : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>
    {
        internal StorageLifecyclePolicyActionSummaryDetail() { }
        public string ErrorList { get { throw null; } }
        public long? SuccessCount { get { throw null; } }
        public long? TotalObjectsCount { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageLifecyclePolicyCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>
    {
        internal StorageLifecyclePolicyCompletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail DeleteSummary { get { throw null; } }
        public string ScheduleTime { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail TierToArchiveSummary { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail TierToCoolSummary { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>
    {
        internal StorageTaskCompletedEventData() { }
        public System.DateTimeOffset? CompletedDateTime { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus? Status { get { throw null; } }
        public System.Uri SummaryReportBlobUri { get { throw null; } }
        public string TaskExecutionId { get { throw null; } }
        public string TaskName { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskCompletedStatus : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskCompletedStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus left, Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus left, Azure.Messaging.EventGrid.SystemEvents.StorageTaskCompletedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskQueuedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>
    {
        internal StorageTaskQueuedEventData() { }
        public System.DateTimeOffset? QueuedDateTime { get { throw null; } }
        public string TaskExecutionId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.StorageTaskQueuedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionDeletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>
    {
        internal SubscriptionDeletedEventData() { }
        public string EventSubscriptionId { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionDeletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionValidationEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>
    {
        internal SubscriptionValidationEventData() { }
        public string ValidationCode { get { throw null; } }
        public string ValidationUrl { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionValidationResponse : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>
    {
        public SubscriptionValidationResponse() { }
        public string ValidationResponse { get { throw null; } set { } }
        Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.SubscriptionValidationResponse>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebAppServicePlanUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>
    {
        internal WebAppServicePlanUpdatedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail AppServicePlanEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku Sku { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebAppServicePlanUpdatedEventDataSku : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>
    {
        internal WebAppServicePlanUpdatedEventDataSku() { }
        public string Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebAppUpdatedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>
    {
        internal WebAppUpdatedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebAppUpdatedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebBackupOperationCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>
    {
        internal WebBackupOperationCompletedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebBackupOperationFailedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>
    {
        internal WebBackupOperationFailedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationFailedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebBackupOperationStartedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>
    {
        internal WebBackupOperationStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebBackupOperationStartedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebRestoreOperationCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>
    {
        internal WebRestoreOperationCompletedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebRestoreOperationFailedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>
    {
        internal WebRestoreOperationFailedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationFailedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebRestoreOperationStartedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>
    {
        internal WebRestoreOperationStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebRestoreOperationStartedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSlotSwapCompletedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>
    {
        internal WebSlotSwapCompletedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapCompletedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSlotSwapFailedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>
    {
        internal WebSlotSwapFailedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapFailedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSlotSwapStartedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>
    {
        internal WebSlotSwapStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapStartedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSlotSwapWithPreviewCancelledEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>
    {
        internal WebSlotSwapWithPreviewCancelledEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewCancelledEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSlotSwapWithPreviewStartedEventData : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>
    {
        internal WebSlotSwapWithPreviewStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.EventGrid.SystemEvents.WebSlotSwapWithPreviewStartedEventData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EventGridPublisherClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureSasCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
