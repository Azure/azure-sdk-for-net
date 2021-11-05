// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class BlobOutputConverter<TInput> : IAsyncObjectToTypeConverter<BlobBaseClient>
        where TInput : class
    {
        private readonly IAsyncConverter<TInput, BlobBaseClient> _innerConverter;

        public BlobOutputConverter(IAsyncConverter<TInput, BlobBaseClient> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public async Task<ConversionResult<BlobBaseClient>> TryConvertAsync(object input,
            CancellationToken cancellationToken)
        {
            TInput typedInput = input as TInput;

            if (typedInput == null)
            {
                return new ConversionResult<BlobBaseClient>
                {
                    Succeeded = false,
                    Result = null
                };
            }

            var blob = await _innerConverter.ConvertAsync(typedInput, cancellationToken).ConfigureAwait(false);

            return new ConversionResult<BlobBaseClient>
            {
                Succeeded = true,
                Result = blob
            };
        }
    }
}
