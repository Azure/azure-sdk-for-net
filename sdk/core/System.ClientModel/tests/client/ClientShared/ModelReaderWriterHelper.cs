// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;

namespace ClientModel.Tests.ClientShared;

internal static class ModelReaderWriterHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidateFormat<T>(IPersistableModel<T> model, string format)
    {
        bool implementsJson = model is IJsonModel<T>;
        bool isValid = (format == "J" && implementsJson) || format == "W";
        if (!isValid)
        {
            throw new FormatException($"The model {model.GetType().Name} does not support '{format}' format.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ValidateFormat(IPersistableModel<object> model, string format)
        => ValidateFormat<object>(model, format);

    private static ModelReaderWriterOptions? _wireOptions;
    public static ModelReaderWriterOptions WireOptions => _wireOptions ??= new ModelReaderWriterOptions("W");
}
