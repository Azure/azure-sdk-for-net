// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs.Host.Bindings.StorageAccount
{
    internal class OutputConverter<TInput> : IObjectToTypeConverter<CloudStorageAccount>
        where TInput : class
    {
        private readonly IConverter<TInput, CloudStorageAccount> _innerConverter;

        public OutputConverter(IConverter<TInput, CloudStorageAccount> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out CloudStorageAccount output)
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
