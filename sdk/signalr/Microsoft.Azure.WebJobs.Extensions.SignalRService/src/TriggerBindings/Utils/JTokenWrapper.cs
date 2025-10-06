// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

using MessagePack;
using MessagePack.Formatters;

using Microsoft.AspNetCore.SignalR.Protocol;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService;

/// <summary>
/// Helps to make the <see cref="JToken"/> object correctly seralized in <see cref="JsonHubProtocol"/> that using System.Text.Json internally.
/// <para>Since .Net Core 3.0, the <see cref="JsonHubProtocol"/> uses System.Text.Json library for JSON (de)serialization, which cannot handle <see cref="JToken"/> correctly. However, in isolated worker model, if a SignalR trigger function returns an object, then the SignalR extensions in host process gets a <see cref="JToken"/> object. We need to make sure the <see cref="JToken"/> object serialized correctly in the <see cref="CompletionMessage"/>.</para>
/// </summary>

[System.Text.Json.Serialization.JsonConverter(typeof(JTokenWrapperJsonConverter))]
[MessagePackFormatter(typeof(JTokenWrapperMessagePackFormatter))]
internal class JTokenWrapper(JToken value)
{
    public JToken Value { get; } = value;
}

internal class JTokenWrapperJsonConverter : System.Text.Json.Serialization.JsonConverter<JTokenWrapper>
{
    public override JTokenWrapper Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, JTokenWrapper value, JsonSerializerOptions options)
    {
        var jsonString = JsonConvert.SerializeObject(value.Value);
        writer.WriteRawValue(jsonString);
    }
}

internal class JTokenWrapperMessagePackFormatter : IMessagePackFormatter<JTokenWrapper>
{
    public JTokenWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public void Serialize(ref MessagePackWriter writer, JTokenWrapper value, MessagePackSerializerOptions options)
    {
        var jsonString = value.Value.ToString();
        MessagePackSerializer.ConvertFromJson(jsonString, ref writer, options);
    }
}