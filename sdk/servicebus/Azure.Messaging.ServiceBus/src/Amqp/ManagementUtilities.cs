// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// Utility methods related to the management link
    /// </summary>
    internal static class ManagementUtilities
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionScope"></param>
        /// <param name="managementLink"></param>
        /// <param name="amqpRequestMessage"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal static async Task<AmqpResponseMessage> ExecuteRequestResponseAsync(
           AmqpConnectionScope connectionScope,
           FaultTolerantAmqpObject<RequestResponseAmqpLink> managementLink,
           AmqpRequestMessage amqpRequestMessage,
           TimeSpan timeout)
        {
            AmqpMessage amqpMessage = amqpRequestMessage.AmqpMessage;

            ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
            var ambientTransaction = Transaction.Current;
            if (ambientTransaction != null)
            {
                transactionId = await AmqpTransactionManager.Instance.EnlistAsync(
                    ambientTransaction,
                    connectionScope,
                    timeout)
                    .ConfigureAwait(false);
            }

            if (!managementLink.TryGetOpenedObject(out var requestResponseAmqpLink))
            {
                // MessagingEventSource.Log.CreatingNewLink(this.ClientId, this.isSessionReceiver, this.SessionIdInternal, true, this.LinkException);
                requestResponseAmqpLink = await managementLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
            }

            var responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => requestResponseAmqpLink.BeginRequest(amqpMessage, transactionId, timeout, c, s),
                (a) => requestResponseAmqpLink.EndRequest(a),
                null).ConfigureAwait(false);

            return AmqpResponseMessage.CreateResponse(responseAmqpMessage);
        }
    }
}
