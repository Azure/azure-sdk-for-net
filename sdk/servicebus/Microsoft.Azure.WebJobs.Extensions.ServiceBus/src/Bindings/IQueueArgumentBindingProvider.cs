// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal interface IQueueArgumentBindingProvider
    {
        IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter);
    }
}
