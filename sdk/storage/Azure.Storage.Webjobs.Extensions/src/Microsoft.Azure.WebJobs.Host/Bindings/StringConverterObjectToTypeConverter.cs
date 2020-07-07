// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class StringConverterObjectToTypeConverter<TOutput> : IObjectToTypeConverter<TOutput>
    {
        private readonly IConverter<string, TOutput> _stringConverter;

        public StringConverterObjectToTypeConverter(IConverter<string, TOutput> stringConverter)
        {
            _stringConverter = stringConverter;
        }

        public bool TryConvert(object input, out TOutput output)
        {
            string inputString = input as string;

            if (inputString == null)
            {
                output = default(TOutput);
                return false;
            }

            output = _stringConverter.Convert(inputString);
            return true;
        }
    }
}
