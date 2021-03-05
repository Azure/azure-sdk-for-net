﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ServiceBusEntity
    {
        public ServiceBusSender MessageSender { get; set; }

        public EntityType EntityType { get; set; } = EntityType.Queue;

        public Task SendAndCreateEntityIfNotExistsAsync(ServiceBusMessage message, Guid functionInstanceId, CancellationToken cancellationToken)
        {
            return MessageSender.SendAndCreateEntityIfNotExists(message, functionInstanceId, cancellationToken);
        }
    }
}
