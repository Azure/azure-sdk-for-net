//-----------------------------------------------------------------------
// <copyright file="POCOAdapter.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Storage.Table.Entities
{
    public class POCOAdapter<ShapeEntity> : ITableEntity
    {
        public POCOAdapter(ShapeEntity shape)
        {
            this.Shape = shape;
        }

        public POCOAdapter(ShapeEntity shape, string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
            this.Shape = shape;
        }

        #region ITableEntity Implementation

        /// <summary>
        /// Gets or sets the entity's partition key.
        /// </summary>
        /// <value>The partition key of the entity.</value>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's row key.
        /// </summary>
        /// <value>The row key of the entity.</value>
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's timestamp.
        /// </summary>
        /// <value>The timestamp of the entity.</value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the entity's current ETag.  Set this value to '*' in order to blindly overwrite an entity as part of an update operation.
        /// </summary>
        /// <value>The ETag of the entity.</value>
        public string ETag { get; set; }

        public ShapeEntity Shape { get; set; }

        public virtual void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            TableEntity.ReadUserObject(this.Shape, properties, operationContext);
        }

        public virtual IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            return TableEntity.WriteUserObject(this.Shape, operationContext);
        }
        #endregion
    }
}
