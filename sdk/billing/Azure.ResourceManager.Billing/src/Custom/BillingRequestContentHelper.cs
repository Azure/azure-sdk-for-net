// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    // Workaround helpers used by inline-patched Generated/*.cs call sites where the MPG generator
    // emits invalid `T.ToRequestContent(value)` static-method invocations for body parameter types
    // that have no such static method.
    //   * IEnumerable<TModel> body params  — tracked at https://github.com/Azure/azure-sdk-for-net/issues/57716
    //     (open; draft fix in PR https://github.com/Azure/azure-sdk-for-net/pull/57719).
    //   * DateTimeOffset (scalar utcDateTime) body params — no existing issue; new one to be filed.
    // TODO: remove this helper and the corresponding inline patches in src/Generated once both
    //       generator bugs are fixed and the next regen no longer emits the broken calls.
    internal static class BillingRequestContentHelper
    {
        public static RequestContent ToRequestContent<T>(IEnumerable<T> items) where T : System.ClientModel.Primitives.IPersistableModel<T>
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (T item in items)
            {
                if (item is null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                BinaryData binary = ((System.ClientModel.Primitives.IPersistableModel<T>)item).Write(System.ClientModel.Primitives.ModelReaderWriterOptions.Json);
                using JsonDocument doc = JsonDocument.Parse(binary);
                doc.RootElement.WriteTo(writer);
            }
            writer.WriteEndArray();
            writer.Flush();
            stream.Position = 0;
            return RequestContent.Create(stream.ToArray());
        }

        public static RequestContent ToRequestContent(DateTimeOffset value)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStringValue(value, "O");
            writer.Flush();
            stream.Position = 0;
            return RequestContent.Create(stream.ToArray());
        }
    }
}
