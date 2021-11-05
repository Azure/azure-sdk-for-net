// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal interface IMessageEnqueuedWatcher
    {
        void Notify(string enqueuedInQueueName);
    }
}
