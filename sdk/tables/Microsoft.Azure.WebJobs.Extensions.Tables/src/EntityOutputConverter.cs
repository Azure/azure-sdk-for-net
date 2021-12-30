// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class EntityOutputConverter<TInput> : IObjectToTypeConverter<TableEntityContext>
        where TInput : class
    {
        private readonly IConverter<TInput, TableEntityContext> _innerConverter;

        public EntityOutputConverter(IConverter<TInput, TableEntityContext> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out TableEntityContext output)
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