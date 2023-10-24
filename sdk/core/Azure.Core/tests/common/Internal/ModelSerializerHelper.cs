// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Runtime.CompilerServices;

namespace Azure.Core.Tests.Common
{
    internal static class ModelSerializerHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateFormat<T>(IModel<T> model, ModelReaderWriterFormat format)
        {
            bool implementsJson = model is IJsonModel<T>;
            bool isValid = (format == ModelReaderWriterFormat.Json && implementsJson) || format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {model.GetType().Name} does not support '{format}' format.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateFormat(IModel<object> model, ModelReaderWriterFormat format) => ValidateFormat<object>(model, format);
    }
}
