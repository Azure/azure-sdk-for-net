// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Core.Serialization;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Builds field definitions for a search index by reflecting over a user-defined model type.
    /// </summary>
    public class FieldBuilder
    {
        private const string HelpLink = "https://aka.ms/azsdk/net/search/fieldbuilder";

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
                    [typeof(GeoPoint)] = SearchFieldDataType.GeographyPoint,
                    [typeof(Single)] = SearchFieldDataType.Single
                });

        private static readonly ISet<Type> s_unsupportedTypes =
            new HashSet<Type>
            {
                typeof(decimal),
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldBuilder"/> class.
        /// </summary>
        public FieldBuilder()
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="ObjectSerializer"/> to use to generate field names that match JSON property names.
        /// You should use the same value as <see cref="SearchClientOptions.Serializer"/>.
        /// <see cref="JsonObjectSerializer"/> will be used if no value is provided.
        /// </summary>
        public ObjectSerializer Serializer { get; set; }

        /// <summary>
        /// Creates a list of <see cref="SearchField"/> objects corresponding to
        /// the properties of the type supplied.
        /// </summary>
        /// <param name="modelType">
        /// The type for which fields will be created, based on its properties.
        /// </param>
        /// <returns>A collection of fields.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="modelType"/>.</exception>
        public IList<SearchField> Build(Type modelType) =>
            BuildMapping(modelType).Values.ToList();

        /// <summary>
        /// Creates a dictionary mapping property names to the <see cref="SearchField"/> objects corresponding to the properties of the type supplied.
        /// </summary>
        /// <param name="modelType">
        /// The type for which fields will be created, based on its properties.
        /// </param>
        /// <returns>A collection of fields.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="modelType"/>.</exception>
        /// <remarks>This overload is used to find the Key field of a SearchIndex so we can associate indexing failures with actions.</remarks>
        internal IDictionary<string, SearchField> BuildMapping(Type modelType)
        {
            Argument.AssertNotNull(modelType, nameof(modelType));

            ArgumentException FailOnNonObjectDataType()
            {
                string errorMessage =
                    $"Type '{modelType}' does not have properties which map to fields of an Azure Search index. Please use a " +
                    "class or struct with public properties.";

                throw new ArgumentException(errorMessage, nameof(modelType));
            }

            Serializer ??= new JsonObjectSerializer();
            IMemberNameConverter nameProvider = Serializer as IMemberNameConverter ?? DefaultSerializedNameProvider.Shared;

            if (ObjectInfo.TryGet(modelType, nameProvider, out ObjectInfo info))
            {
                if (info.Properties.Length == 0)
                {
                    throw FailOnNonObjectDataType();
                }

                // Use Stack to avoid a dependency on ImmutableStack for now.
                return Build(modelType, info, nameProvider, new Stack<Type>(new[] { modelType }));
            }

            throw FailOnNonObjectDataType();
        }

        private static IDictionary<string, SearchField> Build(
            Type modelType,
            ObjectInfo info,
            IMemberNameConverter nameProvider,
            Stack<Type> processedTypes)
        {
            SearchField BuildField(ObjectPropertyInfo prop)
            {
                // The IMemberNameConverter will return null for implementation-specific ways of ignoring members.
                static bool ShouldIgnore(Attribute attribute) =>
                    attribute is FieldBuilderIgnoreAttribute;

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
                            Build(underlyingClrType, info, nameProvider, processedTypes).Values.ToList();

                        if (prop.SerializedName is null)
                        {
                            // Member is unsupported or ignored.
                            return null;
                        }

                        // Start with a ComplexField to make sure all properties default to language defaults.
                        SearchField field = new ComplexField(prop.SerializedName, dataType);
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
                    if (prop.SerializedName is null)
                    {
                        // Member is unsupported or ignored.
                        return null;
                    }

                    // Start with a SimpleField to make sure all properties default to language defaults.
                    SearchField field = new SimpleField(prop.SerializedName, SearchFieldDataType);
                    foreach (Attribute attribute in attributes)
                    {
                        switch (attribute)
                        {
                            case SearchableFieldAttribute searchableFieldAttribute:
                                ((ISearchFieldAttribute)searchableFieldAttribute).SetField(field);
                                break;

                            case SimpleFieldAttribute simpleFieldAttribute:
                                ((ISearchFieldAttribute)simpleFieldAttribute).SetField(field);
                                break;

                            case VectorSearchFieldAttribute vectorSearchFieldAttribute:
                                ((ISearchFieldAttribute)vectorSearchFieldAttribute).SetField(field);
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
                        "Azure Search data type. Please use a supported data type or mark the property with [FieldBuilderIgnore] " +
                        $"and define the field by creating a SearchField object. See {HelpLink} for more information.";

                    return new ArgumentException(errorMessage, nameof(modelType))
                    {
                        HelpLink = HelpLink,
                    };
                }

                IDataTypeInfo dataTypeInfo = GetDataTypeInfo(prop.PropertyType, nameProvider);

                return dataTypeInfo.Match(
                    onUnknownDataType: () => throw FailOnUnknownDataType(),
                    onSimpleDataType: CreateSimpleField,
                    onComplexDataType: CreateComplexField);
            }

            return info.Properties
                .Select(prop => (prop.Name, BuildField(prop)))
                .Where(pair => pair.Item2 != null)
                .ToDictionary(pair => pair.Name, pair => pair.Item2);
        }

        private static IDataTypeInfo GetDataTypeInfo(Type propertyType, IMemberNameConverter nameProvider)
        {
            static bool IsNullableType(Type type) =>
                type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (s_primitiveTypeMap.TryGetValue(propertyType, out SearchFieldDataType searchFieldDataType))
            {
                return DataTypeInfo.Simple(searchFieldDataType);
            }
            else if (SpatialProxyFactory.IsSupportedPoint(propertyType))
            {
                return DataTypeInfo.Simple(SearchFieldDataType.GeographyPoint);
            }
            else if (IsNullableType(propertyType))
            {
                return GetDataTypeInfo(propertyType.GenericTypeArguments[0], nameProvider);
            }
            else if (TryGetEnumerableElementType(propertyType, out Type elementType))
            {
                IDataTypeInfo elementTypeInfo = GetDataTypeInfo(elementType, nameProvider);
                return DataTypeInfo.AsCollection(elementTypeInfo);
            }
            else if (ObjectInfo.TryGet(propertyType, nameProvider, out ObjectInfo info))
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
            private ObjectInfo(ObjectPropertyInfo[] properties)
            {
                Properties = properties;
            }

            public static bool TryGet(Type type, IMemberNameConverter nameProvider, out ObjectInfo info)
            {
                // Close approximation to Newtonsoft.Json.Serialization.DefaultContractResolver that was used in Microsoft.Azure.Search.
                if (!type.IsPrimitive &&
                    !type.IsEnum &&
                    !s_unsupportedTypes.Contains(type) &&
                    !s_primitiveTypeMap.ContainsKey(type) &&
                    !SpatialProxyFactory.IsSupportedPoint(type) &&
                    !typeof(IEnumerable).IsAssignableFrom(type))
                {
                    const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

                    List<ObjectPropertyInfo> properties = new List<ObjectPropertyInfo>();
                    foreach (PropertyInfo property in type.GetProperties(bindingFlags))
                    {
                        string serializedName = nameProvider.ConvertMemberName(property);
                        if (serializedName != null)
                        {
                            properties.Add(new ObjectPropertyInfo(property, serializedName));
                        }
                    }

                    foreach (FieldInfo field in type.GetFields(bindingFlags))
                    {
                        string serializedName = nameProvider.ConvertMemberName(field);
                        if (serializedName != null)
                        {
                            properties.Add(new ObjectPropertyInfo(field, serializedName));
                        }
                    }

                    if (properties.Count != 0)
                    {
                        info = new ObjectInfo(properties.ToArray());
                        return true;
                    }
                }

                info = null;
                return false;
            }

            public ObjectPropertyInfo[] Properties { get; }
        }

        private struct ObjectPropertyInfo
        {
            private readonly MemberInfo _memberInfo;

            public ObjectPropertyInfo(PropertyInfo property, string serializedName)
            {
                Debug.Assert(serializedName != null, $"{nameof(serializedName)} cannot be null");

                _memberInfo = property;

                SerializedName = serializedName;
                PropertyType = property.PropertyType;
            }

            public ObjectPropertyInfo(FieldInfo field, string serializedName)
            {
                Debug.Assert(serializedName != null, $"{nameof(serializedName)} cannot be null");

                _memberInfo = field;

                SerializedName = serializedName;
                PropertyType = field.FieldType;
            }

            public string Name => _memberInfo.Name;

            public string SerializedName { get; }

            public Type PropertyType { get; }

            public static implicit operator MemberInfo(ObjectPropertyInfo property) =>
                property._memberInfo;

            public object[] GetCustomAttributes(bool inherit) =>
                _memberInfo.GetCustomAttributes(inherit);
        }

        private class DefaultSerializedNameProvider : IMemberNameConverter
        {
            public static IMemberNameConverter Shared { get; } = new DefaultSerializedNameProvider();

            private DefaultSerializedNameProvider()
            {
            }

            public string ConvertMemberName(MemberInfo member) => member?.Name;
        }
    }
}
