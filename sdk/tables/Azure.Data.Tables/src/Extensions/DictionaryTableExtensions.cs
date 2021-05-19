// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Azure.Data.Tables
{
    internal static class DictionaryTableExtensions
    {
        /// <summary>
        /// A cache for reflected <see cref="PropertyInfo"/> array for the given <see cref="Type"/>.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> s_propertyInfoCache = new ConcurrentDictionary<Type, PropertyInfo[]>();

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
                if (item.Key == TableConstants.PropertyNames.ETag)
                {
                    continue;
                }

                annotatedDictionary[item.Key] = item.Value;

                switch (item.Value)
                {
                    case byte[] _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmBinary;
                        break;
                    case long _:
                        annotatedDictionary[item.Key.ToOdataTypeString()] = TableConstants.Odata.EdmInt64;
                        // Int64 / long should be serialized as string.
                        annotatedDictionary[item.Key] = item.Value.ToString();
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
        /// Cleans a List of Dictionaries of its Odata type annotations, while using them to cast its entities accordingly.
        /// </summary>
        internal static void CastAndRemoveAnnotations(this IReadOnlyList<IDictionary<string, object>> entityList)
        {
            var typeAnnotationsWithKeys = new Dictionary<string, (string typeAnnotation, string annotationKey)>();

            foreach (var entity in entityList)
            {
                entity.CastAndRemoveAnnotations(typeAnnotationsWithKeys);
            }
        }

        /// <summary>
        /// Cleans a Dictionary of its Odata type annotations, while using them to cast its entities accordingly.
        /// </summary>
        internal static void CastAndRemoveAnnotations(this IDictionary<string, object> entity, Dictionary<string, (string typeAnnotation, string annotationKey)>? typeAnnotationsWithKeys = null)
        {
            typeAnnotationsWithKeys ??= new Dictionary<string, (string typeAnnotation, string annotationKey)>();
            var spanOdataSuffix = TableConstants.Odata.OdataTypeString.AsSpan();

            typeAnnotationsWithKeys.Clear();

            foreach (var propertyName in entity.Keys)
            {
                var spanPropertyName = propertyName.AsSpan();
                var iSuffix = spanPropertyName.IndexOf(spanOdataSuffix);
                if (iSuffix > 0)
                {
                    // This property is an Odata annotation. Save it in the typeAnnoations dictionary.
                    typeAnnotationsWithKeys[spanPropertyName.Slice(0, iSuffix).ToString()] = (typeAnnotation: (entity[propertyName] as string)!, annotationKey: propertyName);
                }
            }

            // Iterate through the types that are serialized as string by default and Parse them as the correct type, as indicated by the type annotations.
            foreach (var annotation in typeAnnotationsWithKeys.Keys)
            {
                entity[annotation] = typeAnnotationsWithKeys[annotation].typeAnnotation switch
                {
                    TableConstants.Odata.EdmBinary => Convert.FromBase64String(entity[annotation] as string),
                    TableConstants.Odata.EdmDateTime => DateTimeOffset.Parse(entity[annotation] as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    TableConstants.Odata.EdmGuid => Guid.Parse(entity[annotation] as string),
                    TableConstants.Odata.EdmInt64 => long.Parse(entity[annotation] as string, CultureInfo.InvariantCulture),
                    _ => throw new NotSupportedException("Not supported type " + typeAnnotationsWithKeys[annotation])
                };

                // Remove the type annotation property from the dictionary.
                entity.Remove(typeAnnotationsWithKeys[annotation].annotationKey);
            }

            // The Timestamp property is not annotated, since it is a known system property
            // so we must cast it without a type annotation
            if (entity.TryGetValue(TableConstants.PropertyNames.TimeStamp, out var value) && value is string)
            {
                entity[TableConstants.PropertyNames.TimeStamp] = DateTimeOffset.Parse(entity[TableConstants.PropertyNames.TimeStamp] as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }

            // Remove odata metadata.
            entity.Remove(TableConstants.PropertyNames.OdataMetadata);

            // Set odata.etag as the proper ETag property
            if (entity.TryGetValue(TableConstants.PropertyNames.EtagOdata, out var etag))
            {
                entity[TableConstants.PropertyNames.ETag] = etag;
                entity.Remove(TableConstants.PropertyNames.EtagOdata);
            }
        }

        /// <summary>
        /// Converts a List of Dictionaries containing properties and Odata type annotations to a custom entity type.
        /// </summary>
        internal static List<T> ToTableEntityList<T>(this IReadOnlyList<IDictionary<string, object>> entityList) where T : class, ITableEntity, new()
        {
            PropertyInfo[] properties = s_propertyInfoCache.GetOrAdd(typeof(T), (type) =>
            {
                return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            });

            var result = new List<T>(entityList.Count);

            foreach (var entity in entityList)
            {
                var tableEntity = entity.ToTableEntity<T>(properties);

                result.Add(tableEntity);
            }

            return result;
        }

        /// <summary>
        /// Cleans a Dictionary of its Odata type annotations, while using them to cast its entities accordingly.
        /// </summary>
        internal static T ToTableEntity<T>(this IDictionary<string, object> entity, PropertyInfo[]? properties = null) where T : class, ITableEntity, new()
        {
            var result = new T();

            if (result is IDictionary<string, object> dictionary)
            {
                entity.CastAndRemoveAnnotations();

                foreach (var entProperty in entity.Keys)
                {
                    dictionary[entProperty] = entity[entProperty];
                }

                return result;
            }

            properties ??= s_propertyInfoCache.GetOrAdd(typeof(T), (type) =>
            {
                return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            });

            // Iterate through each property of the entity and set them as the correct type.
            foreach (var property in properties)
            {
                if (entity.TryGetValue(property.Name, out var propertyValue))
                {
                    if (typeActions.TryGetValue(property.PropertyType, out var propertyAction))
                    {
                        propertyAction(property, propertyValue, result);
                    }
                    else
                    {
                        if (property.PropertyType.IsEnum)
                        {
                            typeActions[typeof(Enum)](property, propertyValue, result);
                        }
                        else
                        {
                            property.SetValue(result, propertyValue);
                        }
                    }
                }
            }

            // Populate the ETag if present.
            if (entity.TryGetValue(TableConstants.PropertyNames.EtagOdata, out var etag))
            {
                result.ETag = new ETag((etag as string)!);
            }
            return result;
        }

        private static Dictionary<Type, Action<PropertyInfo, object, object>> typeActions = new Dictionary<Type, Action<PropertyInfo, object, object>>
        {
            {typeof(byte[]), (property, propertyValue, result) =>  property.SetValue(result, Convert.FromBase64String(propertyValue as string))},
            {typeof(long), (property, propertyValue, result) =>  property.SetValue(result, long.Parse(propertyValue as string, CultureInfo.InvariantCulture))},
            {typeof(long?), (property, propertyValue, result) =>  property.SetValue(result, long.Parse(propertyValue as string, CultureInfo.InvariantCulture))},
            {typeof(double), (property, propertyValue, result) =>  property.SetValue(result, propertyValue)},
            {typeof(double?), (property, propertyValue, result) =>  property.SetValue(result, propertyValue)},
            {typeof(bool), (property, propertyValue, result) =>  property.SetValue(result, (bool)propertyValue)},
            {typeof(bool?), (property, propertyValue, result) =>  property.SetValue(result, (bool?)propertyValue)},
            {typeof(Guid), (property, propertyValue, result) =>  property.SetValue(result, Guid.Parse(propertyValue as string))},
            {typeof(Guid?), (property, propertyValue, result) =>  property.SetValue(result, Guid.Parse(propertyValue as string))},
            {typeof(DateTimeOffset), (property, propertyValue, result) =>  property.SetValue(result, DateTimeOffset.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind))},
            {typeof(DateTimeOffset?), (property, propertyValue, result) =>  property.SetValue(result, DateTimeOffset.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind))},
            {typeof(DateTime), (property, propertyValue, result) =>  property.SetValue(result, DateTime.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind))},
            {typeof(DateTime?), (property, propertyValue, result) =>  property.SetValue(result, DateTime.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind))},
            {typeof(string), (property, propertyValue, result) =>  property.SetValue(result, propertyValue as string)},
            {typeof(int), (property, propertyValue, result) =>  property.SetValue(result, (int)propertyValue)},
            {typeof(int?), (property, propertyValue, result) =>  property.SetValue(result, (int?)propertyValue)},
            {typeof(Enum), (property, propertyValue, result) =>  property.SetValue(result, Enum.Parse(property.PropertyType, propertyValue as string ))},
        };
    }
}
