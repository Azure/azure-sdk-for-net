// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
    internal class BlobOutputConverter<TInput> : IAsyncObjectToTypeConverter<ICloudBlob>
        where TInput : class
    {
        private readonly IAsyncConverter<TInput, ICloudBlob> _innerConverter;

        public BlobOutputConverter(IAsyncConverter<TInput, ICloudBlob> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        public async Task<ConversionResult<ICloudBlob>> TryConvertAsync(object input,
            CancellationToken cancellationToken)
        {
            TInput typedInput = input as TInput;

            if (typedInput == null)
            {
                return new ConversionResult<ICloudBlob>
                {
                    Succeeded = false,
                    Result = null
                };
            }

            var blob = await _innerConverter.ConvertAsync(typedInput, cancellationToken);

            return new ConversionResult<ICloudBlob>
            {
                Succeeded = true,
                Result = blob
            };
        }
    }
}
