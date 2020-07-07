// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Helpers for creating bindings to common patterns such as Messaging or Streams.
    /// This will add additional adapters to connect the user's parameter type to an IAsyncCollector. 
    /// It will also see <see cref="IConverterManager"/> to convert 
    /// from the user's type to the underlying IAsyncCollector's message type.
    /// For example, for messaging patterns, if the user is a ICollector, this will add an adapter that implements ICollector and calls IAsyncCollector.  
    /// </summary>
    internal static class BindingFactoryHelpers
    {
        // If a conversion function exists from TMessage --> exactType, then use it. 
        // else return null.
        private static SimpleTriggerArgumentBinding<TMessage, TTriggerValue> GetDirectTriggerBinding<TMessage, TTriggerValue>(
            Type exactType,
            ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy,
            IConverterManager converterManager)
        {
            // Wrapper to convert runtime Type to a compile time  generic. 
            var method = typeof(BindingFactoryHelpers).GetMethod("GetDirectTriggerBindingWorker", BindingFlags.NonPublic | BindingFlags.Static);
            method = method.MakeGenericMethod(typeof(TMessage), typeof(TTriggerValue), exactType);
            var argumentBinding = MethodInvoke<SimpleTriggerArgumentBinding<TMessage, TTriggerValue>>(
                method, 
                bindingStrategy, converterManager);
            return argumentBinding;
        }

        private static SimpleTriggerArgumentBinding<TMessage, TTriggerValue>
            GetDirectTriggerBindingWorker<TMessage, TTriggerValue, TUserType>(
            ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy,
            IConverterManager converterManager)
        {
            var directConvert = converterManager.GetConverter<TMessage, TUserType, Attribute>();
            if (directConvert != null)
            {
                var argumentBinding = new CustomTriggerArgumentBinding<TMessage, TTriggerValue, TUserType>(
                    bindingStrategy, converterManager, directConvert);
                return argumentBinding;
            }
            return null;
        }

        // Bind a trigger argument to various parameter types. 
        // Handles either T or T[], 
        internal static ITriggerDataArgumentBinding<TTriggerValue> GetTriggerArgumentBinding<TMessage, TTriggerValue>(
            ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy,
            ParameterInfo parameter,
            IConverterManager converterManager,
            out bool singleDispatch)
        {
            ITriggerDataArgumentBinding<TTriggerValue> argumentBinding = null;

            // If there's a direct binding from TMessage to the parameter's exact type; use that. 
            // This takes precedence over array bindings. 
            argumentBinding = GetDirectTriggerBinding<TMessage, TTriggerValue>(parameter.ParameterType, bindingStrategy, converterManager);
            if (argumentBinding != null)
            {
                singleDispatch = true;
                return argumentBinding;
            }

            // Or array 
            if (parameter.ParameterType.IsArray)
            {
                // dispatch the entire batch in a single call. 
                singleDispatch = false;

                var elementType = parameter.ParameterType.GetElementType();
                var innerArgumentBinding = GetTriggerArgumentElementBinding<TMessage, TTriggerValue>(elementType, bindingStrategy, converterManager);
                                
                argumentBinding = new ArrayTriggerArgumentBinding<TMessage, TTriggerValue>(bindingStrategy, innerArgumentBinding, converterManager);

                return argumentBinding;
            }
            else
            {
                // Dispatch each item one at a time
                singleDispatch = true;

                var elementType = parameter.ParameterType;
                argumentBinding = GetTriggerArgumentElementBinding<TMessage, TTriggerValue>(elementType, bindingStrategy, converterManager);
                return argumentBinding;
            }
        }

        // Bind a T. 
        private static SimpleTriggerArgumentBinding<TMessage, TTriggerValue> GetTriggerArgumentElementBinding<TMessage, TTriggerValue>(
            Type elementType,
            ITriggerBindingStrategy<TMessage, TTriggerValue> bindingStrategy,
            IConverterManager converterManager)
        {
            var argumentBinding = GetDirectTriggerBinding<TMessage, TTriggerValue>(elementType, bindingStrategy, converterManager);
            if (argumentBinding != null)
            {
                // Exact match in converter manager. Always takes precedence. 
                return argumentBinding;
            }

            if (elementType == typeof(TMessage))
            {
                return new SimpleTriggerArgumentBinding<TMessage, TTriggerValue>(bindingStrategy, converterManager);
            }
            if (elementType == typeof(string))
            {
                return new StringTriggerArgumentBinding<TMessage, TTriggerValue>(bindingStrategy, converterManager);
            }
            else
            {
                // Catch-all. 
                // Default, assume a Poco
                return new PocoTriggerArgumentBinding<TMessage, TTriggerValue>(bindingStrategy, converterManager, elementType);
            }
        }
                
        // Helper to invoke and unwrap the target exception. 
        public static TReturn MethodInvoke<TReturn>(MethodInfo method, params object[] args)
        {
            try
            {
                var result = method.Invoke(null, args);
                return (TReturn)result;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}