// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters
{
    /// <summary>
    /// Represents the result of a conversion.
    /// </summary>
    /// <typeparam name="TResult">The <see cref="System.Type"/> of the conversion result.</typeparam>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    internal struct ConversionResult<TResult>
    {
        /// <summary>
        /// Gets a value indicating whether the conversion succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets the conversion result.
        /// </summary>
        public TResult Result { get; set; }
    }
}
