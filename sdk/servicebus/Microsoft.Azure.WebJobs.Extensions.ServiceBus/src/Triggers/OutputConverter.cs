// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class OutputConverter<TInput> : IObjectToTypeConverter<ServiceBusMessage>
        where TInput : class
    {
        private readonly IConverter<TInput, ServiceBusMessage> _innerConverter;

        public OutputConverter(IConverter<TInput, ServiceBusMessage> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out ServiceBusMessage output)
        {
            TInput typedInput = input as TInput;

            if (typedInput == null)
            {
                output = null;
                return false;
            }

            output = _innerConverter.Convert(typedInput);
            return true;
        }
    }
}
