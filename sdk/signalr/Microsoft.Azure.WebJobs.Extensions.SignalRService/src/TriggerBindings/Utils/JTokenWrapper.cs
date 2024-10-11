﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR.Protocol;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService;

/// <summary>
/// Helps to make the <see cref="JToken"/> object correctly seralized in <see cref="JsonHubProtocol"/> that using System.Text.Json internally.
/// <para>Since .Net Core 3.0, the <see cref="JsonHubProtocol"/> uses System.Text.Json library for JSON (de)serialization, which cannot handle <see cref="JToken"/> correctly. However, in isolated worker model, if a SignalR trigger function returns an object, then the SignalR extensions in host process gets a <see cref="JToken"/> object. We need to make sure the <see cref="JToken"/> object serialized correctly in the <see cref="CompletionMessage"/>.</para>
/// </summary>

[System.Text.Json.Serialization.JsonConverter(typeof(JTokenWrapperJsonConverter))]
internal class JTokenWrapper
{
    public JTokenWrapper(JToken value)
    {
        Value = value;
    }

    public JToken Value { get; }
}

internal class JTokenWrapperJsonConverter : System.Text.Json.Serialization.JsonConverter<JTokenWrapper>
{
    public override JTokenWrapper Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, JTokenWrapper value, JsonSerializerOptions options)
    {
#if NET6_0_OR_GREATER
        var jsonString = JsonConvert.SerializeObject(value.Value);
        writer.WriteRawValue(jsonString);
#elif NETSTANDARD2_0
        // No need to implement.
        // First of all, the SignalR extensions for host process always run on .NET 6 or greater runtime when this class is first written.
        // Even if somehow the extensions run on .NET Framework, the JsonHubProtocol would use Newtonsoft.Json for serialization and this class would not be used.
        throw new NotImplementedException("Serializing Newtonsoft.Json.JsonToken with System.Text.Json is not implemented. ");
#endif
    }
}
