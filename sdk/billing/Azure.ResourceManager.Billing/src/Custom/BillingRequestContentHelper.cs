// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    /// <summary>
    /// Workaround for MPG generator bugs where the emitter invokes <c>parameters.ToRequestContent()</c>
    /// on a body parameter type that has no such method. The replacements are exposed as
    /// <b>extension methods</b> and called from <c>[CodeGenSuppress]</c>-ed replacement methods in
    /// <c>Custom\BillingAccountResource.cs</c> / <c>Custom\Extensions\MockableBillingTenantResource.cs</c>.
    ///
    /// Tracking issues:
    ///   * IEnumerable&lt;TModel&gt; body params  —
    ///     https://github.com/Azure/azure-sdk-for-net/issues/57716 (open; draft fix PR #57719).
    ///   * DateTimeOffset (scalar utcDateTime) body params —
    ///     https://github.com/Azure/azure-sdk-for-net/issues/59539 (open).
    /// TODO: remove these extension methods, the corresponding <c>[CodeGenSuppress]</c> attributes,
    ///       and the replacement methods once the upstream generator fixes ship and the next regen
    ///       no longer emits the broken calls.
    /// </summary>
    internal static class BillingRequestContentHelper
    {
        public static RequestContent ToRequestContent<T>(this IEnumerable<T> items) where T : System.ClientModel.Primitives.IPersistableModel<T>
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

        public static RequestContent ToRequestContent(this DateTimeOffset value)
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
