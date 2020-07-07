// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class ClassOutputConverter<TInput, TOutput> : IObjectToTypeConverter<TOutput>
        where TInput : class
    {
        private readonly IConverter<TInput, TOutput> _innerConverter;

        public ClassOutputConverter(IConverter<TInput, TOutput> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out TOutput output)
        {
            TInput typedInput = input as TInput;

            if (typedInput == null)
            {
                output = default(TOutput);
                return false;
            }

            output = _innerConverter.Convert(typedInput);
            return true;
        }
    }
}
