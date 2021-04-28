// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    /// <summary>
    ///
    /// </summary>
    public class BatchItem
    {
        /// <summary>
        ///
        /// </summary>
        public BatchOperation BatchOperation { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ITableEntity Entity { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ETag ETag { get; set; }

        /// <summary>
        ///
        /// </summary>
        public BatchItem()
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="batchOperation"></param>
        /// <param name="entity"></param>
        /// <param name="etag"></param>
        public BatchItem(BatchOperation batchOperation, ITableEntity entity, ETag etag = default)
        {
            BatchOperation = batchOperation;
            Entity = entity;
            ETag = etag;
        }
    }
}
