// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    /// <summary>
    /// The response from <see cref="TableClient.SubmitTransaction"/> or <see cref="TableClient.SubmitTransactionAsync"/>.
    /// </summary>
    public class TableTransactionResult
    {
        private readonly IDictionary<string, HttpMessage> _requestLookup;

        internal TableTransactionResult(Dictionary<string, HttpMessage> requestLookup)
        {
            _requestLookup = requestLookup;
        }

        /// <summary>
        /// The number of batch sub-responses contained in this <see cref="TableTransactionResult"/>.
        /// </summary>
        public int ResponseCount => _requestLookup.Keys.Count;

        /// <summary>
        /// Gets the batch sub-response for the batch sub-request associated with the entity with the specified <paramref name="rowKey"/>.
        /// </summary>
        /// <param name="rowKey">The <see cref="ITableEntity.RowKey"/> value of the entity related to the batch sub-request.</param>
        /// <returns></returns>
        public Response GetResponseForEntity(string rowKey)
        {
            if (!_requestLookup.TryGetValue(rowKey, out HttpMessage message))
            {
                throw new InvalidOperationException("The batch operation did not contain an entity with the specified rowKey");
            }

            return message.Response;
        }

        /// <summary>
        /// Tries to get the entity that caused the batch operation failure from the <see cref="RequestFailedException"/>.
        /// </summary>
        /// <param name="exception">The exception thrown from <see cref="TableClient.SubmitTransaction"/> or <see cref="TableClient.SubmitTransactionAsync"/>.</param>
        /// <param name="submittedBatchItems">The submitted list of <see cref="TableTransactionAction"/>. This list should be unchanged since it was submitted via
        /// <see cref="TableClient.SubmitTransaction"/> or <see cref="TableClient.SubmitTransactionAsync"/> </param>
        /// <param name="failedEntity">If the return value is <c>true</c>, contains the <see cref="ITableEntity"/> that caused the batch operation to fail.</param>
        /// <returns><c>true</c> if the failed entity was retrieved from the exception, else <c>false</c>.</returns>
        public static bool TryGetFailedEntityFromException(RequestFailedException exception, IReadOnlyList<TableTransactionAction> submittedBatchItems, out ITableEntity failedEntity)
        {
            Argument.AssertNotNull(exception, nameof(exception));
            Argument.AssertNotNull(submittedBatchItems, nameof(submittedBatchItems));

            failedEntity = null;

            if (!exception.Data.Contains(TableConstants.ExceptionData.FailedEntityIndex))
            {
                return false;
            }
            try
            {
                if (exception.Data[TableConstants.ExceptionData.FailedEntityIndex] is string stringIndex && int.TryParse(stringIndex, out int index))
                {
                    failedEntity = submittedBatchItems[index].Entity;
                }
            }
            catch
            {
                // We just don't want to throw here.
            }

            return failedEntity != null;
        }
    }
}
