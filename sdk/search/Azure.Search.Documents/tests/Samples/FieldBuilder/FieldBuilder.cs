// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes.Models;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#else
using Microsoft.Spatial;
#endif

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Builds field definitions for a search index by reflecting over a user-defined model type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This <see cref="FieldBuilder"/> was ported from the Microsoft.Azure.Search.Service package
    /// to make migrating from using Microsoft.Azure.Search to Azure.Search.Documents easier.
    /// It also uses System.Text.Json instead of Newtonsoft.Json (JSON.NET).
    /// </para>
    /// <para>
    /// This is only a sample you can include in your code and future implementations may change
    /// to follow modern guidelines and design principles.
    /// </para>
    /// </remarks>
    public static class FieldBuilder
    {
        private static readonly IReadOnlyDictionary<Type, SearchFieldDataType> s_primitiveTypeMap =
            new ReadOnlyDictionary<Type, SearchFieldDataType>(
                new Dictionary<Type, SearchFieldDataType>()
                {
                    [typeof(string)] = SearchFieldDataType.String,
                    [typeof(int)] = SearchFieldDataType.Int32,
                    [typeof(long)] = SearchFieldDataType.Int64,
                    [typeof(double)] = SearchFieldDataType.Double,
                    [typeof(bool)] = SearchFieldDataType.Boolean,
                    [typeof(DateTime)] = SearchFieldDataType.DateTimeOffset,
                    [typeof(DateTimeOffset)] = SearchFieldDataType.DateTimeOffset,
#if EXPERIMENTAL_SPATIAL
                    [typeof(PointGeometry)] = SearchFieldDataType.GeographyPoint,
#else
                    [typeof(GeographyPoint)] = SearchFieldDataType.GeographyPoint,
#endif
                });

        private static readonly ISet<Type> s_unsupportedTypes =
            new HashSet<Type>
            {
                typeof(decimal),
            };

        private static JsonNamingPolicy CamelCaseResolver { get; } = JsonNamingPolicy.CamelCase;

        private static JsonNamingPolicy DefaultResolver { get; } = DefaultJsonNamingPolicy.Shared;

        /// <summary>
        /// Creates a collection of <see cref="SearchField"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <typeparam name="T">
        /// The type for which fields will be created, based on its properties.
        /// </typeparam>
        /// <returns>A collection of fields.</returns>
        public static IList<SearchField> BuildForType<T>() => BuildForType(typeof(T));

        /// <summary>
        /// Creates a collection of <see cref="SearchField"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <param name="modelType">
        /// The type for which fields will be created, based on its properties.
        /// </param>
        /// <returns>A collection of fields.</returns>
        public static IList<SearchField> BuildForType(Type modelType)
        {
            bool useCamelCase = SerializePropertyNamesAsCamelCaseAttribute.IsDefinedOnType(modelType);
            JsonNamingPolicy namingPolicy = useCamelCase
                ? CamelCaseResolver
                : DefaultResolver;
            return BuildForType(modelType, namingPolicy);
        }

        /// <summary>
        /// Creates a collection of <see cref="SearchField"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <typeparam name="T">
        /// The type for which fields will be created, based on its properties.
        /// </typeparam>
        /// <param name="namingPolicy">
        /// <see cref="JsonNamingPolicy"/> to use.
        /// This ensures that the field names are generated in a way that is
        /// consistent with the way the model will be serialized.
        /// </param>
        /// <returns>A collection of fields.</returns>
        public static IList<SearchField> BuildForType<T>(JsonNamingPolicy namingPolicy) => BuildForType(typeof(T), namingPolicy);

        /// <summary>
        /// Creates a collection of <see cref="SearchField"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <param name="modelType">
        /// The type for which fields will be created, based on its properties.
        /// </param>
        /// <param name="namingPolicy">
        /// <see cref="JsonNamingPolicy"/> to use.
        /// Contract resolver that the SearchIndexClient will use.
        /// This ensures that the field names are generated in a way that is
        /// consistent with the way the model will be serialized.
        /// </param>
        /// <returns>A collection of fields.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="modelType"/> or <paramref name="namingPolicy"/> is null.</exception>
        public static IList<SearchField> BuildForType(Type modelType, JsonNamingPolicy namingPolicy)
        {
            if (modelType is null)
            { throw new ArgumentNullException(nameof(modelType));
            }

            if (namingPolicy is null)
            { throw new ArgumentNullException(nameof(namingPolicy));
            }

            ArgumentException FailOnNonObjectDataType()
            {
                string errorMessage =
                    $"Type '{modelType}' does not have properties which map to fields of an Azure Search index. Please use a " +
                    "class or struct with public properties.";

                throw new ArgumentException(errorMessage, nameof(modelType));
            }

            if (ObjectInfo.TryGet(modelType, out ObjectInfo info))
            {
                if (info.Properties.Length == 0)
                {
                    throw FailOnNonObjectDataType();
                }

                // Use Stack to avoid a dependency on ImmutableStack for now.
                return BuildForTypeRecursive(modelType, info, namingPolicy, new Stack<Type>(new[] { modelType }));
            }

            throw FailOnNonObjectDataType();
        }

        private static IList<SearchField> BuildForTypeRecursive(
            Type modelType,
            ObjectInfo info,
            JsonNamingPolicy namingPolicy,
            Stack<Type> processedTypes)
        {
            SearchField BuildField(PropertyInfo prop)
            {
                static bool ShouldIgnore(Attribute attribute) =>
                    attribute is JsonIgnoreAttribute || attribute is FieldBuilderIgnoreAttribute;

                IList<Attribute> attributes = prop.GetCustomAttributes(true).Cast<Attribute>().ToArray();
                if (attributes.Any(ShouldIgnore))
                {
                    return null;
                }

                SearchField CreateComplexField(SearchFieldDataType dataType, Type underlyingClrType, ObjectInfo info)
                {
                    if (processedTypes.Contains(underlyingClrType))
                    {
                        // Skip recursive types.
                        return null;
                    }

                    processedTypes.Push(underlyingClrType);
                    try
                    {
                        IList<SearchField> subFields =
                            BuildForTypeRecursive(underlyingClrType, info, namingPolicy, processedTypes);

                        string fieldName = namingPolicy.ConvertName(prop.Name);

                        SearchField field = new SearchField(fieldName, dataType);
                        foreach (SearchField subField in subFields)
                        {
                            field.Fields.Add(subField);
                        }

                        return field;
                    }
                    finally
                    {
                        processedTypes.Pop();
                    }
                }

                SearchField CreateSimpleField(SearchFieldDataType SearchFieldDataType)
                {
                    string fieldName = namingPolicy.ConvertName(prop.Name);

                    SearchField field = new SearchField(fieldName, SearchFieldDataType);
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
                                field.IsHidden = !isRetrievableAttribute.IsRetrievable;
                                break;

                            case AnalyzerAttribute analyzerAttribute:
                                field.AnalyzerName = analyzerAttribute.Name;
                                break;

                            case SearchAnalyzerAttribute searchAnalyzerAttribute:
                                field.SearchAnalyzerName = searchAnalyzerAttribute.Name;
                                break;

                            case IndexAnalyzerAttribute indexAnalyzerAttribute:
                                field.IndexAnalyzerName = indexAnalyzerAttribute.Name;
                                break;

                            case SynonymMapsAttribute synonymMapsAttribute:
                                foreach (string synonymMapName in synonymMapsAttribute.SynonymMaps)
                                {
                                    field.SynonymMapNames.Add(synonymMapName);
                                }
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
                        $"Property '{prop.Name}' is of type '{prop.PropertyType}', which does not map to an " +
                        "Azure Search data type. Please use a supported data type or mark the property with [JsonIgnore] or " +
                        "[FieldBuilderIgnore] and define the field by creating a SearchField object.";

                    return new ArgumentException(errorMessage, nameof(modelType));
                }

                IDataTypeInfo dataTypeInfo = GetDataTypeInfo(prop.PropertyType, namingPolicy);

                return dataTypeInfo.Match(
                    onUnknownDataType: () => throw FailOnUnknownDataType(),
                    onSimpleDataType: CreateSimpleField,
                    onComplexDataType: CreateComplexField);
            }

            return info.Properties.Select(BuildField).Where(field => field != null).ToArray();
        }

        private static IDataTypeInfo GetDataTypeInfo(Type propertyType, JsonNamingPolicy namingPolicy)
        {
            static bool IsNullableType(Type type) =>
                type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (s_primitiveTypeMap.TryGetValue(propertyType, out SearchFieldDataType SearchFieldDataType))
            {
                return DataTypeInfo.Simple(SearchFieldDataType);
            }
            else if (IsNullableType(propertyType))
            {
                return GetDataTypeInfo(propertyType.GenericTypeArguments[0], namingPolicy);
            }
            else if (TryGetEnumerableElementType(propertyType, out Type elementType))
            {
                IDataTypeInfo elementTypeInfo = GetDataTypeInfo(elementType, namingPolicy);
                return DataTypeInfo.AsCollection(elementTypeInfo);
            }
            else if (ObjectInfo.TryGet(propertyType, out ObjectInfo info))
            {
                return DataTypeInfo.Complex(SearchFieldDataType.Complex, propertyType, info);
            }
            else
            {
                return DataTypeInfo.Unknown;
            }
        }

        private static bool TryGetEnumerableElementType(Type candidateType, out Type elementType)
        {
            static Type GetElementTypeIfIEnumerable(Type t) =>
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
                Func<SearchFieldDataType, T> onSimpleDataType,
                Func<SearchFieldDataType, Type, ObjectInfo, T> onComplexDataType);
        }

        private static class DataTypeInfo
        {
            public static IDataTypeInfo Unknown { get; } = new UnknownDataTypeInfo();

            public static IDataTypeInfo Simple(SearchFieldDataType SearchFieldDataType) => new SimpleDataTypeInfo(SearchFieldDataType);

            public static IDataTypeInfo Complex(SearchFieldDataType SearchFieldDataType, Type underlyingClrType, ObjectInfo info) =>
                new ComplexDataTypeInfo(SearchFieldDataType, underlyingClrType, info);

            public static IDataTypeInfo AsCollection(IDataTypeInfo dataTypeInfo) =>
                dataTypeInfo.Match(
                    onUnknownDataType: () => Unknown,
                    onSimpleDataType: SearchFieldDataType => Simple(SearchFieldDataType.Collection(SearchFieldDataType)),
                    onComplexDataType: (SearchFieldDataType, underlyingClrType, info) =>
                        Complex(SearchFieldDataType.Collection(SearchFieldDataType), underlyingClrType, info));

            private sealed class UnknownDataTypeInfo : IDataTypeInfo
            {
                public UnknownDataTypeInfo()
                {
                }

                public T Match<T>(
                    Func<T> onUnknownDataType,
                    Func<SearchFieldDataType, T> onSimpleDataType,
                    Func<SearchFieldDataType, Type, ObjectInfo, T> onComplexDataType)
                    => onUnknownDataType();
            }

            private sealed class SimpleDataTypeInfo : IDataTypeInfo
            {
                private readonly SearchFieldDataType _dataType;

                public SimpleDataTypeInfo(SearchFieldDataType SearchFieldDataType)
                {
                    _dataType = SearchFieldDataType;
                }

                public T Match<T>(
                    Func<T> onUnknownDataType,
                    Func<SearchFieldDataType, T> onSimpleDataType,
                    Func<SearchFieldDataType, Type, ObjectInfo, T> onComplexDataType)
                    => onSimpleDataType(_dataType);
            }

            private sealed class ComplexDataTypeInfo : IDataTypeInfo
            {
                private readonly SearchFieldDataType _dataType;
                private readonly Type _underlyingClrType;
                private readonly ObjectInfo _info;

                public ComplexDataTypeInfo(SearchFieldDataType SearchFieldDataType, Type underlyingClrType, ObjectInfo info)
                {
                    _dataType = SearchFieldDataType;
                    _underlyingClrType = underlyingClrType;
                    _info = info;
                }

                public T Match<T>(
                    Func<T> onUnknownDataType,
                    Func<SearchFieldDataType, T> onSimpleDataType,
                    Func<SearchFieldDataType, Type, ObjectInfo, T> onComplexDataType)
                    => onComplexDataType(_dataType, _underlyingClrType, _info);
            }
        }

        private class ObjectInfo
        {
            private ObjectInfo(Type type)
            {
                Properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }

            public static bool TryGet(Type type, out ObjectInfo info)
            {
                // Close approximation to Newtonsoft.Json.Serialization.DefaultContractResolver.
                if (!type.IsPrimitive && !type.IsEnum && !s_unsupportedTypes.Contains(type) && !s_primitiveTypeMap.ContainsKey(type) && !typeof(IEnumerable).IsAssignableFrom(type))
                {
                    info = new ObjectInfo(type);
                    return true;
                }

                info = null;
                return false;
            }

            public PropertyInfo[] Properties { get; }
        }

        private class DefaultJsonNamingPolicy : JsonNamingPolicy
        {
            public static JsonNamingPolicy Shared { get; } = new DefaultJsonNamingPolicy();

            public override string ConvertName(string name) => name;
        }
    }
}
