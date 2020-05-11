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
            var spanOdataSuffix = TableConstants.Odata.OdataTypeString.AsSpan();

            foreach (var entity in entityList)
            {
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
                        TableConstants.Odata.EdmDateTime => DateTime.Parse(entity[annotation] as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                        TableConstants.Odata.EdmGuid => Guid.Parse(entity[annotation] as string),
                        TableConstants.Odata.EdmInt64 => long.Parse(entity[annotation] as string, CultureInfo.InvariantCulture),
                        _ => throw new NotSupportedException("Not supported type " + typeAnnotationsWithKeys[annotation])
                    };

                    // Remove the type annotation property from the dictionary.
                    entity.Remove(typeAnnotationsWithKeys[annotation].annotationKey);
                }
            }
        }

        /// <summary>
        /// Cleans a Dictionary of its Odata type annotations, while using them to cast its entities accordingly.
        /// </summary>
        internal static void CastAndRemoveAnnotations(this IDictionary<string, object> entity)
        {
            var typeAnnotationsWithKeys = new Dictionary<string, (string typeAnnotation, string annotationKey)>();
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
                    TableConstants.Odata.EdmDateTime => DateTime.Parse(entity[annotation] as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    TableConstants.Odata.EdmGuid => Guid.Parse(entity[annotation] as string),
                    TableConstants.Odata.EdmInt64 => long.Parse(entity[annotation] as string, CultureInfo.InvariantCulture),
                    _ => throw new NotSupportedException("Not supported type " + typeAnnotationsWithKeys[annotation])
                };

                // Remove the type annotation property from the dictionary.
                entity.Remove(typeAnnotationsWithKeys[annotation].annotationKey);
            }
        }

        private static string ToOdataTypeString(this string name)
        {
            return $"{name}{TableConstants.Odata.OdataTypeString}";
        }
    }
}
