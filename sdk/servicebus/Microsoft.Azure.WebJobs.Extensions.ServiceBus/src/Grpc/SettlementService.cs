// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Linq;
using System.Threading.Tasks;
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

        public override async Task<SettlementReply> Complete(CompleteRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var action))
            {
                try
                {
                    await action.CompleteMessageAsync(action._eventArgs.Message, context.CancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    return new SettlementReply() { Exception = exception.ToString() };
                }
                return new SettlementReply();
            }
            return new SettlementReply {Exception = $"LockToken {request.Locktoken} not found."};
        }

        public override async Task<SettlementReply> Abandon(AbandonRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var action))
            {
                try
                {
                    await action.AbandonMessageAsync(
                        action._eventArgs.Message,
                        request.PropertiesToModify.ToDictionary(
                            pair => pair.Key,
                            pair => pair.Value.GetPropertyValue()),
                        context.CancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    return new SettlementReply() { Exception = exception.ToString() };
                }
                return new SettlementReply();
            }
            return new SettlementReply {Exception = $"LockToken {request.Locktoken} not found."};
        }

        public override async Task<SettlementReply> Defer(DeferRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var action))
            {
                try
                {
                    await action.DeferMessageAsync(
                        action._eventArgs.Message,
                        request.PropertiesToModify.ToDictionary(
                            pair => pair.Key,
                            pair => pair.Value.GetPropertyValue()),
                        context.CancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    return new SettlementReply() { Exception = exception.ToString() };
                }
                return new SettlementReply();
            }
            return new SettlementReply {Exception = $"LockToken {request.Locktoken} not found."};
        }

        public override async Task<SettlementReply> Deadletter(DeadletterRequest request, ServerCallContext context)
        {
            if (_provider.ActionsCache.TryGetValue(request.Locktoken, out var action))
            {
                try
                {
                    await action.DeadLetterMessageAsync(
                        action._eventArgs.Message,
                        request.PropertiesToModify.ToDictionary(
                            pair => pair.Key,
                            pair => pair.Value.GetPropertyValue()),
                        request.DeadletterReason,
                        request.DeadletterErrorDescription,
                        context.CancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    return new SettlementReply() { Exception = exception.ToString() };
                }
                return new SettlementReply();
            }
            return new SettlementReply {Exception = $"LockToken {request.Locktoken} not found."};
        }
    }
}
#endif