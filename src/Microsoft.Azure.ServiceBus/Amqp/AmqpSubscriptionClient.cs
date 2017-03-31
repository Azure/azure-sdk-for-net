// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Azure.Amqp;
    using Core;
    using Filters;
    using Messaging.Amqp;

    internal sealed class AmqpSubscriptionClient : AmqpClient, IInnerSubscriptionClient
    {
        public AmqpSubscriptionClient(
            ServiceBusConnection servicebusConnection,
            string entityPath,
            MessagingEntityType entityType,
            RetryPolicy retryPolicy,
            ReceiveMode mode = ReceiveMode.ReceiveAndDelete)
            : base(servicebusConnection, entityPath, entityType, retryPolicy, mode)
        {
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

                AmqpResponseMessage response =
                    await
                        ((AmqpMessageReceiver)this.InnerReceiver).ExecuteRequestResponseAsync(amqpRequestMessage)
                            .ConfigureAwait(false);

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

                var response = await ((AmqpMessageReceiver)this.InnerReceiver).ExecuteRequestResponseAsync(amqpRequestMessage).ConfigureAwait(false);

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