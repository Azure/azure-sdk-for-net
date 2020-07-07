// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Useful for extension  that need some special case type restriction. 
    // If the user parameter type passes the predicate, then chain to an inner an provider. 
    internal class FilteringBindingProvider<TAttribute> : IBindingProvider, IBindingRuleProvider
        where TAttribute : Attribute
    {
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;
        private readonly IBindingProvider _inner;
        private readonly FilterNode _description;

        public FilteringBindingProvider(
            IConfiguration configuration,
            INameResolver nameResolver,  
            IBindingProvider inner,
            FilterNode description)
        {
            _configuration = configuration;
            _nameResolver = nameResolver;
            _inner = inner;
            _description = description;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Type parametertype = context.Parameter.ParameterType;

            var attr = context.Parameter.GetCustomAttribute<TAttribute>();

            var cloner = new AttributeCloner<TAttribute>(attr, context.BindingDataContract, _configuration, _nameResolver);
            var attrNameResolved = cloner.GetNameResolvedAttribute();

            // This may do validation and throw too. 
            bool canBind = _description.Eval(attrNameResolved);

            if (!canBind)
            {
                return Task.FromResult<IBinding>(null);
            }
            return _inner.TryCreateAsync(context);
        }

        public IEnumerable<BindingRule> GetRules()
        {
            IBindingRuleProvider inner = _inner as IBindingRuleProvider;
            if (inner != null)
            {
                foreach (var rule in inner.GetRules())
                {
                    rule.Filter = FilterNode.And(_description, rule.Filter);
                    yield return rule;
                }
            }
        }

        public Type GetDefaultType(Attribute attribute, FileAccess access, Type requestedType)
        {
            TAttribute attr = attribute as TAttribute;
            if (attr == null)
            {
                return null;
            }
            bool ok = _description.Eval(attribute);
            if (!ok)
            {
                return null;
            }

            // Must apply filter 
            IBindingRuleProvider inner = _inner as IBindingRuleProvider;
            if (inner != null)
            {
                return inner.GetDefaultType(attribute, access, requestedType);
            }
            return null;
        }
    }
}