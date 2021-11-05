// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters
{
    /// <summary>
    /// Defines methods for converting objects to another <see cref="System.Type"/>.
    /// </summary>
    /// <typeparam name="TOutput">The output <see cref="System.Type"/>.</typeparam>
    internal interface IObjectToTypeConverter<TOutput>
    {
        /// <summary>
        /// Try to convert the specified object to the output <see cref="System.Type"/>.
        /// </summary>
        /// <param name="input">The object to convert.</param>
        /// <param name="output">If the conversion was successful, the result of the conversion.</param>
        /// <returns>True if the conversion was successful, false otherwise.</returns>
        bool TryConvert(object input, out TOutput output);
    }
}
