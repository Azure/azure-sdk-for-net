// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Runtime
{
    internal class AttributeBindingSource : IAttributeBindingSource
    {
        private readonly MemberInfo _memberInfo;
        private readonly IBindingProvider _bindingProvider;
        private readonly AmbientBindingContext _context;

        public AttributeBindingSource(MemberInfo memberInfo, IBindingProvider bindingProvider, AmbientBindingContext context)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("memberInfo");
            }

            if (bindingProvider == null)
            {
                throw new ArgumentNullException("bindingProvider");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _memberInfo = memberInfo;
            _bindingProvider = bindingProvider;
            _context = context;
        }

        public AmbientBindingContext AmbientBindingContext
        {
            get { return _context; }
        }

        public Task<IBinding> BindAsync<TValue>(Attribute attribute, Attribute[] additionalAttributes = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            ParameterInfo parameterInfo = new FakeParameterInfo(typeof(TValue), _memberInfo, attribute, additionalAttributes);
            BindingProviderContext bindingProviderContext =
                new BindingProviderContext(parameterInfo, bindingDataContract: null, cancellationToken: cancellationToken);

            return _bindingProvider.TryCreateAsync(bindingProviderContext);
        }

        // A non-reflection based implementation
        private class FakeParameterInfo : ParameterInfo
        {
            private readonly Collection<Attribute> _attributes = new Collection<Attribute>();

            public FakeParameterInfo(Type parameterType, MemberInfo memberInfo, Attribute attribute, Attribute[] additionalAttributes)
            {
                ClassImpl = parameterType;
                AttrsImpl = ParameterAttributes.In;
                NameImpl = "?";
                MemberImpl = memberInfo;

                // union all the parameter attributes
                _attributes.Add(attribute);
                if (additionalAttributes != null)
                {
                    foreach (var additionalAttribute in additionalAttributes)
                    {
                        _attributes.Add(additionalAttribute);
                    }
                }
            }

            public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                return _attributes.Where(p => p.GetType() == attributeType).ToArray();
            }
        }
    }
}
