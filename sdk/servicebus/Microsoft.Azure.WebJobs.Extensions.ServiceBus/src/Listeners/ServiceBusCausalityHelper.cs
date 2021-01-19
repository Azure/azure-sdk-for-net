// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal static class ServiceBusCausalityHelper
    {
        private const string ParentGuidFieldName = "$AzureWebJobsParentId";

        public static void EncodePayload(Guid functionOwner, Message msg)
        {
            msg.UserProperties[ParentGuidFieldName] = functionOwner.ToString();
        }

        public static Guid? GetOwner(Message msg)
        {
            object parent;
            if (msg.UserProperties.TryGetValue(ParentGuidFieldName, out parent))
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
