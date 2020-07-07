// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class CompositeAsyncObjectToTypeConverter<T> : IAsyncObjectToTypeConverter<T>
    {
        private readonly IEnumerable<IAsyncObjectToTypeConverter<T>> _converters;

        public CompositeAsyncObjectToTypeConverter(IEnumerable<IAsyncObjectToTypeConverter<T>> converters)
        {
            _converters = converters;
        }

        public CompositeAsyncObjectToTypeConverter(params IAsyncObjectToTypeConverter<T>[] converters)
            : this((IEnumerable<IAsyncObjectToTypeConverter<T>>)converters)
        {
        }

        public async Task<ConversionResult<T>> TryConvertAsync(object value, CancellationToken cancellationToken)
        {
            foreach (IAsyncObjectToTypeConverter<T> converter in _converters)
            {
                ConversionResult<T> result = await converter.TryConvertAsync(value, cancellationToken);

                if (result.Succeeded)
                {
                    return result;
                }
            }

            return new ConversionResult<T>
            {
                Succeeded = false,
                Result = default(T)
            };
        }
    }
}
