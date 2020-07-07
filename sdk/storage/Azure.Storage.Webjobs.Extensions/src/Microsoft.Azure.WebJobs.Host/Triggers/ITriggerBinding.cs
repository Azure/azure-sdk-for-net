// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Triggers
{
    /// <summary>
    /// Interface defining a trigger parameter binding.
    /// </summary>
    public interface ITriggerBinding
    {
        /// <summary>
        /// The trigger value type that this binding binds to.
        /// </summary>
        Type TriggerValueType { get; }

        /// <summary>
        /// Gets the binding data contract.
        /// </summary>
        IReadOnlyDictionary<string, Type> BindingDataContract { get; }

        /// <summary>
        /// Perform a bind to the specified value using the specified binding context.
        /// </summary>
        /// <param name="value">The value to bind to. 
        /// This is commonly passed from the listener via <see cref="ITriggeredFunctionExecutor.TryExecuteAsync(TriggeredFunctionData, System.Threading.CancellationToken)"/>  </param>
        /// <param name="context">The binding context.</param>
        /// <returns>A task that returns the <see cref="ITriggerData"/> for the binding.</returns>
        Task<ITriggerData> BindAsync(object value, ValueBindingContext context);

        /// <summary>
        /// Creates a <see cref="IListener"/> for the trigger parameter.
        /// </summary>
        /// <param name="context">The <see cref="ListenerFactoryContext"/> to use.</param>
        /// <returns>The <see cref="IListener"/>.</returns>
        Task<IListener> CreateListenerAsync(ListenerFactoryContext context);

        /// <summary>
        /// Get a description of the binding.
        /// </summary>
        /// <returns>The <see cref="ParameterDescriptor"/></returns>
        ParameterDescriptor ToParameterDescriptor();
    }
}
