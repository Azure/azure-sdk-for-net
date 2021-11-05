// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters
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
                ConversionResult<T> result = await converter.TryConvertAsync(value, cancellationToken).ConfigureAwait(false);

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
