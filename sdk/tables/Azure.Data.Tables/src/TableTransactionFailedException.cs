// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Azure.Data.Tables
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class TableTransactionFailedException : RequestFailedException
    {
        /// <summary>
        /// The index position of the <see cref="TableTransactionAction"/> collection submitted to <see cref="TableClient.SubmitTransaction"/> or
        /// <see cref="TableClient.SubmitTransactionAsync"/> which caused the transaction to fail.
        /// </summary>
        public int? FailedTransactionActionIndex { get; internal set; }

        /// <summary>
        /// Initializes a new instances of a <see cref="TableTransactionFailedException"/>.
        /// </summary>
        /// <param name="requestFailedException"> The <see cref="RequestFailedException"/> related to this exception.</param>
        public TableTransactionFailedException(RequestFailedException requestFailedException)
            : base(
                requestFailedException.Status,
                requestFailedException.Message,
                requestFailedException.ErrorCode,
                requestFailedException.InnerException)
        {
            foreach (var key in requestFailedException.Data.Keys)
            {
                Data.Add(key, requestFailedException.Data[key]);
            }

            try
            {
                if (Data[TableConstants.ExceptionData.FailedEntityIndex] is string stringIndex && int.TryParse(stringIndex, out var index))
                {
                    FailedTransactionActionIndex = index;
                }
            }
            catch
            {
                // We just don't want to throw here.
            }
        }

        /// <inheritdoc />
#if NET8_0_OR_GREATER
        [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
        protected TableTransactionFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
