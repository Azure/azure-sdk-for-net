// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit.Abstractions;

    public abstract class QueueClientTestBase : SenderReceiverClientTestBase
    {
        protected QueueClientTestBase(ITestOutputHelper output)
            : base(output)
        {
        }

        protected string ConnectionString { get; set; }

        public async Task QueueClientPeekLockTestCase(int messageCount)
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                await this.PeekLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                queueClient.Close();
            }
        }

        public async Task QueueClientReceiveDeleteTestCase(int messageCount)
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveDeleteTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                queueClient.Close();
            }
        }

        public async Task QueueClientPeekLockWithAbandonTestCase(int messageCount)
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                await this.PeekLockWithAbandonTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                queueClient.Close();
            }
        }

        public async Task QueueClientPeekLockWithDeadLetterTestCase(int messageCount)
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);

            // Create DLQ Client To Receive DeadLetteredMessages
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(this.ConnectionString);
            builder.EntityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            QueueClient deadLetterQueueClient = QueueClient.CreateFromConnectionString(builder.ToString());

            try
            {
                await this.PeekLockWithDeadLetterTestCase(queueClient.InnerSender, queueClient.InnerReceiver, deadLetterQueueClient.InnerReceiver, messageCount);
            }
            finally
            {
                deadLetterQueueClient.Close();
                queueClient.Close();
            }
        }

        public async Task QueueClientPeekLockDeferTestCase(int messageCount)
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                await this.PeekLockDeferTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                queueClient.Close();
            }
        }

        public async Task QueueClientRenewLockTestCase(int messageCount)
        {
            QueueClient queueClient = QueueClient.CreateFromConnectionString(this.ConnectionString);
            try
            {
                await this.RenewLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                queueClient.Close();
            }
        }
    }
}