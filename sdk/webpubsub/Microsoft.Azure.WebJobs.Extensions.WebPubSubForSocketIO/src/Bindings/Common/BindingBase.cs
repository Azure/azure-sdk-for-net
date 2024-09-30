// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// copy from https://github.com/Azure/azure-webjobs-sdk/blob/v3.0.29/src/Microsoft.Azure.WebJobs.Host/Bindings/BindingBase.cs.
    /// </summary>
    // Helper class for implementing IBinding with the attribute resolver pattern.
    internal abstract class BindingBase<TAttribute> : IBinding
        where TAttribute : Attribute
    {
        protected readonly AttributeCloner<TAttribute> Cloner;
        private readonly ParameterDescriptor _param;

        public BindingBase(BindingProviderContext context, IConfiguration configuration, INameResolver nameResolver)
        {
            var attributeSource = TypeUtility.GetResolvedAttribute<TAttribute>(context.Parameter);
            Cloner = new AttributeCloner<TAttribute>(attributeSource, context.BindingDataContract, configuration, nameResolver);
            _param = new ParameterDescriptor
            {
                Name = context.Parameter.Name,
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

        protected abstract Task<IValueProvider> BuildAsync(TAttribute attrResolved, IReadOnlyDictionary<string, object> bindingData);

        public async Task<IValueProvider> BindAsync(BindingContext context)
        {
            var attrResolved = Cloner.ResolveFromBindingData(context);
            return await BuildAsync(attrResolved, context.BindingData).ConfigureAwait(false);
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            // TODO: Called when we invoke from dashboard.
            // str --> attribute --> obj
            // Passed a direct object, such as JobHost.Call
            throw new NotImplementedException();
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return _param;
        }
    }
}
