// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides functionality to read and write <see cref="IPersistableModel{T}"/> and <see cref="IJsonModel{T}"/>.
/// </summary>
public static class ModelReaderWriter
{
    private static readonly Lazy<ReflectionContext> s_reflectionContext = new(() => new());

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

        return WritePersistable(model, options);
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

        //temp blocking this for symetry of functionality on read/write with no context.
        //will be allowed after https://github.com/Azure/azure-sdk-for-net/issues/48294
        if (model is IPersistableModel<object> iModel)
        {
            return WritePersistable(iModel, options);
        }
        else
        {
            throw new InvalidOperationException($"{model.GetType().Name} does not implement IPersistableModel");
        }
    }

    /// <summary>
    /// Writes the model into the provided <see cref="Stream"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Write<T>(T model, Stream stream, ModelReaderWriterOptions? options = default)
        where T : IStreamModel<T>
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        options ??= ModelReaderWriterOptions.Json;

        WriteStreamModel(model, stream, options);
    }

    /// <summary>
    /// Writes the model into the provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static void Write(object model, Stream stream, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        options ??= ModelReaderWriterOptions.Json;

        //temp blocking this for symetry of functionality on read/write with no context.
        //will be allowed after https://github.com/Azure/azure-sdk-for-net/issues/48294
        if (model is IStreamModel<object> iModel)
        {
            WriteStreamModel(iModel, stream, options);
        }
        else
        {
            throw new InvalidOperationException($"{model.GetType().Name} does not implement IStreamModel");
        }
    }

    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to write.</typeparam>
    /// <param name="model">The model to convert.</param>
    /// <param name="context"> The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    public static BinaryData Write<T>(T model, ModelReaderWriterContext context, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        options ??= ModelReaderWriterOptions.Json;

        return WritePersistableOrEnumerable(model, context, options);
    }

    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <param name="model">The model to convert.</param>
    /// <param name="context"> The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    public static BinaryData Write(object model, ModelReaderWriterContext context, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        options ??= ModelReaderWriterOptions.Json;

        return WritePersistableOrEnumerable(model, context, options);
    }

    /// <summary>
    /// Writes the model into the provided <see cref="Stream"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <param name="stream"></param>
    /// <param name="context"></param>
    /// <param name="options"></param>
    public static void Write<T>(T model, Stream stream, ModelReaderWriterContext context, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        options ??= ModelReaderWriterOptions.Json;

        WriteStreamModelOrEnumerable(model, stream, context, options);
    }

    /// <summary>
    /// Writes the model into the provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="stream"></param>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Write(object model, Stream stream, ModelReaderWriterContext context, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        options ??= ModelReaderWriterOptions.Json;

        WriteStreamModelOrEnumerable(model, stream, context, options);
    }

    private static BinaryData WritePersistableOrEnumerable<T>(T model, ModelReaderWriterContext context, ModelReaderWriterOptions options)
    {
        if (model is IPersistableModel<T> iModel)
        {
            return WritePersistable(iModel, options);
        }
        else
        {
            if (TryWriteEnumerable(model, context, options, out BinaryData? data) && data != null)
            {
                return data;
            }
            else
            {
                throw new InvalidOperationException($"{model!.GetType().Name} must implement IEnumerable or IPersistableModel");
            }
        }
    }

    private static BinaryData WritePersistable<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
    {
        if (TryWriteJson(model, options, out BinaryData? data) && data != null)
        {
            return data;
        }
        else
        {
            return model.Write(options);
        }
    }

    private static void WriteStreamModelOrEnumerable<T>(
        T model,
        Stream stream,
        ModelReaderWriterContext context,
        ModelReaderWriterOptions options)
    {
        if (model is IStreamModel<T> iModel)
        {
            WriteStreamModel(iModel, stream, options);
            return;
        }
        else
        {
            if (TryWriteEnumerable(model, context, options, out _, stream))
            {
                return;
            }
            else
            {
                throw new InvalidOperationException($"{model!.GetType().Name} must implement IEnumerable or IStreamModel");
            }
        }
    }

    private static void WriteStreamModel<T>(IStreamModel<T> model, Stream stream, ModelReaderWriterOptions options)
    {
        if (TryWriteJson(model, options, out _, stream))
        {
            return;
        }
        else
        {
            model.Write(stream, options);
        }

        return;
    }

    private static bool TryWriteJson<T>(
        IPersistableModel<T> model,
        ModelReaderWriterOptions options,
        out BinaryData? data,
        Stream? stream = default)
    {
        data = null;

        if (ShouldWriteAsJson(model, options, out IJsonModel<T>? jsonModel))
        {
            var writer = new ModelWriter<T>(jsonModel, options);
            if (stream != null)
            {
                writer.WriteTo(stream);
                return true;
            }

            using var reader = writer.ExtractReader();
            data = reader.ToBinaryData();
            return true;
        }

        return false;
    }

    private static bool TryWriteEnumerable<T>(
        T model,
        ModelReaderWriterContext context,
        ModelReaderWriterOptions options,
        out BinaryData? data,
        Stream? stream = default)
    {
        data = null;

        var enumerable = model as IEnumerable ?? context.GetModelBuilder(model!.GetType()).GetEnumerable(model);
        if (enumerable != null)
        {
            var collectionWriter = CollectionWriter.GetCollectionWriter(enumerable, options);
            if (stream != null)
            {
                collectionWriter.WriteTo(enumerable, stream, options);
                return true;
            }

            data = collectionWriter.Write(enumerable, options);
            return true;
        }

        return false;
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
            s_reflectionContext.Value,
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
            s_reflectionContext.Value,
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

    private static T? ReadInternal<T>(
        BinaryData data,
        ModelReaderWriterContext context,
        ModelReaderWriterOptions? options = default)
    {
        var obj = ReadInternal(data, typeof(T), context, options);
        return obj is null ? (T?)obj : (T)obj;
    }

    private static object? ReadInternal(
        BinaryData data,
        Type returnType,
        ModelReaderWriterContext context,
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

        options ??= ModelReaderWriterOptions.Json;

        var returnObj = context.GetModelBuilder(returnType).CreateObject();
        if (returnObj is CollectionWrapper builder)
        {
            var collectionReader = CollectionReader.GetCollectionReader(builder, options);
            return collectionReader.Read(builder, data, context, options);
        }
        else if (returnObj is IPersistableModel<object> persistableModel)
        {
            return persistableModel.Create(data, options);
        }
        else
        {
            throw new InvalidOperationException($"{returnType.Name} must implement IPersistableModel");
        }
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
    private static bool IsJsonFormatRequested<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
        => options.Format == "J" || (options.Format == "W" && model.GetFormatFromOptions(options) == "J");
}
