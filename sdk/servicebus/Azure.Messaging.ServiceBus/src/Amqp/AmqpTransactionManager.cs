// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpTransactionManager
    {
        private readonly object syncRoot = new object();
        private readonly Dictionary<string, AmqpTransactionEnlistment> enlistmentMap = new Dictionary<string, AmqpTransactionEnlistment>(StringComparer.Ordinal);

        public static AmqpTransactionManager Instance { get; } = new AmqpTransactionManager();

        public async Task<ArraySegment<byte>> EnlistAsync(
            Transaction transaction,
            AmqpConnectionScope connectionScope,
            TimeSpan timeout)
        {
            if (transaction.IsolationLevel != IsolationLevel.Serializable)
            {
                throw new InvalidOperationException($"The only supported IsolationLevel is {nameof(IsolationLevel.Serializable)}");
            }

            string transactionId = transaction.TransactionInformation.LocalIdentifier;
            AmqpTransactionEnlistment transactionEnlistment;

            lock (syncRoot)
            {
                if (!enlistmentMap.TryGetValue(transactionId, out transactionEnlistment))
                {
                    transactionEnlistment = new AmqpTransactionEnlistment(
                        transaction,
                        this,
                        connectionScope,
                        timeout);
                    enlistmentMap.Add(transactionId, transactionEnlistment);

                    if (!transaction.EnlistPromotableSinglePhase(transactionEnlistment))
                    {
                        enlistmentMap.Remove(transactionId);
                        throw new InvalidOperationException("Local transactions are not supported with other resource managers/DTC.");
                    }
                }
            }

            transactionEnlistment = await transactionEnlistment.GetOrCreateAsync(timeout).ConfigureAwait(false);
            return transactionEnlistment.AmqpTransactionId;
        }

        public void RemoveEnlistment(string transactionId)
        {
            lock (syncRoot)
            {
                enlistmentMap.Remove(transactionId);
            }
        }
    }
}
