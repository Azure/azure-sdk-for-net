// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Text.Json
{
    internal static class JsonElementExtensions
    {
        public static string ReadString(this JsonElement element, string name)
        {
            return element.GetProperty(name).GetString();
        }

        public static TValue ReadToObject<TValue>(this JsonElement element, string name)
        {
            var value = element.GetProperty(name);
            return JsonSerializer.Deserialize<TValue>(value.GetRawText());
        }
    }
}
