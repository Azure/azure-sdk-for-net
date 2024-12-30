﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

using MessagePack;

namespace Microsoft.AspNetCore.SignalR.Protocol;

#nullable enable

/// <summary>
/// Copied from https://github.com/dotnet/aspnetcore/blob/0825def633c99d9fdd74e47e69bcde3935a5fe74/
/// </summary>
internal sealed class DefaultMessagePackHubProtocolWorker : MessagePackHubProtocolWorker
{
    private readonly MessagePackSerializerOptions _messagePackSerializerOptions;

    public DefaultMessagePackHubProtocolWorker(MessagePackSerializerOptions messagePackSerializerOptions)
    {
        _messagePackSerializerOptions = messagePackSerializerOptions;
    }

    protected override object? DeserializeObject(ref MessagePackReader reader, Type type, string field)
    {
        try
        {
            return MessagePackSerializer.Deserialize(type, ref reader, _messagePackSerializerOptions);
        }
        catch (Exception ex)
        {
            throw new InvalidDataException($"Deserializing object of the `{type.Name}` type for '{field}' failed.", ex);
        }
    }

    protected override void Serialize(ref MessagePackWriter writer, Type type, object value)
    {
        MessagePackSerializer.Serialize(type, ref writer, value, _messagePackSerializerOptions);
    }
}