// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal static class JsonElementExtensions
    {
        public static BinaryData GetUtf8Bytes(this JsonElement element)
        {
#if NET9_0_OR_GREATER
            return new BinaryData(JsonMarshal.GetRawUtf8Value(element).ToArray());
#else
            return BinaryData.FromString(element.GetRawText());
#endif
        }
    }
}
