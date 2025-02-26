// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides functionality to read and write <see cref="IPersistableModel{T}"/> and <see cref="IJsonModel{T}"/>.
/// </summary>
public static class ModelReaderWriter
{
    internal static readonly HashSet<Type> s_supportedCollectionTypes =
    [
        typeof(List<>),
        typeof(Dictionary<,>)
    ];

    private delegate object ObjectActivator(Type typeToActivate);
    private delegate IPersistableModel<object> PersistableModelActivator(Type typeToActivate);

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

        if (model is IPersistableModel<object> iModel)
        {
            if (ShouldWriteAsJson(iModel, options, out IJsonModel<object>? jsonModel))
            {
                using (UnsafeBufferSequence.Reader reader = new ModelWriter(jsonModel, options).ExtractReader())
                {
                    return reader.ToBinaryData();
                }
            }
            else
            {
                return iModel.Write(options);
            }
        }
        else if (model is IEnumerable enumerable)
        {
            var collectionWriter = CollectionWriter.GetCollectionWriter(enumerable, options);
            return collectionWriter.Write(enumerable, options);
        }
        else
        {
            throw new InvalidOperationException($"{model.GetType().FullName} must implement IEnumerable or IPersistableModel");
        }
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
        where T : IPersistableModel<T>
    {
        return ReadInternal<T>(
            data,
            new ReflectionContext(),
            options);
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="context"> The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
    /// <exception cref="MissingMethodException">If <typeparamref name="T"/> does not have a public or non public empty constructor.</exception>
    public static T? Read<T>(
        BinaryData data,
        ModelReaderWriterContext context,
        ModelReaderWriterOptions? options = default)
    {
        return ReadInternal<T>(
            data,
            context,
            options);
    }

    private static T? ReadInternal<T>(
        BinaryData data,
        IActivatorFactory activatorFactory,
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

            var collectionReader = CollectionReader.GetCollectionReader(typeOfT, data, activatorFactory, nameof(T), options);
            return (T)collectionReader.Read(typeOfT, data, activatorFactory, options);
        }
        else
        {
            var iModel = GetInstance(typeOfT, activatorFactory) as IPersistableModel<T>;
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
        return ReadInternal(
            data,
            returnType,
            new ReflectionContext(),
            options);
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="returnType">The type of the object to convert and return.</param>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
    /// <exception cref="MissingMethodException">If <paramref name="returnType"/> does not have a public or non public empty constructor.</exception>
    public static object? Read(
        BinaryData data,
        Type returnType,
        ModelReaderWriterContext context,
        ModelReaderWriterOptions? options = default)
    {
        return ReadInternal(
            data,
            returnType,
            context,
            options);
    }

    private static object? ReadInternal(
        BinaryData data,
        Type returnType,
        IActivatorFactory activatorFactory,
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

            var collectionReader = CollectionReader.GetCollectionReader(returnType, data, activatorFactory, nameof(returnType), options);
            return collectionReader.Read(returnType, data, activatorFactory, options);
        }
        else
        {
            var iModel = GetInstance(returnType, activatorFactory);
            return iModel!.Create(data, options);
        }
    }

    internal static IPersistableModel<object> GetInstance(Type returnType, IActivatorFactory activatorFactory)
    {
        var model = activatorFactory.CreateObject(returnType) as IPersistableModel<object>;
        if (model is null)
        {
            throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IPersistableModel<object>)}");
        }
        return model;
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
