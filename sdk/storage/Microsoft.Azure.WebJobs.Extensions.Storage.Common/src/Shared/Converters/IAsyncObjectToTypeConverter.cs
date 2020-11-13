﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters
{
    /// <summary>
    /// Provides an interface for performing asynchronous conversions from
    /// an object to a particular type.
    /// </summary>
    /// <typeparam name="TOutput">The type to convert to.</typeparam>
    internal interface IAsyncObjectToTypeConverter<TOutput>
    {
        /// <summary>
        /// Try to convert the specified input object.
        /// </summary>
        /// <param name="input">The object to convert.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A task that returns the conversion result.</returns>
        Task<ConversionResult<TOutput>> TryConvertAsync(object input, CancellationToken cancellationToken);
    }
}
