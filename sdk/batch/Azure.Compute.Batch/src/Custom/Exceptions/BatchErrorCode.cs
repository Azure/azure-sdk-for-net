// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Contains string constants for error codes returned by the Batch service.
    /// </summary>
    public readonly struct BatchErrorCode
    {
        // Batch Service

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="BatchErrorCode"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public BatchErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// The specified account is disabled.
        /// </summary>
        private const string AccountIsDisabledValue = "AccountIsDisabled";

        /// <summary>
        /// The account has reached its quota of active jobs and job schedules.
        /// </summary>
        private const string ActiveJobAndScheduleQuotaReachedValue = "ActiveJobAndScheduleQuotaReached";

        /// <summary>
        /// The specified application does not exist.
        /// </summary>
        private const string ApplicationNotFoundValue = "ApplicationNotFound";

        /// <summary>
        /// An automatic scaling formula has a syntax error.
        /// </summary>
        private const string AutoScalingFormulaSyntaxErrorValue = "AutoScalingFormulaSyntaxError";

        /// <summary>
        /// An automatic scaling formula is too long. The maximum length is 8192 characters.
        /// </summary>
        private const string AutoScaleFormulaTooLongValue = "AutoScaleFormulaTooLong";

        /// <summary>
        /// Requests for the same pool must be separated by at least 30 seconds.
        /// </summary>
        private const string TooManyRequestsValue = "TooManyRequests";

        /// <summary>
        /// Enable AutoScale requests for the same pool must be separated by at least 30 seconds.
        /// </summary>
        private const string AutoScaleTooManyRequestsToEnableValue = "TooManyEnableAutoScaleRequests";

        /// <summary>
        /// A certificate operation was attempted which is not permitted when the certificate is in the process of being deleted.
        /// </summary>
        private const string CertificateBeingDeletedValue = "CertificateBeingDeleted";

        /// <summary>
        /// The certificate you are attempting to add already exists.
        /// </summary>
        private const string CertificateExistsValue = "CertificateExists";

        /// <summary>
        /// The certificate on which an operation was attempted is not present in the Batch account.
        /// </summary>
        private const string CertificateNotFoundValue = "CertificateNotFound";

        /// <summary>
        /// A certificate operation was attempted which is not permitted when the certificate is active.
        /// </summary>
        private const string CertificateStateActiveValue = "CertificateStateActive";

        /// <summary>
        /// A certificate could not be deleted because it is still in use.
        /// </summary>
        private const string CertificateStateDeleteFailedValue = "CertificateStateDeleteFailed";

        /// <summary>
        /// A node file requested from a task or compute node was not found.
        /// </summary>
        private const string FileNotFoundValue = "FileNotFound";

        /// <summary>
        /// One or more application package references could not be satisfied. This occurs if the application
        /// id or version does not exist or is not active, or if the reference did not specify a version and
        /// there is no default version configured.
        /// </summary>
        private const string InvalidApplicationPackageReferencesValue = "InvalidApplicationPackageReferences";

        /// <summary>
        /// A pool specification specifies one or more invalid certificates (for example, certificates that are
        /// not present in the Batch account).
        /// </summary>
        private const string InvalidCertificateReferencesValue = "InvalidCertificateReferences";

        /// <summary>
        /// A value in a job or task constraint is out of range.
        /// </summary>
        private const string InvalidConstraintValueValue = "InvalidConstraintValue";

        // TODO: get real words instead of weasel words
        /// <summary>
        /// There is a conflict between the REST API being used and the account.
        /// </summary>
        private const string InvalidRestAPIForAccountSettingValue = "InvalidRestAPIForAccountSetting";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job is in the process of being deleted.
        /// </summary>
        private const string JobBeingDeletedValue = "JobBeingDeleted";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job is in the process of being terminated.
        /// </summary>
        private const string JobBeingTerminatedValue = "JobBeingTerminated";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job has been completed.
        /// </summary>
        private const string JobCompletedValue = "JobCompleted";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job is not active.
        /// </summary>
        private const string JobNotActiveValue = "JobNotActive";

        /// <summary>
        /// The specified job exists.
        /// </summary>
        private const string JobExistsValue = "JobExists";

        /// <summary>
        /// A Job Preparation task was not run on a compute node.
        /// </summary>
        private const string JobPreparationTaskNotRunOnNodeValue = "JobPreparationTaskNotRunOnNode";

        /// <summary>
        /// The specified job does not have a Job Preparation task.
        /// </summary>
        private const string JobPreparationTaskNotSpecifiedValue = "JobPreparationTaskNotSpecified";

        /// <summary>
        /// A Job Release task was not run on a compute node.
        /// </summary>
        private const string JobReleaseTaskNotRunOnNodeValue = "JobReleaseTaskNotRunOnNode";

        /// <summary>
        /// The specified job does not have a Job Release task.
        /// </summary>
        private const string JobReleaseTaskNotSpecifiedValue = "JobReleaseTaskNotSpecified";

        /// <summary>
        /// The job on which an operation was attempted is not present in the Batch account.
        /// </summary>
        private const string JobNotFoundValue = "JobNotFound";

        /// <summary>
        /// An I/O error occurred while trying to access a resource within the Batch account.
        /// </summary>
        private const string IOErrorValue = "IOError";

        /// <summary>
        /// The specified operation is not valid for the current state of the resource.
        /// </summary>
        private const string OperationInvalidForCurrentStateValue = "OperationInvalidForCurrentState";

        /// <summary>
        /// The specified Azure Guest OS version is disabled.
        /// </summary>
        private const string OSVersionDisabledValue = "OSVersionDisabled";

        /// <summary>
        /// The specified Azure Guest OS version is expired.
        /// </summary>
        private const string OSVersionExpiredValue = "OSVersionExpired";

        /// <summary>
        /// The specified Azure Guest OS version was not found.
        /// </summary>
        private const string OSVersionNotFoundValue = "OSVersionNotFound";

        /// <summary>
        /// A job priority was specified which was outside the permitted range of -1000 to 1000.
        /// </summary>
        private const string OutOfRangePriorityValue = "OutOfRangePriority";

        // TODO: confirm - guess this could also indicate a URL error?
        /// <summary>
        /// A file path was not found on a compute node.
        /// </summary>
        private const string PathNotFoundValue = "PathNotFound";

        /// <summary>
        /// A pool operation was attempted which is not permitted when the pool is in the process of being deleted.
        /// </summary>
        private const string PoolBeingDeletedValue = "PoolBeingDeleted";

        /// <summary>
        /// A pool operation was attempted which is not permitted when the pool is in the process of being resized.
        /// </summary>
        private const string PoolBeingResizedValue = "PoolBeingResized";

        /// <summary>
        /// A pool operation was attempted which is not permitted when the pool is in the process of being created.
        /// </summary>
        private const string PoolBeingCreatedValue = "PoolBeingCreated";

        /// <summary>
        /// The pool you are attempting to add already exists.
        /// </summary>
        private const string PoolExistsValue = "PoolExists";

        /// <summary>
        /// The specified pool is not eligible for an operating system version upgrade.
        /// </summary>
        private const string PoolNotEligibleForOSVersionUpgradeValue = "PoolNotEligibleForOSVersionUpgrade";

        /// <summary>
        /// The pool on which an operation was attempted is not present in the Batch account.
        /// </summary>
        private const string PoolNotFoundValue = "PoolNotFound";

        /// <summary>
        /// The account has reached its quota of pools.
        /// </summary>
        private const string PoolQuotaReachedValue = "PoolQuotaReached";

        /// <summary>
        /// The pool is already on the operating system version to which it was asked to upgrade.
        /// </summary>
        private const string PoolVersionEqualsUpgradeVersionValue = "PoolVersionEqualsUpgradeVersion";

        // TODO: unweasel
        /// <summary>
        /// A requested storage account was not found.
        /// </summary>
        private const string StorageAccountNotFoundValue = "StorageAccountNotFound";

        /// <summary>
        /// A task operation was attempted which is not permitted when the task has been completed.
        /// </summary>
        private const string TaskCompletedValue = "TaskCompleted";

        /// <summary>
        /// A task was specified as depending on other tasks, but the job did not specify that it would use task dependencies.
        /// </summary>
        private const string TaskDependenciesNotSpecifiedOnJobValue = "TaskDependenciesNotSpecifiedOnJob";

        /// <summary>
        /// A task was specified as depending on other tasks, but the list of dependencies was too long to be stored.
        /// </summary>
        private const string TaskDependencyListTooLongValue = "TaskDependencyListTooLong";

        /// <summary>
        /// A task was specified as depending on other tasks, but the list of task id ranges was too long to be stored.
        /// </summary>
        private const string TaskDependencyRangesTooLongValue = "TaskDependencyRangesTooLong";

        /// <summary>
        /// The node files for a task are not available, for example because the retention period has expired.
        /// </summary>
        private const string TaskFilesUnavailableValue = "TaskFilesUnavailable";

        /// <summary>
        /// The files of the specified task are cleaned up.
        /// </summary>
        private const string TaskFilesCleanedupValue = "TaskFilesCleanedup";

        /// <summary>
        /// The task you are attempting to add already exists.
        /// </summary>
        private const string TaskExistsValue = "TaskExists";

        /// <summary>
        /// The task id is the same as that of the Job Preparation task.
        /// </summary>
        private const string TaskIdSameAsJobPreparationTaskValue = "TaskIdSameAsJobPreparationTask";

        /// <summary>
        /// The task id is the same as that of the Job Release task.
        /// </summary>
        private const string TaskIdSameAsJobReleaseTaskValue = "TaskIdSameAsJobReleaseTask";

        /// <summary>
        /// The task on which an operation was attempted is not present in the job.
        /// </summary>
        private const string TaskNotFoundValue = "TaskNotFound";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being created.
        /// </summary>
        private const string NodeBeingCreatedValue = "NodeBeingCreated";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being started.
        /// </summary>
        private const string NodeBeingStartedValue = "NodeBeingStarted";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being rebooted.
        /// </summary>
        private const string NodeBeingRebootedValue = "NodeBeingRebooted";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being reimaged.
        /// </summary>
        private const string NodeBeingReimagedValue = "NodeBeingReimaged";

        /// <summary>
        /// The node counts do not match.
        /// </summary>
        private const string NodeCountsMismatchValue = "NodeCountsMismatch";  // TODO: substantiate this

        /// <summary>
        /// The compute node on which an operation was attempted is not present in the given pool.
        /// </summary>
        private const string NodeNotFoundValue = "NodeNotFound";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is unusable.
        /// </summary>
        private const string NodeStateUnusableValue = "NodeStateUnusable";

        /// <summary>
        /// The compute node user account you are attempting to add already exists.
        /// </summary>
        private const string NodeUserExistsValue = "NodeUserExists";

        /// <summary>
        /// The compute node user account on which an operation was attempted does not exist.
        /// </summary>
        private const string NodeUserNotFoundValue = "NodeUserNotFound";

        /// <summary>
        /// The specified compute node is already in the target scheduling state.
        /// </summary>
        private const string NodeAlreadyInTargetSchedulingStateValue = "NodeAlreadyInTargetSchedulingState";

        // TODO: unweasel
        /// <summary>
        /// A requested job or task constraint is not supported.
        /// </summary>
        private const string UnsupportedConstraintValue = "UnsupportedConstraint";

        /// <summary>
        /// The specified version of the Batch REST API is not supported.
        /// </summary>
        private const string UnsupportedRequestVersionValue = "UnsupportedRequestVersion";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule is in the process of being deleted.
        /// </summary>
        private const string JobScheduleBeingDeletedValue = "JobScheduleBeingDeleted";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule is in the process of being terminated.
        /// </summary>
        private const string JobScheduleBeingTerminatedValue = "JobScheduleBeingTerminated";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule has completed.
        /// </summary>
        private const string JobScheduleCompletedValue = "JobScheduleCompleted";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule is disabled.
        /// </summary>
        private const string JobScheduleDisabledValue = "JobScheduleDisabled";

        /// <summary>
        /// The job schedule you are attempting to add already exists in the Batch account.
        /// </summary>
        private const string JobScheduleExistsValue = "JobScheduleExists";

        /// <summary>
        /// The job schedule on which an operation was attempted does not exist.
        /// </summary>
        private const string JobScheduleNotFoundValue = "JobScheduleNotFound";

        /// <summary>
        /// The specified job is disabled.
        /// </summary>
        private const string JobDisabledValue = "JobDisabled";

        /// <summary>
        /// A job with the specified job schedule id exists. Job and job schedule cannot have the same id.
        /// </summary>
        private const string JobWithSameIdExistsValue = "JobWithSameIdExists";

        /// <summary>
        /// A job schedule with the specified job id exists. Job and job schedule cannot have the same id.
        /// </summary>
        private const string JobScheduleWithSameIdExistsValue = "JobScheduleWithSameIdExists";

        // General

        /// <summary>
        /// The Batch service failed to authenticate the request.
        /// </summary>
        private const string AuthenticationFailedValue = "AuthenticationFailed";

        /// <summary>
        /// A read operation included a HTTP conditional header, and the condition was not met.
        /// </summary>
        private const string ConditionNotMetValue = "ConditionNotMet";

        /// <summary>
        /// An add or update request specified a metadata item whose key is an empty string.
        /// </summary>
        private const string EmptyMetadataKeyValue = "EmptyMetadataKey";

        /// <summary>
        /// The host information was missing from the HTTP request.
        /// </summary>
        private const string HostInformationNotPresentValue = "HostInformationNotPresent";

        /// <summary>
        /// The account being accessed does not have sufficient permissions to execute this operation.
        /// </summary>
        private const string InsufficientAccountPermissionsValue = "InsufficientAccountPermissions";

        /// <summary>
        /// An internal error occurred in the Batch service.
        /// </summary>
        private const string InternalErrorValue = "InternalError";

        /// <summary>
        /// The authentication credentials were not provided in the correct format.
        /// </summary>
        private const string InvalidAuthenticationInfoValue = "InvalidAuthenticationInfo";

        /// <summary>
        /// The specified auto-scale settings are not valid.
        /// </summary>
        private const string InvalidAutoScalingSettingsValue = "InvalidAutoScalingSettings";

        /// <summary>
        /// The value of one of the HTTP headers was in an incorrect format.
        /// </summary>
        private const string InvalidHeaderValueValue = "InvalidHeaderValue";

        /// <summary>
        /// The Batch service did not recognise the HTTP verb.
        /// </summary>
        private const string InvalidHttpVerbValue = "InvalidHttpVerb";

        /// <summary>
        /// One of the request inputs is not valid.
        /// </summary>
        private const string InvalidInputValue = "InvalidInput";

        /// <summary>
        /// An add or update request specified a metadata item which contains characters that are not permitted.
        /// </summary>
        private const string InvalidMetadataValue = "InvalidMetadata";

        /// <summary>
        /// The value of a property in the HTTP request body is invalid.
        /// </summary>
        private const string InvalidPropertyValueValue = "InvalidPropertyValue";

        /// <summary>
        /// The HTTP request body is not syntactically valid.
        /// </summary>
        private const string InvalidRequestBodyValue = "InvalidRequestBody";

        /// <summary>
        /// The HTTP request URI contained invalid value for one of the query parameters.
        /// </summary>
        private const string InvalidQueryParameterValueValue = "InvalidQueryParameterValue";

        /// <summary>
        /// The specified byte range is invalid for the given resource.
        /// </summary>
        private const string InvalidRangeValue = "InvalidRange";

        /// <summary>
        /// The HTTP request URI was invalid.
        /// </summary>
        private const string InvalidUriValue = "InvalidUri";

        /// <summary>
        /// The size of the metadata exceeds the maximum permitted.
        /// </summary>
        private const string MetadataTooLargeValue = "MetadataTooLarge";

        /// <summary>
        /// The HTTP Content-Length header was not specified.
        /// </summary>
        private const string MissingContentLengthHeaderValue = "MissingContentLengthHeader";

        /// <summary>
        /// A required HTTP header was not specified.
        /// </summary>
        private const string MissingRequiredHeaderValue = "MissingRequiredHeader";

        /// <summary>
        /// A required property was not specified in the HTTP request body.
        /// </summary>
        private const string MissingRequiredPropertyValue = "MissingRequiredProperty";

        /// <summary>
        /// A required query parameter was not specified in the URL.
        /// </summary>
        private const string MissingRequiredQueryParameterValue = "MissingRequiredQueryParameter";

        /// <summary>
        /// Multiple condition headers are not supported.
        /// </summary>
        private const string MultipleConditionHeadersNotSupportedValue = "MultipleConditionHeadersNotSupported";

        /// <summary>
        /// The operation is not implemented.
        /// </summary>
        private const string NotImplementedValue = "NotImplemented";

        /// <summary>
        /// One of the request inputs is out of range.
        /// </summary>
        private const string OutOfRangeInputValue = "OutOfRangeInput";

        /// <summary>
        /// A query parameter in the request URL is out of range.
        /// </summary>
        private const string OutOfRangeQueryParameterValueValue = "OutOfRangeQueryParameterValue";

        /// <summary>
        /// The operation could not be completed within the permitted time.
        /// </summary>
        private const string OperationTimedOutValue = "OperationTimedOut";

        /// <summary>
        /// The size of the HTTP request body exceeds the maximum permitted.
        /// </summary>
        private const string RequestBodyTooLargeValue = "RequestBodyTooLarge";

        /// <summary>
        /// The Batch service could not parse the request URL.
        /// </summary>
        private const string RequestUrlFailedToParseValue = "RequestUrlFailedToParse";

        /// <summary>
        /// The specified resource does not exist.
        /// </summary>
        private const string ResourceNotFoundValue = "ResourceNotFound";

        /// <summary>
        /// The specified resource already exists.
        /// </summary>
        private const string ResourceAlreadyExistsValue = "ResourceAlreadyExists";

        // TODO: unweasel
        /// <summary>
        /// The resource does not match the expected type.
        /// </summary>
        private const string ResourceTypeMismatchValue = "ResourceTypeMismatch";

        /// <summary>
        /// The Batch service is currently unable to receive requests.
        /// </summary>
        private const string ServerBusyValue = "ServerBusy";

        /// <summary>
        /// One of the HTTP headers specified in the request is not supported.
        /// </summary>
        private const string UnsupportedHeaderValue = "UnsupportedHeader";

        /// <summary>
        /// The resource does not support the specified HTTP verb.
        /// </summary>
        private const string UnsupportedHttpVerbValue = "UnsupportedHttpVerb";

        /// <summary>
        /// The Batch service does not support the specified version of the HTTP protocol.
        /// </summary>
        private const string UnsupportedHttpVersionValue = "UnsupportedHttpVersion";

        /// <summary>
        /// One of the properties specified in the HTTP request body is not supported.
        /// </summary>
        private const string UnsupportedPropertyValue = "UnsupportedProperty";

        /// <summary>
        /// One of the query parameters specified in the URL is not supported.
        /// </summary>
        private const string UnsupportedQueryParameterValue = "UnsupportedQueryParameter";

        /// <summary>
        /// Task failed to add.
        /// </summary>
        private const string AddTaskCollectionTerminatedValue = "Addition of a task failed with unexpected status code.Details: {0}";

        /// <summary>
        /// Request to server failed in parallel scenario.
        /// </summary>
        private const string MultipleParallelRequestsHitUnexpectedErrorsValue = "One or more requests to the Azure Batch service failed.";

        /// <summary>
        /// Can only be run once.
        /// </summary>
        private const string CanOnlyBeRunOnceFailureValue = "{0} can only be run once.";

        // Public properties

        /// <summary>
        /// Gets the error code representing that the specified account is disabled.
        /// </summary>
        public static BatchErrorCode AccountAlreadyExists { get; } = new BatchErrorCode(AccountIsDisabledValue);

        /// <summary>
        /// Gets the error code indicating that the account has reached its quota of active jobs and job schedules.
        /// </summary>
        public static BatchErrorCode ActiveJobAndScheduleQuotaReached { get; } = new BatchErrorCode(ActiveJobAndScheduleQuotaReachedValue);

        /// <summary>
        /// Gets the error code indicating that the specified application does not exist.
        /// </summary>
        public static BatchErrorCode ApplicationNotFound { get; } = new BatchErrorCode(ApplicationNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that an automatic scaling formula has a syntax error.
        /// </summary>
        public static BatchErrorCode AutoScalingFormulaSyntaxError { get; } = new BatchErrorCode(AutoScalingFormulaSyntaxErrorValue);

        /// <summary>
        /// Gets the error code indicating that an automatic scaling formula is too long.
        /// </summary>
        public static BatchErrorCode AutoScaleFormulaTooLong { get; } = new BatchErrorCode(AutoScaleFormulaTooLongValue);

        /// <summary>
        /// Gets the error code indicating that requests for the same pool must be separated by at least 30 seconds.
        /// </summary>
        public static BatchErrorCode TooManyRequests { get; } = new BatchErrorCode(TooManyRequestsValue);

        /// <summary>
        /// Gets the error code indicating that Enable AutoScale requests for the same pool must be separated by at least 30 seconds.
        /// </summary>
        public static BatchErrorCode AutoScaleTooManyRequestsToEnable { get; } = new BatchErrorCode(AutoScaleTooManyRequestsToEnableValue);

        /// <summary>
        /// Gets the error code indicating that a certificate operation was attempted while the certificate is being deleted.
        /// </summary>
        public static BatchErrorCode CertificateBeingDeleted { get; } = new BatchErrorCode(CertificateBeingDeletedValue);

        /// <summary>
        /// Gets the error code indicating that the certificate already exists.
        /// </summary>
        public static BatchErrorCode CertificateExists { get; } = new BatchErrorCode(CertificateExistsValue);

        /// <summary>
        /// Gets the error code indicating that the certificate was not found in the Batch account.
        /// </summary>
        public static BatchErrorCode CertificateNotFound { get; } = new BatchErrorCode(CertificateNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that a certificate operation was attempted while the certificate is active.
        /// </summary>
        public static BatchErrorCode CertificateStateActive { get; } = new BatchErrorCode(CertificateStateActiveValue);

        /// <summary>
        /// Gets the error code indicating that a certificate could not be deleted because it is still in use.
        /// </summary>
        public static BatchErrorCode CertificateStateDeleteFailed { get; } = new BatchErrorCode(CertificateStateDeleteFailedValue);

        /// <summary>
        /// Gets the error code indicating that a node file requested from a task or compute node was not found.
        /// </summary>
        public static BatchErrorCode FileNotFound { get; } = new BatchErrorCode(FileNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that one or more application package references could not be satisfied.
        /// </summary>
        public static BatchErrorCode InvalidApplicationPackageReferences { get; } = new BatchErrorCode(InvalidApplicationPackageReferencesValue);

        /// <summary>
        /// Gets the error code indicating that a pool specification contains invalid certificate references.
        /// </summary>
        public static BatchErrorCode InvalidCertificateReferences { get; } = new BatchErrorCode(InvalidCertificateReferencesValue);

        /// <summary>
        /// Gets the error code indicating that a value in a job or task constraint is out of range.
        /// </summary>
        public static BatchErrorCode InvalidConstraintValue { get; } = new BatchErrorCode(InvalidConstraintValueValue);

        /// <summary>
        /// Gets the error code indicating that there is a conflict between the REST API and the account.
        /// </summary>
        public static BatchErrorCode InvalidRestAPIForAccountSetting { get; } = new BatchErrorCode(InvalidRestAPIForAccountSettingValue);

        /// <summary>
        /// Gets the error code indicating that a job operation was attempted while the job is being deleted.
        /// </summary>
        public static BatchErrorCode JobBeingDeleted { get; } = new BatchErrorCode(JobBeingDeletedValue);

        /// <summary>
        /// Gets the error code indicating that a job operation was attempted while the job is being terminated.
        /// </summary>
        public static BatchErrorCode JobBeingTerminated { get; } = new BatchErrorCode(JobBeingTerminatedValue);

        /// <summary>
        /// Gets the error code indicating that a job operation was attempted on a completed job.
        /// </summary>
        public static BatchErrorCode JobCompleted { get; } = new BatchErrorCode(JobCompletedValue);

        /// <summary>
        /// Gets the error code indicating that a job operation was attempted on a job that is not active.
        /// </summary>
        public static BatchErrorCode JobNotActive { get; } = new BatchErrorCode(JobNotActiveValue);

        /// <summary>
        /// Gets the error code indicating that the specified job already exists.
        /// </summary>
        public static BatchErrorCode JobExists { get; } = new BatchErrorCode(JobExistsValue);

        /// <summary>
        /// Gets the error code indicating that a Job Preparation task was not run on a compute node.
        /// </summary>
        public static BatchErrorCode JobPreparationTaskNotRunOnNode { get; } = new BatchErrorCode(JobPreparationTaskNotRunOnNodeValue);

        /// <summary>
        /// Gets the error code indicating that no Job Preparation task was specified for the job.
        /// </summary>
        public static BatchErrorCode JobPreparationTaskNotSpecified { get; } = new BatchErrorCode(JobPreparationTaskNotSpecifiedValue);

        /// <summary>
        /// Gets the error code indicating that a Job Release task was not run on a compute node.
        /// </summary>
        public static BatchErrorCode JobReleaseTaskNotRunOnNode { get; } = new BatchErrorCode(JobReleaseTaskNotRunOnNodeValue);

        /// <summary>
        /// Gets the error code indicating that no Job Release task was specified for the job.
        /// </summary>
        public static BatchErrorCode JobReleaseTaskNotSpecified { get; } = new BatchErrorCode(JobReleaseTaskNotSpecifiedValue);

        /// <summary>
        /// Gets the error code indicating that the specified job was not found in the Batch account.
        /// </summary>
        public static BatchErrorCode JobNotFound { get; } = new BatchErrorCode(JobNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that an I/O error occurred while accessing a resource.
        /// </summary>
        public static BatchErrorCode IOError { get; } = new BatchErrorCode(IOErrorValue);

        /// <summary>
        /// Gets the error code indicating that the operation is invalid for the current state of the resource.
        /// </summary>
        public static BatchErrorCode OperationInvalidForCurrentState { get; } = new BatchErrorCode(OperationInvalidForCurrentStateValue);

        /// <summary>
        /// Gets the error code indicating that the specified Azure Guest OS version is disabled.
        /// </summary>
        public static BatchErrorCode OSVersionDisabled { get; } = new BatchErrorCode(OSVersionDisabledValue);

        /// <summary>
        /// Gets the error code indicating that the specified Azure Guest OS version is expired.
        /// </summary>
        public static BatchErrorCode OSVersionExpired { get; } = new BatchErrorCode(OSVersionExpiredValue);

        /// <summary>
        /// Gets the error code indicating that the specified Azure Guest OS version was not found.
        /// </summary>
        public static BatchErrorCode OSVersionNotFound { get; } = new BatchErrorCode(OSVersionNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that a job priority is out of the permitted range.
        /// </summary>
        public static BatchErrorCode OutOfRangePriority { get; } = new BatchErrorCode(OutOfRangePriorityValue);

        /// <summary>
        /// Gets the error code indicating that a file path was not found on a compute node.
        /// </summary>
        public static BatchErrorCode PathNotFound { get; } = new BatchErrorCode(PathNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that a pool operation was attempted on a pool being deleted.
        /// </summary>
        public static BatchErrorCode PoolBeingDeleted { get; } = new BatchErrorCode(PoolBeingDeletedValue);

        /// <summary>
        /// Gets the error code indicating that a pool operation was attempted on a pool being resized.
        /// </summary>
        public static BatchErrorCode PoolBeingResized { get; } = new BatchErrorCode(PoolBeingResizedValue);

        /// <summary>
        /// Gets the error code indicating that a pool operation was attempted on a pool being created.
        /// </summary>
        public static BatchErrorCode PoolBeingCreated { get; } = new BatchErrorCode(PoolBeingCreatedValue);

        /// <summary>
        /// Gets the error code indicating that the specified pool already exists.
        /// </summary>
        public static BatchErrorCode PoolExists { get; } = new BatchErrorCode(PoolExistsValue);

        /// <summary>
        /// Gets the error code indicating that the specified pool is not eligible for an OS version upgrade.
        /// </summary>
        public static BatchErrorCode PoolNotEligibleForOSVersionUpgrade { get; } = new BatchErrorCode(PoolNotEligibleForOSVersionUpgradeValue);

        /// <summary>
        /// Gets the error code indicating that the specified pool was not found in the Batch account.
        /// </summary>
        public static BatchErrorCode PoolNotFound { get; } = new BatchErrorCode(PoolNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that the account has reached its pool quota.
        /// </summary>
        public static BatchErrorCode PoolQuotaReached { get; } = new BatchErrorCode(PoolQuotaReachedValue);

        /// <summary>
        /// Gets the error code indicating that the pool is already on the target OS version.
        /// </summary>
        public static BatchErrorCode PoolVersionEqualsUpgradeVersion { get; } = new BatchErrorCode(PoolVersionEqualsUpgradeVersionValue);

        /// <summary>
        /// Gets the error code indicating that the requested storage account was not found.
        /// </summary>
        public static BatchErrorCode StorageAccountNotFound { get; } = new BatchErrorCode(StorageAccountNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that a task operation was attempted on a completed task.
        /// </summary>
        public static BatchErrorCode TaskCompleted { get; } = new BatchErrorCode(TaskCompletedValue);

        /// <summary>
        /// Gets the error code indicating that task dependencies were not specified on the job.
        /// </summary>
        public static BatchErrorCode TaskDependenciesNotSpecifiedOnJob { get; } = new BatchErrorCode(TaskDependenciesNotSpecifiedOnJobValue);

        /// <summary>
        /// Gets the error code indicating that the task dependency list is too long.
        /// </summary>
        public static BatchErrorCode TaskDependencyListTooLong { get; } = new BatchErrorCode(TaskDependencyListTooLongValue);

        /// <summary>
        /// Gets the error code indicating that the task dependency ranges are too long.
        /// </summary>
        public static BatchErrorCode TaskDependencyRangesTooLong { get; } = new BatchErrorCode(TaskDependencyRangesTooLongValue);

        /// <summary>
        /// Gets the error code indicating that the node files for the task are unavailable.
        /// </summary>
        public static BatchErrorCode TaskFilesUnavailable { get; } = new BatchErrorCode(TaskFilesUnavailableValue);

        /// <summary>
        /// Gets the error code indicating that the task files have been cleaned up.
        /// </summary>
        public static BatchErrorCode TaskFilesCleanedup { get; } = new BatchErrorCode(TaskFilesCleanedupValue);

        /// <summary>
        /// Gets the error code indicating that the specified task already exists.
        /// </summary>
        public static BatchErrorCode TaskExists { get; } = new BatchErrorCode(TaskExistsValue);

        /// <summary>
        /// Gets the error code indicating that the task id is the same as that of the Job Preparation task.
        /// </summary>
        public static BatchErrorCode TaskIdSameAsJobPreparationTask { get; } = new BatchErrorCode(TaskIdSameAsJobPreparationTaskValue);

        /// <summary>
        /// Gets the error code indicating that the task id is the same as that of the Job Release task.
        /// </summary>
        public static BatchErrorCode TaskIdSameAsJobReleaseTask { get; } = new BatchErrorCode(TaskIdSameAsJobReleaseTaskValue);

        /// <summary>
        /// Gets the error code indicating that the specified task was not found.
        /// </summary>
        public static BatchErrorCode TaskNotFound { get; } = new BatchErrorCode(TaskNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that a compute node operation was attempted while the node is being created.
        /// </summary>
        public static BatchErrorCode NodeBeingCreated { get; } = new BatchErrorCode(NodeBeingCreatedValue);

        /// <summary>
        /// Gets the error code indicating that a compute node operation was attempted while the node is being started.
        /// </summary>
        public static BatchErrorCode NodeBeingStarted { get; } = new BatchErrorCode(NodeBeingStartedValue);

        /// <summary>
        /// Gets the error code indicating that a compute node operation was attempted while the node is being rebooted.
        /// </summary>
        public static BatchErrorCode NodeBeingRebooted { get; } = new BatchErrorCode(NodeBeingRebootedValue);

        /// <summary>
        /// Gets the error code indicating that a compute node operation was attempted while the node is being reimaged.
        /// </summary>
        public static BatchErrorCode NodeBeingReimaged { get; } = new BatchErrorCode(NodeBeingReimagedValue);

        /// <summary>
        /// Gets the error code indicating that the node counts do not match.
        /// </summary>
        public static BatchErrorCode NodeCountsMismatch { get; } = new BatchErrorCode(NodeCountsMismatchValue);

        /// <summary>
        /// Gets the error code indicating that the specified compute node was not found in the pool.
        /// </summary>
        public static BatchErrorCode NodeNotFound { get; } = new BatchErrorCode(NodeNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that a compute node operation was attempted on a node in an unusable state.
        /// </summary>
        public static BatchErrorCode NodeStateUnusable { get; } = new BatchErrorCode(NodeStateUnusableValue);

        /// <summary>
        /// Gets the error code indicating that the specified compute node user already exists.
        /// </summary>
        public static BatchErrorCode NodeUserExists { get; } = new BatchErrorCode(NodeUserExistsValue);

        /// <summary>
        /// Gets the error code indicating that the specified compute node user was not found.
        /// </summary>
        public static BatchErrorCode NodeUserNotFound { get; } = new BatchErrorCode(NodeUserNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that the compute node is already in the target scheduling state.
        /// </summary>
        public static BatchErrorCode NodeAlreadyInTargetSchedulingState { get; } = new BatchErrorCode(NodeAlreadyInTargetSchedulingStateValue);

        /// <summary>
        /// Gets the error code indicating that the requested job or task constraint is not supported.
        /// </summary>
        public static BatchErrorCode UnsupportedConstraint { get; } = new BatchErrorCode(UnsupportedConstraintValue);

        /// <summary>
        /// Gets the error code indicating that the specified version of the Batch REST API is not supported.
        /// </summary>
        public static BatchErrorCode UnsupportedRequestVersion { get; } = new BatchErrorCode(UnsupportedRequestVersionValue);

        /// <summary>
        /// Gets the error code indicating that a job schedule operation was attempted on a schedule being deleted.
        /// </summary>
        public static BatchErrorCode JobScheduleBeingDeleted { get; } = new BatchErrorCode(JobScheduleBeingDeletedValue);

        /// <summary>
        /// Gets the error code indicating that a job schedule operation was attempted on a schedule being terminated.
        /// </summary>
        public static BatchErrorCode JobScheduleBeingTerminated { get; } = new BatchErrorCode(JobScheduleBeingTerminatedValue);

        /// <summary>
        /// Gets the error code indicating that a job schedule operation was attempted on a completed schedule.
        /// </summary>
        public static BatchErrorCode JobScheduleCompleted { get; } = new BatchErrorCode(JobScheduleCompletedValue);

        /// <summary>
        /// Gets the error code indicating that a job schedule operation was attempted on a disabled schedule.
        /// </summary>
        public static BatchErrorCode JobScheduleDisabled { get; } = new BatchErrorCode(JobScheduleDisabledValue);

        /// <summary>
        /// Gets the error code indicating that the specified job schedule already exists.
        /// </summary>
        public static BatchErrorCode JobScheduleExists { get; } = new BatchErrorCode(JobScheduleExistsValue);

        /// <summary>
        /// Gets the error code indicating that the specified job schedule was not found.
        /// </summary>
        public static BatchErrorCode JobScheduleNotFound { get; } = new BatchErrorCode(JobScheduleNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that the specified job is disabled.
        /// </summary>
        public static BatchErrorCode JobDisabled { get; } = new BatchErrorCode(JobDisabledValue);

        /// <summary>
        /// Gets the error code indicating that a job with the same id as an existing job schedule exists.
        /// </summary>
        public static BatchErrorCode JobWithSameIdExists { get; } = new BatchErrorCode(JobWithSameIdExistsValue);

        /// <summary>
        /// Gets the error code indicating that a job schedule with the same id as an existing job exists.
        /// </summary>
        public static BatchErrorCode JobScheduleWithSameIdExists { get; } = new BatchErrorCode(JobScheduleWithSameIdExistsValue);

        /// <summary>
        /// Gets the error code indicating that the Batch service failed to authenticate the request.
        /// </summary>
        public static BatchErrorCode AuthenticationFailed { get; } = new BatchErrorCode(AuthenticationFailedValue);

        /// <summary>
        /// Gets the error code indicating that a HTTP conditional header did not meet its condition.
        /// </summary>
        public static BatchErrorCode ConditionNotMet { get; } = new BatchErrorCode(ConditionNotMetValue);

        /// <summary>
        /// Gets the error code indicating that an empty metadata key was specified.
        /// </summary>
        public static BatchErrorCode EmptyMetadataKey { get; } = new BatchErrorCode(EmptyMetadataKeyValue);

        /// <summary>
        /// Gets the error code indicating that the host information was not present in the request.
        /// </summary>
        public static BatchErrorCode HostInformationNotPresent { get; } = new BatchErrorCode(HostInformationNotPresentValue);

        /// <summary>
        /// Gets the error code indicating that the account lacks sufficient permissions.
        /// </summary>
        public static BatchErrorCode InsufficientAccountPermissions { get; } = new BatchErrorCode(InsufficientAccountPermissionsValue);

        /// <summary>
        /// Gets the error code indicating that an internal error occurred in the Batch service.
        /// </summary>
        public static BatchErrorCode InternalError { get; } = new BatchErrorCode(InternalErrorValue);

        /// <summary>
        /// Gets the error code indicating that the authentication information is invalid.
        /// </summary>
        public static BatchErrorCode InvalidAuthenticationInfo { get; } = new BatchErrorCode(InvalidAuthenticationInfoValue);

        /// <summary>
        /// Gets the error code indicating that the specified auto-scale settings are invalid.
        /// </summary>
        public static BatchErrorCode InvalidAutoScalingSettings { get; } = new BatchErrorCode(InvalidAutoScalingSettingsValue);

        /// <summary>
        /// Gets the error code indicating that one of the HTTP headers has an incorrect format.
        /// </summary>
        public static BatchErrorCode InvalidHeaderValue { get; } = new BatchErrorCode(InvalidHeaderValueValue);

        /// <summary>
        /// Gets the error code indicating that the HTTP verb is not recognised.
        /// </summary>
        public static BatchErrorCode InvalidHttpVerb { get; } = new BatchErrorCode(InvalidHttpVerbValue);

        /// <summary>
        /// Gets the error code indicating that one of the request inputs is invalid.
        /// </summary>
        public static BatchErrorCode InvalidInput { get; } = new BatchErrorCode(InvalidInputValue);

        /// <summary>
        /// Gets the error code indicating that the metadata contains invalid characters.
        /// </summary>
        public static BatchErrorCode InvalidMetadata { get; } = new BatchErrorCode(InvalidMetadataValue);

        /// <summary>
        /// Gets the error code indicating that a property value in the request body is invalid.
        /// </summary>
        public static BatchErrorCode InvalidPropertyValue { get; } = new BatchErrorCode(InvalidPropertyValueValue);

        /// <summary>
        /// Gets the error code indicating that the HTTP request body is not valid.
        /// </summary>
        public static BatchErrorCode InvalidRequestBody { get; } = new BatchErrorCode(InvalidRequestBodyValue);

        /// <summary>
        /// Gets the error code indicating that a query parameter has an invalid value.
        /// </summary>
        public static BatchErrorCode InvalidQueryParameterValue { get; } = new BatchErrorCode(InvalidQueryParameterValueValue);

        /// <summary>
        /// Gets the error code indicating that the specified byte range is invalid.
        /// </summary>
        public static BatchErrorCode InvalidRange { get; } = new BatchErrorCode(InvalidRangeValue);

        /// <summary>
        /// Gets the error code indicating that the HTTP request URI is invalid.
        /// </summary>
        public static BatchErrorCode InvalidUri { get; } = new BatchErrorCode(InvalidUriValue);

        /// <summary>
        /// Gets the error code indicating that the metadata size exceeds the maximum allowed.
        /// </summary>
        public static BatchErrorCode MetadataTooLarge { get; } = new BatchErrorCode(MetadataTooLargeValue);

        /// <summary>
        /// Gets the error code indicating that the HTTP Content-Length header was not specified.
        /// </summary>
        public static BatchErrorCode MissingContentLengthHeader { get; } = new BatchErrorCode(MissingContentLengthHeaderValue);

        /// <summary>
        /// Gets the error code indicating that a required HTTP header was not specified.
        /// </summary>
        public static BatchErrorCode MissingRequiredHeader { get; } = new BatchErrorCode(MissingRequiredHeaderValue);

        /// <summary>
        /// Gets the error code indicating that a required property was not specified in the request body.
        /// </summary>
        public static BatchErrorCode MissingRequiredProperty { get; } = new BatchErrorCode(MissingRequiredPropertyValue);

        /// <summary>
        /// Gets the error code indicating that a required query parameter was not specified.
        /// </summary>
        public static BatchErrorCode MissingRequiredQueryParameter { get; } = new BatchErrorCode(MissingRequiredQueryParameterValue);

        /// <summary>
        /// Gets the error code indicating that multiple conditional headers were provided.
        /// </summary>
        public static BatchErrorCode MultipleConditionHeadersNotSupported { get; } = new BatchErrorCode(MultipleConditionHeadersNotSupportedValue);

        /// <summary>
        /// Gets the error code indicating that the operation is not implemented.
        /// </summary>
        public static BatchErrorCode NotImplemented { get; } = new BatchErrorCode(NotImplementedValue);

        /// <summary>
        /// Gets the error code indicating that one of the inputs is out of range.
        /// </summary>
        public static BatchErrorCode OutOfRangeInput { get; } = new BatchErrorCode(OutOfRangeInputValue);

        /// <summary>
        /// Gets the error code indicating that a query parameter is out of range.
        /// </summary>
        public static BatchErrorCode OutOfRangeQueryParameterValue { get; } = new BatchErrorCode(OutOfRangeQueryParameterValueValue);

        /// <summary>
        /// Gets the error code indicating that the operation timed out.
        /// </summary>
        public static BatchErrorCode OperationTimedOut { get; } = new BatchErrorCode(OperationTimedOutValue);

        /// <summary>
        /// Gets the error code indicating that the request body is too large.
        /// </summary>
        public static BatchErrorCode RequestBodyTooLarge { get; } = new BatchErrorCode(RequestBodyTooLargeValue);

        /// <summary>
        /// Gets the error code indicating that the request URL could not be parsed.
        /// </summary>
        public static BatchErrorCode RequestUrlFailedToParse { get; } = new BatchErrorCode(RequestUrlFailedToParseValue);

        /// <summary>
        /// Gets the error code indicating that the specified resource was not found.
        /// </summary>
        public static BatchErrorCode ResourceNotFound { get; } = new BatchErrorCode(ResourceNotFoundValue);

        /// <summary>
        /// Gets the error code indicating that the specified resource already exists.
        /// </summary>
        public static BatchErrorCode ResourceAlreadyExists { get; } = new BatchErrorCode(ResourceAlreadyExistsValue);

        /// <summary>
        /// Gets the error code indicating that the resource type does not match the expected type.
        /// </summary>
        public static BatchErrorCode ResourceTypeMismatch { get; } = new BatchErrorCode(ResourceTypeMismatchValue);

        /// <summary>
        /// Gets the error code indicating that the Batch service is busy.
        /// </summary>
        public static BatchErrorCode ServerBusy { get; } = new BatchErrorCode(ServerBusyValue);

        /// <summary>
        /// Gets the error code indicating that an HTTP header is not supported.
        /// </summary>
        public static BatchErrorCode UnsupportedHeader { get; } = new BatchErrorCode(UnsupportedHeaderValue);

        /// <summary>
        /// Gets the error code indicating that the HTTP verb is not supported by the resource.
        /// </summary>
        public static BatchErrorCode UnsupportedHttpVerb { get; } = new BatchErrorCode(UnsupportedHttpVerbValue);

        /// <summary>
        /// Gets the error code indicating that the HTTP version is not supported.
        /// </summary>
        public static BatchErrorCode UnsupportedHttpVersion { get; } = new BatchErrorCode(UnsupportedHttpVersionValue);

        /// <summary>
        /// Gets the error code indicating that the specified property is not supported.
        /// </summary>
        public static BatchErrorCode UnsupportedProperty { get; } = new BatchErrorCode(UnsupportedPropertyValue);

        /// <summary>
        /// Gets the error code indicating that the query parameter is not supported.
        /// </summary>
        public static BatchErrorCode UnsupportedQueryParameter { get; } = new BatchErrorCode(UnsupportedQueryParameterValue);

        /// <summary>
        /// Gets the error code indicating that the task addition failed.
        /// </summary>
        public static BatchErrorCode AddTaskCollectionTerminated { get; } = new BatchErrorCode(AddTaskCollectionTerminatedValue);

        /// <summary>
        /// Gets the error code indicating that one or more parallel requests encountered unexpected errors.
        /// </summary>
        public static BatchErrorCode MultipleParallelRequestsHitUnexpectedErrors { get; } = new BatchErrorCode(MultipleParallelRequestsHitUnexpectedErrorsValue);

        /// <summary>
        /// Gets the error code indicating that the operation can only be run once.
        /// </summary>
        public static BatchErrorCode CanOnlyBeRunOnceFailure { get; } = new BatchErrorCode(CanOnlyBeRunOnceFailureValue);

        /// <summary>
        /// Determines if two <see cref="BatchErrorCode"/> values are the same.
        /// </summary>
        public static bool operator ==(BatchErrorCode left, BatchErrorCode right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="BatchErrorCode"/> values are not the same.
        /// </summary>
        public static bool operator !=(BatchErrorCode left, BatchErrorCode right) => !left.Equals(right);

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="BatchErrorCode"/>.
        /// </summary>
        public static implicit operator BatchErrorCode(string value) => new BatchErrorCode(value);

        /// <summary>
        /// BatchErrorCode Comparison
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if equals, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BatchErrorCode other && Equals(other);

        /// <summary>
        /// BatchErrorCode string Comparison
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if equals, false otherwise</returns>
        public bool Equals(BatchErrorCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// BatchErrorCode Comparison
        /// </summary>
        /// <returns>true if not equals, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <summary>
        /// String value of Error Code
        /// </summary>
        /// <returns>string value</returns>
        public override string ToString() => _value;
    }
}
