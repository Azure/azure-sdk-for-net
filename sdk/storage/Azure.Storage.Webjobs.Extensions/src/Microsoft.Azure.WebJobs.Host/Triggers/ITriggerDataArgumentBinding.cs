// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Interface providing the capability to bind to trigger parameter values.
    /// </summary>
    /// <typeparam name="TTriggerValue">The type of the trigger value.</typeparam>
    internal interface ITriggerDataArgumentBinding<TTriggerValue>
    {
        /// <summary>
        /// Gets the type of the trigger value.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Gets the binding data contract.
        /// </summary>
        IReadOnlyDictionary<string, Type> BindingDataContract { get; }

        /// <summary>
        /// Bind to the specified trigger value.
        /// </summary>
        /// <param name="value">The value to bind to.</param>
        /// <param name="context">The binding context.</param>
        /// <returns>A task that returns the <see cref="ITriggerData"/> for the binding.</returns>
        Task<ITriggerData> BindAsync(TTriggerValue value, ValueBindingContext context);
    }
}
