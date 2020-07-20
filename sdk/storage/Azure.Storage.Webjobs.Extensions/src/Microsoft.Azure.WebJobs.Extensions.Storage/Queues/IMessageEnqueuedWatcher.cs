// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    internal interface IMessageEnqueuedWatcher
    {
        void Notify(string enqueuedInQueueName);
    }
}
