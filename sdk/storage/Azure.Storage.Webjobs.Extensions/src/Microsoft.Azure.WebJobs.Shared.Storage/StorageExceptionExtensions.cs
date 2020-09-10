// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs
{
    // TODO (kasobol-msft) Rename this ?
    /// <summary>Provides extension methods for the <see cref="RequestFailedException"/> class.</summary>
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
        public static bool IsConflictBlobAlreadyExists(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 409)
            {
                return false;
            }

            return exception.ErrorCode == "BlobAlreadyExists";
        }

        /// <summary>
        /// Determines whether the exception is due to a 409 Conflict error with the error code LeaseAlreadyPresent.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 409 Conflict error with the error code
        /// LeaseAlreadyPresent; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsConflictLeaseAlreadyPresent(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 409)
            {
                return false;
            }

            return exception.ErrorCode == "LeaseAlreadyPresent";
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
        public static bool IsConflictLeaseIdMismatchWithLeaseOperation(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 409)
            {
                return false;
            }

            return exception.ErrorCode == "LeaseIdMismatchWithLeaseOperation";
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
        public static bool IsNotFound(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            return exception.Status == 404;
        }

        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code ContainerNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code
        /// ContainerNotFound; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundContainerNotFound(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 404)
            {
                return false;
            }

            return exception.ErrorCode == "ContainerNotFound";
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
        public static bool IsNotFoundBlobOrContainerNotFound(this RequestFailedException exception)
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
        public static bool IsOk(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            return exception.Status == 200;
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
        public static bool IsPreconditionFailedLeaseIdMissing(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 412)
            {
                return false;
            }

            return exception.ErrorCode == "LeaseIdMissing";
        }

        /// <summary>
        /// Determines whether the exception is due to a 412 Precondition Failed error with the error code LeaseLost.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 412 Precondition Failed error with the error code
        /// LeaseLost; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsPreconditionFailedLeaseLost(this RequestFailedException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (exception.Status != 412)
            {
                return false;
            }

            return exception.ErrorCode == "LeaseLost";
        }
    }
}
