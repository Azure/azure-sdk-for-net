// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Helper class for implementing IBinding with the attribute resolver pattern. 
    internal abstract class BindingBase<TAttribute> : IBinding
        where TAttribute : Attribute
    {
        protected readonly AttributeCloner<TAttribute> Cloner;
        private readonly ParameterDescriptor _param;

        public BindingBase(AttributeCloner<TAttribute> cloner, ParameterDescriptor param)
        {
            Cloner = cloner;
            _param = param;
        }

        public BindingBase(AttributeCloner<TAttribute> cloner, ParameterInfo parameterInfo)
        {
            Cloner = cloner;
            _param = new ParameterDescriptor
            {
                Name = parameterInfo.Name,
                DisplayHints = new ParameterDisplayHints
                {
                    Description = "value"
                }
            };
        }

        public bool FromAttribute
        {
            get
            {
                return true;
            }
        }

        protected abstract Task<IValueProvider> BuildAsync(TAttribute attrResolved, ValueBindingContext context);

        public async Task<IValueProvider> BindAsync(BindingContext context)
        {
            var attrResolved = Cloner.ResolveFromBindingData(context);
            return await BuildAsync(attrResolved, context.ValueContext);
        }

        public async Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            var str = value as string;
            if (str != null)
            {
                // Called when we invoke from dashboard. 
                // str --> attribute --> obj 
                var resolvedAttr = Cloner.ResolveFromInvokeString(str);
                return await BuildAsync(resolvedAttr, context);
            }
            else
            {
                // Passed a direct object, such as JobHost.Call 
                throw new NotImplementedException();
            }
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return _param;
        }
    }
}
