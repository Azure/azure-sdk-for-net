// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Azure.Amqp;
    using Core;
    using Filters;

    internal sealed class AmqpSubscriptionClient : IInnerSubscriptionClient
    {
        int prefetchCount;
        readonly object syncLock;
        MessageReceiver innerReceiver;

        public AmqpSubscriptionClient(
            string path,
            ServiceBusConnection servicebusConnection,
            RetryPolicy retryPolicy,
            ICbsTokenProvider cbsTokenProvider,
            int prefetchCount = 0,
            ReceiveMode mode = ReceiveMode.ReceiveAndDelete)
        {
            this.syncLock = new object();
            this.Path = path;
            this.ServiceBusConnection = servicebusConnection;
            this.RetryPolicy = retryPolicy;
            this.CbsTokenProvider = cbsTokenProvider;
            this.PrefetchCount = prefetchCount;
            this.ReceiveMode = mode;
        }

        public MessageReceiver InnerReceiver
        {
            get
            {
                if (this.innerReceiver == null)
                {
                    lock (this.syncLock)
                    {
                        if (this.innerReceiver == null)
                        {
                            this.innerReceiver = new MessageReceiver(
                                this.Path,
                                MessagingEntityType.Subscriber,
                                this.ReceiveMode,
                                this.ServiceBusConnection,
                                this.CbsTokenProvider,
                                this.RetryPolicy,
                                this.PrefetchCount);
                        }
                    }
                }

                return this.innerReceiver;
            }
        }

        /// <summary>
        /// Gets or sets the number of messages that the subscription client can simultaneously request.
        /// </summary>
        /// <value>The number of messages that the subscription client can simultaneously request.</value>
        public int PrefetchCount
        {
            get => this.prefetchCount;
            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(this.PrefetchCount), value, "Value cannot be less than 0.");
                }
                this.prefetchCount = value;
                if (this.innerReceiver != null)
                {
                    this.innerReceiver.PrefetchCount = value;
                }
            }
        }

        ServiceBusConnection ServiceBusConnection { get; set; }

        RetryPolicy RetryPolicy { get; set; }

        ICbsTokenProvider CbsTokenProvider { get; set; }

        ReceiveMode ReceiveMode { get; set; }

        string Path { get; }

        public Task CloseAsync()
        {
            return this.innerReceiver?.CloseAsync();
        }

        public async Task OnAddRuleAsync(RuleDescription description)
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.AddRuleOperation,
                    this.ServiceBusConnection.OperationTimeout,
                    null);
                amqpRequestMessage.Map[ManagementConstants.Properties.RuleName] = description.Name;
                amqpRequestMessage.Map[ManagementConstants.Properties.RuleDescription] =
                    AmqpMessageConverter.GetRuleDescriptionMap(description);

                var response = await this.InnerReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (response.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw response.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }

        public async Task OnRemoveRuleAsync(string ruleName)
        {
            try
            {
                var amqpRequestMessage =
                    AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.RemoveRuleOperation,
                        this.ServiceBusConnection.OperationTimeout,
                        null);
                amqpRequestMessage.Map[ManagementConstants.Properties.RuleName] = ruleName;

                var response = await this.InnerReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

                if (response.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw response.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }
    }
}