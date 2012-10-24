// -----------------------------------------------------------------------------------------
// <copyright file="TableEntity.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents the base object type for a table entity in the Table Storage service.
    /// </summary>
    /// <remarks><see cref="TableEntity"/> provides a base implementation for the <see cref="ITableEntity"/> interface that provides <see cref="ReadEntity(IDictionary{string, EntityProperty}, OperationContext)"/> and <see cref="WriteEntity(OperationContext)"/> methods that by default serialize and 
    /// de-serialize all properties via reflection. A table entity class may extend this class and override the <see cref="ITableEntity.ReadEntity(IDictionary{string, EntityProperty}, OperationContext)"/> and <see cref="ITableEntity.WriteEntity(OperationContext)"/> methods to provide customized or better performing serialization logic.</remarks>
    public class TableEntity : ITableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class.
        /// </summary>
        public TableEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">The partition key of the <see cref="TableEntity"/> to be initialized.</param>
        /// <param name="rowKey">The row key of the <see cref="TableEntity"/> to be initialized.</param>
        public TableEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

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

        /// <summary>
        /// De-serializes this <see cref="TableEntity"/> instance using the specified <see cref="Dictionary{TKey,TValue}"/> of property names to <see cref="EntityProperty"/> data typed values. 
        /// </summary>
        /// <param name="properties">The map of string property names to <see cref="EntityProperty"/> data values to de-serialize and store in this table entity instance.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Needed for object type checking.")]
        public virtual void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
#if RT
            IEnumerable<PropertyInfo> objectProperties = this.GetType().GetRuntimeProperties();
#else
            IEnumerable<PropertyInfo> objectProperties = this.GetType().GetProperties();
#endif

            foreach (PropertyInfo property in objectProperties)
            {
                // reserved properties
                if (property.Name == TableConstants.PartitionKey ||
                    property.Name == TableConstants.RowKey ||
                    property.Name == TableConstants.Timestamp ||
                    property.Name == "ETag")
                {
                    continue;
                }

                // Enforce public getter / setter
#if RT
                if (property.SetMethod == null || !property.SetMethod.IsPublic || property.GetMethod == null || !property.GetMethod.IsPublic)
#else
                if (property.GetSetMethod() == null || !property.GetSetMethod().IsPublic || property.GetGetMethod() == null || !property.GetGetMethod().IsPublic)
#endif
                {
                    continue;
                }

                // only proceed with properties that have a corresponding entry in the dictionary
                if (!properties.ContainsKey(property.Name))
                {
                    continue;
                }

                EntityProperty entityProperty = properties[property.Name];

                if (entityProperty.IsNull)
                {
                    property.SetValue(this, null, null);
                }

                switch (entityProperty.PropertyType)
                {
                    case EdmType.String:
                        if (property.PropertyType != typeof(string) && property.PropertyType != typeof(String))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.StringValue, null);
                        break;
                    case EdmType.Binary:
                        if (property.PropertyType != typeof(byte[]))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.BinaryValue, null);
                        break;
                    case EdmType.Boolean:
                        if (property.PropertyType != typeof(bool) && property.PropertyType != typeof(Boolean))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.BooleanValue, null);
                        break;
                    case EdmType.DateTime:
                        if (property.PropertyType == typeof(DateTime))
                        {
                            property.SetValue(this, entityProperty.DateTimeOffsetValue.Value.UtcDateTime, null);
                        }
                        else if (property.PropertyType == typeof(DateTime?))
                        {
                            property.SetValue(this, entityProperty.DateTimeOffsetValue.HasValue ? entityProperty.DateTimeOffsetValue.Value.UtcDateTime : (DateTime?)null, null);
                        }
                        else if (property.PropertyType == typeof(DateTimeOffset))
                        {
                            property.SetValue(this, entityProperty.DateTimeOffsetValue.Value, null);
                        }
                        else if (property.PropertyType == typeof(DateTimeOffset?))
                        {
                            property.SetValue(this, entityProperty.DateTimeOffsetValue, null);
                        }

                        break;
                    case EdmType.Double:
                        if (property.PropertyType != typeof(double) && property.PropertyType != typeof(Double))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.DoubleValue, null);
                        break;
                    case EdmType.Guid:
                        if (property.PropertyType != typeof(Guid))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.GuidValue, null);
                        break;
                    case EdmType.Int32:
                        if (property.PropertyType != typeof(int) && property.PropertyType != typeof(Int32))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.Int32Value, null);
                        break;
                    case EdmType.Int64:
                        if (property.PropertyType != typeof(long) && property.PropertyType != typeof(Int64))
                        {
                            continue;
                        }

                        property.SetValue(this, entityProperty.Int64Value, null);
                        break;
                }
            }
        }

        /// <summary>
        /// Serializes the <see cref="Dictionary{TKey,TValue}"/> of property names mapped to <see cref="EntityProperty"/> data values from this <see cref="TableEntity"/> instance.
        /// </summary>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        /// <returns>A map of property names to <see cref="EntityProperty"/> data typed values created by serializing this table entity instance.</returns>
        public virtual IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            Dictionary<string, EntityProperty> retVals = new Dictionary<string, EntityProperty>();

#if RT
            IEnumerable<PropertyInfo> objectProperties = this.GetType().GetRuntimeProperties();
#else
            IEnumerable<PropertyInfo> objectProperties = this.GetType().GetProperties();
#endif

            foreach (PropertyInfo property in objectProperties)
            {
                // reserved properties
                if (property.Name == TableConstants.PartitionKey ||
                    property.Name == TableConstants.RowKey ||
                    property.Name == TableConstants.Timestamp ||
                    property.Name == "ETag")
                {
                    continue;
                }

                // Enforce public getter / setter
#if RT
                if (property.SetMethod == null || !property.SetMethod.IsPublic || property.GetMethod == null || !property.GetMethod.IsPublic)
#else
                if (property.GetSetMethod() == null || !property.GetSetMethod().IsPublic || property.GetGetMethod() == null || !property.GetGetMethod().IsPublic)
#endif
                {
                    continue;
                }

                EntityProperty newProperty = EntityProperty.CreateEntityPropertyFromObject(property.GetValue(this, null), false);

                // property will be null if unknown type
                if (newProperty != null)
                {
                    retVals.Add(property.Name, newProperty);
                }
            }

            return retVals;
        }
    }
}
