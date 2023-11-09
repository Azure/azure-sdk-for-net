// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Runtime.CompilerServices;

namespace System.Net.ClientModel.Internal
{
    public static class ModelReaderWriterHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateFormat<T>(IModel<T> model, string format)
        {
            bool implementsJson = model is IJsonModel<T>;
            bool isValid = (format == "J" && implementsJson) || format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {model.GetType().Name} does not support '{format}' format.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateFormat(IModel<object> model, string format) => ValidateFormat<object>(model, format);
    }
}
