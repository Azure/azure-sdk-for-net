// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters
{
    /// <summary>
    /// A converter that simply returns the value to be converted,
    /// without performing any conversions.
    /// </summary>
    /// <typeparam name="TValue">The <see cref="System.Type"/> being converted.</typeparam>
    internal class IdentityConverter<TValue> : IConverter<TValue, TValue>
    {
        /// <inheritdoc/>
        public TValue Convert(TValue input)
        {
            return input;
        }
    }
}
