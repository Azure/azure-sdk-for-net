// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>Provides extension methods for the <see cref="StorageException"/> class.</summary>
    internal static class StorageExceptionExtensions
    {
        public static bool IsServerSideError(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            int statusCode = result.HttpStatusCode;
            return statusCode >= 500 && statusCode < 600;
        }

        /// <summary>
        /// Determines whether the exception is due to a 400 Bad Request error with the error code PopReceiptMismatch.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 400 Bad Request error with the error code
        /// PopReceiptMismatch; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsBadRequestPopReceiptMismatch(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 400)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "PopReceiptMismatch";
        }

        /// <summary>Determines whether the exception is due to a 409 Conflict error.</summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflict(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            return result.HttpStatusCode == 409;
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code BlobAlreadyExists.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code
        /// BlobAlreadyExists; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictBlobAlreadyExists(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 409)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "BlobAlreadyExists";
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code LeaseAlreadyPresent.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code
        /// LeaseAlreadyPresent; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictLeaseAlreadyPresent(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 409)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "LeaseAlreadyPresent";
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code
        /// LeaseIdMismatchWithLeaseOperation.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code
        /// LeaseIdMismatchWithLeaseOperation; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictLeaseIdMismatchWithLeaseOperation(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 409)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "LeaseIdMismatchWithLeaseOperation";
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code QueueBeingDeleted.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code
        /// QueueBeingDeleted; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictQueueBeingDeleted(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 409)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "QueueBeingDeleted";
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code QueueBeingDeleted or
        /// QueueDisabled.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code QueueBeingDeleted
        /// or QueueDisabled; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictQueueBeingDeletedOrDisabled(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 409)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "QueueBeingDeleted";
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code QueueDisabled.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code QueueDisabled;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictQueueDisabled(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 409)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "QueueDisabled";
        }

        /// <summary>Determines whether the exception is due to a 404 Not Found error.</summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            return result.HttpStatusCode == 404;
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code BlobNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code BlobNotFound;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundBlobNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "BlobNotFound";
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code ContainerNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code
        /// ContainerNotFound; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundContainerNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "ContainerNotFound";
        }



        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code BlobNotFound or
        /// ContainerNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code BlobNotFound or
        /// ContainerNotFound; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundBlobOrContainerNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            string errorCode = extendedInformation.ErrorCode;
            return errorCode == "BlobNotFound" || errorCode == "ContainerNotFound";
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code MessageNotFound or
        /// QueueNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code MessageNotFound
        /// or QueueNotFound; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundMessageOrQueueNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            string errorCode = extendedInformation.ErrorCode;
            return errorCode == "MessageNotFound" || errorCode == "QueueNotFound";
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code MessageNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code MessageNotFound;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundMessageNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "MessageNotFound";
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code QueueNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code QueueNotFound;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundQueueNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "QueueNotFound";
        }

        /// <summary>Determines whether the exception occurred despite a 200 OK response.</summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception occurred despite a 200 OK response; otherwise
        /// <see langword="false"/>.
        /// </returns>
        public static bool IsOk(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            return result.HttpStatusCode == 200;
        }

        /// <summary>Determines whether the exception is due to a 412 Precondition Failed error.</summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 412 Precondition Failed error; otherwise
        /// <see langword="false"/>.
        /// </returns>
        public static bool IsPreconditionFailed(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            return result.HttpStatusCode == 412;
        }

        /// <summary>
        /// Determines whether the exception is due to a 412 Precondition Failed error with the error code
        /// ConditionNotMet.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 412 Precondition Failed error with the error code
        /// ConditionNotMet; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsPreconditionFailedConditionNotMet(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 412)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "ConditionNotMet";
        }

        /// <summary>
        /// Determines whether the exception is due to a 412 Precondition Failed error with the error code
        /// LeaseIdMissing.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 412 Precondition Failed error with the error code
        /// LeaseIdMissing; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsPreconditionFailedLeaseIdMissing(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 412)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "LeaseIdMissing";
        }

        /// <summary>
        /// Determines whether the exception is due to a 412 Precondition Failed error with the error code LeaseLost.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 412 Precondition Failed error with the error code
        /// LeaseLost; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsPreconditionFailedLeaseLost(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 412)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "LeaseLost";
        }

        /// <summary>
        /// Determines whether the exception is due to a task cancellation.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns><see langword="true"/> if the inner exception is a <see cref="TaskCanceledException"/>. Otherwise, <see langword="false"/>.</returns>
        public static bool IsTaskCanceled(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            return exception.InnerException is TaskCanceledException;
        }

        /// <summary>
        /// Returns the status code from the storage exception, or null.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <param name="statusCode">When this method returns, contains the status code.</param>
        /// <returns>Returns true if there was a status code; otherwise, false.</returns>
        public static bool TryGetStatusCode(this StorageException exception, out int statusCode)
        {
            statusCode = 0;

            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            statusCode = result.HttpStatusCode;
            return true;
        }

        /// <summary>
        /// Returns the error code from storage exception, or null.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>The error code, or null.</returns>
        public static string GetErrorCode(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return null;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return null;
            }

            return extendedInformation.ErrorCode;
        }

        /// <summary>
        /// Returns a custom detailed error message for a StorageException. This is a workaround for bad error messages
        /// returned by Azure Storage.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>The error message.</returns>
        public static string GetDetailedErrorMessage(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            string message = exception.Message;

            if (exception.RequestInformation != null)
            {
                message += $" (HTTP status code {exception.RequestInformation.HttpStatusCode.ToString()}: "
                    + $"{exception.RequestInformation.ExtendedErrorInformation?.ErrorCode}. "
                    + $"{exception.RequestInformation.ExtendedErrorInformation?.ErrorMessage})";
            }

            return message;
        }
    }
}
