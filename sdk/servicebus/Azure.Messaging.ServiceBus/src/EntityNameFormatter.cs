// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Management;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This class can be used to format the path for different Service Bus entity types.
    /// </summary>
    public static class EntityNameFormatter
    {
        private const string PathDelimiter = @"/";
        private const string SubscriptionsSubPath = "Subscriptions";
        private const string RulesSubPath = "Rules";
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
            return EntityNameFormatter.FormatSubQueuePath(entityPath, EntityNameFormatter.DeadLetterQueueName);
        }

        /// <summary>
        /// Formats the subqueue path for either a queue, or a subscription.
        /// </summary>
        /// <param name="entityPath">The name of the queue, or path of the subscription.</param>
        /// <param name="subQueueName"></param>
        /// <returns>The path as a string of the subqueue entity.</returns>
        public static string FormatSubQueuePath(string entityPath, string subQueueName)
        {
            return string.Concat(entityPath, EntityNameFormatter.PathDelimiter, subQueueName);
        }

        /// <summary>
        /// Formats the subscription path, based on the topic path and subscription name.
        /// </summary>
        /// <param name="topicPath">The name of the topic, including slashes.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        public static string FormatSubscriptionPath(string topicPath, string subscriptionName)
        {
            return string.Concat(topicPath, PathDelimiter, SubscriptionsSubPath, PathDelimiter, subscriptionName);
        }

        /// <summary>
        /// Formats the rule path, based on the topic path, subscription name and rule name.
        /// </summary>
        /// <param name="topicPath">The name of the topic, including slashes.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="ruleName">The name of the rule</param>
        public static string FormatRulePath(string topicPath, string subscriptionName, string ruleName)
        {
            return string.Concat(
                topicPath, PathDelimiter,
                SubscriptionsSubPath, PathDelimiter,
                subscriptionName, PathDelimiter,
                RulesSubPath, PathDelimiter, ruleName);
        }

        /// <summary>
        /// Utility method that creates the name for the transfer dead letter receiver, specified by <paramref name="entityPath"/>
        /// </summary>
        public static string Format​Transfer​Dead​Letter​Path(string entityPath)
        {
            return string.Concat(entityPath, PathDelimiter, TransferDeadLetterQueueName);
        }

        internal static void CheckValidQueueName(string queueName, string paramName = "queuePath")
        {
            CheckValidEntityName(GetPathWithoutBaseUri(queueName), ManagementClientConstants.QueueNameMaximumLength, true, paramName);
        }

        internal static void CheckValidTopicName(string topicName, string paramName = "topicPath")
        {
            CheckValidEntityName(topicName, ManagementClientConstants.TopicNameMaximumLength, true, paramName);
        }

        internal static void CheckValidSubscriptionName(string subscriptionName, string paramName = "subscriptionName")
        {
            CheckValidEntityName(subscriptionName, ManagementClientConstants.SubscriptionNameMaximumLength, false, paramName);
        }

        internal static void CheckValidRuleName(string ruleName, string paramName = "ruleName")
        {
            CheckValidEntityName(ruleName, ManagementClientConstants.RuleNameMaximumLength, false, paramName);
        }

        private static void CheckValidEntityName(string entityName, int maxEntityNameLength, bool allowSeparator, string paramName)
        {
            if (string.IsNullOrWhiteSpace(entityName))
            {
                throw new ArgumentNullException(paramName);
            }

            // and "\" will be converted to "/" on the REST path anyway. Gateway/REST do not
            // have to worry about the begin/end slash problem, so this is purely a client side check.
            var tmpName = entityName.Replace(@"\", Constants.PathDelimiter);
            if (tmpName.Length > maxEntityNameLength)
            {
                throw new ArgumentOutOfRangeException(paramName, $@"Entity path '{entityName}' exceeds the '{maxEntityNameLength}' character limit.");
            }

            if (tmpName.StartsWith(Constants.PathDelimiter, StringComparison.OrdinalIgnoreCase) ||
                tmpName.EndsWith(Constants.PathDelimiter, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($@"The entity name/path cannot contain '/' as prefix or suffix. The supplied value is '{entityName}'", paramName);
            }

            if (!allowSeparator && tmpName.Contains(Constants.PathDelimiter))
            {
                throw new ArgumentException($@"The entity name/path contains an invalid character '{Constants.PathDelimiter}'", paramName);
            }

            foreach (var uriSchemeKey in ManagementClientConstants.InvalidEntityPathCharacters)
            {
                if (entityName.IndexOf(uriSchemeKey) >= 0)
                {
                    throw new ArgumentException($@"'{entityName}' contains character '{uriSchemeKey}' which is not allowed because it is reserved in the Uri scheme.", paramName);
                }
            }
        }

        private static string GetPathWithoutBaseUri(string entityName)
        {
            // Note: on Linux/macOS, "/path" URLs are treated as valid absolute file URLs.
            // To ensure relative queue paths are correctly rejected on these platforms,
            // an additional check using IsWellFormedOriginalString() is made here.
            // See https://github.com/dotnet/corefx/issues/22098 for more information.
            if (Uri.TryCreate(entityName, UriKind.Absolute, out Uri uriValue) &&
                uriValue.IsWellFormedOriginalString())
            {
                entityName = uriValue.PathAndQuery;
                return entityName.TrimStart('/');
            }
            return entityName;
        }
    }
}
