// -----------------------------------------------------------------------------------------
// <copyright file="ITableEntity.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An interface required for table entity types. The <see cref="ITableEntity"/> interface declares getter and setter methods for the mandatory entity properties, and <see cref="ReadEntity"/> 
    /// and <see cref="WriteEntity"/> methods for serialization and de-serialization of all entity properties using a property dictionary. Create classes implementing <see cref="ITableEntity"/> to customize property 
    /// storage, retrieval, serialization and de-serialization, and to provide additional custom logic for a table entity.
    /// </summary>
    /// <remarks><para>The Storage client library includes two implementations of <see cref="ITableEntity"/> that provide for simple property access and serialization:</para>
    /// <para><see cref="DynamicTableEntity"/> implements <see cref="ITableEntity"/> and provides a simple property dictionary to store and retrieve properties. Use a <see cref="DynamicTableEntity"/> for simple access 
    /// to entity properties when only a subset of properties are returned (for example, by a select clause in a query), or for when your query can return multiple entity types 
    /// with different properties. You can also use this type to perform bulk table updates of heterogeneous entities without losing property information.</para>
    /// <para><see cref="TableEntity"/> is an implementation of <see cref="ITableEntity"/> that uses reflection-based serialization and de-serialization behavior in its <see cref="TableEntity.ReadEntity(IDictionary{string, EntityProperty}, OperationContext)"/> and <see cref="TableEntity.WriteEntity(OperationContext)"/> methods. 
    /// <see cref="TableEntity"/>-derived classes with methods that follow a convention for types and naming are serialized and deserialized automatically. <see cref="TableEntity"/>-derived classes must also provide a get-able and set-able public
    /// property of a type that is supported by the Windows Azure Table Service.</para></remarks>
    public interface ITableEntity
    {
        /// <summary>
        /// Gets or sets the entity's partition key.
        /// </summary>
        /// <value>The entity's partition key.</value>
        string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's row key.
        /// </summary>
        /// <value>The entity's row key.</value>
        string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's time stamp.
        /// </summary>
        /// <value>The entity's time stamp. The property is populated by the Windows Azure Table Service.</value>
        DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the entity's current ETag.  Set this value to '*'
        /// in order to blindly overwrite an entity as part of an update
        /// operation.
        /// </summary>
        /// <value>The entity's time stamp.</value>
        string ETag { get; set; }

        /// <summary>
        /// Populates the entity's properties from the <see cref="EntityProperty"/> data values in the <paramref name="properties"/> dictionary. 
        /// </summary>
        /// <param name="properties">The dictionary of string property names to <see cref="EntityProperty"/> data values to deserialize and store in this table entity instance.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext);

        /// <summary>
        /// Serializes the <see cref="Dictionary{TKey,TValue}"/> of property names mapped to <see cref="EntityProperty"/> data values from the entity instance.
        /// </summary>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        /// <returns>A dictionary of property names to <see cref="EntityProperty"/> data typed values created by serializing this table entity instance.</returns>
        IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext);
    }
}
