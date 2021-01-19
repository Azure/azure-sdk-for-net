// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class MessageArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (!parameter.IsOut || parameter.ParameterType != typeof(Message).MakeByRefType())
            {
                return null;
            }

            return new MessageArgumentBinding();
        }
    }
}
