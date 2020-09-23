// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Files.DataLake.Models
{
#pragma warning disable CA2229, CA2235 // False positive
    /// <summary>
    /// An exception thrown when an operation is interrupted and can be continued later on.
    /// </summary>
    [Serializable]
    public class DataLakeAclChangeFailedException : Exception, ISerializable
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets the service specific error code if available. Please refer to the client documentation for the list of supported error codes.
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Gets the continuation token from the last successful response from the service.
        /// </summary>
        public string ContinuationToken { get; }

        /// <summary>Initializes a new instance of the <see cref="DataLakeAclChangeFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="exception">The exception thrown from the failed request.</param>
        /// <param name="continuationToken">The continuation token returned from the previous successful response.</param>
        public DataLakeAclChangeFailedException(
            RequestFailedException exception,
            string continuationToken)
            : base(exception.Message, exception.InnerException)
        {
            Status = exception.Status;
            ErrorCode = exception.ErrorCode;
            ContinuationToken = continuationToken;
        }

        /// <inheritdoc />
        protected DataLakeAclChangeFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
            ErrorCode = info.GetString(nameof(ErrorCode));
            ContinuationToken = info.GetString(nameof(ContinuationToken));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(Status), Status);
            info.AddValue(nameof(ErrorCode), ErrorCode);
            info.AddValue(nameof(ContinuationToken), ContinuationToken);

            base.GetObjectData(info, context);
        }
    }
}
