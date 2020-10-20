// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;

namespace Azure.Data.Tables
{
    /// <summary>
    /// An exception thrown when a <see cref="TableTransactionalBatch"/> operation fails.
    /// </summary>
    public class TableBatchOperationFailedException : RequestFailedException
    {
        public TableBatchOperationFailedException(string message) : base(message)
        {
        }

        public TableBatchOperationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TableBatchOperationFailedException(int status, string message) : base(status, message)
        {
        }

        public TableBatchOperationFailedException(int status, string message, Exception innerException) : base(status, message, innerException)
        {
        }

        public TableBatchOperationFailedException(int status, string message, string errorCode, Exception innerException, ITableEntity entity) : base(status, message, errorCode, innerException)
        {
            TableEntity = entity;
        }

        protected TableBatchOperationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// The <see cref="ITableEntity"/> related to the batch operation error.
        /// </summary>
        /// <value></value>
        public ITableEntity TableEntity { get; }
    }
}
