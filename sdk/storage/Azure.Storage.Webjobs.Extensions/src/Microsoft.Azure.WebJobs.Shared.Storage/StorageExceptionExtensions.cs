// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>Provides extension methods for the <see cref="StorageException"/> class.</summary>
    internal static class StorageExceptionExtensions
    {
        public static bool IsServerSideError(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            int statusCode = exception.Status;
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
        public static bool IsBadRequestPopReceiptMismatch(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 400)
            {
                return false;
            }

            return exception.ErrorCode == "PopReceiptMismatch";
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
                throw new ArgumentNullException(nameof(exception));
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
                throw new ArgumentNullException(nameof(exception));
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
                throw new ArgumentNullException(nameof(exception));
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
        /// Determines whether the exception is due to a 409 Conflict error with the error code QueueBeingDeleted or
        /// QueueDisabled.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code QueueBeingDeleted
        /// or QueueDisabled; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictQueueBeingDeletedOrDisabled(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 409)
            {
                return false;
            }

            return exception.ErrorCode == "QueueBeingDeleted";
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
                throw new ArgumentNullException(nameof(exception));
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            return result.HttpStatusCode == 404;
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
                throw new ArgumentNullException(nameof(exception));
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
                throw new ArgumentNullException(nameof(exception));
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
        public static bool IsNotFoundMessageOrQueueNotFound(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 404)
            {
                return false;
            }

            string errorCode = exception.ErrorCode;
            return errorCode == "MessageNotFound" || errorCode == "QueueNotFound";
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code QueueNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code QueueNotFound;
        /// otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundQueueNotFound(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 404)
            {
                return false;
            }

            return exception.ErrorCode == QueueErrorCode.QueueNotFound;
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
                throw new ArgumentNullException(nameof(exception));
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            return result.HttpStatusCode == 200;
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
                throw new ArgumentNullException(nameof(exception));
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
                throw new ArgumentNullException(nameof(exception));
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
                throw new ArgumentNullException(nameof(exception));
            }

            return exception.InnerException is TaskCanceledException;
        }
    }
}
