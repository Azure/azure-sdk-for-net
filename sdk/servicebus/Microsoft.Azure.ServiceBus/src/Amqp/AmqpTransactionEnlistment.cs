// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using System.Transactions;
    using Microsoft.Azure.Amqp;
    using Primitives;

    internal class AmqpTransactionEnlistment : Singleton<AmqpTransactionEnlistment>, IPromotableSinglePhaseNotification
    {
	    private readonly string _transactionId;
	    private readonly AmqpTransactionManager _transactionManager;
	    private readonly ServiceBusConnection _serviceBusConnection;

        public AmqpTransactionEnlistment(
            Transaction transaction,
            AmqpTransactionManager transactionManager,
            ServiceBusConnection serviceBusConnection)
        {
            _transactionId = transaction.TransactionInformation.LocalIdentifier;
            this._transactionManager = transactionManager;
            this._serviceBusConnection = serviceBusConnection;
        }

        public ArraySegment<byte> AmqpTransactionId { get; private set; }
        
        protected override async Task<AmqpTransactionEnlistment> OnCreateAsync(TimeSpan timeout)
        {
            try
            {
                var faultTolerantController = _serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(_serviceBusConnection.OperationTimeout).ConfigureAwait(false);
                AmqpTransactionId = await controller.DeclareAsync().ConfigureAwait(false);
                MessagingEventSource.Log.AmqpTransactionDeclared(_transactionId, AmqpTransactionId);
                return this;
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpTransactionInitializeException(_transactionId, exception);
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
            TaskExtensionHelper.Schedule(() => SinglePhaseCommitAsync(singlePhaseEnlistment));
        }

        private async Task SinglePhaseCommitAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                var faultTolerantController = _serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(_serviceBusConnection.OperationTimeout).ConfigureAwait(false);

                await controller.DischargeAsync(AmqpTransactionId, fail: false).ConfigureAwait(false);
                singlePhaseEnlistment.Committed();
                MessagingEventSource.Log.AmqpTransactionDischarged(_transactionId, AmqpTransactionId, false);
                await CloseAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.GetClientException(e);
                MessagingEventSource.Log.AmqpTransactionDischargeException(_transactionId, AmqpTransactionId, exception);
                singlePhaseEnlistment.InDoubt(exception);
            }
        }

        void IPromotableSinglePhaseNotification.Rollback(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            _transactionManager.RemoveEnlistment(_transactionId);
            TaskExtensionHelper.Schedule(() => RollbackAsync(singlePhaseEnlistment));
        }

        private async Task RollbackAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                var faultTolerantController = _serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(_serviceBusConnection.OperationTimeout).ConfigureAwait(false);

                await controller.DischargeAsync(AmqpTransactionId, fail: true).ConfigureAwait(false);
                singlePhaseEnlistment.Aborted();
                MessagingEventSource.Log.AmqpTransactionDischarged(_transactionId, AmqpTransactionId, true);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.GetClientException(e);
                MessagingEventSource.Log.AmqpTransactionDischargeException(_transactionId, AmqpTransactionId, exception);
                singlePhaseEnlistment.Aborted(exception);
            }
        }

        byte[] ITransactionPromoter.Promote()
        {
            throw new TransactionPromotionException("Local transactions are not supported with other resource managers/DTC.");
        }
    }
}
