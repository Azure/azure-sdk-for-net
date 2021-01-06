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
                annotatedDictionary[prop.Name] = prop.GetValue(entity);

                switch (annotatedDictionary[prop.Name])
                {
                    case byte[] _:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmBinary;
                        break;
                    case long _:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmInt64;
                        // Int64 / long should be serialized as string.
                        annotatedDictionary[prop.Name] = annotatedDictionary[prop.Name].ToString();
                        break;
                    case double _:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDouble;
                        break;
                    case Guid _:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmGuid;
                        break;
                    case DateTimeOffset _:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                        break;
                    case DateTime _:
                        annotatedDictionary[prop.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                        break;
                    case Enum enumValue:
                        // serialize enum as string
                        annotatedDictionary[prop.Name] = enumValue.ToString();
                        break;
                }
            }

            // Remove the ETag property, as it does not need to be serialized
            annotatedDictionary.Remove(TableConstants.PropertyNames.ETag);

            return annotatedDictionary;
        }
    }
}
