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
    }
}
