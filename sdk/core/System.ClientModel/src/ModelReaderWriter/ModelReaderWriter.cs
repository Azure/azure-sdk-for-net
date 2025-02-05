// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides functionality to read and write <see cref="IPersistableModel{T}"/> and <see cref="IJsonModel{T}"/>.
/// </summary>
public static class ModelReaderWriter
{
    private static readonly HashSet<Type> s_supportedCollectionTypes =
    [
        typeof(List<>),
        typeof(Dictionary<,>)
    ];

    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to write.</typeparam>
    /// <param name="model">The model to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    public static BinaryData Write<T>(T model, ModelReaderWriterOptions? options = default)
        where T : IPersistableModel<T>
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        options ??= ModelReaderWriterOptions.Json;

        if (ShouldWriteAsJson(model, options, out IJsonModel<T>? jsonModel))
        {
            using (UnsafeBufferSequence.Reader reader = new ModelWriter<T>(jsonModel, options).ExtractReader())
            {
                return reader.ToBinaryData();
            }
        }
        else
        {
            return model.Write(options);
        }
    }

    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <param name="model">The model to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    public static BinaryData Write(object model, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        options ??= ModelReaderWriterOptions.Json;
        if (model is IPersistableModel<object> iModel && !ShouldWriteAsJson(iModel, options, out _))
        {
            return iModel.Write(options);
        }
        else
        {
            using UnsafeBufferSequence sequenceWriter = new();
            using Utf8JsonWriter writer = new(sequenceWriter);
            WriteJson(model, options, writer);
            writer.Flush();
            return sequenceWriter.ExtractReader().ToBinaryData();
        }
    }

    private static void WriteJson(object model, ModelReaderWriterOptions options, Utf8JsonWriter writer)
    {
        if (model is IPersistableModel<object> iModel && ShouldWriteAsJson(iModel, options, out IJsonModel<object>? jsonModel))
        {
            jsonModel.Write(writer, options);
        }
        else if (model is IEnumerable enumerable)
        {
            WriteEnumerable(options, enumerable, writer);
        }
        else
        {
            throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IPersistableModel<object>)} or {nameof(IEnumerable<IPersistableModel<object>>)}");
        }
    }

    private static void WriteEnumerable(ModelReaderWriterOptions options, IEnumerable enumerable, Utf8JsonWriter writer)
    {
        var enumerableType = enumerable.GetType();

        if (enumerableType.IsArray && enumerableType.GetArrayRank() > 1 && enumerableType.GetElementType()?.IsArray == false) //multi-dimensional array
        {
            Array array = (Array)enumerable;
            WriteMultiDimensionalArray(array, new int[array.Rank], 0, options, writer);
        }
        else
        {
            if (enumerable is IDictionary dictionary)
            {
                writer.WriteStartObject();
                foreach (var key in dictionary.Keys)
                {
                    writer.WritePropertyName(key.ToString()!);
                    WriteJson(dictionary[key]!, options, writer);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in enumerable)
                {
                    WriteJson(item, options, writer);
                }
                writer.WriteEndArray();
            }
        }
    }

    private static void WriteMultiDimensionalArray(Array array, int[] indices, int currentDimension, ModelReaderWriterOptions options, Utf8JsonWriter writer)
    {
        // If we've reached the innermost dimension, print the value at the collected indices
        if (currentDimension == array.Rank)
        {
            WriteJson(array.GetValue(indices)!, options, writer);
            return;
        }

        writer.WriteStartArray();
        // Recursively iterate through each level
        for (int i = 0; i < array.GetLength(currentDimension); i++)
        {
            indices[currentDimension] = i;
            WriteMultiDimensionalArray(array, indices, currentDimension + 1, options, writer);
        }
        writer.WriteEndArray();
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
    /// <exception cref="MissingMethodException">If <typeparamref name="T"/> does not have a public or non public empty constructor.</exception>
    public static T? Read<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(
        BinaryData data,
        ModelReaderWriterOptions? options = default)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        options ??= ModelReaderWriterOptions.Json;

        Type typeOfT = typeof(T);

        if (typeOfT.IsArray)
        {
            throw new ArgumentException("Arrays are not supported. Use List<> instead.", nameof(T));
        }

        var genericType = typeOfT.IsGenericType ? typeOfT.GetGenericTypeDefinition() : null;

        if (genericType is not null)
        {
            if (!s_supportedCollectionTypes.Contains(genericType))
            {
                throw new ArgumentException($"Collection Type {typeOfT.Name} is not supported.", nameof(T));
            }

            return (T)ReadCollection(data, typeOfT, nameof(T), options);
        }
        else
        {
            var iModel = GetInstance(typeOfT) as IPersistableModel<T>;
            return iModel!.Create(data, options);
        }
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="returnType">The type of the object to convert and return.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
    /// <exception cref="MissingMethodException">If <paramref name="returnType"/> does not have a public or non public empty constructor.</exception>
    public static object? Read(
        BinaryData data,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType,
        ModelReaderWriterOptions? options = default)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (returnType is null)
        {
            throw new ArgumentNullException(nameof(returnType));
        }

        if (returnType.IsArray)
        {
            throw new ArgumentException("Arrays are not supported. Use List<> instead.", nameof(returnType));
        }

        options ??= ModelReaderWriterOptions.Json;

        var genericType = returnType.IsGenericType ? returnType.GetGenericTypeDefinition() : null;

        if (genericType is not null)
        {
            if (!s_supportedCollectionTypes.Contains(genericType))
            {
                throw new ArgumentException($"Collection Type {returnType.Name} is not supported.", nameof(returnType));
            }

            return ReadCollection(data, returnType, nameof(returnType), options);
        }
        else
        {
            return GetInstance(returnType).Create(data, options);
        }
    }

    private static object ReadCollection(BinaryData data, Type returnType, string paramName, ModelReaderWriterOptions options)
    {
        object collection = CallActivator(returnType);
        Utf8JsonReader reader = new Utf8JsonReader(data);
        reader.Read();
        var genericType = returnType.GetGenericTypeDefinition();
        if (genericType.Equals(typeof(Dictionary<,>)))
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new FormatException("Expected start of dictionary.");
            }
        }
        else if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new FormatException("Expected start of array.");
        }
        ReadJsonCollection(ref reader, collection, 1, paramName, options);
        return collection;
    }

    private static void ReadJsonCollection(ref Utf8JsonReader reader, object collection, int depth, string paramName, ModelReaderWriterOptions options)
    {
        int argNumber = collection is IDictionary ? 1 : 0;
        Type elementType = collection.GetType().GetGenericArguments()[argNumber];
        if (elementType.IsArray)
        {
            throw new ArgumentException("Arrays are not supported. Use List<> instead.");
        }
        Type? elementGenericType = elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : null;
        if (elementGenericType is not null && !s_supportedCollectionTypes.Contains(elementGenericType))
        {
            throw new ArgumentException($"Collection Type {elementGenericType.Name} is not supported.", paramName);
        }

        bool isElementDictionary = elementGenericType is not null && elementGenericType.Equals(typeof(Dictionary<,>));

        var persistableModel = GetObjectInstance(elementType) as IPersistableModel<object>;
        IJsonModel<object>? iJsonModel = null;
        if (elementGenericType is null && (persistableModel is null || !ShouldWriteAsJson(persistableModel, options, out iJsonModel)))
        {
            throw new InvalidOperationException($"Element type {elementType.Name} must implement IJsonModel<>.");
        }
        bool isInnerCollection = iJsonModel is null;
        string? propertyName = null;

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartObject:
                    if (isInnerCollection)
                    {
                        if (isElementDictionary)
                        {
                            var innerDictionary = CallActivator(elementType);
                            AddItemToCollection(collection, propertyName, innerDictionary);
                            ReadJsonCollection(ref reader, innerDictionary, depth++, paramName, options);
                        }
                        else
                        {
                            throw new FormatException("Unexpected StartObject found.");
                        }
                    }
                    else
                    {
                        AddItemToCollection(collection, propertyName, iJsonModel!.Create(ref reader, options));
                    }
                    break;
                case JsonTokenType.StartArray:
                    if (!isInnerCollection || isElementDictionary)
                    {
                        throw new FormatException("Unexpected StartArray found.");
                    }

                    object innerList = CallActivator(elementType);
                    AddItemToCollection(collection, propertyName, innerList);
                    ReadJsonCollection(ref reader, innerList, depth++, paramName, options);
                    break;
                case JsonTokenType.EndArray:
                    if (--depth == 0)
                    {
                        return;
                    }
                    break;
                case JsonTokenType.PropertyName:
                    propertyName = reader.GetString();
                    break;
                case JsonTokenType.EndObject:
                    return;
                default:
                    throw new FormatException($"Unexpected token {reader.TokenType}.");
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static object CallActivator(Type typeToActivate, bool nonPublic = false)
    {
        var obj = Activator.CreateInstance(typeToActivate, nonPublic);
        if (obj is null)
        {
            //we should never get here, but just in case
            throw new InvalidOperationException($"Unable to create instance of {typeToActivate.Name}.");
        }

        return obj;
    }

    private static void AddItemToCollection(object collection, string? key, object item)
    {
        if (collection is IDictionary dictionary)
        {
            if (key is null)
            {
                //we should never get here because System.Text.Json will throw JsonReaderException if there was no property name
                throw new FormatException("Null key found for dictionary entry.");
            }
            dictionary.Add(key, item);
        }
        else if (collection is IList list)
        {
            list.Add(item);
        }
        else
        {
            //we should never be able to get here since we check for supported collection types in ReadCollection
            throw new InvalidOperationException($"Collection type {collection.GetType().Name} is not supported.");
        }
    }

    private static IPersistableModel<object> GetInstance(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        var model = GetObjectInstance(returnType) as IPersistableModel<object>;
        if (model is null)
        {
            throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IPersistableModel<object>)}");
        }
        return model;
    }

    internal static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        PersistableModelProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(PersistableModelProxyAttribute), false) as PersistableModelProxyAttribute;
        Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

        if (returnType.IsAbstract && attribute is null)
        {
            throw new InvalidOperationException($"{returnType.Name} must be decorated with {nameof(PersistableModelProxyAttribute)} to be used with {nameof(ModelReaderWriter)}");
        }

        return CallActivator(typeToActivate, true);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ShouldWriteAsJson<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
        => ShouldWriteAsJson(model, options, out _);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ShouldWriteAsJson<T>(IPersistableModel<T> model, ModelReaderWriterOptions options, [MaybeNullWhen(false)] out IJsonModel<T> jsonModel)
    {
        if (IsJsonFormatRequested(model, options) && model is IJsonModel<T> iJsonModel)
        {
            jsonModel = iJsonModel;
            return true;
        }

        jsonModel = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ShouldWriteAsJson(IPersistableModel<object> model, ModelReaderWriterOptions options, [MaybeNullWhen(false)] out IJsonModel<object> jsonModel)
        => ShouldWriteAsJson<object>(model, options, out jsonModel);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsJsonFormatRequested<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
        => options.Format == "J" || (options.Format == "W" && model.GetFormatFromOptions(options) == "J");
}
