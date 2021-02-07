// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class OutputConverter<TInput> : IObjectToTypeConverter<QueueMessage>
        where TInput : class
    {
        private readonly IConverter<TInput, QueueMessage> _innerConverter;

        public OutputConverter(IConverter<TInput, QueueMessage> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out QueueMessage output)
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
