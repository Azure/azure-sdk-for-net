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

        public static Guid? GetOwner(ServiceBusReceivedMessage msg)
        {
            object parent;
            if (msg.ApplicationProperties.TryGetValue(ParentGuidFieldName, out parent))
            {
                var parentString = parent as string;
                if (parentString != null)
                {
                    Guid parentGuid;
                    if (Guid.TryParse(parentString, out parentGuid))
                    {
                        return parentGuid;
                    }
                }
            }
            return null;
        }

        public static Guid? GetOwner(ServiceBusMessage msg)
        {
            object parent;
            if (msg.ApplicationProperties.TryGetValue(ParentGuidFieldName, out parent))
            {
                var parentString = parent as string;
                if (parentString != null)
                {
                    Guid parentGuid;
                    if (Guid.TryParse(parentString, out parentGuid))
                    {
                        return parentGuid;
                    }
                }
            }
            return null;
        }
    }
}
