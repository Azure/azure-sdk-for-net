// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class OutputConverter<TInput> : IObjectToTypeConverter<CloudTable>
        where TInput : class
    {
        private readonly IConverter<TInput, CloudTable> _innerConverter;

        public OutputConverter(IConverter<TInput, CloudTable> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out CloudTable output)
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