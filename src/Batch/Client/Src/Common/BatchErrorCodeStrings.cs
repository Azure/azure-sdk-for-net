// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿// -----------------------------------------------------------------------------------------
// <copyright file="BatchErrorCodeStrings.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------
namespace Microsoft.Azure.Batch.Common
{ 
    //TODO: Auto-generate this file?
    /// <summary>
    /// Error code strings from Batch service.
    /// </summary>
    public static class BatchErrorCodeStrings
    {
        // Batch Service

        /// <summary>
        /// The specified account is disabled.
        /// </summary>
        public const string AccountIsDisabled = "AccountIsDisabled";

        /// <summary>
        /// The account has reached its quota of active jobs and job schedules.
        /// </summary>
        public const string ActiveJobAndScheduleQuotaReached = "ActiveJobAndScheduleQuotaReached";
        
        /// <summary>
        /// The specified application does not exist.
        /// </summary>
        public const string ApplicationNotFound  = "ApplicationNotFound";

        /// <summary>
        /// An automatic scaling formula has a syntax error.
        /// </summary>
        public const string AutoScalingFormulaSyntaxError = "AutoScalingFormulaSyntaxError";

        /// <summary>
        /// An automatic scaling formula is too long. The maximum length is 8192 characters.
        /// </summary>
        public const string AutoScaleFormulaTooLong = "AutoScaleFormulaTooLong";

        /// <summary>
        /// Enable AutoScale requests for the same pool must be separated by at least 30 seconds. 
        /// </summary>
        public const string AutoScaleTooManyRequestsToEnable = "TooManyEnableAutoScaleRequests";

        /// <summary>
        /// A certificate operation was attempted which is not permitted when the certificate is in the process of being deleted.
        /// </summary>
        public const string CertificateBeingDeleted = "CertificateBeingDeleted";

        /// <summary>
        /// The certificate you are attempting to add already exists.
        /// </summary>
        public const string CertificateExists = "CertificateExists";

        /// <summary>
        /// The certificate on which an operation was attempted is not present in the Batch account.
        /// </summary>
        public const string CertificateNotFound = "CertificateNotFound";

        /// <summary>
        /// A certificate operation was attempted which is not permitted when the certificate is active.
        /// </summary>
        public const string CertificateStateActive = "CertificateStateActive";

        /// <summary>
        /// A certificate could not be deleted because it is still in use.
        /// </summary>
        public const string CertificateStateDeleteFailed = "CertificateDeleteFailed";

        /// <summary>
        /// A node file requested from a task or compute node was not found.
        /// </summary>
        public const string FileNotFound = "FileNotFound";

        /// <summary>
        /// One or more application package references could not be satisfied. This occurs if the application 
        /// id or version does not exist or is not active, or if the reference did not specify a version and 
        /// there is no default version configured.
        /// </summary>
        public const string InvalidApplicationPackageReferences = "InvalidApplicationPackageReferences";

        /// <summary>
        /// A pool specification specifies one or more invalid certificates (for example, certificates that are
        /// not present in the Batch account).
        /// </summary>
        public const string InvalidCertificateReferences = "InvalidCertificateReferences";

        /// <summary>
        /// A value in a job or task constraint is out of range.
        /// </summary>
        public const string InvalidConstraintValue = "InvalidConstraintValue";

        // TODO: get real words instead of weasel words
        /// <summary>
        /// There is a conflict between the REST API being used and the account.
        /// </summary>
        public const string InvalidRestAPIForAccountSetting = "InvalidRestAPIForAccountSetting";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job is in the process of being deleted.
        /// </summary>
        public const string JobBeingDeleted = "JobBeingDeleted";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job is in the process of being terminated.
        /// </summary>
        public const string JobBeingTerminated = "JobBeingTerminated";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job has been completed.
        /// </summary>
        public const string JobCompleted = "JobCompleted";

        /// <summary>
        /// A job operation was attempted which is not permitted when the job is not active.
        /// </summary>
        public const string JobNotActive = "JobNotActive";

        /// <summary>
        /// The specified job exists.
        /// </summary>
        public const string JobExists = "JobExists";

        /// <summary>
        /// A Job Preparation task was not run on a compute node.
        /// </summary>
        public const string JobPreparationTaskNotRunOnNode = "JobPreparationTaskNotRunOnNode";

        /// <summary>
        /// The specified job does not have a Job Preparation task.
        /// </summary>
        public const string JobPreparationTaskNotSpecified = "JobPreparationTaskNotSpecified";

        /// <summary>
        /// A Job Release task was not run on a compute node.
        /// </summary>
        public const string JobReleaseTaskNotRunOnNode = "JobReleaseTaskNotRunOnNode";

        /// <summary>
        /// The specified job does not have a Job Release task.
        /// </summary>
        public const string JobReleaseTaskNotSpecified = "JobReleaseTaskNotSpecified";

        /// <summary>
        /// The job on which an operation was attempted is not present in the Batch account.
        /// </summary>
        public const string JobNotFound = "JobNotFound";

        /// <summary>
        /// An I/O error occurred while trying to access a resource within the Batch account.
        /// </summary>
        public const string IOError = "IOError";

        /// <summary>
        /// The specified operation is not valid for the current state of the resource.
        /// </summary>
        public const string OperationInvalidForCurrentState = "OperationInvalidForCurrentState";

        /// <summary>
        /// The specified Azure Guest OS version is disabled.
        /// </summary>
        public const string OSVersionDisabled = "OSVersionDisabled";

        /// <summary>
        /// The specified Azure Guest OS version is expired.
        /// </summary>
        public const string OSVersionExpired = "OSVersionExpired";

        /// <summary>
        /// The specified Azure Guest OS version was not found.
        /// </summary>
        public const string OSVersionNotFound = "OSVersionNotFound";

        /// <summary>
        /// A job priority was specified which was outside the permitted range of -1000 to 1000.
        /// </summary>
        public const string OutOfRangePriority = "OutOfRangePriority";

        // TODO: confirm - guess this could also indicate a URL error?
        /// <summary>
        /// A file path was not found on a compute node.
        /// </summary>
        public const string PathNotFound = "PathNotFound";

        /// <summary>
        /// A pool operation was attempted which is not permitted when the pool is in the process of being deleted.
        /// </summary>
        public const string PoolBeingDeleted = "PoolBeingDeleted";

        /// <summary>
        /// A pool operation was attempted which is not permitted when the pool is in the process of being resized.
        /// </summary>
        public const string PoolBeingResized = "PoolBeingResized";

        /// <summary>
        /// A pool operation was attempted which is not permitted when the pool is in the process of being created.
        /// </summary>
        public const string PoolBeingCreated = "PoolBeingCreated";

        /// <summary>
        /// The pool you are attempting to add already exists.
        /// </summary>
        public const string PoolExists = "PoolExists";

        /// <summary>
        /// The specified pool is not eligible for an operating system version upgrade.
        /// </summary>
        public const string PoolNotEligibleForOSVersionUpgrade = "PoolNotEligibleForOSVersionUpgrade";

        /// <summary>
        /// The pool on which an operation was attempted is not present in the Batch account.
        /// </summary>
        public const string PoolNotFound = "PoolNotFound";

        /// <summary>
        /// The account has reached its quota of pools.
        /// </summary>
        public const string PoolQuotaReached = "PoolQuotaReached";

        /// <summary>
        /// The pool is already on the operating system version to which it was asked to upgrade.
        /// </summary>
        public const string PoolVersionEqualsUpgradeVersion = "PoolVersionEqualsUpgradeVersion";

        // TODO: unweasel
        /// <summary>
        /// A requested storage account was not found.
        /// </summary>
        public const string StorageAccountNotFound = "StorageAccountNotFound";

        /// <summary>
        /// A task operation was attempted which is not permitted when the task has been completed.
        /// </summary>
        public const string TaskCompleted = "TaskCompleted";

        /// <summary>
        /// A task was specified as depending on other tasks, but the job did not specify that it would use task dependencies.
        /// </summary>
        public const string TaskDependenciesNotSpecifiedOnJob = "TaskDependenciesNotSpecifiedOnJob";

        /// <summary>
        /// A task was specified as depending on other tasks, but the list of dependencies was too long to be stored.
        /// </summary>
        public const string TaskDependencyListTooLong = "TaskDependencyListTooLong";

        /// <summary>
        /// A task was specified as depending on other tasks, but the list of task id ranges was too long to be stored.
        /// </summary>
        public const string TaskDependencyRangesTooLong = "TaskDependencyRangesTooLong";

        /// <summary>
        /// The node files for a task are not available, for example because the retention period has expired.
        /// </summary>
        public const string TaskFilesUnavailable = "TaskFilesUnavailable";

        /// <summary>
        /// The files of the specified task are cleaned up.
        /// </summary>
        public const string TaskFilesCleanedup = "TaskFilesCleanedup";

        /// <summary>
        /// The task you are attempting to add already exists.
        /// </summary>
        public const string TaskExists = "TaskExists";

        /// <summary>
        /// The task id is the same as that of the Job Preparation task.
        /// </summary>
        public const string TaskIdSameAsJobPreparationTask = "TaskIdSameAsJobPreparationTask";

        /// <summary>
        /// The task id is the same as that of the Job Release task.
        /// </summary>
        public const string TaskIdSameAsJobReleaseTask = "TaskIdSameAsJobReleaseTask";

        /// <summary>
        /// The task on which an operation was attempted is not present in the job.
        /// </summary>
        public const string TaskNotFound = "TaskNotFound";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being created.
        /// </summary>
        public const string NodeBeingCreated = "NodeBeingCreated";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being started.
        /// </summary>
        public const string NodeBeingStarted = "NodeBeingStarted";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being rebooted.
        /// </summary>
        public const string NodeBeingRebooted = "NodeBeingRebooted";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is in the process of being reimaged.
        /// </summary>
        public const string NodeBeingReimaged = "NodeBeingReimaged";

        // TODO: unweasel
        /// <summary>
        /// The node counts do not match.
        /// </summary>
        public const string NodeCountsMismatch = "NodeCountsMismatch";  // TODO: substantiate this

        /// <summary>
        /// The compute node on which an operation was attempted is not present in the given pool.
        /// </summary>
        public const string NodeNotFound = "NodeNotFound";

        /// <summary>
        /// A compute node operation was attempted which is not permitted when the node is unusable.
        /// </summary>
        public const string NodeStateUnusable = "NodeStateUnusable";

        /// <summary>
        /// The compute node user account you are attempting to add already exists.
        /// </summary>
        public const string NodeUserExists = "NodeUserExists";

        /// <summary>
        /// The compute node user account on which an operation was attempted does not exist.
        /// </summary>
        public const string NodeUserNotFound = "NodeUserNotFound";

        /// <summary>
        /// The specified compute node is already in the target scheduling state.
        /// </summary>
        public const string NodeAlreadyInTargetSchedulingState = "NodeAlreadyInTargetSchedulingState";

        /// <summary>
        /// The pool is already upgrading to a different operating system version.
        /// </summary>
        public const string UpgradePoolVersionConflict = "UpgradePoolVersionConflict";

        // TODO: unweasel
        /// <summary>
        /// A requested job or task constraint is not supported.
        /// </summary>
        public const string UnsupportedConstraint = "UnsupportedConstraint";

        /// <summary>
        /// The specified version of the Batch REST API is not supported.
        /// </summary>
        public const string UnsupportedRequestVersion = "UnsupportedRequestVersion";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule is in the process of being deleted.
        /// </summary>
        public const string JobScheduleBeingDeleted = "JobScheduleBeingDeleted";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule is in the process of being terminated.
        /// </summary>
        public const string JobScheduleBeingTerminated = "JobScheduleBeingTerminated";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule has completed.
        /// </summary>
        public const string JobScheduleCompleted = "JobScheduleCompleted";

        /// <summary>
        /// A job schedule operation was attempted which is not permitted when the schedule is disabled.
        /// </summary>
        public const string JobScheduleDisabled = "JobScheduleDisabled";

        /// <summary>
        /// The job schedule you are attempting to add already exists in the Batch account.
        /// </summary>
        public const string JobScheduleExists = "JobScheduleExists";

        /// <summary>
        /// The job schedule on which an operation was attempted does not exist.
        /// </summary>
        public const string JobScheduleNotFound = "JobScheduleNotFound";

        /// <summary>
        /// The specified job is disabled.
        /// </summary>
        public const string JobDisabled = "JobDisabled";

        /// <summary>
        /// A job with the specified job schedule id exists. Job and job schedule cannot have the same id.
        /// </summary>
        public const string JobWithSameIdExists = "JobWithSameIdExists";

        /// <summary>
        /// A job schedule with the specified job id exists. Job and job schedule cannot have the same id.
        /// </summary>
        public const string JobScheduleWithSameIdExists = "JobScheduleWithSameIdExists";

        // General

        /// <summary>
        /// The Batch service failed to authenticate the request.
        /// </summary>
        public const string AuthenticationFailed = "AuthenticationFailed";

        /// <summary>
        /// A read operation included a HTTP conditional header, and the condition was not met.
        /// </summary>
        public const string ConditionNotMet = "ConditionNotMet";

        /// <summary>
        /// An add or update request specified a metadata item whose key is an empty string.
        /// </summary>
        public const string EmptyMetadataKey = "EmptyMetadataKey";

        /// <summary>
        /// The host information was missing from the HTTP request.
        /// </summary>
        public const string HostInformationNotPresent = "HostInformationNotPresent";

        /// <summary>
        /// The account being accessed does not have sufficient permissions to execute this operation.
        /// </summary>
        public const string InsufficientAccountPermissions = "InsufficientAccountPermissions";

        /// <summary>
        /// An internal error occurred in the Batch service.
        /// </summary>
        public const string InternalError = "InternalError";

        /// <summary>
        /// The authentication credentials were not provided in the correct format.
        /// </summary>
        public const string InvalidAuthenticationInfo = "InvalidAuthenticationInfo";

        /// <summary>
        /// The specified auto-scale settings are not valid.
        /// </summary>
        public const string InvalidAutoScalingSettings = "InvalidAutoScalingSettings";

        /// <summary>
        /// The value of one of the HTTP headers was in an incorrect format.
        /// </summary>
        public const string InvalidHeaderValue = "InvalidHeaderValue";

        /// <summary>
        /// The Batch service did not recognise the HTTP verb.
        /// </summary>
        public const string InvalidHttpVerb = "InvalidHttpVerb";

        /// <summary>
        /// One of the request inputs is not valid.
        /// </summary>
        public const string InvalidInput = "InvalidInput";

        /// <summary>
        /// An add or update request specified a metadata item which contains characters that are not permitted.
        /// </summary>
        public const string InvalidMetadata = "InvalidMetadata";

        /// <summary>
        /// The value of a property in the HTTP request body is invalid.
        /// </summary>
        public const string InvalidPropertyValue = "InvalidPropertyValue";

        /// <summary>
        /// The HTTP request body is not syntactically valid.
        /// </summary>
        public const string InvalidRequestBody = "InvalidRequestBody";

        /// <summary>
        /// The HTTP request URI contained invalid value for one of the query parameters.
        /// </summary>
        public const string InvalidQueryParameterValue = "InvalidQueryParameterValue";

        /// <summary>
        /// The specified byte range is invalid for the given resource.
        /// </summary>
        public const string InvalidRange = "InvalidRange";

        /// <summary>
        /// The HTTP request URI was invalid.
        /// </summary>
        public const string InvalidUri = "InvalidUri";

        /// <summary>
        /// The size of the metadata exceeds the maximum permitted.
        /// </summary>
        public const string MetadataTooLarge = "MetadataTooLarge";

        /// <summary>
        /// The HTTP Content-Length header was not specified.
        /// </summary>
        public const string MissingContentLengthHeader = "MissingContentLengthHeader";

        /// <summary>
        /// A required HTTP header was not specified.
        /// </summary>
        public const string MissingRequiredHeader = "MissingRequiredHeader";

        /// <summary>
        /// A required property was not specified in the HTTP request body.
        /// </summary>
        public const string MissingRequiredProperty = "MissingRequiredProperty";

        /// <summary>
        /// A required query parameter was not specified in the URL.
        /// </summary>
        public const string MissingRequiredQueryParameter = "MissingRequiredQueryParameter";

        /// <summary>
        /// Multiple condition headers are not supported.
        /// </summary>
        public const string MultipleConditionHeadersNotSupported = "MultipleConditionHeadersNotSupported";

        /// <summary>
        /// The operation is not implemented.
        /// </summary>
        public const string NotImplemented = "NotImplemented";

        /// <summary>
        /// One of the request inputs is out of range.
        /// </summary>
        public const string OutOfRangeInput = "OutOfRangeInput";

        /// <summary>
        /// A query parameter in the request URL is out of range.
        /// </summary>
        public const string OutOfRangeQueryParameterValue = "OutOfRangeQueryParameterValue";

        /// <summary>
        /// The operation could not be completed within the permitted time.
        /// </summary>
        public const string OperationTimedOut = "OperationTimedOut";

        /// <summary>
        /// The size of the HTTP request body exceeds the maximum permitted.
        /// </summary>
        public const string RequestBodyTooLarge = "RequestBodyTooLarge";

        /// <summary>
        /// The Batch service could not parse the request URL.
        /// </summary>
        public const string RequestUrlFailedToParse = "RequestUrlFailedToParse";
        
        /// <summary>
        /// The specified resource does not exist.
        /// </summary>
        public const string ResourceNotFound = "ResourceNotFound";

        /// <summary>
        /// The specified resource already exists.
        /// </summary>
        public const string ResourceAlreadyExists = "ResourceAlreadyExists";

        // TODO: unweasel
        /// <summary>
        /// The resource does not match the expected type.
        /// </summary>
        public const string ResourceTypeMismatch = "ResourceTypeMismatch";

        /// <summary>
        /// The Batch service is currently unable to receive requests.
        /// </summary>
        public const string ServerBusy = "ServerBusy";

        /// <summary>
        /// One of the HTTP headers specified in the request is not supported.
        /// </summary>
        public const string UnsupportedHeader = "UnsupportedHeader";

        /// <summary>
        /// The resource does not support the specified HTTP verb.
        /// </summary>
        public const string UnsupportedHttpVerb = "UnsupportedHttpVerb";

        /// <summary>
        /// The Batch service does not support the specified version of the HTTP protocol.
        /// </summary>
        public const string UnsupportedHttpVersion = "UnsupportedHttpVersion";

        /// <summary>
        /// One of the properties specified in the HTTP request body is not supported.
        /// </summary>
        public const string UnsupportedProperty = "UnsupportedProperty";

        /// <summary>
        /// One of the query parameters specified in the URL is not supported.
        /// </summary>
        public const string UnsupportedQueryParameter = "UnsupportedQueryParameter";
    }

    /// <summary>
    /// Contains error codes specific to pool resize errors.
    /// </summary>
    public static class PoolResizeErrorCodes
    {
        /// <summary>
        /// The account has reached its quota of compute nodes.
        /// </summary>
        public const string AccountCoreQuotaReached = "AccountCoreQuotaReached";

        /// <summary>
        /// An error occurred while trying to allocate the desired number of compute nodes.
        /// </summary>
        public const string AllocationFailed = "AllocationFailed";

        /// <summary>
        /// The Batch service was unable to allocate the desired number of compute nodes within the resize timeout.
        /// </summary>
        public const string AllocationTimedout= "AllocationTimedout";

        /// <summary>
        /// An error occurred when removing compute nodes from the pool.
        /// </summary>
        public const string RemoveNodesFailed = "RemoveNodesFailed";

        /// <summary>
        /// The user stopped the resize operation.
        /// </summary>
        public const string ResizeStopped = "ResizeStopped";

        /// <summary>
        /// The reason for the failure is not known.
        /// </summary>
        public const string Unknown = "Unknown";
    }

    /// <summary>
    /// Contains error codes specific to job scheduling errors.
    /// </summary>
    public static class JobSchedulingErrorCodes
    {
        /// <summary>
        /// The Batch service could not create an auto pool to run the job on, because the account
        /// has reached its quota of compute nodes.
        /// </summary>
        public const string AutoPoolCreationFailedWithQuotaReached = "AutoPoolCreationFailedWithQuotaReached";
        
        /// <summary>
        /// The auto pool specification for the job has one or more application package references which could not be satisfied.  
        /// This occurs if the application id or version does not exist or is not active, or if the reference did not specify a
        /// version and there is no default version configured.
        /// </summary>
        public const string InvalidApplicationPackageReferencesInAutoPool = "InvalidApplicationPackageReferencesInAutoPool";

        /// <summary>
        /// The auto pool specification for the job has an invalid automatic scaling formula.
        /// </summary>
        public const string InvalidAutoScaleFormulaInAutoPool = "InvalidAutoScaleFormulaInAutoPool";

        /// <summary>
        /// The auto pool specification for the job has an invalid certificate reference (for example, to a
        /// certificate that does not exist).
        /// </summary>
        public const string InvalidCertificatesInAutoPool = "InvalidCertificatesInAutoPool";

        /// <summary>
        /// The reason for the scheduling error is unknown.
        /// </summary>
        public const string Unknown = "Unknown";
    }

    /// <summary>
    /// Contains error codes specific to task scheduling errors.
    /// </summary>
    public static class TaskSchedulingErrorCodes
    {
        /// <summary>
        /// An error occurred when trying to deploy a required application package.
        /// </summary>
        public const string ApplicationPackageError = "ApplicationPackageError";

        /// <summary>
        /// Access was denied when trying to download a resource file required for the task.
        /// </summary>
        public const string BlobAccessDenied = "BlobAccessDenied";

        /// <summary>
        /// An error occurred when trying to download a resource file required for the task.
        /// </summary>
        public const string BlobDownloadMiscError = "BlobDownloadMiscError";

        /// <summary>
        /// A timeout occurred when downloading a resource file required for the task.
        /// </summary>
        public const string BlobDownloadTimedOut = "BlobDownloadTimedOut";

        /// <summary>
        /// A resource file required for the task does not exist.
        /// </summary>
        public const string BlobNotFound = "BlobNotFound";

        /// <summary>
        /// An error occurred when launching the task's command line.
        /// </summary>
        public const string CommandLaunchFailed = "CommandLaunchFailed";

        /// <summary>
        /// The program specified in the task's command line was not found.
        /// </summary>
        public const string CommandProgramNotFound = "CommandProgramNotFound";

        /// <summary>
        /// The compute node disk ran out of space when downloading the resource files required for the task.
        /// </summary>
        public const string DiskFull = "DiskFull";

        /// <summary>
        /// The compute node could not create a directory for the task's resource files.
        /// </summary>
        public const string ResourceDirectoryCreateFailed = "ResourceDirectoryCreateFailed";

        /// <summary>
        /// The compute node could not create a local file when trying to download a resource file required for the task.
        /// </summary>
        public const string ResourceFileCreateFailed = "ResourceFileCreateFailed";

        /// <summary>
        /// The compute node could not write to a local file when trying to download a resource file required for the task.
        /// </summary>
        public const string ResourceFileWriteFailed = "ResourceFileWriteFailed";

        /// <summary>
        /// The task ended.
        /// </summary>
        public const string TaskEnded = "TaskEnded";

        /// <summary>
        /// The reason for the scheduling error is unknown.
        /// </summary>
        public const string Unknown = "Unknown";
    }

}
