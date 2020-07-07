// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines methods for retrieving information for an arbitrary value.
    /// </summary>
    public interface IValueProvider
    {
        /// <summary>
        /// Gets the <see cref="Type"/> of the value.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>A task that returns the value.</returns>
        Task<object> GetValueAsync();

        /// <summary>
        /// Returns a string representation of the value.
        /// </summary>
        /// <returns>The string representation of the value.</returns>
        string ToInvokeString();
    }
}
