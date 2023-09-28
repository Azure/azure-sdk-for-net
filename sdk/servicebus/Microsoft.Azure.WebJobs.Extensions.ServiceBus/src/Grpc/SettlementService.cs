// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
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
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
            {
                await tuple.Actions.CompleteMessageAsync(
                    tuple.Message,
                    context.CancellationToken).ConfigureAwait(false);
                return new Empty();
            }
            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        public override async Task<Empty> Abandon(AbandonRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
            {
                await tuple.Actions.AbandonMessageAsync(
                    tuple.Message,
                    request.PropertiesToModify.ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value.GetPropertyValue()),
                    context.CancellationToken).ConfigureAwait(false);
                return new Empty();
            }
            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        public override async Task<Empty> Defer(DeferRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
            {
                await tuple.Actions.DeferMessageAsync(
                    tuple.Message,
                    request.PropertiesToModify.ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value.GetPropertyValue()),
                    context.CancellationToken).ConfigureAwait(false);
                return new Empty();
            }
            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }

        public override async Task<Empty> Deadletter(DeadletterRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var tuple))
            {
                await tuple.Actions.DeadLetterMessageAsync(
                    tuple.Message,
                    request.PropertiesToModify.ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value.GetPropertyValue()),
                    request.DeadletterReason,
                    request.DeadletterErrorDescription,
                    context.CancellationToken).ConfigureAwait(false);
                return new Empty();
            }
            throw new RpcException (new Status(StatusCode.FailedPrecondition, $"LockToken {request.Locktoken} not found."));
        }
    }
}
#endif