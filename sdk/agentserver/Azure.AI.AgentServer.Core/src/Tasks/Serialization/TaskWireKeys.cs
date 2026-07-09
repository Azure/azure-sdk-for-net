// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// Canonical JSON key names for the persisted task record and its nested shapes.
/// Centralized so every read/write site uses the exact protocol spelling.
/// </summary>
internal static class TaskWireKeys
{
    // TaskRecord
    public const string Object = "object";
    public const string Id = "id";
    public const string AgentName = "agent_name";
    public const string SessionId = "session_id";
    public const string Title = "title";
    public const string Description = "description";
    public const string Status = "status";
    public const string Lease = "lease";
    public const string Payload = "payload";
    public const string Tags = "tags";
    public const string Source = "source";
    public const string Attachments = "attachments";
    public const string Error = "error";
    public const string ErrorMessage = "message";
    public const string ErrorType = "type";
    public const string ErrorCode = "code";
    public const string SuspensionReason = "suspension_reason";
    public const string CreatedAt = "created_at";
    public const string UpdatedAt = "updated_at";
    public const string StartedAt = "started_at";
    public const string CompletedAt = "completed_at";
    public const string Etag = "etag";

    // Envelope constant
    public const string ObjectValue = "task";

    // Status wire values
    public const string StatusPending = "pending";
    public const string StatusInProgress = "in_progress";
    public const string StatusSuspended = "suspended";
    public const string StatusCompleted = "completed";
    public const string StatusFailed = "failed";
    public const string StatusDoneAlias = "done";

    // Suspension reasons
    public const string SuspensionReasonRunCompletion = "run_completion";

    // Payload reserved keys
    public const string PayloadInput = "input";
    public const string PayloadMetadata = "metadata";
    public const string PayloadMetadataNamespacePrefix = "metadata:";
    public const string PayloadLastInputId = "last_input_id";
    public const string PayloadTurnStartedAt = "turn_started_at";
    public const string PayloadRetryAttempt = "retry_attempt";
    public const string PayloadSteering = "steering";
    public const string PayloadSchemaVersion = "schema_version";

    // Current task-document schema version stamped at create (spec §20/§38). Its presence
    // is REQUIRED: a stale in_progress record lacking it is legacy and MUST be deleted
    // (not recovered) by the recovery scan.
    public const string SchemaVersionValue = "1";

    // Steering keys
    public const string SteeringPendingInputs = "pending_inputs";
    public const string SteeringNextInputSeq = "next_input_seq";
    public const string SteeringCancelRequested = "cancel_requested";
    public const string SteeringDrainInProgress = "drain_in_progress";
    public const string SteeringActiveInput = "active_input";

    // Lease keys
    public const string LeaseOwner = "owner";
    public const string LeaseInstanceId = "instance_id";
    public const string LeaseGeneration = "generation";
    public const string LeaseExpiresAt = "expires_at";
    public const string LeaseExpiryCount = "expiry_count";
    public const string LeaseHeartbeatAt = "heartbeat_at";

    // Source keys
    public const string SourceType = "type";
    public const string SourceName = "name";
    public const string SourceServerVersion = "server_version";
    public const string SourceHostingEnvironment = "hosting_environment";
    public const string SourceTypeValue = "agentserver.task";

    // Attachment ref keys
    public const string AttachmentRefMagic = "__attachment_ref__";
    public const string AttachmentRefKey = "key";
    public const string AttachmentRefHash = "hash";

    // Reserved tag keys
    public const string TagTaskName = "task_name";
    public const string TagReservedPrefix = "_task_";
}
