// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal interface IQueueTriggerArgumentBindingProvider
    {
        ITriggerDataArgumentBinding<QueueMessage> TryCreate(ParameterInfo parameter);
    }
}
