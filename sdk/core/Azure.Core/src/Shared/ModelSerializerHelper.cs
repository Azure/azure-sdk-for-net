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
        public static void ValidateFormat(IModelSerializable<object> model, ModelSerializerFormat format)
        {
            bool implementsJson = model is IModelJsonSerializable<object>;
            bool isValid = (format == ModelSerializerFormat.Json && implementsJson) || format == ModelSerializerFormat.Wire;
            if (!isValid)
            {
                throw new NotSupportedException($"The model {model.GetType().Name} does not support '{format}' format.");
            }
        }
    }
}
