// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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

        var iModel = model as IPersistableModel<object>;
        if (iModel is null)
        {
            throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IPersistableModel<object>)}");
        }

        if (ShouldWriteAsJson(iModel, options, out IJsonModel<object>? jsonModel))
        {
            using (UnsafeBufferSequence.Reader reader = new ModelWriter<object>(jsonModel, options).ExtractReader())
            {
                return reader.ToBinaryData();
            }
        }
        else
        {
            return iModel.Write(options);
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
    public static T? Read<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(BinaryData data, ModelReaderWriterOptions? options = default)
        where T : IPersistableModel<T>
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        options ??= ModelReaderWriterOptions.Json;

        return GetInstance<T>().Create(data, options);
    }

    /// <summary>
    /// Converts the <see cref="BinaryData"/> into a <paramref name="returnType"/>.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to convert.</param>
    /// <param name="returnType">The type of the objec to convert and return.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <paramref name="returnType"/> representation of the <see cref="BinaryData"/>.</returns>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not implement <see cref="IPersistableModel{T}"/>.</exception>
    /// <exception cref="InvalidOperationException">Throws if <paramref name="returnType"/> does not have a public or internal parameterless constructor.</exception>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="data"/> or <paramref name="returnType"/> are null.</exception>
    /// <exception cref="MissingMethodException">If <paramref name="returnType"/> does not have a public or non public empty constructor.</exception>
    public static object? Read(BinaryData data, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType, ModelReaderWriterOptions? options = default)
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

        return GetInstance(returnType).Create(data, options);
    }

    private static IPersistableModel<object> GetInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        var model = GetObjectInstance(returnType) as IPersistableModel<object>;
        if (model is null)
        {
            throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IPersistableModel<object>)}");
        }
        return model;
    }

    private static IPersistableModel<T> GetInstance<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>()
        where T : IPersistableModel<T>
    {
        var model = GetObjectInstance(typeof(T)) as IPersistableModel<T>;
        if (model is null)
        {
            throw new InvalidOperationException($"{typeof(T).Name} does not implement {nameof(IPersistableModel<T>)}");
        }
        return model;
    }

    private static object GetObjectInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type returnType)
    {
        PersistableModelProxyAttribute? attribute = Attribute.GetCustomAttribute(returnType, typeof(PersistableModelProxyAttribute), false) as PersistableModelProxyAttribute;
        Type typeToActivate = attribute is null ? returnType : attribute.ProxyType;

        if (returnType.IsAbstract && attribute is null)
        {
            throw new InvalidOperationException($"{returnType.Name} must be decorated with {nameof(PersistableModelProxyAttribute)} to be used with {nameof(ModelReaderWriter)}");
        }

        var obj = Activator.CreateInstance(typeToActivate, true);
        if (obj is null)
        {
            throw new InvalidOperationException($"Unable to create instance of {typeToActivate.Name}.");
        }
        return obj;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsJsonFormatRequested(IPersistableModel<object> model, ModelReaderWriterOptions options)
        => IsJsonFormatRequested<object>(model, options);
}
