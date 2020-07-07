// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Defines an interface for the creation of parameter bindings.
    /// </summary>
    public interface IBindingProvider
    {
        /// <summary>
        /// Try to create a binding using the specified context.
        /// </summary>
        /// <param name="context">The binding context.</param>
        /// <returns>A task that returns the binding on completion.</returns>
        Task<IBinding> TryCreateAsync(BindingProviderContext context);
    }
}
