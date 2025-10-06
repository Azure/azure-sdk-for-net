// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Data.Tables
{
    internal static class DictionaryTableExtensions
    {
        /// <summary>
        /// Returns a new Dictionary with the appropriate Odata type annotation for a given propertyName value pair.
        /// The default case is intentionally unhandled as this means that no type annotation for the specified type is required.
        /// This is because the type is naturally serialized in a way that the table service can interpret without hints.
        /// </summary>
        internal static Dictionary<string, object> ToOdataAnnotatedDictionary(this IDictionary<string, object> tableEntityProperties)
        {
            var annotatedDictionary = new Dictionary<string, object>(tableEntityProperties.Keys.Count * 2);

            foreach (var item in tableEntityProperties)
            {
                // Remove the ETag property, as it does not need to be serialized
                if (item.Key == TableConstants.PropertyNames.EtagOdata || item.Key == TableConstants.PropertyNames.Timestamp)
                {
                    continue;
                }

                annotatedDictionary[item.Key] = item.Value;

                switch (item.Value)
                {
                    case byte[] _:
                    case BinaryData _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmBinary;
                        break;
                    case long _:
                    case ulong _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmInt64;
                        // Int64 / long should be serialized as string.
                        annotatedDictionary[item.Key] = item.Value.ToString() ?? string.Empty;
                        break;
                    case double _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmDouble;
                        break;
                    case Guid _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmGuid;
                        break;
                    case DateTimeOffset _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                        break;
                    case DateTime _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                        break;
                    case Enum enumValue:
                        throw new NotSupportedException("Enum values are only supported for custom model types implementing ITableEntity.");
                }
            }

            return annotatedDictionary;
        }

        /// <summary>
        /// Cleans a Dictionary of its Odata type annotations, while using them to cast its entities accordingly.
        /// </summary>
        internal static void CastAndRemoveAnnotations(this IDictionary<string, object> entity, Dictionary<string, (string TypeAnnotation, string AnnotationKey)>? typeAnnotationsWithKeys = null)
        {
            typeAnnotationsWithKeys ??= new Dictionary<string, (string TypeAnnotation, string AnnotationKey)>();
            var spanOdataSuffix = TableConstants.Odata.OdataTypeString.AsSpan();

            typeAnnotationsWithKeys.Clear();

            foreach (var propertyName in entity.Keys)
            {
                var spanPropertyName = propertyName.AsSpan();
                var iSuffix = spanPropertyName.IndexOf(spanOdataSuffix);
                if (iSuffix > 0)
                {
                    // This property is an Odata annotation. Save it in the typeAnnoations dictionary.
                    typeAnnotationsWithKeys[spanPropertyName.Slice(0, iSuffix).ToString()] = ((entity[propertyName] as string)!, propertyName);
                }
            }

            // Iterate through the types that are serialized as string by default and Parse them as the correct type, as indicated by the type annotations.
            foreach (var annotation in typeAnnotationsWithKeys.Keys)
            {
                entity[annotation] = typeAnnotationsWithKeys[annotation].TypeAnnotation switch
                {
                    TableConstants.Odata.EdmBinary => Convert.FromBase64String(entity[annotation] as string ?? string.Empty),
                    TableConstants.Odata.EdmDateTime => DateTimeOffset.Parse(entity[annotation] as string ?? string.Empty, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    TableConstants.Odata.EdmGuid => Guid.Parse(entity[annotation] as string ?? string.Empty),
                    TableConstants.Odata.EdmInt64 => long.Parse(entity[annotation] as string ?? string.Empty, CultureInfo.InvariantCulture),
                    TableConstants.Odata.EdmDouble => double.Parse(entity[annotation] as string ?? string.Empty, CultureInfo.InvariantCulture),
                    _ => throw new NotSupportedException("Not supported type " + typeAnnotationsWithKeys[annotation])
                };

                // Remove the type annotation property from the dictionary.
                entity.Remove(typeAnnotationsWithKeys[annotation].AnnotationKey);
            }

            // The Timestamp property is not annotated, since it is a known system property
            // so we must cast it without a type annotation
            if (entity.TryGetValue(TableConstants.PropertyNames.Timestamp, out var value) && value is string)
            {
                entity[TableConstants.PropertyNames.Timestamp] = DateTimeOffset.Parse(entity[TableConstants.PropertyNames.Timestamp] as string ?? string.Empty, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }

            // Remove odata metadata.
            entity.Remove(TableConstants.PropertyNames.OdataMetadata);
        }

        /// <summary>
        /// Converts a List of Dictionaries containing properties and Odata type annotations to a custom entity type.
        /// </summary>
        internal static List<T> ToTableEntityList<T>(this IReadOnlyList<IDictionary<string, object>> entityList) where T : class, ITableEntity
        {
            var result = new List<T>(entityList.Count);
            var typeInfo = TablesTypeBinder.Shared.GetBinderInfo(typeof(T), typeof(ITableEntity));

            foreach (var entity in entityList)
            {
                var tableEntity = entity.ToTableEntity<T>(typeInfo);

                result.Add(tableEntity);
            }

            return result;
        }

        /// <summary>
        /// Cleans a Dictionary of its Odata type annotations, while using them to cast its entities accordingly.
        /// </summary>
        internal static T ToTableEntity<T>(this IDictionary<string, object> entity, TablesTypeBinder.BoundTypeInfo? typeInfo = null) where T : class, ITableEntity
        {
            if (typeof(IDictionary<string, object>).IsAssignableFrom(typeof(T)))
            {
                var result = Activator.CreateInstance<T>();
                var dictionary = (IDictionary<string, object>)result;
                entity.CastAndRemoveAnnotations();

                foreach (var entProperty in entity.Keys)
                {
                    dictionary[entProperty] = entity[entProperty];
                }

                return result;
            }

            typeInfo ??= TablesTypeBinder.Shared.GetBinderInfo(typeof(T), typeof(ITableEntity));
            return typeInfo.Deserialize<T>(entity);
        }
    }
}
