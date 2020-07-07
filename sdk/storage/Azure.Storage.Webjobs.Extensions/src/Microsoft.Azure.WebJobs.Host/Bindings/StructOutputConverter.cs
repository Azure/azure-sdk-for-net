// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class StructOutputConverter<TInput, TOutput> : IObjectToTypeConverter<TOutput>
    {
        private readonly bool _isNullable;
        private readonly IConverter<TInput, TOutput> _innerConverter;

        public StructOutputConverter(IConverter<TInput, TOutput> innerConverter)
        {
            _isNullable = TypeUtility.IsNullable(typeof(TInput));
            _innerConverter = innerConverter;
        }

        public bool TryConvert(object input, out TOutput output)
        {
            if (!(input is TInput) && !(input == null && _isNullable))
            {
                output = default(TOutput);
                return false;
            }

            output = _innerConverter.Convert((TInput)input);
            return true;
        }
    }
}
