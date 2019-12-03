// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Search
{
    /// <summary>
    /// Builds field definitions for a search index by reflecting over a user-defined model type.
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
        public static IList<Field> BuildForType(Type modelType, IContractResolver contractResolver)
        {
            ArgumentException FailOnNonObjectDataType()
            {
                string errorMessage =
                    $"Type '{modelType}' does not have properties which map to fields of an Azure Search index. Please use a " +
                    "class or struct with public properties.";

                throw new ArgumentException(errorMessage, nameof(modelType));
            }

            if (contractResolver.ResolveContract(modelType) is JsonObjectContract contract)
            {
                if (contract.Properties.Count == 0)
                {
                    throw FailOnNonObjectDataType();
                }

                // Use Stack to avoid a dependency on ImmutableStack for now.
                return BuildForTypeRecursive(modelType, contract, contractResolver, new Stack<Type>(new[] { modelType }));
            }

            throw FailOnNonObjectDataType();
        }

        private static IList<Field> BuildForTypeRecursive(
            Type modelType,
            JsonObjectContract contract,
            IContractResolver contractResolver,
            Stack<Type> processedTypes)
        {
            Field BuildField(JsonProperty prop)
            {
                bool ShouldIgnore(Attribute attribute) =>
                    attribute is JsonIgnoreAttribute || attribute is FieldBuilderIgnoreAttribute;

                IList<Attribute> attributes = prop.AttributeProvider.GetAttributes(true);
                if (attributes.Any(ShouldIgnore))
                {
                    return null;
                }

                Field CreateComplexField(DataType dataType, Type underlyingClrType, JsonObjectContract jsonObjectContract)
                {
                    try
                    {
                        if (processedTypes.Contains(underlyingClrType))
                        {
                            // Skip recursive types.
                            return null;
                        }

                        processedTypes.Push(underlyingClrType);
                        IList<Field> subFields =
                            BuildForTypeRecursive(underlyingClrType, jsonObjectContract, contractResolver, processedTypes);
                        return new Field(prop.PropertyName, dataType, subFields);
                    }
                    finally
                    {
                        processedTypes.Pop();
                    }
                }

                Field CreateSimpleField(DataType dataType)
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
                                Type attributeType = attribute.GetType();

                                // Match on name to avoid dependency - don't want to force people not using
                                // this feature to bring in the annotations component.
                                //
                                // Also, ignore key attributes on sub-fields.
                                if (attributeType.FullName == "System.ComponentModel.DataAnnotations.KeyAttribute" &&
                                    processedTypes.Count <= 1)
                                {
                                    field.IsKey = true;
                                }
                                break;
                        }
                    }

                    return field;
                }

                ArgumentException FailOnUnknownDataType()
                {
                    string errorMessage =
                        $"Property '{prop.PropertyName}' is of type '{prop.PropertyType}', which does not map to an " +
                        "Azure Search data type. Please use a supported data type or mark the property with [JsonIgnore] or " +
                        "[FieldBuilderIgnore] and define the field by creating a Field object.";

                    return new ArgumentException(errorMessage, nameof(modelType));
                }

                IDataTypeInfo dataTypeInfo = GetDataTypeInfo(prop.PropertyType, contractResolver);

                return dataTypeInfo.Match(
                    onUnknownDataType: () => throw FailOnUnknownDataType(),
                    onSimpleDataType: CreateSimpleField,
                    onComplexDataType: CreateComplexField);
            }

            return contract.Properties.Select(BuildField).Where(field => field != null).ToArray();
        }

        private static IDataTypeInfo GetDataTypeInfo(Type propertyType, IContractResolver contractResolver)
        {
            bool IsNullableType(Type type) =>
                type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (PrimitiveTypeMap.TryGetValue(propertyType, out DataType dataType))
            {
                return DataTypeInfo.Simple(dataType);
            }
            else if (IsNullableType(propertyType))
            {
                return GetDataTypeInfo(propertyType.GenericTypeArguments[0], contractResolver);
            }
            else if (TryGetEnumerableElementType(propertyType, out Type elementType))
            {
                IDataTypeInfo elementTypeInfo = GetDataTypeInfo(elementType, contractResolver);
                return DataTypeInfo.AsCollection(elementTypeInfo);
            }
            else if (contractResolver.ResolveContract(propertyType) is JsonObjectContract jsonContract)
            {
                return DataTypeInfo.Complex(DataType.Complex, propertyType, jsonContract);
            }
            else
            {
                return DataTypeInfo.Unknown;
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

        private interface IDataTypeInfo
        {
            T Match<T>(
                Func<T> onUnknownDataType,
                Func<DataType, T> onSimpleDataType,
                Func<DataType, Type, JsonObjectContract, T> onComplexDataType);
        }

        private static class DataTypeInfo
        {
            public static IDataTypeInfo Unknown { get; } = new UnknownDataTypeInfo();

            public static IDataTypeInfo Simple(DataType dataType) => new SimpleDataTypeInfo(dataType);

            public static IDataTypeInfo Complex(DataType dataType, Type underlyingClrType, JsonObjectContract jsonContract) =>
                new ComplexDataTypeInfo(dataType, underlyingClrType, jsonContract);

            public static IDataTypeInfo AsCollection(IDataTypeInfo dataTypeInfo) =>
                dataTypeInfo.Match(
                    onUnknownDataType: () => Unknown,
                    onSimpleDataType: dataType => Simple(DataType.Collection(dataType)),
                    onComplexDataType: (dataType, underlyingClrType, jsonContract) =>
                        Complex(DataType.Collection(dataType), underlyingClrType, jsonContract));

            private sealed class UnknownDataTypeInfo : IDataTypeInfo
            {
                public UnknownDataTypeInfo()
                {
                }

                public T Match<T>(
                    Func<T> onUnknownDataType,
                    Func<DataType, T> onSimpleDataType,
                    Func<DataType, Type, JsonObjectContract, T> onComplexDataType)
                    => onUnknownDataType();
            }

            private sealed class SimpleDataTypeInfo : IDataTypeInfo
            {
                private readonly DataType _dataType;

                public SimpleDataTypeInfo(DataType dataType)
                {
                    _dataType = dataType;
                }

                public T Match<T>(
                    Func<T> onUnknownDataType,
                    Func<DataType, T> onSimpleDataType,
                    Func<DataType, Type, JsonObjectContract, T> onComplexDataType)
                    => onSimpleDataType(_dataType);
            }

            private sealed class ComplexDataTypeInfo : IDataTypeInfo
            {
                private readonly DataType _dataType;
                private readonly Type _underlyingClrType;
                private readonly JsonObjectContract _jsonContract;

                public ComplexDataTypeInfo(DataType dataType, Type underlyingClrType, JsonObjectContract jsonContract)
                {
                    _dataType = dataType;
                    _underlyingClrType = underlyingClrType;
                    _jsonContract = jsonContract;
                }

                public T Match<T>(
                    Func<T> onUnknownDataType,
                    Func<DataType, T> onSimpleDataType,
                    Func<DataType, Type, JsonObjectContract, T> onComplexDataType)
                    => onComplexDataType(_dataType, _underlyingClrType, _jsonContract);
            }
        }
    }
}
