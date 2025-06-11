// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

using MessagePack;

using Microsoft.AspNetCore.Internal;

namespace Microsoft.AspNetCore.SignalR.Protocol;

#nullable enable

/// <summary>
/// A trimmed version of  https://github.com/dotnet/aspnetcore/blob/0825def633c99d9fdd74e47e69bcde3935a5fe74/
/// </summary>
internal abstract class MessagePackHubProtocolWorker
{
    private const int ErrorResult = 1;
    private const int VoidResult = 2;
    private const int NonVoidResult = 3;

    protected abstract object? DeserializeObject(ref MessagePackReader reader, Type type, string field);

    public void WriteMessage(HubMessage message, IBufferWriter<byte> output)
    {
        var memoryBufferWriter = MemoryBufferWriter.Get();

        try
        {
            var writer = new MessagePackWriter(memoryBufferWriter);

            // Write message to a buffer so we can get its length
            WriteMessageCore(message, ref writer);

            // Write length then message to output
            BinaryMessageFormatter.WriteLengthPrefix(memoryBufferWriter.Length, output);
            memoryBufferWriter.CopyTo(output);
        }
        finally
        {
            MemoryBufferWriter.Return(memoryBufferWriter);
        }
    }

    public ReadOnlyMemory<byte> GetMessageBytes(HubMessage message)
    {
        var memoryBufferWriter = MemoryBufferWriter.Get();

        try
        {
            var writer = new MessagePackWriter(memoryBufferWriter);

            // Write message to a buffer so we can get its length
            WriteMessageCore(message, ref writer);

            var dataLength = memoryBufferWriter.Length;
            var prefixLength = BinaryMessageFormatter.LengthPrefixLength(memoryBufferWriter.Length);

            var array = new byte[dataLength + prefixLength];
            var span = array.AsSpan();

            // Write length then message to output
            var written = BinaryMessageFormatter.WriteLengthPrefix(memoryBufferWriter.Length, span);
            Debug.Assert(written == prefixLength);
            memoryBufferWriter.CopyTo(span.Slice(prefixLength));

            return array;
        }
        finally
        {
            MemoryBufferWriter.Return(memoryBufferWriter);
        }
    }

    private void WriteMessageCore(HubMessage message, ref MessagePackWriter writer)
    {
        switch (message)
        {
            case InvocationMessage invocationMessage:
                WriteInvocationMessage(invocationMessage, ref writer);
                break;
            case CompletionMessage completionMessage:
                WriteCompletionMessage(completionMessage, ref writer);
                break;
            default:
                throw new NotSupportedException($"Not supported message type: {message.GetType().Name}");
        }

        writer.Flush();
    }

    private void WriteArgument(object? argument, ref MessagePackWriter writer)
    {
        if (argument == null)
        {
            writer.WriteNil();
        }
#if NET8_0_OR_GREATER
        else if (argument is RawResult result)
        {
            writer.WriteRaw(result.RawSerializedData);
        }
#endif
        else
        {
            Serialize(ref writer, argument.GetType(), argument);
        }
    }

    protected abstract void Serialize(ref MessagePackWriter writer, Type type, object value);

    private static void WriteStreamIds(string[]? streamIds, ref MessagePackWriter writer)
    {
        if (streamIds != null)
        {
            writer.WriteArrayHeader(streamIds.Length);
            foreach (var streamId in streamIds)
            {
                writer.Write(streamId);
            }
        }
        else
        {
            writer.WriteArrayHeader(0);
        }
    }

    private void WriteInvocationMessage(InvocationMessage message, ref MessagePackWriter writer)
    {
        writer.WriteArrayHeader(6);

        writer.Write(HubProtocolConstants.InvocationMessageType);
        PackHeaders(message.Headers, ref writer);
        if (string.IsNullOrEmpty(message.InvocationId))
        {
            writer.WriteNil();
        }
        else
        {
            writer.Write(message.InvocationId);
        }
        writer.Write(message.Target);

        if (message.Arguments is null)
        {
            writer.WriteArrayHeader(0);
        }
        else
        {
            writer.WriteArrayHeader(message.Arguments.Length);
            foreach (var arg in message.Arguments)
            {
                WriteArgument(arg, ref writer);
            }
        }
#if NET6_0_OR_GREATER
        WriteStreamIds(message.StreamIds, ref writer);
#endif
    }

    private void WriteCompletionMessage(CompletionMessage message, ref MessagePackWriter writer)
    {
        var resultKind =
            message.Error != null ? ErrorResult :
            message.HasResult ? NonVoidResult :
            VoidResult;

        writer.WriteArrayHeader(4 + (resultKind != VoidResult ? 1 : 0));
        writer.Write(HubProtocolConstants.CompletionMessageType);
        PackHeaders(message.Headers, ref writer);
        writer.Write(message.InvocationId);
        writer.Write(resultKind);
        switch (resultKind)
        {
            case ErrorResult:
                writer.Write(message.Error);
                break;
            case NonVoidResult:
                WriteArgument(message.Result, ref writer);
                break;
        }
    }

    private static void PackHeaders(IDictionary<string, string>? headers, ref MessagePackWriter writer)
    {
        if (headers != null)
        {
            writer.WriteMapHeader(headers.Count);
            if (headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    writer.Write(header.Key);
                    writer.Write(header.Value);
                }
            }
        }
        else
        {
            writer.WriteMapHeader(0);
        }
    }
}