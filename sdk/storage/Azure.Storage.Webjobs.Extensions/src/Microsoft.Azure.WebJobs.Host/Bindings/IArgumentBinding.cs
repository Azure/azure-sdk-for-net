// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Interface for performing bind operations on job function arguments.
    /// </summary>
    /// <typeparam name="TArgument">The argument type.</typeparam>
    public interface IArgumentBinding<TArgument>
    {
        /// <summary>
        /// The <see cref="Type"/> of the argument value.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Bind to the specified argument value using the specified binding context.
        /// </summary>
        /// <param name="value">The value to bind to.</param>
        /// <param name="context">The binding context.</param>
        /// <returns>A task that returns the <see cref="IValueProvider"/> for the bound argument.</returns>
        Task<IValueProvider> BindAsync(TArgument value, ValueBindingContext context);
    }
}
