// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;
    using Core;
    using Framing;
    using Primitives;

    internal sealed class AmqpSubscriptionClient : IInnerSubscriptionClient
    {
        int prefetchCount;
        readonly object syncLock;
        MessageReceiver innerReceiver;

        static AmqpSubscriptionClient()
        {
            AmqpCodec.RegisterKnownTypes(AmqpTrueFilterCodec.Name, AmqpTrueFilterCodec.Code, () => new AmqpTrueFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpFalseFilterCodec.Name, AmqpFalseFilterCodec.Code, () => new AmqpFalseFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpCorrelationFilterCodec.Name, AmqpCorrelationFilterCodec.Code, () => new AmqpCorrelationFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpSqlFilterCodec.Name, AmqpSqlFilterCodec.Code, () => new AmqpSqlFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpEmptyRuleActionCodec.Name, AmqpEmptyRuleActionCodec.Code, () => new AmqpEmptyRuleActionCodec());
            AmqpCodec.RegisterKnownTypes(AmqpSqlRuleActionCodec.Name, AmqpSqlRuleActionCodec.Code, () => new AmqpSqlRuleActionCodec());
            AmqpCodec.RegisterKnownTypes(AmqpRuleDescriptionCodec.Name, AmqpRuleDescriptionCodec.Code, () => new AmqpRuleDescriptionCodec());
        }

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

        ServiceBusConnection ServiceBusConnection { get; }

        RetryPolicy RetryPolicy { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        ReceiveMode ReceiveMode { get; }

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

        public async Task<IList<RuleDescription>> OnGetRulesAsync(int top, int skip)
        {
            try
            {
                var amqpRequestMessage =
                    AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.EnumerateRulesOperation,
                        this.ServiceBusConnection.OperationTimeout,
                        null);
                amqpRequestMessage.Map[ManagementConstants.Properties.Top] = top;
                amqpRequestMessage.Map[ManagementConstants.Properties.Skip] = skip;

                var response = await this.InnerReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
                var ruleDescriptions = new List<RuleDescription>();
                if (response.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var ruleList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Rules);
                    foreach (var entry in ruleList)
                    {
                        var amqpRule = (AmqpRuleDescriptionCodec)entry[ManagementConstants.Properties.RuleDescription];
                        var ruleDescription = AmqpMessageConverter.GetRuleDescription(amqpRule);
                        ruleDescriptions.Add(ruleDescription);
                    }
                }
                else if (response.StatusCode == AmqpResponseStatusCode.NoContent)
                {
                    // Do nothing. Return empty list;
                }
                else
                {
                    throw response.ToMessagingContractException();
                }

                return ruleDescriptions;
            }
            catch (Exception exception)
            {
                throw AmqpExceptionHelper.GetClientException(exception);
            }
        }
    }
}