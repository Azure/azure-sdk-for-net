// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using System.Transactions;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    class AmqpTransactionEnlistment : Singleton<AmqpTransactionEnlistment>, IPromotableSinglePhaseNotification
    {
        readonly string transactionId;
        readonly AmqpTransactionManager transactionManager;
        readonly ServiceBusConnection serviceBusConnection;

        public AmqpTransactionEnlistment(
            Transaction transaction,
            AmqpTransactionManager transactionManager,
            ServiceBusConnection serviceBusConnection)
        {
            this.transactionId = transaction.TransactionInformation.LocalIdentifier;
            this.transactionManager = transactionManager;
            this.serviceBusConnection = serviceBusConnection;
        }

        public ArraySegment<byte> AmqpTransactionId { get; private set; }
        
        protected override async Task<AmqpTransactionEnlistment> OnCreateAsync(TimeSpan timeout)
        {
            try
            {
                var faultTolerantController = this.serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(this.serviceBusConnection.OperationTimeout).ConfigureAwait(false);
                this.AmqpTransactionId = await controller.DeclareAsync().ConfigureAwait(false);
                MessagingEventSource.Log.AmqpTransactionDeclared(this.transactionId, this.AmqpTransactionId);
                return this;
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpTransactionInitializeException(this.transactionId, exception);
                this.transactionManager.RemoveEnlistment(this.transactionId);
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
            this.transactionManager.RemoveEnlistment(this.transactionId);
            TaskExtensionHelper.Schedule(() => this.SinglePhaseCommitAsync(singlePhaseEnlistment));
        }

        async Task SinglePhaseCommitAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                var faultTolerantController = this.serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(this.serviceBusConnection.OperationTimeout).ConfigureAwait(false);

                await controller.DischargeAsync(this.AmqpTransactionId, fail: false).ConfigureAwait(false);
                singlePhaseEnlistment.Committed();
                MessagingEventSource.Log.AmqpTransactionDischarged(this.transactionId, this.AmqpTransactionId, false);
                await this.CloseAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.GetClientException(e, true, null);
                MessagingEventSource.Log.AmqpTransactionDischargeException(this.transactionId, this.AmqpTransactionId, exception);
                singlePhaseEnlistment.InDoubt(exception);
            }
        }

        void IPromotableSinglePhaseNotification.Rollback(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            this.transactionManager.RemoveEnlistment(this.transactionId);
            TaskExtensionHelper.Schedule(() => this.RollbackAsync(singlePhaseEnlistment));
        }

        async Task RollbackAsync(SinglePhaseEnlistment singlePhaseEnlistment)
        {
            try
            {
                var faultTolerantController = this.serviceBusConnection.TransactionController;
                var controller = await faultTolerantController.GetOrCreateAsync(this.serviceBusConnection.OperationTimeout).ConfigureAwait(false);

                await controller.DischargeAsync(this.AmqpTransactionId, fail: true).ConfigureAwait(false);
                singlePhaseEnlistment.Aborted();
                MessagingEventSource.Log.AmqpTransactionDischarged(this.transactionId, this.AmqpTransactionId, true);
            }
            catch (Exception e)
            {
                Exception exception = AmqpExceptionHelper.GetClientException(e, true, null);
                MessagingEventSource.Log.AmqpTransactionDischargeException(this.transactionId, this.AmqpTransactionId, exception);
                singlePhaseEnlistment.Aborted(exception);
            }
        }

        byte[] ITransactionPromoter.Promote()
        {
            throw new TransactionPromotionException("Local transactions are not supported with other resource managers/DTC.");
        }
    }
}
