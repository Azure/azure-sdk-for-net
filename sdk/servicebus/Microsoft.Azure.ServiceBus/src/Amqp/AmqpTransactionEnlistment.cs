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
	    private readonly string transactionId;
	    private readonly AmqpTransactionManager transactionManager;
	    private readonly ServiceBusConnection serviceBusConnection;

        public AmqpTransactionEnlistment(
            Transaction transaction,
            AmqpTransactionManager transactionManager,
            ServiceBusConnection serviceBusConnection)
        {
            transactionId = transaction.TransactionInformation.LocalIdentifier;
            this.transactionManager = transactionManager;
            this.serviceBusConnection = serviceBusConnection;
        }

        public ArraySegment<byte> AmqpTransactionId { get; private set; }
        
        protected override async Task<AmqpTransactionEnlistment> OnCreateAsync(TimeSpan timeout)
        {
            try
            {
                var faultTolerantController = serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(serviceBusConnection.OperationTimeout).ConfigureAwait(false);
                AmqpTransactionId = await controller.DeclareAsync().ConfigureAwait(false);
                MessagingEventSource.Log.AmqpTransactionDeclared(transactionId, AmqpTransactionId);
                return this;
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpTransactionInitializeException(transactionId, exception);
                transactionManager.RemoveEnlistment(transactionId);
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
            transactionManager.RemoveEnlistment(transactionId);
            TaskExtensionHelper.Schedule(() => SinglePhaseCommitAsync(singlePhaseEnlistment));
        }

        private async Task SinglePhaseCommitAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                var faultTolerantController = serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(serviceBusConnection.OperationTimeout).ConfigureAwait(false);

                await controller.DischargeAsync(AmqpTransactionId, fail: false).ConfigureAwait(false);
                singlePhaseEnlistment.Committed();
                MessagingEventSource.Log.AmqpTransactionDischarged(transactionId, AmqpTransactionId, false);
                await CloseAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.GetClientException(e, null);
                MessagingEventSource.Log.AmqpTransactionDischargeException(transactionId, AmqpTransactionId, exception);
                singlePhaseEnlistment.InDoubt(exception);
            }
        }

        void IPromotableSinglePhaseNotification.Rollback(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            transactionManager.RemoveEnlistment(transactionId);
            TaskExtensionHelper.Schedule(() => RollbackAsync(singlePhaseEnlistment));
        }

        private async Task RollbackAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                var faultTolerantController = serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(serviceBusConnection.OperationTimeout).ConfigureAwait(false);

                await controller.DischargeAsync(AmqpTransactionId, fail: true).ConfigureAwait(false);
                singlePhaseEnlistment.Aborted();
                MessagingEventSource.Log.AmqpTransactionDischarged(transactionId, AmqpTransactionId, true);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.GetClientException(e, null);
                MessagingEventSource.Log.AmqpTransactionDischargeException(transactionId, AmqpTransactionId, exception);
                singlePhaseEnlistment.Aborted(exception);
            }
        }

        byte[] ITransactionPromoter.Promote()
        {
            throw new TransactionPromotionException("Local transactions are not supported with other resource managers/DTC.");
        }
    }
}
