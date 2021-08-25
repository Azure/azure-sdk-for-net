// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal static class ServiceBusCausalityHelper
    {
        private const string ParentGuidFieldName = "$AzureWebJobsParentId";

        public static void EncodePayload(Guid functionOwner, ServiceBusMessage msg)
        {
            msg.ApplicationProperties[ParentGuidFieldName] = functionOwner.ToString();
        }

        public static Guid? GetOwner(ServiceBusReceivedMessage message)
        {
            if (message.ApplicationProperties.TryGetValue(ParentGuidFieldName, out var parent))
            {
                if (Guid.TryParse(parent?.ToString(), out var parentGuid))
                {
                    return parentGuid;
                }
            }
            return null;
        }
    }
}
