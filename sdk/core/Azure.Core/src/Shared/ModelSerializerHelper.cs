// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using Azure.Core.Serialization;

namespace Azure.Core
{
    internal static class ModelSerializerHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateFormat<T>(IModelSerializable<T> model, ModelSerializerFormat format)
        {
            bool implementsJson = model is IModelJsonSerializable<T>;
            bool isValid = (format == ModelSerializerFormat.Json && implementsJson) || format == ModelSerializerFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {model.GetType().Name} does not support '{format}' format.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateFormat(IModelSerializable<object> model, ModelSerializerFormat format) => ValidateFormat<object>(model, format);
    }
}
