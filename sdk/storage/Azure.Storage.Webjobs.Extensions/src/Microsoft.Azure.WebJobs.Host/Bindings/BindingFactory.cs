// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Helper class for creating some generally useful BindingProviders
    /// </summary>
    [Obsolete("Not ready for public consumption.")]
    public class BindingFactory
    {
        /// <summary>
        /// Bind a  parameter to an IAsyncCollector. Use this for things that have discrete output items (like sending messages or writing table rows)
        /// This will add additional adapters to connect the user's parameter type to an IAsyncCollector. 
        /// </summary>
        /// <typeparam name="TMessage">The 'core type' for the IAsyncCollector.</typeparam>
        /// <typeparam name="TTriggerValue">The type of the trigger object to pass to the listener.</typeparam>
        /// <param name="bindingStrategy">A strategy object that describes how to do the binding</param>
        /// <param name="parameter">The user's parameter being bound to</param>
        /// <param name="converterManager">The converter manager, used to convert between the user parameter's type and the underlying native types used by the trigger strategy</param>
        /// <param name="createListener">A function to create the underlying listener for this parameter</param>
        /// <returns>A trigger binding</returns>
        public static ITriggerBinding GetTriggerBinding<TMessage, TTriggerValue>(
            ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy,
            ParameterInfo parameter,
            IConverterManager converterManager,
            Func<ListenerFactoryContext, bool, Task<IListener>> createListener)
        {
            if (bindingStrategy == null)
            {
                throw new ArgumentNullException("bindingStrategy");
            }
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            bool singleDispatch;
            var argumentBinding = BindingFactoryHelpers.GetTriggerArgumentBinding(bindingStrategy, parameter, converterManager, out singleDispatch);

            var parameterDescriptor = new ParameterDescriptor
            {
                Name = parameter.Name,
                DisplayHints = new ParameterDisplayHints
                {
                    Description = singleDispatch ? "message" : "messages"
                }
            };

            ITriggerBinding binding = new StrategyTriggerBinding<TMessage, TTriggerValue>(
                bindingStrategy, argumentBinding, createListener, parameterDescriptor, singleDispatch);

            return binding;
        }
    }
}