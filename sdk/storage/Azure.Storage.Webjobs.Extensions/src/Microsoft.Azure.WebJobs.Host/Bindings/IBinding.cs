// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines an interface for a parameter binding.
    /// </summary>
    public interface IBinding
    {
        /// <summary>
        /// Gets a value indicating whether the binding was sourced from a parameter attribute.
        /// </summary>
        bool FromAttribute { get; }

        /// <summary>
        /// Perform a bind to the specified value.
        /// </summary>
        /// <param name="value">The value to bind to.</param>
        /// <param name="context">The binding context.</param>
        /// <returns>A task that returns the <see cref="IValueProvider"/> for the binding.</returns>
        Task<IValueProvider> BindAsync(object value, ValueBindingContext context);

        /// <summary>
        /// Perform a bind using the specified context.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A task that returns the <see cref="IValueProvider"/> for the binding.</returns>
        Task<IValueProvider> BindAsync(BindingContext context);

        /// <summary>
        /// Get a description of the binding.
        /// </summary>
        /// <returns></returns>
        ParameterDescriptor ToParameterDescriptor();
    }
}
