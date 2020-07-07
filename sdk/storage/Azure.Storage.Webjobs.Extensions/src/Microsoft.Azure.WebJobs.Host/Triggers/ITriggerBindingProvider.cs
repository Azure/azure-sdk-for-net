// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Defines a provider of <see cref="ITriggerBinding"/>s
    /// </summary>
    public interface ITriggerBindingProvider
    {
        /// <summary>
        /// Try to bind using the specified context.
        /// </summary>
        /// <param name="context">The binding context.</param>
        /// <returns>A <see cref="ITriggerBinding"/> if successful, null otherwise.</returns>
        Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context);
    }
}
