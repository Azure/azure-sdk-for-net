// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Amqp.Shared;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc
{
    internal class SettlementService : Settlement.SettlementBase
    {
        private readonly MessagingProvider _provider;

        public SettlementService(MessagingProvider provider)
        {
            _provider = provider;
        }

        public SettlementService()
        {
            _provider = null;
        }

        public override async Task<Empty> Complete(CompleteRequest request, ServerCallContext context)
        {
            try
            {
                if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
                {
                    await tuple.Actions.CompleteMessageAsync(
                        tuple.Message,
                        context.CancellationToken).ConfigureAwait(false);
                    return new Empty();
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Unknown, ex.ToString()));
            }

            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        public override async Task<Empty> Abandon(AbandonRequest request, ServerCallContext context)
        {
            try
            {
                if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
                {
                    await tuple.Actions.AbandonMessageAsync(
                        tuple.Message,
                        DeserializeAmqpMap(request.PropertiesToModify),
                        context.CancellationToken).ConfigureAwait(false);
                    return new Empty();
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Unknown, ex.ToString()));
            }

            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        public override async Task<Empty> Defer(DeferRequest request, ServerCallContext context)
        {
            try
            {
                if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
                {
                    await tuple.Actions.DeferMessageAsync(
                        tuple.Message,
                        DeserializeAmqpMap(request.PropertiesToModify),
                        context.CancellationToken).ConfigureAwait(false);
                    return new Empty();
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Unknown, ex.ToString()));
            }

            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        public override async Task<Empty> Deadletter(DeadletterRequest request, ServerCallContext context)
        {
            try
            {
                if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
                {
                    if (request.PropertiesToModify == null || request.PropertiesToModify == ByteString.Empty)
                    {
                        await tuple.Actions.DeadLetterMessageAsync(
                            tuple.Message,
                            request.DeadletterReason,
                            request.DeadletterErrorDescription,
                            context.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await tuple.Actions.DeadLetterMessageAsync(
                            tuple.Message,
                            DeserializeAmqpMap(request.PropertiesToModify),
                            request.DeadletterReason,
                            request.DeadletterErrorDescription,
                            context.CancellationToken).ConfigureAwait(false);
                    }

                    return new Empty();
                }
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Unknown, ex.ToString()));
            }

            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        private static Dictionary<string, object> DeserializeAmqpMap(ByteString mapBytes)
        {
            if (mapBytes == null || mapBytes == ByteString.Empty)
            {
                return null;
            }

            var bytes = mapBytes.ToByteArray();
            using ByteBuffer buffer = new ByteBuffer(bytes.Length, false);
            AmqpBitConverter.WriteBytes(buffer, bytes, 0, bytes.Length);
            var map = AmqpCodec.DecodeMap(buffer);
            var dict = new Dictionary<string, object>(map.Count);
            foreach (var pair in map)
            {
                // This matches the behavior when constructing a ServiceBusReceivedMessage in the SDK.
                if (AmqpAnnotatedMessageConverter.TryCreateNetPropertyFromAmqpProperty(pair.Value, out object value))
                {
                    dict[pair.Key.ToString()] = value;
                }
            }

            return dict;
        }
    }
}
#endif