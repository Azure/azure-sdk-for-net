// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.ServiceBus.Filters;

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
            syncLock = new object();
            Path = path;
            ServiceBusConnection = servicebusConnection;
            RetryPolicy = retryPolicy;
            CbsTokenProvider = cbsTokenProvider;
            PrefetchCount = prefetchCount;
            ReceiveMode = mode;
        }

        public MessageReceiver InnerReceiver
        {
            get
            {
                if (innerReceiver == null)
                {
                    lock (syncLock)
                    {
                        if (innerReceiver == null)
                        {
                            innerReceiver = new MessageReceiver(
                                Path,
                                MessagingEntityType.Subscriber,
                                ReceiveMode,
                                ServiceBusConnection,
                                CbsTokenProvider,
                                RetryPolicy,
                                PrefetchCount);
                        }
                    }
                }

                return innerReceiver;
            }
        }

        /// <summary>
        /// Gets or sets the number of messages that the subscription client can simultaneously request.
        /// </summary>
        /// <value>The number of messages that the subscription client can simultaneously request.</value>
        public int PrefetchCount
        {
            get => prefetchCount;
            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(PrefetchCount), value, "Value cannot be less than 0.");
                }
                prefetchCount = value;
                if (innerReceiver != null)
                {
                    innerReceiver.PrefetchCount = value;
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
            return innerReceiver?.CloseAsync();
        }

        public async Task OnAddRuleAsync(RuleDescription description)
        {
            try
            {
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.AddRuleOperation,
                    ServiceBusConnection.OperationTimeout,
                    null);
                amqpRequestMessage.Map[ManagementConstants.Properties.RuleName] = description.Name;
                amqpRequestMessage.Map[ManagementConstants.Properties.RuleDescription] =
                    AmqpMessageConverter.GetRuleDescriptionMap(description);

                var response = await InnerReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

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
                        ServiceBusConnection.OperationTimeout,
                        null);
                amqpRequestMessage.Map[ManagementConstants.Properties.RuleName] = ruleName;

                var response = await InnerReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

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
                        ServiceBusConnection.OperationTimeout,
                        null);
                amqpRequestMessage.Map[ManagementConstants.Properties.Top] = top;
                amqpRequestMessage.Map[ManagementConstants.Properties.Skip] = skip;

                var response = await InnerReceiver.ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);
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