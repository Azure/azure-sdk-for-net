// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    // Helper class for implementing IBinding with the attribute resolver pattern.
    internal abstract class BindingBase<TAttribute> : IBinding
        where TAttribute : Attribute
    {
        protected readonly AttributeCloner<TAttribute> Cloner;
        private readonly ParameterDescriptor param;

        public BindingBase(BindingProviderContext context, IConfiguration configuration, INameResolver nameResolver)
        {
            var attributeSource = TypeUtility.GetResolvedAttribute<TAttribute>(context.Parameter);
            Cloner = new AttributeCloner<TAttribute>(attributeSource, context.BindingDataContract, configuration, nameResolver);

            param = new ParameterDescriptor
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

        protected abstract Task<IValueProvider> BuildAsync(TAttribute attrResolved, IReadOnlyDictionary<string, object> bindingContext);

        public async Task<IValueProvider> BindAsync(BindingContext context)
        {
            var attrResolved = Cloner.ResolveFromBindingData(context);
            return await BuildAsync(attrResolved, context.BindingData).ConfigureAwait(false);
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            throw new NotImplementedException();
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return param;
        }
    }
}