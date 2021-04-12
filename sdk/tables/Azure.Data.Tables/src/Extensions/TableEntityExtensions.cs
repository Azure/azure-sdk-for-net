// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Data.Tables
{
    internal static class TableEntityExtensions
    {
        /// <summary>
        /// Returns a new Dictionary with the appropriate Odata type annotation for a given propertyName value pair.
        /// The default case is intentionally unhandled as this means that no type annotation for the specified type is required.
        /// This is because the type is naturally serialized in a way that the table service can interpret without hints.
        /// </summary>
        internal static Dictionary<string, object> ToOdataAnnotatedDictionary<T>(this T entity) where T : class, ITableEntity
        {
            if (entity is IDictionary<string, object> dictEntity)
            {
                return dictEntity.ToOdataAnnotatedDictionary();
            }

            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var annotatedDictionary = new Dictionary<string, object>(properties.Length * 2);

            foreach (var prop in properties)
            {
                // Remove the ETag and Timestamp properties, as they do not need to be serialized
                if (prop.Name == TableConstants.PropertyNames.ETag || prop.Name == TableConstants.PropertyNames.Timestamp)
                {
                    continue;
                }

                annotatedDictionary[prop.Name] = prop.GetValue(entity);

                switch (annotatedDictionary[prop.Name])
                {
                    case byte[]:
                    case BinaryData:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmBinary;
                        break;
                    case long:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmInt64;
                        // Int64 / long should be serialized as string.
                        annotatedDictionary[prop.Name] = annotatedDictionary[prop.Name].ToString();
                        break;
                    case double:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDouble;
                        break;
                    case Guid:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmGuid;
                        break;
                    case DateTimeOffset:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                        break;
                    case DateTime:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                        break;
                    case Enum enumValue:
                        // serialize enum as string
                        annotatedDictionary[prop.Name] = enumValue.ToString();
                        break;
                }
            }

            return annotatedDictionary;
        }
    }
}
