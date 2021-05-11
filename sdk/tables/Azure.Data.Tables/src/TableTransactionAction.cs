// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    /// <summary>
    /// Defines an transaction action to be included as part of a batch operation.
    /// </summary>
    public class TableTransactionAction
    {
        /// <summary>
        /// The operation type to be applied to the <see cref="Entity"/>.
        /// </summary>
        public TableTransactionActionType ActionType { get; }

        /// <summary>
        /// The table entity to which the batch operation will be applied.
        /// </summary>
        public ITableEntity Entity { get; }

        /// <summary>
        /// The optional <see cref="ETag"/> to be used for the entity operation.
        /// </summary>
        public ETag ETag { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableTransactionAction"/>
        /// </summary>
        /// <param name="actionType"> The operation type to be applied to the <paramref name="entity"/></param>
        /// <param name="entity">The table entity to which the <paramref name="actionType"/> will be applied.</param>
        public TableTransactionAction(TableTransactionActionType actionType, ITableEntity entity) : this(actionType, entity, default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableTransactionAction"/>
        /// </summary>
        /// <param name="actionType"> The operation type to be applied to the <paramref name="entity"/></param>
        /// <param name="entity">The table entity to which the <paramref name="actionType"/> will be applied.</param>
        /// <param name="etag"> The <see cref="ETag"/> to apply to this action.</param>
        public TableTransactionAction(TableTransactionActionType actionType, ITableEntity entity, ETag etag = default)
        {
            ActionType = actionType;
            Entity = entity;
            ETag = etag;
        }
    }
}
