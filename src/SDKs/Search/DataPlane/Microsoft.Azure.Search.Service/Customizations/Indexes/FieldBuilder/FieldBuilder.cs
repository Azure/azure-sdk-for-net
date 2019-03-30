// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Spatial;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Builds field definitions for an Azure Search index by reflecting over a user-defined model type.
    /// </summary>
    public static class FieldBuilder
    {
        private static readonly IReadOnlyDictionary<Type, DataType> PrimitiveTypeMap =
            new ReadOnlyDictionary<Type, DataType>(
                new Dictionary<Type, DataType>()
                {
                    [typeof(string)] = DataType.String,
                    [typeof(int)] = DataType.Int32,
                    [typeof(long)] = DataType.Int64,
                    [typeof(double)] = DataType.Double,
                    [typeof(bool)] = DataType.Boolean,
                    [typeof(DateTime)] = DataType.DateTimeOffset,
                    [typeof(DateTimeOffset)] = DataType.DateTimeOffset,
                    [typeof(GeographyPoint)] = DataType.GeographyPoint
                });

        private static IContractResolver CamelCaseResolver { get; } = new CamelCasePropertyNamesContractResolver();

        private static IContractResolver DefaultResolver { get; } = new DefaultContractResolver();

        /// <summary>
        /// Creates a collection of <see cref="Field"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <typeparam name="T">
        /// The type for which fields will be created, based on its properties.
        /// </typeparam>
        /// <returns>A collection of fields.</returns>
        public static IList<Field> BuildForType<T>() => BuildForType(typeof(T));

        /// <summary>
        /// Creates a collection of <see cref="Field"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <param name="modelType">
        /// The type for which fields will be created, based on its properties.
        /// </param>
        /// <returns>A collection of fields.</returns>
        public static IList<Field> BuildForType(Type modelType)
        {
            bool useCamelCase = SerializePropertyNamesAsCamelCaseAttribute.IsDefinedOnType(modelType);
            IContractResolver resolver = useCamelCase
                ? CamelCaseResolver
                : DefaultResolver;
            return BuildForType(modelType, resolver);
        }

        /// <summary>
        /// Creates a collection of <see cref="Field"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <typeparam name="T">
        /// The type for which fields will be created, based on its properties.
        /// </typeparam>
        /// <param name="contractResolver">
        /// Contract resolver that the SearchIndexClient will use.
        /// This ensures that the field names are generated in a way that is
        /// consistent with the way the model will be serialized.
        /// </param>
        /// <returns>A collection of fields.</returns>
        public static IList<Field> BuildForType<T>(IContractResolver contractResolver) => BuildForType(typeof(T), contractResolver);

        /// <summary>
        /// Creates a collection of <see cref="Field"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <param name="modelType">
        /// The type for which fields will be created, based on its properties.
        /// </param>
        /// <param name="contractResolver">
        /// Contract resolver that the SearchIndexClient will use.
        /// This ensures that the field names are generated in a way that is
        /// consistent with the way the model will be serialized.
        /// </param>
        /// <returns>A collection of fields.</returns>
        public static IList<Field> BuildForType(Type modelType, IContractResolver contractResolver) =>
            BuildForTypeRecursive(modelType, contractResolver, new Stack<Type>(new[] { modelType }));   // Avoiding dependency on ImmutableStack for now.

        private static IList<Field> BuildForTypeRecursive(Type modelType, IContractResolver contractResolver, Stack<Type> processedTypes)
        {
            var contract = (JsonObjectContract)contractResolver.ResolveContract(modelType);
            var fields = new List<Field>();
            foreach (JsonProperty prop in contract.Properties)
            {
                IList<Attribute> attributes = prop.AttributeProvider.GetAttributes(true);
                if (attributes.Any(attr => attr is JsonIgnoreAttribute))
                {
                    continue;
                }

                DataTypeInfo dataTypeInfo = GetDataTypeInfo(prop.PropertyType);
                DataType dataType = dataTypeInfo.DataType;
                Type underlyingClrType = dataTypeInfo.UnderlyingClrType;

                if (processedTypes.Contains(underlyingClrType))
                {
                    // Skip recursive types.
                    continue;
                }

                Field CreateComplexField()
                {
                    try
                    {
                        processedTypes.Push(underlyingClrType);
                        IList<Field> subFields = BuildForTypeRecursive(underlyingClrType, contractResolver, processedTypes);
                        return new Field(prop.PropertyName, dataType, subFields);
                    }
                    finally
                    {
                        processedTypes.Pop();
                    }
                }

                Field CreateSimpleField()
                {
                    var field = new Field(prop.PropertyName, dataType);

                    foreach (Attribute attribute in attributes)
                    {
                        switch (attribute)
                        {
                            case IsSearchableAttribute _:
                                field.IsSearchable = true;
                                break;

                            case IsFilterableAttribute _:
                                field.IsFilterable = true;
                                break;

                            case IsSortableAttribute _:
                                field.IsSortable = true;
                                break;

                            case IsFacetableAttribute _:
                                field.IsFacetable = true;
                                break;

                            case IsRetrievableAttribute isRetrievableAttribute:
                                field.IsRetrievable = isRetrievableAttribute.IsRetrievable;
                                break;

                            case AnalyzerAttribute analyzerAttribute:
                                field.Analyzer = analyzerAttribute.Name;
                                break;

                            case SearchAnalyzerAttribute searchAnalyzerAttribute:
                                field.SearchAnalyzer = searchAnalyzerAttribute.Name;
                                break;

                            case IndexAnalyzerAttribute indexAnalyzerAttribute:
                                field.IndexAnalyzer = indexAnalyzerAttribute.Name;
                                break;

                            case SynonymMapsAttribute synonymMapsAttribute:
                                field.SynonymMaps = synonymMapsAttribute.SynonymMaps;
                                break;

                            default:
                                // Match on name to avoid dependency - don't want to force people not using
                                // this feature to bring in the annotations component.
                                Type attributeType = attribute.GetType();
                                if (attributeType.FullName == "System.ComponentModel.DataAnnotations.KeyAttribute")
                                {
                                    field.IsKey = true;
                                }
                                break;
                        }
                    }

                    return field;
                }

                fields.Add(dataType.IsComplex() ? CreateComplexField() : CreateSimpleField());
            }

            return fields;
        }

        private static DataTypeInfo GetDataTypeInfo(Type propertyType)
        {
            bool IsNullableType(Type type) =>
                type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (PrimitiveTypeMap.TryGetValue(propertyType, out DataType dataType))
            {
                return new DataTypeInfo(dataType, propertyType);
            }
            else if (IsNullableType(propertyType))
            {
                return GetDataTypeInfo(propertyType.GenericTypeArguments[0]);
            }
            else if (TryGetEnumerableElementType(propertyType, out Type elementType))
            {
                DataTypeInfo elementTypeInfo = GetDataTypeInfo(elementType);
                return new DataTypeInfo(DataType.Collection(elementTypeInfo.DataType), elementTypeInfo.UnderlyingClrType);
            }
            else
            {
                return new DataTypeInfo(DataType.Complex, propertyType);
            }
        }

        private static bool TryGetEnumerableElementType(Type candidateType, out Type elementType)
        {
            Type GetElementTypeIfIEnumerable(Type t) =>
                t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                    ? t.GenericTypeArguments[0]
                    : null;

            elementType = GetElementTypeIfIEnumerable(candidateType);
            if (elementType != null)
            {
                return true;
            }
            else
            {
                TypeInfo ti = candidateType.GetTypeInfo();
                var listElementTypes = ti
                    .ImplementedInterfaces
                    .Select(GetElementTypeIfIEnumerable)
                    .Where(p => p != null)
                    .ToList();

                if (listElementTypes.Count == 1)
                {
                    elementType = listElementTypes[0];
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Avoid dependency on ValueTuple for now.
        private struct DataTypeInfo
        {
            public DataTypeInfo(DataType dataType, Type underlyingClrType)
            {
                DataType = dataType;
                UnderlyingClrType = underlyingClrType;
            }

            public DataType DataType { get; }

            public Type UnderlyingClrType { get; }
        }
    }
}
