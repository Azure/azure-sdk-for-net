// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.WebJobs.Host.Converters
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
