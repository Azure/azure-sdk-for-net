// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal static class ServiceBusEntityPathHelper
    {
        public static EntityType ParseEntityType(string entityPath)
        {
            return entityPath.IndexOf("/Subscriptions/", StringComparison.OrdinalIgnoreCase) >= 0 ? EntityType.Topic : EntityType.Queue;
        }

        public static void ParseTopicAndSubscription(string entityPath, out string topic, out string subscription)
        {
            string[] arr = Regex.Split(entityPath, "/Subscriptions/", RegexOptions.IgnoreCase);

            if (arr.Length < 2)
            {
                throw new InvalidOperationException($"{entityPath} is either formatted incorrectly, or is not a valid Service Bus subscription path");
            }

            topic = arr[0];
            subscription = arr[1];
        }
    }
}
