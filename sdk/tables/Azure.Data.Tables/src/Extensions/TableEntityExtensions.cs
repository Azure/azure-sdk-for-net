// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Data.Tables
{
    internal static class TableEntityExtensions
    {
        /// <summary>
        /// Returns a new Dictionary with the appropriate Odata type annotation for a given propertyName value pair.
        /// The default case is intentionally unhandled as this means that no type annotation for the specified type is required.
        /// This is because the type is naturally serialized in a way that the table service can interpret without hints.
        /// </summary>
        internal static IDictionary<string, object> ToOdataAnnotatedDictionary<T>(this T entity) where T : class, ITableEntity
        {
            if (entity is IDictionary<string, object> dictEntity)
            {
                return dictEntity.ToOdataAnnotatedDictionary();
            }

            var dictionary = new Dictionary<string, object>();
            TablesTypeBinder.Shared.Serialize(entity, entity.GetType(), dictionary);
            return dictionary;
        }
    }
}
