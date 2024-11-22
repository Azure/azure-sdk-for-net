// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;
using Azure.Core;
using Azure.Storage.Common;

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
        /// Gets the continuation token from the last successful response from the service.
        /// </summary>
        public string ContinuationToken { get; }

        /// <summary>Initializes a new instance of the <see cref="DataLakeAclChangeFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="exception">The exception thrown from the failed request.</param>
        /// <param name="continuationToken">The continuation token returned from the previous successful response.</param>
        public DataLakeAclChangeFailedException(
            string message,
            Exception exception,
            string continuationToken)
            : base(message, exception)
        {
            ContinuationToken = continuationToken;
        }

        /// <summary>Initializes a new instance of the <see cref="DataLakeAclChangeFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="exception">The exception thrown from the failed request.</param>
        /// <param name="continuationToken">The continuation token returned from the previous successful response.</param>
        public DataLakeAclChangeFailedException(
            string message,
            RequestFailedException exception,
            string continuationToken)
            : base(message, exception)
        {
            ContinuationToken = continuationToken;
        }

        /// <inheritdoc />
#if NET8_0_OR_GREATER
        [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
        protected DataLakeAclChangeFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ContinuationToken = info.GetString(nameof(ContinuationToken));
        }

        /// <inheritdoc />
#if NET8_0_OR_GREATER
        [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(ContinuationToken), ContinuationToken);

            base.GetObjectData(info, context);
        }
    }
}
