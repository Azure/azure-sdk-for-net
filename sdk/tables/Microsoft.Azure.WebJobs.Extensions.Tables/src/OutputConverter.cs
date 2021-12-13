// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class OutputConverter<TInput> : IObjectToTypeConverter<TableClient>
        where TInput : class
    {
        private readonly IConverter<TInput, TableClient> _innerConverter;

        public OutputConverter(IConverter<TInput, TableClient> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out TableClient output)
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