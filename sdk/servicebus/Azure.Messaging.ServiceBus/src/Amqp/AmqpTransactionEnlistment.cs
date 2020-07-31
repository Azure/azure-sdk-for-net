// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Transaction;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpTransactionEnlistment : Singleton<AmqpTransactionEnlistment>, IPromotableSinglePhaseNotification
    {
        private readonly string _transactionId;
        private readonly AmqpTransactionManager _transactionManager;
        private readonly AmqpConnectionScope _connectionScope;
        private readonly TimeSpan _timeout;

        public AmqpTransactionEnlistment(
            Transaction transaction,
            AmqpTransactionManager transactionManager,
            AmqpConnectionScope connectionScope,
            TimeSpan timeout)
        {
            _transactionId = transaction.TransactionInformation.LocalIdentifier;
            _transactionManager = transactionManager;
            _connectionScope = connectionScope;
            _timeout = timeout;
        }

        public ArraySegment<byte> AmqpTransactionId { get; private set; }

        protected override async Task<AmqpTransactionEnlistment> OnCreateAsync(TimeSpan timeout)
        {
            try
            {
                FaultTolerantAmqpObject<Controller> faultTolerantController = _connectionScope.TransactionController;
                Controller controller = await faultTolerantController.GetOrCreateAsync(timeout).ConfigureAwait(false);
                AmqpTransactionId = await controller.DeclareAsync().ConfigureAwait(false);
                ServiceBusEventSource.Log.TransactionDeclared(_transactionId, AmqpTransactionId);
                return this;
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.TransactionInitializeException(_transactionId, exception.ToString());
                _transactionManager.RemoveEnlistment(_transactionId);
                throw;
            }
        }

        protected override void OnSafeClose(AmqpTransactionEnlistment value)
        {
        }

        void IPromotableSinglePhaseNotification.Initialize()
        {
        }

        void IPromotableSinglePhaseNotification.SinglePhaseCommit(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            _transactionManager.RemoveEnlistment(_transactionId);
            _ = SinglePhaseCommitAsync(singlePhaseEnlistment);
        }

        private async Task SinglePhaseCommitAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                FaultTolerantAmqpObject<Controller> faultTolerantController = _connectionScope.TransactionController;
                Controller controller = await faultTolerantController.GetOrCreateAsync(_timeout)
                    .ConfigureAwait(false);

                await controller.DischargeAsync(AmqpTransactionId, fail: false).ConfigureAwait(false);
                singlePhaseEnlistment.Committed();
                ServiceBusEventSource.Log.TransactionDischarged(
                    _transactionId,
                    AmqpTransactionId,
                    false);
                await CloseAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.TranslateException(e, null);
                ServiceBusEventSource.Log.TransactionDischargeException(
                    _transactionId,
                    AmqpTransactionId,
                    exception);
                singlePhaseEnlistment.InDoubt(exception);
            }
        }

        void IPromotableSinglePhaseNotification.Rollback(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            _transactionManager.RemoveEnlistment(_transactionId);
            _ = RollbackAsync(singlePhaseEnlistment);
        }

        private async Task RollbackAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                FaultTolerantAmqpObject<Controller> faultTolerantController = _connectionScope.TransactionController;
                Controller controller = await faultTolerantController.GetOrCreateAsync(_timeout)
                    .ConfigureAwait(false);

                await controller.DischargeAsync(AmqpTransactionId, fail: true).ConfigureAwait(false);
                singlePhaseEnlistment.Aborted();
                ServiceBusEventSource.Log.TransactionDischarged(_transactionId, AmqpTransactionId, true);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.TranslateException(e, null);
                ServiceBusEventSource.Log.TransactionDischargeException(
                    _transactionId,
                    AmqpTransactionId,
                    exception);
                singlePhaseEnlistment.Aborted(exception);
            }
        }

        byte[] ITransactionPromoter.Promote()
        {
            throw new TransactionPromotionException(
                "Local transactions are not supported with other resource managers/DTC.");
        }
    }
}
