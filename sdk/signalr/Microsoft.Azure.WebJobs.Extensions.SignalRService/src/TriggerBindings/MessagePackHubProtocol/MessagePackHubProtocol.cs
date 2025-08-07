// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

using Microsoft.AspNetCore.Connections;

namespace Microsoft.AspNetCore.SignalR.Protocol;

#nullable enable

/// <summary>
/// Implements the SignalR Hub Protocol using MessagePack.
/// A trimmed version of https://github.com/dotnet/aspnetcore/blob/0825def633c99d9fdd74e47e69bcde3935a5fe74/
/// </summary>
internal class MessagePackHubProtocol : IHubProtocol
{
    private const string ProtocolName = "messagepack";
    private const int ProtocolVersion = 2;
    private readonly DefaultMessagePackHubProtocolWorker _worker;
    private readonly MessagePackSerializerOptions _messagePackSerializerOptions =
        MessagePackSerializerOptions
            .Standard
            .WithResolver(SignalRResolver.Instance)
            .WithSecurity(MessagePackSecurity.UntrustedData);

    public string Name => ProtocolName;

    public int Version => ProtocolVersion;

    public TransferFormat TransferFormat => TransferFormat.Binary;

    public MessagePackHubProtocol()
    {
        _worker = new DefaultMessagePackHubProtocolWorker(_messagePackSerializerOptions);
    }

    public bool IsVersionSupported(int version)
    {
        return version <= Version;
    }

#if NETSTANDARD2_0
    public bool TryParseMessage(ref ReadOnlySequence<byte> input, IInvocationBinder binder, out HubMessage? message)
#else
    public bool TryParseMessage(ref ReadOnlySequence<byte> input, IInvocationBinder binder, [NotNullWhen(true)] out HubMessage? message)
#endif
        => throw new NotImplementedException();

    public void WriteMessage(HubMessage message, IBufferWriter<byte> output)
        => _worker.WriteMessage(message, output);

    public ReadOnlyMemory<byte> GetMessageBytes(HubMessage message)
        => _worker.GetMessageBytes(message);

    internal sealed class SignalRResolver : IFormatterResolver
    {
        public static readonly IFormatterResolver Instance = new SignalRResolver();

        public static readonly IReadOnlyList<IFormatterResolver> Resolvers = new IFormatterResolver[]
        {
                DynamicEnumAsStringResolver.Instance,
                ContractlessStandardResolver.Instance,
        };

        public IMessagePackFormatter<T>? GetFormatter<T>()
        {
            return Cache<T>.Formatter;
        }

        private static class Cache<T>
        {
            public static readonly IMessagePackFormatter<T>? Formatter = ResolveFormatter();

            private static IMessagePackFormatter<T>? ResolveFormatter()
            {
                foreach (var resolver in Resolvers)
                {
                    var formatter = resolver.GetFormatter<T>();
                    if (formatter != null)
                    {
                        return formatter;
                    }
                }

                return null;
            }
        }
    }
}