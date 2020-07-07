// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Converters
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