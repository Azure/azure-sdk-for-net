// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Transactions;

    internal class AmqpTransactionManager
    {
	    private readonly object _syncRoot = new object();
	    private readonly Dictionary<string, AmqpTransactionEnlistment> _enlistmentMap = new Dictionary<string, AmqpTransactionEnlistment>(StringComparer.Ordinal);

        public static AmqpTransactionManager Instance { get; } = new AmqpTransactionManager();

        public async Task<ArraySegment<byte>> EnlistAsync(
            Transaction transaction,
            ServiceBusConnection serviceBusConnection)
        {
            if (transaction.IsolationLevel != IsolationLevel.Serializable)
            {
                throw new InvalidOperationException($"The only supported IsolationLevel is {nameof(IsolationLevel.Serializable)}");
            }

            string transactionId = transaction.TransactionInformation.LocalIdentifier;
            AmqpTransactionEnlistment transactionEnlistment;

            lock (_syncRoot)
            {
                if (!_enlistmentMap.TryGetValue(transactionId, out transactionEnlistment))
                {
                    transactionEnlistment = new AmqpTransactionEnlistment(transaction, this, serviceBusConnection);
                    _enlistmentMap.Add(transactionId, transactionEnlistment);

                    if (!transaction.EnlistPromotableSinglePhase(transactionEnlistment))
                    {
                        _enlistmentMap.Remove(transactionId);
                        throw new InvalidOperationException("Local transactions are not supported with other resource managers/DTC.");
                    }
                }
            }

            transactionEnlistment = await transactionEnlistment.GetOrCreateAsync(serviceBusConnection.OperationTimeout).ConfigureAwait(false);
            return transactionEnlistment.AmqpTransactionId;
        }

        public void RemoveEnlistment(string transactionId)
        {
            lock (_syncRoot)
            {
                _enlistmentMap.Remove(transactionId);
            }
        }
    }
}
