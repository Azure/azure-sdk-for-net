// -----------------------------------------------------------------------------------------
// <copyright file="EntityUtilities.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Table;

    internal class EntityUtilities
    {
        internal static TElement ResolveEntityByType<TElement>(string partitionKey, string rowKey, DateTimeOffset timestamp, IDictionary<string, EntityProperty> properties, string etag) where TElement : ITableEntity
        {
            ITableEntity entity = (ITableEntity)InstantiateEntityFromGenericType<TElement>();

            entity.PartitionKey = partitionKey;
            entity.RowKey = rowKey;
            entity.Timestamp = timestamp;
            entity.ReadEntity(properties, null);
            entity.ETag = etag;

            return (TElement)entity;
        }

        internal static DynamicTableEntity ResolveDynamicEntity(string partitionKey, string rowKey, DateTimeOffset timestamp, IDictionary<string, EntityProperty> properties, string etag)
        {
            DynamicTableEntity entity = new DynamicTableEntity(partitionKey, rowKey);
            entity.Timestamp = timestamp;
            entity.ReadEntity(properties, null);
            entity.ETag = etag;

            return entity;
        }

        internal static TElement InstantiateEntityFromGenericType<TElement>()
        {
            return (TElement)Activator.CreateInstance(typeof(TElement));
        }
    }
}
