// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class FunctionBinding : IFunctionBinding
    {
        private readonly FunctionDescriptor _descriptor;
        private readonly IReadOnlyDictionary<string, IBinding> _bindings;
        private readonly SingletonManager _singletonManager;

        public FunctionBinding(FunctionDescriptor descriptor, IReadOnlyDictionary<string, IBinding> bindings, SingletonManager singletonManager)
        {
            _descriptor = descriptor;
            _bindings = bindings;
            _singletonManager = singletonManager;
        }

        // Create a bindingContext. 
        // parameters takes precedence over existingBindingData.
        internal static BindingContext NewBindingContext(
            ValueBindingContext context, 
            IReadOnlyDictionary<string, object> existingBindingData,  
            IDictionary<string, object> parameters)
        {
            // if bindingData was a mutable dictionary, we could just add it. 
            // But since it's read-only, must create a new one. 
            Dictionary<string, object> bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            var funcContext = context.FunctionContext;
            var methodName = funcContext.MethodName;
            
            if (existingBindingData != null)
            {
                foreach (var kv in existingBindingData)
                {
                    bindingData[kv.Key] = kv.Value;
                }
            }
            if (parameters != null)
            {
                foreach (var kv in parameters)
                {
                    bindingData[kv.Key] = kv.Value;
                }
            }

            // Add 'sys' binding data. 
            var sysBindingData = new SystemBindingData
            {
                MethodName = methodName
            };
            sysBindingData.AddToBindingData(bindingData);

            BindingContext bindingContext = new BindingContext(context, bindingData);
            return bindingContext;
        }

        public async Task<IReadOnlyDictionary<string, IValueProvider>> BindAsync(ValueBindingContext context, IDictionary<string, object> parameters)
        {
            Dictionary<string, IValueProvider> results = new Dictionary<string, IValueProvider>();

            // Supplied bindings can be direct parameters or route parameters. 
            BindingContext bindingContext = NewBindingContext(context, null, parameters);

            // bind Singleton if specified
            SingletonAttribute singletonAttribute = SingletonManager.GetFunctionSingletonOrNull(_descriptor, isTriggered: false);
            if (singletonAttribute != null)
            {
                string boundScopeId = _singletonManager.GetBoundScopeId(singletonAttribute.ScopeId);
                IValueProvider singletonValueProvider = new SingletonValueProvider(_descriptor, boundScopeId, context.FunctionInstanceId.ToString(), singletonAttribute, _singletonManager);
                results.Add(SingletonValueProvider.SingletonParameterName, singletonValueProvider);
            }

            foreach (KeyValuePair<string, IBinding> item in _bindings)
            {
                string name = item.Key;
                IBinding binding = item.Value;
                IValueProvider valueProvider;

                try
                {
                    if (parameters != null && parameters.ContainsKey(name))
                    {
                        valueProvider = await binding.BindAsync(parameters[name], context);
                    }
                    else
                    {
                        valueProvider = await binding.BindAsync(bindingContext);
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    valueProvider = new BindingExceptionValueProvider(name, exception);
                }

                results.Add(name, valueProvider);
            }

            return results;
        }
    }
}
