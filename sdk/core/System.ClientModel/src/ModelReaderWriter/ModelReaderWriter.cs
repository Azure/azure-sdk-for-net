// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides functionality to read and write <see cref="IPersistableModel{T}"/> and <see cref="IJsonModel{T}"/>.
/// </summary>
public static class ModelReaderWriter
{
    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to write.</typeparam>
    /// <param name="model">The model to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    [RequiresDynamicCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    [RequiresUnreferencedCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    public static BinaryData Write<T>(T model, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        options ??= ModelReaderWriterOptions.Json;

        return WritePersistableOrEnumerable(model, options, ModelReaderWriterReflectionContext.Default);
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
    [RequiresDynamicCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    [RequiresUnreferencedCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    public static BinaryData Write(object model, ModelReaderWriterOptions? options = default)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        options ??= ModelReaderWriterOptions.Json;

        return WritePersistableOrEnumerable(model, options, ModelReaderWriterReflectionContext.Default);
    }

    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to write.</typeparam>
    /// <param name="model">The model to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <param name="context"> The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    public static BinaryData Write<T>(T model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        return WritePersistableOrEnumerable(model, options, context);
    }

    /// <summary>
    /// Converts the value of a model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <param name="model">The model to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <param name="context"> The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <returns>A <see cref="BinaryData"/> representation of the model in the <see cref="ModelReaderWriterOptions.Format"/> specified by the <paramref name="options"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="model"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null.</exception>
    public static BinaryData Write(object model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        return WritePersistableOrEnumerable(model, options, context);
    }

    private static BinaryData WritePersistableOrEnumerable<T>(T model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        if (model is IPersistableModel<T> iModel)
        {
            return WritePersistable(iModel, options);
        }
        else if (model is IPersistableModel<object> objModel)
        {
            //used for the class proxy case since the proxy does not need to implement reading and writing for itself
            return WritePersistable(objModel, options);
        }
        else
        {
            var enumerable = model as IEnumerable ?? context.GetTypeBuilder(model!.GetType()).ToEnumerable(model);
            if (enumerable is not null)
            {
                var collectionWriter = CollectionWriter.GetCollectionWriter(enumerable, options);
                return collectionWriter.Write(enumerable, options);
            }
            else
            {
                throw new InvalidOperationException($"{model!.GetType().ToFriendlyName()} must implement IEnumerable or IPersistableModel");
            }
        }
    }

    private static BinaryData WritePersistable<T>(IPersistableModel<T> model, ModelReaderWriterOptions options)
    {
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
    /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
    /// <exception cref="MissingMethodException">If <typeparamref name="T"/> does not have a public or non public empty constructor.</exception>
    [RequiresDynamicCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    [RequiresUnreferencedCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    public static T? Read<T>(BinaryData data, ModelReaderWriterOptions? options = default)
    {
        return ReadInternal<T>(data, options ??= ModelReaderWriterOptions.Json, ModelReaderWriterReflectionContext.Default);
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <param name="context"> The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <returns>A <typeparamref name="T"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <typeparamref name="T"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> is null.</exception>
    /// <exception cref="MissingMethodException">If <typeparamref name="T"/> does not have a public or non public empty constructor.</exception>
    public static T? Read<T>(BinaryData data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        return ReadInternal<T>(data, options, context);
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
    [RequiresDynamicCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    [RequiresUnreferencedCode("This method uses reflection.  Use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
    public static object? Read(BinaryData data, Type returnType, ModelReaderWriterOptions? options = default)
    {
        return ReadInternal(data, returnType, options ??= ModelReaderWriterOptions.Json, ModelReaderWriterReflectionContext.Default);
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="returnType">The type of the object to convert and return.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> to use.</param>
    /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
    /// <exception cref="MissingMethodException">If <paramref name="returnType"/> does not have a public or non public empty constructor.</exception>
    public static object? Read(BinaryData data, Type returnType, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        return ReadInternal(data, returnType, options, context);
    }

    private static T? ReadInternal<T>(BinaryData data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        var obj = ReadInternal(data, typeof(T), options, context);
        return obj is null ? (T?)obj : (T)obj;
    }

    private static object? ReadInternal(BinaryData data, Type returnType, ModelReaderWriterOptions options, ModelReaderWriterContext context)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (returnType is null)
        {
            throw new ArgumentNullException(nameof(returnType));
        }

        var builder = context.GetTypeBuilder(returnType);
        var returnObj = builder.CreateObject();
        if (returnObj is ModelReaderWriterTypeBuilder.CollectionWrapper collectionWrapper)
        {
            var collectionReader = CollectionReader.GetCollectionReader(collectionWrapper, options);
            return collectionReader.Read(collectionWrapper, data, builder, context, options);
        }
        else if (returnObj is IPersistableModel<object> persistableModel)
        {
            return persistableModel.Create(data, options);
        }
        else
        {
            throw new InvalidOperationException($"{returnType.ToFriendlyName()} must implement IPersistableModel");
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
