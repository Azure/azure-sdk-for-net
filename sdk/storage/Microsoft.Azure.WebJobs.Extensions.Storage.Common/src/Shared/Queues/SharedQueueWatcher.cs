﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal class SharedQueueWatcher : IMessageEnqueuedWatcher
    {
        private readonly ConcurrentDictionary<string, ConcurrentBag<INotificationCommand>> _registrations =
            new ConcurrentDictionary<string, ConcurrentBag<INotificationCommand>>();

        public void Notify(string enqueuedInQueueName)
        {
            ConcurrentBag<INotificationCommand> queueRegistrations;

            if (_registrations.TryGetValue(enqueuedInQueueName, out queueRegistrations))
            {
                foreach (INotificationCommand registration in queueRegistrations.ToArray())
                {
                    registration.Notify();
                }
            }
        }

        public void Register(string queueName, INotificationCommand notification)
        {
            _registrations.AddOrUpdate(queueName,
                new ConcurrentBag<INotificationCommand>(new INotificationCommand[] { notification }),
                (i, existing) => { existing.Add(notification); return existing; });
        }
    }
}
