// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    public static class EntityNameHelper
    {
        public const string PathDelimiter = @"/";
        public const string Subscriptions = "Subscriptions";
        public const string SubQueuePrefix = "$";
        public const string DeadLetterQueueSuffix = "DeadLetterQueue";
        public const string DeadLetterQueueName = SubQueuePrefix + DeadLetterQueueSuffix;

        public static string FormatDeadLetterPath(string entityPath)
        {
            return EntityNameHelper.FormatSubQueuePath(entityPath, EntityNameHelper.DeadLetterQueueName);
        }

        public static string FormatSubQueuePath(string entityPath, string subQueueName)
        {
            return string.Concat(entityPath, EntityNameHelper.PathDelimiter, subQueueName);
        }

        public static string FormatSubscriptionPath(string topicPath, string subscriptionName)
        {
            return string.Concat(topicPath, PathDelimiter, Subscriptions, PathDelimiter, subscriptionName);
        }
    }
}