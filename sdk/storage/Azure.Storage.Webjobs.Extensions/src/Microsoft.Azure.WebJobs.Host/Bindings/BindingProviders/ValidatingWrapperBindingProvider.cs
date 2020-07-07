// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Applies a local validator function for just a specific rule. 
    // Validator only runs if the inner rule claims it. 
    internal class ValidatingWrapperBindingProvider<TAttribute> : IBindingProvider
        where TAttribute : Attribute
    {
        private readonly Action<TAttribute, Type> _validator;
        private readonly IBindingProvider _inner;
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;

        public ValidatingWrapperBindingProvider(Action<TAttribute, Type> validator, IConfiguration configuration, INameResolver nameResolver, IBindingProvider inner)
        {
            _validator = validator;
            _inner = inner;
            _configuration = configuration;
            _nameResolver = nameResolver;
        }

        public async Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var binding = await _inner.TryCreateAsync(context);

            if (binding != null)
            {
                // Only run the validator if the inner binding claims it. 
                // Expected this will throw on errors. 
                Type parameterType = context.Parameter.ParameterType;
                var attr = context.Parameter.GetCustomAttribute<TAttribute>();

                var cloner = new AttributeCloner<TAttribute>(attr, context.BindingDataContract, _configuration, _nameResolver);
                var attrNameResolved = cloner.GetNameResolvedAttribute();
                _validator(attrNameResolved, parameterType);
            }

            return binding;
        }
    }
}