// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Binding provider for filter context parameters (<see cref="FunctionExecutedContext"/> and 
    /// <see cref="FunctionExecutingContext"/> ).
    /// </summary>
    internal class FunctionFilterBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            var param = context.Parameter;
            IBinding binding = null;
            var parameterType = param.ParameterType;
            if (parameterType == typeof(FunctionExecutedContext) ||
                parameterType == typeof(FunctionExecutingContext))
            {
                binding = new FilterBinding(parameterType, param.Name);
            }
            return Task.FromResult(binding);
        }

        // The challenge is that we have a context parameter in the arguments, but we don't have the parameter name.
        // But parameter arguments are already provided via the binding data; and we have a unique type to match against, 
        // so we can pull the context parameter from the binding data by type. 
        private class FilterBinding : IBinding
        {
            public bool FromAttribute => false;

            private readonly Type _type;
            private readonly string _parameterName;

            public FilterBinding(Type type, string parameterName)
            {
                _type = type;
                _parameterName = parameterName;
            }

            public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
            {
                return Bind(value);
            }

            private Task<IValueProvider> Bind(object value)
            {
                var valueProvider = new ObjectValueProvider(value, _type);
                return Task.FromResult<IValueProvider>(valueProvider);
            }

            public Task<IValueProvider> BindAsync(BindingContext context)
            {
                foreach (var kv in context.BindingData)
                {
                    var val = kv.Value;
                    if (val != null && val.GetType() == _type)
                    {
                        return Bind(val);
                    }
                }
                throw new InvalidOperationException("Unable to bind filter context.");
            }

            public ParameterDescriptor ToParameterDescriptor()
            {
                return new ParameterDescriptor
                {
                    Name = _parameterName
                };
            }
        }
    }
}
