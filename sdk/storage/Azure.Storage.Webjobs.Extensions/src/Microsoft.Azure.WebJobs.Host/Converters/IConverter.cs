// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Defines methods for performing value conversions
    /// </summary>
    /// <typeparam name="TInput">The input value type.</typeparam>
    /// <typeparam name="TOutput">The output value type.</typeparam>
    public interface IConverter<TInput, TOutput>
    {
        /// <summary>
        /// Convert the specified input value.
        /// </summary>
        /// <param name="input">The value to convert</param>
        /// <returns>The converted value.</returns>
        TOutput Convert(TInput input);
    }   
}
