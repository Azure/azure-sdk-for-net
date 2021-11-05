// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Triggers;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal interface IQueueTriggerArgumentBindingProvider
    {
        ITriggerDataArgumentBinding<QueueMessage> TryCreate(ParameterInfo parameter);
    }
}
