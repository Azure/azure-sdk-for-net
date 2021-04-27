// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    /// <summary>Provides extension methods for the <see cref="RequestFailedException"/> class.</summary>
    internal static partial class RequestFailedExceptionExtensions
    {
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
