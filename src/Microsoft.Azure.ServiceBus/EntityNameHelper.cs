// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>
    /// This class can be used to format the path for different Service Bus entity types.
    /// </summary>
    public static class EntityNameHelper
    {
        private const string PathDelimiter = @"/";
        private const string Subscriptions = "Subscriptions";
        private const string SubQueuePrefix = "$";
        private const string DeadLetterQueueSuffix = "DeadLetterQueue";
        private const string DeadLetterQueueName = SubQueuePrefix + DeadLetterQueueSuffix;
        private const string Transfer = "Transfer";
        private const string TransferDeadLetterQueueName = SubQueuePrefix + Transfer + PathDelimiter + DeadLetterQueueName;

        /// <summary>
        /// Formats the dead letter path for either a queue, or a subscription.
        /// </summary>
        /// <param name="entityPath">The name of the queue, or path of the subscription.</param>
        /// <returns>The path as a string of the dead letter entity.</returns>
        public static string FormatDeadLetterPath(string entityPath)
        {
            return EntityNameHelper.FormatSubQueuePath(entityPath, EntityNameHelper.DeadLetterQueueName);
        }

        /// <summary>
        /// Formats the subqueue path for either a queue, or a subscription.
        /// </summary>
        /// <param name="entityPath">The name of the queue, or path of the subscription.</param>
        /// <param name="subQueueName">The name of the subqueue.</param>
        /// <returns>The path as a string of the subqueue entity.</returns>
        public static string FormatSubQueuePath(string entityPath, string subQueueName)
        {
            return string.Concat(entityPath, EntityNameHelper.PathDelimiter, subQueueName);
        }

        /// <summary>
        /// Formats the subscription path, based on the topic path and subscription name.
        /// </summary>
        /// <param name="topicPath">The name of the topic, including slashes.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <returns></returns>
        public static string FormatSubscriptionPath(string topicPath, string subscriptionName)
        {
            return string.Concat(topicPath, PathDelimiter, Subscriptions, PathDelimiter, subscriptionName);
        }

        /// <summary>
        /// Utility method that creates the name for the transfer dead letter receiver, specified by <paramref name="entityPath"/>
        /// </summary>
        public static string Format​Transfer​Dead​Letter​Path(string entityPath)
        {
            return string.Concat(entityPath, PathDelimiter, TransferDeadLetterQueueName);
        }
    }
}