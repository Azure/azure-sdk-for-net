// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class OutputConverter<TInput> : IObjectToTypeConverter<CloudQueueMessage>
        where TInput : class
    {
        private readonly IConverter<TInput, CloudQueueMessage> _innerConverter;

        public OutputConverter(IConverter<TInput, CloudQueueMessage> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out CloudQueueMessage output)
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
