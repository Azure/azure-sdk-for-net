// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    /// <summary>
    /// Workaround for MPG generator bug where the emitter invokes
    /// <c>parameters.ToRequestContent()</c> on a <see cref="DateTimeOffset"/> body parameter
    /// (https://github.com/Azure/azure-sdk-for-net/issues/59539). The extension is called
    /// from a <c>[CodeGenSuppress]</c>-ed replacement in <c>Custom\BillingAccountResource.cs</c>.
    /// TODO: remove once #59539 ships and the next regen no longer emits the broken call.
    /// </summary>
    internal static class BillingRequestContentHelper
    {
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
